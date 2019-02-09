using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;
using EarthquakeGraph;


namespace DataGraph
{
    public partial class Form1 : Form
    {
        #region Initialize Variables
        public string fileName;    
        public STALTA childform;
        public List<double> EHE, EHN, EHZ, hold;
        public List<double> STAEHE, LTAEHE, STAEHN, LTAEHN, STAEHZ, LTAEHZ, STALTAEHE, STALTAEHN, STALTAEHZ;
        public volatile bool killThread = false;
        public double sec, timesec, hourmin, degree, longitude, latitude, magnitude, hypocenter;
        public string stationID, date, spss;
        public bool fileOpened = false, clicked = false, psSet = false, choose = false;
        public double pwaveEHE, swaveEHE, pwaveEHN, swaveEHN, pwaveEHZ, swaveEHZ, holder = 0, xVal = 0, xp, xs;
        public int axis,sps;
        string state = "checkIfTriggered";
        double trigger = 2.5, detrigger = 0.5, triggertime = 10;
        int start, end;
        EarthquakeAnalyzer eq = new EarthquakeAnalyzer();
        public Excel excel = new Excel();
        System.Drawing.Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            //..FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            if (choose)
                statuses.Text = "Status: Load EQAnalyzer format";
            else
                statuses.Text = "Status: Load Phivolcs format";
        }

        private void l(object sender, EventArgs e)
        {
            
        }

