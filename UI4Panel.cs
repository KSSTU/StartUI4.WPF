using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace StartUI4Controls
{
    public class UI4Panel : ContentControl
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(UI4Panel),
                new PropertyMetadata(new CornerRadius(12), OnStyleUpdate));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register(
                nameof(BorderBrush),
                typeof(Color),
                typeof(UI4Panel),
                new PropertyMetadata(Color.FromArgb(60, 120, 140, 200), OnStyleUpdate));

        public new Color BorderBrush
        {
            get => (Color)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }

        public static readonly DependencyProperty HoverBorderBrushProperty =
            DependencyProperty.Register(
                nameof(HoverBorderBrush),
                typeof(SolidColorBrush),
                typeof(UI4Panel),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(0x63, 0x66, 0xF1)), OnStyleUpdate));

        public SolidColorBrush HoverBorderBrush
        {
            get => (SolidColorBrush)GetValue(HoverBorderBrushProperty);
            set => SetValue(HoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register(
                nameof(BorderThickness),
                typeof(Thickness),
                typeof(UI4Panel),
                new PropertyMetadata(new Thickness(1), OnStyleUpdate));

        public new Thickness BorderThickness
        {
            get => (Thickness)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ShadowDepthProperty =
            DependencyProperty.Register(
                nameof(ShadowDepth),
                typeof(double),
                typeof(UI4Panel),
                new PropertyMetadata(0.0, OnStyleUpdate));

        public double ShadowDepth
        {
            get => (double)GetValue(ShadowDepthProperty);
            set => SetValue(ShadowDepthProperty, value);
        }

        public static readonly DependencyProperty ShadowBlurRadiusProperty =
            DependencyProperty.Register(
                nameof(ShadowBlurRadius),
                typeof(double),
                typeof(UI4Panel),
                new PropertyMetadata(15.0, OnStyleUpdate));

        public double ShadowBlurRadius
        {
            get => (double)GetValue(ShadowBlurRadiusProperty);
            set => SetValue(ShadowBlurRadiusProperty, value);
        }

        public static readonly DependencyProperty ShadowOpacityProperty =
            DependencyProperty.Register(
                nameof(ShadowOpacity),
                typeof(double),
                typeof(UI4Panel),
                new PropertyMetadata(0.1, OnStyleUpdate));

        public double ShadowOpacity
        {
            get => (double)GetValue(ShadowOpacityProperty);
            set => SetValue(ShadowOpacityProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register(
                nameof(ShadowColor),
                typeof(Color),
                typeof(UI4Panel),
                new PropertyMetadata(Colors.Black, OnStyleUpdate));

        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ContentPaddingProperty =
            DependencyProperty.Register(
                nameof(ContentPadding),
                typeof(Thickness),
                typeof(UI4Panel),
                new PropertyMetadata(new Thickness(0), OnStyleUpdate));

        public Thickness ContentPadding
        {
            get => (Thickness)GetValue(ContentPaddingProperty);
            set => SetValue(ContentPaddingProperty, value);
        }

        public static readonly DependencyProperty HoverAnimationDurationProperty =
            DependencyProperty.Register(
                nameof(HoverAnimationDuration),
                typeof(Duration),
                typeof(UI4Panel),
                new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(200)), OnStyleUpdate));

        public Duration HoverAnimationDuration
        {
            get => (Duration)GetValue(HoverAnimationDurationProperty);
            set => SetValue(HoverAnimationDurationProperty, value);
        }

        public static readonly DependencyProperty HoverScaleProperty =
            DependencyProperty.Register(
                nameof(HoverScale),
                typeof(double),
                typeof(UI4Panel),
                new PropertyMetadata(1.01, OnStyleUpdate));
        public double HoverScale
        {
            get => (double)GetValue(HoverScaleProperty);
            set => SetValue(HoverScaleProperty, value);
        }

        private static void OnStyleUpdate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Panel panel)
                panel.Style = panel.BuildPanelStyle();
        }

        static UI4Panel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4Panel),
                new FrameworkPropertyMetadata(typeof(UI4Panel)));

        }

        public UI4Panel()
        {
            Background = new SolidColorBrush(Color.FromArgb(10, 255, 255, 255));
            Style = BuildPanelStyle();
            Cursor = Cursors.Arrow;
        }

        private Style BuildPanelStyle()
        {
            Style style = new Style(typeof(ContentControl));

            ControlTemplate template = new ControlTemplate(typeof(ContentControl));

            FrameworkElementFactory rootBorder = new FrameworkElementFactory(typeof(Border));
            rootBorder.Name = "PART_RootBorder";
            rootBorder.SetBinding(Border.CornerRadiusProperty,
                new Binding(nameof(CornerRadius)) { RelativeSource = RelativeSource.TemplatedParent });
            rootBorder.SetBinding(Border.BackgroundProperty,
                new Binding(nameof(Background)) { RelativeSource = RelativeSource.TemplatedParent });
            rootBorder.SetBinding(Border.BorderThicknessProperty,
                new Binding(nameof(BorderThickness)) { RelativeSource = RelativeSource.TemplatedParent });
            rootBorder.SetBinding(Border.PaddingProperty,
                new Binding(nameof(ContentPadding)) { RelativeSource = RelativeSource.TemplatedParent });
            rootBorder.SetValue(Border.BorderBrushProperty, new SolidColorBrush(BorderBrush));
            rootBorder.SetValue(UIElement.ClipToBoundsProperty, true);
            rootBorder.SetValue(UIElement.RenderTransformOriginProperty, new Point(0.5, 0.5));
            ScaleTransform scaleTransform = new ScaleTransform(1, 1);
            rootBorder.SetValue(UIElement.RenderTransformProperty, scaleTransform);
            var shadow = new DropShadowEffect
            {
                ShadowDepth = ShadowDepth,
                BlurRadius = ShadowBlurRadius,
                Opacity = ShadowOpacity,
                Color = ShadowColor
            };
            rootBorder.SetValue(UIElement.EffectProperty, shadow);

            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
            contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Stretch);
            rootBorder.AppendChild(contentPresenter);

            template.VisualTree = rootBorder;

            ColorAnimation hoverAnim = new ColorAnimation
            {
                To = HoverBorderBrush.Color,
                Duration = HoverAnimationDuration
            };

            Storyboard hoverStoryboard = new Storyboard();
            hoverStoryboard.Children.Add(hoverAnim);
            Storyboard.SetTargetName(hoverAnim, "PART_RootBorder");
            Storyboard.SetTargetProperty(hoverAnim,
                new PropertyPath("(Border.BorderBrush).(SolidColorBrush.Color)"));

            ColorAnimation leaveAnim = new ColorAnimation
            {
                To = BorderBrush,
                Duration = HoverAnimationDuration
            };

            Storyboard leaveStoryboard = new Storyboard();
            leaveStoryboard.Children.Add(leaveAnim);
            Storyboard.SetTargetName(leaveAnim, "PART_RootBorder");
            Storyboard.SetTargetProperty(leaveAnim,
                new PropertyPath("(Border.BorderBrush).(SolidColorBrush.Color)"));

            DoubleAnimation scaleXHoverAnim = new DoubleAnimation
            {
                To = HoverScale,
                Duration = HoverAnimationDuration,
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            DoubleAnimation scaleYHoverAnim = new DoubleAnimation
            {
                To = HoverScale,
                Duration = HoverAnimationDuration,
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            hoverStoryboard.Children.Add(scaleXHoverAnim);
            hoverStoryboard.Children.Add(scaleYHoverAnim);
            Storyboard.SetTargetName(scaleXHoverAnim, "PART_RootBorder");
            Storyboard.SetTargetProperty(scaleXHoverAnim, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            Storyboard.SetTargetName(scaleYHoverAnim, "PART_RootBorder");
            Storyboard.SetTargetProperty(scaleYHoverAnim, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            DoubleAnimation scaleXLeaveAnim = new DoubleAnimation
            {
                To = 1.0,
                Duration = HoverAnimationDuration,
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            DoubleAnimation scaleYLeaveAnim = new DoubleAnimation
            {
                To = 1.0,
                Duration = HoverAnimationDuration,
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            leaveStoryboard.Children.Add(scaleXLeaveAnim);
            leaveStoryboard.Children.Add(scaleYLeaveAnim);
            Storyboard.SetTargetName(scaleXLeaveAnim, "PART_RootBorder");
            Storyboard.SetTargetProperty(scaleXLeaveAnim, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            Storyboard.SetTargetName(scaleYLeaveAnim, "PART_RootBorder");
            Storyboard.SetTargetProperty(scaleYLeaveAnim, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            EventTrigger mouseEnterTrigger = new EventTrigger(UIElement.MouseEnterEvent);
            mouseEnterTrigger.Actions.Add(new BeginStoryboard { Storyboard = hoverStoryboard });
            template.Triggers.Add(mouseEnterTrigger);

            EventTrigger mouseLeaveTrigger = new EventTrigger(UIElement.MouseLeaveEvent);
            mouseLeaveTrigger.Actions.Add(new BeginStoryboard { Storyboard = leaveStoryboard });
            template.Triggers.Add(mouseLeaveTrigger);

            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            style.Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
            style.Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Stretch));
            return style;
        }
    }
}
