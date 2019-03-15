using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
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
        int mulitplier = 50;
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
        public double sec, timesec, hourmin, degree, longitude, latitude, magnitude, hypocenter, trgr, dtrgr;
        public string stationID, date, xmax, xmin, ymax, ymin, zmax, zmin;
        public bool fileOpened = false, clicked = false, psSet = false, threadbool = false, staltafinish = false;
        public double pwaveEHE, swaveEHE, pwaveEHN, swaveEHN, pwaveEHZ, swaveEHZ, holder = 0, xVal = 0, xp, xs;
        public int sps, axis = 0;
        public int statime = 2, ltatime = 30;
        public int listX = 0;
        string openpath = @"E:\Kiting\CSVFiles";
        EarthquakeAnalyzer eq = new EarthquakeAnalyzer();
        //public Excel excel = new Excel();
        ChartControl chartControl = new ChartControl();
        //System.Drawing.Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        //Thread thread1, thread2, thread3;
        String timeee = "";
        Stopwatch stopwatch = new Stopwatch();
        const int max = 3;
        Bitmap bm;
        #endregion

        CSVRetreiver CSVR = new CSVRetreiver();
        Data data = new Data();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            PwaveX.Visible = false;
            PwaveX.Visible = false;
            PwaveZ.Visible = false;
            SwaveX.Visible = false;
            SwaveY.Visible = false;
            SwaveZ.Visible = false;
            test_magnitude.Enabled = false;
            tooltip.AutomaticDelay = 3000;
        }

        private void l(object sender, EventArgs e)
        {
            
        }

        #region MouseClickEvents

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
                VA1.X = listX+50;
                VA2.X = listX + 50;
                VA3.X = listX + 50;
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

                    test_direction.Enabled = true;
                    test_magnitude.Enabled = true;
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
            backgroundWorker1.CancelAsync();
            loading.Maximum = 100;
            loading.Step = 1;
            loading.Value = 0;
            data = null;
            stopwatch.Start();
            System.Threading.Thread.Sleep(1000);
            OpenFileDialog opensesame = new OpenFileDialog();
            opensesame.Title = "Open csv File";
            opensesame.Filter = "CSV files|*.csv";
            opensesame.InitialDirectory = openpath;
            if (opensesame.ShowDialog() == DialogResult.OK)
            {
                
                fileName = opensesame.FileName.ToString();
                this.Text = fileName;
                clearAll();
                try
                {
                    //MessageBox.Show(fileName);
                    data = new Data();
                    data = CSVRetreiver.decodeCSVFile(fileName);
                    sps = (int)data.getSamplePerSecond();
                    sec = (int)data.getSecond();
                    stationID = data.getSitename();
                    initializeAll();
                    setRA();
                }
                catch (Exception) { MessageBox.Show("Wrong file name selected"); }
            }
            stopwatch.Stop();
            
            Console.WriteLine("Opening and displaying: " + stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }

        private List<double> centerize(List<double> list)
        {
            List<double> convert = new List<double>();
            for (int x = 0; x < list.Count; x++)
            {
                convert.Add(list[x] - Math.Round(list.Average()));
            }
            return convert;
        }

        private void call_back(int i)
        {
            thread1();
            System.Threading.Thread.Sleep(500);
        }

        private void thread1()
        {
            Console.WriteLine("thread1 start");
            
            Console.WriteLine("thread1 end");
            //
        }

        private void thread2()
        {
            Console.WriteLine("thread1 start");
            
        }

        private void thread3()
        {
            Console.WriteLine("thread1 start");
            
        }

        public void initializeAll()
        {//
            sps = (int)data.getSamplePerSecond();
            EHE = centerize(data.getEHE());
            
            xmax = EHE.Max().ToString();
            xmin = EHE.Min().ToString();
            chartControl.createChart(EHEchart, EHE, "x_axis", 0, Color.Gray, VA1);
            setWaveAnnotation(SwaveX, 100, EHEchart);
            setWaveAnnotation(PwaveX, 100, EHEchart);
            //
            EHN = centerize(data.getEHN());
            
            ymax = EHN.Max().ToString();
            ymin = EHN.Min().ToString();
            chartControl.createChart(EHNchart, EHN, "y_axis", 0, Color.Gray, VA2);
            setWaveAnnotation(SwaveY, 100, EHNchart);
            setWaveAnnotation(PwaveY, 100, EHNchart);
            //
            EHZ = centerize(data.getEHZ());
            
            zmax = EHZ.Max().ToString();
            zmin = EHZ.Min().ToString();
            chartControl.createChart(EHZchart, EHZ, "z_axis", 0, Color.Gray, VA3);
            setWaveAnnotation(SwaveZ, 100, EHZchart);
            setWaveAnnotation(PwaveZ, 100, EHZchart);
            //
            
            trgr = eq.Trigger;
            dtrgr = eq.Detrigger;
            station1.Text = stationID;
            x.Text = "EHE";
            station2.Text = stationID;
            y.Text = "EHN";
            station3.Text = stationID;
            z.Text = "EHZ";
            max1.Text = xmax;
            min1.Text = xmin;
            max2.Text = ymax;
            min2.Text = ymin;
            max3.Text = zmax;
            min3.Text = zmin;
            date = data.getYear() + " " + data.getMonth() + " " + data.getDay();
            hourmin = data.getMinute();
            degree = data.getCompass();
            longitude = data.getLongitude();
            latitude = data.getLatitude();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
            fileOpened = true;
        }

        private void sTALTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileOpened && staltafinish)
            {
                childform = new STALTA(STALTAEHE, STALTAEHN, STALTAEHZ);
                childform.Show();
            }
            else
                MessageBox.Show("No file was opened");
                
        }

        private void checkEQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string output = "";
            if (fileOpened)
            {
                        if (eq.checkEarhtquakeV2(STALTAEHE, 1, sps) || eq.checkEarhtquakeV2(STALTAEHN, 2, sps) || eq.checkEarhtquakeV2(STALTAEHZ, 3, sps))
                        {
                            /*if (eq.Axis == 1)
                            {
                              //  degree = eq.calculateDirection(EHE, EHN, EHZ, xp, xs, degree);
                              //  magnitude = eq.calculateMagnitude(EHE, xp, xs);
                              //  hypocenter = eq.calculateHypocenter(pwaveEHE, swaveEHE, sps, sec);
                            }
                            else if (eq.Axis == 2)
                            {
                             //   degree = eq.calculateDirection(EHE, EHN, EHZ, xp, xs, degree);
                             //   magnitude = eq.calculateMagnitude(EHN, xp, xs);
                             //   hypocenter = eq.calculateHypocenter(pwaveEHN, swaveEHN, sps, sec);
                            }
                            else
                            {
                               // degree = eq.calculateDirection(EHE, EHN, EHZ, xp, xs, degree);
                              //  magnitude = eq.calculateMagnitude(EHZ, xp, xs);
                               // hypocenter = eq.calculateHypocenter(pwaveEHZ, swaveEHZ, sps, sec);
                            }*/
                            output += eq.calculateDirection(EHE, EHN, EHZ, xp, xs, degree);
                            output += eq.calculateMagnitude(EHE, EHN, EHZ, xp, xs);
                            output += "\nHypocenter: "+eq.calculateHypocenter(xp, xs, sps, sec);
                            MessageBox.Show(output);
                        }
                        else
                            MessageBox.Show("No Earthquake Detected");
            }
                else
                    MessageBox.Show("Set P-wave and S-wave first");
        }

        private void downloadCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadData data = new DownloadData();
            data.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(eq.calculateMagnitude(EHE,EHN,EHZ, xp, xs).ToString());
            
            test_magnitude.Enabled = false;
        }

        private void testV2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(eq.calculateDirection(EHE, EHN, EHZ, xp, xs, degree));
            //Hysteresis hys = new Hysteresis(EHE,EHN,EHZ,xp,xs, degree);
            //hys.Show();
            test_direction.Enabled = false;
        }

        private void pWaveBtn_MouseHover(object sender, EventArgs e)
        {
            tooltip.Show("Sets primary wave of Earthquake", this.pWaveBtn, 1500);
        }

        private void sWaveBtn_MouseHover(object sender, EventArgs e)
        {
            tooltip.Show("Sets secondary wave of Earthquake", this.pWaveBtn, 1500);
        }

        private void EHEchart_AnnotationPositionChanging(object sender, AnnotationPositionChangingEventArgs e)
        {
            
            try
            {
                header.Text = stationID + ".EHZ. " + date + "  " + hourmin.ToString() + "  " + timesec + "  " + sps.ToString() + "sps" + "/\t EHE: " + EHE[listX] + " EHN: " + EHN[listX] + " EHZ: " + EHZ[listX];
            }
            catch (ArgumentOutOfRangeException) { }      
            RA.X = VA3.X - (RA.Width / 2);
            RA.Text = ((listX / sps) % 60).ToString();
            RA.X = e.NewLocationX;
            listX = (int)e.NewLocationX;
            RA.Y = (EHZ.Min() * 1.05); 
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
            xs = 0;
            xp = 0;
            listX = 0;
            EHEchart.Update();
            EHNchart.Update();
            EHZchart.Update();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, AppDomain.CurrentDomain.BaseDirectory+"\\User_Manual.chm");
        }


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
            EHEchart.Visible = true;
            EHNchart.Visible = true;
            EHZchart.Visible = true;
            EHEchart.Series[0].Points.Clear();
            EHNchart.Series[0].Points.Clear();
            EHZchart.Series[0].Points.Clear();
            removeWaveAnnotation(VA1, EHEchart);
            removeWaveAnnotation(VA2, EHNchart);
            removeWaveAnnotation(VA3, EHZchart);
            removeWaveAnnotation(PwaveX, EHEchart);
            removeWaveAnnotation(SwaveX, EHEchart);
            removeWaveAnnotation(PwaveY, EHNchart);
            removeWaveAnnotation(SwaveY, EHNchart);
            removeWaveAnnotation(PwaveZ, EHZchart);
            removeWaveAnnotation(SwaveZ, EHZchart);
            EHZchart.Annotations.Remove(RA);
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

        public void removeWaveAnnotation(VerticalLineAnnotation wave,  System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            chart.Annotations.Remove(wave);
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void EHEchart_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
            axis = 0;
            xp = EHEchart.ChartAreas[0].CursorX.SelectionStart;
            xs = EHEchart.ChartAreas[0].CursorX.SelectionEnd;
            test_direction.Enabled = true;
            test_magnitude.Enabled = true;
            statuses.Text = "Start: " + xp + "\tFinish: " + xs;
        }

        private void EHNchart_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
            axis = 1;
            xp = EHNchart.ChartAreas[0].CursorX.SelectionStart;
            xs = EHNchart.ChartAreas[0].CursorX.SelectionEnd;
            test_direction.Enabled = true;
            test_magnitude.Enabled = true;
            statuses.Text = "Start: " + xp + "\tFinish: " + xs;
        }

        private void EHZchart_SelectionRangeChanging(object sender, CursorEventArgs e)
        {
            axis = 2;
            xp = EHZchart.ChartAreas[0].CursorX.SelectionStart;
            xs = EHZchart.ChartAreas[0].CursorX.SelectionEnd;
            test_direction.Enabled = true;
            test_magnitude.Enabled = true;  
            statuses.Text = "Start: " + xp + "\tFinish: " + xs;
        }
        private void EHNchart_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            double holder = 0;
            if (xp > xs)
            {
                xp = holder;
                xp = xs;
                xs = holder;
            }
            //MessageBox.Show(xp + " " + xs);
            //EHEchart.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
            //EHNchart.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
            //EHZchart.ChartAreas[0].AxisX.ScaleView.ZoomReset(1);
            //EHEchart.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
            //EHNchart.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
            //EHZchart.ChartAreas[0].AxisY.ScaleView.ZoomReset(1);
            statuses.Text = "Start: " + xp + "\tFinish: " + xs;
        }

        private void zoom_plus_Click(object sender, EventArgs e)
        {
            EHEchart.Width += mulitplier;
            EHNchart.Width += mulitplier;
            EHZchart.Width += mulitplier;
        }

        private void zoom_minus_Click(object sender, EventArgs e)
        {
            EHEchart.Width -= mulitplier;
            EHNchart.Width -= mulitplier;
            EHZchart.Width -= mulitplier;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loading.Value = e.ProgressPercentage;
            //statuses.Text=
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Async start");
            STALTAEHE = eq.getSTALTAratio(EHE, statime * sps, ltatime * sps);
            STALTAEHN = eq.getSTALTAratio(EHN, statime * sps, ltatime * sps);
            STALTAEHZ = eq.getSTALTAratio(EHZ, statime * sps, ltatime * sps);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Settings set = new Settings(statime, ltatime, eq.Trigger, eq.Detrigger, openpath);
            set.ShowDialog();
            if (set.DialogResult == DialogResult.OK)
            {
                statime = set.StaTime;
                ltatime = set.LtaTime;
                eq.Trigger = set.Trigger;
                eq.Detrigger = set.Detrigger;
                openpath = set.Path;
                if(!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
            MessageBox.Show(statime + " " + ltatime + " " + eq.Trigger + " " + eq.Detrigger + " " + openpath + " ");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            staltafinish = true;
            Console.WriteLine("stalta load finish");
        }
    }
}
/*int pt1 = (int)e.NewLocationX;
            
            if (sender == VA3)
                RA.X = VA3.X - (RA.Width / 2);
            listX = (int)VA1.X;
            timesec = (listX / sps) + sec;
            hourmin = timesec > 60 ? hourmin + 1 : hourmin;
            try
            {
                double step = (EHZchart.Series["z_axis"].Points[pt1 + 1].YValues[0] - EHZchart.Series["z_axis"].Points[pt1].YValues[0]);
                double deltaX = e.NewLocationX - EHZchart.Series["z_axis"].Points[pt1].XValue;
                double val = EHZchart.Series["z_axis"].Points[pt1].YValues[0] + step * deltaX;
                header.Text = stationID + ".EHZ. " + date + "  " + hourmin.ToString() + "  " + timesec.ToString() + "  " + sps.ToString() + "sps" + "/\t EHE: " + EHE[listX] + " EHN: " + EHN[listX] + " EHZ: " + EHZ[listX];
                RA.Text = Math.Round((/*((listX / sps) % 60) + val),2).ToString();
                RA.X = e.NewLocationX;
            }
            catch (ArgumentOutOfRangeException)
            {
            }*/
