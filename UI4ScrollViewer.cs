using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Markup;
using System.Xml;

namespace StartUI4Controls
{

    public class UI4ScrollViewer : ScrollViewer
    {
        private static Style _scrollViewerStyle;
        private double _targetVerticalOffset;
        private double _targetHorizontalOffset;
        private bool _isAnimatingVertical;
        private bool _isAnimatingHorizontal;
        private const double AnimationDuration = 100;

        public static readonly DependencyProperty IsSmoothScrollEnabledProperty =
            DependencyProperty.Register(
                nameof(IsSmoothScrollEnabled),
                typeof(bool),
                typeof(UI4ScrollViewer),
                new PropertyMetadata(true));

        public bool IsSmoothScrollEnabled
        {
            get => (bool)GetValue(IsSmoothScrollEnabledProperty);
            set => SetValue(IsSmoothScrollEnabledProperty, value);
        }

        static UI4ScrollViewer()
        {
            _scrollViewerStyle = CreateScrollViewerStyleFromXaml();
        }

        public UI4ScrollViewer()
        {
            if (_scrollViewerStyle != null)
            {
                Style = _scrollViewerStyle;
            }
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _targetVerticalOffset = VerticalOffset;
            _targetHorizontalOffset = HorizontalOffset;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            if (!IsSmoothScrollEnabled)
            {
                base.OnMouseWheel(e);
                return;
            }

            e.Handled = true;

            double scrollAmount = e.Delta;
            double lineHeight = 16;
            double totalDelta = scrollAmount / 120.0 * 3 * lineHeight;

            _targetVerticalOffset = Math.Max(0, Math.Min(ScrollableHeight, _targetVerticalOffset - totalDelta));

            AnimateVerticalOffset(VerticalOffset, _targetVerticalOffset);
        }

        private void AnimateVerticalOffset(double from, double to)
        {
            if (Math.Abs(from - to) < 0.1) return;

            double startTime = Environment.TickCount;
            double duration = AnimationDuration;
            double startVal = from;
            double endVal = to;

            EventHandler renderHandler = null;
            renderHandler = (s, e) =>
            {
                double elapsed = Environment.TickCount - startTime;
                if (elapsed >= duration)
                {
                    CompositionTarget.Rendering -= renderHandler;
                    ScrollToVerticalOffset(endVal);
                    _isAnimatingVertical = false;
                    return;
                }

                double t = elapsed / duration;
                double eased = EaseOutCubic(t);
                double currentVal = startVal + (endVal - startVal) * eased;
                ScrollToVerticalOffset(currentVal);
            };

            CompositionTarget.Rendering += renderHandler;
            _isAnimatingVertical = true;
        }

        private static double EaseOutCubic(double t)
        {
            return 1 - Math.Pow(1 - t, 3);
        }

        public void SmoothScrollToVerticalOffset(double offset)
        {
            offset = Math.Max(0, Math.Min(ScrollableHeight, offset));
            _targetVerticalOffset = offset;
            AnimateVerticalOffset(VerticalOffset, offset);
        }

        public void SmoothScrollToHorizontalOffset(double offset)
        {
            offset = Math.Max(0, Math.Min(ScrollableWidth, offset));
            _targetHorizontalOffset = offset;
            AnimateHorizontalOffset(HorizontalOffset, offset);
        }

        private void AnimateHorizontalOffset(double from, double to)
        {
            if (Math.Abs(from - to) < 0.1) return;

            double startTime = Environment.TickCount;
            double duration = AnimationDuration;
            double startVal = from;
            double endVal = to;

            EventHandler renderHandler = null;
            renderHandler = (s, e) =>
            {
                double elapsed = Environment.TickCount - startTime;
                if (elapsed >= duration)
                {
                    CompositionTarget.Rendering -= renderHandler;
                    ScrollToHorizontalOffset(endVal);
                    _isAnimatingHorizontal = false;
                    return;
                }

                double t = elapsed / duration;
                double eased = EaseOutCubic(t);
                double currentVal = startVal + (endVal - startVal) * eased;
                ScrollToHorizontalOffset(currentVal);
            };

            CompositionTarget.Rendering += renderHandler;
            _isAnimatingHorizontal = true;
        }

