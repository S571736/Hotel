namespace FrontDeskApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            bookings = new HashSet<bookings>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customerID { get; set; }

        [StringLength(25)]
        public string firstName { get; set; }

        [StringLength(25)]
        public string lastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookings> bookings { get; set; }
    }
}
