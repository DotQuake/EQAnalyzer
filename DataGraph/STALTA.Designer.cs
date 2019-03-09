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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.STALTAEHE = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.STALTAEHN = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.STALTAEHZ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STALTAEHZ)).BeginInit();
            this.SuspendLayout();
            // 
            // STALTAEHE
            // 
            this.STALTAEHE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.STALTAEHE.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.STALTAEHE.Legends.Add(legend4);
            this.STALTAEHE.Location = new System.Drawing.Point(12, 62);
            this.STALTAEHE.Name = "STALTAEHE";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.STALTAEHE.Series.Add(series4);
            this.STALTAEHE.Size = new System.Drawing.Size(1797, 280);
            this.STALTAEHE.TabIndex = 0;
            this.STALTAEHE.Text = "chart1";
            // 
            // STALTAEHN
            // 
            this.STALTAEHN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.Name = "ChartArea1";
            this.STALTAEHN.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.STALTAEHN.Legends.Add(legend5);
            this.STALTAEHN.Location = new System.Drawing.Point(12, 348);
            this.STALTAEHN.Name = "STALTAEHN";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.STALTAEHN.Series.Add(series5);
            this.STALTAEHN.Size = new System.Drawing.Size(1797, 280);
            this.STALTAEHN.TabIndex = 1;
            this.STALTAEHN.Text = "chart2";
            // 
            // STALTAEHZ
            // 
            this.STALTAEHZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea6.Name = "ChartArea1";
            this.STALTAEHZ.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.STALTAEHZ.Legends.Add(legend6);
            this.STALTAEHZ.Location = new System.Drawing.Point(12, 634);
            this.STALTAEHZ.Name = "STALTAEHZ";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.STALTAEHZ.Series.Add(series6);
            this.STALTAEHZ.Size = new System.Drawing.Size(1797, 280);
            this.STALTAEHZ.TabIndex = 2;
            this.STALTAEHZ.Text = "chart3";
            // 
            // STALTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1833, 912);
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

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart STALTAEHE;
        private System.Windows.Forms.DataVisualization.Charting.Chart STALTAEHN;
        private System.Windows.Forms.DataVisualization.Charting.Chart STALTAEHZ;
    }
}