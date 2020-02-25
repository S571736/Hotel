using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WebAppClient;



namespace WebFormsIdentity
{
    public partial class Register : System.Web.UI.Page
    {


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



        protected void CreateUser_Click(object sender, EventArgs e)
        {

            // Default UserStore constructor uses the default connection string named: DefaultConnection





            var firstName = FirstName.Text;
            var lastName = LastName.Text;


            var db = new HotelDBEntities();



            var id = AllBookings().Count() +1;

            customer cu = new customer(id, firstName, lastName);

            db.customer.Add(cu);
            db.SaveChanges();


            Session["id"] = id;
            Session["firstname"] = firstName;
            Session["lastname"] = lastName;

            Response.Write(Session["id"]);
            Response.Write(Session["firstname"]);
            Response.Write(Session["lastname"]);


            StatusMessage.Text = string.Format("User {0} {1} was created with id {2}!", firstName, lastName, id);



            MessageBox.Show(StatusMessage.Text);


            Response.Redirect("UserEntryPage.aspx");
        


        }
    }
}