        #region MouseClickEvents
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == (System.Drawing.Point)prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = EHEchart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

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
                        timesec = (prop.XValue / sps) + sec;
                        header.Text = stationID + ".EHZ. " + date + "  " + hourmin.ToString() + "  " + timesec.ToString() + "  " + sps.ToString() + "sps" + "  " + prop.YValues[0].ToString() + "/\t EHE: "+EHE[(int)prop.XValue] + " EHN: "+EHN[(int)prop.XValue] + " EHZ: "+EHZ[(int)prop.XValue];
                        xVal = prop.XValue;
                    }
                }
            }
        }

        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == (System.Drawing.Point)prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = EHNchart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

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
                        timesec = (prop.XValue / sps) + sec;
                        header.Text = stationID + ".EHZ. " + date + "  " + hourmin.ToString() + "  " + timesec.ToString() + "  " + sps.ToString() + "sps" + "  " + prop.YValues[0].ToString(); xVal = prop.XValue;
                    }
                }
            }
        }

        private void chart3_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == (System.Drawing.Point)prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = EHZchart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);

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
                        timesec = (prop.XValue / sps) + sec;
                        header.Text = stationID + ".EHZ. " + date + "  " + hourmin.ToString() + "  " + timesec.ToString() + "  " + sps.ToString() + "sps" + "  " + prop.YValues[0].ToString();
                        xVal = prop.XValue;
                    }
                }
            }
        }


        private void pWaveBtn_Click(object sender, EventArgs e)
        {
            if (xVal != 0 && fileOpened)
            {
                xp = xVal;
                clicked = true;
                pwaveEHE = EHE[(int)xVal];
                pwaveEHN = EHN[(int)xVal];
                pwaveEHZ = EHZ[(int)xVal];
                statuses.Text = "Status: P-wave set: "+xVal;
                statusStrip1.Refresh();
                xVal = 0;
            }
            else
            {
                statuses.Text = "Status: Error no value selected";
                statusStrip1.Refresh();
            }
        }

        private void sWaveBtn_Click(object sender, EventArgs e)
        {
            if (xVal != 0 && fileOpened)
            {
                if (clicked)
                {
                    xs = xVal;
                    swaveEHE = EHE[(int)xVal];
                    swaveEHN = EHN[(int)xVal];
                    swaveEHZ = EHZ[(int)xVal];
                    clicked = false;
                    psSet = true;
                    statuses.Text = "Status: S-wave set: "+xVal;
                    statusStrip1.Refresh();
                    xVal = 0;
                }
                else
                {
                    statuses.Text = "Status: Choose P-wave  first";
                    statusStrip1.Refresh();
                }
            }
            else
            {
                statuses.Text = "Status: Error no value selected";
                statusStrip1.Refresh();
            }
        }

        #endregion

        public void clearAll()
        {
            EHE = null;
            EHN = null;
            EHZ = null;
            STAEHE = null;
            LTAEHE = null;
            STAEHN = null;
            LTAEHN = null;
            STAEHZ = null;
            LTAEHZ = null;
            eq.EHEs = null;
            eq.EHNs = null;
            eq.EHZs = null;
            excel.EHEs = null;
            excel.EHNs = null;
            excel.EHZs = null;
            EHEchart.Visible = true;
            EHNchart.Visible = true;
            EHZchart.Visible = true;
            EHEchart.Series.Clear();
            EHNchart.Series.Clear();
            EHZchart.Series.Clear();
            max1.Visible = true;
            max2.Visible = true;
            max3.Visible = true;
            min1.Visible = true;
            min2.Visible = true;
            min3.Visible = true;
            station1.Visible = true;
            station2.Visible = true;
            station3.Visible = true;
            x.Visible = true;
            y.Visible = true;
            z.Visible = true;


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading.Maximum = 100;
            loading.Step = 1;
            loading.Value = 0;
            backgroundWorker1.RunWorkerAsync();
            clearAll();
            OpenFileDialog opensesame = new OpenFileDialog();
            opensesame.Title = "Open csv File";
            opensesame.Filter = "CSV files|*.csv";
            opensesame.InitialDirectory = @"E:\Kiting\CSVFiles";
            if (opensesame.ShowDialog() == DialogResult.OK)
            {
                fileName = opensesame.FileName.ToString();
            }
            else
                MessageBox.Show("No file was selected");
            try
            {
                excel.Choose = choose;
                excel.setPath(fileName);
                excel.readAllAxes();
                sps = excel.Sps;
                sec = excel.Seconds;
                stationID = excel.StationID;
                station1.Text = stationID;
                station2.Text = stationID;
                station3.Text = stationID;
                x.Text = "EHE";
                y.Text = "EHN";
                z.Text = "EHZ";
                date = excel.Date;
                hourmin = excel.Hours;
                //degree = excel.CompassVal;
                //longitude = excel.Longitude;
                //latitude = excel.Latitude;
                eq.EHEs = excel.getAxis(1, choose);
                eq.EHNs = excel.getAxis(2, choose);
                eq.EHZs = excel.getAxis(3, choose);
                fileOpened = true;
                EHE = eq.EHEs;
                EHN = eq.EHNs;
                EHZ = eq.EHZs;
                staltaThread();
                max1.Text = EHE.Max().ToString();
                min1.Text = EHE.Min().ToString();
                max2.Text = EHN.Max().ToString();
                min2.Text = EHN.Min().ToString();
                max3.Text = EHZ.Max().ToString();
                min3.Text = EHZ.Min().ToString();
                excel.creatChart(EHEchart, EHE, "x axis", 0, Color.Gray);
                excel.creatChart(EHNchart, EHN, "y axis", 0, Color.Gray);
                excel.creatChart(EHZchart, EHZ, "z axis", 0, Color.Gray);
            }
            catch (Exception c) { MessageBox.Show("Wrong file name selected"); }
            
            //----------------------TestChart---------------------
            
        }

        private void sTALTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileOpened)
            {

                childform = new STALTA(STALTAEHE, STALTAEHN, STALTAEHZ);
                childform.Show();
            }
            else
                MessageBox.Show("No file was open");
        }

        public void staltaThread()
        {
            STALTAEHE = eq.getSTALTAratio(EHE, 200, 3000);
            STALTAEHN = eq.getSTALTAratio(EHN, 200, 3000);
            STALTAEHZ = eq.getSTALTAratio(EHZ, 200, 3000);
        }

        private void checkEQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            magnitude = 0;
            degree = 0;
            hypocenter = 0;
            bool choise = false;
           /* for (int x = 1; x <= 3; x++)
            {
                if (checkEarhtquakeV2(STALTAEHE, x, sps))
                {
                    choise = true;
                    break;
                }
            }
            if (choise)
            {
                if (eq.Axis == 1)
                {
                    degree = eq.calculateDirection(EHE[(int)xp], EHN[(int)xp], EHZ[(int)xp], 0) + degree;
                    magnitude = eq.calculateMagnitude(EHE, xp, xs);
                    hypocenter = eq.calculateHypocenter(pwaveEHE, swaveEHE, sps, sec);
                }
                else if (eq.Axis == 2)
                {
                    degree = eq.calculateDirection(EHE[(int)xp], EHN[(int)xp], EHZ[(int)xp], 0) + degree;
                    magnitude = eq.calculateMagnitude(EHN, xp, xs);
                    hypocenter = eq.calculateHypocenter(pwaveEHN, swaveEHN, sps, sec);
                }
                else
                {
                    degree = eq.calculateDirection(EHE[(int)xp], EHN[(int)xp], EHZ[(int)xp], 0) + degree;
                    magnitude = eq.calculateMagnitude(EHZ, xp, xs);
                    hypocenter = eq.calculateHypocenter(pwaveEHZ, swaveEHZ, sps, sec);
                }
                MessageBox.Show("Eathquake detected\nMagnitude:\t" + magnitude.ToString() + "\nDistance:\t" + "\t" + hypocenter + "km" + "\nDirection:\t" + degree + "\nAxis:\t" + eq.Axis);
                //MessageBox.Show("Earthquake Detected");
            }
            else
                MessageBox.Show("No Earthquake Detected");
            /*if (fileOpened)
            {
                if (psSet)
                {
                    if (xs < xp)
                    {
                        MessageBox.Show("P-wave must be earlier than S-wave");
                        xs = 0;
                        xp = 0;
                    }
                    else
                    {
                        if (checkEarhtquakeV2(STALTAEHE, 1, sps) || checkEarhtquakeV2(STALTAEHN, 2, sps) || checkEarhtquakeV2(STALTAEHZ, 3, sps))
                        {
                            if (eq.Axis == 1)
                            {
                                degree = eq.calculateDirection(EHE[(int)xp], EHN[(int)xp], EHZ[(int)xp], 0) + degree;
                                magnitude = eq.calculateMagnitude(EHE, xp, xs);
                                hypocenter = eq.calculateHypocenter(pwaveEHE, swaveEHE, sps, sec);
                            }
                            else if (eq.Axis == 2)
                            {
                                degree = eq.calculateDirection(EHE[(int)xp], EHN[(int)xp], EHZ[(int)xp], 0) + degree;
                                magnitude = eq.calculateMagnitude(EHN, xp, xs);
                                hypocenter = eq.calculateHypocenter(pwaveEHN, swaveEHN, sps, sec);
                            }
                            else
                            {
                                degree = eq.calculateDirection(EHE[(int)xp], EHN[(int)xp], EHZ[(int)xp], 0) + degree;
                                magnitude = eq.calculateMagnitude(EHZ, xp, xs);
                                hypocenter = eq.calculateHypocenter(pwaveEHZ, swaveEHZ, sps, sec);
                            }
                            MessageBox.Show("Eathquake detected\nMagnitude:\t" + magnitude.ToString() + "\nDistance:\t" + "\t" + hypocenter + "km" + "\nDirection:\t" + degree + "\nAxis:\t" + eq.Axis);
                            //MessageBox.Show("Earthquake Detected");
                        }
                        else
                            MessageBox.Show("No Earthquake Detected");
                    }
                }
                else
                    MessageBox.Show("Set P-wave and S-wave first");
            }*/

        }

        private void downloadCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadData data = new DownloadData();
            data.Show();
        }

        private void philvolcsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choose = false;
            excel.Choose = choose;
            statuses.Text = "Status: Load Phivolcs format";
        }

        private void eQAnalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choose = true;
            excel.Choose = choose;
            statuses.Text = "Status: Load EQAnalyzer format";
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string uten = null;
            foreach(var num in checkEarhtquakeV2(STALTAEHE,1,sps))
            {
                uten += num;
            }
            MessageBox.Show(uten+"\n");
            
        }

        private void testV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string uten = null;
            for (int x = 0; x < 300; x++)
            {
                uten += STALTAEHE[x].ToString() + "\n";
            }
            MessageBox.Show(uten);            
        }
        public List<string> checkEarhtquakeV2(List<double> stalta, int axis, int sps)
        {
            start = 0;
            end = 0;
            List<string> output = new List<string>();
            bool cond = false, finish = false;
            state = "checkIfTriggered";
            while (!finish)
            {
                switch (state)
                {
                    case "checkIfTriggered":
                        {
                            for (int x = 0; x < stalta.Count; x++)
                            {
                                if (stalta[x] > trigger)
                                {
                                    output.Add("trigger: " + stalta[x].ToString() + "\n");
                                    start = x;
                                    state = "checkIfDetriggered";
                                    break;
                                }
                                else if (x == stalta.Count)
                                {
                                    output.Add("finished not triggered");
                                    finish = true;
                                }
                            }
                            //if (state == "checkSTA")
                            // return cond;
                            break;
                        }
                    case "checkIfDetriggered":
                        {
                            for (int x = start; x < stalta.Count; x++)
                            {
                                if (stalta[x] < detrigger)
                                {
                                    output.Add("detrigger: " + stalta[x].ToString() + "\n");
                                    end = x;
                                    state = "checkActiveTime";
                                    break;
                                }
                                else if(x == stalta.Count)
                                {
                                    output.Add("finished not detriggered");
                                    finish = true;
                                }
                            }
                            break;
                        }
                    case "checkActiveTime":
                        {
                            double res = (end - start) / sps;
                            output.Add("active time: " + res.ToString());
                            if (res > (triggertime))
                            {
                                cond = true;
                            }
                            else
                            {
                                cond = false;
                            }
                            finish = true;
                            break;
                        }
                }
            }
            output.Add("\ncond: " + cond.ToString());
            this.axis = axis;
            return output;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
