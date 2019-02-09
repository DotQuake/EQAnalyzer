using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;

namespace EarthquakeGraph
{
    public class Excel
    {
        private List<double> EHE = new List<double>();
        private List<double> EHN = new List<double>();
        private List<double> EHZ = new List<double>();
        private int sps;
        private int hours;
        private double longitude;
        private double latitude;
        private double compassVal;
        private double seconds;
        private string date;
        private string stationID;
        private string path = "";
        private bool choose = true;

        _Application excel = new _Excel.Application();
        private Workbook wb;
        private Worksheet ws;
        private Range usedRange;

        public bool Choose { get { return choose; } set { choose = value; } }
        public int Sps { get { return sps; } set { sps = value; } }
        public int Hours { get { return hours; } set { hours = value; } }
        public double Longitude { get { return longitude; } set { longitude = value; } }
        public double Latitude { get { return latitude; } set { latitude = value; } }
        public double CompassVal { get { return compassVal; } set { compassVal = value; } }
        public double Seconds { get { return seconds; } set { seconds = value; } }
        public string Date { get { return date; } set { date = value; } }
        public string StationID { get { return stationID; } set { stationID = value; } }


        public List<double> EHEs
        {
            get { return this.EHE; }
            set { EHE = value; }
        }
        public List<double> EHNs
        {
            get { return this.EHN; }
            set { EHN = value; }
        }
        public List<double> EHZs
        {
            get { return this.EHZ; }
            set { EHZ = value; }
        }


        #region EXCEL_PART

        public void setPath(string path)
        {
            this.path = path;
            this.wb = excel.Workbooks.Open(this.path);
            this.ws = this.wb.Worksheets[1];
            this.usedRange = ws.UsedRange;
        }

        public string ReadCell(int i, int j)
        {
            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2.ToString();
            else
                return "";
        }

        public int getMaxNumberCells()
        {
            return usedRange.Rows.Count - 5;
        }

        public void readOtherData()
        {
            sps = Convert.ToInt16(getSamplesPerSecond(choose));
            seconds = Convert.ToDouble(getSecond(choose));
            stationID = getStationID(choose);
            hours = Convert.ToInt16(getHourMin(choose));
            date = getDate(choose);
            //this.longitude = Convert.ToDouble(getLongitude());
            //this.latitude = Convert.ToDouble(getLatitude());
            //this.compassVal = Convert.ToDouble(getCompassValue());
            
        }

        public void clearAxes()
        {
            this.EHE = null;
            this.EHN = null;
            this.EHZ = null;
        }

        public void ReadAxes(int startI, int endI, int EHEend, int EHNend, int EHZend)
        {
            clearAxes();
            readOtherData();
            this.EHE = new List<double>();
            this.EHN = new List<double>();
            this.EHZ = new List<double>();
            Range rangeEHE = (Range)ws.Range[ws.Cells[startI, EHEend], ws.Cells[endI, EHEend]];
            Range rangeEHN = (Range)ws.Range[ws.Cells[startI, EHNend], ws.Cells[endI, EHNend]];
            Range rangeEHZ = (Range)ws.Range[ws.Cells[startI, EHZend], ws.Cells[endI, EHZend]];
            object[,] holderEHE = rangeEHE.Value2;
            object[,] holderEHN = rangeEHN.Value2;
            object[,] holderEHZ = rangeEHZ.Value2;
            for (int x = 1; x <= holderEHE.GetLength(0); x++)
            {
                for (int y = 1; y <= holderEHE.GetLength(1); y++)
                {
                    EHE.Add(Convert.ToDouble(holderEHE[x, y]));
                }
            }
            for (int x = 1; x <= holderEHN.GetLength(0); x++)
            {
                for (int y = 1; y <= holderEHN.GetLength(1); y++)
                {
                    EHN.Add(Convert.ToDouble(holderEHN[x, y]));
                }
            }
            for (int x = 1; x <= holderEHZ.GetLength(0); x++)
            {
                for (int y = 1; y <= holderEHZ.GetLength(1); y++)
                {
                    EHZ.Add(Convert.ToDouble(holderEHZ[x, y]));
                }
            }
            
            this.wb.Close(true);
        }

        public void readAllAxes()
        {
            ReadAxes(28, getMaxNumberCells(), 1, 2, 3);
        }

