using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StartUI4Controls
{
    public class UI4CheckBox : CheckBox
    {
        public static readonly DependencyProperty BoxCornerRadiusProperty =
            DependencyProperty.Register(
                nameof(BoxCornerRadius),
                typeof(CornerRadius),
                typeof(UI4CheckBox),
                new PropertyMetadata(new CornerRadius(4), OnStyleRefresh));

        public CornerRadius BoxCornerRadius
        {
            get => (CornerRadius)GetValue(BoxCornerRadiusProperty);
            set => SetValue(BoxCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CheckBackgroundProperty =
            DependencyProperty.Register(
                nameof(CheckBackground),
                typeof(Color),
                typeof(UI4CheckBox),
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
                typeof(UI4CheckBox),
                new PropertyMetadata(Color.FromRgb(180, 180, 200), OnStyleRefresh));

        public Color BorderNormalColor
        {
            get => (Color)GetValue(BorderNormalColorProperty);
            set => SetValue(BorderNormalColorProperty, value);
        }

        public static readonly DependencyProperty BoxSizeProperty =
            DependencyProperty.Register(
                nameof(BoxSize),
                typeof(double),
                typeof(UI4CheckBox),
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
                typeof(UI4CheckBox),
                new PropertyMetadata(Colors.LightGray, OnStyleRefresh));

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register(
                nameof(TextMargin),
                typeof(Thickness),
                typeof(UI4CheckBox),
                new PropertyMetadata(new Thickness(8, 0, 0, 0), OnStyleRefresh));

        public Thickness TextMargin
        {
            get => (Thickness)GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        private static void OnStyleRefresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4CheckBox ctrl)
                ctrl.Style = ctrl.BuildCheckBoxStyle();
        }

        static UI4CheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4CheckBox),
                new FrameworkPropertyMetadata(typeof(UI4CheckBox)));
        }

        public UI4CheckBox()
        {
            FontSize = 15d;
            Style = BuildCheckBoxStyle();
        }

        private Style BuildCheckBoxStyle()
        {
            Style style = new Style(typeof(CheckBox));

            ControlTemplate template = new ControlTemplate(typeof(CheckBox));

            FrameworkElementFactory rootStack = new FrameworkElementFactory(typeof(StackPanel));
            rootStack.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            rootStack.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);

            FrameworkElementFactory boxBorder = new FrameworkElementFactory(typeof(Border));
            boxBorder.Name = "boxBorder";
            boxBorder.SetValue(Border.WidthProperty, BoxSize);
            boxBorder.SetValue(Border.HeightProperty, BoxSize);
            boxBorder.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(BoxCornerRadius)) { RelativeSource = RelativeSource.TemplatedParent });
            boxBorder.SetValue(Border.BorderThicknessProperty, new Thickness(1, 1, 1, 1));
            boxBorder.SetValue(Border.BorderBrushProperty, new SolidColorBrush(BorderNormalColor));
            boxBorder.SetValue(Border.BackgroundProperty, Brushes.LightGray);

            FrameworkElementFactory checkMark = new FrameworkElementFactory(typeof(Path));
            checkMark.Name = "checkMark";
            checkMark.SetValue(Path.StrokeProperty, Brushes.White);
            checkMark.SetValue(Path.StrokeThicknessProperty, 2.5d);
            checkMark.SetValue(Path.StrokeStartLineCapProperty, PenLineCap.Round);
            checkMark.SetValue(Path.StrokeEndLineCapProperty, PenLineCap.Round);
            checkMark.SetValue(Path.DataProperty, Geometry.Parse("M3,9 L7,13 L14,4"));
            checkMark.SetValue(Path.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            checkMark.SetValue(Path.VerticalAlignmentProperty, VerticalAlignment.Center);
            checkMark.SetValue(UIElement.VisibilityProperty, Visibility.Collapsed);
            boxBorder.AppendChild(checkMark);

            rootStack.AppendChild(boxBorder);

            FrameworkElementFactory textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.Name = "PART_TextBlock";

            textBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Content)) { RelativeSource = RelativeSource.TemplatedParent });
            textBlock.SetBinding(TextBlock.MarginProperty, new Binding(nameof(TextMargin)) { RelativeSource = RelativeSource.TemplatedParent });
            textBlock.SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(TextColor));
            textBlock.SetBinding(TextBlock.FontSizeProperty, new Binding(nameof(FontSize)) { RelativeSource = RelativeSource.TemplatedParent });
            textBlock.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            rootStack.AppendChild(textBlock);

            template.VisualTree = rootStack;

            Trigger checkedTrigger = new Trigger
            {
                Property = ToggleButton.IsCheckedProperty,
                Value = true
            };
            SolidColorBrush checkBrush = new SolidColorBrush(CheckBackground);
            checkedTrigger.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Visible) { TargetName = "checkMark" });
            checkedTrigger.Setters.Add(new Setter(Border.BackgroundProperty, checkBrush) { TargetName = "boxBorder" });
            checkedTrigger.Setters.Add(new Setter(TextBlock.ForegroundProperty, new Binding(nameof(Foreground)) { RelativeSource = RelativeSource.TemplatedParent }) { TargetName = "PART_TextBlock" });
            template.Triggers.Add(checkedTrigger);

            Trigger hoverTrigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            hoverTrigger.Setters.Add(new Setter(Border.BorderBrushProperty, new SolidColorBrush(Color.FromRgb(140, 140, 170))) { TargetName = "boxBorder" });
            template.Triggers.Add(hoverTrigger);

            style.Setters.Add(new Setter(Control.TemplateProperty, template));
            return style;
        }
    }
}
