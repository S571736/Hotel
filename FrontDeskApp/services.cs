namespace FrontDeskApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class services
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int serviceID { get; set; }

        [StringLength(15)]
        public string serviceType { get; set; }

        public int? roomID { get; set; }

        [StringLength(15)]
        public string serviceStatus { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        public virtual rooms rooms { get; set; }
    }
}
