using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace StartUI4Controls
{
    public class UI4Slider : Slider
    {

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(UI4Slider),
                new PropertyMetadata(new CornerRadius(4), OnStyleRefresh));
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty GradientStartProperty =
            DependencyProperty.Register(
                nameof(GradientStart),
                typeof(Color),
                typeof(UI4Slider),
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
                typeof(UI4Slider),
                new PropertyMetadata(Color.FromRgb(147, 51, 234), OnStyleRefresh));
        public Color GradientEnd
        {
            get => (Color)GetValue(GradientEndProperty);
            set => SetValue(GradientEndProperty, value);
        }

        public static readonly DependencyProperty TrackBackgroundProperty =
            DependencyProperty.Register(
                nameof(TrackBackground),
                typeof(Color),
                typeof(UI4Slider),
                new PropertyMetadata(Color.FromArgb(255, 255, 255, 255), OnStyleRefresh));
        public Color TrackBackground
        {
            get => (Color)GetValue(TrackBackgroundProperty);
            set => SetValue(TrackBackgroundProperty, value);
        }

        public static readonly DependencyProperty ThumbSizeProperty =
            DependencyProperty.Register(
                nameof(ThumbSize),
                typeof(double),
                typeof(UI4Slider),
                new PropertyMetadata(16d, OnStyleRefresh));
        public double ThumbSize
        {
            get => (double)GetValue(ThumbSizeProperty);
            set => SetValue(ThumbSizeProperty, value);
        }

        public static readonly DependencyProperty IsValueVisibleProperty =
            DependencyProperty.Register(
                nameof(IsValueVisible),
                typeof(bool),
                typeof(UI4Slider),
                new PropertyMetadata(true, OnStyleRefresh));
        public bool IsValueVisible
        {
            get => (bool)GetValue(IsValueVisibleProperty);
            set => SetValue(IsValueVisibleProperty, value);
        }

        private static void OnStyleRefresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Slider slider)
            {
                slider.Style = slider.BuildSliderStyle();
            }
        }

        private Border _trackFill;
        private Thumb _thumb;
        private Border _trackBg;

        static UI4Slider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4Slider),
                new FrameworkPropertyMetadata(typeof(UI4Slider)));
        }

        public UI4Slider()
        {
            Style = BuildSliderStyle();
            SizeChanged += (s, e) => UpdateTrackLayout();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _trackBg = GetTemplateChild("PART_TrackBg") as Border;
            _trackFill = GetTemplateChild("PART_TrackFill") as Border;
            _thumb = GetTemplateChild("PART_Thumb") as Thumb;
            if (_thumb != null)
            {
                _thumb.DragDelta += OnThumbDragDelta;
            }
            UpdateTrackLayout();
        }

        private void OnThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double delta = e.HorizontalChange / (ActualWidth - ThumbSize) * (Maximum - Minimum);
            Value = Math.Clamp(Value + delta, Minimum, Maximum);
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            UpdateTrackLayout();
        }

        private void UpdateTrackLayout()
        {
            if (_trackFill == null || _thumb == null || ActualWidth <= 0) return;
            if (_trackBg != null)
                _trackBg.Width = ActualWidth;

            double percent = (Value - Minimum) / (Maximum - Minimum);
            double trackWidth = ActualWidth - ThumbSize;
            if (trackWidth <= 0) return;

            double fillWidth = trackWidth * percent + ThumbSize / 2;
            _trackFill.Width = fillWidth;
            Canvas.SetLeft(_thumb, trackWidth * percent);
        }

        private Style BuildSliderStyle()
        {
            Style style = new Style(typeof(Slider));

            style.Setters.Add(new Setter(MinHeightProperty, 40d));
            style.Setters.Add(new Setter(MinWidthProperty, 100d));
            style.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));
            style.Setters.Add(new Setter(CursorProperty, Cursors.Hand));

            var gradientBrush = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 0),
                GradientStops =
                {
                    new GradientStop(GradientStart, 0),
                    new GradientStop(GradientEnd, 1)
                }
            };

            ControlTemplate template = new ControlTemplate(typeof(Slider));
            FrameworkElementFactory canvas = new FrameworkElementFactory(typeof(Canvas));

            FrameworkElementFactory trackBg = new FrameworkElementFactory(typeof(Border));
            trackBg.Name = "PART_TrackBg";
            trackBg.SetValue(Border.BackgroundProperty, new SolidColorBrush(TrackBackground));
            trackBg.SetBinding(Border.CornerRadiusProperty,
                new Binding(nameof(CornerRadius)) { RelativeSource = RelativeSource.TemplatedParent });
            trackBg.SetValue(FrameworkElement.HeightProperty, 4d);
            trackBg.SetValue(Canvas.TopProperty, 10d);
            trackBg.SetValue(FrameworkElement.WidthProperty, double.NaN);

            FrameworkElementFactory trackFill = new FrameworkElementFactory(typeof(Border));
            trackFill.Name = "PART_TrackFill";
            trackFill.SetValue(Border.BackgroundProperty, gradientBrush);
            trackFill.SetBinding(Border.CornerRadiusProperty,
                new Binding(nameof(CornerRadius)) { RelativeSource = RelativeSource.TemplatedParent });
            trackFill.SetValue(FrameworkElement.HeightProperty, 4d);
            trackFill.SetValue(Canvas.TopProperty, 10d);
            trackFill.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);

            Style thumbStyle = new Style(typeof(Thumb));
            ControlTemplate thumbTemplate = new ControlTemplate(typeof(Thumb));
            FrameworkElementFactory thumbBorder = new FrameworkElementFactory(typeof(Border));
            thumbBorder.SetValue(Border.BackgroundProperty, gradientBrush);
            thumbBorder.SetValue(Border.CornerRadiusProperty, new CornerRadius(8));
            thumbTemplate.VisualTree = thumbBorder;
            thumbStyle.Setters.Add(new Setter(Control.TemplateProperty, thumbTemplate));
            thumbStyle.Setters.Add(new Setter(FrameworkElement.WidthProperty, ThumbSize));
            thumbStyle.Setters.Add(new Setter(FrameworkElement.HeightProperty, ThumbSize));

            FrameworkElementFactory thumb = new FrameworkElementFactory(typeof(Thumb));
            thumb.Name = "PART_Thumb";
            thumb.SetValue(FrameworkElement.StyleProperty, thumbStyle);
            thumb.SetValue(Canvas.TopProperty, 4d);

            Binding toolTipBinding = new Binding(nameof(Value))
            {
                RelativeSource = RelativeSource.TemplatedParent,
                StringFormat = "F0"
            };
            thumb.SetBinding(ToolTipProperty, toolTipBinding);

            if (IsValueVisible)
            {

                FrameworkElementFactory textGrid = new FrameworkElementFactory(typeof(Grid));
                textGrid.Name = "PART_TextGrid";
                Binding widthBinding = new Binding("ActualWidth") { RelativeSource = RelativeSource.TemplatedParent };
                textGrid.SetBinding(FrameworkElement.WidthProperty, widthBinding);
                textGrid.SetValue(Canvas.BottomProperty, 5d);

                FrameworkElementFactory colDef1 = new FrameworkElementFactory(typeof(ColumnDefinition));
                colDef1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
                FrameworkElementFactory colDef2 = new FrameworkElementFactory(typeof(ColumnDefinition));
                colDef2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
                FrameworkElementFactory colDef3 = new FrameworkElementFactory(typeof(ColumnDefinition));
                colDef3.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
                textGrid.AppendChild(colDef1);
                textGrid.AppendChild(colDef2);
                textGrid.AppendChild(colDef3);

                FrameworkElementFactory minText = new FrameworkElementFactory(typeof(TextBlock));
                Binding minBinding = new Binding(nameof(Minimum)) { RelativeSource = RelativeSource.TemplatedParent, StringFormat = "F0" };
                minText.SetBinding(TextBlock.TextProperty, minBinding);
                minText.SetValue(Grid.ColumnProperty, 0);
                minText.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                minText.SetBinding(TextBlock.ForegroundProperty, new Binding("Foreground") { RelativeSource = RelativeSource.TemplatedParent });
                minText.SetValue(TextBlock.FontSizeProperty, 12d);

                FrameworkElementFactory maxText = new FrameworkElementFactory(typeof(TextBlock));
                Binding maxBinding = new Binding(nameof(Maximum)) { RelativeSource = RelativeSource.TemplatedParent, StringFormat = "F0" };
                maxText.SetBinding(TextBlock.TextProperty, maxBinding);
                maxText.SetValue(Grid.ColumnProperty, 2);
                maxText.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Right);
                maxText.SetBinding(TextBlock.ForegroundProperty, new Binding("Foreground") { RelativeSource = RelativeSource.TemplatedParent });
                maxText.SetValue(TextBlock.FontSizeProperty, 12d);

                FrameworkElementFactory valText = new FrameworkElementFactory(typeof(TextBlock));
                Binding valBinding = new Binding(nameof(Value)) { RelativeSource = RelativeSource.TemplatedParent, StringFormat = "F0" };
                valText.SetBinding(TextBlock.TextProperty, valBinding);
                valText.SetValue(Grid.ColumnProperty, 1);
                valText.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                valText.SetBinding(TextBlock.ForegroundProperty, new Binding("Foreground") { RelativeSource = RelativeSource.TemplatedParent });
                valText.SetValue(TextBlock.FontSizeProperty, 12d);

                textGrid.AppendChild(minText);
                textGrid.AppendChild(maxText);
                textGrid.AppendChild(valText);

                canvas.AppendChild(textGrid);
            }

            canvas.AppendChild(trackBg);
            canvas.AppendChild(trackFill);
            canvas.AppendChild(thumb);

            template.VisualTree = canvas;
            style.Setters.Add(new Setter(TemplateProperty, template));
            return style;
        }
    }
}
