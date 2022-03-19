using Npgsql;
using ITDUtilities.imageQuering;

namespace ServerData.PostgreSQLServer
{
    /// <summary>
    ///open's the Connection to the PostgerSQL Server
    /// </summary>
    public class Connection
    {
        // variable object of Parameters class
        private Parameters variable = new Parameters();

        /// <summary>
        /// return Npgsql connection for the server
        /// </summary>
        public NpgsqlConnection Sign_In()
        {
            // creates a factory object of PostgreSQLConnectionFactory class
            PostgreSQLConnectionFactory factory = new PostgreSQLConnectionFactory(variable.Details());
            //making connection by using GetNewSQLConnectionObject method for factory object
            NpgsqlConnection connection = factory.GetNewSQLConnectionObject();
            //opening connection 
            connection.Open();
            return connection;
        }


    }
}
