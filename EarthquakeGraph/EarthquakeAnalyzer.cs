using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int triggertime = 10;
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
            List<double> sta = new List<double>(getSTA(input, period1));
            List<double> lta = new List<double>(getLTA(input, period2));
            for (int x = 0; x < input.Count; x++)
            {
                if (sta[x] != 0 && lta[x] != 0)
                {
                    quo = Math.Round((sta[x] / lta[x]), 2);
                }

                staltaRatio.Add(quo);
            }
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
        public double calculateMagnitude(List<double> axis, double start, double finish)
        {
            List<double> holder = new List<double>();
            for (int x = (int)start; x < finish; x++)
            {
                holder.Add(Math.Abs(axis[x]));
            }
            double volts = 0;
            double g = 0;
            double mmi = 0;
            volts = (counts * holder.Max());
            g = volts / 1.815;
            if (g >= 0.0017 && g < 0.00785)
                mmi = Math.Round(((g*2)/0.0017),1);
            else if (g >= 0.00785 && g < 0.014)
                mmi = Math.Round(((g*3)/0.00785),1);
            else if (g >= 0.014 && g < 0.039)
                mmi = Math.Round(((g*4)/0.014),1);
            else if (g >= 0.039 && g < 0.092)
                mmi = Math.Round(((g*5)/0.039),1);
            else if (g >= 0.092 && g < 0.18)
                mmi = Math.Round(((g*6)/0.092),1);
            else if (g >= 0.18 && g < 0.34)
                mmi = Math.Round(((g*7)/0.18),1);
            else if (g >= 0.34 && g < 0.65)
                mmi = Math.Round(((g*8)/0.34),1);
            else if (g >= 0.65 && g < 1.24)
                mmi = Math.Round(((g * 9) / 0.65), 1);
            else if (g >= 1.24)
                mmi = 9001;

            magnitude = 1 + mmi * (2 / 3);

            return magnitude;
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
            string wat = "";
            double[] output = new double[(int)(finish - start)+5];
            int[] degree = new int[361];
            double angle = 0;
            int deg = 0, deg2;
            int index = (int)start;
            double max = 0;
            for (int x = 0; x < 360; x++)
            {
                degree[x] = 0;
            }
            for (int x = Convert.ToInt32(start); x < finish; x++)
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
                    if (EHN[index] > 0 && EHE[index] > 0)
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
                    else if (EHN[index] < 0 && EHE[index] > 0)
                    {
                        angle = Math.Atan(EHN[index] / EHE[index]);
                        deg = (int)Math.Round((angle * 180) / Math.PI);
                        deg += 360;
                    }
                    else
                        deg = 0;
                    wat += "\nx: " + EHE[index] + "\n y: " + EHN[index];
                    wat += "\ndegree of phone: " + degreePhone;
                    deg2 = EHZ[index] < 0 ? deg : Math.Abs(360 - deg);
                    wat += "\nAccelerometer calc: " + deg2;
                    deg2 = (int)(degreePhone - deg2);
                    wat += "\nCalculated with phone: " + deg2;
            return wat;
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
        public string calculateDirection(double x, double y, double z ,double degreePhone)
        {
            string output = "";
            double angle = 0;
            int deg = 0;
            if (y > 0 && x > 0)
            {
                angle = Math.Atan(y /x);
                deg = (int)Math.Round((angle * 180) / Math.PI);

            }
            else if (x < 0)
            {
                angle = Math.Atan(y /x);
                deg = (int)Math.Round((angle * 180) / Math.PI);
                deg += 180;
            }
            else if (y < 0 && x > 0)
            {
                angle = Math.Atan(y /x);
                deg = (int)Math.Round((angle * 180) / Math.PI);
                deg += 360;
            }
            else
                deg = 0;
            output += "acceleration: " + deg;
            output += "phone: " + degreePhone;
            deg = (int)degreePhone - deg;
            deg = deg < 0? deg - 180: deg;
            deg = z > 0 ? deg : Math.Abs(180 - deg);
            output += "solved: " + deg;
            String where = "NO";
            if (deg >= 0)
            {
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
            }
            else
            {
                if (deg <= -338 || deg >= -23)
                {
                    where = "NNorth";
                }
                if (deg > -338 && deg < -293)
                {
                    where = "NNorthEast";
                }
                if (deg >= -293 && deg < -248)
                {
                    where = "NEast";
                }
                if (deg >= -248 && deg < -202)
                {
                    where = "NSouthEast";
                }
                if (deg >= -202 && deg < -158)
                {
                    where = "NSouth";
                }
                if (deg >= -158 && deg < -112)
                {
                    where = "NSouthWest";
                }
                if (deg >= -112 && deg < -68)
                {
                    where = "NWest";
                }
                if (deg >= -68 && deg < -23)
                {
                    where = "NNorthWest";
                }
            }
            return output;
        }

        #endregion

        #endregion
    }
}