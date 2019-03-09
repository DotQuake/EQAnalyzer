using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EarthquakeGraph
{
    public class CSVRetreiver : Form
    {
        public static Boolean validateCSVFile(String fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                Boolean arrivalFlag = false,timeSeriesFlag=false,startData=false;
                String line;
                String[] decodedLine;
                while ((line = streamReader.ReadLine()) != null)
                {
                    decodedLine = line.Split(',');
                    if (decodedLine[0].Equals("ARRIVALS"))
                    {
                        arrivalFlag = true;
                    }else if(decodedLine[0].Equals("TIME SERIES"))
                    {
                        timeSeriesFlag = true;
                    }
                    else if (decodedLine[0].Equals("--------"))
                    {
                        startData = true;
                    }
                    if (arrivalFlag && timeSeriesFlag && startData)
                        return true;
                }
                return false;
            }
        }
        public static Data decodeCSVFile(String fileName)
        {
            Data data = new Data();
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                Boolean arrivalFlag = false,startData=false;
                String line;
                String[] decodedLine;

                while ((line = streamReader.ReadLine()) != null)
                {
                    decodedLine = line.Split(',');
                    if (!startData)
                    {
                        foreach (String str in decodedLine)
                        {
                            if (decodedLine[0].Equals("ARRIVALS"))
                            {
                                arrivalFlag = true;
                            }
                            else if (decodedLine[0].Equals("TIME SERIES"))
                            {
                                arrivalFlag = false;
                            }
                            if (arrivalFlag)
                            {
                                if (str.Equals("#uncertainty in seconds"))
                                {
                                    try
                                    {
                                        data.setLongitude(Double.Parse(decodedLine[2]));
                                    }
                                    catch (Exception)
                                    {
                                        //MessageBox.Show("Error Parse Longtitude" + decodedLine[2]);
                                        data.setLongitude(0);
                                        //return null;
                                    }
                                }
                                else if (str.Equals("#peak amplitude"))
                                {
                                    try
                                    {
                                        data.setLatitude(Double.Parse(decodedLine[2]));
                                    }
                                    catch (Exception)
                                    {
                                        //MessageBox.Show("Error Parse Latitude");
                                        data.setLatitude(0);
                                        //return null;
                                    }
                                }
                                else if (str.Equals("#frequency at P phase"))
                                {
                                    try
                                    {
                                        data.setCompass(Double.Parse(decodedLine[2]));
                                    }
                                    catch (Exception)
                                    {
                                        //MessageBox.Show("Error Parse Compass");
                                        //return null;
                                        data.setCompass(0);
                                    }
                                }
                            }
                            else
                            {
                                if (!startData)
                                {
                                    if (str.Equals("#sitename"))
                                    {
                                        data.setSitename(decodedLine[0]);
                                    }
                                    else if (str.Equals("#authority"))
                                    {
                                        data.setAuthority(decodedLine[0]);
                                    }
                                    else if (str.Equals("#year month day"))
                                    {
                                        double year, month, day;
                                        try
                                        {
                                            year = Double.Parse(decodedLine[0][0] + "" + decodedLine[0][1] + "" + decodedLine[0][2] + "" + decodedLine[0][3] + "");
                                            month = Double.Parse(decodedLine[0][4] + "" + decodedLine[0][5] + "");
                                            day = Double.Parse(decodedLine[0][6] + "" + decodedLine[0][7] + "");
                                            data.setYear(year); data.setMonth(month); data.setDay(day);
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Error Parse Year Month Day");
                                            return null;
                                        }
                                    }
                                    else if (str.Equals("#hour minute"))
                                    {
                                        double hour, minute;
                                        try
                                        {
                                            hour = Double.Parse(decodedLine[0][0] + "" + decodedLine[0][1] + "");
                                            minute = Double.Parse(decodedLine[0][2] + "" + decodedLine[0][3] + "");
                                            data.setMinute(minute); data.setHour(hour);
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Error Parse Hour Year");
                                            return null;
                                        }
                                    }
                                    else if (str.Equals("#second"))
                                    {
                                        try
                                        {
                                            data.setSecond(Double.Parse(decodedLine[0]));
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Error Parse Second");
                                            return null;
                                        }
                                    }
                                    else if (str.Equals("#samples per second"))
                                    {
                                        try
                                        {
                                            data.setSamplePerSecond(Double.Parse(decodedLine[0]));
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Error Parse Sample Per Seconds");
                                            return null;
                                        }
                                    }
                                    else if (str.Equals("#unit"))
                                    {
                                        data.setUnit(decodedLine[0]);
                                    }
                                    else if (str.Equals("#data source"))
                                    {
                                        data.setSource(decodedLine[0]);
                                    }
                                    else if (str.Equals("#conversion value"))
                                    {
                                        String[] val = decodedLine[0].Split(' ');
                                        data.setCountsToVolts((float)Convert.ToDouble(val[0]));
                                    }
                                    else if (str.Equals("--------"))
                                    {
                                        startData = true;
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            data.appendEHE(float.Parse(decodedLine[0]));
                            data.appendEHN(float.Parse(decodedLine[1]));
                            data.appendEHZ(float.Parse(decodedLine[2]));
                        }
                        catch (Exception) { }
                    }
                }
            }
            return data;
        }
    }
}
