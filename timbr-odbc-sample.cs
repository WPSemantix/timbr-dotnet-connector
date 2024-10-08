using System;
using System.Data.Odbc;

static void Main(string[] args)
{
    string hostname = "<TIMBR_IP/HOST>";
    int port = <TIMBR_PORT>;
    string ontology = "<ONTOLOGY_NAME>";
    string token = "<TIMBR_TOKEN_VALUE>";
    string query = "<QUERY_TO_EXECUTE>";

    // hostname - The IP / Hostname of the Timbr platform.
    // port - The port to connect to in the Timbr server. Timbr's default port for HTTPS connection is 443 and for HTTP connection is 11000.
    // ontology - The name of the ontology (knowledge graph) to connect.
    // token - The token value of your user from Timbr Platform.
    // query - The query that you want to execute.

    executeTimbrQuery(hostname, port, ontology, token, query);
}

static void executeTimbrQuery(string hostname, int port, string ontology, string token, string query)
{
    string connectionString = "Driver={Microsoft Spark ODBC Driver};" + 
                              "Host=" + hostname + ";" +
                              "Port=" + port + ";" +
                              "Database=" + ontology + ";" + 
                              "UID=token@" + ontology + ";" +
                              "PWD=" + token + ";" +
                              "AuthMech=3;" +
                              "HTTPPath=/timbr-server;" + 
                              "SSL=1;" + 
                              "ThriftTransport=2;";

    using (OdbcConnection connection = new OdbcConnection(connectionString))
    {
        try
        {
            connection.Open();
            Console.WriteLine("Connection Opened Successfully.");
            OdbcCommand command = new OdbcCommand(query, connection);
            using (OdbcDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["concept"]);
                }
                reader.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Connection Closed.");
            }
        }
    }
}