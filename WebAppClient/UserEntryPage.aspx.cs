using HotelLibrary;
using System;
using System.Collections.Generic;

namespace WebAppClient
{
    public partial class UserEntryPage : System.Web.UI.Page
    {
       // private readonly List<Booking> bookings;



        protected void Page_Load(object sender, EventArgs e)
        {

            

           
        
        }


        // en kommentar
        protected void CheckBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckBooking.aspx");
        }
        protected void CreateBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateBooking.aspx");
        }
    }
}