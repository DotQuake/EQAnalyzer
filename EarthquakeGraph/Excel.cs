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
    /// <summary>
    /// A Class mainly used for reading the CSV file.
    /// </summary>
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

        #region SETTERS AND GETTERS

        /// <summary>
        /// True for EQAnalyzer format
        /// False for Phivolcs format
        /// </summary>
        public bool Choose { get { return choose; } set { choose = value; } }
        /// <summary>
        /// Samples per second
        /// </summary>
        public int Sps { get { return sps; } set { sps = value; } }
        /// <summary>
        /// time in hours
        /// </summary>
        public int Hours { get { return hours; } set { hours = value; } }
        /// <summary>
        /// Longitude location of device
        /// </summary>
        public double Longitude { get { return longitude; } set { longitude = value; } }
        /// <summary>
        /// Latitude location of device
        /// </summary>
        public double Latitude { get { return latitude; } set { latitude = value; } }
        /// <summary>
        /// Degree of orientation
        /// </summary>
        public double CompassVal { get { return compassVal; } set { compassVal = value; } }
        /// <summary>
        /// Time seconds value
        /// </summary>
        public double Seconds { get { return seconds; } set { seconds = value; } }
        /// <summary>
        /// Year Month Day
        /// </summary>
        public string Date { get { return date; } set { date = value; } }
        /// <summary>
        /// Station ID of the device
        /// </summary>
        public string StationID { get { return stationID; } set { stationID = value; } }

        /// <summary>
        /// X-axis
        /// </summary>
        public List<double> EHEs
        {
            get { return this.EHE; }
            set { EHE = value; }
        }
        /// <summary>
        /// Y-axis
        /// </summary>
        public List<double> EHNs
        {
            get { return this.EHN; }
            set { EHN = value; }
        }
        /// <summary>
        /// Z-axis
        /// </summary>
        public List<double> EHZs
        {
            get { return this.EHZ; }
            set { EHZ = value; }
        }

        #endregion

        #region EXCEL_PART

        /// <summary>
        /// Sets the path of the chosed CSV file.
        /// </summary>
        /// <param name="path">Path of the file</param>
        public void setPath(string path)
        {
            this.path = path;
            this.wb = excel.Workbooks.Open(this.path);
            this.ws = this.wb.Worksheets[1];
            this.usedRange = ws.UsedRange;
        }
        /// <summary>
        /// Reads a specific row and column in excel
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string ReadCell(int i, int j)
        {
            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2.ToString();
            else
                return "";
        }
        /// <summary>
        /// Gets the max number of rows in the CSV file
        /// </summary>
        /// <returns>Returns the number of rows in the CSV file</returns>
        public int getMaxNumberCells()
        {
            return usedRange.Rows.Count - 5;
        }
        /// <summary>
        /// Reads the station id, date, hour, seconds, sps, longitude, latitude,
        /// and degree of orientation inside the CSV file
        /// </summary>
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
        /// <summary>
        /// Clears all values in the list of axis
        /// </summary>
        public void clearAxes()
        {
            this.EHE = null;
            this.EHN = null;
            this.EHZ = null;
        }
        /// <summary>
        /// Reads all values in the xyz axis in the CSV file
        /// </summary>
        /// <param name="startI">Starting line where first value is recorded in the CSV file</param>
        /// <param name="endI">Ending line of the axis</param>
        /// <param name="EHEend">column for x axis</param>
        /// <param name="EHNend">column for y axis</param>
        /// <param name="EHZend">column for z axis</param>
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
        /// <summary>
        /// Reads all axis
        /// </summary>
        public void readAllAxes()
        {
            ReadAxes(28, getMaxNumberCells(), 1, 2, 3);
        }
        /// <summary>
        /// Gets the value in the specified axis
        /// </summary>
        /// <param name="axis">The chosen axis</param>
        /// <param name="choose">True for EQAnal format: False for Phivolcs format</param>
        /// <returns>Returns list of double values </returns>
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
        /// <summary>
        /// Closes Excel. (LOL NO)
        /// </summary>
        public void Close()
        {
            this.wb.Close();
        }
        /// <summary>
        /// Gets the station ID of the CSV File
        /// </summary>
        /// <param name="choose">True for EQAnal format: False for Phivolcs format</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string getStationID(bool choose)
        {
            if(choose)
                return ReadCell(17, 1);
            else
                return ReadCell(14, 1);
        }
        /// <summary>
        /// Gets the date recorded in the CSV file
        /// </summary>
        /// <param name="choose">True for EQAnal format: False for Phivolcs format</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string getDate(bool choose)
        {
            if(choose)
                return ReadCell(20, 1);
            else
                return ReadCell(17, 1);
        }
        /// <summary>
        /// Gets the hour and minute in the CSV file
        /// </summary>
        /// <param name="choose">True for EQAnal format: False for Phivolcs format</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string getHourMin(bool choose)
        {
            if(choose)
                return ReadCell(21, 1);
            else
                return ReadCell(18, 1);
        }
        /// <summary>
        /// Gets the second in the CSV file
        /// </summary>
        /// <param name="choose">True for EQAnal format: False for Phivolcs format</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string getSecond(bool choose)
        {
            if(choose)
                return ReadCell(22, 1);
            else
                return ReadCell(19, 1);
        }
        /// <summary>
        /// Gets the SPS in the CSV file
        /// </summary>
        /// <param name="choose">True for EQAnal format: False for Phivolcs format</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string getSamplesPerSecond(bool choose)
        {
            if(choose)
                return ReadCell(23, 1);
            else
                return ReadCell(20, 1);
        }
        /// <summary>
        /// Gets the Longitude in the CSV file
        /// </summary>
        /// <param name="choose">True for EQAnal format. Only for EQAnal format</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string getLongitude(bool choose)
        {
            if(choose)
                return ReadCell(13, 2);
            else
                return "";
        }
        /// <summary>
        /// Gets the Latitude in the CSV file
        /// </summary>
        /// <param name="choose">True for EQAnal format. Only for EQAnal format</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string getLatitude(bool choose)
        {
            if(choose)
                return ReadCell(14, 2);
            else
                return "";
        }
        /// <summary>
        /// Gets the degree orientation in the CSV file
        /// </summary>
        /// <param name="choose">True for EQAnal format. Only for EQAnal format</param>
        /// <returns>Returns the value inside the cell in string format</returns>
        public string getCompassValue(bool choose)
        {
            if(choose)
                return ReadCell(15, 2);
            else
                return "";
        }
        
        #endregion

        #region CHART_PART
        /// <summary>
        /// Plots the data inside the list series in the chart
        /// </summary>
        /// <param name="chart1">Chart where the values will be plotted</param>
        /// <param name="series">List of values to be plotted</param>
        /// <param name="axis">Axis where the list is located</param>
        /// <param name="chartArea">Just put '0' lol</param>
        /// <param name="color">Color of the plotted line chart</param>
        public void creatChart(System.Windows.Forms.DataVisualization.Charting.Chart chart1, List<double> series, string axis, int chartArea, Color color)
        {
            chart1.Series.Clear();
            chart1.DataSource = series;
            var chart = chart1.ChartAreas[chartArea];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = false;

            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = series.Count;
            chart.AxisY.Minimum = series.Min()*1.1;
            chart.AxisY.Maximum = series.Max()*1.1;
            chart.AxisX.Interval = Math.Round((double)series.Count/9);
            chart.AxisY.Interval = Math.Round(((series.Max() + (Math.Abs(series.Min())))/5),2);
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
            for (int x = 0; x < series.Count; x++)
            {
                chart1.Series[axis].Points.AddXY(x, series[x]);
            }
        }
        
        
        #endregion
    }
}
