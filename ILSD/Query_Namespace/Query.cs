
namespace Device_Query_Connection.Query_Namespace
{
    public class Query
    {
        /// <summary>
        ///creates object called place from DevicePlacing
        /// </summary>
        private DevicePlacing place = new DevicePlacing();

        /// <summary>
        /// returns the Query statement 
        /// </summary>
        public string ReadingQuery(string table)
        {
            string queryStatement = "";

            if (table == "current")
            {
                //query for getting current table readings
                queryStatement = string.Format($"SELECT* from current where (device ='{place.Room_WA(place.RandomNumber())}'OR device ='{place.Room_TH(place.RandomNumber())}') AND (reading = 'temperature_actual' OR reading='humidity')");
            }
            else if (table == "history")
            {
                //query for getting history table readings of two months
                queryStatement = string.Format($"SELECT* from history where (device ='{place.Room_TH(place.RandomNumber())}'OR device ='{place.Room_WA(place.RandomNumber())}') AND (reading = 'temperature_actual' AND reading='humidity') AND (timestamp between '2021-08-01' and '2021-10-10')");
            }
            else
            {
                //query for getting current table readings for Powerplug device
                queryStatement = string.Format($" SELECT* from current where device ='{place.Powerplug(place.RandomNumber2())}' AND (reading = '2.STATE' OR reading = '4.STATE')");
            }
            return queryStatement;

        }

        /// <summary>
        /// returns the Query statement  for history table
        /// </summary>
        public string ReadingQueryH(string table, string reading)
        {
            string queryStatement = "";

            if (table == "history" && reading == "temperature_actual")
            {
                //query for getting history table readings of two months
                queryStatement = string.Format($"SELECT* from history where (device ='{place.Room_TH(place.RandomNumber())}'OR device ='{place.Room_WA(place.RandomNumber())}') AND (reading = 'temperature_actual') AND (timestamp between '2021-09-01' and '2021-09-15')");

            }
            else if (table == "history" && reading == "humidity")
            {
                //query for getting history table readings of two months
                queryStatement = string.Format($"SELECT* from history where (device ='{place.Room_TH(place.RandomNumber())}'OR device ='{place.Room_WA(place.RandomNumber())}') AND (reading='humidity') AND (timestamp between '2021-09-01' and '2021-09-15')");
            }
            return queryStatement;
        }

        /// <summary>
        /// returns the Query statement  of temperature  in current table 
        /// </summary>
        public string ReadingCt(string table)
        {
                //query for getting only current table readings of Temperature
               string queryStatement = string.Format($"SELECT* from current where (device ='{place.Room_WA(place.RandomNumber())}'OR device ='{place.Room_TH(place.RandomNumber())}') AND (reading = 'temperature_actual')");
             
            return queryStatement;
        }

        /// <summary>
        /// returns the Query statement  of humidity  in current table 
        /// </summary>
        public string ReadingCh(string table)
        { 
                //query for getting only current table readings of Humidity
               string queryStatement = string.Format($"SELECT* from current where (device ='{place.Room_WA(place.RandomNumber())}'OR device ='{place.Room_TH(place.RandomNumber())}') AND (reading='humidity') ");

            
            return queryStatement;
        }
    }
}
