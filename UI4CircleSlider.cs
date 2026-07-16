using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace StartUI4Controls
{
    public class UI4CircleSlider : ContentControl
    {
        private Grid _container;
        private bool _isDragging;
        private bool _isAnimating;
        private const double RingSafePadding = 6.0;

        static UI4CircleSlider()
        {
            ForegroundProperty.OverrideMetadata(typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(
                    SystemColors.ControlTextBrush,
                    FrameworkPropertyMetadataOptions.Inherits,
                    OnForegroundChanged));
        }

        public UI4CircleSlider()
        {
            _container = new Grid();
            this.Content = _container;
            this.Width = 120;
            this.Height = 120;
            this.Background = Brushes.Transparent;
            this.SizeChanged += OnSizeChanged;
            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
        }

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(0.0, OnValueChanged, CoerceValue));

        private static object CoerceValue(DependencyObject d, object baseValue)
        {
            var slider = (UI4CircleSlider)d;
            double val = (double)baseValue;
            return Math.Max(slider.Minimum, Math.Min(slider.Maximum, val));
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slider = (UI4CircleSlider)d;
            slider.Dispatcher.BeginInvoke(new Action(() => slider.UpdateSlider()));
        }

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(double), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(0.0, OnRangePropertyChanged));

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(nameof(Maximum), typeof(double), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(100.0, OnRangePropertyChanged));

        public double SmallChange
        {
            get => (double)GetValue(SmallChangeProperty);
            set => SetValue(SmallChangeProperty, value);
        }

        public static readonly DependencyProperty SmallChangeProperty =
            DependencyProperty.Register(nameof(SmallChange), typeof(double), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(1.0));

        public double RingThickness
        {
            get => (double)GetValue(RingThicknessProperty);
            set => SetValue(RingThicknessProperty, value);
        }

        public static readonly DependencyProperty RingThicknessProperty =
            DependencyProperty.Register(nameof(RingThickness), typeof(double), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(8.0, OnRingPropertyChanged));

        public Brush RingForeground
        {
            get => (Brush)GetValue(RingForegroundProperty);
            set => SetValue(RingForegroundProperty, value);
        }

        public static readonly DependencyProperty RingForegroundProperty =
            DependencyProperty.Register(nameof(RingForeground), typeof(Brush), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(0, 120, 212)), OnRingPropertyChanged));

        public Brush RingBackground
        {
            get => (Brush)GetValue(RingBackgroundProperty);
            set => SetValue(RingBackgroundProperty, value);
        }

        public static readonly DependencyProperty RingBackgroundProperty =
            DependencyProperty.Register(nameof(RingBackground), typeof(Brush), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromArgb(10, 0, 0, 0)), OnRingPropertyChanged));

        public bool ShowValueText
        {
            get => (bool)GetValue(ShowValueTextProperty);
            set => SetValue(ShowValueTextProperty, value);
        }

        public static readonly DependencyProperty ShowValueTextProperty =
            DependencyProperty.Register(nameof(ShowValueText), typeof(bool), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(false, OnShowValueTextChanged));

        public double ValueFontSize
        {
            get => (double)GetValue(ValueFontSizeProperty);
            set => SetValue(ValueFontSizeProperty, value);
        }

        public static readonly DependencyProperty ValueFontSizeProperty =
            DependencyProperty.Register(nameof(ValueFontSize), typeof(double), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(30.0, OnValueFontSizeChanged));

        public double AnimationDuration
        {
            get => (double)GetValue(AnimationDurationProperty);
            set => SetValue(AnimationDurationProperty, value);
        }

        public static readonly DependencyProperty AnimationDurationProperty =
            DependencyProperty.Register(nameof(AnimationDuration), typeof(double), typeof(UI4CircleSlider),
                new FrameworkPropertyMetadata(0.5));

        private static void OnRingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slider = (UI4CircleSlider)d;
            slider.Dispatcher.BeginInvoke(new Action(() => slider.UpdateSlider()));
        }

        private static void OnRangePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slider = (UI4CircleSlider)d;
            slider.CoerceValue(ValueProperty);
            slider.Dispatcher.BeginInvoke(new Action(() => slider.UpdateSlider()));
        }

        private static void OnShowValueTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slider = (UI4CircleSlider)d;
            slider.Dispatcher.BeginInvoke(new Action(() => slider.UpdateSlider()));
        }

        private static void OnValueFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slider = (UI4CircleSlider)d;
            slider.Dispatcher.BeginInvoke(new Action(() => slider.UpdateSlider()));
        }

        private static void OnForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var slider = (UI4CircleSlider)d;
            if (slider.ReadLocalValue(ForegroundProperty) != DependencyProperty.UnsetValue &&
                slider.ReadLocalValue(RingForegroundProperty) == DependencyProperty.UnsetValue)
            {
                slider.RingForeground = e.NewValue as Brush;
            }
            slider.Dispatcher.BeginInvoke(new Action(() => slider.UpdateSlider()));
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            if (AnimationDuration > 0 && Value > Minimum)
            {
                _isAnimating = true;
                double startValue = Minimum;
                double endValue = Value;

                var anim = new DoubleAnimation(startValue, endValue, TimeSpan.FromSeconds(AnimationDuration))
                {
                    FillBehavior = FillBehavior.HoldEnd,
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };

                anim.Completed += (s, _) =>
                {
                    _isAnimating = false;

                    this.BeginAnimation(ValueProperty, null);
                    SetCurrentValue(ValueProperty, endValue);
                };

                this.BeginAnimation(ValueProperty, anim);
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (_isAnimating)
            {
                this.BeginAnimation(ValueProperty, null);
                _isAnimating = false;
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {

            if (_isAnimating)
            {
                _isAnimating = false;
                double current = Value;
                this.BeginAnimation(ValueProperty, null);
                Value = current;
            }

            base.OnMouseLeftButtonDown(e);
            _isDragging = true;
            CaptureMouse();
            UpdateValueFromPoint(e.GetPosition(this));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDragging)
            {
                UpdateValueFromPoint(e.GetPosition(this));
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (_isDragging)
            {
                _isDragging = false;
                ReleaseMouseCapture();
                Value = SnapToStep(Value);
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (_isDragging)
            {
                _isDragging = false;
                ReleaseMouseCapture();
                Value = SnapToStep(Value);
            }
        }

        private void UpdateValueFromPoint(Point point)
        {
            Value = PointToValue(point);
        }

        private double PointToValue(Point point)
        {
            double centerX = ActualWidth / 2;
            double centerY = ActualHeight / 2;
            double dx = point.X - centerX;
            double dy = point.Y - centerY;

            double angleRad = Math.Atan2(dy, dx);
            double angleDeg = angleRad * 180.0 / Math.PI;
            double normalizedAngle = angleDeg + 90.0;
            if (normalizedAngle < 0) normalizedAngle += 360.0;

            double range = Maximum - Minimum;
            if (range <= 0) return Minimum;
            double pct = normalizedAngle / 360.0;
            return Minimum + pct * range;
        }

        private double ValueToAngleDeg(double value)
        {
            double range = Maximum - Minimum;
            if (range <= 0) return -90.0;
            double pct = (value - Minimum) / range;
            pct = Math.Max(0.0, Math.Min(1.0, pct));
            return -90.0 + pct * 360.0;
        }

        private double SnapToStep(double value)
        {
            if (SmallChange <= 0) return value;
            double snapped = Math.Round((value - Minimum) / SmallChange) * SmallChange + Minimum;
            return Math.Max(Minimum, Math.Min(Maximum, snapped));
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateSlider();
        }

        private void UpdateSlider()
        {
            if (_container == null) return;

            double width = this.ActualWidth;
            double height = this.ActualHeight;
            if (width <= 0 || double.IsNaN(width)) width = this.Width;
            if (height <= 0 || double.IsNaN(height)) height = this.Height;
            if (width <= 0 || double.IsNaN(width)) width = 120;
            if (height <= 0 || double.IsNaN(height)) height = 120;

            _container.Children.Clear();

            double diameter = Math.Min(width, height);
            double thickness = Math.Min(RingThickness, diameter / 2);
            double usableDiameter = diameter - RingSafePadding * 2;
            usableDiameter = Math.Max(usableDiameter, thickness + 2);

            double arcRadius = (usableDiameter - thickness) / 2 + thickness / 2;
            double centerX = width / 2;
            double centerY = height / 2;

            _container.Children.Add(CreateArc(centerX, centerY, arcRadius, -90, 360, RingBackground, thickness));

            double currentAngle = ValueToAngleDeg(Value);
            double sweepAngle = currentAngle - (-90);
            if (sweepAngle > 0)
            {
                _container.Children.Add(CreateArc(centerX, centerY, arcRadius, -90, sweepAngle, RingForeground, thickness));
            }

            double thumbSize = thickness * 2;
            double rad = currentAngle * Math.PI / 180.0;
            double thumbX = centerX + arcRadius * Math.Cos(rad);
            double thumbY = centerY + arcRadius * Math.Sin(rad);

            var thumb = new Ellipse
            {
                Width = thumbSize,
                Height = thumbSize,
                Fill = RingForeground,
                Stroke = Brushes.White,
                StrokeThickness = 1.5,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                RenderTransform = new TranslateTransform(thumbX - thumbSize / 2, thumbY - thumbSize / 2)
            };
            Panel.SetZIndex(thumb, 10);
            _container.Children.Add(thumb);

            if (ShowValueText)
            {
                var valueText = new TextBlock
                {
                    Text = Value.ToString("0"),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = this.Foreground,
                    FontSize = this.ValueFontSize,
                    FontWeight = FontWeights.SemiBold,
                    IsHitTestVisible = false
                };
                Panel.SetZIndex(valueText, 20);
                _container.Children.Add(valueText);
            }
        }

        private static Point CalcPoint(double cx, double cy, double r, double angleDeg)
        {
            double rad = angleDeg * Math.PI / 180.0;
            return new Point(cx + r * Math.Cos(rad), cy + r * Math.Sin(rad));
        }

        private static Path CreateArc(double cx, double cy, double r, double startAngle, double sweepAngle, Brush brush, double thickness)
        {
            double displayAngle = sweepAngle >= 360 ? 359.999 : sweepAngle;
            var figure = new PathFigure { StartPoint = CalcPoint(cx, cy, r, startAngle) };
            var arc = new ArcSegment
            {
                Point = CalcPoint(cx, cy, r, startAngle + displayAngle),
                Size = new Size(r, r),
                IsLargeArc = displayAngle > 180,
                SweepDirection = SweepDirection.Clockwise
            };
            figure.Segments.Add(arc);

            var geo = new PathGeometry();
            geo.Figures.Add(figure);

            return new Path
            {
                Data = geo,
                Stroke = brush,
                StrokeThickness = thickness,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
        }
    }
}
