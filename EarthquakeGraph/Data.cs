using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthquakeGraph
{
    public class Data
    {
        private List<double> EHE = new List<double>();
        private List<double> EHN = new List<double>();
        private List<double> EHZ = new List<double>();
        private double longitude;
        private double latitude;
        private String sitename;
        private String authority;
        private double year, month, day;
        private double compass;
        private double hour, minute,second,samplePerSecond;
        private String unit,dataSource;
        private float countsToVolts;

        public void setCountsToVolts(float countsToVolts)
        {
            this.countsToVolts = countsToVolts / (1000000);
        }

        public float getCountsToVolts()
        {
            return countsToVolts;
        }

        public double getSamplePerSecond()
        {
            return samplePerSecond;
        }

        public String getDataSource()
        {
            return dataSource;
        }

        public String getUnit()
        {
            return unit;
        }

        public double getCompass()
        {
            return this.compass;
        }

        public double getMinute()
        {
            return minute;
        }

        public double getSecond()
        {
            return second;
        }

        public double getHour()
        {
            return hour;
        }

        public String getAuthority()
        {
            return this.authority;
        }

        public double getYear()
        {
            return year;
        }

        public double getMonth()
        {
            return month;
        }

        public double getDay()
        {
            return day;
        }

        public double getLongitude()
        {
            return this.longitude;
        }

        public double getLatitude()
        {
            return latitude;
        }

        public String getSitename()
        {
            return this.sitename;
        }

        public List<double> getEHE()
        {
            return EHE;
        }

        public List<double> getEHN()
        {
            return EHN;
        }

        public List<double> getEHZ()
        {
            return EHZ;
        }

        public void appendEHE(float x)
        {
            if (this.dataSource.Equals("External"))
            {
                EHE.Add(x * countsToVolts);
            }
            else
            {
                EHE.Add(x);
            }
        }

        public void appendEHN(float y)
        {
            if (this.dataSource.Equals("External"))
            {
                EHN.Add(y * countsToVolts);
            }
            else
            {
                EHN.Add(y);
            }
        }

        public void appendEHZ(float z)
        {
            if (this.dataSource.Equals("External"))
            {
                EHZ.Add(z * countsToVolts);
            }
            else
            {
                EHZ.Add(z);
            }
        }

        public void setSource(String dataSource)
        {
            this.dataSource = dataSource;
        }

        public void setUnit(String unit)
        {
            this.unit = unit;
        }

        public void setSamplePerSecond(double samplePerSecond)
        {
            this.samplePerSecond = samplePerSecond;
        }

        public void setSecond(double second)
        {
            this.second = second;
        }

        public void setHour(double hour)
        {
            this.hour = hour;
        }

        public void setMinute(double minute)
        {
            this.minute = minute;
        }

        public void setYear(double year)
        {
            this.year = year;
        }

        public void setMonth(double month)
        {
            this.month = month;
        }

        public void setDay(double day)
        {
            this.day = day;
        }

        public void setCompass(double compass)
        {
            this.compass = compass;
        }

        public void setAuthority(String authority)
        {
            this.authority = authority;
        }

        public void setSitename(String sitename)
        {
            this.sitename = sitename;
        }

        public void setLongitude(double longitude)
        {
            this.longitude = longitude;
        }

        public void setLatitude(double latitude)
        {
            this.latitude = latitude;
        }

    }
}
