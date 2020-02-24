namespace FrontDeskApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bookings
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roomID { get; set; }

        public DateTime? dateTo { get; set; }

        public DateTime? dateFrom { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        public virtual customer customer { get; set; }

        public virtual rooms rooms { get; set; }
    }
}
