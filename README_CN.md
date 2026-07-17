# StartUI4.WPF 控件库文档

> 基于 WPF .NET 6 的现代化 Fluent Design UI 控件库

[![从 Microsoft 商店获取](https://get.microsoft.com/images/en-us%20dark.svg)](https://apps.microsoft.com/detail/9nvb5kpdjwfg)

> **Github**: [Github](https://github.com/KSSTU/StartUI4.WPF/)

![Image](https://store-images.s-microsoft.com/image/apps.30849.14402085032895111.92211ece-02cd-474f-a3b1-9dec5d75adbe.c29164b8-eaee-4f76-9124-fc8f781c7cdb)

---

## 目录

- [项目简介](#项目简介)
- [特性](#特性)
- [快速开始](#快速开始)
- [控件列表](#控件列表)
- [控件详细说明](#控件详细说明)

---

## 项目简介

**StartUI4.WPF** 是一款基于 WPF .NET 6 开发的现代化 UI 控件库，完美契合 WinUI Fluent Design 设计语言。只需简单配置即可使用，支持 Windows 7 / 10 / 11 操作系统。

- **版本**: 1.0.6
- **作者**: KS.STUDIO
- **目标框架**: .NET 6 (net6.0-windows7.0)
- **NuGet 包**: StartUI4.WPF

![Image](https://store-images.s-microsoft.com/image/apps.63171.14402085032895111.92211ece-02cd-474f-a3b1-9dec5d75adbe.7fd0dc69-cf18-4f5c-af03-641cefbcef67)

---

## 特性

- 🎨 **Fluent Design 设计风格** - 完美契合 WinUI 设计语言
- 🌈 **渐变色彩支持** - 多种控件支持渐变色配置
- ✨ **丰富的动画效果** - 悬停、切换、加载等流畅动画
- 🎯 **高度可定制** - 大量依赖属性供外部调整样式
- 📦 **开箱即用** - 简单引用即可使用
- 🪟 **多平台支持** - 支持 Windows 7 / 10 / 11
- 🔧 **基于 .NET 6** - 高性能、跨版本兼容

---

## 快速开始

### 1. 安装 NuGet 包

```
Install-Package StartUI4.WPF
```

或通过 .NET CLI:

```
dotnet add package StartUI4.WPF
```

### 2. 引入命名空间

在 XAML 文件中添加命名空间引用：

```xml
xmlns:ui="clr-namespace:StartUI4Controls;assembly=StartUI4Controls"
```

### 3. 使用控件

```xml
<ui:UI4Button Content="点击我" Width="150" Height="40" />
```

---

## 控件列表

| 控件名称 | 基类 | 简介 |
|---------|------|------|
| [UI4Button](#ui4button-按钮) | Button | 现代化按钮，支持渐变和悬停效果 |
| [UI4CheckBox](#ui4checkbox-复选框) | CheckBox | 自定义样式复选框 |
| [UI4Radio](#ui4radio-单选框) | RadioButton | 自定义样式单选框 |
| [UI4Switch](#ui4switch-开关) | ToggleButton | 渐变风格的现代化开关控件 |
| [UI4TextBox](#ui4textbox-文本输入框) | TextBox | 带焦点渐变、清除按钮的文本框 |
| [UI4TextBlock](#ui4textblock-文本块) | ContentControl | 带阴影效果的文本显示控件 |
| [UI4ComboBox](#ui4combobox-下拉框) | ComboBox | 自定义样式下拉选择框 |
| [UI4ProgressBar](#ui4progressbar-进度条) | Control | 渐变进度条，支持不确定模式 |
| [UI4ProgressRing](#ui4progressring-环形进度) | ContentControl | 环形进度指示器（确定/不确定模式） |
| [UI4Slider](#ui4slider-滑块) | Slider | 渐变滑块控件，带数值显示 |
| [UI4CircleSlider](#ui4circleslider-环形滑块) | ContentControl | 可交互的环形滑块 |
| [UI4Panel](#ui4panel-面板容器) | ContentControl | 带阴影和悬停缩放的容器面板 |
| [UI4Pivot](#ui4pivot-选项卡) | Selector | 选项卡控件，带滑动切换动画 |
| [UI4Tab](#ui4tab-浏览器标签) | Selector | 浏览器风格标签控件，支持关闭和新增按钮 |
| [UI4NavigationView](#ui4navigationview-导航视图) | ItemsControl | 侧边栏导航控件 |
| [UI4ListBox](#ui4listbox-列表框) | ListBox | 自定义样式列表，支持多种列表样式 |
| [UI4ListView](#ui4listview-列表视图) | ListBox | 卡片式列表视图 |
| [UI4GridView](#ui4gridview-网格视图) | ListBox | 网格布局卡片视图，自适应列数 |
| [UI4ScrollViewer](#ui4scrollviewer-滚动视图) | ScrollViewer | 自定义滚动条，支持平滑滚动动画 |
| [UI4MessageBox](#ui4messagebox-消息框) | Window | 自定义消息对话框 |
| [UI4CodeEditor](#ui4codeeditor-代码编辑器) | RichTextBox | 带语法高亮的代码编辑器 |

---

## 控件详细说明

---

### UI4Button 按钮

现代化按钮控件，支持圆角、渐变色、悬停背景等自定义样式。

**继承自**: `Button`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `CornerRadius` | `CornerRadius` | `8` | 按钮圆角半径 |
| `GradientStart` | `Color` | `#2563EB` (37,99,235) | 渐变起始色 |
| `GradientEnd` | `Color` | `#9333EA` (147,51,234) | 渐变结束色 |
| `HoverBackground` | `Brush` | `#1D4ED8` (29,78,216) | 鼠标悬停时的背景色 |

#### 继承属性

同时继承 `Button` 的所有属性，如 `Content`、`Background`、`Foreground`、`FontSize`、`FontWeight`、`Width`、`Height`、`Margin`、`Padding`、`Cursor` 等。

#### 示例代码

```xml
<!-- 基础按钮 -->
<ui:UI4Button Content="确定" Width="100" Height="30" />

<!-- 自定义颜色按钮 -->
<ui:UI4Button Content="绿色按钮" 
              Background="Green" 
              HoverBackground="DarkGreen" 
              Width="200" Height="40" />

<!-- 带渐变色的按钮 -->
<ui:UI4Button Content="渐变按钮" 
              GradientStart="#FF0024FF" 
              GradientEnd="#FFB400FF"
              Width="150" Height="40" />

<!-- 圆角按钮 -->
<ui:UI4Button Content="圆角按钮" 
              CornerRadius="20" 
              Width="150" Height="40" />
```

#### 事件

支持 `Button` 基类的所有事件，如 `Click`、`MouseEnter`、`MouseLeave` 等。

---

### UI4CheckBox 复选框

自定义样式的复选框控件，可调整勾选框大小、颜色、圆角等。

**继承自**: `CheckBox`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `BoxCornerRadius` | `CornerRadius` | `4` | 勾选框圆角半径 |
| `CheckBackground` | `Color` | `#1D4ED8` (29,78,216) | 选中时勾选框背景色 |
| `BorderNormalColor` | `Color` | `#B4B4C8` (180,180,200) | 未选中时边框颜色 |
| `BoxSize` | `double` | `18` | 勾选框尺寸（宽高） |
| `TextColor` | `Color` | `LightGray` | 未选中时文字颜色 |
| `TextMargin` | `Thickness` | `8,0,0,0` | 文字与勾选框的间距 |

#### 继承属性

同时继承 `CheckBox` 的所有属性，如 `Content`、`IsChecked`、`Foreground`、`FontSize` 等。

#### 示例代码

```xml
<!-- 基础复选框 -->
<ui:UI4CheckBox Content="同意协议" IsChecked="True" Margin="10" />

<!-- 自定义颜色复选框 -->
<ui:UI4CheckBox Content="绿色主题" 
                CheckBackground="Green" 
                BorderNormalColor="DarkGreen"
                BoxSize="24"
                BoxCornerRadius="6" />

<!-- 自定义文字颜色和间距 -->
<ui:UI4CheckBox Content="自定义样式" 
                TextColor="Black"
                TextMargin="12,0,0,0"
                FontSize="16" />
```

#### 说明

- 选中时文字颜色自动使用 `Foreground` 属性
- 悬停时边框颜色会加深
- 勾选标记为白色对勾形状

---

### UI4Radio 单选框

自定义样式的单选框控件，与 UI4CheckBox 风格一致，支持分组互斥。

**继承自**: `RadioButton`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `CheckBackground` | `Color` | `#1D4ED8` (29,78,216) | 选中时填充色 |
| `BorderNormalColor` | `Color` | `#B4B4C8` (180,180,200) | 未选中时边框色 |
| `DotColor` | `Color` | `White` | 选中时内圆点颜色 |
| `BoxSize` | `double` | `18` | 单选框大小（直径） |
| `TextColor` | `Color` | `LightGray` | 未选中时文字颜色 |
| `TextMargin` | `Thickness` | `8,0,0,0` | 文字与单选框间距 |

#### 继承属性

继承 `RadioButton` 的所有属性，如 `Content`、`IsChecked`、`GroupName`、`Foreground`、`FontSize` 等。

#### 示例代码

```xml
<!-- 基础单选框 -->
<ui:UI4Radio Content="选项一" IsChecked="True" GroupName="Group1" Margin="5" />
<ui:UI4Radio Content="选项二" GroupName="Group1" Margin="5" />
<ui:UI4Radio Content="选项三" GroupName="Group1" Margin="5" />

<!-- 自定义颜色 -->
<ui:UI4Radio Content="绿色主题" 
             CheckBackground="Green" 
             BorderNormalColor="DarkGreen"
             DotColor="White"
             BoxSize="20" />

<!-- 自定义文字颜色和间距 -->
<ui:UI4Radio Content="自定义样式" 
             TextColor="Black"
             TextMargin="12,0,0,0"
             FontSize="16" />
```

#### 说明

- **风格统一**：与 UI4CheckBox 视觉风格一致（相同配色方案）
- **分组互斥**：同一 `GroupName` 下只能选中一个
- **悬停效果**：鼠标悬停时边框颜色变化
- **键盘支持**：支持 Tab 导航和空格键选择
- **三态支持**：支持 `IsThreeState` 三态模式

---

### UI4Switch 开关

现代化开关控件，渐变填充，平滑滑动动画，与 UI4Button 配色一致。

**继承自**: `ToggleButton`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `IsOn` | `bool` | `false` | 开关状态（同 `IsChecked`） |
| `GradientStart` | `Color` | `#2563EB` (37,99,235) | 开启时渐变起始色 |
| `GradientEnd` | `Color` | `#9333EA` (147,51,234) | 开启时渐变结束色 |
| `OffBackground` | `Color` | `#C8C8D2` (200,200,210) | 关闭时背景色 |
| `ThumbColor` | `Color` | `White` | 滑块颜色 |
| `SwitchWidth` | `double` | `50` | 开关宽度 |
| `SwitchHeight` | `double` | `28` | 开关高度 |

#### 继承属性

继承 `ToggleButton` 的所有属性，如 `IsChecked`、`Content`、`Foreground`、`FontSize`、`IsEnabled` 等。

#### 示例代码

```xml
<!-- 基础开关 -->
<ui:UI4Switch IsOn="True" />

<!-- 自定义大小和颜色 -->
<ui:UI4Switch IsOn="True"
              SwitchWidth="60"
              SwitchHeight="32"
              GradientStart="Green"
              GradientEnd="DarkGreen"
              OffBackground="LightGray" />

<!-- 带文字标签 -->
<StackPanel Orientation="Horizontal">
    <ui:UI4Switch x:Name="themeSwitch" />
    <TextBlock Text="深色模式" VerticalAlignment="Center" Margin="8,0,0,0"/>
</StackPanel>
```

#### 事件

| 事件名 | 参数类型 | 说明 |
|-------|---------|------|
| `Toggled` | `RoutedEventArgs` | 开关状态切换时触发 |

同时支持 `ToggleButton` 的所有事件，如 `Click`、`Checked`、`Unchecked` 等。

#### 说明

- **渐变填充**：开启时使用 UI4Button 默认渐变色方案
- **平滑动画**：切换时 200ms 缓动滑动动画
- **胶囊形状**：两端完全圆角（药丸形状）
- **白色滑块**：白色圆形滑块，对比鲜明
- **风格统一**：与 UI4Button 默认渐变主题一致

---

### UI4TextBox 文本输入框

现代化文本输入框，支持焦点渐变边框、清除按钮、自定义右键菜单、自动隐藏滚动条等特性。

**继承自**: `TextBox`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `CornerRadius` | `CornerRadius` | `8` | 输入框圆角半径 |
| `BorderNormalColor` | `Color` | `#C8C8DC` (200,200,220) | 默认边框颜色 |
| `FocusGradientStart` | `Color` | `#2563EB` (37,99,235) | 聚焦时渐变起始色 |
| `FocusGradientEnd` | `Color` | `#9333EA` (147,51,234) | 聚焦时渐变结束色 |
| `EditBackground` | `Brush` | `White` (255,255,255) | 输入框背景色 |
| `TextColor` | `Color` | `#1E1E1E` (30,30,30) | 文字颜色 |
| `InnerPadding` | `Thickness` | `12,10,32,10` | 内部内容内边距 |
| `ShowClearButton` | `bool` | `false` | 是否显示清除按钮 |
| `PlaceholderText` | `string` | `""` | 文本为空时显示的占位符文本 |
| `PlaceholderForeground` | `Brush` | `LightGray` | 占位符文字颜色 |

#### 继承属性

同时继承 `TextBox` 的所有属性，如 `Text`、`FontSize`、`Foreground`、`Width`、`Height`、`AcceptsReturn`、`VerticalScrollBarVisibility`、`HorizontalScrollBarVisibility` 等。

#### 公共字段

| 字段名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `MenuStrings` | `string[]` | `Undo, Cut, Copy, Paste, Delete, Select All` | 右键菜单项文本 |

#### 示例代码

```xml
<!-- 基础单行文本框 -->
<ui:UI4TextBox Width="260" Text="请输入文本..." />

<!-- 带清除按钮的文本框 -->
<ui:UI4TextBox Width="260" 
               Text="可清除的文本" 
               ShowClearButton="True" />

<!-- 多行文本框 -->
<ui:UI4TextBox Width="450" 
               Height="100" 
               AcceptsReturn="True"
               VerticalScrollBarVisibility="Auto"
               ShowClearButton="True"
               Text="带清除按钮的多行文本输入框" />

<!-- 自定义聚焦颜色 -->
<ui:UI4TextBox Width="300"
               FocusGradientStart="Green"
               FocusGradientEnd="LimeGreen"
               Text="绿色焦点边框" />

<!-- 自定义圆角和背景 -->
<ui:UI4TextBox Width="300"
               CornerRadius="15"
               EditBackground="#FFF8F8F8"
               BorderNormalColor="#FFCCCCCC"
               Text="自定义样式" />

<!-- 带占位符的文本框 -->
<ui:UI4TextBox Width="300"
               PlaceholderText="请输入用户名..." />

<!-- 自定义占位符颜色 -->
<ui:UI4TextBox Width="300"
               PlaceholderText="请输入密码..."
               PlaceholderForeground="Gray" />
```

#### 特性说明

- **焦点渐变边框**: 获得焦点时边框变为渐变色
- **清除按钮**: 设置 `ShowClearButton="True"` 显示一键清除按钮
- **自定义右键菜单**: 替换系统默认菜单，含撤销、剪切、复制、粘贴、删除、全选，带图标和多语言
- **自动隐藏滚动条**: 滚动时淡入，停止后淡出，宽度 10px
- **悬停边框**: 鼠标悬停时边框颜色加深
- **占位符支持**: `PlaceholderText` + `PlaceholderForeground`，输入文字时自动隐藏

---

### UI4TextBlock 文本块

增强型文本显示控件，支持文字阴影效果、自定义右键菜单等。

**继承自**: `ContentControl`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `Text` | `string` | `""` | 文本内容（优先级高于 Content） |
| `Foreground` | `Brush` | `null` | 前景色（文字颜色） |
| `CornerRadius` | `CornerRadius` | `8` | 控件圆角半径 |
| `GradientStart` | `Color` | `#2563EB` (37,99,235) | 渐变起始色（保留扩展） |
| `GradientEnd` | `Color` | `#9333EA` (147,51,234) | 渐变结束色（保留扩展） |
| `PanelBackground` | `Brush` | `Transparent` | 面板背景色 |
| `Padding` | `Thickness` | `8,6,8,6` | 内边距 |
| `FontSize` | `double` | `15` | 字体大小 |
| `FontWeight` | `FontWeight` | `Normal` | 字体粗细 |
| `HorizontalContentAlign` | `HorizontalAlignment` | `Left` | 水平内容对齐 |
| `VerticalContentAlign` | `VerticalAlignment` | `Center` | 垂直内容对齐 |
| `TextWrapping` | `TextWrapping` | `NoWrap` | 文本换行方式 |
| **阴影属性** | | | |
| `ShadowDepth` | `double` | `8.0` | 阴影深度（偏移量） |
| `ShadowBlurRadius` | `double` | `5.0` | 阴影模糊半径 |
| `ShadowOpacity` | `double` | `0.2` | 阴影不透明度 |
| `ShadowColor` | `Color` | `Black` | 阴影颜色 |

#### 公共字段

| 字段名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `MenuStrings` | `string[]` | `Copy, Select All` | 右键菜单项文本 |

#### 示例代码

```xml
<!-- 基础文本 -->
<ui:UI4TextBlock Text="这是一段文本。" FontSize="28" />

<!-- 带阴影效果的文本 -->
<ui:UI4TextBlock Content="带阴影的文本" 
                 FontSize="28" 
                 ShadowDepth="8" 
                 ShadowOpacity="0.6" 
                 ShadowBlurRadius="10" 
                 ShadowColor="Black" />

<!-- 渐变文字（通过 Foreground） -->
<ui:UI4TextBlock Text="渐变文字" FontSize="34" FontWeight="SemiBold">
    <ui:UI4TextBlock.Foreground>
        <LinearGradientBrush EndPoint="1,0.5" StartPoint="0,0.5">
            <GradientStop Color="#FF2762EB"/>
            <GradientStop Color="#FFAD00FF" Offset="1"/>
        </LinearGradientBrush>
    </ui:UI4TextBlock.Foreground>
</ui:UI4TextBlock>

<!-- 大标题文本 -->
<ui:UI4TextBlock x:Name="HeroTextBlock" 
                 FontSize="52" 
                 FontWeight="Bold"  
                 TextWrapping="Wrap"  
                 Foreground="#111111" 
                 Content="StartUI4.WPF" 
                 ShadowOpacity="0"/>
```

#### 特性说明

- **双内容属性**: 同时支持 `Text` 和 `Content`，`Text` 优先级更高
- **文字阴影**: 通过 `Shadow*` 系列属性调整文字阴影效果
- **自定义右键菜单**: 支持复制、全选操作
- **支持渐变前景**: 可通过 `Foreground` 设置渐变画笔

---

### UI4ComboBox 下拉框

自定义样式的下拉选择框，支持焦点渐变边框、悬停效果等。

**继承自**: `ComboBox`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `CornerRadius` | `CornerRadius` | `8` | 下拉框圆角半径 |
| `BorderNormalColor` | `Color` | `#C8C8DC` (200,200,220) | 默认边框颜色 |
| `FocusGradientStart` | `Color` | `#2563EB` (37,99,235) | 聚焦时渐变起始色 |
| `FocusGradientEnd` | `Color` | `#9333EA` (147,51,234) | 聚焦时渐变结束色 |
| `EditBackground` | `Brush` | `White` (255,255,255) | 背景色 |
| `TextColor` | `Color` | `#1E1E1E` (30,30,30) | 文字颜色 |
| `InnerPadding` | `Thickness` | `12,10,30,10` | 内部内边距 |
| `DropCornerRadius` | `CornerRadius` | `6` | 下拉列表圆角半径 |

#### 继承属性

同时继承 `ComboBox` 的所有属性，如 `Items`、`SelectedIndex`、`SelectedItem`、`IsEditable`、`Width`、`Height`、`FontSize` 等。

#### 示例代码

```xml
<!-- 基础下拉框 -->
<ui:UI4ComboBox Width="400" Height="40" SelectedIndex="0">
    <ComboBoxItem>选项1</ComboBoxItem>
    <ComboBoxItem>选项2</ComboBoxItem>
    <ComboBoxItem>选项3</ComboBoxItem>
</ui:UI4ComboBox>

<!-- 自定义颜色 -->
<ui:UI4ComboBox Width="300" 
                FocusGradientStart="Green"
                FocusGradientEnd="LimeGreen"
                SelectedIndex="0">
    <ComboBoxItem>红色</ComboBoxItem>
    <ComboBoxItem>绿色</ComboBoxItem>
    <ComboBoxItem>蓝色</ComboBoxItem>
</ui:UI4ComboBox>

<!-- 自定义圆角 -->
<ui:UI4ComboBox Width="300" 
                CornerRadius="16"
                DropCornerRadius="10">
    <ComboBoxItem>圆角下拉</ComboBoxItem>
</ui:UI4ComboBox>
```

#### 特性说明

- **焦点渐变边框**: 获得焦点时边框变为渐变色
- **下拉动画**: 下拉列表带淡入动画
- **悬停效果**: 下拉项带悬停背景色
- **可编辑模式**: 支持 `IsEditable="True"` 编辑模式

---

### UI4ProgressBar 进度条

带渐变色的线性进度条控件，支持不确定模式。

**继承自**: `Control`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `CornerRadius` | `CornerRadius` | `5` | 进度条圆角半径 |
| `GradientStart` | `Color` | `#0096E6` (0,150,230) | 进度渐变起始色 |
| `GradientEnd` | `Color` | `#0078D4` (0,120,212) | 进度渐变结束色（与 ProgressRing 一致） |
| `TrackBackground` | `Color` | `#0A000000` (10,0,0,0) | 轨道背景色（与 ProgressRing 一致） |
| `IsIndeterminate` | `bool` | `false` | 不确定模式（跑马灯动画） |
| `Minimum` | `double` | `0` | 最小值 |
| `Maximum` | `double` | `100` | 最大值 |
| `Value` | `double` | `0` | 当前进度值 |
| `Background` | `Brush` | `null` | 若设置，使用纯色替代渐变色 |

#### 示例代码

```xml
<!-- 基础进度条 -->
<ui:UI4ProgressBar Value="50" Maximum="100" Minimum="0" 
                   Width="200" Height="6" />

<!-- 纯色进度条（Background 覆盖渐变色） -->
<ui:UI4ProgressBar Value="50"  
                   Maximum="100" Minimum="0" 
                   Width="200" Height="6" 
                   Background="Red" />

<!-- 自定义渐变色进度条 -->
<ui:UI4ProgressBar Value="50"  
                   Maximum="100" Minimum="0" 
                   Width="200" Height="6" 
                   GradientStart="#FF55FF00" 
                   GradientEnd="#FF0016FF" />

<!-- 自定义轨道颜色 -->
<ui:UI4ProgressBar Value="75" 
                   Maximum="100" 
                   TrackBackground="#FFE0E0E0"
                   Width="200" Height="6" />

<!-- 不确定模式 -->
<ui:UI4ProgressBar IsIndeterminate="True" 
                   Width="200" Height="6" />
```

#### 特性说明

- **水平渐变填充**: 进度填充部分默认使用从左到右的渐变色
- **Background 覆盖**: 若设置了 `Background` 属性，则使用纯色替代渐变色
- **圆角外观**: 轨道和进度均为圆角，边界处有正确的圆角裁剪
- **高度可调整**: 通过 `Height` 属性调整粗细
- **不确定模式**: 设置 `IsIndeterminate="True"` 启用跑马灯滑动动画
- **色彩统一**: 默认配色与 UI4ProgressRing 保持一致，视觉协调

---

### UI4ProgressRing 环形进度

环形进度指示器，支持确定模式（显示具体数值）和不确定模式（旋转动画）。

**继承自**: `ContentControl`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `IsActive` | `bool` | `true` | 是否激活（显示） |
| `IsIndeterminate` | `bool` | `true` | 是否为不确定模式 |
| `Minimum` | `double` | `0.0` | 最小值 |
| `Maximum` | `double` | `100.0` | 最大值 |
| `Value` | `double` | `0.0` | 当前值 |
| `RingBackground` | `Brush` | `#0A000000` (10,0,0,0) | 环形背景色 |
| `RingForeground` | `Brush` | `#0078D4` (0,120,212) | 环形前景色（进度色） |
| `RingThickness` | `double` | `6.0` | 环形线条粗细 |
| `ShowValueText` | `bool` | `true` | 是否显示数值文字 |
| `ValueFontSize` | `double` | `30.0` | 数值文字大小 |
| **动画属性** | | | |
| `AnimatedValue` | `double` | `0.0` | 内部动画驱动值 |
| `StartupAnimationDuration` | `double` | `0.5` | 启动动画时长（秒） |
| `EnableStartupAnimation` | `bool` | `true` | 是否启用启动动画 |

#### 继承属性

同时继承 `ContentControl` 的所有属性，如 `Foreground`、`Width`、`Height` 等。

#### 示例代码

```xml
<!-- 不确定模式（旋转动画） -->
<ui:UI4ProgressRing IsActive="True" 
                    IsIndeterminate="True" 
                    Width="80" Height="80" />

<!-- 确定模式（显示数值） -->
<ui:UI4ProgressRing IsIndeterminate="False" 
                    Foreground="Red" 
                    ValueFontSize="20" 
                    ShowValueText="True" 
                    Value="50" 
                    Maximum="150" />

<!-- 渐变色环形进度 -->
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

#### 特性说明

- **双模式**: 支持 `IsIndeterminate` 不确定模式（旋转动画）和确定模式（数值进度）
- **渐变环形**: `RingForeground` 支持 `Brush`，可设置渐变色
- **数值显示**: 中心可显示当前数值
- **启动动画**: 加载时从 0 过渡到目标值的平滑动画
- **圆头端点**: 环形两端为圆形端点

---

### UI4Slider 滑块

带渐变色轨道和数值显示的滑块控件。

**继承自**: `Slider`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `CornerRadius` | `CornerRadius` | `4` | 轨道圆角半径 |
| `GradientStart` | `Color` | `#2563EB` (37,99,235) | 渐变起始色 |
| `GradientEnd` | `Color` | `#9333EA` (147,51,234) | 渐变结束色 |
| `TrackBackground` | `Color` | `White` (255,255,255) | 轨道背景色 |
| `ThumbSize` | `double` | `16` | 滑块按钮尺寸 |
| `IsValueVisible` | `bool` | `true` | 是否显示底部数值标签 |

#### 继承属性

同时继承 `Slider` 的所有属性，如 `Value`、`Minimum`、`Maximum`、`Width`、`Height`、`IsDirectionReversed` 等。

#### 示例代码

```xml
<!-- 基础滑块 -->
<ui:UI4Slider Value="50" Maximum="100" Minimum="0" 
              Width="200" Height="20" />

<!-- 不显示数值 -->
<ui:UI4Slider Value="50" Maximum="200" Minimum="0" 
              Width="200" Height="20" 
              IsValueVisible="False" 
              GradientStart="#FFFFF900" 
              GradientEnd="Red" />

<!-- 自定义滑块大小 -->
<ui:UI4Slider Value="30" 
              ThumbSize="20"
              Width="300" />
```

#### 特性说明

- **渐变轨道**: 已填充部分使用渐变色
- **数值标签**: 底部显示最小值、最大值、当前值（可通过 `IsValueVisible` 关闭）
- **滑块提示**: 滑块 ToolTip 显示当前整数值
- **自定义滑块**: 可通过 `ThumbSize` 调整滑块大小

---

### UI4CircleSlider 环形滑块

可交互的环形滑块控件，支持鼠标拖动调整数值。

**继承自**: `ContentControl`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `Value` | `double` | `0.0` | 当前值 |
| `Minimum` | `double` | `0.0` | 最小值 |
| `Maximum` | `double` | `100.0` | 最大值 |
| `SmallChange` | `double` | `1.0` | 步长（吸附值） |
| `RingThickness` | `double` | `8.0` | 环形线条粗细 |
| `RingForeground` | `Brush` | `#0078D4` (0,120,212) | 环形前景色（进度色） |
| `RingBackground` | `Brush` | `#0A000000` (10,0,0,0) | 环形背景色 |
| `ShowValueText` | `bool` | `false` | 是否显示数值文字 |
| `ValueFontSize` | `double` | `30.0` | 数值文字大小 |
| `AnimationDuration` | `double` | `0.5` | 加载动画时长（秒） |

#### 继承属性

同时继承 `ContentControl` 的所有属性，如 `Foreground`、`Width`、`Height`、`Background` 等。

#### 示例代码

```xml
<!-- 基础环形滑块 -->
<ui:UI4CircleSlider Value="60" ShowValueText="True" />

<!-- 自定义尺寸和颜色 -->
<ui:UI4CircleSlider Width="200" Height="200" 
                    RingThickness="12" 
                    Maximum="360" 
                    ValueFontSize="60" 
                    Value="60" 
                    ShowValueText="True" 
                    Foreground="Green" />

<!-- 渐变色环形滑块 -->
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

#### 特性说明

- **可交互拖动**: 鼠标左键拖动环形滑块调整数值
- **步长吸附**: 拖动结束后自动吸附到 `SmallChange` 的整数倍
- **渐变支持**: `RingForeground` 支持画笔，可设置渐变色
- **滑块按钮**: 带白色描边的圆形滑块
- **加载动画**: 初始加载时从最小值平滑过渡到设定值
- **圆头端点**: 环形两端为圆形端点

---

### UI4Panel 面板容器

带阴影效果和悬停缩放动画的容器面板，可包裹任何内容。

**继承自**: `ContentControl`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `CornerRadius` | `CornerRadius` | `12` | 面板圆角半径 |
| `BorderBrush` | `Color` | `#3C788CC8` (60,120,140,200) | 边框颜色 |
| `HoverBorderBrush` | `SolidColorBrush` | `#6366F1` | 悬停时边框颜色 |
| `BorderThickness` | `Thickness` | `1` | 边框粗细 |
| `ContentPadding` | `Thickness` | `0` | 内容内边距 |
| `HoverAnimationDuration` | `Duration` | `00:00:00.200` | 悬停动画时长 |
| `HoverScale` | `double` | `1.01` | 悬停缩放比例 |
| **阴影属性** | | | |
| `ShadowDepth` | `double` | `0.0` | 阴影深度（偏移量） |
| `ShadowBlurRadius` | `double` | `15.0` | 阴影模糊半径 |
| `ShadowOpacity` | `double` | `0.1` | 阴影不透明度 |
| `ShadowColor` | `Color` | `Black` | 阴影颜色 |

#### 继承属性

同时继承 `ContentControl` 的所有属性，如 `Background`、`Content`、`Width`、`Height`、`Margin`、`Padding` 等。

#### 示例代码

```xml
<!-- 基础面板 -->
<ui:UI4Panel Width="300" Height="200">
    <TextBlock Text="面板内容" HorizontalAlignment="Center" VerticalAlignment="Center"/>
</ui:UI4Panel>

<!-- 带阴影和悬停缩放的面板 -->
<ui:UI4Panel Width="800" Height="600" 
             ShadowDepth="15" 
             ShadowOpacity="0.6" 
             HoverScale="1.1">
    <Grid Margin="20">
        <TextBlock Text="带阴影和悬停效果的面板"/>
    </Grid>
</ui:UI4Panel>

<!-- 透明背景面板（仅作为动画容器） -->
<ui:UI4Panel ShadowDepth="8" 
             ShadowOpacity="0.4" 
             HoverScale="1.0" 
             BorderThickness="0" 
             Background="Transparent">
    <!-- 内容 -->
</ui:UI4Panel>
```

#### 特性说明

- **阴影效果**: 通过 `Shadow*` 属性调整投影效果
- **悬停缩放**: 鼠标悬停时平滑放大（`HoverScale` 控制缩放比例）
- **边框颜色动画**: 悬停时边框颜色平滑过渡
- **中心缩放**: 缩放以面板中心为原点
- **缓动函数**: 使用 Cubic EaseOut 缓动，动画更自然

---

### UI4Pivot 选项卡

选项卡/标签页控件，支持平滑的内容滑动切换动画。

**包含两个类**:
- `UI4Pivot` - 主选项卡控件
- `UI4PivotItem` - 选项卡项

#### UI4Pivot 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `SelectedItemForeground` | `Color` | `#2563EB` (37,99,235) | 选中项文字颜色 |
| `ItemFontSize` | `double` | `20.0` | 未选中项字体大小 |
| `SelectedFontSize` | `double` | `25.0` | 选中项字体大小 |
| `BrandFontSize` | `double` | `22.0` | 品牌项字体大小 |
| `ItemFontWeight` | `FontWeight` | `Normal` | 未选中项字体粗细 |
| `BrandFontWeight` | `FontWeight` | `SemiBold` | 品牌项字体粗细 |
| `ItemForeground` | `Color` | `#DC000000` (220,0,0,0) | 未选中项文字颜色 |
| `ItemHoverForeground` | `Color` | `#DC000000` (220,0,0,0) | 悬停项文字颜色 |
| `ItemPadding` | `Thickness` | `10,8,10,8` | 选项卡内边距 |
| `ItemMargin` | `Thickness` | `5,0,5,0` | 选项卡外边距 |

#### UI4PivotItem 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `Header` | `object` |  | 选项卡标题 |
| `IsBrand` | `bool` | `false` | 是否为品牌项（特殊样式） |
| `Content` | `object` |  | 选项卡内容 |

#### 继承属性

`UI4Pivot` 继承自 `Selector`，支持 `SelectedIndex`、`SelectedItem`、`Items`、`SelectionChanged` 事件等。

#### 示例代码

```xml
<!-- 基础选项卡 -->
<ui:UI4Pivot x:Name="pivot" 
             ItemFontSize="18" 
             SelectionChanged="pivot_SelectionChanged">
    <ui:UI4PivotItem Header="首页">
        <TextBlock Text="首页内容"/>
    </ui:UI4PivotItem>
    <ui:UI4PivotItem Header="设置">
        <TextBlock Text="设置内容"/>
    </ui:UI4PivotItem>
    <ui:UI4PivotItem Header="关于">
        <TextBlock Text="关于内容"/>
    </ui:UI4PivotItem>
</ui:UI4Pivot>

<!-- 自定义选中颜色 -->
<ui:UI4Pivot SelectedItemForeground="Black" Margin="0,0,0,20">
    <ui:UI4PivotItem Header="选项1">
        <TextBlock Text="内容1"/>
    </ui:UI4PivotItem>
    <ui:UI4PivotItem Header="选项2">
        <TextBlock Text="内容2"/>
    </ui:UI4PivotItem>
</ui:UI4Pivot>
```

#### 特性说明

- **滑动切换动画**: 内容切换时带左右滑动 + 淡入淡出动画
- **选中放大**: 选中项字体自动放大并加粗
- **品牌项**: `IsBrand="True"` 的项使用品牌样式
- **水平排列**: 选项卡水平排列在顶部
- **可滚动 Header**: 标签超出宽度时出现横向滚动条（UI4ScrollViewer）

---

### UI4Tab 浏览器标签

浏览器风格的标签控件，支持关闭按钮、新增按钮、图标显示，可自定义顶部背景色。

**包含两个类**:
- `UI4Tab` - 主标签控件
- `UI4TabItem` - 标签项

#### UI4Tab 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `HeaderBackground` | `Color` | `#E6E6EB` (230,230,235) | 顶部 header 区域背景色 |
| `TabBackground` | `Color` | `Transparent` | 未选中标签背景色 |
| `TabSelectedBackground` | `Color` | `White` | 选中标签背景色 |
| `TabHoverBackground` | `Color` | `#1E000000` | 悬停标签背景色 |
| `TabForeground` | `Color` | `#C8000000` | 未选中标签文字颜色 |
| `TabSelectedForeground` | `Color` | `#FF000000` | 选中标签文字颜色 |
| `CloseButtonColor` | `Color` | `#96000000` | 关闭按钮颜色 |
| `TabFontSize` | `double` | `13` | 标签文字大小 |
| `TabPadding` | `Thickness` | `12,8,8,8` | 标签内边距 |
| `ShowAddButton` | `bool` | `true` | 是否显示右侧新增按钮 |
| `AddButtonColor` | `Color` | `#96000000` | 新增按钮颜色 |
| `TabCornerRadius` | `double` | `6` | 标签项圆角半径 |

#### UI4TabItem 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `Header` | `object` | | 标签头部内容 |
| `TextIcon` | `string` | `null` | 文字图标（如 Segoe MDL2 Assets 字符） |
| `TextIconFontFamily` | `FontFamily` | `Segoe MDL2 Assets` | 文字图标字体 |
| `ImageSource` | `ImageSource` | `null` | 图片图标（**优先显示**，优先于 TextIcon） |
| `IconSize` | `double` | `16` | 图标大小 |
| `IsClosable` | `bool` | `true` | 是否显示关闭按钮 |
| `Content` | `object` | | 标签内容 |

#### 事件

| 事件名 | 参数类型 | 说明 |
|-------|---------|------|
| `AddTab` | `RoutedEventArgs` | 点击新增按钮时触发 |
| `CloseTab` | `TabCloseRoutedEventArgs` | 点击关闭按钮时触发，`e.Handled = true` 可取消关闭 |

`TabCloseRoutedEventArgs` 属性：
- `TabItem` (`UI4TabItem`) - 被关闭的标签项

#### 继承属性

`UI4Tab` 继承自 `Selector`，支持 `SelectedIndex`、`SelectedItem`、`Items`、`SelectionChanged` 事件等。

#### 示例代码

```xml
<!-- 基础标签控件 -->
<ui:UI4Tab x:Name="MyTab"
           AddTab="MyTab_AddTab"
           CloseTab="MyTab_CloseTab">
    
    <!-- 文字图标标签 -->
    <ui:UI4TabItem Header="首页" TextIcon="&#xE80F;">
        <Grid Background="White">
            <TextBlock Text="首页内容"/>
        </Grid>
    </ui:UI4TabItem>
    
    <!-- 图片图标标签 -->
    <ui:UI4TabItem Header="文档" ImageSource="/Images/doc.png">
        <Grid Background="White">
            <TextBlock Text="文档内容"/>
        </Grid>
    </ui:UI4TabItem>
    
    <!-- 不可关闭的标签 -->
    <ui:UI4TabItem Header="设置" TextIcon="&#xE713;" IsClosable="False">
        <Grid Background="White">
            <TextBlock Text="设置内容"/>
        </Grid>
    </ui:UI4TabItem>
    
</ui:UI4Tab>

<!-- 自定义颜色 -->
<ui:UI4Tab HeaderBackground="#F0F0F0"
           TabSelectedBackground="White"
           CloseButtonColor="Red"
           ShowAddButton="False">
    ...
</ui:UI4Tab>
```

后台代码示例：

```csharp
private int _tabCount = 3;

private void MyTab_AddTab(object sender, RoutedEventArgs e)
{
    _tabCount++;
    var newTab = new UI4TabItem
    {
        Header = $"新标签 {_tabCount}",
        TextIcon = "\uE80F",
        Content = new TextBlock { Text = $"第 {_tabCount} 个标签内容" }
    };
    MyTab.Items.Add(newTab);
    MyTab.SelectedIndex = MyTab.Items.Count - 1;
}

private void MyTab_CloseTab(object sender, TabCloseRoutedEventArgs e)
{
    // 阻止关闭最后一个标签
    if (MyTab.Items.Count <= 1)
    {
        e.Handled = true; // 取消关闭
    }
}
```

#### 特性说明

- **浏览器风格**: 浏览器标签设计，带圆角和关闭按钮
- **双图标模式**: 图片图标（`ImageSource`）优先显示，无图片时显示文字图标（`TextIcon`）
- **新增按钮**: 右侧 "+" 按钮可添加新标签（可开关）
- **关闭按钮**: 每个标签带 × 关闭按钮（可单独控制显示）
- **可自定义 Header**: `HeaderBackground` 控制顶部栏背景色
- **内容切换动画**: 切换标签时滑动 + 淡入淡出动画
- **可滚动 Header**: 标签超出宽度时出现横向滚动条
- **可取消关闭**: 在 `CloseTab` 事件中设置 `e.Handled = true` 可阻止关闭

---

### UI4NavigationView 导航视图

侧边栏导航控件，支持可折叠侧边栏、内容切换动画等。

![1](https://store-images.s-microsoft.com/image/apps.53158.14402085032895111.4e651371-d0df-4a15-9e7b-7fa694cf7844.9d8e483a-32c9-433e-96b6-9f736e874cf1)

**包含两个类**:
- `UI4NavigationView` - 主导航视图
- `UI4NavigationViewItem` - 导航项

#### UI4NavigationView 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `LeftPanelBackground` | `Brush` | `null` | 左侧面板背景 |
| `LeftPanelWidth` | `double` | `200.0` | 左侧面板展开宽度 |
| `ItemHoverColor` | `Color` | `White` | 列表项悬停背景色 |
| `ItemPressedBackground` | `Color` | `#0C000000` (12,0,0,0) | 列表项按下背景色 |
| `ItemPressedForeground` | `Color` | `Black` | 列表项按下前景色 |
| `ItemHoverForeground` | `Color` | `Black` | 列表项悬停前景色 |
| `ItemForeground` | `Brush` | `Black` | 列表项正常前景色 |
| `Header` | `string` | `null` | 导航视图标题 |
| `SelectedItemBackground` | `Brush` | `null` | 选中项背景 |
| `SelectedItem` | `UI4NavigationViewItem` | `null` | 当前选中项 |

#### UI4NavigationViewItem 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `Header` | `string` |  | 导航项标题 |
| `ImageSource` | `ImageSource` |  | 图标图片源 |
| `TextIcon` | `string` |  | 文本图标（如 Segoe MDL2 Assets 字符） |
| `TextIconFontFamily` | `FontFamily` | `null` | 文本图标字体 |
| `Content` | `object` |  | 导航项内容 |

#### 示例代码

```xml
<!-- 基础导航视图 -->
<ui:UI4NavigationView Header="NavigationView">
    <ui:UI4NavigationViewItem ImageSource="/1.png" Header="代码">
        <TextBlock Text="代码页面内容"/>
    </ui:UI4NavigationViewItem>
    <ui:UI4NavigationViewItem TextIcon="&#xE104;" 
                              TextIconFontFamily="Segoe MDL2 Assets" 
                              Header="属性">
        <TextBlock Text="属性页面内容"/>
    </ui:UI4NavigationViewItem>
</ui:UI4NavigationView>
```

#### 特性说明

- **可折叠侧边栏**: 点击菜单按钮可折叠/展开侧边栏
- **双图标模式**: 支持图片图标（`ImageSource`）和文本图标（`TextIcon`）
- **内容切换动画**: 切换导航项时内容上下滑动淡入
- **自定义菜单项颜色**: 悬停、按下、选中状态均可配置
- **内置列表**: 基于 `UI4ListBox` 实现导航列表

---

### UI4ListBox 列表框

高度可定制的列表框控件，支持多种列表样式类型（无样式、圆点、数字序号）。

**继承自**: `ListBox`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `CornerRadius` | `CornerRadius` | `8` | 列表外框圆角半径 |
| `BorderNormalColor` | `Color` | `#2563EB` (37,99,235) | 边框颜色 |
| `PanelBackground` | `Brush` | `White` | 列表背景色 |
| `TextColor` | `Color` | `#FF000000` (0,0,0) | 文字颜色 |
| `ItemPadding` | `Thickness` | `12,8,12,8` | 列表项内边距 |
| `ItemCornerRadius` | `CornerRadius` | `8` | 列表项圆角半径 |
| `HoverBackground` | `Color` | `#0AF5FFFF` (10,245,255,255) | 悬停项背景色 |
| `HoverForeground` | `Color` | `#DC000000` (220,0,0,0) | 悬停项文字颜色 |
| `PressedBackground` | `Color` | `#2563EB` (37,99,235) | 选中/按下项背景色 |
| `PressedForeground` | `Color` | `#FFFFFF` (255,255,255) | 选中/按下项文字颜色 |
| `ListStyleType` | `ListStyleType` | `None` | 列表样式类型 |
| `NumberCircleBackground` | `Brush` | `#2563EB` (37,99,235) | 数字序号圆圈背景 |

#### 枚举类型: ListStyleType

| 值 | 说明 |
|----|------|
| `None` | 无样式（默认） |
| `Disc` | 圆点样式 |
| `Number` | 数字序号样式（带圆圈背景） |

#### 继承属性

同时继承 `ListBox` 的所有属性，如 `Items`、`ItemsSource`、`SelectedIndex`、`SelectedItem`、`ItemTemplate`、`SelectionChanged` 事件等。

#### 示例代码

```xml
<!-- 普通列表 -->
<ui:UI4ListBox Width="200" Height="220">
    <ListBoxItem>Item 1</ListBoxItem>
    <ListBoxItem>Item 2</ListBoxItem>
    <ListBoxItem>Item 3</ListBoxItem>
</ui:UI4ListBox>

<!-- 圆点样式列表 -->
<ui:UI4ListBox ListStyleType="Disc" 
               HoverForeground="Black" 
               HoverBackground="#0C000000"
               Width="200" Height="220">
    <ListBoxItem>Item 1</ListBoxItem>
    <ListBoxItem>Item 2</ListBoxItem>
    <ListBoxItem>Item 3</ListBoxItem>
</ui:UI4ListBox>

<!-- 数字序号列表 -->
<ui:UI4ListBox ListStyleType="Number" 
               NumberCircleBackground="Green"
               Width="200" Height="220">
    <ListBoxItem>Item 1</ListBoxItem>
    <ListBoxItem>Item 2</ListBoxItem>
    <ListBoxItem>Item 3</ListBoxItem>
</ui:UI4ListBox>

<!-- 渐变色数字圆圈 -->
<ui:UI4ListBox ListStyleType="Number" Width="200" Height="220">
    <ui:UI4ListBox.NumberCircleBackground>
        <LinearGradientBrush EndPoint="1,0.5" StartPoint="0,0.5">
            <GradientStop Color="#FF002BFF" Offset="0.003"/>
            <GradientStop Color="#FFC800FF" Offset="1"/>
        </LinearGradientBrush>
    </ui:UI4ListBox.NumberCircleBackground>
    <ListBoxItem>Item 1</ListBoxItem>
</ui:UI4ListBox>

<!-- 自定义数据模板的列表 -->
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

#### 特性说明

- **三种列表样式**: 无样式、圆点、数字序号
- **数字圆圈渐变色**: `NumberCircleBackground` 支持 `Brush`，可设置渐变色
- **自定义滚动条**: 内置自动隐藏的滚动条，宽度 10px（更宽更好用）
- **悬停/选中效果**: 可自定义各状态的背景和文字颜色
- **数据模板支持**: 支持 `ItemTemplate` 自定义项外观

---

### UI4ListView 列表视图

卡片式列表视图，每个项以卡片形式展示，带阴影和悬停缩放动画。

![Image](https://store-images.s-microsoft.com/image/apps.30115.14402085032895111.92211ece-02cd-474f-a3b1-9dec5d75adbe.d2adeea6-5a7f-42fd-865e-e619d66cf0e9)

**继承自**: `ListBox`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `ItemWidth` | `double` | `NaN` | 卡片项宽度 |
| `ItemHeight` | `double` | `NaN` | 卡片项高度 |
| `ItemCornerRadius` | `CornerRadius` | `12` | 卡片圆角半径 |
| `ItemBackground` | `Brush` | `#0AFFFFFF` (10,255,255,255) | 卡片背景色 |
| `ItemBorderBrush` | `Color` | `#3C788CC8` (60,120,140,200) | 卡片边框颜色 |
| `ItemHoverBorderBrush` | `Color` | `#3CDCF5` (60,220,255) | 悬停时边框颜色 |
| `ItemBorderThickness` | `Thickness` | `1` | 卡片边框粗细 |
| `ItemPadding` | `Thickness` | `0` | 卡片内容内边距 |
| `ItemMargin` | `Thickness` | `10` | 卡片外边距 |
| `HoverAnimationDuration` | `Duration` | `00:00:00.200` | 悬停动画时长 |
| `HoverScale` | `double` | `1.03` | 悬停缩放比例 |
| **阴影属性** | | | |
| `ShadowColor` | `Color` | `#23000000` (35,0,0,0) | 阴影颜色 |
| `ShadowBlurRadius` | `double` | `12.0` | 阴影模糊半径 |
| `ShadowDepth` | `double` | `0.0` | 阴影深度 |
| `ShadowOpacity` | `double` | `0.35` | 阴影不透明度 |

#### 继承属性

同时继承 `ListBox` 的所有属性，如 `ItemsSource`、`ItemTemplate`、`SelectedIndex`、`SelectionChanged` 事件等。

#### 示例代码

```xml
<!-- 数据绑定列表视图 -->
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

#### 特性说明

- **卡片式布局**: 每一项都是带阴影的卡片
- **悬停动画**: 悬停时卡片边框变色 + 缩放
- **阴影效果**: 每张卡片都有投影效果
- **自定义滚动条**: 内置自动隐藏的滚动条，宽度 10px
- **完整的数据绑定支持**: 支持 `ItemsSource` 和 `ItemTemplate`

---

### UI4GridView 网格视图

网格布局的卡片视图，自动计算列数，响应式布局。

![1](https://store-images.s-microsoft.com/image/apps.56425.14402085032895111.92211ece-02cd-474f-a3b1-9dec5d75adbe.adbe738a-aa09-4828-8924-8cb12290feae)

**继承自**: `ListBox`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `ItemWidth` | `double` | `300.0` | 卡片项宽度 |
| `ItemHeight` | `double` | `220.0` | 卡片项高度 |
| `ItemCornerRadius` | `CornerRadius` | `12` | 卡片圆角半径 |
| `ItemBackground` | `Brush` | `White` (255,255,255) | 卡片背景色 |
| `ItemBorderBrush` | `Color` | `#3C788CC8` (60,120,140,200) | 卡片边框颜色 |
| `ItemHoverBorderBrush` | `Color` | `#3CDCF5` (60,220,255) | 悬停时边框颜色 |
| `ItemBorderThickness` | `Thickness` | `1` | 卡片边框粗细 |
| `ItemPadding` | `Thickness` | `0` | 卡片内容内边距 |
| `ItemMargin` | `Thickness` | `10` | 卡片外边距 |
| `HoverAnimationDuration` | `Duration` | `00:00:00.200` | 悬停动画时长 |
| `HoverScale` | `double` | `1.03` | 悬停缩放比例 |
| **阴影属性** | | | |
| `ShadowColor` | `Color` | `#23000000` (35,0,0,0) | 阴影颜色 |
| `ShadowBlurRadius` | `double` | `12.0` | 阴影模糊半径 |
| `ShadowDepth` | `double` | `0.0` | 阴影深度 |
| `ShadowOpacity` | `double` | `0.35` | 阴影不透明度 |

#### 继承属性

同时继承 `ListBox` 的所有属性，如 `ItemsSource`、`ItemTemplate`、`SelectedIndex`、`SelectionChanged` 事件等。

#### 示例代码

```xml
<!-- 数据绑定网格视图 -->
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

<!-- 首页功能卡片示例 -->
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

#### 特性说明

- **响应式网格**: 根据容器宽度自动计算列数
- **卡片式布局**: 每一项都是带阴影的卡片
- **悬停动画**: 悬停时卡片边框变色 + 缩放
- **阴影效果**: 每张卡片都有投影效果
- **自定义滚动条**: 内置自动隐藏的滚动条，宽度 10px
- **基于 UniformGrid**: 使用均匀网格布局

---

### UI4ScrollViewer 滚动视图

自定义样式的滚动视图控件，内置自动隐藏的滚动条和平滑滚动动画。

**继承自**: `ScrollViewer`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `IsSmoothScrollEnabled` | `bool` | `true` | 是否启用平滑滚动动画 |

#### 公共方法

| 方法名 | 返回值 | 说明 |
|-------|--------|------|
| `SmoothScrollToVerticalOffset(double offset)` | `void` | 平滑滚动到指定垂直位置 |
| `SmoothScrollToHorizontalOffset(double offset)` | `void` | 平滑滚动到指定水平位置 |

#### 特性说明

- **自动隐藏滚动条**: 滚动时淡入，停止 1.5 秒后淡出
- **圆角滑块**: 滚动条滑块为圆角矩形
- **更宽滚动条**: 宽度 10px（原 5px + 增加 5px），更易点击和拖动
- **悬停显示**: 鼠标悬停在滚动条上时保持显示
- **平滑滚动**: 鼠标滚轮滚动使用三次缓出动画（200ms），手感更丝滑
- **平滑滚动 API**: `SmoothScrollToVerticalOffset` / `SmoothScrollToHorizontalOffset` 支持代码调用平滑滚动

#### 示例代码

```xml
<!-- 基础滚动视图 -->
<ui:UI4ScrollViewer Width="400" Height="200">
    <StackPanel Margin="20" Height="300">
        <TextBlock Text="滚动内容..."/>
    </StackPanel>
</ui:UI4ScrollViewer>

<!-- 带文本的滚动视图 -->
<ui:UI4ScrollViewer>
    <StackPanel VerticalAlignment="Top">
        <ui:UI4TextBlock FontSize="20" TextWrapping="Wrap" 
                         FontWeight="Bold" 
                         Content="UI4ScrollViewer 是对系统 ScrollViewer 的美化，使其更现代流畅。"/>
        <!-- 更多内容 -->
    </StackPanel>
</ui:UI4ScrollViewer>
```

#### 继承属性

同时继承 `ScrollViewer` 的所有属性，如 `Content`、`HorizontalScrollBarVisibility`、`VerticalScrollBarVisibility`、`Width`、`Height`、`Padding` 等。

---

### UI4MessageBox 消息框

自定义样式的消息对话框，带入场/出场动画、可调整大小等特性。

**继承自**: `Window`

#### 静态方法

| 方法名 | 返回值 | 说明 |
|-------|--------|------|
| `Show(string content, string title = "Notice", double width = 480, double height = 280)` | `bool?` | 显示消息框，返回对话框结果 |

#### 构造函数

| 构造函数 | 说明 |
|---------|------|
| `UI4MessageBox(string title, string content)` | 创建消息框实例 |

#### 示例代码

```csharp
// 简单调用
UI4MessageBox.Show("操作成功！", "提示");

// 自定义尺寸
UI4MessageBox.Show("这是一条消息内容", "通知", 480, 280);

// 确认/取消判断
bool? result = UI4MessageBox.Show("确定要删除吗？", "确认");
if (result == true)
{
    // 用户点击了确定
}
else
{
    // 用户点击了取消
}
```

#### 特性说明

- **入场动画**: 从下方滑入 + 缩放 + 模糊消散
- **出场动画**: 下滑 + 缩小 + 模糊 + 淡出
- **无边框窗口**: 自定义窗口样式，无系统标题栏
- **可拖动**: 拖拽标题栏移动窗口
- **可调整大小**: 8 个方向均可调整窗口大小
- **OK / Cancel 按钮**: 确定和取消两个操作按钮

---

### UI4CodeEditor 代码编辑器

带 C# 语法高亮的代码编辑器控件。

**继承自**: `RichTextBox`

#### 可设置属性

| 属性名 | 类型 | 默认值 | 说明 |
|-------|------|--------|------|
| `Code` | `string` | `""` | 代码文本内容（双向绑定） |

#### 继承属性

同时继承 `RichTextBox` 的所有属性，如 `Background`、`Foreground`、`FontFamily`、`FontSize`、`Width`、`Height`、`Padding` 等。

#### 公共方法

| 方法名 | 返回值 | 说明 |
|-------|--------|------|
| `HighlightSyntax()` | `void` | 手动触发语法高亮 |

#### 语法高亮

内置 C# 语法高亮，支持以下类型：

| 类型 | 颜色 | 说明 |
|------|------|------|
| 默认文本 | `#D4D4D4` (212,212,212) | 普通文字 |
| 关键字 | `#569CD6` (86,156,214) | C# 关键字（class, int, if 等） |
| 字符串 | `#CE9178` (206,145,120) | 字符串字面量 |
| 注释 | `#6A9955` (106,153,85) | 单行和多行注释 |
| 数字 | `#B5CEA8` (181,206,168) | 数字字面量 |

#### 示例代码

```xml
<!-- 基础代码编辑器 -->
<ui:UI4CodeEditor x:Name="codeEditor" Width="500" Height="200" />

<!-- 设置代码内容 -->
<ui:UI4CodeEditor Code="{Binding CodeContent}" 
                  Width="500" 
                  HorizontalAlignment="Left" />

<!-- 小型代码展示 -->
<ui:UI4CodeEditor Height="60" 
                   Width="500" 
                   HorizontalAlignment="Left" 
                   Margin="10,0,0,20"/>
```

#### 特性说明

- **C# 语法高亮**: 自动高亮关键字、字符串、注释、数字
- **深色主题**: 默认深色背景，适合代码显示
- **等宽字体**: 默认使用 Consolas 字体
- **自定义右键菜单**: 支持撤销、剪切、复制、粘贴、删除、全选
- **自动宽度**: 未设置宽度时根据内容自动调整
- **双向绑定**: `Code` 属性支持双向数据绑定

---

## 附录：命名空间引用

在所有 XAML 文件中使用前，请确保已引入命名空间：

```xml
<Window xmlns:ui="clr-namespace:StartUI4Controls;assembly=StartUI4Controls"
        ...>
    <!-- 控件使用 -->
</Window>
```

完整示例：

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

## 许可证

© KS.STUDIO - StartUI4.WPF v1.0.6
