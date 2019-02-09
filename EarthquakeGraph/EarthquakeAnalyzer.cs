using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthquakeGraph
{
    public class EarthquakeAnalyzer : Excel
    {
        private List<double> eqHolder = new List<double>();
        private double trigger = 2.5;
        private double detrigger = 0.5;
        private double px, py, pz;
        private int start, end, axis;
        private string state = "checkIfTriggered";
        private double magnitude = 0;
        private int triggertime = 10;
        private double counts = 0.0000625;

        public int Axis { get { return this.axis; } set { this.axis = value; } }

        public EarthquakeAnalyzer()
        {
        }

        /*public EarthquakeAnalyzer(List<double> EHE, List<double> EHN, List<double> EHZ)
        {
            this.EHE = EHE;
            this.EHN = EHN;
            this.EHZ = EHZ;
        }


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
        }*/

        #region EARTQUAKE_ANALYZER

        #region EARTHQUAKE_CHECKER

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
                                else if (x == stalta.Count)
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
            this.axis = axis;
           // return output;
            return cond;
        }

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

        public List<double> getSTA(List<double> input, int period)
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

        public List<double> getLTA(List<double> input, int period)
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

        public List<double> getLTAv2(List<double> input, int period)
        {
            List<double> output = new List<double>();
            Queue<double> buffs = new Queue<double>();
            double ave = 0;
            for (int x = 0; x < input.Count; x++)
            {
                ave = Math.Abs(input[x]);
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

        public List<double> getSTALTAratio(List<double> input, int period1, int period2)
        {
            double quo = 1;
            List<double> staltaRatio = new List<double>();
            List<double> sta = new List<double>(getLTA(input, period1));
            List<double> lta = new List<double>(getLTAv2(input, period2));
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

        public List<double> getSLALTAratioV2(List<double> input, int period1, int period2)
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

        public double getTime(double count)
        {
            double sec = count / Convert.ToInt16(getSamplesPerSecond(Choose));
            return sec;
        }

        public double calculateMagnitude(List<double> axis, double pw, double sw)
        {
            List<double> holder = new List<double>();
            for (int x = (int)pw; x < sw; x++)
            {
                holder.Add(axis[x]);
            }
            double volts = 0;
            double g = 0;

            volts = (counts * holder.Max()); //g ours 
            //volts = (axis.Max() * 3.3) / ratioValue; // g phivol
            g = volts / 1.815;
            if (g >= 0.0017 && g < 0.00785)
                magnitude = Math.Round(((g*2)/0.0017),1);
            else if (g >= 0.00785 && g < 0.014)
                magnitude = Math.Round(((g*3)/0.00785),1);
            else if (g >= 0.014 && g < 0.039)
                magnitude = Math.Round(((g*4)/0.014),1);
            else if (g >= 0.039 && g < 0.092)
                magnitude = Math.Round(((g*5)/0.039),1);
            else if (g >= 0.092 && g < 0.18)
                magnitude = Math.Round(((g*6)/0.092),1);
            else if (g >= 0.18 && g < 0.34)
                magnitude = Math.Round(((g*7)/0.18),1);
            else if (g >= 0.34 && g < 0.65)
                magnitude = Math.Round(((g*8)/0.34),1);
            else if (g >= 0.65 && g < 1.24)
                magnitude = Math.Round(((g * 9) / 0.65), 1);
            else if (g >= 1.24)
                magnitude = 9001;
            return magnitude;
        }

        public double calculateHypocenter(double pwave, double swave, double sps, double seconds)
        {
            double time = ((swave - pwave) / sps) + seconds;
            double hypocenter = Math.Round((time * 8),2);
            return hypocenter;
        }

        public void detectPW()
        {
            px = EHEs[start];
            py = EHNs[start];
            pz = EHZs[start];
        }

        public int calculateDirectionV2(List<double> EHE, List<double> EHN, List<double> EHZ, double start, double finish)
        {
            int[] degree = new int[361];
            double angle = 0;
            int deg = 0;
            int index = 0;
            for (int x = 0; x < 360; x++)
            {
                degree[x] = 0;
            }
            for (int x = Convert.ToInt32(start); x < finish; x++)
            {
                if (EHN[x] > 0 && EHE[x] > 0)
                {
                    angle = Math.Atan(EHN[x] / EHE[x]);
                    deg = (int)Math.Round((angle * 180) / Math.PI);
                }
                else if (EHE[x] < 0)
                {
                    angle = Math.Atan(EHN[x] / EHE[x]);
                    deg = (int)Math.Round((angle * 180) / Math.PI);
                    deg += 180;
                }
                else if (EHN[x] < 0 && EHE[x] > 0)
                {
                    angle = Math.Atan(EHN[x] / EHE[x]);
                    deg = (int)Math.Round((angle * 180) / Math.PI);
                    deg += 360;
                }
                else
                    deg = 0;
                deg = EHZ[x] > 0 ? deg : Math.Abs(180-deg);
                degree[deg]++;
            }
            
            for (int x = 0; x <= 360; x++)
            {
                if (degree[x] == degree.Max())
                    index = x;
            }
            return index;
        }

        public double calculateDirection(double x, double y, double z, double degree)
        {
            double threshold = 0;
            // From the phone's point of view
            degree = Math.Round(degree);
            if (z < threshold)
            {
                if (x < -threshold && y < -threshold)
                {// pushed to SOUTHWEST
                    return (degree + 135);
                }
                else if (x > threshold && y < -threshold)
                {// pushed to SOUTHEAST
                    return (degree - 135);
                }
                else if (x < -threshold && y > threshold)
                {// pushed to NORTHWEST
                    return (degree + 45);
                }
                else if (x > threshold && y > threshold)
                {// pushed to NORTHEAST
                    return (degree - 45);
                }
                else if (x > threshold)
                { // pushed to EAST
                    return (degree - 90);
                }
                else if (x < -threshold)
                { // pushed to WEST
                    return (degree + 90);
                }
                else if (y > threshold)
                { // pushed to NORTH
                    return (degree - 180);
                }
                else if (y < -threshold)
                {// pushed to SOUTH
                    return (degree);
                }

            }
            else
            {


                if (x < -threshold && y < -threshold)
                {// pushed to SOUTHWEST
                    return (degree - 135);
                }
                else if (x > threshold && y < -threshold)
                {// pushed to SOUTHEAST
                    return (degree + 135);
                }
                else if (x < -threshold && y > threshold)
                {// pushed to NORTHWEST
                    return (degree - 45);
                }
                else if (x > threshold && y > threshold)
                {// pushed to NORTHEAST
                    return (degree + 45);
                }
                else if (x > threshold)
                { // pushed to EAST
                    return (degree + 90);
                }
                else if (x < -threshold)
                { // pushed to WEST
                    return (degree - 90);
                }
                else if (y > threshold)
                { // pushed to NORTH
                    return (degree);
                }
                else if (y < -threshold)
                {// pushed to SOUTH
                    return (degree - 180);
                }

            }
            return 90;
        }

        #endregion

        #endregion
    }

    /*double ave = 0;
    List<double> output = new List<double>();
    Queue<double> buffs = new Queue<double>();
    for (int x = 0; x < input.Count; x++)
    {
        ave = Math.Abs(input[x]);
        if (buffs.Count < period)
        {
            buffs.Enqueue(Math.Abs(input[x]));
        }
        else if (buffs.Count == period)
        {
            ave = Math.Round(buffs.Average(), 2);
            buffs.Dequeue();
        }
        output.Add(ave);
    }
    return output;*/
}