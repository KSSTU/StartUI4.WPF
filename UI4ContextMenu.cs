using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Input;

namespace StartUI4Controls
{
    public enum UI4MenuItemType
    {
        Undo,
        Redo,
        Cut,
        Copy,
        Paste,
        Delete,
        SelectAll
    }

    public class UI4MenuItem
    {
        public UI4MenuItemType Type { get; set; }
        public string Text { get; set; }
        public ImageSource Icon { get; set; }
        public Action Command { get; set; }
        public Func<bool> CanExecute { get; set; }

        public UI4MenuItem(UI4MenuItemType type, string text, ImageSource icon, Action command, Func<bool> canExecute = null)
        {
            Type = type;
            Text = text;
            Icon = icon;
            Command = command;
            CanExecute = canExecute;
        }
    }

    public static class UI4ContextMenuLanguage
    {
        private static Dictionary<UI4MenuItemType, string> _currentStrings;

        public static Dictionary<UI4MenuItemType, string> Current
        {
            get
            {
                if (_currentStrings == null)
                    _currentStrings = GetStrings(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
                return _currentStrings;
            }
        }

        public static void Refresh()
        {
            _currentStrings = null;
        }

        public static Dictionary<UI4MenuItemType, string> GetStrings(string lang)
        {
            switch (lang.ToLower())
            {
                case "zh":
                    return GetChineseStrings();
                case "ja":
                    return GetJapaneseStrings();
                case "ko":
                    return GetKoreanStrings();
                case "de":
                    return GetGermanStrings();
                case "fr":
                    return GetFrenchStrings();
                case "es":
                    return GetSpanishStrings();
                case "ru":
                    return GetRussianStrings();
                default:
                    return GetEnglishStrings();
            }
        }

        private static Dictionary<UI4MenuItemType, string> GetEnglishStrings()
        {
            return new Dictionary<UI4MenuItemType, string>
            {
                { UI4MenuItemType.Undo, "Undo" },
                { UI4MenuItemType.Redo, "Redo" },
                { UI4MenuItemType.Cut, "Cut" },
                { UI4MenuItemType.Copy, "Copy" },
                { UI4MenuItemType.Paste, "Paste" },
                { UI4MenuItemType.Delete, "Delete" },
                { UI4MenuItemType.SelectAll, "Select All" }
            };
        }

        private static Dictionary<UI4MenuItemType, string> GetChineseStrings()
        {
            return new Dictionary<UI4MenuItemType, string>
            {
                { UI4MenuItemType.Undo, "撤销" },
                { UI4MenuItemType.Redo, "重做" },
                { UI4MenuItemType.Cut, "剪切" },
                { UI4MenuItemType.Copy, "复制" },
                { UI4MenuItemType.Paste, "粘贴" },
                { UI4MenuItemType.Delete, "删除" },
                { UI4MenuItemType.SelectAll, "全选" }
            };
        }

        private static Dictionary<UI4MenuItemType, string> GetJapaneseStrings()
        {
            return new Dictionary<UI4MenuItemType, string>
            {
                { UI4MenuItemType.Undo, "元に戻す" },
                { UI4MenuItemType.Redo, "やり直し" },
                { UI4MenuItemType.Cut, "切り取り" },
                { UI4MenuItemType.Copy, "コピー" },
                { UI4MenuItemType.Paste, "貼り付け" },
                { UI4MenuItemType.Delete, "削除" },
                { UI4MenuItemType.SelectAll, "すべて選択" }
            };
        }

        private static Dictionary<UI4MenuItemType, string> GetKoreanStrings()
        {
            return new Dictionary<UI4MenuItemType, string>
            {
                { UI4MenuItemType.Undo, "실행 취소" },
                { UI4MenuItemType.Redo, "다시 실행" },
                { UI4MenuItemType.Cut, "잘라내기" },
                { UI4MenuItemType.Copy, "복사" },
                { UI4MenuItemType.Paste, "붙여넣기" },
                { UI4MenuItemType.Delete, "삭제" },
                { UI4MenuItemType.SelectAll, "모두 선택" }
            };
        }

        private static Dictionary<UI4MenuItemType, string> GetGermanStrings()
        {
            return new Dictionary<UI4MenuItemType, string>
            {
                { UI4MenuItemType.Undo, "Rückgängig" },
                { UI4MenuItemType.Redo, "Wiederholen" },
                { UI4MenuItemType.Cut, "Ausschneiden" },
                { UI4MenuItemType.Copy, "Kopieren" },
                { UI4MenuItemType.Paste, "Einfügen" },
                { UI4MenuItemType.Delete, "Löschen" },
                { UI4MenuItemType.SelectAll, "Alles auswählen" }
            };
        }

        private static Dictionary<UI4MenuItemType, string> GetFrenchStrings()
        {
            return new Dictionary<UI4MenuItemType, string>
            {
                { UI4MenuItemType.Undo, "Annuler" },
                { UI4MenuItemType.Redo, "Rétablir" },
                { UI4MenuItemType.Cut, "Couper" },
                { UI4MenuItemType.Copy, "Copier" },
                { UI4MenuItemType.Paste, "Coller" },
                { UI4MenuItemType.Delete, "Supprimer" },
                { UI4MenuItemType.SelectAll, "Tout sélectionner" }
            };
        }

        private static Dictionary<UI4MenuItemType, string> GetSpanishStrings()
        {
            return new Dictionary<UI4MenuItemType, string>
            {
                { UI4MenuItemType.Undo, "Deshacer" },
                { UI4MenuItemType.Redo, "Rehacer" },
                { UI4MenuItemType.Cut, "Cortar" },
                { UI4MenuItemType.Copy, "Copiar" },
                { UI4MenuItemType.Paste, "Pegar" },
                { UI4MenuItemType.Delete, "Eliminar" },
                { UI4MenuItemType.SelectAll, "Seleccionar todo" }
            };
        }

        private static Dictionary<UI4MenuItemType, string> GetRussianStrings()
        {
            return new Dictionary<UI4MenuItemType, string>
            {
                { UI4MenuItemType.Undo, "Отменить" },
                { UI4MenuItemType.Redo, "Повторить" },
                { UI4MenuItemType.Cut, "Вырезать" },
                { UI4MenuItemType.Copy, "Копировать" },
                { UI4MenuItemType.Paste, "Вставить" },
                { UI4MenuItemType.Delete, "Удалить" },
                { UI4MenuItemType.SelectAll, "Выделить все" }
            };
        }
    }

