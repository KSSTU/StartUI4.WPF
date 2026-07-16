using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace StartUI4Controls
{
    public class UI4Button : Button
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(UI4Button),
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
                typeof(UI4Button),
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
                typeof(UI4Button),
                new PropertyMetadata(Color.FromRgb(147, 51, 234), OnStyleRefresh));

        public Color GradientEnd
        {
            get => (Color)GetValue(GradientEndProperty);
            set => SetValue(GradientEndProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register(
                nameof(HoverBackground),
                typeof(Brush),
                typeof(UI4Button),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(29, 78, 216)), OnStyleRefresh));
        public Brush HoverBackground
        {
            get => (Brush)GetValue(HoverBackgroundProperty);
            set => SetValue(HoverBackgroundProperty, value);
        }

        private static void OnStyleRefresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Button btn)
            {
                btn.Style = btn.BuildPrimaryStyle();
            }
        }

        static UI4Button()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4Button),
                new FrameworkPropertyMetadata(typeof(UI4Button)));
        }

        public UI4Button()
        {
            Style = BuildPrimaryStyle();
        }

        private Style BuildPrimaryStyle()
        {
            Style style = new Style(typeof(Button));
            style.Setters.Add(new Setter(ForegroundProperty, Brushes.White));
            style.Setters.Add(new Setter(PaddingProperty, new Thickness(10, 0, 10, 0)));
            style.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));
            style.Setters.Add(new Setter(FontSizeProperty, 15d));
            style.Setters.Add(new Setter(FontWeightProperty, FontWeights.SemiBold));
            style.Setters.Add(new Setter(CursorProperty, Cursors.Hand));
            style.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Color.FromRgb(37, 99, 235))));

            ControlTemplate normalTemplate = new ControlTemplate(typeof(Button));
            FrameworkElementFactory borderNormal = new FrameworkElementFactory(typeof(Border));

            borderNormal.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(CornerRadius)) { RelativeSource = RelativeSource.TemplatedParent });
            borderNormal.SetBinding(Border.BackgroundProperty, new Binding(nameof(Background)) { RelativeSource = RelativeSource.TemplatedParent });
            borderNormal.SetBinding(Border.PaddingProperty, new Binding(nameof(Padding)) { RelativeSource = RelativeSource.TemplatedParent });

            FrameworkElementFactory cpNormal = new FrameworkElementFactory(typeof(ContentPresenter));
            cpNormal.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            cpNormal.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            borderNormal.AppendChild(cpNormal);
            normalTemplate.VisualTree = borderNormal;
            style.Setters.Add(new Setter(TemplateProperty, normalTemplate));

            Trigger hoverTrigger = new Trigger
            {
                Property = IsMouseOverProperty,
                Value = true
            };
            ControlTemplate hoverTemplate = new ControlTemplate(typeof(Button));
            FrameworkElementFactory borderHover = new FrameworkElementFactory(typeof(Border));
            borderHover.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(CornerRadius)) { RelativeSource = RelativeSource.TemplatedParent });
            borderHover.SetBinding(Border.BackgroundProperty, new Binding(nameof(HoverBackground)) { RelativeSource = RelativeSource.TemplatedParent });
            borderHover.SetBinding(Border.PaddingProperty, new Binding(nameof(Padding)) { RelativeSource = RelativeSource.TemplatedParent });

            FrameworkElementFactory cpHover = new FrameworkElementFactory(typeof(ContentPresenter));
            cpHover.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            cpHover.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            borderHover.AppendChild(cpHover);
            hoverTemplate.VisualTree = borderHover;

            hoverTrigger.Setters.Add(new Setter(TemplateProperty, hoverTemplate));
            style.Triggers.Add(hoverTrigger);

            return style;
        }
    }

}
