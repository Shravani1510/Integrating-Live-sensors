using System;
using ServerData.PostgreSQLServer;
using Npgsql;
using System.Collections.Generic;

namespace Device_Query_Connection.Query_Namespace
{
    /// <summary>
    /// Factory to read data from the PostgerSQL server
    /// </summary>
    public class PreparingConnection
    {
        /// <summary>
        ///creating objects of Query and Connection classes
        /// </summary>
        private Query q = new Query();
        private Connection connect = new Connection();

        /// <summary>
        ///member variables
        /// </summary>
        private double value;
        private DateTime dt;

        /// <summary>
        ///empty list of values_received
        /// </summary>
        private List<double> values_received = new List<double>();

        /// <summary>
        ///returns Datetime from Current table
        /// </summary>
        public DateTime Connection_Statement(string s, string table)
        {
            try
            {
                // Defines Query for the table
                NpgsqlCommand select = new NpgsqlCommand(q.ReadingQuery(table), connect.Sign_In());
                // calling ExecuteReader to the Query and obtains the result set
                NpgsqlDataReader dataReader = select.ExecuteReader();
                //output the result of the table
                while (dataReader.Read())
                {
                    //FieldCount Returns  number of columns in a row 

                    var time = new object[dataReader.FieldCount];
                    time[0] = dataReader[0];
                    dt = (DateTime)(time[0]);
                }
            }
            catch (Exception e)
            {
                if (connect.Sign_In() != null) ;
                  //Console.WriteLine("{0}", e);
            }
           
            return dt;
        }


        /// <summary>
        // returns only List of Current Reading of Temperature & Humidity
        /// </summary>
        public List<double> ReadingsC(string s, string table)
        { 
            // Defines Query for the table
            NpgsqlCommand select = new NpgsqlCommand(q.ReadingQuery(table), connect.Sign_In());
            // calling ExecuteReader to the Query and obtains the result set
            NpgsqlDataReader dataReader = select.ExecuteReader();

            while (dataReader.Read())
            {
                var values = new object[dataReader.FieldCount];
                values[5] = dataReader[5];
                if (table == "current")
                {
                    value = Convert.ToDouble(values[5]);
                    values_received.Add(value);
                }
            }
            return values_received;
        }

        /// <summary>
        ///returns List of History data Reading of Temperature
        /// </summary>
        public List<double> ReadingsHt(string s, string table)
        {
            string t = "temperature_actual";
            // Defines Query for the table
            NpgsqlCommand select = new NpgsqlCommand(q.ReadingQueryH(table,t), connect.Sign_In());
            // calling ExecuteReader to the Query and obtains the result set
            NpgsqlDataReader dataReader = select.ExecuteReader();
            while (dataReader.Read())
            {
                var values = new object[dataReader.FieldCount];
                values[5] = dataReader[5];
                if (table == "history")
                {
                    value = Convert.ToDouble(values[5]);
                    values_received.Add(value);
                }
            }
            return values_received;
        }

        /// <summary>
        ///returns List of History data Reading of Humidity
        /// </summary>
        public List<double> ReadingsHh(string s, string table)
        {
            string t = "humidity";
            // Defines Query for the table
            NpgsqlCommand select = new NpgsqlCommand(q.ReadingQueryH(table, t), connect.Sign_In());
            // calling ExecuteReader to the Query and obtains the result set
            NpgsqlDataReader dataReader = select.ExecuteReader();
            while (dataReader.Read())
            {
                var values = new object[dataReader.FieldCount];
                values[5] = dataReader[5];
                if (table == "history")
                {
                    value = Convert.ToDouble(values[5]);
                    values_received.Add(value);
                }
            }
            return values_received;
        }

        /// <summary>
        ///returns List of Current data Reading of Temperature
        ///used in graph
        /// </summary>
        public List<double> ReadingsCt(string s, string table)
        {
            //string t = "temperature_actual";
            // Defines Query for the table
            NpgsqlCommand select = new NpgsqlCommand(q.ReadingCt(table), connect.Sign_In());
            // calling ExecuteReader to the Query and obtains the result set
            NpgsqlDataReader dataReader = select.ExecuteReader();
            while (dataReader.Read())
            {
                var values = new object[dataReader.FieldCount];
                values[5] = dataReader[5];
                if (table == "current")
                {

                    value = Convert.ToDouble(values[5]);
                    values_received.Add(value);
                }
            }
           
            return values_received;
        }

        /// <summary>
        ///  returns only Current data Reading of Humidity
        /// </summary>
        public double ReadingsCh(string s, string table)
        { 
            // Defines Query for the table
            NpgsqlCommand select = new NpgsqlCommand(q.ReadingCh(table), connect.Sign_In());
            // calling ExecuteReader to the Query and obtains the result set
            NpgsqlDataReader dataReader = select.ExecuteReader();
            while (dataReader.Read())
            {
                var values = new object[dataReader.FieldCount];
                values[5] = dataReader[5];
                value = Convert.ToDouble(values[5]);
                //values_received.Add(value);
            }
            
            
            return value;
        }

        /// <summary>
        ///returns List of Datetime from History table
        /// </summary>
        List<DateTime> datetime = new List<DateTime>();
        public List<DateTime> Get_Timet(string table)
        {
            string t = "temperature_actual";
            // Defines Query for the table
            NpgsqlCommand select = new NpgsqlCommand(q.ReadingQueryH(table, t), connect.Sign_In());
            // calling ExecuteReader to the Query and obtains the result set
            NpgsqlDataReader dataReader = select.ExecuteReader();
            while (dataReader.Read())
            {
                var values = new object[dataReader.FieldCount];
                values[0] = dataReader[0];
                dt = (DateTime)dataReader[0];
                datetime.Add(dt);
            }
            return datetime;
        }
    }

}
