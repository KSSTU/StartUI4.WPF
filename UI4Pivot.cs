using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace StartUI4Controls
{
    public class UI4PivotItem : HeaderedContentControl
    {
        public static readonly DependencyProperty IsBrandProperty =
            DependencyProperty.Register(nameof(IsBrand), typeof(bool), typeof(UI4PivotItem),
                new PropertyMetadata(false));

        public bool IsBrand
        {
            get => (bool)GetValue(IsBrandProperty);
            set => SetValue(IsBrandProperty, value);
        }

        static UI4PivotItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4PivotItem),
                new FrameworkPropertyMetadata(typeof(UI4PivotItem)));
        }

        public UI4PivotItem()
        {
            Background = Brushes.Transparent;
            BorderThickness = new Thickness(0);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            var parentPivot = ItemsControl.ItemsControlFromItemContainer(this) as UI4Pivot;
            if (parentPivot != null)
            {
                int idx = parentPivot.ItemContainerGenerator.IndexFromContainer(this);
                if (idx >= 0)
                    parentPivot.SelectedIndex = idx;
            }
            e.Handled = true;
        }
    }

    public class UI4Pivot : Selector
    {
        public static readonly DependencyProperty SelectedItemForegroundProperty =
            DependencyProperty.Register(nameof(SelectedItemForeground), typeof(Color), typeof(UI4Pivot),
                new PropertyMetadata(Color.FromRgb(37, 99, 235), OnStyleChanged));

        public Color SelectedItemForeground
        {
            get => (Color)GetValue(SelectedItemForegroundProperty);
            set => SetValue(SelectedItemForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemFontSizeProperty =
            DependencyProperty.Register(nameof(ItemFontSize), typeof(double), typeof(UI4Pivot),
                new PropertyMetadata(20.0, OnStyleChanged));

        public double ItemFontSize
        {
            get => (double)GetValue(ItemFontSizeProperty);
            set => SetValue(ItemFontSizeProperty, value);
        }

        public static readonly DependencyProperty SelectedFontSizeProperty =
            DependencyProperty.Register(nameof(SelectedFontSize), typeof(double), typeof(UI4Pivot),
                new PropertyMetadata(25.0, OnStyleChanged));

        public double SelectedFontSize
        {
            get => (double)GetValue(SelectedFontSizeProperty);
            set => SetValue(SelectedFontSizeProperty, value);
        }

        public static readonly DependencyProperty BrandFontSizeProperty =
            DependencyProperty.Register(nameof(BrandFontSize), typeof(double), typeof(UI4Pivot),
                new PropertyMetadata(22.0, OnStyleChanged));

        public double BrandFontSize
        {
            get => (double)GetValue(BrandFontSizeProperty);
            set => SetValue(BrandFontSizeProperty, value);
        }

        public static readonly DependencyProperty ItemFontWeightProperty =
            DependencyProperty.Register(nameof(ItemFontWeight), typeof(FontWeight), typeof(UI4Pivot),
                new PropertyMetadata(FontWeights.Normal, OnStyleChanged));

        public FontWeight ItemFontWeight
        {
            get => (FontWeight)GetValue(ItemFontWeightProperty);
            set => SetValue(ItemFontWeightProperty, value);
        }

        public static readonly DependencyProperty BrandFontWeightProperty =
            DependencyProperty.Register(nameof(BrandFontWeight), typeof(FontWeight), typeof(UI4Pivot),
                new PropertyMetadata(FontWeights.SemiBold, OnStyleChanged));

        public FontWeight BrandFontWeight
        {
            get => (FontWeight)GetValue(BrandFontWeightProperty);
            set => SetValue(BrandFontWeightProperty, value);
        }

        public static readonly DependencyProperty ItemForegroundProperty =
            DependencyProperty.Register(nameof(ItemForeground), typeof(Color), typeof(UI4Pivot),
                new PropertyMetadata(Color.FromArgb(220, 0, 0, 0), OnStyleChanged));

        public Color ItemForeground
        {
            get => (Color)GetValue(ItemForegroundProperty);
            set => SetValue(ItemForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemHoverForegroundProperty =
            DependencyProperty.Register(nameof(ItemHoverForeground), typeof(Color), typeof(UI4Pivot),
                new PropertyMetadata(Color.FromArgb(220, 0, 0, 0), OnStyleChanged));

        public Color ItemHoverForeground
        {
            get => (Color)GetValue(ItemHoverForegroundProperty);
            set => SetValue(ItemHoverForegroundProperty, value);
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.Register(nameof(ItemPadding), typeof(Thickness), typeof(UI4Pivot),
                new PropertyMetadata(new Thickness(10, 8, 10, 8), OnStyleChanged));

        public Thickness ItemPadding
        {
            get => (Thickness)GetValue(ItemPaddingProperty);
            set => SetValue(ItemPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemMarginProperty =
            DependencyProperty.Register(nameof(ItemMargin), typeof(Thickness), typeof(UI4Pivot),
                new PropertyMetadata(new Thickness(5, 0, 5, 0), OnStyleChanged));

        public Thickness ItemMargin
        {
            get => (Thickness)GetValue(ItemMarginProperty);
            set => SetValue(ItemMarginProperty, value);
        }

        private ContentPresenter _contentPresenter;
        private Border _contentBorder;
        private int _previousIndex = 0;

        private static void OnStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Pivot pivot)
                pivot.RebuildStyle();
        }

        static UI4Pivot()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4Pivot),
                new FrameworkPropertyMetadata(typeof(UI4Pivot)));
        }

        public UI4Pivot()
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
                var firstItem = Items[SelectedIndex] as UI4PivotItem;
                if (_contentPresenter != null)
                    _contentPresenter.Content = firstItem?.Content;
            }
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
            => item is UI4PivotItem;

        protected override DependencyObject GetContainerForItemOverride()
            => new UI4PivotItem();

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _contentPresenter = GetTemplateChild("PART_ContentPresenter") as ContentPresenter;
            _contentBorder = GetTemplateChild("PART_ContentBorder") as Border;
            ApplySelection();
        }

        private void RebuildStyle()
        {
            Style = BuildPivotStyle();
        }

        private Style BuildPivotStyle()
        {
            var style = new Style(typeof(Selector));
            style.Setters.Add(new Setter(BackgroundProperty, Brushes.Transparent));
            style.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));

            var template = new ControlTemplate(typeof(Selector));

            var root = new FrameworkElementFactory(typeof(DockPanel));

            var headerScrollViewer = new FrameworkElementFactory(typeof(UI4ScrollViewer));
            headerScrollViewer.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            headerScrollViewer.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
            headerScrollViewer.SetValue(DockPanel.DockProperty, Dock.Top);
            headerScrollViewer.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 0, 0, 8));

            var itemsPresenter = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemsPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

            headerScrollViewer.AppendChild(itemsPresenter);

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
            root.AppendChild(headerScrollViewer);
            root.AppendChild(contentBorder);
            template.VisualTree = root;

            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            var stackPanel = new FrameworkElementFactory(typeof(StackPanel));
            stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            var itemsPanelTemplate = new ItemsPanelTemplate();
            itemsPanelTemplate.VisualTree = stackPanel;
            style.Setters.Add(new Setter(ItemsPanelProperty, itemsPanelTemplate));

            var itemStyle = new Style(typeof(UI4PivotItem));
            itemStyle.Setters.Add(new Setter(UI4PivotItem.CursorProperty, Cursors.Hand));
            itemStyle.Setters.Add(new Setter(UI4PivotItem.BackgroundProperty, Brushes.Transparent));
            itemStyle.Setters.Add(new Setter(UI4PivotItem.BorderThicknessProperty, new Thickness(0)));
            itemStyle.Setters.Add(new Setter(UI4PivotItem.ForegroundProperty, new SolidColorBrush(ItemForeground)));
            itemStyle.Setters.Add(new Setter(UI4PivotItem.FontSizeProperty, new Binding(nameof(ItemFontSize)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Pivot), 1) }));
            itemStyle.Setters.Add(new Setter(UI4PivotItem.PaddingProperty, new Binding(nameof(ItemPadding)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Pivot), 1) }));
            itemStyle.Setters.Add(new Setter(UI4PivotItem.MarginProperty, new Binding(nameof(ItemMargin)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Pivot), 1) }));

            var itemTemplate = new ControlTemplate(typeof(UI4PivotItem));

            var itemBorder = new FrameworkElementFactory(typeof(Border));
            itemBorder.SetBinding(Border.BackgroundProperty, new Binding(nameof(Background)) { RelativeSource = RelativeSource.TemplatedParent });
            itemBorder.SetBinding(Border.BorderBrushProperty, new Binding(nameof(BorderBrush)) { RelativeSource = RelativeSource.TemplatedParent });
            itemBorder.SetBinding(Border.BorderThicknessProperty, new Binding(nameof(BorderThickness)) { RelativeSource = RelativeSource.TemplatedParent });
            itemBorder.SetBinding(Border.PaddingProperty, new Binding(nameof(Padding)) { RelativeSource = RelativeSource.TemplatedParent });
            itemBorder.SetValue(UIElement.RenderTransformOriginProperty, new Point(0.5, 0.5));

            var scaleTransform = new ScaleTransform(1, 1);
            itemBorder.SetValue(UIElement.RenderTransformProperty, scaleTransform);

            var headerPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            headerPresenter.Name = "HeaderPresenter";
            headerPresenter.SetValue(ContentPresenter.ContentSourceProperty, "Header");
            headerPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            headerPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            headerPresenter.SetBinding(TextElement.FontWeightProperty,
                new Binding(nameof(ItemFontWeight)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Pivot), 1) });
            itemBorder.AppendChild(headerPresenter);
            itemTemplate.VisualTree = itemBorder;

            var brandTrigger = new Trigger
            {
                Property = UI4PivotItem.IsBrandProperty,
                Value = true
            };
            brandTrigger.Setters.Add(new Setter(UI4PivotItem.FontSizeProperty,
                new Binding(nameof(BrandFontSize)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Pivot), 1) }));
            brandTrigger.Setters.Add(new Setter(UI4PivotItem.FontWeightProperty,
                new Binding(nameof(BrandFontWeight)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Pivot), 1) }));

            itemTemplate.Triggers.Add(brandTrigger);

            var selectedTrigger = new Trigger
            {
                Property = Selector.IsSelectedProperty,
                Value = true
            };
            selectedTrigger.Setters.Add(new Setter(TextElement.FontWeightProperty, FontWeights.Bold) { TargetName = "HeaderPresenter" });
            selectedTrigger.Setters.Add(new Setter(UI4PivotItem.ForegroundProperty, new SolidColorBrush(SelectedItemForeground)));
            selectedTrigger.Setters.Add(new Setter(UI4PivotItem.FontSizeProperty,
                new Binding(nameof(SelectedFontSize)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4Pivot), 1) }));
            itemTemplate.Triggers.Add(selectedTrigger);

            itemStyle.Setters.Add(new Setter(Control.TemplateProperty, itemTemplate));
            style.Setters.Add(new Setter(ItemContainerStyleProperty, itemStyle));

            return style;
        }

        private void ApplySelection()
        {
            if (_contentPresenter == null) return;

            int newIndex = SelectedIndex;
            if (newIndex < 0 || newIndex >= Items.Count) return;
            if (newIndex == _previousIndex) return;

            if (_contentPresenter.Content == null)
            {
                var firstItem = Items[newIndex] as UI4PivotItem;
                _contentPresenter.Content = firstItem?.Content;
                _previousIndex = newIndex;
                return;
            }

            bool slideRight = newIndex > _previousIndex;
            _previousIndex = newIndex;

            if (_contentBorder == null)
            {
                var item = Items[newIndex] as UI4PivotItem;
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
                var item = Items[newIndex] as UI4PivotItem;
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
}
