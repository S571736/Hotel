using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace MaintenanceApp
{
    public partial class services
    {

        [PrimaryKey, Identity]
        public int serviceID { get; set; }

        [Column(Name = "serviceType"), NotNull]
        public string serviceType { get; set; }
        

        [Column(Name = "roomID"), NotNull]
        public int roomID { get; set; }

        [Column(Name = "serviceStatus"), NotNull]
        public string serviceStatus { get; set; }

        [Column(Name = "note"), NotNull]
        public string note { get; set; }
    }
}
