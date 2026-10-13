using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsBuildRecorder.BusinessLogic;
using TfsBuildRecorder.Entities;

namespace DateFixer
{
    class Program
    {
        public static IFileManager FileManager = new CsvFileManager();

        private static string Month;
        private static string Day;
        private static string Year;
        private static string Hour;
        private static string Minute;
        private static string Second;
        public static string FullDate
        {
            get { return string.Format("{0}/{1}/{2}",Month,Day,Year); }
        }

        public static string FullTime
        {
            get { return String.Format("{0}:{1}:{2}",Hour, Minute, Second); }
        }

        static void Main(string[] args)
        {
            var data = FileManager.ReadExistingBuildData();

            List<string> endDates = GetEndDates(data);

            var transformedDates = TransformDates(endDates);

            FileManager.WriteEndDates(transformedDates);

            Console.WriteLine("Complete");
            Console.ReadLine();
        }

        private static List<string> TransformDates(List<string> endDates)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            List<DateTime> listDates = new List<DateTime>();
            foreach (var date in endDates)
            {
                #region
                var dateEnd = date.Substring(date.Length-2, 2);
                if (dateEnd == "AM" || dateEnd == "PM")
                {
                    string fullDate = date;
                    fullDate = fullDate.Remove(date.Length - 3);
                    var splitdate = fullDate.Split(' ')[0].Split('/');
                    var splitTime = fullDate.Split(' ')[1].Split(':');
                    Month = splitdate[0];
                    Day = splitdate[1];
                    Year = splitdate[2];

                    Hour = splitTime[0];
                    Minute = splitTime[1];
                    Second = splitTime[2];

                    if (Minute.Length < 2)
                    {
                        fullDate = GetFullDateTime("minute");
                    }
                    if (Hour.Length < 2)
                    {
                        fullDate = GetFullDateTime("hour");
                    }
                    if (Day.Length < 2)
                    {
                        fullDate = GetFullDateTime("day");
                    }
                    if (Month.Length < 2)
                    {
                        fullDate = GetFullDateTime("month");
                    }


                    try
                    {
                        listDates.Add(DateTime.ParseExact(fullDate, "MM/dd/yyyy HH:mm:ss", provider));
                    }
                    catch (Exception)
                    {
                    }
                }
                #endregion
                else
                {
                    try
                    {
                        listDates.Add(DateTime.Parse(date, new CultureInfo("en-US")));
                    }
                    catch (Exception)
                    { }

                }

            }
            var stringDates = new List<string>();
            listDates.ForEach(d =>
            {
                var date = ConvertDate(d);
                stringDates.Add(date.ToString("dd MMM yyyy HH:mm:ss", new CultureInfo("en-US")));
            });

            return stringDates;
        }

        private static DateTime ConvertDate(DateTime dateTime)
        {
            if (dateTime.Month < 7 || dateTime.Month > 10)
            {
                var month = dateTime.Month;
                var day = dateTime.Day;
                var year = dateTime.Year;

                var hour = dateTime.Hour;
                var minute = dateTime.Minute;
                var second = dateTime.Second;

                var newDay = month;
                var newMonth = day;

                return new DateTime(year,newMonth,newDay,hour,minute,second);
            }
            return dateTime;
        }

        private static string GetFullDateTime(string section)
        {
            if (section == "minute")
            {
                Minute = 0 + Minute;
            }
            else if (section == "hour")
            {
                Hour = 0 + Hour;
            }
            else if (section == "day")
            {
                Day = 0 + Day;
            }
            else if (section == "month")
            {
                Month = 0 + Month;
            }

            return FullDate + " " + FullTime;
        }

        private static List<string> GetEndDates(List<TfsBuildDetail> data)
        {
            var list = new List<string>();

            foreach (var line in data)
            {
                list.Add(line.FinishTime.ToString(CultureInfo.InvariantCulture));
            }

            return list;
        }
    }
}
