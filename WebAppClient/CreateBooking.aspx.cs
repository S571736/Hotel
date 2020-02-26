using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using HotelLibrary;
using System.Data.Entity;
using WebAppClient;

namespace WebAppClient.CreateBooking
{

    public partial class CreateBooking : System.Web.UI.Page
    {

        bookingService bs = new bookingService();




        //Get from DB
        List<rooms> rooms = AllRooms();

        List<bookings> booking = AllBookings();

        bookings myBooking = new bookings();

        HotelDBEntities db = new HotelDBEntities();

        HttpContext context = HttpContext.Current;


        Size Size
        {
            get
            {
                return bs.convertToEnum<Size>(DropDownList2.SelectedValue);

            }
            set { }
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

        DateTime DateFrom
        {

            get
            {

                return DateFromCalendar.SelectedDate.Date;
            }

        }


        DateTime DateTo
        {

            get
            {
                return DateToCalendar.SelectedDate.Date;
            }
        }

        int NBeds
        {
            get
            {
                return int.Parse(DropDownList1.SelectedValue);
            }

            set { NBeds = value; }
        }


        //getting user ID from session
        int UserID
        {
            get
            {
                return (int)context.Session["id"];

            }
        }

        string FirstName
        {
            get
            {
                return (string)context.Session["firstname"];
            }
        }

        string LastName
        {
            get
            {
                return (string)context.Session["lastname"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static List<customer> AllCustomers()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from c in db.customer
                            select c;
                return query.ToList();
            }
        }

        public string showRoom(rooms room)
        {
            string info = "Number of beds:" + room.beds.ToString() + " Type of room: " + room.size;
            return info;
        }

        public customer getUser()
        {
            customer user = new customer();
            foreach (customer c in AllCustomers())
            {
                if(c.customerID == UserID)
                {
                    user = c;
                }
            }
            return user;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            bool roomCheck = false;
            var listOfRooms = AllRooms();
            var listOfBookings = AllBookings();

            //List<rooms> availableRooms = listOfRooms.Where((Func<rooms, bool>)(i => i.beds == NBeds && i.size.Equals(Size.ToString().ToLower()))).ToList();

            List<rooms> avroms = new List<rooms>();

            foreach(rooms r in listOfRooms)
            {
                if (r.beds == NBeds && r.size.Equals(Size.ToString().ToLower())){
                    avroms.Add(r);
                }
            }

            //availableRooms = availableRooms.ToList();

            foreach (bookings b in listOfBookings)
            {
                foreach (rooms r in avroms)
                {
                    if (b.roomID == r.roomID)
                    {
                        DateTime tmpTo = new DateTime();
                        DateTime tmpFrom = new DateTime();
                       
                        tmpTo = Convert.ToDateTime(b.dateTo);
                        tmpFrom = Convert.ToDateTime(b.dateFrom);
                        
                        if (DateFrom >= tmpTo && DateTo <= tmpFrom)
                        {
                            avroms.Remove(r);
                        }
                    }
                }
            }

            rooms theRoom = new rooms();

            if (avroms.Count() != 0)
            {
               theRoom = avroms.First();
                roomCheck = true;

            }
            else
            {
               MessageBoxResult failed = MessageBox.Show("No available rooms that match your preferences. Try again.", "Not available", MessageBoxButton.OK);

                switch (failed)
                {
                    case MessageBoxResult.OK:
                        Response.Redirect("CreateBooking.aspx");
                    break;
                }
                

            }

             // Last opp til DB


            if (roomCheck)
            {



                MessageBoxResult booked = MessageBox.Show("Hello " + FirstName + " " + LastName + " This room suits your preferences: " + showRoom(theRoom) + ". Do you want to book it? ", "Booked Room", MessageBoxButton.OKCancel);


                switch (booked)
                {
                    case MessageBoxResult.OK:

                        myBooking = new bookings();

                        myBooking.roomID = theRoom.roomID;
                        myBooking.customerID = UserID;
                        myBooking.dateFrom = DateFrom;
                        myBooking.dateTo = DateTo;
                        myBooking.note = "Booked";


                        //myBooking.customer = getUser();
                        //myBooking.rooms = theRoom;

                        db.bookings.Add(myBooking);
                        db.SaveChanges();

                        Response.Redirect("CheckBooking.aspx");


                        break;
              
                    case MessageBoxResult.Cancel:

                        MessageBox.Show("Do you want to book another?", "Delete");
                        Response.Redirect("CreateBooking.aspx");

                        break;
                }


            }
            // }


        }



        protected void LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }

    }
}