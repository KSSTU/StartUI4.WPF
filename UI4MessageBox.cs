using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace StartUI4Controls
{
    public class UI4MessageBox : Window
    {
        public UI4MessageBox(string title, string content)
        {
            Title = title;
            Width = 450;
            Height = 280;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.CanResize;
            AllowsTransparency = true;
            Background = null;

            Grid rootGrid = new Grid() { Margin=new Thickness(10)};

            RowDefinition row0 = new RowDefinition();
            row0.Height = GridLength.Auto;
            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition row2 = new RowDefinition();
            row2.Height = GridLength.Auto;
            rootGrid.RowDefinitions.Add(row0);
            rootGrid.RowDefinitions.Add(row1);
            rootGrid.RowDefinitions.Add(row2);

            TextBlock titleText = new TextBlock
            {
                Text = title,
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                TextWrapping=TextWrapping.Wrap,
                Margin = new Thickness(10)
            };
            Grid.SetRow(titleText, 0);
            rootGrid.Children.Add(titleText);

            UI4TextBlock contentText = new UI4TextBlock
            {
                Text = content,
                Margin = new Thickness(10, 10, 10, 0),
                TextWrapping = TextWrapping.Wrap,
                Background =null,
                VerticalContentAlign = VerticalAlignment.Top,
                BorderThickness=new Thickness(0),
                ShadowOpacity = 0,
            };
            Grid.SetRow(contentText, 1);
            rootGrid.Children.Add(contentText);

            Grid gridbottom = new Grid() {
                Background=new SolidColorBrush(Color.FromArgb(20,174,174,174)),
                Margin=new Thickness(-20) ,
                Height=90
            };
            StackPanel buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
            };
            Grid.SetRow(gridbottom, 2);
            rootGrid.Children.Add(gridbottom);
            gridbottom.Children.Add(buttonPanel);

            UI4Button okButton = new UI4Button
            {
                Content = "OK",
                Height = 30,
                Width = 100,
                Margin = new Thickness(0, 0, 10, 0)
            };
            okButton.Click += OkButton_Click;
            buttonPanel.Children.Add(okButton);

            UI4Button closeButton = new UI4Button
            {
                Content = "Cancel",
                Height = 30,
                Width = 100,
                Margin = new Thickness(20, 0, 30, 0)
            };
            closeButton.Click += CloseButton_Click;
            buttonPanel.Children.Add(closeButton);

            Border border = new Border() { Background=new SolidColorBrush(Colors.White), CornerRadius = new CornerRadius(10) };
            border.MouseLeftButtonDown += (ss, ee) =>
            {
                if (ee.ClickCount == 1) this.DragMove();
            };
            border.Child = rootGrid;

            Grid resizeGrid = new Grid();

            Border left = new Border { Width = ResizeThumbSize, HorizontalAlignment = HorizontalAlignment.Left, Cursor = Cursors.SizeWE, Background = Brushes.Transparent };
            Border right = new Border { Width = ResizeThumbSize, HorizontalAlignment = HorizontalAlignment.Right, Cursor = Cursors.SizeWE, Background = Brushes.Transparent };
            Border top = new Border { Height = ResizeThumbSize, VerticalAlignment = VerticalAlignment.Top, Cursor = Cursors.SizeNS, Background = Brushes.Transparent };
            Border bottom = new Border { Height = ResizeThumbSize, VerticalAlignment = VerticalAlignment.Bottom, Cursor = Cursors.SizeNS, Background = Brushes.Transparent };
            Border topLeft = new Border { Width = ResizeThumbSize, Height = ResizeThumbSize, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Cursor = Cursors.SizeNWSE, Background = Brushes.Transparent };
            Border topRight = new Border { Width = ResizeThumbSize, Height = ResizeThumbSize, HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Top, Cursor = Cursors.SizeNESW, Background = Brushes.Transparent };
            Border bottomLeft = new Border { Width = ResizeThumbSize, Height = ResizeThumbSize, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Bottom, Cursor = Cursors.SizeNESW, Background = Brushes.Transparent };
            Border bottomRight = new Border { Width = ResizeThumbSize, Height = ResizeThumbSize, HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Bottom, Cursor = Cursors.SizeNWSE, Background = Brushes.Transparent };

            resizeGrid.Children.Add(border);
            resizeGrid.Children.Add(left);
            resizeGrid.Children.Add(right);
            resizeGrid.Children.Add(top);
            resizeGrid.Children.Add(bottom);
            resizeGrid.Children.Add(topLeft);
            resizeGrid.Children.Add(topRight);
            resizeGrid.Children.Add(bottomLeft);
            resizeGrid.Children.Add(bottomRight);

            left.MouseLeftButtonDown += (s, e) => StartResize(e, 1);
            right.MouseLeftButtonDown += (s, e) => StartResize(e, 2);
            top.MouseLeftButtonDown += (s, e) => StartResize(e, 3);
            bottom.MouseLeftButtonDown += (s, e) => StartResize(e, 4);
            topLeft.MouseLeftButtonDown += (s, e) => StartResize(e, 5);
            topRight.MouseLeftButtonDown += (s, e) => StartResize(e, 6);
            bottomLeft.MouseLeftButtonDown += (s, e) => StartResize(e, 7);
            bottomRight.MouseLeftButtonDown += (s, e) => StartResize(e, 8);

            UI4Panel winUI4Style_Panel = new UI4Panel()
            {
                Margin = new Thickness(20),
                ShadowBlurRadius = 0,
                ShadowOpacity = 0,
                ShadowDepth = 0,
                HoverScale = 1
            };
            winUI4Style_Panel.Content = resizeGrid;
            this.Content = winUI4Style_Panel;

            this.Loaded += (s, e) =>
            {
                if (!(this.Content is UI4Panel rootPanel))
                    return;

                rootPanel.Opacity = 0;
                rootPanel.RenderTransform = new TransformGroup
                {
                    Children = new TransformCollection
        {
            new TranslateTransform(0, 90),
            new ScaleTransform(0.88, 0.88)
        }
                };
                rootPanel.RenderTransformOrigin = new Point(0.5, 0.5);
                rootPanel.Effect = new BlurEffect { Radius = 14 };

                DoubleAnimation fadeAnim = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(200))
                {
                    EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
                };
                rootPanel.BeginAnimation(UIElement.OpacityProperty, fadeAnim);

                TransformGroup transformGroup = rootPanel.RenderTransform as TransformGroup;
                TranslateTransform translate = transformGroup.Children[0] as TranslateTransform;
                ScaleTransform scale = transformGroup.Children[1] as ScaleTransform;

                DoubleAnimation slideAnim = new DoubleAnimation(90, 0, TimeSpan.FromMilliseconds(200))
                {
                    EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.35 }
                };
                translate.BeginAnimation(TranslateTransform.YProperty, slideAnim);

                DoubleAnimation scaleAnim = new DoubleAnimation(0.88, 1, TimeSpan.FromMilliseconds(200))
                {
                    EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.5 }
                };
                scale.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
                scale.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

                DoubleAnimation blurAnim = new DoubleAnimation(14, 0, TimeSpan.FromMilliseconds(200))
                {
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                rootPanel.Effect.BeginAnimation(BlurEffect.RadiusProperty, blurAnim);
            };
        }
        private bool _isClosingAnimating;
        private void CloseAnimation(bool dialogResult)
        {
            if (_isClosingAnimating) return;
            if (!(this.Content is UI4Panel rootPanel))
                return;

            if (rootPanel.RenderTransform is not TransformGroup tg || tg.Children.Count < 2)
                return;
            if (tg.Children[0] is not TranslateTransform trans || tg.Children[1] is not ScaleTransform scale)
                return;

            BlurEffect blurEffect = rootPanel.Effect as BlurEffect;
            if (blurEffect == null)
            {
                blurEffect = new BlurEffect { Radius = 0 };
                rootPanel.Effect = blurEffect;
            }

            _isClosingAnimating = true;
            TimeSpan duration = TimeSpan.FromMilliseconds(200);

            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, duration)
            {
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn },
                FillBehavior = FillBehavior.HoldEnd
            };

            DoubleAnimation slideDown = new DoubleAnimation(0, 90, duration)
            {
                EasingFunction = new BackEase() { EasingMode = EasingMode.EaseIn, Amplitude = 0.35 },
                FillBehavior = FillBehavior.HoldEnd
            };

            DoubleAnimation shrinkX = new DoubleAnimation(1, 0.88, duration)
            {
                EasingFunction = new BackEase() { EasingMode = EasingMode.EaseIn, Amplitude = 0.5 },
                FillBehavior = FillBehavior.HoldEnd
            };
            DoubleAnimation shrinkY = new DoubleAnimation(1, 0.88, duration)
            {
                EasingFunction = new BackEase() { EasingMode = EasingMode.EaseIn, Amplitude = 0.5 },
                FillBehavior = FillBehavior.HoldEnd
            };

            DoubleAnimation blurOut = new DoubleAnimation(0, 14, duration)
            {
                EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseIn },
                FillBehavior = FillBehavior.HoldEnd
            };

            int completeCount = 0;
            int totalAnim = 5;

            void OnAnyAnimationCompleted(object s, EventArgs e)
            {
                completeCount++;
                if (completeCount >= totalAnim)
                {
                    Dispatcher.Invoke(() =>
                    {
                        DialogResult = dialogResult;
                        this.Close();
                    });
                }
            }

            fadeOut.Completed += OnAnyAnimationCompleted;
            slideDown.Completed += OnAnyAnimationCompleted;
            shrinkX.Completed += OnAnyAnimationCompleted;
            shrinkY.Completed += OnAnyAnimationCompleted;
            blurOut.Completed += OnAnyAnimationCompleted;

            rootPanel.BeginAnimation(UIElement.OpacityProperty, fadeOut);
            trans.BeginAnimation(TranslateTransform.YProperty, slideDown);
            scale.BeginAnimation(ScaleTransform.ScaleXProperty, shrinkX);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, shrinkY);
            blurEffect.BeginAnimation(BlurEffect.RadiusProperty, blurOut);
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            CloseAnimation(true);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseAnimation(false);
        }

        public static bool? Show(string content,string title="Notice", double width = 480, double height = 280)
        {
            UI4MessageBox box = new UI4MessageBox(title, content);
            box.Width = width;
            box.Height = height;
            return box.ShowDialog();
        }
        private const double ResizeThumbSize = 8;
        private Point _resizeStartPoint;
        private double _resizeStartWidth, _resizeStartHeight;
        private int _resizeDirection = 0;
        private void StartResize(MouseButtonEventArgs e, int direction)
        {
            _resizeDirection = direction;
            _resizeStartPoint = PointToScreen(e.GetPosition(this));
            _resizeStartWidth = Width;
            _resizeStartHeight = Height;
            Mouse.Capture(this);
            MouseMove += DoResize;
            MouseLeftButtonUp += EndResize;
        }

        private void DoResize(object sender, MouseEventArgs e)
        {
            if (_resizeDirection == 0 || e.LeftButton != MouseButtonState.Pressed) return;
            Point current = PointToScreen(e.GetPosition(this));
            double dx = current.X - _resizeStartPoint.X;
            double dy = current.Y - _resizeStartPoint.Y;
            double minW = 200, minH = 150;

            switch (_resizeDirection)
            {
                case 2: Width = Math.Max(minW, _resizeStartWidth + dx); break;
                case 1: Width = Math.Max(minW, _resizeStartWidth - dx); break;
                case 4: Height = Math.Max(minH, _resizeStartHeight + dy); break;
                case 3: Height = Math.Max(minH, _resizeStartHeight - dy); break;
                case 6: Width = Math.Max(minW, _resizeStartWidth + dx); Height = Math.Max(minH, _resizeStartHeight - dy); break;
                case 5: Width = Math.Max(minW, _resizeStartWidth - dx); Height = Math.Max(minH, _resizeStartHeight - dy); break;
                case 8: Width = Math.Max(minW, _resizeStartWidth + dx); Height = Math.Max(minH, _resizeStartHeight + dy); break;
                case 7: Width = Math.Max(minW, _resizeStartWidth - dx); Height = Math.Max(minH, _resizeStartHeight + dy); break;
            }
        }

        private void EndResize(object sender, MouseButtonEventArgs e)
        {
            _resizeDirection = 0;
            Mouse.Capture(null);
            MouseMove -= DoResize;
            MouseLeftButtonUp -= EndResize;
        }
    }
}