    public static class UI4MenuIcons
    {
        private static ImageSource _undoIcon;
        private static ImageSource _redoIcon;
        private static ImageSource _cutIcon;
        private static ImageSource _copyIcon;
        private static ImageSource _pasteIcon;
        private static ImageSource _deleteIcon;
        private static ImageSource _selectAllIcon;

        public static ImageSource Undo => _undoIcon ?? (_undoIcon = CreateUndoIcon());
        public static ImageSource Redo => _redoIcon ?? (_redoIcon = CreateRedoIcon());
        public static ImageSource Cut => _cutIcon ?? (_cutIcon = CreateCutIcon());
        public static ImageSource Copy => _copyIcon ?? (_copyIcon = CreateCopyIcon());
        public static ImageSource Paste => _pasteIcon ?? (_pasteIcon = CreatePasteIcon());
        public static ImageSource Delete => _deleteIcon ?? (_deleteIcon = CreateDeleteIcon());
        public static ImageSource SelectAll => _selectAllIcon ?? (_selectAllIcon = CreateSelectAllIcon());

        public static ImageSource GetIcon(UI4MenuItemType type)
        {
            switch (type)
            {
                case UI4MenuItemType.Undo: return Undo;
                case UI4MenuItemType.Redo: return Redo;
                case UI4MenuItemType.Cut: return Cut;
                case UI4MenuItemType.Copy: return Copy;
                case UI4MenuItemType.Paste: return Paste;
                case UI4MenuItemType.Delete: return Delete;
                case UI4MenuItemType.SelectAll: return SelectAll;
                default: return null;
            }
        }

        private static ImageSource CreateIconFromGeometry(Geometry geometry, Brush brush)
        {
            var drawing = new GeometryDrawing(brush, null, geometry);
            var drawingGroup = new DrawingGroup();
            drawingGroup.Children.Add(drawing);
            var image = new DrawingImage(drawingGroup);
            image.Freeze();
            return image;
        }

        private static ImageSource CreateUndoIcon()
        {
            StreamGeometry geo = new StreamGeometry();
            using (var ctx = geo.Open())
            {
                ctx.BeginFigure(new Point(4, 10), true, true);
                ctx.LineTo(new Point(9, 10), true, false);
                ctx.ArcTo(new Point(14, 15), new Size(5, 5), 0, false, SweepDirection.Clockwise, true, false);
                ctx.LineTo(new Point(16, 15), true, false);
                ctx.LineTo(new Point(13, 18), true, false);
                ctx.LineTo(new Point(10, 15), true, false);
                ctx.LineTo(new Point(11, 15), true, false);
                ctx.ArcTo(new Point(7, 11), new Size(4, 4), 0, false, SweepDirection.Counterclockwise, true, false);
                ctx.LineTo(new Point(7, 10), true, false);
            }
            geo.Freeze();
            return CreateIconFromGeometry(geo, Brushes.Black);
        }

