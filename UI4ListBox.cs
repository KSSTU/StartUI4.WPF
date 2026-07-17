using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace StartUI4Controls
{

    public enum ListStyleType
    {
        None,
        Disc,
        Number
    }

    public class IndexPlusOneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
                return (index + 1).ToString();
            return "1";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class UI4ListBox : ListBox
    {

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(
                nameof(CornerRadius),
                typeof(CornerRadius),
                typeof(UI4ListBox),
                new PropertyMetadata(new CornerRadius(8), OnStyleRefresh));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty BorderNormalColorProperty =
            DependencyProperty.Register(
                nameof(BorderNormalColor),
                typeof(Color),
                typeof(UI4ListBox),
                new PropertyMetadata(Color.FromRgb (37, 99, 235), OnStyleRefresh));

        public Color BorderNormalColor
        {
            get => (Color)GetValue(BorderNormalColorProperty);
            set => SetValue(BorderNormalColorProperty, value);
        }

        public static readonly DependencyProperty PanelBackgroundProperty =
            DependencyProperty.Register(
                nameof(PanelBackground),
                typeof(Brush),
                typeof(UI4ListBox),
                new PropertyMetadata(Brushes.White, OnStyleRefresh));

        public Brush PanelBackground
        {
            get => (Brush)GetValue(PanelBackgroundProperty);
            set => SetValue(PanelBackgroundProperty, value);
        }

        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register(
                nameof(TextColor),
                typeof(Color),
                typeof(UI4ListBox),
                new PropertyMetadata(Color.FromArgb(255, 0, 0, 0), OnStyleRefresh));

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly DependencyProperty ItemPaddingProperty =
            DependencyProperty.Register(
                nameof(ItemPadding),
                typeof(Thickness),
                typeof(UI4ListBox),
                new PropertyMetadata(new Thickness(12, 8, 12, 8), OnStyleRefresh));

        public Thickness ItemPadding
        {
            get => (Thickness)GetValue(ItemPaddingProperty);
            set => SetValue(ItemPaddingProperty, value);
        }

        public static readonly DependencyProperty ItemCornerRadiusProperty =
            DependencyProperty.Register(
                nameof(ItemCornerRadius),
                typeof(CornerRadius),
                typeof(UI4ListBox),
                new PropertyMetadata(new CornerRadius(8), OnStyleRefresh));

        public CornerRadius ItemCornerRadius
        {
            get => (CornerRadius)GetValue(ItemCornerRadiusProperty);
            set => SetValue(ItemCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty HoverBackgroundProperty =
            DependencyProperty.Register(
                nameof(HoverBackground),
                typeof(Color),
                typeof(UI4ListBox),
                new PropertyMetadata(Color.FromArgb(10, 245, 255, 255), OnStyleRefresh));
        public Color HoverBackground
        {
            get => (Color)GetValue(HoverBackgroundProperty);
            set => SetValue(HoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty HoverForegroundProperty =
            DependencyProperty.Register(
                nameof(HoverForeground),
                typeof(Color),
                typeof(UI4ListBox),
                new PropertyMetadata(Color.FromArgb(220, 0, 0, 0), OnStyleRefresh));
        public Color HoverForeground
        {
            get => (Color)GetValue(HoverForegroundProperty);
            set => SetValue(HoverForegroundProperty, value);
        }

        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register(
                nameof(PressedBackground),
                typeof(Color),
                typeof(UI4ListBox),
                new PropertyMetadata(Color.FromRgb (37, 99, 235), OnStyleRefresh));
        public Color PressedBackground
        {
            get => (Color)GetValue(PressedBackgroundProperty);
            set => SetValue(PressedBackgroundProperty, value);
        }

        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.Register(
                nameof(PressedForeground),
                typeof(Color),
                typeof(UI4ListBox),
                new PropertyMetadata(Color.FromRgb(255, 255, 255), OnStyleRefresh));
        public Color PressedForeground
        {
            get => (Color)GetValue(PressedForegroundProperty);
            set => SetValue(PressedForegroundProperty, value);
        }

        public static readonly DependencyProperty ListStyleTypeProperty =
            DependencyProperty.Register(
                nameof(ListStyleType),
                typeof(ListStyleType),
                typeof(UI4ListBox),
                new PropertyMetadata(ListStyleType.None, OnStyleRefresh));
        public ListStyleType ListStyleType
        {
            get => (ListStyleType)GetValue(ListStyleTypeProperty);
            set => SetValue(ListStyleTypeProperty, value);
        }

        public static readonly DependencyProperty NumberCircleBackgroundProperty =
            DependencyProperty.Register(
                nameof(NumberCircleBackground),
                typeof(Brush),
                typeof(UI4ListBox),
                new PropertyMetadata(CreateDefaultCircleBrush(), OnStyleRefresh));
        public Brush NumberCircleBackground
        {
            get => (Brush)GetValue(NumberCircleBackgroundProperty);
            set => SetValue(NumberCircleBackgroundProperty, value);
        }

        private static Brush CreateDefaultCircleBrush()
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb (37, 99, 235));
            brush.Freeze();
            return brush;
        }

        public static Style _scrollViewerStyle;

        private static void OnStyleRefresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4ListBox list)
                list.Style = list.BuildListStyle();
        }

        static UI4ListBox()
        {

            BorderThicknessProperty.OverrideMetadata(typeof(UI4ListBox),
                new FrameworkPropertyMetadata(new Thickness(0), OnBorderThicknessChanged));

            DefaultStyleKeyProperty.OverrideMetadata(typeof(UI4ListBox),
                new FrameworkPropertyMetadata(typeof(UI4ListBox)));

            _scrollViewerStyle = CreateScrollViewerStyleFromXaml();
        }

        private static void OnBorderThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4ListBox list)
                list.Style = list.BuildListStyle();
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

        public UI4ListBox()
        {
            FontSize = 15d;
            Style = BuildListStyle();
        }

        private Style BuildListStyle()
        {
            Style style = new Style(typeof(ListBox));
            style.Setters.Add(new Setter(ForegroundProperty, new SolidColorBrush(TextColor)));
            style.Setters.Add(new Setter(BorderBrushProperty, new SolidColorBrush(BorderNormalColor)));
            style.Setters.Add(new Setter(BackgroundProperty, PanelBackground));
            style.Setters.Add(new Setter(ItemsControl.AlternationCountProperty, int.MaxValue));

            ControlTemplate template = new ControlTemplate(typeof(ListBox));
            FrameworkElementFactory rootBorder = new FrameworkElementFactory(typeof(Border));
            rootBorder.Name = "PART_MainBorder";
            rootBorder.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(CornerRadius)) { RelativeSource = RelativeSource.TemplatedParent });
            rootBorder.SetBinding(Border.BackgroundProperty, new Binding(nameof(Background)) { RelativeSource = RelativeSource.TemplatedParent });
            rootBorder.SetBinding(Border.BorderBrushProperty, new Binding(nameof(BorderBrush)) { RelativeSource = RelativeSource.TemplatedParent });
            rootBorder.SetBinding(Border.BorderThicknessProperty, new Binding(nameof(BorderThickness)) { RelativeSource = RelativeSource.TemplatedParent });

            FrameworkElementFactory scrollViewer = new FrameworkElementFactory(typeof(ScrollViewer));
            if (_scrollViewerStyle != null)
                scrollViewer.SetValue(FrameworkElement.StyleProperty, _scrollViewerStyle);
            scrollViewer.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            scrollViewer.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
            scrollViewer.SetValue(ScrollViewer.PaddingProperty, new Thickness(4, 4, 4, 4));
            scrollViewer.SetValue(FrameworkElement.FocusableProperty, false);
            scrollViewer.SetValue(Control.BorderThicknessProperty, new Thickness(0));

            FrameworkElementFactory itemsPresenter = new FrameworkElementFactory(typeof(ItemsPresenter));
            scrollViewer.AppendChild(itemsPresenter);
            rootBorder.AppendChild(scrollViewer);
            template.VisualTree = rootBorder;
            style.Setters.Add(new Setter(Control.TemplateProperty, template));

            Style itemStyle = new Style(typeof(ListBoxItem));
            itemStyle.Setters.Add(new Setter(ContentControl.HorizontalContentAlignmentProperty, HorizontalAlignment.Left));
            itemStyle.Setters.Add(new Setter(ContentControl.VerticalContentAlignmentProperty, VerticalAlignment.Center));

            itemStyle.Setters.Add(new Setter(Control.ForegroundProperty,
                new Binding(nameof(Foreground)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListBox), 1) }));

            Trigger hoverTrigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            hoverTrigger.Setters.Add(new Setter(Control.ForegroundProperty, new SolidColorBrush(HoverForeground)));
            itemStyle.Triggers.Add(hoverTrigger);

            Trigger selectedTrigger = new Trigger
            {
                Property = ListBoxItem.IsSelectedProperty,
                Value = true
            };
            selectedTrigger.Setters.Add(new Setter(Control.ForegroundProperty, new SolidColorBrush(PressedForeground)));
            itemStyle.Triggers.Add(selectedTrigger);

            itemStyle.Setters.Add(new Setter(ListBoxItem.TagProperty, string.Empty));

            itemStyle.Setters.Add(new EventSetter(UIElement.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler((s, e) =>
            {
                if (s is ListBoxItem item && !item.IsSelected)
                {
                    item.Tag = "Pressed";
                    item.Foreground = new SolidColorBrush(PressedForeground);
                }
            })));
            itemStyle.Setters.Add(new EventSetter(UIElement.PreviewMouseLeftButtonUpEvent, new MouseButtonEventHandler((s, e) =>
            {
                if (s is ListBoxItem item && item.Tag is string tag && tag == "Pressed")
                {
                    item.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        item.ClearValue(ListBoxItem.TagProperty);
                        item.ClearValue(Control.ForegroundProperty);
                    }), System.Windows.Threading.DispatcherPriority.Input);
                }
            })));
            itemStyle.Setters.Add(new EventSetter(UIElement.MouseLeaveEvent, new MouseEventHandler((s, e) =>
            {
                if (s is ListBoxItem item && item.Tag is string tag && tag == "Pressed")
                {
                    item.ClearValue(ListBoxItem.TagProperty);
                    item.ClearValue(Control.ForegroundProperty);
                }
            })));

            ControlTemplate itemTemplate = new ControlTemplate(typeof(ListBoxItem));
            FrameworkElementFactory itemBorder = new FrameworkElementFactory(typeof(Border));
            itemBorder.Name = "PART_ItemBorder";
            itemBorder.SetBinding(Border.CornerRadiusProperty, new Binding(nameof(ItemCornerRadius))
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListBox), 1)
            });
            itemBorder.SetValue(Border.BackgroundProperty, Brushes.Transparent);
            itemBorder.SetValue(Border.MarginProperty, new Thickness(2, 2, 2, 2));
            itemBorder.SetBinding(Border.PaddingProperty, new Binding(nameof(ItemPadding))
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListBox), 1)
            });

            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.Name = "PART_ItemContent";
            contentPresenter.SetBinding(ContentPresenter.ContentProperty, new Binding("Content") { RelativeSource = RelativeSource.TemplatedParent });
            contentPresenter.SetBinding(ContentPresenter.ContentTemplateProperty, new Binding("ContentTemplate") { RelativeSource = RelativeSource.TemplatedParent });

            contentPresenter.SetBinding(TextElement.ForegroundProperty,
                new Binding("Foreground") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ListBoxItem), 1) });
            contentPresenter.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            contentPresenter.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);

            FrameworkElementFactory contentPanel = new FrameworkElementFactory(typeof(StackPanel));
            contentPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            contentPanel.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);

            if (ListStyleType == ListStyleType.Disc)
            {
                FrameworkElementFactory dot = new FrameworkElementFactory(typeof(Ellipse));
                dot.SetValue(Shape.FillProperty, new SolidColorBrush(TextColor));
                dot.SetValue(FrameworkElement.WidthProperty, 6.0);
                dot.SetValue(FrameworkElement.HeightProperty, 6.0);
                dot.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 0, 10, 0));
                dot.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
                contentPanel.AppendChild(dot);
            }
            else if (ListStyleType == ListStyleType.Number)
            {
                FrameworkElementFactory numberCircle = new FrameworkElementFactory(typeof(Border));
                numberCircle.SetValue(Border.WidthProperty, 26.0);
                numberCircle.SetValue(Border.HeightProperty, 26.0);
                numberCircle.SetValue(Border.CornerRadiusProperty, new CornerRadius(16.0));
                numberCircle.SetValue(Border.VerticalAlignmentProperty, VerticalAlignment.Center);
                numberCircle.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 0, 12, 0));
                numberCircle.SetBinding(Border.BackgroundProperty,
                    new Binding(nameof(NumberCircleBackground)) { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(UI4ListBox), 1) });
                FrameworkElementFactory numberText = new FrameworkElementFactory(typeof(TextBlock));
                numberText.SetValue(TextBlock.ForegroundProperty, Brushes.White);
                numberText.SetValue(TextBlock.FontWeightProperty, FontWeights.Medium);
                numberText.SetValue(TextBlock.FontSizeProperty, 13.0);
                numberText.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                numberText.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
                numberText.SetValue(TextBlock.TextAlignmentProperty, TextAlignment.Center);
                numberText.SetBinding(TextBlock.TextProperty,
                    new Binding("(ItemsControl.AlternationIndex)") { RelativeSource = RelativeSource.TemplatedParent, Converter = new IndexPlusOneConverter() });
                numberCircle.AppendChild(numberText);
                contentPanel.AppendChild(numberCircle);
            }

            contentPanel.AppendChild(contentPresenter);
            itemBorder.AppendChild(contentPanel);
            itemTemplate.VisualTree = itemBorder;

            Trigger hoverBgTrigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            hoverBgTrigger.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(HoverBackground)) { TargetName = "PART_ItemBorder" });
            itemTemplate.Triggers.Add(hoverBgTrigger);

            Trigger selectedBgTrigger = new Trigger
            {
                Property = ListBoxItem.IsSelectedProperty,
                Value = true
            };
            selectedBgTrigger.Setters.Add(new Setter(Border.BackgroundProperty, new SolidColorBrush(PressedBackground)) { TargetName = "PART_ItemBorder" });
            itemTemplate.Triggers.Add(selectedBgTrigger);

            itemStyle.Setters.Add(new Setter(Control.TemplateProperty, itemTemplate));

            style.Setters.Add(new Setter(ListBox.ItemContainerStyleProperty, itemStyle));
            return style;
        }
    }
}