        private static Style CreateScrollViewerStyleFromXaml()
        {
            string xaml = @"
<Style xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
       xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
       TargetType='{x:Type ScrollViewer}'>
    <Style.Resources>
        <Style x:Key='ScrollBarThumb' TargetType='{x:Type Thumb}'>
            <Setter Property='OverridesDefaultStyle' Value='true'/>
            <Setter Property='IsTabStop' Value='false'/>
            <Setter Property='Template'>
                <Setter.Value>
                    <ControlTemplate TargetType='{x:Type Thumb}'>
                        <Grid>
                            <Rectangle Fill='#50000000' RadiusX='5' RadiusY='5'/>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key='HorizontalScrollBarPageButton' TargetType='{x:Type RepeatButton}'>
            <Setter Property='OverridesDefaultStyle' Value='true'/>
            <Setter Property='Background' Value='Transparent'/>
            <Setter Property='Focusable' Value='false'/>
            <Setter Property='IsTabStop' Value='false'/>
            <Setter Property='Opacity' Value='0'/>
            <Setter Property='Template'>
                <Setter.Value>
                    <ControlTemplate TargetType='{x:Type RepeatButton}'>
                        <Rectangle Fill='{TemplateBinding Background}'
                                   Width='{TemplateBinding Width}'
                                   Height='{TemplateBinding Height}'/>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key='VerticalScrollBarPageButton' TargetType='{x:Type RepeatButton}'>
            <Setter Property='OverridesDefaultStyle' Value='true'/>
            <Setter Property='Background' Value='Transparent'/>
            <Setter Property='Focusable' Value='false'/>
            <Setter Property='IsTabStop' Value='false'/>
            <Setter Property='Opacity' Value='0'/>
            <Setter Property='Template'>
                <Setter.Value>
                    <ControlTemplate TargetType='{x:Type RepeatButton}'>
                        <Rectangle Fill='{TemplateBinding Background}'
                                   Width='{TemplateBinding Width}'
                                   Height='{TemplateBinding Height}'/>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
        <Style x:Key='for_scrollbar' TargetType='{x:Type ScrollBar}'>
            <Setter Property='Stylus.IsPressAndHoldEnabled' Value='false'/>
            <Setter Property='Stylus.IsFlicksEnabled' Value='false'/>
            <Setter Property='Background' Value='Transparent'/>
            <Setter Property='Margin' Value='0,1,2,6'/>
            <Setter Property='Width' Value='6'/>
            <Setter Property='MinWidth' Value='6'/>
            <Setter Property='Opacity' Value='0'/>
            <Setter Property='Template'>
                <Setter.Value>
                    <ControlTemplate TargetType='{x:Type ScrollBar}'>
                        <Grid x:Name='Bg' SnapsToDevicePixels='true'>
                            <Track x:Name='PART_Track' IsEnabled='{TemplateBinding IsMouseOver}' IsDirectionReversed='true'>
                                <Track.DecreaseRepeatButton>
                                    <RepeatButton Style='{StaticResource VerticalScrollBarPageButton}'
                                                  Command='{x:Static ScrollBar.PageUpCommand}'/>
                                </Track.DecreaseRepeatButton>
                                <Track.IncreaseRepeatButton>
                                    <RepeatButton Style='{StaticResource VerticalScrollBarPageButton}'
                                                  Command='{x:Static ScrollBar.PageDownCommand}'/>
                                </Track.IncreaseRepeatButton>
                                <Track.Thumb>
                                    <Thumb Style='{StaticResource ScrollBarThumb}'/>
                                </Track.Thumb>
                            </Track>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property='IsMouseOver' Value='True'>
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetProperty='Opacity' To='1' Duration='0:0:0.2'/>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetProperty='Opacity' To='0' Duration='0:0:0.5'/>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.ExitActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property='Orientation' Value='Horizontal'>
                    <Setter Property='Background' Value='Transparent'/>
                    <Setter Property='Margin' Value='2,0,6,2'/>
                    <Setter Property='Height' Value='6'/>
                    <Setter Property='MinHeight' Value='6'/>
                    <Setter Property='Width' Value='Auto'/>
                    <Setter Property='Opacity' Value='0'/>
                    <Setter Property='Template'>
                        <Setter.Value>
                            <ControlTemplate TargetType='{x:Type ScrollBar}'>
                                <Grid x:Name='Bg' SnapsToDevicePixels='true'>
                                    <Track x:Name='PART_Track' IsEnabled='{TemplateBinding IsMouseOver}'>
                                        <Track.DecreaseRepeatButton>
                                            <RepeatButton Style='{StaticResource HorizontalScrollBarPageButton}'
                                                          Command='{x:Static ScrollBar.PageLeftCommand}'/>
                                        </Track.DecreaseRepeatButton>
                                        <Track.IncreaseRepeatButton>
                                            <RepeatButton Style='{StaticResource HorizontalScrollBarPageButton}'
                                                          Command='{x:Static ScrollBar.PageRightCommand}'/>
                                        </Track.IncreaseRepeatButton>
                                        <Track.Thumb>
                                            <Thumb Style='{StaticResource ScrollBarThumb}'/>
                                        </Track.Thumb>
                                    </Track>
                                </Grid>
                                <ControlTemplate.Triggers>
                                    <Trigger Property='IsMouseOver' Value='True'>
                                        <Trigger.EnterActions>
                                            <BeginStoryboard>
                                                <Storyboard>
                                                    <DoubleAnimation Storyboard.TargetProperty='Opacity' To='1' Duration='0:0:0.2'/>
                                                </Storyboard>
                                            </BeginStoryboard>
                                        </Trigger.EnterActions>
                                        <Trigger.ExitActions>
                                            <BeginStoryboard>
                                                <Storyboard>
                                                    <DoubleAnimation Storyboard.TargetProperty='Opacity' To='0' Duration='0:0:0.5'/>
                                                </Storyboard>
                                            </BeginStoryboard>
                                        </Trigger.ExitActions>
                                    </Trigger>
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Style.Resources>
    <Setter Property='BorderBrush' Value='LightGray'/>
    <Setter Property='BorderThickness' Value='0'/>
    <Setter Property='HorizontalContentAlignment' Value='Left'/>
    <Setter Property='HorizontalScrollBarVisibility' Value='Auto'/>
    <Setter Property='VerticalContentAlignment' Value='Top'/>
    <Setter Property='VerticalScrollBarVisibility' Value='Auto'/>
    <Setter Property='Template'>
        <Setter.Value>
            <ControlTemplate TargetType='{x:Type ScrollViewer}'>
                <Border BorderBrush='{TemplateBinding BorderBrush}'
                        BorderThickness='{TemplateBinding BorderThickness}'
                        SnapsToDevicePixels='True'>
                    <Grid Background='{TemplateBinding Background}'>
                        <ScrollContentPresenter
                            Cursor='{TemplateBinding Cursor}'
                            Margin='{TemplateBinding Padding}'
                            ContentTemplate='{TemplateBinding ContentTemplate}'/>
                        <ScrollBar x:Name='PART_VerticalScrollBar'
                                   HorizontalAlignment='Right'
                                   Maximum='{TemplateBinding ScrollableHeight}'
                                   Orientation='Vertical'
                                   Style='{StaticResource for_scrollbar}'
                                   ViewportSize='{TemplateBinding ViewportHeight}'
                                   Value='{TemplateBinding VerticalOffset}'
                                   Visibility='{TemplateBinding ComputedVerticalScrollBarVisibility}'/>
                        <ScrollBar x:Name='PART_HorizontalScrollBar'
                                   Maximum='{TemplateBinding ScrollableWidth}'
                                   Orientation='Horizontal'
                                   Style='{StaticResource for_scrollbar}'
                                   VerticalAlignment='Bottom'
                                   Value='{TemplateBinding HorizontalOffset}'
                                   ViewportSize='{TemplateBinding ViewportWidth}'
                                   Visibility='{TemplateBinding ComputedHorizontalScrollBarVisibility}'/>
                    </Grid>
                </Border>
                <ControlTemplate.Triggers>
                    <EventTrigger RoutedEvent='ScrollChanged'>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName='PART_VerticalScrollBar' Storyboard.TargetProperty='Opacity' To='1' Duration='0:0:0.2'/>
                                <DoubleAnimation Storyboard.TargetName='PART_VerticalScrollBar' Storyboard.TargetProperty='Opacity' To='0' Duration='0:0:0.5' BeginTime='0:0:1.5'/>
                                <DoubleAnimation Storyboard.TargetName='PART_HorizontalScrollBar' Storyboard.TargetProperty='Opacity' To='1' Duration='0:0:0.2'/>
                                <DoubleAnimation Storyboard.TargetName='PART_HorizontalScrollBar' Storyboard.TargetProperty='Opacity' To='0' Duration='0:0:0.5' BeginTime='0:0:1.5'/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>";

            try
            {
                using (var sr = new StringReader(xaml))
                using (var xr = XmlReader.Create(sr))
                {
                    return (Style)XamlReader.Load(xr);
                }
            }
            catch
            {

                return null;
            }
        }
    }
}