        private static ImageSource CreateRedoIcon()
        {
            StreamGeometry geo = new StreamGeometry();
            using (var ctx = geo.Open())
            {
                ctx.BeginFigure(new Point(16, 10), true, true);
                ctx.LineTo(new Point(11, 10), true, false);
                ctx.ArcTo(new Point(6, 15), new Size(5, 5), 0, false, SweepDirection.Counterclockwise, true, false);
                ctx.LineTo(new Point(4, 15), true, false);
                ctx.LineTo(new Point(7, 18), true, false);
                ctx.LineTo(new Point(10, 15), true, false);
                ctx.LineTo(new Point(9, 15), true, false);
                ctx.ArcTo(new Point(13, 11), new Size(4, 4), 0, false, SweepDirection.Clockwise, true, false);
                ctx.LineTo(new Point(13, 10), true, false);
            }
            geo.Freeze();
            return CreateIconFromGeometry(geo, Brushes.Black);
        }

        private static ImageSource CreateCutIcon()
        {
            StreamGeometry geo = new StreamGeometry();
            using (var ctx = geo.Open())
            {
                ctx.BeginFigure(new Point(3, 3), false, false);
                ctx.LineTo(new Point(15, 15), true, false);
                ctx.BeginFigure(new Point(15, 3), false, false);
                ctx.LineTo(new Point(3, 15), true, false);
                ctx.BeginFigure(new Point(5, 2), true, true);
                ctx.ArcTo(new Point(7, 4), new Size(2, 2), 0, false, SweepDirection.Clockwise, true, false);
                ctx.ArcTo(new Point(5, 6), new Size(2, 2), 0, false, SweepDirection.Clockwise, true, false);
                ctx.ArcTo(new Point(3, 4), new Size(2, 2), 0, false, SweepDirection.Clockwise, true, false);
                ctx.ArcTo(new Point(5, 2), new Size(2, 2), 0, false, SweepDirection.Clockwise, true, false);
                ctx.BeginFigure(new Point(15, 2), true, true);
                ctx.ArcTo(new Point(17, 4), new Size(2, 2), 0, false, SweepDirection.Clockwise, true, false);
                ctx.ArcTo(new Point(15, 6), new Size(2, 2), 0, false, SweepDirection.Clockwise, true, false);
                ctx.ArcTo(new Point(13, 4), new Size(2, 2), 0, false, SweepDirection.Clockwise, true, false);
                ctx.ArcTo(new Point(15, 2), new Size(2, 2), 0, false, SweepDirection.Clockwise, true, false);
            }
            geo.Freeze();
            return CreateIconFromGeometry(geo, Brushes.Black);
        }

        private static ImageSource CreateCopyIcon()
        {
            GeometryGroup group = new GeometryGroup();
            group.Children.Add(new RectangleGeometry(new Rect(6, 2, 10, 12), 1, 1));
            group.Children.Add(new RectangleGeometry(new Rect(2, 6, 10, 12), 1, 1));
            group.Freeze();
            return CreateIconFromGeometry(group, Brushes.Black);
        }

        private static ImageSource CreatePasteIcon()
        {
            GeometryGroup group = new GeometryGroup();
            group.Children.Add(new RectangleGeometry(new Rect(7, 1, 6, 3), 1, 1));
            group.Children.Add(new RectangleGeometry(new Rect(4, 4, 12, 14), 1, 1));
            group.Freeze();
            return CreateIconFromGeometry(group, Brushes.Black);
        }

        private static ImageSource CreateDeleteIcon()
        {
            GeometryGroup group = new GeometryGroup();
            group.Children.Add(new RectangleGeometry(new Rect(3, 4, 14, 2), 0.5, 0.5));
            group.Children.Add(new RectangleGeometry(new Rect(5, 6, 10, 12), 0, 0));
            group.Children.Add(new LineGeometry(new Point(8, 9), new Point(8, 15)));
            group.Children.Add(new LineGeometry(new Point(12, 9), new Point(12, 15)));
            group.Freeze();
            return CreateIconFromGeometry(group, Brushes.Black);
        }

