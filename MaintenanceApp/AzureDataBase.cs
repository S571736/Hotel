using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaintenanceApp
{
    class AzureDataBase : LinqToDB.Data.DataConnection
    {
        public AzureDataBase() : base("AzureDB") { }

        public ITable<services> services => GetTable<services>();
       
    }
}
