using itd.common.imageQuering;

namespace ServerData.PostgreSQLServer
{
    /// <summary>
    /// Factory for Variables of PostgreSQL Server
    /// </summary>
    public class Parameters
    {
        /// <summary>
        ///default constructor
        /// </summary>
        public Parameters() { }
        
        private PostgreSQLParameters parameters;

        /// <summary>
        /// Constructor with an already initialized parameter data
        /// </summary>
        public Parameters(PostgreSQLParameters parameter)
        {
            this.parameters = parameter;
        }

        /// <summary>
        /// return sign_in data for PostgreSQL server
        /// </summary>
        public PostgreSQLParameters Details()
        {
            this.parameters = new PostgreSQLParameters();
            this.parameters.PostgreSQLHost = "141.54.19.28";
            this.parameters.PostgreSQLPort = 5432;
            this.parameters.UserName = "Shravani";
            this.parameters.Password = "ITD-DigEng.Ma.2021";
            this.parameters.Database = "FHEM_Datalogging";
            return this.parameters;
        }
    }
}
