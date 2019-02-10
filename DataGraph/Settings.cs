using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGraph
{
    public partial class Settings : Form
    {
        private int staTime = 3;
        private int ltaTime = 30;
        private double trigger = 2.5;
        private double detrigger = 0.5;
        private string path = "";
        public int StaTime
        {
            get { return staTime*100; }
            set { staTime = value; }
        }
        public int LtaTime
        {
            get { return ltaTime*100; }
            set { ltaTime = value; }
        }
        public double Trigger
        {
            get { return trigger; }
            set { this.trigger = value; }
        }
        public double Detrigger
        {
            get { return detrigger; }
            set { this.detrigger = value; }
        }
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        public Settings(int sta, int lta, double trgr, double dtrgr, string opnpath)
        {
            InitializeComponent();
            staTime = sta;
            ltaTime = lta;
            trigger = trgr;
            detrigger = dtrgr;
            path = opnpath;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            staTxtBox.Text = (staTime/100).ToString();
            ltaTxtBox.Text = (ltaTime/100).ToString();
            thresholdTxtBox.Text = trigger.ToString();
            defaultPathTxtBox.Text = path;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            staTime = Convert.ToInt16(staTxtBox.Text);
            ltaTime = Convert.ToInt16(ltaTxtBox.Text);
            //trigger = Convert.ToInt16(thresholdTxtBox.Text);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
        }

        private void browseFolderBtn_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog fld = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Choose directory";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                defaultPathTxtBox.Text = path;
            }
        }
    }
}
