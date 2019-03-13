namespace DataGraph
{
    partial class Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.thresholdTxtBox = new System.Windows.Forms.TextBox();
            this.ltaTxtBox = new System.Windows.Forms.TextBox();
            this.staTxtBox = new System.Windows.Forms.TextBox();
            this.threshold = new System.Windows.Forms.Label();
            this.lta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sta = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.specifiedFolder = new System.Windows.Forms.GroupBox();
            this.browseFolderBtn = new System.Windows.Forms.Button();
            this.defaultPathTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.specifiedFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.thresholdTxtBox);
            this.groupBox1.Controls.Add(this.ltaTxtBox);
            this.groupBox1.Controls.Add(this.staTxtBox);
            this.groupBox1.Controls.Add(this.threshold);
            this.groupBox1.Controls.Add(this.lta);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sta);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "STA/LTA Settings";
            // 
            // thresholdTxtBox
            // 
            this.thresholdTxtBox.Location = new System.Drawing.Point(103, 81);
            this.thresholdTxtBox.Name = "thresholdTxtBox";
            this.thresholdTxtBox.Size = new System.Drawing.Size(100, 22);
            this.thresholdTxtBox.TabIndex = 1;
            // 
            // ltaTxtBox
            // 
            this.ltaTxtBox.Location = new System.Drawing.Point(103, 53);
            this.ltaTxtBox.Name = "ltaTxtBox";
            this.ltaTxtBox.Size = new System.Drawing.Size(100, 22);
            this.ltaTxtBox.TabIndex = 1;
            // 
            // staTxtBox
            // 
            this.staTxtBox.Location = new System.Drawing.Point(103, 25);
            this.staTxtBox.Name = "staTxtBox";
            this.staTxtBox.Size = new System.Drawing.Size(100, 22);
            this.staTxtBox.TabIndex = 1;
            // 
            // threshold
            // 
            this.threshold.AutoSize = true;
            this.threshold.Location = new System.Drawing.Point(24, 81);
            this.threshold.Name = "threshold";
            this.threshold.Size = new System.Drawing.Size(72, 17);
            this.threshold.TabIndex = 0;
            this.threshold.Text = "Threshold";
            // 
            // lta
            // 
            this.lta.AutoSize = true;
            this.lta.Location = new System.Drawing.Point(24, 56);
            this.lta.Name = "lta";
            this.lta.Size = new System.Drawing.Size(34, 17);
            this.lta.TabIndex = 0;
            this.lta.Text = "LTA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "sec (eg. 20)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "sec (eg. 1)";
            // 
            // sta
            // 
            this.sta.AutoSize = true;
            this.sta.Location = new System.Drawing.Point(24, 28);
            this.sta.Name = "sta";
            this.sta.Size = new System.Drawing.Size(35, 17);
            this.sta.TabIndex = 0;
            this.sta.Text = "STA";
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(78, 226);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(74, 31);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(158, 226);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(74, 31);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // specifiedFolder
            // 
            this.specifiedFolder.Controls.Add(this.browseFolderBtn);
            this.specifiedFolder.Controls.Add(this.defaultPathTxtBox);
            this.specifiedFolder.Controls.Add(this.label1);
            this.specifiedFolder.Location = new System.Drawing.Point(13, 135);
            this.specifiedFolder.Name = "specifiedFolder";
            this.specifiedFolder.Size = new System.Drawing.Size(286, 73);
            this.specifiedFolder.TabIndex = 2;
            this.specifiedFolder.TabStop = false;
            this.specifiedFolder.Text = "Choose specified folder";
            // 
            // browseFolderBtn
            // 
            this.browseFolderBtn.Location = new System.Drawing.Point(233, 24);
            this.browseFolderBtn.Name = "browseFolderBtn";
            this.browseFolderBtn.Size = new System.Drawing.Size(33, 32);
            this.browseFolderBtn.TabIndex = 2;
            this.browseFolderBtn.Text = "...";
            this.browseFolderBtn.UseVisualStyleBackColor = true;
            this.browseFolderBtn.Click += new System.EventHandler(this.browseFolderBtn_Click);
            // 
            // defaultPathTxtBox
            // 
            this.defaultPathTxtBox.Location = new System.Drawing.Point(65, 29);
            this.defaultPathTxtBox.Name = "defaultPathTxtBox";
            this.defaultPathTxtBox.Size = new System.Drawing.Size(152, 22);
            this.defaultPathTxtBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Open";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "(eg. 2.5)";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 269);
            this.Controls.Add(this.specifiedFolder);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.specifiedFolder.ResumeLayout(false);
            this.specifiedFolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox thresholdTxtBox;
        private System.Windows.Forms.TextBox ltaTxtBox;
        private System.Windows.Forms.TextBox staTxtBox;
        private System.Windows.Forms.Label threshold;
        private System.Windows.Forms.Label lta;
        private System.Windows.Forms.Label sta;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox specifiedFolder;
        private System.Windows.Forms.TextBox defaultPathTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseFolderBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}