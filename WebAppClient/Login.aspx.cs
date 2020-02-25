using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppClient;

namespace WebFormsIdentity
{
    public partial class Login : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;

        public static List<customer> AllCustomers()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from c in db.customer
                            select c;
                return query.ToList();
            }
        }



        public static List<rooms> AllRooms()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from r in db.rooms
                            select r;
                return query.ToList();
            }
        }

        public static List<bookings> AllBookings()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from b in db.bookings
                            select b;
                return query.ToList();
            }
        }



        protected void LoginUser_Click(object sender, EventArgs e)
        {


            var db = new HotelDBEntities();

            bool result = false;

            string firstName = FirstName.Text;
            string lastName = LastName.Text;

          
            Session["firstname"] = firstName;
            Session["lastname"] = lastName;

          
            Response.Write(Session["firstname"]);
            Response.Write(Session["lastname"]);



            foreach (customer c in AllCustomers())
            {
                if (c.firstName.ToLower().Equals(firstName.ToLower()) && c.lastName.ToLower().Equals(lastName.ToLower())) {

                    result = true;
                
                }
            }




            if (result)
            {
  

                Response.Redirect("UserEntryPage.aspx");
               

            }
            else
            {
                StatusMessage.Text = "ERROR!!!     Er du sikker på at du skrev riktig navn?";
                
                
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}