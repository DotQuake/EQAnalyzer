namespace DataGraph
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.EHEchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.EHNchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.EHZchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTALTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkEQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.header = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.Label();
            this.max1 = new System.Windows.Forms.Label();
            this.station1 = new System.Windows.Forms.Label();
            this.min1 = new System.Windows.Forms.Label();
            this.y = new System.Windows.Forms.Label();
            this.station2 = new System.Windows.Forms.Label();
            this.min2 = new System.Windows.Forms.Label();
            this.max2 = new System.Windows.Forms.Label();
            this.z = new System.Windows.Forms.Label();
            this.station3 = new System.Windows.Forms.Label();
            this.min3 = new System.Windows.Forms.Label();
            this.max3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.test_magnitude = new System.Windows.Forms.Button();
            this.test_direction = new System.Windows.Forms.Button();
            this.sWaveBtn = new System.Windows.Forms.Button();
            this.pWaveBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loading = new System.Windows.Forms.ToolStripProgressBar();
            this.statuses = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.EHEchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EHNchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EHZchart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // EHEchart
            // 
            this.EHEchart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EHEchart.BackColor = System.Drawing.Color.LightGray;
            this.EHEchart.BorderlineWidth = 0;
            this.EHEchart.BorderSkin.BackColor = System.Drawing.Color.DarkGray;
            this.EHEchart.BorderSkin.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Cross;
            chartArea1.Name = "ChartArea1";
            this.EHEchart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.EHEchart.Legends.Add(legend1);
            this.EHEchart.Location = new System.Drawing.Point(20, 16);
            this.EHEchart.Margin = new System.Windows.Forms.Padding(1);
            this.EHEchart.Name = "EHEchart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.EHEchart.Series.Add(series1);
            this.EHEchart.Size = new System.Drawing.Size(1743, 255);
            this.EHEchart.TabIndex = 6;
            this.EHEchart.Text = "chart1";
            this.EHEchart.Visible = false;
            this.EHEchart.SelectionRangeChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.EHEchart_SelectionRangeChanging);
            this.EHEchart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.EHNchart_SelectionRangeChanged);
            this.EHEchart.AnnotationPositionChanged += new System.EventHandler(this.EHZchart_AnnotationPositionChanged);
            this.EHEchart.AnnotationPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.AnnotationPositionChangingEventArgs>(this.EHEchart_AnnotationPositionChanging);
            // 
            // EHNchart
            // 
            this.EHNchart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EHNchart.BackColor = System.Drawing.Color.LightGray;
            chartArea2.Name = "ChartArea1";
            this.EHNchart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.EHNchart.Legends.Add(legend2);
            this.EHNchart.Location = new System.Drawing.Point(20, 273);
            this.EHNchart.Margin = new System.Windows.Forms.Padding(1);
            this.EHNchart.Name = "EHNchart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.EHNchart.Series.Add(series2);
            this.EHNchart.Size = new System.Drawing.Size(1743, 255);
            this.EHNchart.TabIndex = 6;
            this.EHNchart.Text = "chart1";
            this.EHNchart.Visible = false;
            this.EHNchart.SelectionRangeChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.EHNchart_SelectionRangeChanging);
            this.EHNchart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.EHNchart_SelectionRangeChanged);
            this.EHNchart.AnnotationPositionChanged += new System.EventHandler(this.EHZchart_AnnotationPositionChanged);
            this.EHNchart.AnnotationPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.AnnotationPositionChangingEventArgs>(this.EHEchart_AnnotationPositionChanging);
            // 
            // EHZchart
            // 
            this.EHZchart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EHZchart.BackColor = System.Drawing.Color.LightGray;
            chartArea3.Name = "ChartArea1";
            this.EHZchart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.EHZchart.Legends.Add(legend3);
            this.EHZchart.Location = new System.Drawing.Point(20, 530);
            this.EHZchart.Margin = new System.Windows.Forms.Padding(1);
            this.EHZchart.Name = "EHZchart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.EHZchart.Series.Add(series3);
            this.EHZchart.Size = new System.Drawing.Size(1743, 255);
            this.EHZchart.TabIndex = 6;
            this.EHZchart.Text = "chart1";
            this.EHZchart.Visible = false;
            this.EHZchart.SelectionRangeChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.EHZchart_SelectionRangeChanging);
            this.EHZchart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.EHNchart_SelectionRangeChanged);
            this.EHZchart.AnnotationPositionChanged += new System.EventHandler(this.EHZchart_AnnotationPositionChanged);
            this.EHZchart.AnnotationPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.AnnotationPositionChangingEventArgs>(this.EHEchart_AnnotationPositionChanging);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1876, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.sTALTAToolStripMenuItem,
            this.checkEQToolStripMenuItem,
            this.downloadCsvToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // sTALTAToolStripMenuItem
            // 
            this.sTALTAToolStripMenuItem.Name = "sTALTAToolStripMenuItem";
            this.sTALTAToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.sTALTAToolStripMenuItem.Text = "STA/LTA";
            this.sTALTAToolStripMenuItem.Click += new System.EventHandler(this.sTALTAToolStripMenuItem_Click);
            // 
            // checkEQToolStripMenuItem
            // 
            this.checkEQToolStripMenuItem.Name = "checkEQToolStripMenuItem";
            this.checkEQToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.checkEQToolStripMenuItem.Text = "Check EQ";
            this.checkEQToolStripMenuItem.Click += new System.EventHandler(this.checkEQToolStripMenuItem_Click);
            // 
            // downloadCsvToolStripMenuItem
            // 
            this.downloadCsvToolStripMenuItem.Name = "downloadCsvToolStripMenuItem";
            this.downloadCsvToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.downloadCsvToolStripMenuItem.Text = "Download csv";
            this.downloadCsvToolStripMenuItem.Click += new System.EventHandler(this.downloadCsvToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Location = new System.Drawing.Point(10, 89);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(0, 17);
            this.header.TabIndex = 13;
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.BackColor = System.Drawing.Color.Transparent;
            this.x.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x.Location = new System.Drawing.Point(14, 219);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(34, 20);
            this.x.TabIndex = 15;
            this.x.Text = "     ";
            this.x.Visible = false;
            // 
            // max1
            // 
            this.max1.AutoSize = true;
            this.max1.BackColor = System.Drawing.Color.Transparent;
            this.max1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max1.Location = new System.Drawing.Point(14, 153);
            this.max1.Name = "max1";
            this.max1.Size = new System.Drawing.Size(34, 20);
            this.max1.TabIndex = 15;
            this.max1.Text = "     ";
            this.max1.Visible = false;
            // 
            // station1
            // 
            this.station1.AutoSize = true;
            this.station1.BackColor = System.Drawing.Color.Transparent;
            this.station1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.station1.Location = new System.Drawing.Point(14, 262);
            this.station1.Name = "station1";
            this.station1.Size = new System.Drawing.Size(34, 20);
            this.station1.TabIndex = 15;
            this.station1.Text = "     ";
            this.station1.Visible = false;
            // 
            // min1
            // 
            this.min1.AutoSize = true;
            this.min1.BackColor = System.Drawing.Color.Transparent;
            this.min1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min1.Location = new System.Drawing.Point(14, 322);
            this.min1.Name = "min1";
            this.min1.Size = new System.Drawing.Size(34, 20);
            this.min1.TabIndex = 15;
            this.min1.Text = "     ";
            this.min1.Visible = false;
            // 
            // y
            // 
            this.y.AutoSize = true;
            this.y.BackColor = System.Drawing.Color.Transparent;
            this.y.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y.Location = new System.Drawing.Point(14, 466);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(34, 20);
            this.y.TabIndex = 15;
            this.y.Text = "     ";
            this.y.Visible = false;
            // 
            // station2
            // 
            this.station2.AutoSize = true;
            this.station2.BackColor = System.Drawing.Color.Transparent;
            this.station2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.station2.Location = new System.Drawing.Point(14, 508);
            this.station2.Name = "station2";
            this.station2.Size = new System.Drawing.Size(34, 20);
            this.station2.TabIndex = 15;
            this.station2.Text = "     ";
            this.station2.Visible = false;
            // 
            // min2
            // 
            this.min2.AutoSize = true;
            this.min2.BackColor = System.Drawing.Color.Transparent;
            this.min2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min2.Location = new System.Drawing.Point(14, 578);
            this.min2.Name = "min2";
            this.min2.Size = new System.Drawing.Size(34, 20);
            this.min2.TabIndex = 15;
            this.min2.Text = "     ";
            this.min2.Visible = false;
            // 
            // max2
            // 
            this.max2.AutoSize = true;
            this.max2.BackColor = System.Drawing.Color.Transparent;
            this.max2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max2.Location = new System.Drawing.Point(14, 404);
            this.max2.Name = "max2";
            this.max2.Size = new System.Drawing.Size(34, 20);
            this.max2.TabIndex = 15;
            this.max2.Text = "     ";
            this.max2.Visible = false;
            // 
            // z
            // 
            this.z.AutoSize = true;
            this.z.BackColor = System.Drawing.Color.Transparent;
            this.z.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z.Location = new System.Drawing.Point(14, 732);
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(34, 20);
            this.z.TabIndex = 15;
            this.z.Text = "     ";
            this.z.Visible = false;
            // 
            // station3
            // 
            this.station3.AutoSize = true;
            this.station3.BackColor = System.Drawing.Color.Transparent;
            this.station3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.station3.Location = new System.Drawing.Point(14, 776);
            this.station3.Name = "station3";
            this.station3.Size = new System.Drawing.Size(34, 20);
            this.station3.TabIndex = 15;
            this.station3.Text = "     ";
            this.station3.Visible = false;
            // 
            // min3
            // 
            this.min3.AutoSize = true;
            this.min3.BackColor = System.Drawing.Color.Transparent;
            this.min3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min3.Location = new System.Drawing.Point(14, 840);
            this.min3.Name = "min3";
            this.min3.Size = new System.Drawing.Size(34, 20);
            this.min3.TabIndex = 15;
            this.min3.Text = "     ";
            this.min3.Visible = false;
            // 
            // max3
            // 
            this.max3.AutoSize = true;
            this.max3.BackColor = System.Drawing.Color.Transparent;
            this.max3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max3.Location = new System.Drawing.Point(14, 669);
            this.max3.Name = "max3";
            this.max3.Size = new System.Drawing.Size(34, 20);
            this.max3.TabIndex = 15;
            this.max3.Text = "     ";
            this.max3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Gray;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.test_magnitude);
            this.groupBox1.Controls.Add(this.test_direction);
            this.groupBox1.Controls.Add(this.sWaveBtn);
            this.groupBox1.Controls.Add(this.pWaveBtn);
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1864, 54);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // test_magnitude
            // 
            this.test_magnitude.Enabled = false;
            this.test_magnitude.Location = new System.Drawing.Point(280, 15);
            this.test_magnitude.Name = "test_magnitude";
            this.test_magnitude.Size = new System.Drawing.Size(127, 33);
            this.test_magnitude.TabIndex = 0;
            this.test_magnitude.Text = "Test magnitude";
            this.test_magnitude.UseVisualStyleBackColor = true;
            this.test_magnitude.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // test_direction
            // 
            this.test_direction.Enabled = false;
            this.test_direction.Location = new System.Drawing.Point(159, 15);
            this.test_direction.Name = "test_direction";
            this.test_direction.Size = new System.Drawing.Size(115, 33);
            this.test_direction.TabIndex = 0;
            this.test_direction.Text = "Test direction";
            this.test_direction.UseVisualStyleBackColor = true;
            this.test_direction.Click += new System.EventHandler(this.testV2ToolStripMenuItem_Click);
            // 
            // sWaveBtn
            // 
            this.sWaveBtn.Location = new System.Drawing.Point(48, 15);
            this.sWaveBtn.Name = "sWaveBtn";
            this.sWaveBtn.Size = new System.Drawing.Size(36, 33);
            this.sWaveBtn.TabIndex = 0;
            this.sWaveBtn.Text = "S";
            this.sWaveBtn.UseVisualStyleBackColor = true;
            this.sWaveBtn.Click += new System.EventHandler(this.sWaveBtn_Click);
            this.sWaveBtn.MouseHover += new System.EventHandler(this.sWaveBtn_MouseHover);
            // 
            // pWaveBtn
            // 
            this.pWaveBtn.Location = new System.Drawing.Point(6, 15);
            this.pWaveBtn.Name = "pWaveBtn";
            this.pWaveBtn.Size = new System.Drawing.Size(36, 33);
            this.pWaveBtn.TabIndex = 0;
            this.pWaveBtn.Text = "P";
            this.pWaveBtn.UseVisualStyleBackColor = true;
            this.pWaveBtn.Click += new System.EventHandler(this.pWaveBtn_Click);
            this.pWaveBtn.MouseHover += new System.EventHandler(this.pWaveBtn_MouseHover);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loading,
            this.statuses});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1030);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1876, 25);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loading
            // 
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(100, 19);
            // 
            // statuses
            // 
            this.statuses.Name = "statuses";
            this.statuses.Size = new System.Drawing.Size(52, 20);
            this.statuses.Text = "Status:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.EHEchart);
            this.panel1.Controls.Add(this.EHNchart);
            this.panel1.Controls.Add(this.EHZchart);
            this.panel1.Location = new System.Drawing.Point(71, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1772, 801);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1876, 1055);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.max3);
            this.Controls.Add(this.min3);
            this.Controls.Add(this.station3);
            this.Controls.Add(this.z);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.max2);
            this.Controls.Add(this.max1);
            this.Controls.Add(this.min2);
            this.Controls.Add(this.station2);
            this.Controls.Add(this.min1);
            this.Controls.Add(this.y);
            this.Controls.Add(this.station1);
            this.Controls.Add(this.x);
            this.Controls.Add(this.header);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "EQAnalyzer Wave";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EHEchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EHNchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EHZchart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart EHEchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart EHNchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart EHZchart;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTALTAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label x;
        private System.Windows.Forms.ToolStripMenuItem checkEQToolStripMenuItem;
        private System.Windows.Forms.Label max1;
        private System.Windows.Forms.Label station1;
        private System.Windows.Forms.Label min1;
        private System.Windows.Forms.Label y;
        private System.Windows.Forms.Label station2;
        private System.Windows.Forms.Label min2;
        private System.Windows.Forms.Label max2;
        private System.Windows.Forms.Label z;
        private System.Windows.Forms.Label station3;
        private System.Windows.Forms.Label min3;
        private System.Windows.Forms.Label max3;
        private System.Windows.Forms.ToolStripMenuItem downloadCsvToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button sWaveBtn;
        private System.Windows.Forms.Button pWaveBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar loading;
        private System.Windows.Forms.ToolStripStatusLabel statuses;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button test_magnitude;
        private System.Windows.Forms.Button test_direction;
        private System.Windows.Forms.Panel panel1;
    }
}