        private static ImageSource CreateSelectAllIcon()
        {
            GeometryGroup group = new GeometryGroup();
            group.Children.Add(new RectangleGeometry(new Rect(2, 2, 7, 7), 1, 1));
            group.Children.Add(new RectangleGeometry(new Rect(11, 2, 7, 7), 1, 1));
            group.Children.Add(new RectangleGeometry(new Rect(2, 11, 7, 7), 1, 1));
            group.Children.Add(new RectangleGeometry(new Rect(11, 11, 7, 7), 1, 1));
            group.Freeze();
            return CreateIconFromGeometry(group, Brushes.Black);
        }
    }

    public class UI4ContextMenu
    {
        private Popup _popup;
        private UI4ListBox _listBox;
        private List<UI4MenuItem> _menuItems;
        private UIElement _placementTarget;

        public double Width { get; set; } = 160;
        public Thickness ItemPadding { get; set; } = new Thickness(12, 8, 12, 8);
        public Color BorderColor { get; set; } = Color.FromArgb(255, 200, 200, 220);
        public Brush Background { get; set; } = Brushes.White;
        public Color HoverBackground { get; set; } = Color.FromArgb(180, 245, 245, 245);

        public bool IsOpen => _popup?.IsOpen ?? false;

        public UI4ContextMenu()
        {
            _menuItems = new List<UI4MenuItem>();
        }

        public void AddItem(UI4MenuItem item)
        {
            _menuItems.Add(item);
        }

        public void AddItem(UI4MenuItemType type, Action command, Func<bool> canExecute = null)
        {
            var strings = UI4ContextMenuLanguage.Current;
            if (strings.ContainsKey(type))
            {
                var item = new UI4MenuItem(
                    type,
                    strings[type],
                    UI4MenuIcons.GetIcon(type),
                    command,
                    canExecute);
                _menuItems.Add(item);
            }
        }

        public void Attach(UIElement target)
        {
            _placementTarget = target;
            BuildMenu();
            target.MouseRightButtonUp += OnTargetRightButtonUp;
        }

        public void Detach()
        {
            if (_placementTarget != null)
            {
                _placementTarget.MouseRightButtonUp -= OnTargetRightButtonUp;
                _placementTarget = null;
            }
            Close();
        }

        private void BuildMenu()
        {
            _listBox = new UI4ListBox
            {
                Width = this.Width,
                ItemPadding = this.ItemPadding,
                BorderNormalColor = this.BorderColor,
                Background = this.Background,
                HoverBackground = this.HoverBackground,
            };

            foreach (var item in _menuItems)
            {
                var container = new Grid();
                container.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
                container.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                if (item.Icon != null)
                {
                    var icon = new System.Windows.Controls.Image
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

            _listBox.SelectionChanged += OnSelectionChanged;

            _popup = new Popup
            {
                Child = _listBox,
                Placement = PlacementMode.MousePoint,
                StaysOpen = false,
                AllowsTransparency = true,
                PopupAnimation = PopupAnimation.Slide
            };
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_listBox.SelectedItem is FrameworkElement element && element.Tag is UI4MenuItem item)
            {
                if (item.CanExecute?.Invoke() ?? true)
                {
                    item.Command?.Invoke();
                }
                Close();
            }
        }

        private void OnTargetRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Open();
        }

        public void Open()
        {
            if (_popup == null || _listBox == null || _placementTarget == null) return;

            Close();

            UpdateCanExecuteStates();

            _listBox.BeginAnimation(UIElement.OpacityProperty, null);
            _listBox.Opacity = 0;

            _popup.PlacementTarget = _placementTarget;
            _popup.IsOpen = true;

            var anim = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(150));
            _listBox.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        public void Close()
        {
            if (_popup != null)
                _popup.IsOpen = false;
            if (_listBox != null)
                _listBox.SelectedIndex = -1;
        }

        private void UpdateCanExecuteStates()
        {
            if (_listBox == null) return;

            for (int i = 0; i < _listBox.Items.Count && i < _menuItems.Count; i++)
            {
                if (_listBox.Items[i] is FrameworkElement element && element.Tag is UI4MenuItem item)
                {
                    bool canExec = item.CanExecute?.Invoke() ?? true;
                    foreach (var child in (element as Grid).Children)
                    {
                        if (child is UIElement uiElement)
                        {
                            uiElement.Opacity = canExec ? 1.0 : 0.4;
                        }
                    }
                }
            }
        }
    }
}
