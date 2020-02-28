using LinqToDB.Configuration;
using System.Collections.Generic;
using System.Linq;

public class ConnectionStringSettings : IConnectionStringSettings
{
    public string ConnectionString { get; set; }
    public string Name { get; set; }
    public string ProviderName { get; set; }
    public bool IsGlobal => false;
}

public class MySettings : ILinqToDBSettings
{
    public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

    public string DefaultConfiguration => "SqlServer";
    public string DefaultDataProvider => "SqlServer";

    public IEnumerable<IConnectionStringSettings> ConnectionStrings
    {
        get
        {
            yield return
                new ConnectionStringSettings
                {
                    Name = "AzureDB",
                    ProviderName = "SqlServer",
                    ConnectionString = @"Server = tcp:hotel-server-dat154.database.windows.net,1433;Initial Catalog = HotelDB;" +
                                          " Persist Security Info = False;User ID = admin1; Password = HVLdataOblig4;" +
                                          " MultipleActiveResultSets = False;Encrypt = True;TrustServerCertificate = False;Connection Timeout = 30;"
                };
        }
    }
}