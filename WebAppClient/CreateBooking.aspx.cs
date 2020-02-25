using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using HotelLibrary;
using System.Data.Entity;

namespace WebAppClient.CreateBooking
{

    public partial class CreateBooking : System.Web.UI.Page
    {

        bookingService bs = new bookingService();


        //Get from DB
        List<rooms> rooms = AllRooms();

        List<bookings> booking = AllBookings();

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

        public string showRoom(rooms room)
        {
            string info = "Number of beds:" + room.beds.ToString() + " Type of room: " + room.size;
            return info;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

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
                        string rand = b.dateTo.ToString();
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
            };

             // Last opp til DB


            if (true)
            {


                MessageBox.Show("Hello " + FirstName + " " + LastName + " This room is available, and suits your preferences: " + showRoom(theRoom) + "Do you want to book it?");


                //MessageBox.Show("This room is available, and suits your preferences: " + rooms[0].roomID + rooms[0].size + rooms[0].beds + "Do you want to book it?");


                string name = "yes";
                Button showButton = new Button();

                showButton.CommandName = name;
                showButton.Text = "Yes!";
                showButton.Visible = true;
                showButton.Enabled = true;
                showButton.Click += new EventHandler(this.Button2_Click);
                Controls.Add(showButton);

            }
            // }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            //create booking in db

            MessageBox.Show("You have booked this room.");


        }

    }
}