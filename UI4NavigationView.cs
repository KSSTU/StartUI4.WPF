using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace StartUI4Controls
{

    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class InverseNullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class UI4NavigationViewItem : ContentControl
    {
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(UI4NavigationViewItem));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(UI4NavigationViewItem));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty TextIconProperty =
            DependencyProperty.Register("TextIcon", typeof(string), typeof(UI4NavigationViewItem),
                new FrameworkPropertyMetadata(null));

        public string TextIcon
        {
            get { return (string)GetValue(TextIconProperty); }
            set { SetValue(TextIconProperty, value); }
        }

        public static readonly DependencyProperty TextIconFontFamilyProperty =
            DependencyProperty.Register("TextIconFontFamily", typeof(FontFamily), typeof(UI4NavigationViewItem),
                new FrameworkPropertyMetadata(null));

        public FontFamily TextIconFontFamily
        {
            get { return (FontFamily)GetValue(TextIconFontFamilyProperty); }
            set { SetValue(TextIconFontFamilyProperty, value); }
        }

        public static readonly DependencyProperty ItemFontSizeProperty =
    DependencyProperty.Register("ItemFontSize", typeof(double), typeof(UI4NavigationView),
        new FrameworkPropertyMetadata(13.0, FrameworkPropertyMetadataOptions.AffectsMeasure));

        public double ItemFontSize
        {
            get { return (double)GetValue(ItemFontSizeProperty); }
            set { SetValue(ItemFontSizeProperty, value); }
        }
    }

    public class UI4NavigationView : ItemsControl
    {

        private const string PartLeftPanel = "PART_LeftPanel";
        private const string PartMenuButton = "PART_MenuButton";
        private const string PartTitleText = "PART_TitleText";
        private const string PartListBox = "PART_ListBox";
        private const string PartContentPresenter = "PART_ContentPresenter";

        private Grid _leftPanel;
        private UI4Button _menuButton;
        private TextBlock _titleText;
        private UI4ListBox _listBox;
        private ContentPresenter _contentPresenter;
        private double _currentWidth = 200;
        private TranslateTransform _contentTransform;

        public static readonly DependencyProperty LeftPanelBackgroundProperty =
            DependencyProperty.Register("LeftPanelBackground", typeof(Brush), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(null,
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    OnLeftPanelBackgroundChanged));

        public Brush LeftPanelBackground
        {
            get { return (Brush)GetValue(LeftPanelBackgroundProperty); }
            set { SetValue(LeftPanelBackgroundProperty, value); }
        }

        private static void OnLeftPanelBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UI4NavigationView)d;
            ctrl.OnLeftPanelBackgroundChanged((Brush)e.OldValue, (Brush)e.NewValue);
        }

        private void OnLeftPanelBackgroundChanged(Brush oldValue, Brush newValue)
        {
            if (_leftPanel != null)
            {
                _leftPanel.Background = newValue;
            }
        }

        public static readonly DependencyProperty LeftPanelWidthProperty =
            DependencyProperty.Register("LeftPanelWidth", typeof(double), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(200.0,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.AffectsMeasure,
                    OnLeftPanelWidthChanged));

        public double LeftPanelWidth
        {
            get { return (double)GetValue(LeftPanelWidthProperty); }
            set { SetValue(LeftPanelWidthProperty, value); }
        }

        private static void OnLeftPanelWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UI4NavigationView)d;
            ctrl.OnLeftPanelWidthChanged((double)e.OldValue, (double)e.NewValue);
        }

        private void OnLeftPanelWidthChanged(double oldValue, double newValue)
        {
            if (_leftPanel != null && Math.Abs(_currentWidth - 45) > 0.01)
            {
                _leftPanel.Width = newValue;
                _currentWidth = newValue;
            }
        }

        public static readonly DependencyProperty ItemHoverColorProperty =
            DependencyProperty.Register("ItemHoverColor", typeof(Color), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(Colors.White,
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    OnItemHoverColorChanged));

        public Color ItemHoverColor
        {
            get { return (Color)GetValue(ItemHoverColorProperty); }
            set { SetValue(ItemHoverColorProperty, value); }
        }

        private static void OnItemHoverColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UI4NavigationView)d;
            ctrl.OnItemHoverColorChanged((Color)e.OldValue, (Color)e.NewValue);
        }

        private void OnItemHoverColorChanged(Color oldValue, Color newValue)
        {
            if (_listBox != null)
            {
                _listBox.HoverBackground = newValue;
            }
        }

        public static readonly DependencyProperty ItemPressedBackgroundProperty =
            DependencyProperty.Register("ItemPressedBackground", typeof(Color), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(Color.FromArgb(0x0C, 0x00, 0x00, 0x00),
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    OnItemPressedBackgroundChanged));

        public Color ItemPressedBackground
        {
            get { return (Color)GetValue(ItemPressedBackgroundProperty); }
            set { SetValue(ItemPressedBackgroundProperty, value); }
        }

        private static void OnItemPressedBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UI4NavigationView)d;
            ctrl.OnItemPressedBackgroundChanged((Color)e.OldValue, (Color)e.NewValue);
        }

        private void OnItemPressedBackgroundChanged(Color oldValue, Color newValue)
        {
            if (_listBox != null)
            {
                _listBox.PressedBackground = newValue;
            }
        }

        public static readonly DependencyProperty ItemPressedForegroundProperty =
            DependencyProperty.Register("ItemPressedForeground", typeof(Color), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(Colors.Black,
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    OnItemPressedForegroundChanged));

        public Color ItemPressedForeground
        {
            get { return (Color)GetValue(ItemPressedForegroundProperty); }
            set { SetValue(ItemPressedForegroundProperty, value); }
        }

        private static void OnItemPressedForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UI4NavigationView)d;
            ctrl.OnItemPressedForegroundChanged((Color)e.OldValue, (Color)e.NewValue);
        }

        private void OnItemPressedForegroundChanged(Color oldValue, Color newValue)
        {
            if (_listBox != null)
            {
                _listBox.PressedForeground = newValue;
            }
        }

        public static readonly DependencyProperty ItemHoverForegroundProperty =
            DependencyProperty.Register("ItemHoverForeground", typeof(Color), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(Colors.Black,
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    OnItemHoverForegroundChanged));

        public Color ItemHoverForeground
        {
            get { return (Color)GetValue(ItemHoverForegroundProperty); }
            set { SetValue(ItemHoverForegroundProperty, value); }
        }

        private static void OnItemHoverForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UI4NavigationView)d;
            ctrl.OnItemHoverForegroundChanged((Color)e.OldValue, (Color)e.NewValue);
        }

        private void OnItemHoverForegroundChanged(Color oldValue, Color newValue)
        {
            if (_listBox != null)
            {
                _listBox.HoverForeground = newValue;
            }
        }

        public static readonly DependencyProperty ItemForegroundProperty =
            DependencyProperty.Register("ItemForeground", typeof(Brush), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(Brushes.Black,
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    OnItemForegroundChanged));

        public Brush ItemForeground
        {
            get { return (Brush)GetValue(ItemForegroundProperty); }
            set { SetValue(ItemForegroundProperty, value); }
        }

        private static void OnItemForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UI4NavigationView)d;
            ctrl.OnItemForegroundChanged((Brush)e.OldValue, (Brush)e.NewValue);
        }

        private void OnItemForegroundChanged(Brush oldValue, Brush newValue)
        {
            if (_listBox != null)
            {
                _listBox.Foreground = newValue;
            }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemBackgroundProperty =
            DependencyProperty.Register("SelectedItemBackground", typeof(Brush), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Brush SelectedItemBackground
        {
            get { return (Brush)GetValue(SelectedItemBackgroundProperty); }
            set { SetValue(SelectedItemBackgroundProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(UI4NavigationViewItem), typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemChanged));

        public UI4NavigationViewItem SelectedItem
        {
            get { return (UI4NavigationViewItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (UI4NavigationView)d;
            ctrl.UpdateListBoxSelection(e.NewValue as UI4NavigationViewItem);
            ctrl.OnSelectedItemChangedInternal(e.OldValue as UI4NavigationViewItem, e.NewValue as UI4NavigationViewItem);
        }

        private void OnSelectedItemChangedInternal(UI4NavigationViewItem oldItem, UI4NavigationViewItem newItem)
        {
            if (oldItem == newItem) return;
            if (_contentTransform == null || _contentPresenter == null) return;

            int oldIndex = -1, newIndex = -1;
            if (oldItem != null)
                oldIndex = Items.IndexOf(oldItem);
            if (newItem != null)
                newIndex = Items.IndexOf(newItem);

            bool slideFromTop;
            if (oldItem == null)
            {
                slideFromTop = false;
            }
            else
            {
                slideFromTop = (newIndex < oldIndex);
            }

            AnimateContentSlide(slideFromTop);
        }

        static UI4NavigationView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(typeof(UI4NavigationView)));

            var template = new ControlTemplate(typeof(UI4NavigationView));

            var rootGrid = new FrameworkElementFactory(typeof(Grid));
            rootGrid.Name = "RootGrid";

            var bgBinding = new Binding("Background")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
            };
            rootGrid.SetBinding(Grid.BackgroundProperty, bgBinding);

            var colDef1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            colDef1.SetValue(ColumnDefinition.WidthProperty, new GridLength(0, GridUnitType.Auto));
            var colDef2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            colDef2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
            rootGrid.AppendChild(colDef1);
            rootGrid.AppendChild(colDef2);

            var leftPanel = new FrameworkElementFactory(typeof(Grid));
            leftPanel.Name = PartLeftPanel;
            leftPanel.SetValue(Grid.ColumnProperty, 0);
            leftPanel.SetValue(Grid.WidthProperty, 200.0);

            var rowDef1 = new FrameworkElementFactory(typeof(RowDefinition));
            rowDef1.SetValue(RowDefinition.HeightProperty, new GridLength(40));
            var rowDef2 = new FrameworkElementFactory(typeof(RowDefinition));
            rowDef2.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Star));
            leftPanel.AppendChild(rowDef1);
            leftPanel.AppendChild(rowDef2);

            var titleGrid = new FrameworkElementFactory(typeof(Grid));
            titleGrid.SetValue(Grid.RowProperty, 0);

            var colTitle1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            colTitle1.SetValue(ColumnDefinition.WidthProperty, new GridLength(45));
            var colTitle2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            colTitle2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
            titleGrid.AppendChild(colTitle1);
            titleGrid.AppendChild(colTitle2);

            var menuButton = new FrameworkElementFactory(typeof(UI4Button));
            menuButton.Name = PartMenuButton;
            menuButton.SetValue(Grid.ColumnProperty, 0);
            menuButton.SetValue(UI4Button.ContentProperty, "\uE700");
            menuButton.SetValue(UI4Button.FontSizeProperty, 16.0);
            menuButton.SetValue(UI4Button.FontFamilyProperty, new FontFamily("Segoe MDL2 Assets"));
            menuButton.SetValue(UI4Button.WidthProperty, 40.0);
            menuButton.SetValue(UI4Button.ForegroundProperty, Brushes.Black);
            menuButton.SetValue(UI4Button.BackgroundProperty, Brushes.Transparent);
            menuButton.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 3, 0, 3));
            titleGrid.AppendChild(menuButton);

            var titleText = new FrameworkElementFactory(typeof(TextBlock));
            titleText.Name = PartTitleText;
            titleText.SetValue(Grid.ColumnProperty, 1);
            titleText.SetValue(TextBlock.FontSizeProperty, 15.0);
            titleText.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            titleText.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            titleText.SetValue(TextBlock.MarginProperty, new Thickness(5, 0, 0, 0));
            var headerBinding = new Binding("Header") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) };
            titleText.SetBinding(TextBlock.TextProperty, headerBinding);
            titleGrid.AppendChild(titleText);

            leftPanel.AppendChild(titleGrid);

            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Grid.RowProperty, 1);
            border.SetValue(Border.BorderBrushProperty, new SolidColorBrush(Color.FromArgb(0x0C, 0x00, 0x00, 0x00)));
            border.SetValue(Border.BorderThicknessProperty, new Thickness(0, 0, 1, 0));

            var listBox = new FrameworkElementFactory(typeof(UI4ListBox));
            listBox.Name = PartListBox;
            listBox.SetValue(UI4ListBox.BackgroundProperty, Brushes.Transparent);

            var itemsBinding = new Binding("Items") { RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent) };
            listBox.SetBinding(ItemsControl.ItemsSourceProperty, itemsBinding);

            var dataTemplate = new DataTemplate();
            var stackPanel = new FrameworkElementFactory(typeof(StackPanel));
            stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            var iconGrid = new FrameworkElementFactory(typeof(Grid));
            iconGrid.SetValue(Grid.WidthProperty, 30.0);
            iconGrid.SetValue(Grid.HeightProperty, 20.0);
            iconGrid.SetValue(FrameworkElement.MarginProperty, new Thickness(-10, 0, 10, 0));

            var image = new FrameworkElementFactory(typeof(Image));
            image.SetValue(Image.WidthProperty, 30.0);
            image.SetValue(Image.HeightProperty, 20.0);
            image.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            image.SetValue(Image.VerticalAlignmentProperty, VerticalAlignment.Center);
            var imageBinding = new Binding("ImageSource");
            image.SetBinding(Image.SourceProperty, imageBinding);
            var imageVisBinding = new Binding("ImageSource")
            {
                Converter = new NullToVisibilityConverter()
            };
            image.SetBinding(UIElement.VisibilityProperty, imageVisBinding);
            iconGrid.AppendChild(image);

            var textIconBlock = new FrameworkElementFactory(typeof(TextBlock));
            textIconBlock.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            textIconBlock.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            textIconBlock.SetValue(TextBlock.FontSizeProperty, 18.0);

            var textIconBinding = new Binding("TextIcon");
            textIconBlock.SetBinding(TextBlock.TextProperty, textIconBinding);

            var fontFamilyBinding = new Binding("TextIconFontFamily");
            textIconBlock.SetBinding(TextBlock.FontFamilyProperty, fontFamilyBinding);

            var textIconVisBinding = new Binding("ImageSource")
            {
                Converter = new InverseNullToVisibilityConverter()
            };
            textIconBlock.SetBinding(UIElement.VisibilityProperty, textIconVisBinding);
            iconGrid.AppendChild(textIconBlock);

            stackPanel.AppendChild(iconGrid);

            var textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            var fontSizeBinding = new Binding("ItemFontSize")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4NavigationView), 1)
            };
            textBlock.SetBinding(TextBlock.FontSizeProperty, fontSizeBinding);
            var headerTextBinding = new Binding("Header");
            textBlock.SetBinding(TextBlock.TextProperty, headerTextBinding);
            stackPanel.AppendChild(textBlock);

            dataTemplate.VisualTree = stackPanel;
            listBox.SetValue(ItemsControl.ItemTemplateProperty, dataTemplate);

            border.AppendChild(listBox);
            leftPanel.AppendChild(border);
            rootGrid.AppendChild(leftPanel);

            var rightBorder = new FrameworkElementFactory(typeof(Border));
            rightBorder.SetValue(Grid.ColumnProperty, 1);
            rightBorder.SetValue(Border.ClipToBoundsProperty, true);

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.Name = PartContentPresenter;
            var contentBinding = new Binding("SelectedItem.Content")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent)
            };
            contentPresenter.SetBinding(ContentPresenter.ContentProperty, contentBinding);
            rightBorder.AppendChild(contentPresenter);
            rootGrid.AppendChild(rightBorder);

            template.VisualTree = rootGrid;
            template.Seal();

            Control.TemplateProperty.OverrideMetadata(typeof(UI4NavigationView),
                new FrameworkPropertyMetadata(template));
        }

        public UI4NavigationView()
        {
            Background = Brushes.White;
            Foreground = Brushes.Black;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _leftPanel = GetTemplateChild(PartLeftPanel) as Grid;
            _menuButton = GetTemplateChild(PartMenuButton) as UI4Button;
            _titleText = GetTemplateChild(PartTitleText) as TextBlock;
            _listBox = GetTemplateChild(PartListBox) as UI4ListBox;
            _contentPresenter = GetTemplateChild(PartContentPresenter) as ContentPresenter;

            if (_leftPanel == null || _menuButton == null || _listBox == null || _contentPresenter == null)
                throw new InvalidOperationException("Missing template parts.");

            _leftPanel.Background = LeftPanelBackground;

            _listBox.Foreground = ItemForeground;
            _listBox.PressedForeground = ItemPressedForeground;
            _listBox.PressedBackground = ItemPressedBackground;
            _listBox.HoverBackground = ItemHoverColor;
            _listBox.HoverForeground = ItemHoverForeground;

            _menuButton.HoverBackground = new SolidColorBrush(Color.FromArgb(0x0C, 0x00, 0x00, 0x00));

            if (_titleText != null && string.IsNullOrEmpty(_titleText.Text))
                _titleText.Text = Header;

            _contentTransform = new TranslateTransform();
            _contentPresenter.RenderTransform = _contentTransform;

            _menuButton.Click -= MenuButton_Click;
            _menuButton.Click += MenuButton_Click;

            _listBox.SelectionChanged -= ListBox_SelectionChanged;
            _listBox.SelectionChanged += ListBox_SelectionChanged;

            _leftPanel.Width = LeftPanelWidth;
            _currentWidth = LeftPanelWidth;

            Style baseStyle = _listBox.ItemContainerStyle;
            var newStyle = new Style(typeof(ListBoxItem), baseStyle);
            newStyle.Setters.Add(new Setter(FrameworkElement.CursorProperty, Cursors.Hand));
            _listBox.ItemContainerStyle = newStyle;

            if (SelectedItem == null && _listBox.SelectedItem == null && Items.Count > 0)
            {
                SelectedItem = Items[0] as UI4NavigationViewItem;
            }
            else if (SelectedItem != null)
            {
                UpdateListBoxSelection(SelectedItem);
            }
            else if (_listBox.SelectedItem is UI4NavigationViewItem first)
            {
                SelectedItem = first;
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (_leftPanel == null) return;

            bool isCollapsed = Math.Abs(_currentWidth - 45) < 0.01;
            double targetWidth = isCollapsed ? LeftPanelWidth : 45;

            if (Math.Abs(_currentWidth - targetWidth) < 0.01)
                return;

            DoubleAnimation widthAnim = new DoubleAnimation
            {
                To = targetWidth,
                Duration = TimeSpan.FromSeconds(0.1),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };
            _leftPanel.BeginAnimation(Grid.WidthProperty, widthAnim);
            _currentWidth = targetWidth;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_listBox.SelectedItem is UI4NavigationViewItem selected)
            {
                if (SelectedItem != selected)
                    SelectedItem = selected;
            }
            else
            {
                SelectedItem = null;
            }
        }

        private void UpdateListBoxSelection(UI4NavigationViewItem item)
        {
            if (_listBox == null) return;

            if (item != null && _listBox.Items.Contains(item))
                _listBox.SelectedItem = item;
            else
                _listBox.SelectedItem = null;
        }

        private void AnimateContentSlide(bool slideFromTop)
        {
            if (_contentTransform == null) return;

            _contentTransform.BeginAnimation(TranslateTransform.YProperty, null);

            double startY = slideFromTop ? -20 : 20;
            _contentTransform.Y = startY;

            var anim = new DoubleAnimation
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            _contentTransform.BeginAnimation(TranslateTransform.YProperty, anim);
        }
    }
}
