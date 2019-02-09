namespace DataGraph
{
    partial class STALTA
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
            this.STALTAEHE = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.STALTAEHN = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.STALTAEHZ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.test = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHZ)).BeginInit();
            this.SuspendLayout();
            // 
            // STALTAEHE
            // 
            this.STALTAEHE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.STALTAEHE.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.STALTAEHE.Legends.Add(legend1);
            this.STALTAEHE.Location = new System.Drawing.Point(12, 62);
            this.STALTAEHE.Name = "STALTAEHE";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.STALTAEHE.Series.Add(series1);
            this.STALTAEHE.Size = new System.Drawing.Size(1797, 280);
            this.STALTAEHE.TabIndex = 0;
            this.STALTAEHE.Text = "chart1";
            this.STALTAEHE.MouseClick += new System.Windows.Forms.MouseEventHandler(this.STALTAEHE_MouseClick);
            // 
            // STALTAEHN
            // 
            this.STALTAEHN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.STALTAEHN.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.STALTAEHN.Legends.Add(legend2);
            this.STALTAEHN.Location = new System.Drawing.Point(12, 348);
            this.STALTAEHN.Name = "STALTAEHN";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.STALTAEHN.Series.Add(series2);
            this.STALTAEHN.Size = new System.Drawing.Size(1797, 280);
            this.STALTAEHN.TabIndex = 1;
            this.STALTAEHN.Text = "chart2";
            this.STALTAEHN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.STALTAEHN_MouseClick);
            // 
            // STALTAEHZ
            // 
            this.STALTAEHZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.STALTAEHZ.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.STALTAEHZ.Legends.Add(legend3);
            this.STALTAEHZ.Location = new System.Drawing.Point(12, 634);
            this.STALTAEHZ.Name = "STALTAEHZ";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.STALTAEHZ.Series.Add(series3);
            this.STALTAEHZ.Size = new System.Drawing.Size(1797, 280);
            this.STALTAEHZ.TabIndex = 2;
            this.STALTAEHZ.Text = "chart3";
            this.STALTAEHZ.MouseClick += new System.Windows.Forms.MouseEventHandler(this.STALTAEHZ_MouseClick);
            // 
            // test
            // 
            this.test.AutoSize = true;
            this.test.Location = new System.Drawing.Point(13, 13);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(46, 17);
            this.test.TabIndex = 3;
            this.test.Text = "label1";
            // 
            // STALTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1833, 912);
            this.Controls.Add(this.test);
            this.Controls.Add(this.STALTAEHZ);
            this.Controls.Add(this.STALTAEHN);
            this.Controls.Add(this.STALTAEHE);
            this.Name = "STALTA";
            this.Text = "STALTA";
            this.Load += new System.EventHandler(this.STALTA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart STALTAEHE;
        private System.Windows.Forms.DataVisualization.Charting.Chart STALTAEHN;
        private System.Windows.Forms.DataVisualization.Charting.Chart STALTAEHZ;
        private System.Windows.Forms.Label test;
    }
}