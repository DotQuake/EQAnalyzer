using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EarthquakeGraph
{
    public partial class Hysteresis : Form
    {
        EarthquakeAnalyzer eq = new EarthquakeAnalyzer();
        List<double> x;
        List<double> y;
        List<double> z;
        double start;
        double finish;
        double degree;
        public Hysteresis(List<double> EHE, List<double> EHN, List<double> EHZ, double start, double finish, double degree)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            x = new List<double>(EHE);
            y = new List<double>(EHN);
            z = new List<double>(EHZ);
            this.start = start;
            this.finish = finish;
            this.degree = degree;
        }

        private void Hysteresis_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = eq.calculateDirection(x, y, z, start, finish, degree, pictureBox1);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
