using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace StartUI4Controls
{
    public class UI4ProgressBar : Control
    {
        private Border _trackBorder;
        private Border _indicatorBorder;
        private TranslateTransform _indicatorTranslate;
        private RectangleGeometry _clipGeometry;
        private bool _isLoaded;

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(UI4ProgressBar),
                new PropertyMetadata(new CornerRadius(5), OnVisualPropertyChanged));
        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty GradientStartProperty =
            DependencyProperty.Register(
                nameof(GradientStart),
                typeof(Color),
                typeof(UI4ProgressBar),
                new PropertyMetadata(Color.FromRgb(0, 150, 230), OnVisualPropertyChanged));
        public Color GradientStart
        {
            get => (Color)GetValue(GradientStartProperty);
            set => SetValue(GradientStartProperty, value);
        }

        public static readonly DependencyProperty GradientEndProperty =
            DependencyProperty.Register(
                nameof(GradientEnd),
                typeof(Color),
                typeof(UI4ProgressBar),
                new PropertyMetadata(Color.FromRgb(0, 120, 212), OnVisualPropertyChanged));
        public Color GradientEnd
        {
            get => (Color)GetValue(GradientEndProperty);
            set => SetValue(GradientEndProperty, value);
        }

        public static readonly DependencyProperty TrackBackgroundProperty =
            DependencyProperty.Register(
                nameof(TrackBackground),
                typeof(Color),
                typeof(UI4ProgressBar),
                new PropertyMetadata(Color.FromArgb(10, 0, 0, 0), OnVisualPropertyChanged));
        public Color TrackBackground
        {
            get => (Color)GetValue(TrackBackgroundProperty);
            set => SetValue(TrackBackgroundProperty, value);
        }

        public bool IsIndeterminate
        {
            get => (bool)GetValue(IsIndeterminateProperty);
            set => SetValue(IsIndeterminateProperty, value);
        }
        public static readonly DependencyProperty IsIndeterminateProperty =
            DependencyProperty.Register(nameof(IsIndeterminate), typeof(bool), typeof(UI4ProgressBar),
                new FrameworkPropertyMetadata(false, OnIsIndeterminateChanged));

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register(nameof(Minimum), typeof(double), typeof(UI4ProgressBar),
                new FrameworkPropertyMetadata(0.0, OnRangeChanged));

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(nameof(Maximum), typeof(double), typeof(UI4ProgressBar),
                new FrameworkPropertyMetadata(100.0, OnRangeChanged));

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(UI4ProgressBar),
                new FrameworkPropertyMetadata(0.0, OnValueChanged));

        private static void OnVisualPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4ProgressBar bar)
            {
                bar.UpdateVisual();
            }
        }

        private static void OnIsIndeterminateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4ProgressBar bar)
            {
                bar.UpdateVisual();
            }
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4ProgressBar bar)
            {
                bar.UpdateIndicatorWidth();
            }
        }

        private static void OnRangeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4ProgressBar bar)
            {
                bar.UpdateIndicatorWidth();
            }
        }

        static UI4ProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4ProgressBar),
                new FrameworkPropertyMetadata(typeof(UI4ProgressBar)));

            BackgroundProperty.OverrideMetadata(typeof(UI4ProgressBar),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnVisualPropertyChanged));
        }

        public UI4ProgressBar()
        {
            this.Loaded += OnLoaded;
            this.SizeChanged += OnSizeChanged;
            BuildVisualTree();
        }

        private void BuildVisualTree()
        {
            _clipGeometry = new RectangleGeometry();

            _trackBorder = new Border
            {
                CornerRadius = this.CornerRadius,
                Background = new SolidColorBrush(TrackBackground),
                Clip = _clipGeometry
            };

            _indicatorTranslate = new TranslateTransform();

            _indicatorBorder = new Border
            {
                CornerRadius = this.CornerRadius,
                Background = GetIndicatorBrush(),
                HorizontalAlignment = HorizontalAlignment.Left,
                RenderTransform = _indicatorTranslate
            };

            _trackBorder.Child = _indicatorBorder;

            this.AddVisualChild(_trackBorder);
            this.AddLogicalChild(_trackBorder);

            this.BorderThickness = new Thickness(0);
            this.Height = 6;
            this.MinWidth = 100;
        }

        private void UpdateClipGeometry()
        {
            if (_clipGeometry == null || _trackBorder == null) return;

            double width = _trackBorder.ActualWidth;
            double height = _trackBorder.ActualHeight;
            if (width <= 0 || double.IsNaN(width)) width = this.ActualWidth;
            if (height <= 0 || double.IsNaN(height)) height = this.ActualHeight;
            if (width <= 0 || height <= 0) return;

            _clipGeometry.Rect = new Rect(0, 0, width, height);

            double radius = Math.Min(
                Math.Min(this.CornerRadius.TopLeft, this.CornerRadius.TopRight),
                Math.Min(this.CornerRadius.BottomLeft, this.CornerRadius.BottomRight));
            radius = Math.Min(radius, Math.Min(width / 2, height / 2));
            _clipGeometry.RadiusX = radius;
            _clipGeometry.RadiusY = radius;
        }

        protected override int VisualChildrenCount => 1;

        protected override Visual GetVisualChild(int index)
        {
            if (index == 0 && _trackBorder != null)
                return _trackBorder;
            return base.GetVisualChild(index);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if (_trackBorder != null)
            {
                _trackBorder.Measure(constraint);
                return _trackBorder.DesiredSize;
            }
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            if (_trackBorder != null)
            {
                _trackBorder.Arrange(new Rect(arrangeBounds));
            }
            return arrangeBounds;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _isLoaded = true;
            UpdateVisual();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateClipGeometry();
            UpdateIndicatorWidth();
            if (IsIndeterminate)
            {
                StartIndeterminateAnimation();
            }
        }

        private Brush GetIndicatorBrush()
        {
            if (ReadLocalValue(BackgroundProperty) != DependencyProperty.UnsetValue && Background != null)
            {
                return Background;
            }

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
            return gradientBrush;
        }

        private void UpdateVisual()
        {
            if (_trackBorder == null || _indicatorBorder == null) return;

            _trackBorder.CornerRadius = this.CornerRadius;
            _trackBorder.Background = new SolidColorBrush(TrackBackground);
            _indicatorBorder.CornerRadius = this.CornerRadius;
            _indicatorBorder.Background = GetIndicatorBrush();

            UpdateClipGeometry();

            if (IsIndeterminate)
            {
                StopIndeterminateAnimation();
                _indicatorBorder.Width = Math.Max(0, this.ActualWidth * 0.4);
                _indicatorTranslate.X = -_indicatorBorder.Width;
                StartIndeterminateAnimation();
            }
            else
            {
                StopIndeterminateAnimation();
                _indicatorTranslate.X = 0;
                UpdateIndicatorWidth();
            }
        }

        private void UpdateIndicatorWidth()
        {
            if (_indicatorBorder == null || !_isLoaded) return;
            if (IsIndeterminate) return;

            double trackWidth = this.ActualWidth;
            if (trackWidth <= 0 || double.IsNaN(trackWidth)) return;

            double range = Maximum - Minimum;
            double pct = range <= 0 ? 0 : Math.Max(0, Math.Min(1, (Value - Minimum) / range));
            _indicatorBorder.Width = trackWidth * pct;
        }

        private void StopIndeterminateAnimation()
        {
            if (_indicatorTranslate != null)
            {
                _indicatorTranslate.BeginAnimation(TranslateTransform.XProperty, null);
            }
        }

        private void StartIndeterminateAnimation()
        {
            if (_indicatorTranslate == null || _indicatorBorder == null) return;
            if (!_isLoaded) return;

            double trackWidth = this.ActualWidth;
            if (trackWidth <= 0 || double.IsNaN(trackWidth)) return;

            double indicatorWidth = trackWidth * 0.4;
            _indicatorBorder.Width = indicatorWidth;

            var anim = new DoubleAnimation
            {
                From = -indicatorWidth,
                To = trackWidth,
                Duration = TimeSpan.FromSeconds(1.0),
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = false
            };

            _indicatorTranslate.BeginAnimation(TranslateTransform.XProperty, anim);
        }
    }
}
