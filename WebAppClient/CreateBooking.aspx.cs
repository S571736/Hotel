using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using HotelLibrary;

namespace WebAppClient.CreateBooking
{
    public partial class CreateBooking : System.Web.UI.Page
    {

        bookingService bs = new bookingService();


        //Get from DB

        List<HotelRoom> rooms;


        List<Booking> bookings;

        HttpContext context = HttpContext.Current;


        Size Size
        {
            get
            {
                return bs.convertToEnum<Size>(DropDownList2.SelectedValue);
                    
            }
            set {}
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
              
                get {
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
     
        string UserName
        {
            get
            {
                return (string)context.Session["name"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {



        }
       
         
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string showRoom(HotelRoom room)
        {
            string info = "Number of beds:" + room.nBeds.ToString() + " Type of room: " + room.size;
            return info;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            //List<HotelRoom> availableRooms = bs.AvailableRooms(bookings, rooms, DateFrom, DateTo, NBeds, Size);

            //HotelRoom theRoom = bs.firstValidRoomFromList(availableRooms);

            HotelRoom theRoom = new HotelRoom(123, Size.Suite, 2);


            if (theRoom != null)
            {

                MessageBox.Show("Hello " + UserName + " This room is available, and suits your preferences: " + showRoom(theRoom) + "Do you want to book it?");

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