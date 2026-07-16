using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Globalization;

namespace StartUI4Controls
{
    public class UI4CodeEditor : RichTextBox
    {
        private static readonly Brush DefaultBrush = new SolidColorBrush(Color.FromRgb(212, 212, 212));
        private static readonly Brush KeywordBrush = new SolidColorBrush(Color.FromRgb(86, 156, 214));
        private static readonly Brush StringBrush = new SolidColorBrush(Color.FromRgb(206, 145, 120));
        private static readonly Brush CommentBrush = new SolidColorBrush(Color.FromRgb(106, 153, 85));
        private static readonly Brush NumberBrush = new SolidColorBrush(Color.FromRgb(181, 206, 168));

        private static readonly Regex SyntaxRegex = new Regex(
            @"(?<comment>//[^\n]*|/\*.*?\*/)|" +
            @"(?<string>""(?:[^""\\]|\\.)*"")|" +
            @"(?<keyword>\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while)\b)|" +
            @"(?<number>\b\d+\.?\d*([eE][+-]?\d+)?\b)",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

        public string Code
        {
            get => (string)GetValue(CodeProperty);
            set => SetValue(CodeProperty, value);
        }

        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register(
                nameof(Code),
                typeof(string),
                typeof(UI4CodeEditor),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnCodeChanged));

        private static void OnCodeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var editor = (UI4CodeEditor)d;
            string newCode = e.NewValue as string ?? string.Empty;
            string currentText = editor.GetDocumentText();

            if (currentText == newCode)
                return;

            editor._skipTextChanged = true;
            editor.SetDocumentText(newCode);
            editor.HighlightSyntax();
        }

        private bool _skipTextChanged;
        private bool _isUpdating;

        private UI4ContextMenu _contextMenu;

        public UI4CodeEditor()
        {
            Background = new SolidColorBrush(Color.FromRgb(30, 30, 30));
            Foreground = DefaultBrush;
            FontFamily = new FontFamily("Consolas");
            FontSize = 14;
            Padding = new Thickness(5);

            this.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
            this.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            TextChanged += OnTextChanged;
            Loaded += UI4CodeEditor_Loaded;
        }

        private void UI4CodeEditor_Loaded(object sender, RoutedEventArgs e)
        {
            InitCustomMenu();
        }

        private void InitCustomMenu()
        {
            if (_contextMenu != null) return;

            _contextMenu = new UI4ContextMenu
            {
                Width = 170
            };

            _contextMenu.AddItem(UI4MenuItemType.Undo,
                () => { if (CanUndo) Undo(); },
                () => CanUndo);

            _contextMenu.AddItem(UI4MenuItemType.Cut,
                () => { if (!string.IsNullOrEmpty(Selection.Text)) Cut(); },
                () => !string.IsNullOrEmpty(Selection.Text));

            _contextMenu.AddItem(UI4MenuItemType.Copy,
                () => { if (!string.IsNullOrEmpty(Selection.Text)) Copy(); },
                () => !string.IsNullOrEmpty(Selection.Text));

            _contextMenu.AddItem(UI4MenuItemType.Paste,
                () => { if (Clipboard.ContainsText()) Paste(); },
                () => Clipboard.ContainsText());

            _contextMenu.AddItem(UI4MenuItemType.Delete,
                () => { if (!string.IsNullOrEmpty(Selection.Text)) Selection.Text = string.Empty; },
                () => !string.IsNullOrEmpty(Selection.Text));

            _contextMenu.AddItem(UI4MenuItemType.SelectAll,
                () => SelectAll());

            ContextMenu = null;
            _contextMenu.Attach(this);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_skipTextChanged)
            {
                _skipTextChanged = false;
                return;
            }

            string currentText = GetDocumentText();
            if (currentText != Code)
                SetValue(CodeProperty, currentText);

            AdjustWidthToContent();
        }

        private string GetDocumentText()
        {
            TextRange range = new TextRange(Document.ContentStart, Document.ContentEnd);
            string text = range.Text;
            text = text.Replace("\r\n", "\n");
            if (text.EndsWith("\n"))
                text = text.Substring(0, text.Length - 1);
            return text;
        }

        private void SetDocumentText(string text)
        {
            Document.Blocks.Clear();

            if (string.IsNullOrEmpty(text))
            {
                Document.Blocks.Add(new Paragraph());
                return;
            }

            string normalized = text.Replace("\r\n", "\n");
            string[] lines = normalized.Split(new[] { '\n' }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                Paragraph p = new Paragraph(new Run(line))
                {
                    LineHeight = this.FontSize,
                    Margin = new Thickness(0)
                };
                Document.Blocks.Add(p);
            }

            AdjustWidthToContent();
        }

        private void AdjustWidthToContent()
        {
            if (!double.IsNaN(this.Width))
                return;

            double maxWidth = 0;
            var typeface = new Typeface(this.FontFamily, this.FontStyle, this.FontWeight, this.FontStretch);
            const double pixelsPerDip = 96.0;

            TextRange range = new TextRange(Document.ContentStart, Document.ContentEnd);
            string fullText = range.Text;
            if (string.IsNullOrEmpty(fullText))
                return;

            string[] lines = fullText.Split(new[] { '\n' }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                FormattedText ft = new FormattedText(
                    line,
                    CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    typeface,
                    this.FontSize,
                    Brushes.Black,
                    pixelsPerDip);

                maxWidth = Math.Max(maxWidth, ft.Width);
            }

            double totalWidth = maxWidth + this.Padding.Left + this.Padding.Right;
            this.Width = totalWidth;
        }

        public void HighlightSyntax()
        {
            if (_isUpdating) return;
            _isUpdating = true;

            try
            {
                TextRange fullRange = new TextRange(Document.ContentStart, Document.ContentEnd);
                string text = fullRange.Text;

                if (string.IsNullOrEmpty(text))
                    return;

                fullRange.ApplyPropertyValue(TextElement.ForegroundProperty, DefaultBrush);

                MatchCollection matches = SyntaxRegex.Matches(text);
                foreach (Match match in matches)
                {
                    if (match.Length == 0) continue;

                    Brush brush = null;
                    if (match.Groups["comment"].Success)
                        brush = CommentBrush;
                    else if (match.Groups["string"].Success)
                        brush = StringBrush;
                    else if (match.Groups["keyword"].Success)
                        brush = KeywordBrush;
                    else if (match.Groups["number"].Success)
                        brush = NumberBrush;

                    if (brush != null)
                    {
                        TextPointer start = Document.ContentStart.GetPositionAtOffset(match.Index);
                        TextPointer end = Document.ContentStart.GetPositionAtOffset(match.Index + match.Length);
                        TextRange highlightRange = new TextRange(start, end);
                        highlightRange.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"高亮出错: {ex.Message}");
            }
            finally
            {
                _isUpdating = false;
            }
        }
    }
}
