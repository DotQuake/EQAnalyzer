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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.philvolcsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eQAnalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testV2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.sWaveBtn = new System.Windows.Forms.Button();
            this.pWaveBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loading = new System.Windows.Forms.ToolStripProgressBar();
            this.statuses = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.EHEchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EHNchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EHZchart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            chartArea4.Name = "ChartArea1";
            this.EHEchart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.EHEchart.Legends.Add(legend4);
            this.EHEchart.Location = new System.Drawing.Point(0, 113);
            this.EHEchart.Margin = new System.Windows.Forms.Padding(1);
            this.EHEchart.Name = "EHEchart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.EHEchart.Series.Add(series4);
            this.EHEchart.Size = new System.Drawing.Size(1697, 280);
            this.EHEchart.TabIndex = 6;
            this.EHEchart.Text = "chart1";
            this.EHEchart.Visible = false;
            this.EHEchart.Click += new System.EventHandler(this.l);
            this.EHEchart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
            // 
            // EHNchart
            // 
            this.EHNchart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EHNchart.BackColor = System.Drawing.Color.LightGray;
            chartArea5.Name = "ChartArea1";
            this.EHNchart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.EHNchart.Legends.Add(legend5);
            this.EHNchart.Location = new System.Drawing.Point(0, 395);
            this.EHNchart.Margin = new System.Windows.Forms.Padding(1);
            this.EHNchart.Name = "EHNchart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.EHNchart.Series.Add(series5);
            this.EHNchart.Size = new System.Drawing.Size(1697, 280);
            this.EHNchart.TabIndex = 6;
            this.EHNchart.Text = "chart1";
            this.EHNchart.Visible = false;
            this.EHNchart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseClick);
            // 
            // EHZchart
            // 
            this.EHZchart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EHZchart.BackColor = System.Drawing.Color.LightGray;
            chartArea6.Name = "ChartArea1";
            this.EHZchart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.EHZchart.Legends.Add(legend6);
            this.EHZchart.Location = new System.Drawing.Point(0, 677);
            this.EHZchart.Margin = new System.Windows.Forms.Padding(1);
            this.EHZchart.Name = "EHZchart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.EHZchart.Series.Add(series6);
            this.EHZchart.Size = new System.Drawing.Size(1697, 280);
            this.EHZchart.TabIndex = 6;
            this.EHZchart.Text = "chart1";
            this.EHZchart.Visible = false;
            this.EHZchart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart3_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1828, 28);
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
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1,
            this.philvolcsToolStripMenuItem,
            this.eQAnalToolStripMenuItem,
            this.testV2ToolStripMenuItem,
            this.testToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.settingsToolStripMenuItem.Text = "Edit";
            // 
            // philvolcsToolStripMenuItem
            // 
            this.philvolcsToolStripMenuItem.Name = "philvolcsToolStripMenuItem";
            this.philvolcsToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.philvolcsToolStripMenuItem.Text = "Philvolcs";
            this.philvolcsToolStripMenuItem.Click += new System.EventHandler(this.philvolcsToolStripMenuItem_Click);
            // 
            // eQAnalToolStripMenuItem
            // 
            this.eQAnalToolStripMenuItem.Name = "eQAnalToolStripMenuItem";
            this.eQAnalToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.eQAnalToolStripMenuItem.Text = "EQAnal";
            this.eQAnalToolStripMenuItem.Click += new System.EventHandler(this.eQAnalToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.testToolStripMenuItem.Text = "TestV1";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // testV2ToolStripMenuItem
            // 
            this.testV2ToolStripMenuItem.Name = "testV2ToolStripMenuItem";
            this.testV2ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.testV2ToolStripMenuItem.Text = "TestV2";
            this.testV2ToolStripMenuItem.Click += new System.EventHandler(this.testV2ToolStripMenuItem_Click);
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
            this.x.BackColor = System.Drawing.Color.Gray;
            this.x.Location = new System.Drawing.Point(12, 211);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(0, 17);
            this.x.TabIndex = 15;
            this.x.Visible = false;
            // 
            // max1
            // 
            this.max1.AutoSize = true;
            this.max1.BackColor = System.Drawing.Color.Gray;
            this.max1.Location = new System.Drawing.Point(12, 142);
            this.max1.Name = "max1";
            this.max1.Size = new System.Drawing.Size(0, 17);
            this.max1.TabIndex = 15;
            this.max1.Visible = false;
            // 
            // station1
            // 
            this.station1.AutoSize = true;
            this.station1.BackColor = System.Drawing.Color.Gray;
            this.station1.Location = new System.Drawing.Point(12, 251);
            this.station1.Name = "station1";
            this.station1.Size = new System.Drawing.Size(0, 17);
            this.station1.TabIndex = 15;
            this.station1.Visible = false;
            // 
            // min1
            // 
            this.min1.AutoSize = true;
            this.min1.BackColor = System.Drawing.Color.Gray;
            this.min1.Location = new System.Drawing.Point(12, 330);
            this.min1.Name = "min1";
            this.min1.Size = new System.Drawing.Size(0, 17);
            this.min1.TabIndex = 15;
            this.min1.Visible = false;
            // 
            // y
            // 
            this.y.AutoSize = true;
            this.y.BackColor = System.Drawing.Color.Gray;
            this.y.Location = new System.Drawing.Point(12, 494);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(0, 17);
            this.y.TabIndex = 15;
            this.y.Visible = false;
            // 
            // station2
            // 
            this.station2.AutoSize = true;
            this.station2.BackColor = System.Drawing.Color.Gray;
            this.station2.Location = new System.Drawing.Point(12, 539);
            this.station2.Name = "station2";
            this.station2.Size = new System.Drawing.Size(0, 17);
            this.station2.TabIndex = 15;
            this.station2.Visible = false;
            // 
            // min2
            // 
            this.min2.AutoSize = true;
            this.min2.BackColor = System.Drawing.Color.Gray;
            this.min2.Location = new System.Drawing.Point(10, 609);
            this.min2.Name = "min2";
            this.min2.Size = new System.Drawing.Size(0, 17);
            this.min2.TabIndex = 15;
            this.min2.Visible = false;
            // 
            // max2
            // 
            this.max2.AutoSize = true;
            this.max2.BackColor = System.Drawing.Color.Gray;
            this.max2.Location = new System.Drawing.Point(12, 423);
            this.max2.Name = "max2";
            this.max2.Size = new System.Drawing.Size(0, 17);
            this.max2.TabIndex = 15;
            this.max2.Visible = false;
            // 
            // z
            // 
            this.z.AutoSize = true;
            this.z.BackColor = System.Drawing.Color.Gray;
            this.z.Location = new System.Drawing.Point(12, 779);
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(0, 17);
            this.z.TabIndex = 15;
            this.z.Visible = false;
            // 
            // station3
            // 
            this.station3.AutoSize = true;
            this.station3.BackColor = System.Drawing.Color.Gray;
            this.station3.Location = new System.Drawing.Point(12, 823);
            this.station3.Name = "station3";
            this.station3.Size = new System.Drawing.Size(0, 17);
            this.station3.TabIndex = 15;
            this.station3.Visible = false;
            // 
            // min3
            // 
            this.min3.AutoSize = true;
            this.min3.BackColor = System.Drawing.Color.Gray;
            this.min3.Location = new System.Drawing.Point(12, 893);
            this.min3.Name = "min3";
            this.min3.Size = new System.Drawing.Size(0, 17);
            this.min3.TabIndex = 15;
            this.min3.Visible = false;
            // 
            // max3
            // 
            this.max3.AutoSize = true;
            this.max3.BackColor = System.Drawing.Color.Gray;
            this.max3.Location = new System.Drawing.Point(12, 706);
            this.max3.Name = "max3";
            this.max3.Size = new System.Drawing.Size(0, 17);
            this.max3.TabIndex = 15;
            this.max3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Gray;
            this.groupBox1.Controls.Add(this.sWaveBtn);
            this.groupBox1.Controls.Add(this.pWaveBtn);
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1816, 54);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
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
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loading,
            this.statuses});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1030);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1828, 25);
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
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(152, 24);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1828, 1055);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.max3);
            this.Controls.Add(this.max2);
            this.Controls.Add(this.max1);
            this.Controls.Add(this.min3);
            this.Controls.Add(this.station3);
            this.Controls.Add(this.min2);
            this.Controls.Add(this.station2);
            this.Controls.Add(this.z);
            this.Controls.Add(this.min1);
            this.Controls.Add(this.y);
            this.Controls.Add(this.station1);
            this.Controls.Add(this.x);
            this.Controls.Add(this.header);
            this.Controls.Add(this.EHZchart);
            this.Controls.Add(this.EHNchart);
            this.Controls.Add(this.EHEchart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "EQAnal Wave";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EHEchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EHNchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EHZchart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem philvolcsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eQAnalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testV2ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
    }
}

