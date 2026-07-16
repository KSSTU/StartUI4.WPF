using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Xml;

namespace StartUI4Controls
{
    public class UI4ListView : ListBox
    {
        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register(
                nameof(ItemWidth),
                typeof(double),
                typeof(UI4ListView),
                new PropertyMetadata(double.NaN, OnStyleUpdate));

        public double ItemWidth
        {
            get => (double)GetValue(ItemWidthProperty);
            set => SetValue(ItemWidthProperty, value);
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register(
                nameof(ItemHeight),
                typeof(double),
                typeof(UI4ListView),
                new PropertyMetadata(double.NaN, OnStyleUpdate));

        public double ItemHeight
        {
            get => (double)GetValue(ItemHeightProperty);
            set => SetValue(ItemHeightProperty, value);
        }

        public static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.Register(
                nameof(ItemCornerRadius),
                typeof(CornerRadius),
                typeof(UI4ListView),
                new PropertyMetadata(new CornerRadius(12), OnStyleUpdate));

        public CornerRadius ItemCornerRadius
        {
            get => (CornerRadius)GetValue(ItemCornerRadiusProperty);
            set => SetValue(ItemCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ItemBackgroundProperty =
            DependencyProperty.Register(
                nameof(ItemBackground),
                typeof(Brush),
                typeof(UI4ListView),
                new PropertyMetadata(new SolidColorBrush(Color.FromArgb(10, 255, 255, 255)), OnStyleUpdate));

        public Brush ItemBackground
        {
            get => (Brush)GetValue(ItemBackgroundProperty);
            set => SetValue(ItemBackgroundProperty, value);
        }

        public static readonly DependencyProperty ItemBorderBrushProperty =
            DependencyProperty.Register(
                nameof(ItemBorderBrush),
                typeof(Color),
                typeof(UI4ListView),
                new PropertyMetadata(Color.FromArgb(60, 120, 140, 200), OnStyleUpdate));

        public Color ItemBorderBrush
        {
            get => (Color)GetValue(ItemBorderBrushProperty);
            set => SetValue(ItemBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemHoverBorderBrushProperty =
            DependencyProperty.Register(
                nameof(ItemHoverBorderBrush),
                typeof(Color),
                typeof(UI4ListView),
                new PropertyMetadata(Color.FromRgb(60, 220, 255), OnStyleUpdate));

        public Color ItemHoverBorderBrush
        {
            get => (Color)GetValue(ItemHoverBorderBrushProperty);
            set => SetValue(ItemHoverBorderBrushProperty, value);
        }

        public static readonly DependencyProperty ItemBorderThicknessProperty =
            DependencyProperty.Register(
                nameof(ItemBorderThickness),
                typeof(Thickness),
                typeof(UI4ListView),
                new PropertyMetadata(new Thickness(1), OnStyleUpdate));

        public Thickness ItemBorderThickness
        {
            get => (Thickness)GetValue(ItemBorderThicknessProperty);
            set => SetValue(ItemBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.Register(
                nameof(ItemPadding),
                typeof(Thickness),
                typeof(UI4ListView),
                new PropertyMetadata(new Thickness(0), OnStyleUpdate));

        public Thickness ItemPadding
        {
            get => (Thickness)GetValue(ItemPaddingProperty);
            set => SetValue(ItemPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemMarginProperty =
            DependencyProperty.Register(
                nameof(ItemMargin),
                typeof(Thickness),
                typeof(UI4ListView),
                new PropertyMetadata(new Thickness(10), OnStyleUpdate));

        public Thickness ItemMargin
        {
            get => (Thickness)GetValue(ItemMarginProperty);
            set => SetValue(ItemMarginProperty, value);
        }

        public static readonly DependencyProperty HoverAnimationDurationProperty =
            DependencyProperty.Register(
                nameof(HoverAnimationDuration),
                typeof(Duration),
                typeof(UI4ListView),
                new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(200)), OnStyleUpdate));

        public Duration HoverAnimationDuration
        {
            get => (Duration)GetValue(HoverAnimationDurationProperty);
            set => SetValue(HoverAnimationDurationProperty, value);
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register(
                nameof(ShadowColor),
                typeof(Color),
                typeof(UI4ListView),
                new PropertyMetadata(Color.FromArgb(35, 0, 0, 0), OnStyleUpdate));
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        public static readonly DependencyProperty ShadowBlurRadiusProperty =
            DependencyProperty.Register(
                nameof(ShadowBlurRadius),
                typeof(double),
                typeof(UI4ListView),
                new PropertyMetadata(12.0, OnStyleUpdate));
        public double ShadowBlurRadius
        {
            get => (double)GetValue(ShadowBlurRadiusProperty);
            set => SetValue(ShadowBlurRadiusProperty, value);
        }

        public static readonly DependencyProperty ShadowDepthProperty =
            DependencyProperty.Register(
                nameof(ShadowDepth),
                typeof(double),
                typeof(UI4ListView),
                new PropertyMetadata(0.0, OnStyleUpdate));
        public double ShadowDepth
        {
            get => (double)GetValue(ShadowDepthProperty);
            set => SetValue(ShadowDepthProperty, value);
        }

        public static readonly DependencyProperty ShadowOpacityProperty =
            DependencyProperty.Register(
                nameof(ShadowOpacity),
                typeof(double),
                typeof(UI4ListView),
                new PropertyMetadata(0.35, OnStyleUpdate));
        public double ShadowOpacity
        {
            get => (double)GetValue(ShadowOpacityProperty);
            set => SetValue(ShadowOpacityProperty, value);
        }

        public static readonly DependencyProperty HoverScaleProperty =
            DependencyProperty.Register(
                nameof(HoverScale),
                typeof(double),
                typeof(UI4ListView),
                new PropertyMetadata(1.03, OnStyleUpdate));
        public double HoverScale
        {
            get => (double)GetValue(HoverScaleProperty);
            set => SetValue(HoverScaleProperty, value);
        }

        private static void OnStyleUpdate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4ListView list)
                list.Style = list.BuildTechCardStyle();
        }
        public static Style _scrollViewerStyle;
        static UI4ListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4ListView),
                new FrameworkPropertyMetadata(typeof(UI4ListView)));
            _scrollViewerStyle = CreateScrollViewerStyleFromXaml();
        }

        public UI4ListView()
        {
            FontSize = 15;
            Style = BuildTechCardStyle();
        }

        private Style BuildTechCardStyle()
        {
            Style listStyle = new Style(typeof(ListBox));
            listStyle.Setters.Add(new Setter(BackgroundProperty, Brushes.Transparent));
            ControlTemplate template = new ControlTemplate(typeof(ListBox));

            FrameworkElementFactory scrollHost = new FrameworkElementFactory(typeof(ScrollViewer));
            scrollHost.Name = "PART_ContentHost";

            if (_scrollViewerStyle != null)
            {
                scrollHost.SetValue(FrameworkElement.StyleProperty, _scrollViewerStyle);
            }

            scrollHost.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            scrollHost.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            scrollHost.SetValue(ScrollViewer.BackgroundProperty, Brushes.Transparent);
            scrollHost.SetValue(ScrollViewer.PaddingProperty, new Thickness(4, 4, 4, 4));
            scrollHost.SetValue(FrameworkElement.FocusableProperty, false);
            scrollHost.SetValue(Control.BorderThicknessProperty, new Thickness(0));

            FrameworkElementFactory itemsPresenter = new FrameworkElementFactory(typeof(ItemsPresenter));
            scrollHost.AppendChild(itemsPresenter);

            template.VisualTree = scrollHost;
            listStyle.Setters.Add(new Setter(Control.TemplateProperty, template));

            Style itemStyle = new Style(typeof(ListBoxItem));
            itemStyle.Setters.Add(new Setter(ListBoxItem.BackgroundProperty, Brushes.Transparent));
            itemStyle.Setters.Add(new Setter(ListBoxItem.BorderThicknessProperty, new Thickness(0)));
            itemStyle.Setters.Add(new Setter(ListBoxItem.PaddingProperty, new Thickness(0)));
            itemStyle.Setters.Add(new Setter(ListBoxItem.MarginProperty, new Binding(nameof(ItemMargin)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListView), 1) }));
            itemStyle.Setters.Add(new Setter(ListBoxItem.HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch));
            itemStyle.Setters.Add(new Setter(ListBoxItem.VerticalContentAlignmentProperty, VerticalAlignment.Stretch));

            if (!double.IsNaN(ItemWidth))
                itemStyle.Setters.Add(new Setter(FrameworkElement.WidthProperty, ItemWidth));
            if (!double.IsNaN(ItemHeight))
                itemStyle.Setters.Add(new Setter(FrameworkElement.HeightProperty, ItemHeight));

            ControlTemplate itemTemplate = new ControlTemplate(typeof(ListBoxItem));

            FrameworkElementFactory itemBorder = new FrameworkElementFactory(typeof(Border));
            itemBorder.Name = "PART_ItemBorder";
            itemBorder.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(ItemCornerRadius)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListView), 1) });
            itemBorder.SetBinding(Border.BackgroundProperty, new Binding(nameof(ItemBackground)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListView), 1) });
            itemBorder.SetValue(Border.BorderBrushProperty, new SolidColorBrush(ItemBorderBrush));
            itemBorder.SetBinding(Border.BorderThicknessProperty, new Binding(nameof(ItemBorderThickness)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListView), 1) });
            itemBorder.SetBinding(Border.PaddingProperty, new Binding(nameof(ItemPadding)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListView), 1) });
            itemBorder.SetValue(UIElement.RenderTransformOriginProperty, new Point(0.5, 0.5));

            ScaleTransform scaleTransform = new ScaleTransform(1, 1);
            itemBorder.SetValue(UIElement.RenderTransformProperty, scaleTransform);

            DropShadowEffect cardShadow = new DropShadowEffect
            {
                Color = ShadowColor,
                BlurRadius = ShadowBlurRadius,
                ShadowDepth = ShadowDepth,
                Opacity = ShadowOpacity
            };
            itemBorder.SetValue(UIElement.EffectProperty, cardShadow);

            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
            contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Stretch);
            itemBorder.AppendChild(contentPresenter);

            itemTemplate.VisualTree = itemBorder;

            ColorAnimation hoverAnim = new ColorAnimation
            {
                To = ItemHoverBorderBrush,
                Duration = HoverAnimationDuration
            };

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

            Storyboard hoverStoryboard = new Storyboard();
            hoverStoryboard.Children.Add(hoverAnim);
            hoverStoryboard.Children.Add(scaleXHoverAnim);
            hoverStoryboard.Children.Add(scaleYHoverAnim);
            Storyboard.SetTargetName(hoverAnim, "PART_ItemBorder");
            Storyboard.SetTargetProperty(hoverAnim, new PropertyPath("(Border.BorderBrush).(SolidColorBrush.Color)"));
            Storyboard.SetTargetName(scaleXHoverAnim, "PART_ItemBorder");
            Storyboard.SetTargetProperty(scaleXHoverAnim, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            Storyboard.SetTargetName(scaleYHoverAnim, "PART_ItemBorder");
            Storyboard.SetTargetProperty(scaleYHoverAnim, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            ColorAnimation leaveAnim = new ColorAnimation
            {
                To = ItemBorderBrush,
                Duration = HoverAnimationDuration
            };

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

            Storyboard leaveStoryboard = new Storyboard();
            leaveStoryboard.Children.Add(leaveAnim);
            leaveStoryboard.Children.Add(scaleXLeaveAnim);
            leaveStoryboard.Children.Add(scaleYLeaveAnim);
            Storyboard.SetTargetName(leaveAnim, "PART_ItemBorder");
            Storyboard.SetTargetProperty(leaveAnim, new PropertyPath("(Border.BorderBrush).(SolidColorBrush.Color)"));
            Storyboard.SetTargetName(scaleXLeaveAnim, "PART_ItemBorder");
            Storyboard.SetTargetProperty(scaleXLeaveAnim, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            Storyboard.SetTargetName(scaleYLeaveAnim, "PART_ItemBorder");
            Storyboard.SetTargetProperty(scaleYLeaveAnim, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            EventTrigger mouseEnterTrigger = new EventTrigger(UIElement.MouseEnterEvent);
            mouseEnterTrigger.Actions.Add(new BeginStoryboard { Storyboard = hoverStoryboard });
            itemTemplate.Triggers.Add(mouseEnterTrigger);

            EventTrigger mouseLeaveTrigger = new EventTrigger(UIElement.MouseLeaveEvent);
            mouseLeaveTrigger.Actions.Add(new BeginStoryboard { Storyboard = leaveStoryboard });
            itemTemplate.Triggers.Add(mouseLeaveTrigger);

            itemStyle.Setters.Add(new Setter(Control.TemplateProperty, itemTemplate));
            listStyle.Setters.Add(new Setter(ListBox.ItemContainerStyleProperty, itemStyle));

            return listStyle;
        }
        public static Style CreateScrollViewerStyleFromXaml()
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
                            <Rectangle Fill='#50000000' RadiusX='3' RadiusY='3'/>
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
            <Setter Property='Margin' Value='0,1,1,6'/>
            <Setter Property='Width' Value='5'/>
            <Setter Property='MinWidth' Value='5'/>
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
                    <Setter Property='Margin' Value='1,0,6,1'/>
                    <Setter Property='Height' Value='5'/>
                    <Setter Property='MinHeight' Value='5'/>
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
                using (StringReader sr = new StringReader(xaml))
                using (XmlReader xr = XmlReader.Create(sr))
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
