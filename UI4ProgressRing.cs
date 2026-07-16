using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace StartUI4Controls
{
    public class UI4ProgressRing : ContentControl
    {
        private Grid _container;
        private RotateTransform _rotateTransform;
        private bool _isLoaded;
        private bool _isStartupAnimationRunning;
        private const double RingSafePadding = 5.0;

        static UI4ProgressRing()
        {
            ForegroundProperty.OverrideMetadata(typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(
                    SystemColors.ControlTextBrush,
                    FrameworkPropertyMetadataOptions.Inherits,
                    OnForegroundChanged));
        }

        public UI4ProgressRing()
        {
            _container = new Grid();
            this.Content = _container;
            this.Width = 80;
            this.Height = 80;
            this.Loaded += OnLoaded;
            this.SizeChanged += OnSizeChanged;
        }

        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register(nameof(IsActive), typeof(bool), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(true, OnIsActiveChanged));
        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ring = (UI4ProgressRing)d;
            ring.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (!ring.IsActive)
                {

                    ring.BeginAnimation(AnimatedValueProperty, null);
                    ring._isAnimating = false;
                    ring.UpdateRing();
                }
                else
                {

                    if (!ring.IsIndeterminate)
                    {
                        ring.StartTransitionAnimation(ring.Value);
                    }
                    else
                    {
                        ring.UpdateRing();
                    }
                }
            }));
        }

        public bool IsIndeterminate
        {
            get => (bool)GetValue(IsIndeterminateProperty);
            set => SetValue(IsIndeterminateProperty, value);
        }
        public static readonly DependencyProperty IsIndeterminateProperty =
            DependencyProperty.Register(nameof(IsIndeterminate), typeof(bool), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(true, OnIsIndeterminateChanged));
        private static void OnIsIndeterminateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ring = (UI4ProgressRing)d;
            ring.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (ring.IsIndeterminate)
                {

                    ring.BeginAnimation(AnimatedValueProperty, null);
                    ring._isAnimating = false;
                    ring.UpdateRing();
                }
                else
                {

                    ring.StartTransitionAnimation(ring.Value);
                }
            }));
        }

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(double), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(0.0, OnRangePropertyChanged));

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(nameof(Maximum), typeof(double), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(100.0, OnRangePropertyChanged));

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(0.0, OnRangePropertyChanged));

        public Brush RingBackground
        {
            get => (Brush)GetValue(RingBackgroundProperty);
            set => SetValue(RingBackgroundProperty, value);
        }
        public static readonly DependencyProperty RingBackgroundProperty =
            DependencyProperty.Register(nameof(RingBackground), typeof(Brush), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromArgb(10, 0, 0, 0)), OnRingPropertyChanged));

        public Brush RingForeground
        {
            get => (Brush)GetValue(RingForegroundProperty);
            set => SetValue(RingForegroundProperty, value);
        }
        public static readonly DependencyProperty RingForegroundProperty =
            DependencyProperty.Register(nameof(RingForeground), typeof(Brush), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(0, 120, 212)), OnRingPropertyChanged));

        public double RingThickness
        {
            get => (double)GetValue(RingThicknessProperty);
            set => SetValue(RingThicknessProperty, value);
        }
        public static readonly DependencyProperty RingThicknessProperty =
            DependencyProperty.Register(nameof(RingThickness), typeof(double), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(6.0, OnRingPropertyChanged));

        public bool ShowValueText
        {
            get => (bool)GetValue(ShowValueTextProperty);
            set => SetValue(ShowValueTextProperty, value);
        }
        public static readonly DependencyProperty ShowValueTextProperty =
            DependencyProperty.Register(nameof(ShowValueText), typeof(bool), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(true, OnShowValueTextChanged));
        private static void OnShowValueTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ring = (UI4ProgressRing)d;
            ring.Dispatcher.BeginInvoke(new Action(() => ring.UpdateRing()));
        }

        public double ValueFontSize
        {
            get => (double)GetValue(ValueFontSizeProperty);
            set => SetValue(ValueFontSizeProperty, value);
        }
        public static readonly DependencyProperty ValueFontSizeProperty =
            DependencyProperty.Register(nameof(ValueFontSize), typeof(double), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(30.0, OnValueFontSizeChanged));
        private static void OnValueFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ring = (UI4ProgressRing)d;
            ring.Dispatcher.BeginInvoke(new Action(() => ring.UpdateRing()));
        }

        public double AnimatedValue
        {
            get => (double)GetValue(AnimatedValueProperty);
            set => SetValue(AnimatedValueProperty, value);
        }
        public static readonly DependencyProperty AnimatedValueProperty =
            DependencyProperty.Register(nameof(AnimatedValue), typeof(double), typeof(UI4ProgressRing),
                new FrameworkPropertyMetadata(0.0, OnAnimatedValueChanged));
        private static void OnAnimatedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ring = (UI4ProgressRing)d;
            ring.Dispatcher.BeginInvoke(new Action(() => ring.UpdateRing()));
        }

        public double StartupAnimationDuration
        {
            get => (double)GetValue(StartupAnimationDurationProperty);
            set => SetValue(StartupAnimationDurationProperty, value);
        }
        public static readonly DependencyProperty StartupAnimationDurationProperty =
            DependencyProperty.Register(nameof(StartupAnimationDuration), typeof(double), typeof(UI4ProgressRing),
                new PropertyMetadata(0.5));

        public bool EnableStartupAnimation
        {
            get => (bool)GetValue(EnableStartupAnimationProperty);
            set => SetValue(EnableStartupAnimationProperty, value);
        }
        public static readonly DependencyProperty EnableStartupAnimationProperty =
            DependencyProperty.Register(nameof(EnableStartupAnimation), typeof(bool), typeof(UI4ProgressRing),
                new PropertyMetadata(true));

        private static void OnRingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ring = (UI4ProgressRing)d;
            ring.Dispatcher.BeginInvoke(new Action(() => ring.UpdateRing()));
        }
        private bool _isAnimating;
        private static void OnRangePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ring = (UI4ProgressRing)d;
            ring.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (ring.IsIndeterminate || !ring.IsActive)
                {

                    ring.UpdateRing();
                    return;
                }

                if (ring.EnableStartupAnimation)
                {
                    ring.StartTransitionAnimation(ring.Value);
                }
                else
                {
                    ring.AnimatedValue = ring.Value;
                    ring.UpdateRing();
                }
            }));
        }

        private static void OnForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ring = (UI4ProgressRing)d;
            if (ring.ReadLocalValue(ForegroundProperty) != DependencyProperty.UnsetValue &&
                ring.ReadLocalValue(RingForegroundProperty) == DependencyProperty.UnsetValue)
            {
                ring.RingForeground = e.NewValue as Brush;
            }
            ring.Dispatcher.BeginInvoke(new Action(() => ring.UpdateRing()));
        }
        private void StartTransitionAnimation(double targetValue)
        {
            if (!IsActive || IsIndeterminate) return;

            this.BeginAnimation(AnimatedValueProperty, null);
            _isAnimating = false;

            double current = AnimatedValue;

            if (Math.Abs(current - targetValue) < 0.001)
            {
                AnimatedValue = targetValue;
                UpdateRing();
                return;
            }

            var anim = new DoubleAnimation(current, targetValue,
                TimeSpan.FromSeconds(StartupAnimationDuration))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            anim.Completed += (s, e) =>
            {
                _isAnimating = false;

                AnimatedValue = targetValue;
                UpdateRing();
            };

            _isAnimating = true;
            this.BeginAnimation(AnimatedValueProperty, anim);
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _isLoaded = true;
            if (IsActive && !IsIndeterminate)
            {
                AnimatedValue = Value;
            }
            UpdateRing();

            if (EnableStartupAnimation && IsActive && !IsIndeterminate)
            {
                double targetValue = Value;
                if (targetValue > Minimum)
                {

                    AnimatedValue = 0;

                    var anim = new DoubleAnimation(0, targetValue, TimeSpan.FromSeconds(StartupAnimationDuration))
                    {
                        EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                    };
                    anim.Completed += (s, args) =>
                    {
                        _isStartupAnimationRunning = false;

                        if (!IsIndeterminate && IsActive)
                        {
                            AnimatedValue = Value;
                        }
                    };

                    _isStartupAnimationRunning = true;
                    this.BeginAnimation(AnimatedValueProperty, anim);
                }
            }
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRing();
        }

        private void StopIndeterminateAnimation()
        {
            if (_rotateTransform != null)
            {
                _rotateTransform.BeginAnimation(RotateTransform.AngleProperty, null);
            }
        }

        private void UpdateRing()
        {
            if (_container == null) return;
            StopIndeterminateAnimation();

            double width = this.ActualWidth;
            double height = this.ActualHeight;
            if (width <= 0 || double.IsNaN(width)) width = this.Width;
            if (height <= 0 || double.IsNaN(height)) height = this.Height;
            if (width <= 0 || double.IsNaN(width)) width = 80;
            if (height <= 0 || double.IsNaN(height)) height = 80;

            _container.Children.Clear();

            if (!IsActive)
            {
                _container.Opacity = 0.0;
                return;
            }

            _container.Opacity = 1.0;

            double diameter = Math.Min(width, height);
            double thickness = Math.Min(RingThickness, diameter / 2);
            double usableDiameter = diameter - RingSafePadding * 2;
            usableDiameter = Math.Max(usableDiameter, thickness + 2);
            double radius = (usableDiameter - thickness) / 2;
            double centerX = width / 2;
            double centerY = height / 2;
            double arcRadius = radius + thickness / 2;

            if (IsIndeterminate)
            {
                BuildIndeterminateRing(centerX, centerY, arcRadius, thickness);
            }
            else
            {
                BuildDeterminateRing(centerX, centerY, arcRadius, thickness);
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

        private void BuildDeterminateRing(double cx, double cy, double r, double thickness)
        {
            _container.Children.Add(CreateArc(cx, cy, r, -90, 360, RingBackground, thickness));

            double min = Minimum, max = Maximum;
            double animatedVal = AnimatedValue;
            double range = max - min;
            double pct = range <= 0 ? 0 : Math.Max(0, Math.Min(1, (animatedVal - min) / range));
            if (pct > 0)
            {
                _container.Children.Add(CreateArc(cx, cy, r, -90, pct * 360, RingForeground, thickness));
            }

            if (ShowValueText)
            {
                var valueText = new TextBlock
                {
                    Text = ((int)animatedVal).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = this.Foreground,
                    FontSize = this.ValueFontSize,
                    FontWeight = FontWeights.SemiBold,
                    IsHitTestVisible = false
                };
                Panel.SetZIndex(valueText, 10);
                _container.Children.Add(valueText);
            }
        }

        private void BuildIndeterminateRing(double cx, double cy, double r, double thickness)
        {
            _container.Children.Add(CreateArc(cx, cy, r, -90, 360, RingBackground, thickness));
            _rotateTransform = new RotateTransform { CenterX = cx, CenterY = cy };
            var fgPath = CreateArc(cx, cy, r, -45, 120, RingForeground, thickness);
            fgPath.RenderTransform = _rotateTransform;
            _container.Children.Add(fgPath);

            var anim = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromSeconds(0.5),
                RepeatBehavior = RepeatBehavior.Forever
            };
            _rotateTransform.BeginAnimation(RotateTransform.AngleProperty, anim);
        }
    }
}
