# StartUI4.WPF Control Library Documentation

> A modern Fluent Design UI control library based on WPF .NET 6

[![Get From Microsoft](https://get.microsoft.com/images/en-us%20dark.svg)](https://apps.microsoft.com/detail/9nvb5kpdjwfg)

> **Github**: [Github](https://github.com/KSSTU/StartUI4.WPF/)

![Image](https://store-images.s-microsoft.com/image/apps.30849.14402085032895111.92211ece-02cd-474f-a3b1-9dec5d75adbe.c29164b8-eaee-4f76-9124-fc8f781c7cdb)

---

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Quick Start](#quick-start)
- [Control List](#control-list)
- [Control Details](#control-details)

---

## Introduction

**StartUI4.WPF** is a modern UI control library developed based on WPF .NET 6, perfectly aligned with the WinUI Fluent Design language. Easy to configure and use, supports Windows 7 / 10 / 11 operating systems.

- **Version**: 1.0.5
- **Author**: KS.STUDIO
- **Target Framework**: .NET 6 (net6.0-windows7.0)
- **NuGet Package**: StartUI4.WPF


![Image](https://store-images.s-microsoft.com/image/apps.63171.14402085032895111.92211ece-02cd-474f-a3b1-9dec5d75adbe.7fd0dc69-cf18-4f5c-af03-641cefbcef67)


---

## Features

-  **Fluent Design Style** - Perfectly aligned with WinUI design language
-  **Gradient Color Support** - Multiple controls support gradient color configuration
-  **Rich Animation Effects** - Smooth animations for hover, switch, loading, etc.
-  **Highly Customizable** - Extensive dependency properties for external style adjustment
-  **Out of the Box** - Simple reference for immediate use
-  **Multi-platform Support** - Supports Windows 7 / 10 / 11
-  **Based on .NET 6** - High performance, cross-version compatibility

---

## Quick Start

### 1. Install NuGet Package

```
Install-Package StartUI4.WPF
```

Or via .NET CLI:

```
dotnet add package StartUI4.WPF
```

### 2. Import Namespace

Add the namespace reference in your XAML file:

```xml
xmlns:ui="clr-namespace:StartUI4Controls;assembly=StartUI4Controls"
```

### 3. Use Controls

```xml
<ui:UI4Button Content="Click Me" Width="150" Height="40" />
```

---

## Control List

| Control Name | Base Class | Description |
|-------------|------------|-------------|
| [UI4Button](#ui4button) | Button | Modern button with gradient and hover effects |
| [UI4CheckBox](#ui4checkbox) | CheckBox | Custom styled checkbox |
| [UI4Radio](#ui4radio) | RadioButton | Custom styled radio button |
| [UI4Switch](#ui4switch) | ToggleButton | Modern toggle switch with gradient style |
| [UI4TextBox](#ui4textbox) | TextBox | TextBox with focus gradient, clear button |
| [UI4TextBlock](#ui4textblock) | ContentControl | Text display control with shadow effects |
| [UI4ComboBox](#ui4combobox) | ComboBox | Custom styled dropdown selector |
| [UI4ProgressBar](#ui4progressbar) | Control | Gradient progress bar with indeterminate mode |
| [UI4ProgressRing](#ui4progressring) | ContentControl | Ring progress indicator (determinate/indeterminate) |
| [UI4Slider](#ui4slider) | Slider | Gradient slider control with value display |
| [UI4CircleSlider](#ui4circleslider) | ContentControl | Interactive circular slider |
| [UI4Panel](#ui4panel) | ContentControl | Container panel with shadow and hover scale effects |
| [UI4Pivot](#ui4pivot) | Selector | Tab control with slide transition animation |
| [UI4Tab](#ui4tab) | Selector | Browser-style tab control with close and add buttons |
| [UI4NavigationView](#ui4navigationview) | ItemsControl | Sidebar navigation control |
| [UI4ListBox](#ui4listbox) | ListBox | Custom styled list, supports multiple list styles |
| [UI4ListView](#ui4listview) | ListBox | Card-style list view |
| [UI4GridView](#ui4gridview) | ListBox | Grid layout card view with adaptive columns |
| [UI4ScrollViewer](#ui4scrollviewer) | ScrollViewer | Custom scrollbar with smooth scrolling animation |
| [UI4MessageBox](#ui4messagebox) | Window | Custom message dialog box |
| [UI4CodeEditor](#ui4codeeditor) | RichTextBox | Code editor with syntax highlighting |

---

## Control Details

---

### UI4Button

A modern button control with support for rounded corners, gradient colors, hover background, and other custom styles.

**Inherits from**: `Button`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `CornerRadius` | `CornerRadius` | `8` | Button corner radius |
| `GradientStart` | `Color` | `#2563EB` (37,99,235) | Gradient start color |
| `GradientEnd` | `Color` | `#9333EA` (147,51,234) | Gradient end color |
| `HoverBackground` | `Brush` | `#1D4ED8` (29,78,216) | Background color on mouse hover |

#### Inherited Properties

Also inherits all properties from `Button`, such as `Content`, `Background`, `Foreground`, `FontSize`, `FontWeight`, `Width`, `Height`, `Margin`, `Padding`, `Cursor`, etc.

#### Example Code

```xml
<!-- Basic button -->
<ui:UI4Button Content="OK" Width="100" Height="30" />

<!-- Custom color button -->
<ui:UI4Button Content="Green Button" 
              Background="Green" 
              HoverBackground="DarkGreen" 
              Width="200" Height="40" />

<!-- Button with gradient -->
<ui:UI4Button Content="Gradient Button" 
              GradientStart="#FF0024FF" 
              GradientEnd="#FFB400FF"
              Width="150" Height="40" />

<!-- Rounded button -->
<ui:UI4Button Content="Rounded Button" 
              CornerRadius="20" 
              Width="150" Height="40" />
```

#### Events

Supports all events from the `Button` base class, such as `Click`, `MouseEnter`, `MouseLeave`, etc.

---

### UI4CheckBox

A custom-styled checkbox control with adjustable check box size, color, corner radius, etc.

**Inherits from**: `CheckBox`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `BoxCornerRadius` | `CornerRadius` | `4` | Check box corner radius |
| `CheckBackground` | `Color` | `#1D4ED8` (29,78,216) | Check box background color when selected |
| `BorderNormalColor` | `Color` | `#B4B4C8` (180,180,200) | Border color when unselected |
| `BoxSize` | `double` | `18` | Check box size (width and height) |
| `TextColor` | `Color` | `LightGray` | Text color when unselected |
| `TextMargin` | `Thickness` | `8,0,0,0` | Spacing between text and check box |

#### Inherited Properties

Also inherits all properties from `CheckBox`, such as `Content`, `IsChecked`, `Foreground`, `FontSize`, etc.

#### Example Code

```xml
<!-- Basic checkbox -->
<ui:UI4CheckBox Content="Agree to terms" IsChecked="True" Margin="10" />

<!-- Custom color checkbox -->
<ui:UI4CheckBox Content="Green Theme" 
                CheckBackground="Green" 
                BorderNormalColor="DarkGreen"
                BoxSize="24"
                BoxCornerRadius="6" />

<!-- Custom text color and spacing -->
<ui:UI4CheckBox Content="Custom Style" 
                TextColor="Black"
                TextMargin="12,0,0,0"
                FontSize="16" />
```

#### Notes

- Text color automatically uses the `Foreground` property when selected
- Border color darkens on hover
- Check mark is a white check shape

---

### UI4Radio

A custom-styled radio button control, consistent with UI4CheckBox style, supports group mutual exclusion.

**Inherits from**: `RadioButton`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `CheckBackground` | `Color` | `#1D4ED8` (29,78,216) | Fill color when selected |
| `BorderNormalColor` | `Color` | `#B4B4C8` (180,180,200) | Border color when unselected |
| `DotColor` | `Color` | `White` | Inner dot color when selected |
| `BoxSize` | `double` | `18` | Radio button size (diameter) |
| `TextColor` | `Color` | `LightGray` | Text color when unselected |
| `TextMargin` | `Thickness` | `8,0,0,0` | Spacing between text and radio button |

#### Inherited Properties

Also inherits all properties from `RadioButton`, such as `Content`, `IsChecked`, `GroupName`, `Foreground`, `FontSize`, etc.

#### Example Code

```xml
<!-- Basic radio buttons -->
<ui:UI4Radio Content="Option 1" IsChecked="True" GroupName="Group1" Margin="5" />
<ui:UI4Radio Content="Option 2" GroupName="Group1" Margin="5" />
<ui:UI4Radio Content="Option 3" GroupName="Group1" Margin="5" />

<!-- Custom color radio -->
<ui:UI4Radio Content="Green Theme" 
             CheckBackground="Green" 
             BorderNormalColor="DarkGreen"
             DotColor="White"
             BoxSize="20" />

<!-- Custom text color and spacing -->
<ui:UI4Radio Content="Custom Style" 
             TextColor="Black"
             TextMargin="12,0,0,0"
             FontSize="16" />
```

#### Feature Notes

- **Consistent Style**: Matches UI4CheckBox visual style (same color scheme)
- **Group Mutual Exclusion**: Same `GroupName` only allows one selection
- **Hover Effect**: Border color changes on mouse hover
- **Keyboard Support**: Supports Tab navigation and Space key selection
- **Three-state Support**: Supports `IsThreeState` tri-state mode

---

### UI4Switch

A modern toggle switch control with gradient fill, smooth sliding animation, consistent with UI4Button color scheme.

**Inherits from**: `ToggleButton`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `IsOn` | `bool` | `false` | Switch state (same as `IsChecked`) |
| `GradientStart` | `Color` | `#2563EB` (37,99,235) | Gradient start color when ON |
| `GradientEnd` | `Color` | `#9333EA` (147,51,234) | Gradient end color when ON |
| `OffBackground` | `Color` | `#C8C8D2` (200,200,210) | Background color when OFF |
| `ThumbColor` | `Color` | `White` | Thumb (slider) color |
| `SwitchWidth` | `double` | `50` | Switch width |
| `SwitchHeight` | `double` | `28` | Switch height |

#### Inherited Properties

Also inherits all properties from `ToggleButton`, such as `IsChecked`, `Content`, `Foreground`, `FontSize`, `IsEnabled`, etc.

#### Example Code

```xml
<!-- Basic switch -->
<ui:UI4Switch IsOn="True" />

<!-- Custom size and color -->
<ui:UI4Switch IsOn="True"
              SwitchWidth="60"
              SwitchHeight="32"
              GradientStart="Green"
              GradientEnd="DarkGreen"
              OffBackground="LightGray" />

<!-- With text label -->
<StackPanel Orientation="Horizontal">
    <ui:UI4Switch x:Name="themeSwitch" />
    <TextBlock Text="Dark Mode" VerticalAlignment="Center" Margin="8,0,0,0"/>
</StackPanel>
```

#### Events

| Event Name | EventArgs | Description |
|-----------|-----------|-------------|
| `Toggled` | `RoutedEventArgs` | Triggered when switch state changes |

Also supports all events from `ToggleButton`, such as `Click`, `Checked`, `Unchecked`, etc.

#### Feature Notes

- **Gradient Fill**: Uses UI4Button default gradient color scheme when ON
- **Smooth Animation**: 200ms cubic ease slide animation when toggling
- **Capsule Shape**: Fully rounded ends (pill shape)
- **White Thumb**: White circular slider with shadow contrast
- **Consistent Style**: Matches UI4Button default gradient theme

---

### UI4TextBox

A modern text input box with focus gradient border, clear button, custom context menu, auto-hide scrollbar, and more.

**Inherits from**: `TextBox`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `CornerRadius` | `CornerRadius` | `8` | Input box corner radius |
| `BorderNormalColor` | `Color` | `#C8C8DC` (200,200,220) | Default border color |
| `FocusGradientStart` | `Color` | `#2563EB` (37,99,235) | Gradient start color when focused |
| `FocusGradientEnd` | `Color` | `#9333EA` (147,51,234) | Gradient end color when focused |
| `EditBackground` | `Brush` | `White` (255,255,255) | Input box background color |
| `TextColor` | `Color` | `#1E1E1E` (30,30,30) | Text color |
| `InnerPadding` | `Thickness` | `12,10,32,10` | Internal content padding |
| `ShowClearButton` | `bool` | `false` | Whether to show the clear button |

#### Inherited Properties

Also inherits all properties from `TextBox`, such as `Text`, `FontSize`, `Foreground`, `Width`, `Height`, `AcceptsReturn`, `VerticalScrollBarVisibility`, `HorizontalScrollBarVisibility`, etc.

#### Public Fields

| Field Name | Type | Default Value | Description |
|-----------|------|---------------|-------------|
| `MenuStrings` | `string[]` | `Undo, Cut, Copy, Paste, Delete, Select All` | Context menu item texts |

#### Example Code

```xml
<!-- Basic single-line textbox -->
<ui:UI4TextBox Width="260" Text="Enter text..." />

<!-- Textbox with clear button -->
<ui:UI4TextBox Width="260" 
               Text="Clearable text" 
               ShowClearButton="True" />

<!-- Multi-line textbox -->
<ui:UI4TextBox Width="450" 
               Height="100" 
               AcceptsReturn="True"
               VerticalScrollBarVisibility="Auto"
               ShowClearButton="True"
               Text="Multi-line text input with clear button" />

<!-- Custom focus color -->
<ui:UI4TextBox Width="300"
               FocusGradientStart="Green"
               FocusGradientEnd="LimeGreen"
               Text="Green focus border" />

<!-- Custom corner radius and background -->
<ui:UI4TextBox Width="300"
               CornerRadius="15"
               EditBackground="#FFF8F8F8"
               BorderNormalColor="#FFCCCCCC"
               Text="Custom style" />
```

#### Feature Notes

- **Focus Gradient Border**: Border becomes gradient colored when focused
- **Clear Button**: Set `ShowClearButton="True"` to show one-click clear button
- **Custom Context Menu**: Replaces system default menu with Undo, Cut, Copy, Paste, Delete, Select All, with icons and multi-language support
- **Auto-hide Scrollbar**: Fades in when scrolling, fades out when stopped, 10px wide
- **Hover Border**: Border color darkens on mouse hover

---

### UI4TextBlock

Enhanced text display control with text shadow effects, custom context menu, etc.

**Inherits from**: `ContentControl`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `Text` | `string` | `""` | Text content (higher priority than Content) |
| `Foreground` | `Brush` | `null` | Foreground color (text color) |
| `CornerRadius` | `CornerRadius` | `8` | Control corner radius |
| `GradientStart` | `Color` | `#2563EB` (37,99,235) | Gradient start color (reserved for extension) |
| `GradientEnd` | `Color` | `#9333EA` (147,51,234) | Gradient end color (reserved for extension) |
| `PanelBackground` | `Brush` | `Transparent` | Panel background color |
| `Padding` | `Thickness` | `8,6,8,6` | Padding |
| `FontSize` | `double` | `15` | Font size |
| `FontWeight` | `FontWeight` | `Normal` | Font weight |
| `HorizontalContentAlign` | `HorizontalAlignment` | `Left` | Horizontal content alignment |
| `VerticalContentAlign` | `VerticalAlignment` | `Center` | Vertical content alignment |
| `TextWrapping` | `TextWrapping` | `NoWrap` | Text wrapping mode |
| **Shadow Properties** | | | |
| `ShadowDepth` | `double` | `8.0` | Shadow depth (offset) |
| `ShadowBlurRadius` | `double` | `5.0` | Shadow blur radius |
| `ShadowOpacity` | `double` | `0.2` | Shadow opacity |
| `ShadowColor` | `Color` | `Black` | Shadow color |

#### Public Fields

| Field Name | Type | Default Value | Description |
|-----------|------|---------------|-------------|
| `MenuStrings` | `string[]` | `Copy, Select All` | Context menu item texts |

#### Example Code

```xml
<!-- Basic text -->
<ui:UI4TextBlock Text="This is a piece of text." FontSize="28" />

<!-- Text with shadow effect -->
<ui:UI4TextBlock Content="Text with shadow" 
                 FontSize="28" 
                 ShadowDepth="8" 
                 ShadowOpacity="0.6" 
                 ShadowBlurRadius="10" 
                 ShadowColor="Black" />

<!-- Gradient text (via Foreground) -->
<ui:UI4TextBlock Text="Gradient Text" FontSize="34" FontWeight="SemiBold">
    <ui:UI4TextBlock.Foreground>
        <LinearGradientBrush EndPoint="1,0.5" StartPoint="0,0.5">
            <GradientStop Color="#FF2762EB"/>
            <GradientStop Color="#FFAD00FF" Offset="1"/>
        </LinearGradientBrush>
    </ui:UI4TextBlock.Foreground>
</ui:UI4TextBlock>

<!-- Heading text -->
<ui:UI4TextBlock x:Name="HeroTextBlock" 
                 FontSize="52" 
                 FontWeight="Bold"  
                 TextWrapping="Wrap"  
                 Foreground="#111111" 
                 Content="StartUI4.WPF" 
                 ShadowOpacity="0"/>
```

#### Feature Notes

- **Dual Content Properties**: Supports both `Text` and `Content`, with `Text` having higher priority
- **Text Shadow**: Adjust text shadow effect via `Shadow*` series properties
- **Custom Context Menu**: Supports Copy and Select All operations
- **Gradient Foreground Support**: Gradient brushes can be set via `Foreground`

---

### UI4ComboBox

Custom styled dropdown selector with focus gradient border, hover effects, etc.

**Inherits from**: `ComboBox`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `CornerRadius` | `CornerRadius` | `8` | Dropdown corner radius |
| `BorderNormalColor` | `Color` | `#C8C8DC` (200,200,220) | Default border color |
| `FocusGradientStart` | `Color` | `#2563EB` (37,99,235) | Gradient start color when focused |
| `FocusGradientEnd` | `Color` | `#9333EA` (147,51,234) | Gradient end color when focused |
| `EditBackground` | `Brush` | `White` (255,255,255) | Background color |
| `TextColor` | `Color` | `#1E1E1E` (30,30,30) | Text color |
| `InnerPadding` | `Thickness` | `12,10,30,10` | Internal padding |
| `DropCornerRadius` | `CornerRadius` | `6` | Dropdown list corner radius |

#### Inherited Properties

Also inherits all properties from `ComboBox`, such as `Items`, `SelectedIndex`, `SelectedItem`, `IsEditable`, `Width`, `Height`, `FontSize`, etc.

#### Example Code

```xml
<!-- Basic combobox -->
<ui:UI4ComboBox Width="400" Height="40" SelectedIndex="0">
    <ComboBoxItem>Option 1</ComboBoxItem>
    <ComboBoxItem>Option 2</ComboBoxItem>
    <ComboBoxItem>Option 3</ComboBoxItem>
</ui:UI4ComboBox>

<!-- Custom color -->
<ui:UI4ComboBox Width="300" 
                FocusGradientStart="Green"
                FocusGradientEnd="LimeGreen"
                SelectedIndex="0">
    <ComboBoxItem>Red</ComboBoxItem>
    <ComboBoxItem>Green</ComboBoxItem>
    <ComboBoxItem>Blue</ComboBoxItem>
</ui:UI4ComboBox>

<!-- Custom corner radius -->
<ui:UI4ComboBox Width="300" 
                CornerRadius="16"
                DropCornerRadius="10">
    <ComboBoxItem>Rounded Dropdown</ComboBoxItem>
</ui:UI4ComboBox>
```

#### Feature Notes

- **Focus Gradient Border**: Border becomes gradient colored when focused
- **Dropdown Animation**: Dropdown list with fade-in animation
- **Hover Effect**: Dropdown items with hover background color
- **Editable Mode**: Supports `IsEditable="True"` edit mode

---

### UI4ProgressBar

Linear progress bar control with gradient colors and indeterminate mode.

**Inherits from**: `Control`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `CornerRadius` | `CornerRadius` | `5` | Progress bar corner radius |
| `GradientStart` | `Color` | `#0096E6` (0,150,230) | Progress gradient start color |
| `GradientEnd` | `Color` | `#0078D4` (0,120,212) | Progress gradient end color (matches ProgressRing) |
| `TrackBackground` | `Color` | `#0A000000` (10,0,0,0) | Track background color (matches ProgressRing) |
| `IsIndeterminate` | `bool` | `false` | Indeterminate mode (marquee animation) |
| `Minimum` | `double` | `0` | Minimum value |
| `Maximum` | `double` | `100` | Maximum value |
| `Value` | `double` | `0` | Current progress value |
| `Background` | `Brush` | `null` | If set, uses solid color instead of gradient |

#### Example Code

```xml
<!-- Basic progress bar -->
<ui:UI4ProgressBar Value="50" Maximum="100" Minimum="0" 
                   Width="200" Height="6" />

<!-- Solid color progress bar (Background overrides gradient) -->
<ui:UI4ProgressBar Value="50"  
                   Maximum="100" Minimum="0" 
                   Width="200" Height="6" 
                   Background="Red" />

<!-- Custom gradient progress bar -->
<ui:UI4ProgressBar Value="50"  
                   Maximum="100" Minimum="0" 
                   Width="200" Height="6" 
                   GradientStart="#FF55FF00" 
                   GradientEnd="#FF0016FF" />

<!-- Custom track color -->
<ui:UI4ProgressBar Value="75" 
                   Maximum="100" 
                   TrackBackground="#FFE0E0E0"
                   Width="200" Height="6" />

<!-- Indeterminate mode -->
<ui:UI4ProgressBar IsIndeterminate="True" 
                   Width="200" Height="6" />
```

#### Feature Notes

- **Horizontal Gradient Fill**: Progress fill uses left-to-right gradient color by default
- **Background Override**: If `Background` property is set, solid color is used instead of gradient
- **Rounded Appearance**: Track and progress are rounded, with proper corner clipping at boundaries
- **Adjustable Height**: Adjust thickness via `Height` property
- **Indeterminate Mode**: Set `IsIndeterminate="True"` for marquee-style sliding animation
- **Color Consistency**: Default colors match UI4ProgressRing for visual uniformity

---

### UI4ProgressRing

Ring progress indicator, supporting determinate mode (display specific value) and indeterminate mode (rotation animation).

**Inherits from**: `ContentControl`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `IsActive` | `bool` | `true` | Whether active (visible) |
| `IsIndeterminate` | `bool` | `true` | Whether in indeterminate mode |
| `Minimum` | `double` | `0.0` | Minimum value |
| `Maximum` | `double` | `100.0` | Maximum value |
| `Value` | `double` | `0.0` | Current value |
| `RingBackground` | `Brush` | `#0A000000` (10,0,0,0) | Ring background color |
| `RingForeground` | `Brush` | `#0078D4` (0,120,212) | Ring foreground color (progress color) |
| `RingThickness` | `double` | `6.0` | Ring line thickness |
| `ShowValueText` | `bool` | `true` | Whether to show value text |
| `ValueFontSize` | `double` | `30.0` | Value text size |
| **Animation Properties** | | | |
| `AnimatedValue` | `double` | `0.0` | Internal animation-driven value |
| `StartupAnimationDuration` | `double` | `0.5` | Startup animation duration (seconds) |
| `EnableStartupAnimation` | `bool` | `true` | Whether to enable startup animation |

#### Inherited Properties

Also inherits all properties from `ContentControl`, such as `Foreground`, `Width`, `Height`, etc.

#### Example Code

```xml
<!-- Indeterminate mode (spin animation) -->
<ui:UI4ProgressRing IsActive="True" 
                    IsIndeterminate="True" 
                    Width="80" Height="80" />

<!-- Determinate mode (show value) -->
<ui:UI4ProgressRing IsIndeterminate="False" 
                    Foreground="Red" 
                    ValueFontSize="20" 
                    ShowValueText="True" 
                    Value="50" 
                    Maximum="150" />

<!-- Gradient color progress ring -->
<ui:UI4ProgressRing Width="150" Height="150"
                    IsActive="True" 
                    IsIndeterminate="False" 
                    RingThickness="12" 
                    Maximum="60" 
                    ValueFontSize="60" 
                    ShowValueText="True" 
                    Foreground="#FF8E17FA">
    <ui:UI4ProgressRing.RingForeground>
        <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
            <GradientStop Color="#FF2861EB"/>
            <GradientStop Color="#FFAC01FF" Offset="1"/>
        </LinearGradientBrush>
    </ui:UI4ProgressRing.RingForeground>
</ui:UI4ProgressRing>
```

#### Feature Notes

- **Dual Mode**: Supports `IsIndeterminate` indeterminate mode (spin animation) and determinate mode (value progress)
- **Gradient Ring**: `RingForeground` supports `Brush`, gradient colors can be set
- **Value Display**: Center can display current value
- **Startup Animation**: Smooth transition from 0 to target value on load
- **Round Caps**: Both ends of the ring are round-capped

---

### UI4Slider

Slider control with gradient track and value display.

**Inherits from**: `Slider`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `CornerRadius` | `CornerRadius` | `4` | Track corner radius |
| `GradientStart` | `Color` | `#2563EB` (37,99,235) | Gradient start color |
| `GradientEnd` | `Color` | `#9333EA` (147,51,234) | Gradient end color |
| `TrackBackground` | `Color` | `White` (255,255,255) | Track background color |
| `ThumbSize` | `double` | `16` | Slider thumb size |
| `IsValueVisible` | `bool` | `true` | Whether to show bottom value labels |

#### Inherited Properties

Also inherits all properties from `Slider`, such as `Value`, `Minimum`, `Maximum`, `Width`, `Height`, `IsDirectionReversed`, etc.

#### Example Code

```xml
<!-- Basic slider -->
<ui:UI4Slider Value="50" Maximum="100" Minimum="0" 
              Width="200" Height="20" />

<!-- Without value display -->
<ui:UI4Slider Value="50" Maximum="200" Minimum="0" 
              Width="200" Height="20" 
              IsValueVisible="False" 
              GradientStart="#FFFFF900" 
              GradientEnd="Red" />

<!-- Custom thumb size -->
<ui:UI4Slider Value="30" 
              ThumbSize="20"
              Width="300" />
```

#### Feature Notes

- **Gradient Track**: Filled portion uses gradient color
- **Value Labels**: Bottom shows minimum, maximum, and current value (can be turned off via `IsValueVisible`)
- **Thumb Tooltip**: Slider ToolTip shows current integer value
- **Custom Thumb**: Adjust thumb size via `ThumbSize`

---

### UI4CircleSlider

Interactive circular slider control, supports mouse drag to adjust value.

**Inherits from**: `ContentControl`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `Value` | `double` | `0.0` | Current value |
| `Minimum` | `double` | `0.0` | Minimum value |
| `Maximum` | `double` | `100.0` | Maximum value |
| `SmallChange` | `double` | `1.0` | Step (snap value) |
| `RingThickness` | `double` | `8.0` | Ring line thickness |
| `RingForeground` | `Brush` | `#0078D4` (0,120,212) | Ring foreground color (progress color) |
| `RingBackground` | `Brush` | `#0A000000` (10,0,0,0) | Ring background color |
| `ShowValueText` | `bool` | `false` | Whether to show value text |
| `ValueFontSize` | `double` | `30.0` | Value text size |
| `AnimationDuration` | `double` | `0.5` | Load animation duration (seconds) |

#### Inherited Properties

Also inherits all properties from `ContentControl`, such as `Foreground`, `Width`, `Height`, `Background`, etc.

#### Example Code

```xml
<!-- Basic circular slider -->
<ui:UI4CircleSlider Value="60" ShowValueText="True" />

<!-- Custom size and color -->
<ui:UI4CircleSlider Width="200" Height="200" 
                    RingThickness="12" 
                    Maximum="360" 
                    ValueFontSize="60" 
                    Value="60" 
                    ShowValueText="True" 
                    Foreground="Green" />

<!-- Gradient color circular slider -->
<ui:UI4CircleSlider Width="150" Height="150" 
                    RingThickness="12" 
                    Maximum="24" 
                    ValueFontSize="60" 
                    ShowValueText="True" 
                    Foreground="#FF2861EB">
    <ui:UI4CircleSlider.RingForeground>
        <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
            <GradientStop Color="#FFFFEC00"/>
            <GradientStop Color="Red" Offset="1"/>
        </LinearGradientBrush>
    </ui:UI4CircleSlider.RingForeground>
</ui:UI4CircleSlider>
```

#### Feature Notes

- **Interactive Dragging**: Left mouse button drag on ring slider to adjust value
- **Step Snapping**: Automatically snaps to integer multiple of `SmallChange` after dragging ends
- **Gradient Support**: `RingForeground` supports brush, gradient colors can be set
- **Slider Thumb**: Circular slider with white stroke
- **Load Animation**: Smooth transition from minimum to set value on initial load
- **Round Caps**: Both ends of the ring are round-capped

---

### UI4Panel

Container panel with shadow effects and hover scale animation, can wrap any content.

**Inherits from**: `ContentControl`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `CornerRadius` | `CornerRadius` | `12` | Panel corner radius |
| `BorderBrush` | `Color` | `#3C788CC8` (60,120,140,200) | Border color |
| `HoverBorderBrush` | `SolidColorBrush` | `#6366F1` | Border color on hover |
| `BorderThickness` | `Thickness` | `1` | Border thickness |
| `ContentPadding` | `Thickness` | `0` | Content padding |
| `HoverAnimationDuration` | `Duration` | `00:00:00.200` | Hover animation duration |
| `HoverScale` | `double` | `1.01` | Hover scale ratio |
| **Shadow Properties** | | | |
| `ShadowDepth` | `double` | `0.0` | Shadow depth (offset) |
| `ShadowBlurRadius` | `double` | `15.0` | Shadow blur radius |
| `ShadowOpacity` | `double` | `0.1` | Shadow opacity |
| `ShadowColor` | `Color` | `Black` | Shadow color |

#### Inherited Properties

Also inherits all properties from `ContentControl`, such as `Background`, `Content`, `Width`, `Height`, `Margin`, `Padding`, etc.

#### Example Code

```xml
<!-- Basic panel -->
<ui:UI4Panel Width="300" Height="200">
    <TextBlock Text="Panel Content" HorizontalAlignment="Center" VerticalAlignment="Center"/>
</ui:UI4Panel>

<!-- Panel with shadow and hover scale -->
<ui:UI4Panel Width="800" Height="600" 
             ShadowDepth="15" 
             ShadowOpacity="0.6" 
             HoverScale="1.1">
    <Grid Margin="20">
        <TextBlock Text="Panel with shadow and hover effects"/>
    </Grid>
</ui:UI4Panel>

<!-- Transparent background panel (as animation container only) -->
<ui:UI4Panel ShadowDepth="8" 
             ShadowOpacity="0.4" 
             HoverScale="1.0" 
             BorderThickness="0" 
             Background="Transparent">
    <!-- content -->
</ui:UI4Panel>
```

#### Feature Notes

- **Shadow Effect**: Adjust drop shadow effect via `Shadow*` properties
- **Hover Scale**: Smooth scale up on mouse hover (`HoverScale` controls scale ratio)
- **Border Color Animation**: Smooth transition of border color on hover
- **Center Scale**: Scaling is centered on the panel center
- **Easing Function**: Uses Cubic EaseOut easing for more natural animation

---

### UI4Pivot

Tab/pivot control with smooth content slide transition animation.

**Contains two classes**:
- `UI4Pivot` - Main pivot control
- `UI4PivotItem` - Pivot item

#### UI4Pivot Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `SelectedItemForeground` | `Color` | `#2563EB` (37,99,235) | Selected item text color |
| `ItemFontSize` | `double` | `20.0` | Unselected item font size |
| `SelectedFontSize` | `double` | `25.0` | Selected item font size |
| `BrandFontSize` | `double` | `22.0` | Brand item font size |
| `ItemFontWeight` | `FontWeight` | `Normal` | Unselected item font weight |
| `BrandFontWeight` | `FontWeight` | `SemiBold` | Brand item font weight |
| `ItemForeground` | `Color` | `#DC000000` (220,0,0,0) | Unselected item text color |
| `ItemHoverForeground` | `Color` | `#DC000000` (220,0,0,0) | Hover item text color |
| `ItemPadding` | `Thickness` | `10,8,10,8` | Tab item padding |
| `ItemMargin` | `Thickness` | `5,0,5,0` | Tab item margin |

#### UI4PivotItem Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `Header` | `object` |  | Tab header |
| `IsBrand` | `bool` | `false` | Whether it's a brand item (special style) |
| `Content` | `object` |  | Tab content |

#### Inherited Properties

`UI4Pivot` inherits from `Selector`, supports `SelectedIndex`, `SelectedItem`, `Items`, `SelectionChanged` event, etc.

#### Example Code

```xml
<!-- Basic pivot -->
<ui:UI4Pivot x:Name="pivot" 
             ItemFontSize="18" 
             SelectionChanged="pivot_SelectionChanged">
    <ui:UI4PivotItem Header="Home">
        <TextBlock Text="Home Content"/>
    </ui:UI4PivotItem>
    <ui:UI4PivotItem Header="Settings">
        <TextBlock Text="Settings Content"/>
    </ui:UI4PivotItem>
    <ui:UI4PivotItem Header="About">
        <TextBlock Text="About Content"/>
    </ui:UI4PivotItem>
</ui:UI4Pivot>

<!-- Custom selected color -->
<ui:UI4Pivot SelectedItemForeground="Black" Margin="0,0,0,20">
    <ui:UI4PivotItem Header="Option 1">
        <TextBlock Text="Content 1"/>
    </ui:UI4PivotItem>
    <ui:UI4PivotItem Header="Option 2">
        <TextBlock Text="Content 2"/>
    </ui:UI4PivotItem>
</ui:UI4Pivot>
```

#### Feature Notes

- **Slide Transition Animation**: Left-right slide + fade in/out animation on content switch
- **Selected Enlargement**: Selected item font automatically enlarges and boldens
- **Brand Item**: Items with `IsBrand="True"` use brand style
- **Horizontal Arrangement**: Tabs arranged horizontally at the top
- **Scrollable Header**: Horizontal scrollbar (UI4ScrollViewer) appears when tabs exceed control width

---

### UI4Tab

Browser-style tab control with close buttons, add button, icon support, and customizable header background.

**Contains two classes**:
- `UI4Tab` - Main tab control
- `UI4TabItem` - Tab item

#### UI4Tab Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `HeaderBackground` | `Color` | `#E6E6EB` (230,230,235) | Top header area background color |
| `TabBackground` | `Color` | `Transparent` | Unselected tab background |
| `TabSelectedBackground` | `Color` | `White` | Selected tab background |
| `TabHoverBackground` | `Color` | `#1E000000` | Hover tab background |
| `TabForeground` | `Color` | `#C8000000` | Unselected tab text color |
| `TabSelectedForeground` | `Color` | `#FF000000` | Selected tab text color |
| `CloseButtonColor` | `Color` | `#96000000` | Close button color |
| `TabFontSize` | `double` | `13` | Tab font size |
| `TabPadding` | `Thickness` | `12,8,8,8` | Tab padding |
| `ShowAddButton` | `bool` | `true` | Whether to show the add button on the right |
| `AddButtonColor` | `Color` | `#96000000` | Add button color |
| `TabCornerRadius` | `double` | `6` | Tab item corner radius |

#### UI4TabItem Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `Header` | `object` | | Tab header content |
| `TextIcon` | `string` | `null` | Text icon character (e.g. Segoe MDL2 Assets) |
| `TextIconFontFamily` | `FontFamily` | `Segoe MDL2 Assets` | Text icon font family |
| `ImageSource` | `ImageSource` | `null` | Image icon (**takes priority** over TextIcon) |
| `IconSize` | `double` | `16` | Icon size |
| `IsClosable` | `bool` | `true` | Whether to show the close button |
| `Content` | `object` | | Tab content |

#### Events

| Event Name | EventArgs | Description |
|-----------|-----------|-------------|
| `AddTab` | `RoutedEventArgs` | Triggered when add button is clicked |
| `CloseTab` | `TabCloseRoutedEventArgs` | Triggered when close button is clicked, `e.Handled = true` cancels close |

`TabCloseRoutedEventArgs` properties:
- `TabItem` (`UI4TabItem`) - The tab item being closed

#### Inherited Properties

`UI4Tab` inherits from `Selector`, supports `SelectedIndex`, `SelectedItem`, `Items`, `SelectionChanged` event, etc.

#### Example Code

```xml
<!-- Basic tab control -->
<ui:UI4Tab x:Name="MyTab"
           AddTab="MyTab_AddTab"
           CloseTab="MyTab_CloseTab">
    
    <!-- Tab with text icon -->
    <ui:UI4TabItem Header="Home" TextIcon="&#xE80F;">
        <Grid Background="White">
            <TextBlock Text="Home content"/>
        </Grid>
    </ui:UI4TabItem>
    
    <!-- Tab with image icon -->
    <ui:UI4TabItem Header="Document" ImageSource="/Images/doc.png">
        <Grid Background="White">
            <TextBlock Text="Document content"/>
        </Grid>
    </ui:UI4TabItem>
    
    <!-- Non-closable tab -->
    <ui:UI4TabItem Header="Settings" TextIcon="&#xE713;" IsClosable="False">
        <Grid Background="White">
            <TextBlock Text="Settings content"/>
        </Grid>
    </ui:UI4TabItem>
    
</ui:UI4Tab>

<!-- Custom colors -->
<ui:UI4Tab HeaderBackground="#F0F0F0"
           TabSelectedBackground="White"
           CloseButtonColor="Red"
           ShowAddButton="False">
    ...
</ui:UI4Tab>
```

Code-behind example:

```csharp
private int _tabCount = 3;

private void MyTab_AddTab(object sender, RoutedEventArgs e)
{
    _tabCount++;
    var newTab = new UI4TabItem
    {
        Header = $"New Tab {_tabCount}",
        TextIcon = "\uE80F",
        Content = new TextBlock { Text = $"Tab {_tabCount} content" }
    };
    MyTab.Items.Add(newTab);
    MyTab.SelectedIndex = MyTab.Items.Count - 1;
}

private void MyTab_CloseTab(object sender, TabCloseRoutedEventArgs e)
{
    // Prevent closing the last tab
    if (MyTab.Items.Count <= 1)
    {
        e.Handled = true; // Cancel close
    }
}
```

#### Feature Notes

- **Browser Style**: Browser tab design with rounded corners and close buttons
- **Dual Icon Mode**: Image icon (`ImageSource`) takes priority, falls back to text icon (`TextIcon`)
- **Add Button**: Right-side "+" button for adding new tabs (toggleable)
- **Close Button**: Each tab has an × close button (toggleable per tab)
- **Customizable Header**: `HeaderBackground` controls the top bar background color
- **Content Switch Animation**: Slide + fade animation when switching tabs
- **Scrollable Header**: Horizontal scrollbar appears when tabs exceed width
- **Cancellable Close**: Set `e.Handled = true` in `CloseTab` event to prevent closing

---

### UI4NavigationView

Sidebar navigation control with collapsible sidebar, content switch animation, etc.

![1](https://store-images.s-microsoft.com/image/apps.53158.14402085032895111.4e651371-d0df-4a15-9e7b-7fa694cf7844.9d8e483a-32c9-433e-96b6-9f736e874cf1)

**Contains two classes**:
- `UI4NavigationView` - Main navigation view
- `UI4NavigationViewItem` - Navigation item

#### UI4NavigationView Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `LeftPanelBackground` | `Brush` | `null` | Left panel background |
| `LeftPanelWidth` | `double` | `200.0` | Left panel expanded width |
| `ItemHoverColor` | `Color` | `White` | List item hover background color |
| `ItemPressedBackground` | `Color` | `#0C000000` (12,0,0,0) | List item pressed background color |
| `ItemPressedForeground` | `Color` | `Black` | List item pressed foreground color |
| `ItemHoverForeground` | `Color` | `Black` | List item hover foreground color |
| `ItemForeground` | `Brush` | `Black` | List item normal foreground color |
| `Header` | `string` | `null` | Navigation view header |
| `SelectedItemBackground` | `Brush` | `null` | Selected item background |
| `SelectedItem` | `UI4NavigationViewItem` | `null` | Currently selected item |

#### UI4NavigationViewItem Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `Header` | `string` |  | Navigation item header |
| `ImageSource` | `ImageSource` |  | Icon image source |
| `TextIcon` | `string` |  | Text icon (e.g., Segoe MDL2 Assets characters) |
| `TextIconFontFamily` | `FontFamily` | `null` | Text icon font family |
| `Content` | `object` |  | Navigation item content |

#### Example Code

```xml
<!-- Basic navigation view -->
<ui:UI4NavigationView Header="NavigationView">
    <ui:UI4NavigationViewItem ImageSource="/1.png" Header="Code">
        <TextBlock Text="Code page content"/>
    </ui:UI4NavigationViewItem>
    <ui:UI4NavigationViewItem TextIcon="&#xE104;" 
                              TextIconFontFamily="Segoe MDL2 Assets" 
                              Header="Properties">
        <TextBlock Text="Properties page content"/>
    </ui:UI4NavigationViewItem>
</ui:UI4NavigationView>
```

#### Feature Notes

- **Collapsible Sidebar**: Click menu button to collapse/expand sidebar
- **Dual Icon Mode**: Supports image icon (`ImageSource`) and text icon (`TextIcon`)
- **Content Switch Animation**: Content slides up/down and fades in when switching navigation items
- **Custom Menu Item Colors**: Hover, pressed, selected states all configurable
- **Built-in List**: Navigation list implemented based on `UI4ListBox`

---

### UI4ListBox

Highly customizable listbox control, supports multiple list style types (none, disc, numbered).

**Inherits from**: `ListBox`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `CornerRadius` | `CornerRadius` | `8` | List outer frame corner radius |
| `BorderNormalColor` | `Color` | `#2563EB` (37,99,235) | Border color |
| `PanelBackground` | `Brush` | `White` | List background color |
| `TextColor` | `Color` | `#FF000000` (0,0,0) | Text color |
| `ItemPadding` | `Thickness` | `12,8,12,8` | List item padding |
| `ItemCornerRadius` | `CornerRadius` | `8` | List item corner radius |
| `HoverBackground` | `Color` | `#0AF5FFFF` (10,245,255,255) | Hover item background color |
| `HoverForeground` | `Color` | `#DC000000` (220,0,0,0) | Hover item text color |
| `PressedBackground` | `Color` | `#2563EB` (37,99,235) | Selected/pressed item background color |
| `PressedForeground` | `Color` | `#FFFFFF` (255,255,255) | Selected/pressed item text color |
| `ListStyleType` | `ListStyleType` | `None` | List style type |
| `NumberCircleBackground` | `Brush` | `#2563EB` (37,99,235) | Number circle background |

#### Enum Type: ListStyleType

| Value | Description |
|-------|-------------|
| `None` | No style (default) |
| `Disc` | Disc style |
| `Number` | Numbered style (with circle background) |

#### Inherited Properties

Also inherits all properties from `ListBox`, such as `Items`, `ItemsSource`, `SelectedIndex`, `SelectedItem`, `ItemTemplate`, `SelectionChanged` event, etc.

#### Example Code

```xml
<!-- Normal list -->
<ui:UI4ListBox Width="200" Height="220">
    <ListBoxItem>Item 1</ListBoxItem>
    <ListBoxItem>Item 2</ListBoxItem>
    <ListBoxItem>Item 3</ListBoxItem>
</ui:UI4ListBox>

<!-- Disc style list -->
<ui:UI4ListBox ListStyleType="Disc" 
               HoverForeground="Black" 
               HoverBackground="#0C000000"
               Width="200" Height="220">
    <ListBoxItem>Item 1</ListBoxItem>
    <ListBoxItem>Item 2</ListBoxItem>
    <ListBoxItem>Item 3</ListBoxItem>
</ui:UI4ListBox>

<!-- Numbered list -->
<ui:UI4ListBox ListStyleType="Number" 
               NumberCircleBackground="Green"
               Width="200" Height="220">
    <ListBoxItem>Item 1</ListBoxItem>
    <ListBoxItem>Item 2</ListBoxItem>
    <ListBoxItem>Item 3</ListBoxItem>
</ui:UI4ListBox>

<!-- Gradient number circle -->
<ui:UI4ListBox ListStyleType="Number" Width="200" Height="220">
    <ui:UI4ListBox.NumberCircleBackground>
        <LinearGradientBrush EndPoint="1,0.5" StartPoint="0,0.5">
            <GradientStop Color="#FF002BFF" Offset="0.003"/>
            <GradientStop Color="#FFC800FF" Offset="1"/>
        </LinearGradientBrush>
    </ui:UI4ListBox.NumberCircleBackground>
    <ListBoxItem>Item 1</ListBoxItem>
</ui:UI4ListBox>

<!-- List with custom data template -->
<ui:UI4ListBox x:Name="list_picture" Width="200" Height="220" HoverBackground="#0C000000">
    <ui:UI4ListBox.ItemTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal">
                <Image Source="{Binding ImageSource}" Width="20" Height="20" Margin="0,0,8,0"/>
                <TextBlock Text="{Binding Text}" VerticalAlignment="Center"/>
            </StackPanel>
        </DataTemplate>
    </ui:UI4ListBox.ItemTemplate>
</ui:UI4ListBox>
```

#### Feature Notes

- **Three List Styles**: None, Disc, Numbered
- **Gradient Number Circle**: `NumberCircleBackground` supports `Brush`, gradient colors can be set
- **Custom Scrollbar**: Built-in auto-hide scrollbar, 10px wide (wider and easier to use)
- **Hover/Selected Effects**: Customizable background and text color for each state
- **Data Template Support**: Supports `ItemTemplate` for custom item appearance

---

### UI4ListView

Card-style list view, each item displayed as a card with shadow and hover scale animation.

![Image](https://store-images.s-microsoft.com/image/apps.30115.14402085032895111.92211ece-02cd-474f-a3b1-9dec5d75adbe.d2adeea6-5a7f-42fd-865e-e619d66cf0e9)

**Inherits from**: `ListBox`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `ItemWidth` | `double` | `NaN` | Card item width |
| `ItemHeight` | `double` | `NaN` | Card item height |
| `ItemCornerRadius` | `CornerRadius` | `12` | Card corner radius |
| `ItemBackground` | `Brush` | `#0AFFFFFF` (10,255,255,255) | Card background color |
| `ItemBorderBrush` | `Color` | `#3C788CC8` (60,120,140,200) | Card border color |
| `ItemHoverBorderBrush` | `Color` | `#3CDCF5` (60,220,255) | Border color on hover |
| `ItemBorderThickness` | `Thickness` | `1` | Card border thickness |
| `ItemPadding` | `Thickness` | `0` | Card content padding |
| `ItemMargin` | `Thickness` | `10` | Card margin |
| `HoverAnimationDuration` | `Duration` | `00:00:00.200` | Hover animation duration |
| `HoverScale` | `double` | `1.03` | Hover scale ratio |
| **Shadow Properties** | | | |
| `ShadowColor` | `Color` | `#23000000` (35,0,0,0) | Shadow color |
| `ShadowBlurRadius` | `double` | `12.0` | Shadow blur radius |
| `ShadowDepth` | `double` | `0.0` | Shadow depth |
| `ShadowOpacity` | `double` | `0.35` | Shadow opacity |

#### Inherited Properties

Also inherits all properties from `ListBox`, such as `ItemsSource`, `ItemTemplate`, `SelectedIndex`, `SelectionChanged` event, etc.

#### Example Code

```xml
<!-- Data-bound list view -->
<ui:UI4ListView ItemsSource="{Binding Items}" 
                SelectionChanged="ListView_SelectionChanged"
                ItemBackground="White" 
                ShadowDepth="15" 
                ShadowOpacity="0.2"
                HoverScale="1.01">
    <ui:UI4ListView.ItemTemplate>
        <DataTemplate>
            <Border Background="LightYellow" CornerRadius="10">
                <StackPanel Margin="20">
                    <ui:UI4TextBlock Content="{Binding Title}" Margin="0,10,0,4"/>
                    <ui:UI4TextBlock Content="{Binding Description}" TextWrapping="Wrap"/>
                </StackPanel>
            </Border>
        </DataTemplate>
    </ui:UI4ListView.ItemTemplate>
</ui:UI4ListView>
```

#### Feature Notes

- **Card-style Layout**: Each item is a card with shadow
- **Hover Animation**: Card border color changes + scales on hover
- **Shadow Effect**: Each card has drop shadow effect
- **Custom Scrollbar**: Built-in auto-hide scrollbar, 10px wide
- **Full Data Binding Support**: Supports `ItemsSource` and `ItemTemplate`

---

### UI4GridView

Grid layout card view, automatically calculates column count, responsive layout.

![1](https://store-images.s-microsoft.com/image/apps.56425.14402085032895111.92211ece-02cd-474f-a3b1-9dec5d75adbe.adbe738a-aa09-4828-8924-8cb12290feae)

**Inherits from**: `ListBox`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `ItemWidth` | `double` | `300.0` | Card item width |
| `ItemHeight` | `double` | `220.0` | Card item height |
| `ItemCornerRadius` | `CornerRadius` | `12` | Card corner radius |
| `ItemBackground` | `Brush` | `White` (255,255,255) | Card background color |
| `ItemBorderBrush` | `Color` | `#3C788CC8` (60,120,140,200) | Card border color |
| `ItemHoverBorderBrush` | `Color` | `#3CDCF5` (60,220,255) | Border color on hover |
| `ItemBorderThickness` | `Thickness` | `1` | Card border thickness |
| `ItemPadding` | `Thickness` | `0` | Card content padding |
| `ItemMargin` | `Thickness` | `10` | Card margin |
| `HoverAnimationDuration` | `Duration` | `00:00:00.200` | Hover animation duration |
| `HoverScale` | `double` | `1.03` | Hover scale ratio |
| **Shadow Properties** | | | |
| `ShadowColor` | `Color` | `#23000000` (35,0,0,0) | Shadow color |
| `ShadowBlurRadius` | `double` | `12.0` | Shadow blur radius |
| `ShadowDepth` | `double` | `0.0` | Shadow depth |
| `ShadowOpacity` | `double` | `0.35` | Shadow opacity |

#### Inherited Properties

Also inherits all properties from `ListBox`, such as `ItemsSource`, `ItemTemplate`, `SelectedIndex`, `SelectionChanged` event, etc.

#### Example Code

```xml
<!-- Data-bound grid view -->
<ui:UI4GridView ItemsSource="{Binding Items}" 
                ItemHeight="200" 
                ItemWidth="250"
                SelectionChanged="GridView_SelectionChanged"
                ShadowDepth="15" 
                ShadowOpacity="0.3"  
                HoverScale="1.1">
    <ui:UI4GridView.ItemTemplate>
        <DataTemplate>
            <Border Background="{Binding Background}" CornerRadius="10">
                <StackPanel Margin="20">
                    <Ellipse Width="36" Height="36" Fill="{Binding IconColor}"/>
                    <ui:UI4TextBlock Content="{Binding Title}" Margin="0,8,0,3"/>
                    <ui:UI4TextBlock Content="{Binding Description}" TextWrapping="Wrap"/>
                </StackPanel>
            </Border>
        </DataTemplate>
    </ui:UI4GridView.ItemTemplate>
</ui:UI4GridView>

<!-- Home feature cards example -->
<ui:UI4GridView ItemHeight="200" 
                ItemsSource="{Binding Items1}" 
                Background="{x:Null}" 
                ItemBorderBrush="White" 
                HoverAnimationDuration="00:00:00.2000000" 
                ItemBackground="White" 
                ShadowOpacity="0.1" 
                HoverScale="1.05">
    <ui:UI4GridView.ItemTemplate>
        <DataTemplate>
            <Border>
                <StackPanel Margin="20">
                    <ui:UI4TextBlock Content="{Binding Title}" 
                                     FontSize="22" 
                                     Foreground="Blue" 
                                     VerticalAlignment="Center" 
                                     FontWeight="Bold" 
                                     Margin="0,8,0,20"/>
                    <ui:UI4TextBlock Content="{Binding Description}" 
                                     Foreground="Black" 
                                     TextWrapping="Wrap"/>
                </StackPanel>
            </Border>
        </DataTemplate>
    </ui:UI4GridView.ItemTemplate>
</ui:UI4GridView>
```

#### Feature Notes

- **Responsive Grid**: Automatically calculates column count based on container width
- **Card-style Layout**: Each item is a card with shadow
- **Hover Animation**: Card border color changes + scales on hover
- **Shadow Effect**: Each card has drop shadow effect
- **Custom Scrollbar**: Built-in auto-hide scrollbar, 10px wide
- **Based on UniformGrid**: Uses uniform grid layout

---

### UI4ScrollViewer

Custom styled scroll viewer control with built-in auto-hide scrollbar and smooth scrolling animation.

**Inherits from**: `ScrollViewer`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `IsSmoothScrollEnabled` | `bool` | `true` | Whether to enable smooth scrolling animation |

#### Public Methods

| Method Name | Return Value | Description |
|------------|--------------|-------------|
| `SmoothScrollToVerticalOffset(double offset)` | `void` | Smooth scroll to specified vertical position |
| `SmoothScrollToHorizontalOffset(double offset)` | `void` | Smooth scroll to specified horizontal position |

#### Feature Notes

- **Auto-hide Scrollbar**: Fades in when scrolling, fades out 1.5 seconds after stopping
- **Rounded Thumb**: Scrollbar thumb is rounded rectangle
- **Wider Scrollbar**: 10px wide (5px original + 5px increase), easier to click and drag
- **Hover Show**: Stays visible when mouse hovers over scrollbar
- **Smooth Scrolling**: Mouse wheel scrolling uses cubic ease-out animation (200ms) for smoother feel
- **Smooth Scroll API**: `SmoothScrollToVerticalOffset` / `SmoothScrollToHorizontalOffset` for programmatic smooth scrolling

#### Example Code

```xml
<!-- Basic scroll viewer -->
<ui:UI4ScrollViewer Width="400" Height="200">
    <StackPanel Margin="20" Height="300">
        <TextBlock Text="Scroll content..."/>
    </StackPanel>
</ui:UI4ScrollViewer>

<!-- Scroll viewer with text -->
<ui:UI4ScrollViewer>
    <StackPanel VerticalAlignment="Top">
        <ui:UI4TextBlock FontSize="20" TextWrapping="Wrap" 
                         FontWeight="Bold" 
                         Content="UI4ScrollViewer beautifies the system ScrollViewer, making it more modern and smooth."/>
        <!-- more content -->
    </StackPanel>
</ui:UI4ScrollViewer>
```

#### Inherited Properties

Also inherits all properties from `ScrollViewer`, such as `Content`, `HorizontalScrollBarVisibility`, `VerticalScrollBarVisibility`, `Width`, `Height`, `Padding`, etc.

---

### UI4MessageBox

Custom styled message dialog with entry/exit animations, resizable, and more.

**Inherits from**: `Window`

#### Static Methods

| Method Name | Return Value | Description |
|------------|--------------|-------------|
| `Show(string content, string title = "Notice", double width = 480, double height = 280)` | `bool?` | Show message box, returns dialog result |

#### Constructor

| Constructor | Description |
|------------|-------------|
| `UI4MessageBox(string title, string content)` | Create message box instance |

#### Example Code

```csharp
// Simple call
UI4MessageBox.Show("Operation successful!", "Notice");

// Custom size
UI4MessageBox.Show("This is a message content", "Notification", 480, 280);

// Confirm/cancel judgment
bool? result = UI4MessageBox.Show("Are you sure you want to delete?", "Confirm");
if (result == true)
{
    // User clicked OK
}
else
{
    // User clicked Cancel
}
```

#### Feature Notes

- **Entry Animation**: Slide in from bottom + scale + blur dissipation
- **Exit Animation**: Slide down + shrink + blur + fade out
- **Borderless Window**: Custom window style, no system title bar
- **Draggable**: Drag title bar to move window
- **Resizable**: Resizable from all 8 directions
- **OK / Cancel Buttons**: Two action buttons: OK and Cancel

---

### UI4CodeEditor

Code editor control with C# syntax highlighting.

**Inherits from**: `RichTextBox`

#### Settable Properties

| Property Name | Type | Default Value | Description |
|--------------|------|---------------|-------------|
| `Code` | `string` | `""` | Code text content (two-way binding) |

#### Inherited Properties

Also inherits all properties from `RichTextBox`, such as `Background`, `Foreground`, `FontFamily`, `FontSize`, `Width`, `Height`, `Padding`, etc.

#### Public Methods

| Method Name | Return Value | Description |
|------------|--------------|-------------|
| `HighlightSyntax()` | `void` | Manually trigger syntax highlighting |

#### Syntax Highlighting

Built-in C# syntax highlighting, supports the following types:

| Type | Color | Description |
|------|-------|-------------|
| Default Text | `#D4D4D4` (212,212,212) | Normal text |
| Keywords | `#569CD6` (86,156,214) | C# keywords (class, int, if, etc.) |
| Strings | `#CE9178` (206,145,120) | String literals |
| Comments | `#6A9955` (106,153,85) | Single-line and multi-line comments |
| Numbers | `#B5CEA8` (181,206,168) | Numeric literals |

#### Example Code

```xml
<!-- Basic code editor -->
<ui:UI4CodeEditor x:Name="codeEditor" Width="500" Height="200" />

<!-- Set code content -->
<ui:UI4CodeEditor Code="{Binding CodeContent}" 
                  Width="500" 
                  HorizontalAlignment="Left" />

<!-- Small code display -->
<ui:UI4CodeEditor Height="60" 
                   Width="500" 
                   HorizontalAlignment="Left" 
                   Margin="10,0,0,20"/>
```

#### Feature Notes

- **C# Syntax Highlighting**: Auto-highlights keywords, strings, comments, numbers
- **Dark Theme**: Default dark background, suitable for code display
- **Monospace Font**: Default uses Consolas font
- **Custom Context Menu**: Supports Undo, Cut, Copy, Paste, Delete, Select All
- **Auto Width**: Adjusts automatically based on content when width not set
- **Two-way Binding**: `Code` property supports two-way data binding

---

## Appendix: Namespace Reference

Before using in any XAML file, make sure the namespace is imported:

```xml
<Window xmlns:ui="clr-namespace:StartUI4Controls;assembly=StartUI4Controls"
        ...>
    <!-- control usage -->
</Window>
```

Complete example:

```xml
<Window x:Class="YourApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:ui="clr-namespace:StartUI4Controls;assembly=StartUI4Controls"
        Title="MainWindow" Height="800" Width="1200">
    <Grid>
        <ui:UI4Button Content="Hello StartUI4" Width="200" Height="40"/>
    </Grid>
</Window>
```

---

## License

?? KS.STUDIO - StartUI4.WPF v1.0.5
