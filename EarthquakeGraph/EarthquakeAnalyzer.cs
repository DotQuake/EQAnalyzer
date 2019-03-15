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
    /// <summary>
    /// A class for analyzing seismic data and checks if an earthquake is recorded in the data
    /// </summary>
    public class EarthquakeAnalyzer : Data
    {
        private List<double> eqHolder = new List<double>();
        private double trigger = 2.5;
        private double detrigger = 0.5;
        //private double px, py, pz;
        private int start, end, axis;
        private string state = "checkIfTriggered";
        private double magnitude = 0;
        private int triggertime = 5;
        private double counts = 0.0000625;

        /// <summary>
        /// Trigger threshold
        /// </summary>
        public double Trigger { get { return trigger; } set { trigger = value; } }
        /// <summary>
        /// Detrigger threshold
        /// </summary>
        public double Detrigger { get { return detrigger; } set { detrigger = value; } }
        /// <summary>
        /// Axis lol
        /// </summary>
        public int Axis { get { return this.axis; } set { this.axis = value; } }
        
        #region EARTQUAKE_ANALYZER

        #region EARTHQUAKE_CHECKER

        /// <summary>
        /// Checks the STA/LTA of an axis and verifies if its an earthquake
        /// </summary>
        /// <param name="stalta">List of double STA/LTA calculated values</param>
        /// <param name="axis">Axis where the STA/LTA is. x = 1, y = 2, z = 3</param>
        /// <param name="sps">Samples per second of the sensor</param>
        /// <returns>
        /// Returns a boolean value that indicates if there is an earthquake detected
        /// </returns>
        public bool checkEarhtquakeV2(List<double> stalta, int axis, int sps)
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
                                else if (x == stalta.Count - 1)
                                {
                                    output.Add("x index: " + x.ToString());
                                    output.Add("x value: " + stalta[x].ToString());
                                    output.Add("finished not triggered");
                                    finish = true;
                                    break;
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
                                else if (x == stalta.Count - 1)
                                {
                                    output.Add("finished not detriggered");
                                    finish = true;
                                    break;
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
            return cond;
        }
        /// <summary>
        /// Checks the STA first if the value exceeded the allowed trigger threshold.
        /// Then checks the LTA if the value is then below the detrigger threshold
        /// </summary>
        /// <param name="sta">List of double STA calculated values</param>
        /// <param name="lta">List of double LTA calculated values</param>
        /// <param name="axis">Axis where the STA/LTA is. x = 1, y = 2, z = 3</param>
        /// <param name="sps">Samples per second of the sensor</param>
        /// <returns>Returns a boolean value that indicates if there is an earthquake detected</returns>
        public bool checkEarthquake(List<double> sta, List<double> lta, int axis, int sps)
        {
            bool cond = false;
            /*
            switch (state)
            {
                case 0:
                    {
                        for (int x = 0; x < sta.Count; x++)
                        {
                            if (sta[x] > trigger)
                            {
                                this.start = x;
                                state = 1;
                                break;
                            }
                        }
                        break;
                    }

                case 1:
                    {
                        for (int x = Convert.ToInt16(lta.Max()); x < lta.Count; x++)
                        {
                            if (lta[x] < detrigger)
                            {
                                this.end = x;
                                state = 2;
                                break;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        double res = (end - start) / sps;
                        if (res > triggertime)
                        {
                            cond = true;
                        }
                        else
                            cond = false;
                        break;
                    }
            }
            this.axis = axis;*/
            return cond;

        }

        #endregion

        #region EARTQUAKE_CALCULATOR
        /// <summary>
        /// Calculates the short term average of the inputed axis.
        /// </summary>
        /// <param name="input">Axis to calculate</param>
        /// <param name="period">Period of the moving average</param>
        /// <returns>List of the double values of the calculated STA</returns>
        public List<double> getSTAv1(List<double> input, int period)
        {
            //List<double> sta = array.ConvertAll<double>(x => Math.Abs(x));
            //return sta;
            List<double> output = new List<double>(input.Count);
            double[] buffs = new double[period];
            int current_index = 0;
            for (int i = 0; i < input.Count; i++)
            {
                buffs[current_index] = Math.Abs(input[i]) / period;
                double ma = 0.0;
                for (int j = 0; j < period; j++)
                {
                    ma += buffs[j];
                }
                output.Add(ma);

                current_index = (current_index + 1) % period;
            }
            return output;
        }
        /// <summary>
        /// Calculates the long term average of the inputed axis. Uses Array
        /// if array buffer wont be filled, output is 1
        /// </summary>
        /// <param name="input">Axis to calculate</param>
        /// <param name="period">Period of the moving average</param>
        /// <returns>List of the double values of the calculated LTA</returns>
        public List<double> getSTA(List<double> input, int period)
        {
            List<double> output = new List<double>(input.Count);
            double[] buffs = new double[period];
            int current_index = 0;
            for (int i = 0; i < input.Count; i++)
            {
                buffs[current_index] = Math.Abs(input[i]) / period;
                double ma = 0.0;
                for (int j = 0; j < period; j++)
                {
                    ma += buffs[j];
                }
                if (i > period)
                    output.Add(ma);
                else
                    output.Add(1);

                current_index = (current_index + 1) % period;
            }
            return output;
        }
        /// <summary>
        /// Calculates the long term average of the inputed axis. Uses Queue
        /// A moving average
        /// </summary>
        /// <param name="input">Axis to calculate</param>
        /// <param name="period">Period of the moving average</param>
        /// <returns>List of the double values of the calculated LTA</returns>
        public List<double> getLTA(List<double> input, int period)
        {
            List<double> output = new List<double>();
            Queue<double> buffs = new Queue<double>();
            double ave = 0;

            for (int x = 0; x < input.Count; x++)
            {
               // ave = Math.Abs(input[x]);
                buffs.Enqueue(Math.Abs(input[x]));
                if (buffs.Count >= period)
                {
                    buffs.Dequeue();
                }
                ave = buffs.Average();
                output.Add(ave);
            }
            return output;
        }
        /// Summary:
        ///     Calculates the ratio of the STA and LTA of an Axis.
        ///     Calls the getSTA and getLTA methods.
        ///     
        /// Parameters:
        ///   input:
        ///     Axis to be calculated.
        ///     
        ///   period1:
        ///     Period of the STA
        ///     
        ///   period2:
        ///     Period of the LTA
        ///     
        /// Returns:
        ///     List of the double values of the calculated ratio of STA & LTA.
        public List<double> getSTALTAratio(List<double> input, int period1, int period2)//Period is dependent on SPS
        {
            double quo = 1;
            List<double> staltaRatio = new List<double>();
            List<double> sta = new List<double>(getSTA(input,period1));
            List<double> lta = new List<double>(getLTA(input,period2));
            for (int x = 0; x < input.Count; x++)
            {
                if (sta[x] != 0 && lta[x] != 0)
                {
                    quo = Math.Round((sta[x] / lta[x]), 2);
                }

                staltaRatio.Add(quo);
            }
            /*
            List<double> staltaRatio = new List<double>(input.Count);
            List<double> sta = new List<double>(input.Count);
            List<double> lta = new List<double>(input.Count);
            double[] buffssta = new double[period1];
            Queue<double> buffslta = new Queue<double>();
            int current_index = 0;
            double avesta = 0;
            double avelta = 0;
            for (int x = 0; x < input.Count; x++)
            {
                // lta
                buffslta.Enqueue(Math.Abs(input[x]));
                if (buffslta.Count >= period2)
                {
                    buffslta.Dequeue();
                }
                avelta = buffslta.Average();
                lta.Add(avelta);
                //sta
                buffssta[current_index] = Math.Abs(input[x]) / period1;
                double ma = 0.0;
                for (int j = 0; j < period1; j++)
                {
                    ma += buffssta[j];
                }
                if (x > period1)
                    sta.Add(ma);
                else
                    sta.Add(1);

                current_index = (current_index + 1) % period1;

                staltaRatio.Add(sta[x] / lta[x]);
            }*/
            return staltaRatio;
        }
        /// <summary>
        /// Calculates the ratio of the STA and LTA of an Axis
        /// Uses array as buffer
        /// </summary>
        /// <param name="input">Axis to be calculated</param>
        /// <param name="period1">Period of the STA</param>
        /// <param name="period2">Period of the LTA</param>
        /// <returns>List of the double values of the calculated ratio of STA & LTA</returns>
        public List<double> getSLALTAratioV2(List<double> input, int period1, int period2)//Period is dependent on SPS
        {
            double ratio = 0;
            List<double> stalta = new List<double>();
            double[] bufferSTA = new double[period1];
            double[] bufferLTA = new double[period2];
            for (int x = 0; x < input.Count; x++)
            {
                bufferSTA[x % period1] = Math.Abs(input[x]);
                bufferLTA[x % period2] = Math.Abs(input[x]);

                if (x >= period2)
                {
                    ratio = Math.Round((bufferSTA.Average() / Math.Max(1, bufferLTA.Average())), 2);
                    stalta.Add(ratio);
                }
                else
                {
                    stalta.Add(1);
                }

            }
            return stalta;
        }
        /// <summary>
        /// Converts the counts in time unit
        /// </summary>
        /// <param name="count">Input count</param>
        /// <returns>Returns the converted time value</returns>
        public double getTime(double count)
        {
            double sec = count / Convert.ToInt16(getSamplePerSecond());
            return sec;
        }
        /// <summary>
        /// Calculates the magnitude of the max value in the axis
        /// </summary>
        /// <param name="axis">Axis where to calculate</param>
        /// <param name="pw">P-wave of the earthquake</param>
        /// <param name="sw">S-wave of the earthquake</param>
        /// <returns>Returns the magnitude of the earthquake (LOL NO)</returns>
        public string calculateMagnitude(List<double> EHE, List<double> EHN, List<double> EHZ , double start, double finish)
        {
            string watt = "";
            double max = 0;
            for (int x = Convert.ToInt32(start); x < finish; x++)
            {
                if (Math.Abs(EHN[x]) > max || Math.Abs(EHE[x]) > max)
                {
                    if (Math.Abs(EHN[x]) > Math.Abs(EHE[x]))
                        max = Math.Abs(EHN[x]);
                    else
                        max = Math.Abs(EHE[x]);
                }
            }
            for (int x = Convert.ToInt32(start); x < finish; x++)
            {
                if (Math.Abs(EHZ[x]) > max)
                {
                    max = Math.Abs(EHZ[x]);
                }
            }
            
            double volts = 0;
            double g = 0;
            double mmi = 0;
            volts = (counts * max);
            watt += "\nCounts: " + max;
            watt += "\nVoltage: " + volts+"v";
            g = volts / 1.815;
            watt += "\nAcceleration: " + g+"g";
            if (g >= 0.0017 && g < 0.00785)
                mmi = 2;
            else if (g >= 0.00785 && g < 0.014)
                mmi = 3;
            else if (g >= 0.014 && g < 0.039)
                mmi = 4;
            else if (g >= 0.039 && g < 0.092)
                mmi = 5;
            else if (g >= 0.092 && g < 0.18)
                mmi = 6;
            else if (g >= 0.18 && g < 0.34)
                mmi = 7;
            else if (g >= 0.34 && g < 0.65)
                mmi = 8;
            else if (g >= 0.65 && g < 1.24)
                mmi = 9;
            else if (g >= 1.24)
                mmi = 9001;
            watt += "\nMMI: " + mmi;
            magnitude = 1 + (mmi * 2) / 3;
            watt += "\nMagnitude: " + magnitude;
            return watt;
        }
        /// <summary>
        /// Calculates the hypocenter of the earthquake
        /// </summary>
        /// <param name="pwave">P-wave of the earthquake</param>
        /// <param name="swave">S-wave of the earthquake</param>
        /// <param name="sps">Samples per second of the device</param>
        /// <param name="seconds">Time started</param>
        /// <returns>Returns the calculated hypocenter or the distance of the device to the earthquake</returns>
        public double calculateHypocenter(double pwave, double swave, double sps, double seconds)
        {
            double time = ((swave - pwave) / sps) + seconds;
            double hypocenter = Math.Round((time * 8),2);
            return hypocenter;
        }
        /// <summary>
        /// lol wa gamit
        /// </summary>
        /*public void detectPW()
        {
            px = EHEs[start];
            py = EHNs[start];
            pz = EHZs[start];
        }*/
        /// <summary>
        /// Calculates the direction of where the earthquake is coming from
        /// Uses hysteresis method of calculation
        /// </summary>
        /// <param name="EHE">X-axis</param>
        /// <param name="EHN">Y-axis</param>
        /// <param name="EHZ">Z-axis</param>
        /// <param name="start">P-wave</param>
        /// <param name="finish">S-wave</param>
        /// <returns>Returns the direction in degrees</returns>
        public string calculateDirection(List<double> EHE, List<double> EHN, List<double> EHZ, double start, double finish, double degreePhone)
        {
            string outstring = "";
            double[] output = new double[(int)(finish - start)+5];
            int[] degree = new int[361];
            double angle = 0;
            int deg = 0, deg2;
            int index = (int)start;
            double max = 0;
            for (int x = Convert.ToInt32(start); x <= finish+1; x++)
            {
                if (Math.Abs(EHN[x]) > max || Math.Abs(EHE[x]) > max)
                {
                    if (Math.Abs(EHN[x]) > Math.Abs(EHE[x]))
                        max = Math.Abs(EHN[x]);
                    else
                        max = Math.Abs(EHE[x]);
                    index = x;
                }
            }
            try
            {
                if (EHN[index] >= 0 && EHE[index] >= 0)
                {
                    angle = Math.Atan(EHN[index] / EHE[index]);
                    deg = (int)Math.Round((angle * 180) / Math.PI);

                }
                else if (EHE[index] < 0)
                {
                    angle = Math.Atan(EHN[index] / EHE[index]);
                    deg = (int)Math.Round((angle * 180) / Math.PI);
                    deg += 180;
                }
                else if (EHN[index] < 0 && EHE[index] >= 0)
                {
                    angle = Math.Atan(EHN[index] / EHE[index]);
                    deg = (int)Math.Round((angle * 180) / Math.PI);
                    deg += 360;
                }
                else
                    deg = 0;
            }
            catch (DivideByZeroException) { }
            outstring += "\nx: " + EHE[index] + "\n y: " + EHN[index] + "\n z: " + EHZ[index];
            outstring += "\ndegree of phone: " + degreePhone;
            outstring += "\nAccelerometer without z: " + deg;
            deg2 = EHZ[index] >= 0 ? (180 + deg)%360:deg;       // positive z is push, negative z is pull
            outstring += "\nAccelerometer with z: " + deg2;

            deg2 = (int)(degreePhone - deg2);               // Aligning output with phone
            outstring += "\nCalculated with phone: " + deg2;
            //deg2 = deg2 >= 360 ? 360 - deg2 : deg2;         // condition if calculated degree exceeds 360
            deg2 = deg2 < 0 ? 360 + deg2 : deg2;            // condition if calculated degree is negative
            outstring += "\nCalculated with >360: " + deg2;
            outstring += "\n"+findOrientation(deg2);
            return outstring;
        }
        public Bitmap calculateDirection(List<double> EHE, List<double> EHN, List<double> EHZ, double start, double finish, double degreePhone , PictureBox picturebox)
        {
            Pen pipi = new Pen(Color.Red, 1f);
            int threshold = 100;
            Bitmap bm = new Bitmap(picturebox.Width, picturebox.Height);
            string outstring = "";
            double[] output = new double[(int)(finish - start) + 5];
            double angle = 0;
            int sum = 0;
            int ctr = 0;
            int deg = 0, deg2;
            for (int index = (int)start; index <= finish; index++)
            {
                if (Math.Abs(EHE[index]) > threshold && Math.Abs(EHN[index]) > threshold)
                {
                    if (EHN[index] >= 0 && EHE[index] >= 0)
                    {
                        angle = Math.Atan(EHN[index] / EHE[index]);
                        deg = (int)Math.Round((angle * 180) / Math.PI);

                    }
                    else if (EHE[index] < 0)
                    {
                        angle = Math.Atan(EHN[index] / EHE[index]);
                        deg = (int)Math.Round((angle * 180) / Math.PI);
                        deg += 180;
                    }
                    else if (EHN[index] < 0 && EHE[index] >= 0)
                    {
                        angle = Math.Atan(EHN[index] / EHE[index]);
                        deg = (int)Math.Round((angle * 180) / Math.PI);
                        deg += 360;
                    }
                    else
                        deg = 0;
                    deg2 = EHZ[index] >= 0 ? (180 + deg) % 360 : deg;       // positive z is push, negative z is pull
                    deg2 = (int)(degreePhone - deg2);               // Aligning output with phone
                    deg2 = deg2 < 0 ? 360 + deg2 : deg2;
                    sum += deg2;
                    ctr++;
                    int angles = deg2;
                    using (var g = Graphics.FromImage(bm))
                    {
                        int x = 0, y = 0;
                        Point point1 = new Point(x, y);
                        Point point2 = new Point(x + (int)((Math.Cos((angles * Math.PI) / 180)) * picturebox.Width/2), y + (int)((Math.Sin((angles * Math.PI) / 180)) * picturebox.Height/2));
                        g.TranslateTransform(picturebox.Width / 2, picturebox.Height / 2);
                        g.RotateTransform(-90);
                        g.DrawLine(Pens.Black, 0, -picturebox.Height, 0, picturebox.Height);
                        g.DrawLine(Pens.Black, -picturebox.Height, 0, picturebox.Height, 0);
                        g.DrawLine(pipi, point1, point2);
                        picturebox.Image = bm;
                        g.ResetTransform();
                        g.Dispose();
                    }
                }
            }
            double ave = sum / ctr;
            using (var g = Graphics.FromImage(bm))
            {
                pipi.Color = Color.Blue;
                g.TranslateTransform(picturebox.Width / 2, picturebox.Height / 2);
                g.RotateTransform(-90);
                Point point3 = new Point((int)((Math.Cos((ave * Math.PI) / 180)) * picturebox.Width/2), (int)((Math.Sin((ave * Math.PI) / 180)) * picturebox.Height/2));
                g.DrawLine(pipi, new Point(0,0), point3);
                picturebox.Image = bm;
                g.ResetTransform();
                g.Dispose();
            }
            return bm;
        }

        public double countsToG(double count)
        {
            double output;

            output = (count * counts)/1.95;

            return output;
        }
        /// <summary>
        /// Calculates the direction of where the earthquake is coming from
        /// Uses P-wave as the basis of direction
        /// </summary>
        /// <param name="x">P-wave x value</param>
        /// <param name="y">P-wave y value</param>
        /// <param name="z">P-wave z value</param>
        /// <param name="degree">Degree of orientation</param>
        /// <returns>Returns the direction in degrees</returns>
        public string findOrientation(int deg)
        {
            String where = "NO";
                if (deg >= 338 || deg <= 23)
                {
                    where = "North";
                }
                if (deg < 338 && deg > 293)
                {
                    where = "NorthWest";
                }
                if (deg <= 293 && deg > 248)
                {
                    where = "West";
                }
                if (deg <= 248 && deg > 202)
                {
                    where = "SouthWest";
                }
                if (deg <= 202 && deg > 158)
                {
                    where = "South";
                }
                if (deg <= 158 && deg > 112)
                {
                    where = "SouthEast";
                }
                if (deg <= 112 && deg > 68)
                {
                    where = "East";
                }
                if (deg <= 68 && deg > 23)
                {
                    where = "NorthEast";
                }
            return where;
        }

        #endregion

        #endregion
    }
}