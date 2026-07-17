using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace StartUI4Controls
{
    public class UI4Switch : Control
    {
        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register(
                nameof(IsOn),
                typeof(bool),
                typeof(UI4Switch),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIsOnChanged));

        public bool IsOn
        {
            get => (bool)GetValue(IsOnProperty);
            set => SetValue(IsOnProperty, value);
        }

        public static readonly DependencyProperty GradientStartProperty =
            DependencyProperty.Register(
                nameof(GradientStart),
                typeof(Color),
                typeof(UI4Switch),
                new PropertyMetadata(Color.FromRgb(37, 99, 235), OnColorChanged));

        public Color GradientStart
        {
            get => (Color)GetValue(GradientStartProperty);
            set => SetValue(GradientStartProperty, value);
        }

        public static readonly DependencyProperty GradientEndProperty =
            DependencyProperty.Register(
                nameof(GradientEnd),
                typeof(Color),
                typeof(UI4Switch),
                new PropertyMetadata(Color.FromRgb(147, 51, 234), OnColorChanged));

        public Color GradientEnd
        {
            get => (Color)GetValue(GradientEndProperty);
            set => SetValue(GradientEndProperty, value);
        }

        public static readonly DependencyProperty OffBackgroundProperty =
            DependencyProperty.Register(
                nameof(OffBackground),
                typeof(Color),
                typeof(UI4Switch),
                new PropertyMetadata(Color.FromRgb(200, 200, 210), OnColorChanged));

        public Color OffBackground
        {
            get => (Color)GetValue(OffBackgroundProperty);
            set => SetValue(OffBackgroundProperty, value);
        }

        public static readonly DependencyProperty ThumbColorProperty =
            DependencyProperty.Register(
                nameof(ThumbColor),
                typeof(Color),
                typeof(UI4Switch),
                new PropertyMetadata(Colors.White, OnColorChanged));

        public Color ThumbColor
        {
            get => (Color)GetValue(ThumbColorProperty);
            set => SetValue(ThumbColorProperty, value);
        }

        public static readonly DependencyProperty SwitchWidthProperty =
            DependencyProperty.Register(
                nameof(SwitchWidth),
                typeof(double),
                typeof(UI4Switch),
                new PropertyMetadata(50.0, OnSizeChanged));

        public double SwitchWidth
        {
            get => (double)GetValue(SwitchWidthProperty);
            set => SetValue(SwitchWidthProperty, value);
        }

        public static readonly DependencyProperty SwitchHeightProperty =
            DependencyProperty.Register(
                nameof(SwitchHeight),
                typeof(double),
                typeof(UI4Switch),
                new PropertyMetadata(28.0, OnSizeChanged));

        public double SwitchHeight
        {
            get => (double)GetValue(SwitchHeightProperty);
            set => SetValue(SwitchHeightProperty, value);
        }

        public static readonly RoutedEvent ToggledEvent =
            EventManager.RegisterRoutedEvent(
                nameof(Toggled),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(UI4Switch));

        public event RoutedEventHandler Toggled
        {
            add { AddHandler(ToggledEvent, value); }
            remove { RemoveHandler(ToggledEvent, value); }
        }

        private Border _trackBorder;
        private Ellipse _thumb;
        private TranslateTransform _thumbTranslate;

        static UI4Switch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4Switch),
                new FrameworkPropertyMetadata(typeof(UI4Switch)));
        }

        public UI4Switch()
        {
            Cursor = Cursors.Hand;
            SizeChanged += OnSizeChanged;
            Loaded += OnLoaded;
            BuildVisualTree();
        }

        private void BuildVisualTree()
        {
            _trackBorder = new Border
            {
                CornerRadius = new CornerRadius(SwitchHeight / 2),
                Background = new SolidColorBrush(OffBackground),
                Width = SwitchWidth,
                Height = SwitchHeight,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            _thumbTranslate = new TranslateTransform();

            _thumb = new Ellipse
            {
                Width = SwitchHeight - 6,
                Height = SwitchHeight - 6,
                Fill = new SolidColorBrush(ThumbColor),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(3, 0, 0, 0),
                RenderTransform = _thumbTranslate
            };

            Grid grid = new Grid();
            grid.Children.Add(_trackBorder);
            grid.Children.Add(_thumb);

            AddVisualChild(grid);
            AddLogicalChild(grid);

            UpdateVisualState(false);
        }

        protected override int VisualChildrenCount => 1;

        protected override Visual GetVisualChild(int index)
        {
            if (index == 0 && _trackBorder != null)
                return (Visual)_trackBorder.Parent;
            return base.GetVisualChild(index);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return new Size(SwitchWidth, SwitchHeight);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            if (_trackBorder != null)
            {
                ((UIElement)_trackBorder.Parent).Arrange(new Rect(arrangeBounds));
            }
            return arrangeBounds;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateVisualState(false);
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_trackBorder != null)
            {
                _trackBorder.Width = SwitchWidth;
                _trackBorder.Height = SwitchHeight;
                _trackBorder.CornerRadius = new CornerRadius(SwitchHeight / 2);
            }
            if (_thumb != null)
            {
                _thumb.Width = SwitchHeight - 6;
                _thumb.Height = SwitchHeight - 6;
            }
            UpdateVisualState(false);
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (IsEnabled)
            {
                IsOn = !IsOn;
                e.Handled = true;
            }
        }

        private static void OnIsOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Switch sw)
            {
                sw.UpdateVisualState(true);
                sw.RaiseEvent(new RoutedEventArgs(ToggledEvent));
            }
        }

        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Switch sw)
                sw.UpdateBrushes();
        }

        private static void OnSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4Switch sw)
            {
                if (sw._trackBorder != null)
                {
                    sw._trackBorder.Width = sw.SwitchWidth;
                    sw._trackBorder.Height = sw.SwitchHeight;
                    sw._trackBorder.CornerRadius = new CornerRadius(sw.SwitchHeight / 2);
                }
                if (sw._thumb != null)
                {
                    sw._thumb.Width = sw.SwitchHeight - 6;
                    sw._thumb.Height = sw.SwitchHeight - 6;
                }
                sw.UpdateVisualState(false);
            }
        }

        private void UpdateBrushes()
        {
            if (_thumb != null)
                _thumb.Fill = new SolidColorBrush(ThumbColor);

            if (_trackBorder != null)
            {
                if (IsOn)
                {
                    var gradient = new LinearGradientBrush
                    {
                        StartPoint = new Point(0, 0.5),
                        EndPoint = new Point(1, 0.5)
                    };
                    gradient.GradientStops.Add(new GradientStop(GradientStart, 0));
                    gradient.GradientStops.Add(new GradientStop(GradientEnd, 1));
                    _trackBorder.Background = gradient;
                }
                else
                {
                    _trackBorder.Background = new SolidColorBrush(OffBackground);
                }
            }
        }

        private void UpdateVisualState(bool animate)
        {
            if (_thumbTranslate == null || _trackBorder == null) return;

            double thumbSize = SwitchHeight - 6;
            double travelDistance = SwitchWidth - thumbSize - 6;
            double targetX = IsOn ? travelDistance : 0;

            UpdateBrushes();

            if (animate && IsLoaded)
            {
                var anim = new DoubleAnimation
                {
                    To = targetX,
                    Duration = TimeSpan.FromMilliseconds(200),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
                };
                _thumbTranslate.BeginAnimation(TranslateTransform.XProperty, anim);
            }
            else
            {
                _thumbTranslate.BeginAnimation(TranslateTransform.XProperty, null);
                _thumbTranslate.X = targetX;
            }
        }
    }
}
