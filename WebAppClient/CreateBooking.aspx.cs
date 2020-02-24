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
        HotelRoom room;



        Size Size
        {
            get
            {
                return bs.convertToEnum<Size>(DropDownList2.SelectedValue);
                    
            
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

        public string displayBookedRoom(Booking booking, List<HotelRoom> rooms)
        {


            foreach (HotelRoom r in rooms)
            {
                if (booking.roomId == r.roomId)
                {
                    room = r;
                }
            }

            return "Room ID: " + room.roomId + "room type: "+ room.size + "number of beds:" + room.nBeds;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
    

           List<HotelRoom> availablerooms = bs.AvailableRooms(bs.bookings, bs.rooms, DateFrom, DateTo, NBeds, Size);

           HotelRoom theRoom = bs.firstValidRoomFromList(availablerooms);

 
            //Book.Enabled = true;
            //Book.Visible = true;

            MessageBoxResult result = MessageBox.Show("This room is available, and suits your preferences: " + showRoom(theRoom) + "/n Do you want to book this room?", "My App", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    bs.newBooking(theRoom.size, theRoom.nBeds, myb)
              

                    MessageBox.Show("You have now booked the room: " + showRoom(theRoom), "My App");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "My App");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "My App");
                    break;
            }

            // if(bs.firstValidRoomFromList(availablebs.rooms) != null)
            //{

            //Create button - Yes it is available, do you want to book?
            //onmouseclick - makeReservation.

            //  MessageBox.Show("Do you want to book a room from: "+  DateFrom.Date.ToString() + " to " +  DateTo.Date.ToString() + " with "  + NBeds +  " beds and type: " +Size.ToString());


            string name = "yes";
                Button showButton = new Button();

                showButton.CommandName = name;
                showButton.Text = "Yes!";
                showButton.Visible = true;
                showButton.Enabled = true;
                showButton.Click += new EventHandler(this.Button2_Click);
                Controls.Add(showButton);


           // }


        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Say what");


        }

    }
}