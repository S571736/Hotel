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
    
    public partial class bookings
    {
        public int customerID { get; set; }
        public int roomID { get; set; }
        public Nullable<System.DateTime> dateTo { get; set; }
        public Nullable<System.DateTime> dateFrom { get; set; }
        public string note { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual rooms rooms { get; set; }

        //public bookings(customer cust, rooms room,  DateTime from, DateTime to, string n)
        //{
        //    this.customer = cust;
        //    this.rooms = room;
        //    this.dateFrom = from;
        //    this.dateTo = to;
        //    this.note = n;

        //}

        //public bookings()
        //{

        //}

    }
}