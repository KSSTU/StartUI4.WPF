using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StartUI4Controls
{
    public class UI4TabItem : HeaderedContentControl
    {
        public static readonly DependencyProperty TextIconProperty =
            DependencyProperty.Register(
                nameof(TextIcon),
                typeof(string),
                typeof(UI4TabItem),
                new PropertyMetadata(null));

        public string TextIcon
        {
            get => (string)GetValue(TextIconProperty);
            set => SetValue(TextIconProperty, value);
        }

        public static readonly DependencyProperty TextIconFontFamilyProperty =
            DependencyProperty.Register(
                nameof(TextIconFontFamily),
                typeof(FontFamily),
                typeof(UI4TabItem),
                new PropertyMetadata(new FontFamily("Segoe MDL2 Assets")));

        public FontFamily TextIconFontFamily
        {
            get => (FontFamily)GetValue(TextIconFontFamilyProperty);
            set => SetValue(TextIconFontFamilyProperty, value);
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(
                nameof(ImageSource),
                typeof(ImageSource),
                typeof(UI4TabItem),
                new PropertyMetadata(null));

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register(
                nameof(IconSize),
                typeof(double),
                typeof(UI4TabItem),
                new PropertyMetadata(16.0));

        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public static readonly DependencyProperty IsClosableProperty =
            DependencyProperty.Register(
                nameof(IsClosable),
                typeof(bool),
                typeof(UI4TabItem),
                new PropertyMetadata(true));

        public bool IsClosable
        {
            get => (bool)GetValue(IsClosableProperty);
            set => SetValue(IsClosableProperty, value);
        }

        public static readonly DependencyProperty IsBrandProperty =
            DependencyProperty.Register(nameof(IsBrand), typeof(bool), typeof(UI4TabItem),
                new PropertyMetadata(false));

        public bool IsBrand
        {
            get => (bool)GetValue(IsBrandProperty);
            set => SetValue(IsBrandProperty, value);
        }

        public static readonly RoutedEvent CloseTabEvent =
            EventManager.RegisterRoutedEvent(
                nameof(CloseTab),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(UI4TabItem));

        public event RoutedEventHandler CloseTab
        {
            add { AddHandler(CloseTabEvent, value); }
            remove { RemoveHandler(CloseTabEvent, value); }
        }

        internal void RaiseCloseTab()
        {
            RaiseEvent(new RoutedEventArgs(CloseTabEvent));
        }

        static UI4TabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4TabItem),
                new FrameworkPropertyMetadata(typeof(UI4TabItem)));
        }

        public UI4TabItem()
        {
            Background = Brushes.Transparent;
            BorderThickness = new Thickness(0);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            var parentTab = ItemsControl.ItemsControlFromItemContainer(this) as UI4Tab;
            if (parentTab != null)
            {
                int idx = parentTab.ItemContainerGenerator.IndexFromContainer(this);
                if (idx >= 0)
                    parentTab.SelectedIndex = idx;
            }
            e.Handled = true;
        }
    }

    public class UI4Tab : Selector
    {
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register(
                nameof(HeaderBackground),
                typeof(Color),
                typeof(UI4Tab),
                new PropertyMetadata(Color.FromArgb(10,0, 0, 0), OnStyleChanged));

        public Color HeaderBackground
        {
            get => (Color)GetValue(HeaderBackgroundProperty);
            set => SetValue(HeaderBackgroundProperty, value);
        }

        public static readonly DependencyProperty TabBackgroundProperty =
            DependencyProperty.Register(
                nameof(TabBackground),
                typeof(Color),
                typeof(UI4Tab),
                new PropertyMetadata(Colors.Transparent, OnStyleChanged));

        public Color TabBackground
        {
            get => (Color)GetValue(TabBackgroundProperty);
            set => SetValue(TabBackgroundProperty, value);
        }

        public static readonly DependencyProperty TabSelectedBackgroundProperty =
            DependencyProperty.Register(
                nameof(TabSelectedBackground),
                typeof(Color),
                typeof(UI4Tab),
                new PropertyMetadata(Colors.White, OnStyleChanged));

        public Color TabSelectedBackground
        {
            get => (Color)GetValue(TabSelectedBackgroundProperty);
            set => SetValue(TabSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty TabHoverBackgroundProperty =
            DependencyProperty.Register(
                nameof(TabHoverBackground),
                typeof(Color),
                typeof(UI4Tab),
                new PropertyMetadata(Color.FromArgb(30, 0, 0, 0), OnStyleChanged));

        public Color TabHoverBackground
        {
            get => (Color)GetValue(TabHoverBackgroundProperty);
            set => SetValue(TabHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty TabForegroundProperty =
            DependencyProperty.Register(
                nameof(TabForeground),
                typeof(Color),
                typeof(UI4Tab),
                new PropertyMetadata(Color.FromArgb(200, 0, 0, 0), OnStyleChanged));

        public Color TabForeground
        {
            get => (Color)GetValue(TabForegroundProperty);
            set => SetValue(TabForegroundProperty, value);
        }

        public static readonly DependencyProperty TabSelectedForegroundProperty =
            DependencyProperty.Register(
                nameof(TabSelectedForeground),
                typeof(Color),
                typeof(UI4Tab),
                new PropertyMetadata(Color.FromArgb(255, 0, 0, 0), OnStyleChanged));

        public Color TabSelectedForeground
        {
            get => (Color)GetValue(TabSelectedForegroundProperty);
            set => SetValue(TabSelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty CloseButtonColorProperty =
            DependencyProperty.Register(
                nameof(CloseButtonColor),
                typeof(Color),
                typeof(UI4Tab),
                new PropertyMetadata(Color.FromArgb(150, 0, 0, 0), OnStyleChanged));

        public Color CloseButtonColor
        {
            get => (Color)GetValue(CloseButtonColorProperty);
            set => SetValue(CloseButtonColorProperty, value);
        }

        public static readonly DependencyProperty TabFontSizeProperty =
            DependencyProperty.Register(
                nameof(TabFontSize),
                typeof(double),
                typeof(UI4Tab),
                new PropertyMetadata(13.0, OnStyleChanged));

        public double TabFontSize
        {
            get => (double)GetValue(TabFontSizeProperty);
            set => SetValue(TabFontSizeProperty, value);
        }

        public static readonly DependencyProperty TabPaddingProperty =
            DependencyProperty.Register(
                nameof(TabPadding),
                typeof(Thickness),
                typeof(UI4Tab),
                new PropertyMetadata(new Thickness(12, 8, 8, 8), OnStyleChanged));

        public Thickness TabPadding
        {
            get => (Thickness)GetValue(TabPaddingProperty);
            set => SetValue(TabPaddingProperty, value);
        }

        public static readonly DependencyProperty ShowAddButtonProperty =
            DependencyProperty.Register(
                nameof(ShowAddButton),
                typeof(bool),
                typeof(UI4Tab),
                new PropertyMetadata(true, OnStyleChanged));

        public bool ShowAddButton
        {
            get => (bool)GetValue(ShowAddButtonProperty);
            set => SetValue(ShowAddButtonProperty, value);
        }

        public static readonly DependencyProperty AddButtonColorProperty =
            DependencyProperty.Register(
                nameof(AddButtonColor),
                typeof(Color),
                typeof(UI4Tab),
                new PropertyMetadata(Color.FromArgb(150, 0, 0, 0), OnStyleChanged));

        public Color AddButtonColor
        {
            get => (Color)GetValue(AddButtonColorProperty);
            set => SetValue(AddButtonColorProperty, value);
        }

        public static readonly RoutedEvent AddTabEvent =
            EventManager.RegisterRoutedEvent(
                nameof(AddTab),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(UI4Tab));

        public event RoutedEventHandler AddTab
        {
            add { AddHandler(AddTabEvent, value); }
            remove { RemoveHandler(AddTabEvent, value); }
        }

        public delegate void TabCloseRoutedEventHandler(object sender, TabCloseRoutedEventArgs e);

        public static readonly RoutedEvent CloseTabEvent =
            EventManager.RegisterRoutedEvent(
                nameof(CloseTab),
                RoutingStrategy.Bubble,
                typeof(TabCloseRoutedEventHandler),
                typeof(UI4Tab));

        public event TabCloseRoutedEventHandler CloseTab
        {
            add { AddHandler(CloseTabEvent, value); }
            remove { RemoveHandler(CloseTabEvent, value); }
        }

        private ContentPresenter _contentPresenter;
        private Border _contentBorder;
        private int _previousIndex = 0;
        private Button _addButton;

        private static void OnStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Tab Tab)
                Tab.RebuildStyle();
        }

        static UI4Tab()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4Tab),
                new FrameworkPropertyMetadata(typeof(UI4Tab)));
        }

        public UI4Tab()
        {
            Background = Brushes.Transparent;
            BorderThickness = new Thickness(0);
            Loaded += OnLoaded;
            SelectionChanged += (s, e) => ApplySelection();
            RebuildStyle();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Items.Count > 0)
            {
                if (SelectedIndex < 0)
                    SelectedIndex = 0;
                var firstItem = Items[SelectedIndex] as UI4TabItem;
                if (_contentPresenter != null)
                    _contentPresenter.Content = firstItem?.Content;
            }
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
            => item is UI4TabItem;

        protected override DependencyObject GetContainerForItemOverride()
            => new UI4TabItem();

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _contentPresenter = GetTemplateChild("PART_ContentPresenter") as ContentPresenter;
            _contentBorder = GetTemplateChild("PART_ContentBorder") as Border;
            _addButton = GetTemplateChild("PART_AddButton") as Button;
            if (_addButton != null)
            {
                _addButton.Click += OnAddButtonClick;
            }
            ApplySelection();
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AddTabEvent));
        }

        private void RebuildStyle()
        {
            Style = BuildTabStyle();
        }

        private Style BuildTabStyle()
        {
            var style = new Style(typeof(Selector));
            style.Setters.Add(new Setter(BackgroundProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));

            var template = new ControlTemplate(typeof(Selector));

            var root = new FrameworkElementFactory(typeof(DockPanel));

            var headerPanel = new FrameworkElementFactory(typeof(DockPanel));
            headerPanel.SetValue(DockPanel.DockProperty, Dock.Top);
            headerPanel.SetValue(Panel.BackgroundProperty, new SolidColorBrush(HeaderBackground));

            var headerScrollViewer = new FrameworkElementFactory(typeof(UI4ScrollViewer));
            headerScrollViewer.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            headerScrollViewer.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            headerScrollViewer.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 0, 0, 0));

            var itemsPresenter = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemsPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            itemsPresenter.SetValue(FrameworkElement.MarginProperty, new Thickness(6, 0, 0, 0));

            headerScrollViewer.AppendChild(itemsPresenter);

            var addButton = BuildAddButton();
            addButton.SetValue(DockPanel.DockProperty, Dock.Right);
            addButton.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            addButton.SetValue(FrameworkElement.MarginProperty, new Thickness(8, 0, 8, 0));

            headerPanel.AppendChild(addButton);
            headerPanel.AppendChild(headerScrollViewer);

            var contentBorder = new FrameworkElementFactory(typeof(Border));
            contentBorder.Name = "PART_ContentBorder";
            contentBorder.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
            contentBorder.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Stretch);
            contentBorder.SetValue(UIElement.ClipToBoundsProperty, true);

            var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.Name = "PART_ContentPresenter";
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Stretch);

            contentBorder.AppendChild(contentPresenter);
            root.AppendChild(headerPanel);
            root.AppendChild(contentBorder);
            template.VisualTree = root;

            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            var stackPanel = new FrameworkElementFactory(typeof(StackPanel));
            stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            var itemsPanelTemplate = new ItemsPanelTemplate();
            itemsPanelTemplate.VisualTree = stackPanel;
            style.Setters.Add(new Setter(ItemsPanelProperty, itemsPanelTemplate));

            var itemStyle = new Style(typeof(UI4TabItem));
            itemStyle.Setters.Add(new Setter(UI4TabItem.CursorProperty, Cursors.Hand));
            itemStyle.Setters.Add(new Setter(UI4TabItem.BackgroundProperty, new SolidColorBrush(TabBackground)));
            itemStyle.Setters.Add(new Setter(UI4TabItem.BorderThicknessProperty, new Thickness(0)));
            itemStyle.Setters.Add(new Setter(UI4TabItem.ForegroundProperty, new SolidColorBrush(TabForeground)));
            itemStyle.Setters.Add(new Setter(UI4TabItem.FontSizeProperty,
                new Binding(nameof(TabFontSize)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Tab), 1) }));
            itemStyle.Setters.Add(new Setter(UI4TabItem.PaddingProperty,
                new Binding(nameof(TabPadding)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Tab), 1) }));
            itemStyle.Setters.Add(new Setter(FrameworkElement.MarginProperty, new Thickness(0, 4, 2, 4)));

            var itemTemplate = new ControlTemplate(typeof(UI4TabItem));

            var itemBorder = new FrameworkElementFactory(typeof(Border));
            itemBorder.Name = "itemBorder";
            itemBorder.SetBinding(Border.BackgroundProperty, new Binding(nameof(Background)) { RelativeSource = RelativeSource.TemplatedParent });
            itemBorder.SetBinding(Border.BorderBrushProperty, new Binding(nameof(BorderBrush)) { RelativeSource = RelativeSource.TemplatedParent });
            itemBorder.SetBinding(Border.BorderThicknessProperty, new Binding(nameof(BorderThickness)) { RelativeSource = RelativeSource.TemplatedParent });
            itemBorder.SetBinding(Border.PaddingProperty, new Binding(nameof(Padding)) { RelativeSource = RelativeSource.TemplatedParent });
            itemBorder.SetValue(Border.CornerRadiusProperty, new CornerRadius(6));
            itemBorder.SetValue(Border.ClipToBoundsProperty, true);

            var itemGrid = new FrameworkElementFactory(typeof(Grid));
            itemGrid.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

            var col0 = new FrameworkElementFactory(typeof(ColumnDefinition));
            col0.SetValue(ColumnDefinition.WidthProperty, GridLength.Auto);
            var col1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            col1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
            var col2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            col2.SetValue(ColumnDefinition.WidthProperty, GridLength.Auto);

            var row0 = new FrameworkElementFactory(typeof(RowDefinition));
            row0.SetValue(RowDefinition.HeightProperty, GridLength.Auto);

            itemGrid.AppendChild(col0);
            itemGrid.AppendChild(col1);
            itemGrid.AppendChild(col2);
            itemGrid.AppendChild(row0);

            var iconContainer = new FrameworkElementFactory(typeof(Grid));
            iconContainer.Name = "iconContainer";
            iconContainer.SetValue(Grid.ColumnProperty, 0);
            iconContainer.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 0, 8, 0));
            iconContainer.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            iconContainer.SetValue(FrameworkElement.WidthProperty, new Binding(nameof(UI4TabItem.IconSize)) { RelativeSource = RelativeSource.TemplatedParent });
            iconContainer.SetValue(FrameworkElement.HeightProperty, new Binding(nameof(UI4TabItem.IconSize)) { RelativeSource = RelativeSource.TemplatedParent });

            var iconImage = new FrameworkElementFactory(typeof(System.Windows.Controls.Image));
            iconImage.Name = "iconImage";
            iconImage.SetBinding(System.Windows.Controls.Image.SourceProperty,
                new Binding(nameof(UI4TabItem.ImageSource)) { RelativeSource = RelativeSource.TemplatedParent });
            iconImage.SetBinding(FrameworkElement.WidthProperty,
                new Binding(nameof(UI4TabItem.IconSize)) { RelativeSource = RelativeSource.TemplatedParent });
            iconImage.SetBinding(FrameworkElement.HeightProperty,
                new Binding(nameof(UI4TabItem.IconSize)) { RelativeSource = RelativeSource.TemplatedParent });
            iconImage.SetBinding(UIElement.VisibilityProperty,
                new Binding(nameof(UI4TabItem.ImageSource)) { RelativeSource = RelativeSource.TemplatedParent, Converter = new TabImageVisibilityConverter() });

            var iconText = new FrameworkElementFactory(typeof(TextBlock));
            iconText.Name = "iconText";
            iconText.SetBinding(TextBlock.TextProperty,
                new Binding(nameof(UI4TabItem.TextIcon)) { RelativeSource = RelativeSource.TemplatedParent });
            iconText.SetBinding(TextBlock.FontFamilyProperty,
                new Binding(nameof(UI4TabItem.TextIconFontFamily)) { RelativeSource = RelativeSource.TemplatedParent });
            iconText.SetBinding(TextBlock.FontSizeProperty,
                new Binding(nameof(UI4TabItem.IconSize)) { RelativeSource = RelativeSource.TemplatedParent });
            iconText.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            iconText.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            iconText.SetBinding(UIElement.VisibilityProperty,
                new Binding(nameof(UI4TabItem.ImageSource)) { RelativeSource = RelativeSource.TemplatedParent, Converter = new TabTextIconVisibilityConverter() });

            iconContainer.AppendChild(iconImage);
            iconContainer.AppendChild(iconText);

            var headerPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            headerPresenter.Name = "HeaderPresenter";
            headerPresenter.SetValue(Grid.ColumnProperty, 1);
            headerPresenter.SetValue(ContentPresenter.ContentSourceProperty, "Header");
            headerPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            headerPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            headerPresenter.SetValue(TextBlock.TextTrimmingProperty, TextTrimming.CharacterEllipsis);

            var closeButton = new FrameworkElementFactory(typeof(Button));
            closeButton.Name = "closeButton";
            closeButton.SetValue(Grid.ColumnProperty, 2);
            closeButton.SetValue(FrameworkElement.MarginProperty, new Thickness(12, 0, 0, 0));
            closeButton.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            closeButton.SetValue(Control.BackgroundProperty, Brushes.Transparent);
            closeButton.SetValue(Control.BorderThicknessProperty, new Thickness(0));
            closeButton.SetValue(Control.PaddingProperty, new Thickness(2));
            closeButton.SetValue(Control.CursorProperty, Cursors.Hand);
            closeButton.SetBinding(UIElement.VisibilityProperty,
                new Binding(nameof(UI4TabItem.IsClosable)) { RelativeSource = RelativeSource.TemplatedParent, Converter = new TabBoolToVisibilityConverter() });

            var closeContent = new FrameworkElementFactory(typeof(TextBlock));
            closeContent.SetValue(TextBlock.TextProperty, "\uE711");
            closeContent.SetValue(TextBlock.FontFamilyProperty, new FontFamily("Segoe MDL2 Assets"));
            closeContent.SetValue(TextBlock.FontSizeProperty, 10.0);
            closeContent.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            closeContent.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            closeContent.SetBinding(TextBlock.ForegroundProperty,
                new Binding(nameof(CloseButtonColor)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Tab), 1), Converter = new TabColorToBrushConverter() });
            closeButton.AppendChild(closeContent);

            closeButton.AddHandler(Button.ClickEvent, new RoutedEventHandler(OnCloseButtonClick));

            itemGrid.AppendChild(iconContainer);
            itemGrid.AppendChild(headerPresenter);
            itemGrid.AppendChild(closeButton);

            itemBorder.AppendChild(itemGrid);
            itemTemplate.VisualTree = itemBorder;

            var hoverTrigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            hoverTrigger.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(TabHoverBackground)) { TargetName = "itemBorder" });
            itemTemplate.Triggers.Add(hoverTrigger);

            var selectedTrigger = new Trigger
            {
                Property = Selector.IsSelectedProperty,
                Value = true
            };
            selectedTrigger.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(TabSelectedBackground)) { TargetName = "itemBorder" });
            selectedTrigger.Setters.Add(new Setter(TextElement.ForegroundProperty, new SolidColorBrush(TabSelectedForeground)) { TargetName = "HeaderPresenter" });
            selectedTrigger.Setters.Add(new Setter(TextElement.FontWeightProperty, FontWeights.SemiBold) { TargetName = "HeaderPresenter" });
            itemTemplate.Triggers.Add(selectedTrigger);

            itemStyle.Setters.Add(new Setter(Control.TemplateProperty, itemTemplate));
            style.Setters.Add(new Setter(ItemContainerStyleProperty, itemStyle));

            return style;
        }

        private FrameworkElementFactory BuildAddButton()
        {
            var button = new FrameworkElementFactory(typeof(Button));
            button.Name = "PART_AddButton";
            button.SetValue(Control.BackgroundProperty, Brushes.Transparent);
            button.SetValue(Control.BorderThicknessProperty, new Thickness(0));
            button.SetValue(Control.PaddingProperty, new Thickness(4));
            button.SetValue(Control.CursorProperty, Cursors.Hand);
            button.SetValue(FrameworkElement.WidthProperty, 24.0);
            button.SetValue(FrameworkElement.HeightProperty, 24.0);
            button.SetBinding(UIElement.VisibilityProperty,
                new Binding(nameof(ShowAddButton)) { RelativeSource = RelativeSource.TemplatedParent, Converter = new TabBoolToVisibilityConverter() });

            var icon = new FrameworkElementFactory(typeof(TextBlock));
            icon.SetValue(TextBlock.TextProperty, "\uE710");
            icon.SetValue(TextBlock.FontFamilyProperty, new FontFamily("Segoe MDL2 Assets"));
            icon.SetValue(TextBlock.FontSizeProperty, 12.0);
            icon.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            icon.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            icon.SetBinding(TextBlock.ForegroundProperty,
                new Binding(nameof(AddButtonColor)) { RelativeSource = RelativeSource.TemplatedParent, Converter = new TabColorToBrushConverter() });

            button.AppendChild(icon);
            return button;
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var tabItem = FindParent<UI4TabItem>(button);
            if (tabItem != null)
            {
                var args = new TabCloseRoutedEventArgs(CloseTabEvent, tabItem);
                RaiseEvent(args);
                if (!args.Handled)
                {
                    int idx = ItemContainerGenerator.IndexFromContainer(tabItem);
                    if (idx >= 0 && idx < Items.Count)
                    {
                        Items.RemoveAt(idx);
                    }
                }
            }
            e.Handled = true;
        }

        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (parent is T typedParent)
                    return typedParent;
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        private void ApplySelection()
        {
            if (_contentPresenter == null) return;

            int newIndex = SelectedIndex;
            if (newIndex < 0 || newIndex >= Items.Count) return;
            if (newIndex == _previousIndex) return;

            if (_contentPresenter.Content == null)
            {
                var firstItem = Items[newIndex] as UI4TabItem;
                _contentPresenter.Content = firstItem?.Content;
                _previousIndex = newIndex;
                return;
            }

            bool slideRight = newIndex > _previousIndex;
            _previousIndex = newIndex;

            if (_contentBorder == null)
            {
                var item = Items[newIndex] as UI4TabItem;
                _contentPresenter.Content = item?.Content;
                return;
            }

            double slideOutOffset = slideRight ? -50 : 50;
            double slideInStart = slideRight ? 50 : -50;

            var translate = new TranslateTransform(0, 0);
            _contentBorder.RenderTransform = translate;

            var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(120))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };
            var slideOut = new DoubleAnimation(0, slideOutOffset, TimeSpan.FromMilliseconds(180))
            {
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn }
            };

            slideOut.Completed += (s, e) =>
            {
                var item = Items[newIndex] as UI4TabItem;
                _contentPresenter.Content = item?.Content;
                translate.X = slideInStart;

                var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(120))
                {
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                };
                var slideIn = new DoubleAnimation(slideInStart, 0, TimeSpan.FromMilliseconds(180))
                {
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                };

                _contentBorder.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                translate.BeginAnimation(TranslateTransform.XProperty, slideIn);
            };

            _contentBorder.BeginAnimation(UIElement.OpacityProperty, fadeOut);
            translate.BeginAnimation(TranslateTransform.XProperty, slideOut);
        }
    }

    public class TabCloseRoutedEventArgs : RoutedEventArgs
    {
        public UI4TabItem TabItem { get; }

        public TabCloseRoutedEventArgs(RoutedEvent routedEvent, UI4TabItem tabItem)
            : base(routedEvent, tabItem)
        {
            TabItem = tabItem;
        }
    }

    internal class TabBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool b && b)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility v && v == Visibility.Visible)
                return true;
            return false;
        }
    }

    internal class TabColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color c)
                return new SolidColorBrush(c);
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class TabImageVisibilityConverter : IValueConverter
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

    internal class TabTextIconVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