        public List<double> getAxis(int axis, bool choose)
        {
            double average = 0;
            if (!choose)
            {
                switch (axis)
                {
                    case 1:
                        {
                            average = EHE.Average();
                            for (int x = 0; x < EHE.Count; x++)
                            {
                                EHE[x] = Math.Round(EHE[x] - average);
                            }

                            return EHE;
                        }

                    case 2:
                        {
                            average = EHN.Average();
                            for (int x = 0; x < EHN.Count; x++)
                            {
                                EHN[x] = Math.Round(EHN[x] - average);
                            }
                            return EHN;
                        }

                    case 3:
                        {
                            average = EHZ.Average();
                            for (int x = 0; x < EHZ.Count; x++)
                            {
                                EHZ[x] = Math.Round(EHZ[x] - average);
                            }
                            return EHZ;
                        }
                    default:
                        return null;
                }
            }
            else
            {
                switch (axis)
                {
                    case 1:
                        {
                            return EHE;
                        }

                    case 2:
                        {
                            return EHN;
                        }

                    case 3:
                        {
                            return EHZ;
                        }
                    default:
                        return null;
                }
            }
        }

        public void Close()
        {
            this.wb.Close();
        }

        public string getStationID(bool choose)
        {
            if(choose)
                return ReadCell(17, 1);
            else
                return ReadCell(14, 1);
        }

        public string getDate(bool choose)
        {
            if(choose)
                return ReadCell(20, 1);
            else
                return ReadCell(17, 1);
        }

        public string getHourMin(bool choose)
        {
            if(choose)
                return ReadCell(21, 1);
            else
                return ReadCell(18, 1);
        }

        public string getSecond(bool choose)
        {
            if(choose)
                return ReadCell(22, 1);
            else
                return ReadCell(19, 1);
        }

        public string getSamplesPerSecond(bool choose)
        {
            if(choose)
                return ReadCell(23, 1);
            else
                return ReadCell(20, 1);
        }

        public string getLongitude(bool choose)
        {
            if(choose)
                return ReadCell(13, 2);
            else
                return "";
        }

        public string getLatitude(bool choose)
        {
            if(choose)
                return ReadCell(14, 2);
            else
                return "";
        }

        public string getCompassValue(bool choose)
        {
            if(choose)
                return ReadCell(15, 2);
            else
                return "";
        }
        
        #endregion

        #region CHART_PART
        public void creatChart(System.Windows.Forms.DataVisualization.Charting.Chart chart1, List<double> ar, string axis, int chartArea, Color color)
        {
            chart1.Series.Clear();
            chart1.DataSource = ar;
            var chart = chart1.ChartAreas[chartArea];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = false;

            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = ar.Count;
            chart.AxisY.Minimum = ar.Min()*1.1;
            chart.AxisY.Maximum = ar.Max()*1.1;
            chart.AxisX.Interval = Math.Round((double)ar.Count/9);
            chart.AxisY.Interval = Math.Round(((ar.Max() + (Math.Abs(ar.Min())))/5),2);
            chart1.Series.Add(axis);
            //chart1.Series[axis].ChartType = SeriesChartType.Spline;
            chart1.Series[axis].ChartType = SeriesChartType.Line;
            chart1.Series[axis].Color = color;
            chart1.Series[axis].IsVisibleInLegend = false;
            //chart1.Series[axis]["LineTension"] = "0.2";
            chart1.ChartAreas[chartArea].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[chartArea].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[chartArea].CursorX.AutoScroll = true;
            chart1.ChartAreas[chartArea].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[chartArea].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[chartArea].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[chartArea].AxisX.LabelStyle.Enabled = false;
            chart1.ChartAreas[chartArea].AxisY.LabelStyle.Enabled = false;

            //chart1.DataBind();
            for (int x = 0; x < ar.Count; x++)
            {
                chart1.Series[axis].Points.AddXY(x, ar[x]);
            }
        }

        public void zoomChart(System.Windows.Forms.DataVisualization.Charting.Chart chart1, string axis, int chartArea, int val)
        {
            var xAxis = chart1.ChartAreas[chartArea].AxisX;
            var yAxis = chart1.ChartAreas[chartArea].AxisY;
            try
            {
               // xAxis.ScaleView.Zoom();
               // yAxis.ScaleView.Zoom();
            }
            catch { }
        }
        
        #endregion
    }
}
