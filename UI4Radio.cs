using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StartUI4Controls
{
    public class UI4Radio : RadioButton
    {
        public static readonly DependencyProperty CheckBackgroundProperty =
            DependencyProperty.Register(
                nameof(CheckBackground),
                typeof(Color),
                typeof(UI4Radio),
                new PropertyMetadata(Color.FromRgb(29, 78, 216), OnStyleRefresh));

        public Color CheckBackground
        {
            get => (Color)GetValue(CheckBackgroundProperty);
            set => SetValue(CheckBackgroundProperty, value);
        }

        public static readonly DependencyProperty BorderNormalColorProperty =
            DependencyProperty.Register(
                nameof(BorderNormalColor),
                typeof(Color),
                typeof(UI4Radio),
                new PropertyMetadata(Color.FromRgb(180, 180, 200), OnStyleRefresh));

        public Color BorderNormalColor
        {
            get => (Color)GetValue(BorderNormalColorProperty);
            set => SetValue(BorderNormalColorProperty, value);
        }

        public static readonly DependencyProperty DotColorProperty =
            DependencyProperty.Register(
                nameof(DotColor),
                typeof(Color),
                typeof(UI4Radio),
                new PropertyMetadata(Colors.White, OnStyleRefresh));

        public Color DotColor
        {
            get => (Color)GetValue(DotColorProperty);
            set => SetValue(DotColorProperty, value);
        }

        public static readonly DependencyProperty BoxSizeProperty =
            DependencyProperty.Register(
                nameof(BoxSize),
                typeof(double),
                typeof(UI4Radio),
                new PropertyMetadata(18d, OnStyleRefresh));

        public double BoxSize
        {
            get => (double)GetValue(BoxSizeProperty);
            set => SetValue(BoxSizeProperty, value);
        }

        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register(
                nameof(TextColor),
                typeof(Color),
                typeof(UI4Radio),
                new PropertyMetadata(Colors.Black, OnStyleRefresh));

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register(
                nameof(TextMargin),
                typeof(Thickness),
                typeof(UI4Radio),
                new PropertyMetadata(new Thickness(8, 0, 0, 0), OnStyleRefresh));

        public Thickness TextMargin
        {
            get => (Thickness)GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        private static void OnStyleRefresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Radio ctrl)
                ctrl.Style = ctrl.BuildRadioStyle();
        }

        static UI4Radio()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4Radio),
                new FrameworkPropertyMetadata(typeof(UI4Radio)));
        }

        public UI4Radio()
        {
            FontSize = 15d;
            Style = BuildRadioStyle();
        }

        private Style BuildRadioStyle()
        {
            Style style = new Style(typeof(RadioButton));

            ControlTemplate template = new ControlTemplate(typeof(RadioButton));

            FrameworkElementFactory rootStack = new FrameworkElementFactory(typeof(StackPanel));
            rootStack.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            rootStack.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);

            FrameworkElementFactory outerEllipse = new FrameworkElementFactory(typeof(Ellipse));
            outerEllipse.Name = "outerEllipse";
            outerEllipse.SetValue(Ellipse.WidthProperty, BoxSize);
            outerEllipse.SetValue(Ellipse.HeightProperty, BoxSize);
            outerEllipse.SetValue(Shape.StrokeProperty, new SolidColorBrush(BorderNormalColor));
            outerEllipse.SetValue(Shape.StrokeThicknessProperty, 1.5d);
            outerEllipse.SetValue(Shape.FillProperty, Brushes.Transparent);

            FrameworkElementFactory innerDot = new FrameworkElementFactory(typeof(Ellipse));
            innerDot.Name = "innerDot";
            innerDot.SetValue(Ellipse.WidthProperty, BoxSize * 0.5);
            innerDot.SetValue(Ellipse.HeightProperty, BoxSize * 0.5);
            innerDot.SetValue(Shape.FillProperty, new SolidColorBrush(DotColor));
            innerDot.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            innerDot.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            innerDot.SetValue(UIElement.VisibilityProperty, Visibility.Collapsed);

            FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
            grid.SetValue(FrameworkElement.WidthProperty, BoxSize);
            grid.SetValue(FrameworkElement.HeightProperty, BoxSize);
            grid.AppendChild(outerEllipse);
            grid.AppendChild(innerDot);

            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenter.SetBinding(ContentPresenter.MarginProperty,
                new System.Windows.Data.Binding(nameof(TextMargin)) { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent });
            contentPresenter.SetBinding(TextBlock.ForegroundProperty,
                new System.Windows.Data.Binding(nameof(TextColor)) { RelativeSource = System.Windows.Data.RelativeSource.TemplatedParent, Converter = new ColorToBrushConverter() });
            contentPresenter.SetValue(TextBlock.FontSizeProperty, FontSize);

            rootStack.AppendChild(grid);
            rootStack.AppendChild(contentPresenter);

            template.VisualTree = rootStack;

            Trigger checkedTrigger = new Trigger { Property = ToggleButton.IsCheckedProperty, Value = true };
            checkedTrigger.Setters.Add(new Setter(Shape.FillProperty, new SolidColorBrush(CheckBackground)) { TargetName = "outerEllipse" });
            checkedTrigger.Setters.Add(new Setter(Shape.StrokeProperty, new SolidColorBrush(CheckBackground)) { TargetName = "outerEllipse" });
            checkedTrigger.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Visible) { TargetName = "innerDot" });
            template.Triggers.Add(checkedTrigger);

            Trigger hoverTrigger = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
            hoverTrigger.Setters.Add(new Setter(Shape.StrokeProperty, new SolidColorBrush(CheckBackground)) { TargetName = "outerEllipse" });
            template.Triggers.Add(hoverTrigger);

            Trigger disabledTrigger = new Trigger { Property = UIElement.IsEnabledProperty, Value = false };
            disabledTrigger.Setters.Add(new Setter(UIElement.OpacityProperty, 0.5) { TargetName = "outerEllipse" });
            template.Triggers.Add(disabledTrigger);

            style.Setters.Add(new Setter(Control.TemplateProperty, template));
            style.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(2)));
            style.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            style.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Left));

            return style;
        }

        private class ColorToBrushConverter : IValueConverter
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
    }
}
