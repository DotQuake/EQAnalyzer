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
        Form1 form1 = new Form1();
        List<double> STAEHELTA;
        List<double> STAEHNLTA;
        List<double> STAEHZLTA;
        Excel excel = new Excel();
        EarthquakeAnalyzer eq = new EarthquakeAnalyzer();
        System.Drawing.Point? prevPosition = null;
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
            excel.creatChart(STALTAEHE, STAEHELTA, "x", 0, Color.Black);
            excel.creatChart(STALTAEHN, STAEHNLTA, "y", 0, Color.Pink);
            excel.creatChart(STALTAEHZ, STAEHZLTA, "z", 0, Color.Yellow);
        }
        #region MouseClickEvents
        private void STALTAEHE_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == (System.Drawing.Point)prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = STALTAEHE.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

            foreach (var result in results)
            {
                var prop = result.Object as DataPoint;
                if (prop != null)
                {
                    var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                    var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                    //check if cursor is 2 pixels close to point
                    if (Math.Abs(pos.X - pointXPixel) < 2 && Math.Abs(pos.Y - pointYPixel) < 2)
                    {

                        tooltip.Show(prop.YValues[0].ToString(), this.STALTAEHE, pos.X, pos.Y - 15);
                        test.Text = prop.YValues[0].ToString() + " " + STAEHELTA[(int)prop.XValue].ToString() + " " + STAEHNLTA[(int)prop.XValue].ToString();
                    }
                }
            }
        }

        private void STALTAEHN_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            //double posx = 0;
            if (prevPosition.HasValue && pos == (System.Drawing.Point)prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = STALTAEHN.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

            foreach (var result in results)
            {
                var prop = result.Object as DataPoint;
                if (prop != null)
                {
                    var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                    var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                    //check if cursor is 2 pixels close to point
                    if (Math.Abs(pos.X - pointXPixel) < 2 && Math.Abs(pos.Y - pointYPixel) < 2)
                    {

                        tooltip.Show(prop.YValues[0].ToString(), this.STALTAEHN, pos.X, pos.Y - 15);
                    }
                }
            }
        }

        private void STALTAEHZ_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            //double posx = 0;
            if (prevPosition.HasValue && pos == (System.Drawing.Point)prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = STALTAEHZ.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

            foreach (var result in results)
            {
                var prop = result.Object as DataPoint;
                if (prop != null)
                {
                    var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                    var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                    //check if cursor is 2 pixels close to point
                    if (Math.Abs(pos.X - pointXPixel) < 2 && Math.Abs(pos.Y - pointYPixel) < 2)
                    {

                        tooltip.Show(prop.YValues[0].ToString(), this.STALTAEHZ, pos.X, pos.Y - 15);
                    }
                }
            }
        }
        #endregion

    }
}
