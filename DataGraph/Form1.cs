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
//using System.Windows.
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;
using EarthquakeGraph;


namespace DataGraph
{
    public partial class Form1 : Form
    {
        #region Initialize Variables
        static VerticalLineAnnotation VA1 = new VerticalLineAnnotation();
        static VerticalLineAnnotation VA2 = new VerticalLineAnnotation();
        static VerticalLineAnnotation VA3 = new VerticalLineAnnotation();
        static RectangleAnnotation RA = new RectangleAnnotation();
        static VerticalLineAnnotation PwaveX = new VerticalLineAnnotation();
        static VerticalLineAnnotation SwaveX = new VerticalLineAnnotation();
        static VerticalLineAnnotation PwaveY = new VerticalLineAnnotation();
        static VerticalLineAnnotation SwaveY = new VerticalLineAnnotation();
        static VerticalLineAnnotation PwaveZ = new VerticalLineAnnotation();
        static VerticalLineAnnotation SwaveZ = new VerticalLineAnnotation();
        public string fileName;    
        public STALTA childform;
        public List<double> EHE, EHN, EHZ, hold;
        public List<double> STAEHE, LTAEHE, STAEHN, LTAEHN, STAEHZ, LTAEHZ, STALTAEHE, STALTAEHN, STALTAEHZ;
        public volatile bool killThread = false;
        public double sec, timesec, hourmin, degree, longitude, latitude, magnitude, hypocenter;
        public string stationID, date, spss, mx1, mn1, mx2, mn2, mx3, mn3;
        public bool fileOpened = false, clicked = false, psSet = false, choose = false, threadbool = false;
        public double pwaveEHE, swaveEHE, pwaveEHN, swaveEHN, pwaveEHZ, swaveEHZ, holder = 0, xVal = 0, xp, xs;
        public int axis,sps;
        public int statime = 200, ltatime = 3000;
        public int listX = 0;
        string openpath = @"E:\Kiting\CSVFiles";
        EarthquakeAnalyzer eq = new EarthquakeAnalyzer();
        public Excel excel = new Excel();
        //System.Drawing.Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        //Thread thread1, thread2, thread3;
       
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (choose)
                statuses.Text = "Status: Load EQAnalyzer format";
            else
                statuses.Text = "Status: Load Phivolcs format";
            PwaveX.Visible = false;
            PwaveX.Visible = false;
            PwaveZ.Visible = false;
            SwaveX.Visible = false;
            SwaveY.Visible = false;
            SwaveZ.Visible = false;

            tooltip.AutomaticDelay = 3000;
        }

        private void l(object sender, EventArgs e)
        {
            
        }

