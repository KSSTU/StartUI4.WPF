using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace StartUI4Controls
{
    public class UI4TrayMenuItem
    {
        public UI4MenuItemType Type { get; set; }
        public string Text { get; set; }
        public ImageSource Icon { get; set; }
        public Action Command { get; set; }
        public Func<bool> CanExecute { get; set; }

        public UI4TrayMenuItem(UI4MenuItemType type, string text, ImageSource icon, Action command, Func<bool> canExecute = null)
        {
            Type = type;
            Text = text;
            Icon = icon;
            Command = command;
            CanExecute = canExecute;
        }
    }

    public class UI4NotifyIcon : TaskbarIcon
    {
        #region 菜单样式依赖属性
        public double MenuWidth
        {
            get => (double)GetValue(MenuWidthProperty);
            set => SetValue(MenuWidthProperty, value);
        }
        public static readonly DependencyProperty MenuWidthProperty =
            DependencyProperty.Register(
                nameof(MenuWidth),
                typeof(double),
                typeof(UI4NotifyIcon),
                new FrameworkPropertyMetadata(160d));

        public Thickness MenuItemPadding
        {
            get => (Thickness)GetValue(MenuItemPaddingProperty);
            set => SetValue(MenuItemPaddingProperty, value);
        }
        public static readonly DependencyProperty MenuItemPaddingProperty =
            DependencyProperty.Register(
                nameof(MenuItemPadding),
                typeof(Thickness),
                typeof(UI4NotifyIcon),
                new FrameworkPropertyMetadata(new Thickness(12, 8, 12, 8)));

        public Color MenuBorderColor
        {
            get => (Color)GetValue(MenuBorderColorProperty);
            set => SetValue(MenuBorderColorProperty, value);
        }
        public static readonly DependencyProperty MenuBorderColorProperty =
            DependencyProperty.Register(
                nameof(MenuBorderColor),
                typeof(Color),
                typeof(UI4NotifyIcon),
                new FrameworkPropertyMetadata(Color.FromArgb(255, 200, 200, 220)));

        public Brush MenuBackground
        {
            get => (Brush)GetValue(MenuBackgroundProperty);
            set => SetValue(MenuBackgroundProperty, value);
        }
        public static readonly DependencyProperty MenuBackgroundProperty =
            DependencyProperty.Register(
                nameof(MenuBackground),
                typeof(Brush),
                typeof(UI4NotifyIcon),
                new FrameworkPropertyMetadata(Brushes.White));

        public Color MenuHoverBg
        {
            get => (Color)GetValue(MenuHoverBgProperty);
            set => SetValue(MenuHoverBgProperty, value);
        }
        public static readonly DependencyProperty MenuHoverBgProperty =
            DependencyProperty.Register(
                nameof(MenuHoverBg),
                typeof(Color),
                typeof(UI4NotifyIcon),
                new FrameworkPropertyMetadata(Color.FromArgb(10, 0, 0, 0)));

        public CornerRadius MenuCornerRadius
        {
            get => (CornerRadius)GetValue(MenuCornerRadiusProperty);
            set => SetValue(MenuCornerRadiusProperty, value);
        }
        public static readonly DependencyProperty MenuCornerRadiusProperty =
            DependencyProperty.Register(
                nameof(MenuCornerRadius),
                typeof(CornerRadius),
                typeof(UI4NotifyIcon),
                new FrameworkPropertyMetadata(new CornerRadius(8)));
        #endregion

        private Popup _trayPopup;
        private UI4ListBox _listBox;
        private readonly List<UI4TrayMenuItem> _menuItems = new List<UI4TrayMenuItem>();

        public UI4NotifyIcon()
        {
            MenuActivation = PopupActivationMode.None;
            TrayRightMouseUp += OnTrayRightClick;
            BuildTrayPopup();
        }

        #region 对外API
        public void AddItem(UI4TrayMenuItem item)
        {
            _menuItems.Add(item);
        }

        public void AddItem(UI4MenuItemType type, Action command, Func<bool> canExecute = null)
        {
            var langDict = UI4ContextMenuLanguage.Current;
            if (!langDict.ContainsKey(type)) return;

            var item = new UI4TrayMenuItem(
                type,
                langDict[type],
                UI4MenuIcons.GetIcon(type),
                command,
                canExecute);
            _menuItems.Add(item);
        }

        public void ClearMenuItems()
        {
            _menuItems.Clear();
            if (_listBox != null)
                _listBox.Items.Clear();
        }
        #endregion

        #region 构建Popup容器
        private void BuildTrayPopup()
        {
            _listBox = new UI4ListBox
            {
                Width = MenuWidth,
                ItemPadding = MenuItemPadding,
                BorderNormalColor = MenuBorderColor,
                Background = MenuBackground,
                HoverBackground = MenuHoverBg,
                CornerRadius = MenuCornerRadius,
            };

            _listBox.PreviewMouseLeftButtonUp += OnListBoxClick;

            _trayPopup = new Popup
            {
                Child = _listBox,
                Placement = PlacementMode.AbsolutePoint,
                StaysOpen = false,
                AllowsTransparency = true,
                PopupAnimation = PopupAnimation.Slide
            };
            _trayPopup.Closed += (s, e) => _listBox.SelectedIndex = -1;
        }

        private void RebuildAllRows()
        {
            _listBox.Items.Clear();
            foreach (var item in _menuItems)
            {
                var container = new Grid();
                container.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                container.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                if (item.Icon != null)
                {
                    var icon = new Image
                    {
                        Source = item.Icon,
                        Width = 16,
                        Height = 16,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Opacity = item.CanExecute?.Invoke() ?? true ? 1.0 : 0.3
                    };
                    Grid.SetColumn(icon, 0);
                    container.Children.Add(icon);
                }

                var textBlock = new TextBlock
                {
                    Text = item.Text,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(6, 0, 0, 0),
                    Opacity = item.CanExecute?.Invoke() ?? true ? 1.0 : 0.4
                };
                Grid.SetColumn(textBlock, 1);
                container.Children.Add(textBlock);

                container.Tag = item;
                _listBox.Items.Add(container);
            }

            _listBox.Width = MenuWidth;
        }
        #endregion

        private void OnListBoxClick(object sender, MouseButtonEventArgs e)
        {
            // 命中测试：从鼠标位置向上查找 ListBoxItem
            var hit = _listBox.InputHitTest(e.GetPosition(_listBox)) as DependencyObject;
            while (hit != null && hit != _listBox)
            {
                if (hit is ListBoxItem lbi)
                {
                    if (lbi.Content is FrameworkElement fe && fe.Tag is UI4TrayMenuItem item)
                    {
                        bool canExec = item.CanExecute?.Invoke() ?? true;
                        if (canExec)
                        {
                            item.Command?.Invoke();
                            CloseMenu();
                        }
                        e.Handled = true;
                    }
                    break;
                }
                hit = VisualTreeHelper.GetParent(hit);
            }
        }

        #region 托盘右键事件
        private void OnTrayRightClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            OpenMenu();
        }
        #endregion

        #region 菜单弹出/关闭
        public void OpenMenu()
        {
            if (_menuItems.Count == 0) return;

            RebuildAllRows();
            Point mousePos = GetMouseScreenPositionDip();
            _trayPopup.HorizontalOffset = mousePos.X;
            _trayPopup.VerticalOffset = mousePos.Y;

            _listBox.BeginAnimation(UIElement.OpacityProperty, null);
            _listBox.Opacity = 0;
            _trayPopup.IsOpen = true;

            var fadeAnim = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(150));
            _listBox.BeginAnimation(UIElement.OpacityProperty, fadeAnim);
        }

        public void CloseMenu()
        {
            if (_trayPopup != null)
                _trayPopup.IsOpen = false;
            if (_listBox != null)
                _listBox.SelectedIndex = -1;
        }
        #endregion

        #region 屏幕鼠标坐标获取（P/Invoke）
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        /// 获取鼠标在屏幕上的物理坐标，并转换为 WPF 设备无关像素（DIP）
        private Point GetMouseScreenPositionDip()
        {
            GetCursorPos(out POINT pt);
            var transform = PresentationSource.FromVisual(this)?.CompositionTarget?.TransformFromDevice
                            ?? Matrix.Identity;
            return transform.Transform(new Point(pt.X, pt.Y));
        }
        #endregion

        #region 资源释放
        public new void Dispose()
        {
            TrayRightMouseUp -= OnTrayRightClick;
            CloseMenu();
            ClearMenuItems();
            Visibility = Visibility.Collapsed;
            base.Dispose();
        }
        #endregion
    }
}
