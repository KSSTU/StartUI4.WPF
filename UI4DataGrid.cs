using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Markup;
using System.Xml;

namespace StartUI4Controls
{
    public class UI4DataGrid : DataGrid
    {
        private static Style? _scrollBarStyle;
        private static readonly System.Collections.Generic.List<string> _tempDbFiles = new();

        static UI4DataGrid()
        {
            _scrollBarStyle = CreateScrollBarStyle();
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            foreach (string dbPath in _tempDbFiles)
            {
                try
                {
                    if (File.Exists(dbPath)) File.Delete(dbPath);
                    string journal = dbPath + "-journal";
                    string wal = dbPath + "-wal";
                    if (File.Exists(journal)) File.Delete(journal);
                    if (File.Exists(wal)) File.Delete(wal);
                }
                catch { }
            }
        }

        private static Style? CreateScrollBarStyle()
        {
            string xaml = @"
<Style xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
       xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
       TargetType='{x:Type ScrollBar}'>
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
    </Style.Resources>
    <Setter Property='Stylus.IsPressAndHoldEnabled' Value='false'/>
    <Setter Property='Stylus.IsFlicksEnabled' Value='false'/>
    <Setter Property='Background' Value='Transparent'/>
    <Setter Property='Margin' Value='0,1,2,6'/>
    <Setter Property='Width' Value='10'/>
    <Setter Property='MinWidth' Value='10'/>
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
            <Setter Property='Height' Value='10'/>
            <Setter Property='MinHeight' Value='10'/>
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

        public int PageSize { get; set; } = 200;

        private int _currentPage;
        private bool _isLoading;
        private bool _hasMoreData = true;
        private bool _scrollBarVisible;
        private DateTime _lastScrollTime = DateTime.MinValue;

        private readonly string _randKey;
        public string DbPath { get; private set; }

        public string TableName { get; set; } = "TableData";

        private DataTable _displayTable;
        private UI4ContextMenu? _contextMenu;

        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register(nameof(HeaderBackground), typeof(Brush), typeof(UI4DataGrid),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(245, 245, 245)), OnStyleChanged));
        public Brush HeaderBackground
        {
            get => (Brush)GetValue(HeaderBackgroundProperty);
            set => SetValue(HeaderBackgroundProperty, value);
        }

        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.Register(nameof(HeaderForeground), typeof(Brush), typeof(UI4DataGrid),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(30, 30, 30)), OnStyleChanged));
        public Brush HeaderForeground
        {
            get => (Brush)GetValue(HeaderForegroundProperty);
            set => SetValue(HeaderForegroundProperty, value);
        }

        public static readonly DependencyProperty RowHoverBackgroundProperty =
            DependencyProperty.Register(nameof(RowHoverBackground), typeof(Brush), typeof(UI4DataGrid),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(240, 240, 245)), OnStyleChanged));
        public Brush RowHoverBackground
        {
            get => (Brush)GetValue(RowHoverBackgroundProperty);
            set => SetValue(RowHoverBackgroundProperty, value);
        }

        public static readonly DependencyProperty RowSelectedBackgroundProperty =
            DependencyProperty.Register(nameof(RowSelectedBackground), typeof(Brush), typeof(UI4DataGrid),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(211, 211, 211)), OnStyleChanged));
        public Brush RowSelectedBackground
        {
            get => (Brush)GetValue(RowSelectedBackgroundProperty);
            set => SetValue(RowSelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty GridLineColorProperty =
            DependencyProperty.Register(nameof(GridLineColor), typeof(Brush), typeof(UI4DataGrid),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(230, 230, 235)), OnStyleChanged));
        public Brush GridLineColor
        {
            get => (Brush)GetValue(GridLineColorProperty);
            set => SetValue(GridLineColorProperty, value);
        }

        private static void OnStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UI4DataGrid grid) grid.ApplyCustomStyle();
        }

        public UI4DataGrid()
        {
            _randKey = Guid.NewGuid().ToString().Substring(0, 8);
            DbPath = Path.Combine(Path.GetTempPath(), $"StartUI4_temp_{_randKey}.db");

            DeleteSelfOldDb();

            lock (_tempDbFiles)
            {
                _tempDbFiles.Add(DbPath);
            }

            _displayTable = new DataTable();
            ItemsSource = _displayTable.DefaultView;

            IsReadOnly = true;
            AutoGenerateColumns = true;
            CanUserAddRows = false;
            CanUserDeleteRows = false;
            GridLinesVisibility = DataGridGridLinesVisibility.Horizontal;
            HeadersVisibility = DataGridHeadersVisibility.Column;
            RowHeaderWidth = 0;
            BorderThickness = new Thickness(1);
            BorderBrush = new SolidColorBrush(Color.FromRgb(220, 220, 225));
            Background = Brushes.White;
            AlternatingRowBackground = null;
            SelectionMode = DataGridSelectionMode.Extended;
            SelectionUnit = DataGridSelectionUnit.FullRow;
            FontSize = 12;
            RowHeight = 28;
            VerticalContentAlignment = VerticalAlignment.Center;

            AutoGeneratingColumn += OnAutoGeneratingColumn;

            if (_scrollBarStyle != null)
            {
                Resources.Add(typeof(ScrollBar), _scrollBarStyle);
            }

            VirtualizingPanel.SetIsVirtualizing(this, true);
            VirtualizingPanel.SetVirtualizationMode(this, VirtualizationMode.Recycling);
            AddHandler(ScrollViewer.ScrollChangedEvent, new ScrollChangedEventHandler(OnScrollChanged));

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;

            InitSqliteTable();
            ApplyCustomStyle();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            InitContextMenu();
        }

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column is DataGridTextColumn textCol)
            {
                Style elementStyle = new Style(typeof(TextBlock));
                elementStyle.Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center));
                elementStyle.Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center));
                elementStyle.Setters.Add(new Setter(TextBlock.TextTrimmingProperty, TextTrimming.CharacterEllipsis));
                textCol.ElementStyle = elementStyle;
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            DeleteSelfOldDb();
        }

        private void InitContextMenu()
        {
            if (_contextMenu != null) return;

            _contextMenu = new UI4ContextMenu
            {
                Width = 170
            };

            _contextMenu.AddItem(UI4MenuItemType.Copy,
                () => { if (SelectedItem != null) Clipboard.SetDataObject(SelectedCellsToString()); },
                () => SelectedItem != null);

            _contextMenu.AddItem(UI4MenuItemType.SelectAll,
                () => SelectAll());

            ContextMenu = null;
            _contextMenu.Attach(this);
        }

        private string SelectedCellsToString()
        {
            if (SelectedCells.Count == 0) return string.Empty;

            var rows = new System.Collections.Generic.List<string>();
            var currentRowItems = new System.Collections.Generic.List<object>();
            DataGridCellInfo firstCell = SelectedCells[0];
            object currentItem = firstCell.Item;

            foreach (var cell in SelectedCells)
            {
                if (cell.Item != currentItem)
                {
                    rows.Add(string.Join("\t", currentRowItems));
                    currentRowItems.Clear();
                    currentItem = cell.Item;
                }

                if (cell.Column is DataGridBoundColumn boundCol && boundCol.Binding is System.Windows.Data.Binding binding)
                {
                    string propName = binding.Path.Path;
                    if (cell.Item is DataRowView rowView && rowView.Row.Table.Columns.Contains(propName))
                    {
                        currentRowItems.Add(rowView[propName]?.ToString() ?? "");
                    }
                    else
                    {
                        currentRowItems.Add("");
                    }
                }
                else
                {
                    currentRowItems.Add("");
                }
            }
            if (currentRowItems.Count > 0)
                rows.Add(string.Join("\t", currentRowItems));

            return string.Join("\n", rows);
        }

        private void ApplyCustomStyle()
        {
            Background = Brushes.White;
            RowBackground = Brushes.White;

            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.White));
            rowStyle.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0)));
            rowStyle.Setters.Add(new Setter(FrameworkElement.HeightProperty, 28.0));

            Trigger hoverTrigger = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
            hoverTrigger.Setters.Add(new Setter(Control.BackgroundProperty, RowHoverBackground));
            rowStyle.Triggers.Add(hoverTrigger);

            Trigger selectedTrigger = new Trigger { Property = DataGridRow.IsSelectedProperty, Value = true };
            selectedTrigger.Setters.Add(new Setter(Control.BackgroundProperty, RowSelectedBackground));
            selectedTrigger.Setters.Add(new Setter(Control.ForegroundProperty, Brushes.Black));
            rowStyle.Triggers.Add(selectedTrigger);

            RowStyle = rowStyle;

            Style headerStyle = new Style(typeof(DataGridColumnHeader));
            headerStyle.Setters.Add(new Setter(Control.BackgroundProperty, HeaderBackground));
            headerStyle.Setters.Add(new Setter(Control.ForegroundProperty, HeaderForeground));
            headerStyle.Setters.Add(new Setter(Control.BorderBrushProperty, GridLineColor));
            headerStyle.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0, 0, 1, 1)));
            headerStyle.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(12, 8, 12, 8)));
            headerStyle.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Normal));
            headerStyle.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Left));
            headerStyle.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));
            headerStyle.Setters.Add(new Setter(FrameworkElement.HeightProperty, 32.0));

            Trigger headerHoverTrigger = new Trigger { Property = UIElement.IsMouseOverProperty, Value = true };
            headerHoverTrigger.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(Color.FromRgb(235, 235, 240))));
            headerStyle.Triggers.Add(headerHoverTrigger);

            ColumnHeaderStyle = headerStyle;

            Style cellStyle = new Style(typeof(DataGridCell));
            cellStyle.Setters.Add(new Setter(Control.BorderBrushProperty, GridLineColor));
            cellStyle.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0, 0, 1, 0)));
            cellStyle.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(12, 4, 12, 4)));
            cellStyle.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Transparent));
            cellStyle.Setters.Add(new Setter(Control.FocusVisualStyleProperty, null));
            cellStyle.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));

            Trigger cellSelectedTrigger = new Trigger { Property = DataGridCell.IsSelectedProperty, Value = true };
            cellSelectedTrigger.Setters.Add(new Setter(Control.BackgroundProperty, RowSelectedBackground));
            cellSelectedTrigger.Setters.Add(new Setter(Control.ForegroundProperty, Brushes.Black));
            cellSelectedTrigger.Setters.Add(new Setter(Control.BorderBrushProperty, GridLineColor));
            cellStyle.Triggers.Add(cellSelectedTrigger);

            CellStyle = cellStyle;

            HorizontalGridLinesBrush = GridLineColor;
            VerticalGridLinesBrush = GridLineColor;
            GridLinesVisibility = DataGridGridLinesVisibility.Horizontal;
        }

        private void DeleteSelfOldDb()
        {
            try
            {
                if (File.Exists(DbPath))
                    File.Delete(DbPath);

                string journal = DbPath + "-journal";
                string wal = DbPath + "-wal";
                if (File.Exists(journal)) File.Delete(journal);
                if (File.Exists(wal)) File.Delete(wal);
            }
            catch
            {

            }
        }

        private void InitSqliteTable()
        {
            using var conn = new SQLiteConnection($"Data Source={DbPath}");
            conn.Open();
            string createSql = $@"
CREATE TABLE IF NOT EXISTS {TableName}(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT,
    Age INTEGER,
    Remark TEXT
)";
            SQLiteCommand cmd = new SQLiteCommand(createSql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer scroll)
            {
                ShowScrollBars(scroll);

                if (_isLoading || !_hasMoreData) return;
                if (scroll.VerticalOffset >= scroll.ExtentHeight - scroll.ViewportHeight - 30)
                {
                    LoadNextPageData();
                }
            }
        }

        private void ShowScrollBars(ScrollViewer scrollViewer)
        {
            _lastScrollTime = DateTime.Now;

            ScrollBar? vBar = GetScrollBar(scrollViewer, Orientation.Vertical);
            ScrollBar? hBar = GetScrollBar(scrollViewer, Orientation.Horizontal);

            if (!_scrollBarVisible)
            {
                _scrollBarVisible = true;
                DoubleAnimation fadeIn = new DoubleAnimation(1, TimeSpan.FromMilliseconds(200));
                vBar?.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                hBar?.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            }

            _ = DelayHideScrollBars(vBar, hBar);
        }

        private async System.Threading.Tasks.Task DelayHideScrollBars(ScrollBar? vBar, ScrollBar? hBar)
        {
            await System.Threading.Tasks.Task.Delay(1500);
            if ((DateTime.Now - _lastScrollTime).TotalMilliseconds >= 1500)
            {
                _scrollBarVisible = false;
                DoubleAnimation fadeOut = new DoubleAnimation(0, TimeSpan.FromMilliseconds(500));
                vBar?.BeginAnimation(UIElement.OpacityProperty, fadeOut);
                hBar?.BeginAnimation(UIElement.OpacityProperty, fadeOut);
            }
        }

        private ScrollBar? GetScrollBar(DependencyObject parent, Orientation orientation)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is ScrollBar bar && bar.Orientation == orientation)
                    return bar;
                ScrollBar? result = GetScrollBar(child, orientation);
                if (result != null) return result;
            }
            return null;
        }

        public void LoadNextPageData()
        {
            if (!_hasMoreData) return;
            _isLoading = true;
            _currentPage++;
            int skipCount = (_currentPage - 1) * PageSize;

            using var conn = new SQLiteConnection($"Data Source={DbPath}");
            conn.Open();
            string sql = $"SELECT * FROM {TableName} ORDER BY Id LIMIT {PageSize} OFFSET {skipCount}";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
            DataTable pageTable = new DataTable();
            adapter.Fill(pageTable);
            conn.Close();

            if (pageTable.Rows.Count == 0)
            {
                _hasMoreData = false;
                _isLoading = false;
                return;
            }

            if (_displayTable.Columns.Count == 0)
            {
                foreach (DataColumn col in pageTable.Columns)
                {
                    _displayTable.Columns.Add(col.ColumnName, col.DataType);
                }
            }

            foreach (DataRow row in pageTable.Rows)
            {
                DataRow newRow = _displayTable.NewRow();
                foreach (DataColumn col in pageTable.Columns)
                {
                    newRow[col.ColumnName] = row[col.ColumnName];
                }
                _displayTable.Rows.Add(newRow);
            }

            if (pageTable.Rows.Count < PageSize)
            {
                _hasMoreData = false;
            }

            _isLoading = false;
        }

        public void ResetLoadData()
        {
            _currentPage = 0;
            _hasMoreData = true;
            _displayTable.Clear();
            _displayTable.Columns.Clear();
            LoadNextPageData();
        }

        public void ImportData(DataTable dt)
        {
            if (dt == null || dt.Columns.Count == 0) return;

            using var conn = new SQLiteConnection($"Data Source={DbPath}");
            conn.Open();

            string dropSql = $"DROP TABLE IF EXISTS {TableName}";
            new SQLiteCommand(dropSql, conn).ExecuteNonQuery();

            string createSql = $"CREATE TABLE {TableName}(Id INTEGER PRIMARY KEY AUTOINCREMENT";
            foreach (DataColumn col in dt.Columns)
            {
                string colType = "TEXT";
                if (col.DataType == typeof(int) || col.DataType == typeof(long) || col.DataType == typeof(short))
                    colType = "INTEGER";
                else if (col.DataType == typeof(double) || col.DataType == typeof(float) || col.DataType == typeof(decimal))
                    colType = "REAL";
                else if (col.DataType == typeof(bool))
                    colType = "INTEGER";
                else if (col.DataType == typeof(DateTime))
                    colType = "TEXT";

                if (col.ColumnName.Equals("Id", StringComparison.OrdinalIgnoreCase))
                    continue;

                createSql += $", [{col.ColumnName}] {colType}";
            }
            createSql += ")";
            new SQLiteCommand(createSql, conn).ExecuteNonQuery();

            using var trans = conn.BeginTransaction();

            string colNames = "";
            string colParams = "";
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName.Equals("Id", StringComparison.OrdinalIgnoreCase))
                    continue;
                if (colNames.Length > 0)
                {
                    colNames += ",";
                    colParams += ",";
                }
                colNames += $"[{col.ColumnName}]";
                colParams += $"@{col.ColumnName}";
            }

            string insertSql = $"INSERT INTO {TableName}({colNames}) VALUES({colParams})";

            foreach (DataRow row in dt.Rows)
            {
                SQLiteCommand cmd = new SQLiteCommand(insertSql, conn, trans);
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName.Equals("Id", StringComparison.OrdinalIgnoreCase))
                        continue;
                    cmd.Parameters.AddWithValue($"@{col.ColumnName}", row[col.ColumnName] ?? DBNull.Value);
                }
                cmd.ExecuteNonQuery();
            }

            trans.Commit();
            conn.Close();
            ResetLoadData();
        }

        public void ClearAllData()
        {
            using var conn = new SQLiteConnection($"Data Source={DbPath}");
            conn.Open();
            new SQLiteCommand($"DELETE FROM {TableName}", conn).ExecuteNonQuery();
            conn.Close();
            ResetLoadData();
        }

        public void DisposeDb()
        {
            DeleteSelfOldDb();
            lock (_tempDbFiles)
            {
                _tempDbFiles.Remove(DbPath);
            }
        }
    }
}