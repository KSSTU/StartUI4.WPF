using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace StartUI4Controls
{

    internal class TextOrContentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2) return string.Empty;
            string text = values[0] as string;
            object content = values[1];

            if (!string.IsNullOrEmpty(text))
                return text;
            return content?.ToString() ?? string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class UI4TextBlock : ContentControl
    {

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(UI4TextBlock),
                new PropertyMetadata(string.Empty, OnStyleRefresh));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register(
                nameof(Foreground),
                typeof(Brush),
                typeof(UI4TextBlock),
                new PropertyMetadata(null, OnStyleRefresh));

        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(UI4TextBlock),
                new PropertyMetadata(new CornerRadius(8), OnStyleRefresh));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty GradientStartProperty =
            DependencyProperty.Register(
                nameof(GradientStart),
                typeof(Color),
                typeof(UI4TextBlock),
                new PropertyMetadata(Color.FromRgb(37, 99, 235), OnStyleRefresh));

        public Color GradientStart
        {
            get => (Color)GetValue(GradientStartProperty);
            set => SetValue(GradientStartProperty, value);
        }

        public static readonly DependencyProperty GradientEndProperty =
            DependencyProperty.Register(
                nameof(GradientEnd),
                typeof(Color),
                typeof(UI4TextBlock),
                new PropertyMetadata(Color.FromRgb(147, 51, 234), OnStyleRefresh));

        public Color GradientEnd
        {
            get => (Color)GetValue(GradientEndProperty);
            set => SetValue(GradientEndProperty, value);
        }

        public static readonly DependencyProperty PanelBackgroundProperty =
            DependencyProperty.Register(
                nameof(PanelBackground),
                typeof(Brush),
                typeof(UI4TextBlock),
                new PropertyMetadata(Brushes.Transparent, OnStyleRefresh));

        public Brush PanelBackground
        {
            get => (Brush)GetValue(PanelBackgroundProperty);
            set => SetValue(PanelBackgroundProperty, value);
        }

        public static readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register(
                nameof(Padding),
                typeof(Thickness),
                typeof(UI4TextBlock),
                new PropertyMetadata(new Thickness(8, 6, 8, 6), OnStyleRefresh));

        public new Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register(
                nameof(FontSize),
                typeof(double),
                typeof(UI4TextBlock),
                new PropertyMetadata(15d, OnStyleRefresh));

        public new double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty FontWeightProperty =
            DependencyProperty.Register(
                nameof(FontWeight),
                typeof(FontWeight),
                typeof(UI4TextBlock),
                new PropertyMetadata(FontWeights.Normal, OnStyleRefresh));

        public new FontWeight FontWeight
        {
            get => (FontWeight)GetValue(FontWeightProperty);
            set => SetValue(FontWeightProperty, value);
        }

        public static readonly DependencyProperty HorizontalContentAlignProperty =
            DependencyProperty.Register(
                nameof(HorizontalContentAlign),
                typeof(HorizontalAlignment),
                typeof(UI4TextBlock),
                new PropertyMetadata(HorizontalAlignment.Left, OnStyleRefresh));

        public HorizontalAlignment HorizontalContentAlign
        {
            get => (HorizontalAlignment)GetValue(HorizontalContentAlignProperty);
            set => SetValue(HorizontalContentAlignProperty, value);
        }

        public static readonly DependencyProperty VerticalContentAlignProperty =
            DependencyProperty.Register(
                nameof(VerticalContentAlign),
                typeof(VerticalAlignment),
                typeof(UI4TextBlock),
                new PropertyMetadata(VerticalAlignment.Center, OnStyleRefresh));

        public VerticalAlignment VerticalContentAlign
        {
            get => (VerticalAlignment)GetValue(VerticalContentAlignProperty);
            set => SetValue(VerticalContentAlignProperty, value);
        }

        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register(
                nameof(TextWrapping),
                typeof(TextWrapping),
                typeof(UI4TextBlock),
                new PropertyMetadata(TextWrapping.NoWrap, OnStyleRefresh));

        public TextWrapping TextWrapping
        {
            get => (TextWrapping)GetValue(TextWrappingProperty);
            set => SetValue(TextWrappingProperty, value);
        }

        public static readonly DependencyProperty ShadowDepthProperty =
            DependencyProperty.Register(
                nameof(ShadowDepth),
                typeof(double),
                typeof(UI4TextBlock),
                new PropertyMetadata(8.0, OnShadowPropertyChanged));

        public double ShadowDepth
        {
            get => (double)GetValue(ShadowDepthProperty);
            set => SetValue(ShadowDepthProperty, value);
        }

        public static readonly DependencyProperty ShadowBlurRadiusProperty =
            DependencyProperty.Register(
                nameof(ShadowBlurRadius),
                typeof(double),
                typeof(UI4TextBlock),
                new PropertyMetadata(5.0, OnShadowPropertyChanged));

        public double ShadowBlurRadius
        {
            get => (double)GetValue(ShadowBlurRadiusProperty);
            set => SetValue(ShadowBlurRadiusProperty, value);
        }

        public static readonly DependencyProperty ShadowOpacityProperty =
            DependencyProperty.Register(
                nameof(ShadowOpacity),
                typeof(double),
                typeof(UI4TextBlock),
                new PropertyMetadata(0.2, OnShadowPropertyChanged));

        public double ShadowOpacity
        {
            get => (double)GetValue(ShadowOpacityProperty);
            set => SetValue(ShadowOpacityProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register(
                nameof(ShadowColor),
                typeof(Color),
                typeof(UI4TextBlock),
                new PropertyMetadata(Colors.Black, OnShadowPropertyChanged));

        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        private TextBox? _textBox;
        private UI4ContextMenu _contextMenu;

        static UI4TextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4TextBlock),
                new FrameworkPropertyMetadata(typeof(UI4TextBlock)));
        }

        public UI4TextBlock()
        {
            Style = BuildTextStyle();
            Loaded += UI4TextBlock_Loaded;
        }

        private static void OnStyleRefresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4TextBlock textCtrl)
                textCtrl.Style = textCtrl.BuildTextStyle();
        }

        private static void OnShadowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4TextBlock ctrl)
                ctrl.UpdateTextShadow();
        }

        private void UpdateTextShadow()
        {
            if (_textBox == null) return;
            _textBox.Effect = new DropShadowEffect
            {
                ShadowDepth = ShadowDepth,
                BlurRadius = ShadowBlurRadius,
                Opacity = ShadowOpacity,
                Color = ShadowColor
            };
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _textBox = GetTemplateChild("PART_TextBox") as TextBox;
            InitCustomMenu();
            UpdateTextShadow();
        }

        private void UI4TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            InitCustomMenu();
        }

        private void InitCustomMenu()
        {
            if (_textBox == null || _contextMenu != null) return;

            _contextMenu = new UI4ContextMenu
            {
                Width = 150
            };

            _contextMenu.AddItem(UI4MenuItemType.Copy,
                () =>
                {
                    if (!string.IsNullOrEmpty(_textBox.SelectedText))
                        Clipboard.SetText(_textBox.SelectedText);
                },
                () => !string.IsNullOrEmpty(_textBox.SelectedText));

            _contextMenu.AddItem(UI4MenuItemType.SelectAll,
                () => _textBox.SelectAll());

            _textBox.ContextMenu = null;
            _contextMenu.Attach(_textBox);
        }

        private Style BuildTextStyle()
        {
            Style style = new Style(typeof(ContentControl));

            style.Setters.Add(new Setter(ContentControl.PaddingProperty, Padding));
            style.Setters.Add(new Setter(ContentControl.HorizontalContentAlignmentProperty, HorizontalContentAlign));
            style.Setters.Add(new Setter(ContentControl.VerticalContentAlignmentProperty, VerticalContentAlign));

            ControlTemplate template = new ControlTemplate(typeof(ContentControl));
            FrameworkElementFactory borderRoot = new FrameworkElementFactory(typeof(Border));
            borderRoot.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(CornerRadius)) { RelativeSource = RelativeSource.TemplatedParent });
            borderRoot.SetBinding(Border.BackgroundProperty, new Binding(nameof(PanelBackground)) { RelativeSource = RelativeSource.TemplatedParent });

            FrameworkElementFactory textBox = new FrameworkElementFactory(typeof(TextBox));
            textBox.Name = "PART_TextBox";
            textBox.SetValue(TextBox.BackgroundProperty, null);
            textBox.SetValue(TextBox.BorderThicknessProperty, new Thickness(0));
            textBox.SetValue(TextBox.IsReadOnlyProperty, true);

            MultiBinding textMultiBind = new MultiBinding
            {
                Converter = new TextOrContentConverter()
            };
            textMultiBind.Bindings.Add(new Binding(nameof(Text)) { RelativeSource = RelativeSource.TemplatedParent });
            textMultiBind.Bindings.Add(new Binding(nameof(Content)) { RelativeSource = RelativeSource.TemplatedParent });
            textBox.SetBinding(TextBox.TextProperty, textMultiBind);

            textBox.SetBinding(TextBox.TextWrappingProperty, new Binding(nameof(TextWrapping)) { RelativeSource = RelativeSource.TemplatedParent });
            textBox.SetBinding(TextBox.FontSizeProperty, new Binding(nameof(FontSize)) { RelativeSource = RelativeSource.TemplatedParent });
            textBox.SetBinding(TextBox.FontWeightProperty, new Binding(nameof(FontWeight)) { RelativeSource = RelativeSource.TemplatedParent });
            textBox.SetBinding(TextBox.HorizontalAlignmentProperty, new Binding(nameof(HorizontalContentAlign)) { RelativeSource = RelativeSource.TemplatedParent });
            textBox.SetBinding(TextBox.VerticalAlignmentProperty, new Binding(nameof(VerticalContentAlign)) { RelativeSource = RelativeSource.TemplatedParent });

            if (Foreground != null)
            {
                textBox.SetValue(TextBox.ForegroundProperty, Foreground);
            }

            borderRoot.AppendChild(textBox);
            template.VisualTree = borderRoot;
            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            return style;
        }

    }
}
