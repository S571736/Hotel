//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppClient
{
    using System;
    using System.Collections.Generic;

    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            this.bookings = new HashSet<bookings>();
        }

        public customer(int customerID, string firstName, string lastName)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bookings> bookings { get; set; }
    }
}