        #region MouseClickEvents
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            EHEchart.Update();
        }

        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void chart3_MouseClick(object sender, MouseEventArgs e)
        {/*
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
          * */
        }

        

        private void pWaveBtn_Click(object sender, EventArgs e)
        {
            if (fileOpened)
            {
                xp = listX;
                clicked = true;
                pwaveEHE = EHE[listX];
                pwaveEHN = EHN[listX];
                pwaveEHZ = EHZ[listX];
                statuses.Text = "Status: P-wave set: " + listX;
                statusStrip1.Refresh();
               
                PwaveX.X = listX;
                PwaveY.X = listX;
                PwaveZ.X = listX;
                PwaveX.Visible = true;
                PwaveY.Visible = true;
                PwaveZ.Visible = true;
                VA1.X = 0;
                VA2.X = 0;
                VA3.X = 0;
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
            if (fileOpened)
            {
                if (clicked)
                {
                    xs = listX;
                    swaveEHE = EHE[listX];
                    swaveEHN = EHN[listX];
                    swaveEHZ = EHZ[listX];
                    clicked = false;
                    psSet = true;
                    statuses.Text = "Status: S-wave set: " + listX;
                    statusStrip1.Refresh();
                    SwaveX.X = listX;
                    SwaveY.X = listX;
                    SwaveZ.X = listX;
                    SwaveX.Visible = true;
                    SwaveY.Visible = true;
                    SwaveZ.Visible = true;
                    VA1.X = 0;
                    VA2.X = 0;
                    VA3.X = 0;
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

        

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loading.Maximum = 100;
            loading.Step = 1;
            loading.Value = 0;
            backgroundWorker1.RunWorkerAsync();
            
            OpenFileDialog opensesame = new OpenFileDialog();
            opensesame.Title = "Open csv File";
            opensesame.Filter = "CSV files|*.csv";
            opensesame.InitialDirectory = openpath;
            if (opensesame.ShowDialog() == DialogResult.OK)
            {
                fileName = opensesame.FileName.ToString();
                clearAll();
                try
                {
                    excel.Choose = choose;
                    excel.setPath(fileName);
                    excel.readAllAxes();
                    sps = excel.Sps;
                    sec = excel.Seconds;
                    stationID = excel.StationID;
                    initializeAll();
                    setRA();
                    setWaveAnnotation(SwaveX, 100, EHEchart);
                    setWaveAnnotation(SwaveY, 100, EHNchart);
                    setWaveAnnotation(SwaveZ, 100, EHZchart);
                    setWaveAnnotation(PwaveX, 100, EHEchart);
                    setWaveAnnotation(PwaveY, 100, EHNchart);
                    setWaveAnnotation(PwaveZ, 100, EHZchart);
                }
                catch (Exception) { MessageBox.Show("Wrong file name selected"); }
            }
            else
                MessageBox.Show("No file was selected");
        }

       

        //Events

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

        private void checkEQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            magnitude = 0;
            degree = 0;
            hypocenter = 0;
            if (fileOpened)
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
                        if (eq.checkEarhtquakeV2(STALTAEHE, 1, sps) || eq.checkEarhtquakeV2(STALTAEHN, 2, sps) || eq.checkEarhtquakeV2(STALTAEHZ, 3, sps))
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
            }

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
            MessageBox.Show(eq.calculateMagnitude(EHE, xp, xs).ToString());
        }

        private void testV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double dir = eq.calculateDirection(EHE, EHN, EHZ, xp, xs);
            MessageBox.Show(dir.ToString());            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Settings set = new Settings(statime, ltatime, eq.Trigger, eq.Detrigger, openpath);
            if (set.ShowDialog() == DialogResult.OK)
            {
                eq.Trigger = set.Trigger;
                eq.Detrigger = set.Detrigger;
                openpath = set.Path;
                statime = set.StaTime;
                ltatime = set.LtaTime;
                MessageBox.Show(eq.Trigger+"\n"+eq.Detrigger+"\n"+statime+"\n"+ltatime+"\n"+openpath);
            }
        }

        private void pWaveBtn_MouseHover(object sender, EventArgs e)
        {
            //tooltip.InitialDelay = 3000;
            //tooltip.
            tooltip.Show("Sets primary wave of Earthquake", this.pWaveBtn, 1500);
        }

        private void sWaveBtn_MouseHover(object sender, EventArgs e)
        {
            //tooltip.InitialDelay = 3000;
            //tooltip.AutomaticDelay = 3000;
            tooltip.Show("Sets secondary wave of Earthquake", this.pWaveBtn, 1500);
        }

        private void EHEchart_AnnotationPositionChanging(object sender, AnnotationPositionChangingEventArgs e)
        {
            if (sender == VA3)
                RA.X = VA3.X - (RA.Width / 2);
            listX = (int)VA1.X;
            timesec = (listX / sps) + sec;
            hourmin = timesec > 60 ? hourmin + 1 : hourmin;
            try
            {
                header.Text = stationID + ".EHZ. " + date + "  " + hourmin.ToString() + "  " + timesec.ToString() + "  " + sps.ToString() + "sps" + "/\t EHE: " + EHE[listX] + " EHN: " + EHN[listX] + " EHZ: " + EHZ[listX];
            }
            catch (ArgumentOutOfRangeException ie)
            {
            }
            RA.Text = ((listX / sps)%60).ToString();
            RA.X = e.NewLocationX;
            VA1.X = e.NewLocationX;
            VA2.X = e.NewLocationX;
            VA3.X = e.NewLocationX;
            
            EHEchart.Update();
            EHNchart.Update();
            EHZchart.Update();
        }

        private void EHZchart_AnnotationPositionChanged(object sender, EventArgs e)
        {
            VA1.X = (int)(VA1.X + 0.5);
            VA2.X = (int)(VA2.X + 0.5);
            VA3.X = (int)(VA2.X + 0.5);
            if (VA1.X < 0)
            {
                VA1.X = 0;
                VA2.X = 0;
            }
            else if (VA1.X > EHE.Count)
            {
                //RA.X = adjacent.Count - RA.Width / 2;
                VA1.X = EHE.Count;
                VA2.X = EHE.Count;
                VA3.X = EHE.Count;
            }
            EHEchart.Update();
            EHNchart.Update();
            EHZchart.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PwaveX.Visible = false;
            SwaveX.Visible = false;
            PwaveY.Visible = false;
            SwaveY.Visible = false;
            PwaveZ.Visible = false;
            SwaveZ.Visible = false;
            PwaveX.X = 0;
            SwaveX.X = 0;
            PwaveY.X = 0;
            SwaveY.X = 0;
            PwaveZ.X = 0;
            SwaveZ.X = 0;
            //Pwave = null;
            //Swave = null;
            EHEchart.Update();
            EHNchart.Update();
            EHZchart.Update();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this,"file://C:\\Users\\Keith\\Documents\\Visual Studio 2012\\Projects\\DataGraph\\DataGraph\\User_Manual.chm");
        }

        //Own functions

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
            header.Text = "";

        }

        public void setRA()
        {
            RA.AxisX = EHZchart.ChartAreas[0].AxisX;
            RA.IsSizeAlwaysRelative = true;
            RA.Width = 20 * 0.13;
            RA.Height = 8 * 0.02;
            RA.Name = "name";
            RA.LineColor = Color.White;
            RA.BackColor = Color.White;
            RA.AxisY = EHZchart.ChartAreas[0].AxisY;
            RA.ClipToChartArea = EHZchart.ChartAreas[0].Name;
            RA.Y = (EHZ.Min()*1.05);
            RA.X = VA3.X - (RA.Width / 2);
            RA.Text = "0";
            RA.ForeColor = Color.Black;
            RA.Font = new System.Drawing.Font("Arial", 8f);
            EHZchart.Annotations.Add(RA);
        }

        public void staltaThread()
        {
            STALTAEHE = eq.getSTALTAratio(EHE, statime, ltatime);
            STALTAEHN = eq.getSTALTAratio(EHN, statime, ltatime);
            STALTAEHZ = eq.getSTALTAratio(EHZ, statime, ltatime);
        }

        public void setWaveAnnotation(VerticalLineAnnotation wave, int x, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            
            wave.AxisX = chart.ChartAreas[0].AxisX;
            wave.AllowMoving = false;
            wave.IsInfinitive = true;
            wave.LineColor = Color.Gray;
            wave.Visible = false;
            wave.Width = 1;
            wave.X = x;
            chart.Annotations.Add(wave);
            chart.Update();
        }

        public void initializeAll()
        {

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

           
            /*thread2 = new Thread(() =>
            {
                eq.EHNs = excel.getAxis(2, choose);
                EHN = eq.EHNs;
                mx2 = EHN.Max().ToString();
                mn2 = EHN.Min().ToString();

                threadbool = true;
            });*/

            eq.EHEs = excel.getAxis(1, choose);
            eq.EHNs = excel.getAxis(2, choose);
            eq.EHZs = excel.getAxis(3, choose);
            fileOpened = true;


            EHE = eq.EHEs;
            EHN = eq.EHNs;
            EHZ = eq.EHZs;

            staltaThread();
            max1.Text = EHE.Max().ToString();
            min1.Text = EHE.Max().ToString();
            max2.Text = EHN.Max().ToString();
            min2.Text = EHN.Max().ToString();
            max3.Text = EHZ.Max().ToString();
            min3.Text = EHZ.Min().ToString();
            excel.creatChart(EHEchart, EHE, "x axis", 0, Color.Gray, VA1);
            excel.creatChart(EHNchart, EHN, "y axis", 0, Color.Gray, VA2);
            excel.creatChart(EHZchart, EHZ, "z axis", 0, Color.Gray, VA3);
        }
        
    }
}
