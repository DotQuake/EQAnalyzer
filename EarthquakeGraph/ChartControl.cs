using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace EarthquakeGraph
{
    public class ChartControl
    {
        public void createChart(Chart chart1, List<double> series, string axis, int chartArea, Color color, VerticalLineAnnotation line)
        {
            double max = 0;
            chart1.Series.Clear();
            chart1.DataSource = series;
            var chart = chart1.ChartAreas[chartArea];
            line.AxisX = chart.AxisX;
            line.AllowMoving = true;
            line.IsInfinitive = true;
            line.ClipToChartArea = chart.Name;
            line.LineColor = Color.Red;
            line.Visible = true;
            line.Width = 1;
            line.X = 0;
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = false;
            if (series.Max() > Math.Abs(series.Min()))
                max = series.Max() * 1.1;
            else
                max = Math.Abs(series.Min()) * 1.1;
            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = series.Count;
            chart.AxisY.Minimum = -max;
            chart.AxisY.Maximum = max;
            chart.AxisX.Interval = Math.Round((double)series.Count / 9);
            chart1.Legends.Clear();
            chart1.Series.Add(axis);
            chart1.Annotations.Add(line);
            chart1.Series[axis].ChartType = SeriesChartType.Line;
            chart1.Series[axis].Color = color;
            chart1.Series[axis].IsVisibleInLegend = false;
            chart1.ChartAreas[chartArea].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[chartArea].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[chartArea].CursorX.AutoScroll = true;
            chart1.ChartAreas[chartArea].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[chartArea].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[chartArea].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[chartArea].AxisX.LabelStyle.Enabled = false;
            chart1.ChartAreas[chartArea].AxisY.LabelStyle.Enabled = false;

            for (int x = 0; x < series.Count; x++)
            {
                chart1.Series[axis].Points.AddXY(x, series[x]);
            }
        }
        public void createChart(Chart chart1, List<double> series, string axis, int chartArea, Color color)
        {
            double max = 0;
            chart1.Series.Clear();
            chart1.DataSource = series;
            var chart = chart1.ChartAreas[chartArea];

            chart.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = false;
            if (series.Max() > Math.Abs(series.Min()))
                max = series.Max() * 1.1;
            else
                max = Math.Abs(series.Min()) * 1.1;
            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = series.Count;
            chart.AxisY.Minimum = -max;
            chart.AxisY.Maximum = max;
            chart.AxisX.Interval = Math.Round((double)series.Count / 9);
            chart1.Series.Add(axis);
            chart1.Legends.Clear();
            chart1.Series[axis].ChartType = SeriesChartType.Line;
            chart1.Series[axis].Color = color;
            chart1.Series[axis].IsVisibleInLegend = false;
            chart1.ChartAreas[chartArea].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[chartArea].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[chartArea].CursorX.AutoScroll = true;
            chart1.ChartAreas[chartArea].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[chartArea].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[chartArea].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[chartArea].AxisX.LabelStyle.Enabled = false;
            chart1.ChartAreas[chartArea].AxisY.LabelStyle.Enabled = false;

            //chart1.DataBind();
            for (int x = 0; x < series.Count; x++)
            {
                chart1.Series[axis].Points.AddXY(x, series[x]);
            }
        }
        
    }
}
