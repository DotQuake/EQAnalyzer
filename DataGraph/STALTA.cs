using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EarthquakeGraph;

namespace DataGraph
{
    public partial class STALTA : Form
    {
        public static VerticalLineAnnotation VA1 = new VerticalLineAnnotation();
        Form1 form1 = new Form1();
        List<double> STAEHELTA;
        List<double> STAEHNLTA;
        List<double> STAEHZLTA;
        EarthquakeAnalyzer eq = new EarthquakeAnalyzer();
        ChartControl chartControl = new ChartControl();
        //System.Drawing.Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        public STALTA(List<double> EHESTALTA, List<double> EHNSTALTA, List<double> EHZSTALTA)
        {
            InitializeComponent();
            STAEHELTA = new List<double>(EHESTALTA);
            STAEHNLTA = new List<double>(EHNSTALTA);
            STAEHZLTA = new List<double>(EHZSTALTA);
        }

        private void STALTA_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            
            chartControl.createChart(STALTAEHE, STAEHELTA, "x", 0, Color.Black);
            chartControl.createChart(STALTAEHN, STAEHNLTA, "y", 0, Color.Pink);
            chartControl.createChart(STALTAEHZ, STAEHZLTA, "z", 0, Color.Yellow);
            //VA1.Visible = false;
        }
       
    }
}
