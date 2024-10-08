![Timbr logo](https://timbr.ai/wp-content/uploads/2023/06/timbr-ai-l-5-226x60-1.png)

# timbr .NET connector sample file
  This project is a sample connecting to timbr using .Net.

## Dependencies
  - .Net 8.0 SDK
  - Microsoft Spark ODBC Driver
  - OdbcConnection Class

## Installation
  - Install .Net 8.0 SDK: https://dotnet.microsoft.com/en-us/download
  - Install Microsoft Spark ODBC Driver: https://www.microsoft.com/en-us/download/details.aspx?id=49883
  - Add to your .Net project the OdbcConnection Class by this command: ```dotnet add package System.Data.Odbc```

## Sample usage
  - Copy to your .Net project the ```executeTimbrQuery``` function.
  - Use this function as explained in this [example file](timbr-odbc-sample.cs)

## Connection parameters
  ```c#
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
  ```
## Execute query example
  ```c#
    // Example with dummy data for query execution
    string hostname = "mytimbrenv.com";
    int port = 443;
    string ontology = "my_ontology";
    string token = "tk_mytimbrtoken";
    string query = "SELECT * FROM timbr.sys_concepts";
    
    executeTimbrQuery(hostname, port, ontology, token, query);
  ```