namespace WebApi.Connection
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;

    using ServiceStack.OrmLite;

    using WebApi.Models;

    /// <summary>
    /// The orm lite connection.
    /// </summary>
    public class OrmLiteConnection
    {
        /// <summary>
        /// The settings.
        /// </summary>
        private readonly Settings settings;

        /// <summary>
        /// The instance.
        /// </summary>
        private static OrmLiteConnection instance;

        /// <summary>
        /// The connection.
        /// </summary>
        private static OrmLiteConnectionFactory connection;

        /// <summary>Get the instance.</summary>
        /// <returns>The current instance or create one</returns>
        public static OrmLiteConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new OrmLiteConnection();
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                var config = builder.Build();

                connection = new OrmLiteConnectionFactory(config.GetConnectionString("SqlConn"), SqlServerDialect.Provider);
            }

            return instance;
        }

        /// <summary>Open the connection.</summary>
        /// <returns>The connection opened.</returns>
        /// <exception cref="Exception">If an exception occurs</exception>
        public IDbConnection OpenConnection()
        {
            try
            {
                return connection.OpenDbConnection();
            }
            catch (SqlException e)
            {
                throw new Exception("Não foi possível conectar no banco de Dados!", e.InnerException);
            }
        }
    }
}