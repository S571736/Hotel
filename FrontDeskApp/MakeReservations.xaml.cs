using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FrontDeskApp
{
    public partial class MakeReservations : Page, INotifyPropertyChanged
    {
        static List<rooms> roomList = AllRooms();
        ObservableCollection<rooms> allRooms = new ObservableCollection<rooms>(roomList);
        ObservableCollection<bookings> allBookings = new ObservableCollection<bookings>(AllBookings());

        public MakeReservations()
        {
            InitializeComponent();
            RoomReservationList.ItemsSource = allRooms;
            MakeReservation = new RelayCommand(
                o =>
                {
                allRooms.Remove((rooms)o);
                });

            checkRooms = new RelayCommand(
             o =>
             {
                 refill(); 
                 List<rooms> rlist =  updateRooms();
                 foreach (rooms r in rlist) {
                     allRooms.Remove(r);
                 }
             });
        }

        public void refill() {
            foreach (rooms r in roomList) {
                if (!allRooms.Contains(r)) {
                    allRooms.Add(r);
                }
            }
            //allRooms.OrderBy(i => i.roomID);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int customer_ID;
        private int room_ID;
        private DateTime date_to = DateTime.Now;
        private DateTime date_from = DateTime.Now;
        public int CustomerID
        {
           get { return customer_ID; }
           set
           {
                if (value != customer_ID)
                {
                    customer_ID = value;
                    OnPropertyChanged("CustomerID");
                }
           }
        }

        public int _RoomID
        {
            get { return room_ID; }
            set
            {
                if (value != room_ID)
                {
                    room_ID = value;
                    OnPropertyChanged("_RoomID");
                }
            }
        }
        public DateTime DateFrom
        {
            get { return date_from; }
            set
            {
                if (value != date_from)
                {
                    date_from = value;
                    OnPropertyChanged("DateFrom");
                    updateRooms();
                }
            }
        }

        public DateTime DateTo
        {
            get { return date_to; }
            set
            {
                if (value != date_to)
                {
                    date_to = value;
                    OnPropertyChanged("DateTo");
                    updateRooms();
                }
            }
        }

        public ICommand MakeReservation { get; }
        public ICommand checkRooms { get; }

        private static List<rooms> AllRooms()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from r in db.rooms
                            select r;
                return query.ToList();
            }
        }

        private static List<bookings> AllBookings()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from r in db.bookings
                            select r;
                return query.ToList();
            }
        }

        private void CreateReservation_Click(object sender, RoutedEventArgs e)
        {
            bookings b = new bookings();
            if (customer_ID!= 0 && room_ID != 0)
            {
                if (date_from < date_to)
                {
                    b.customerID = customer_ID;
                    b.roomID = room_ID;
                    b.dateFrom = date_from;
                    b.dateTo = date_to;
                    addBooking(b);
                    MessageBox.Show("Booking of room: " + b.roomID + "is done");
                }
                else
                {
                    MessageBox.Show("Dates are invalid");
                }
            }
            else {
                MessageBox.Show("One or more of the values are invalid");
            }
        }

        private void addBooking(bookings b)
        {
            using (var db = new HotelDBEntities())
            {
                db.bookings.Add(b);
                db.SaveChanges();
            }
        }

        private List<rooms> updateRooms() {
            List<rooms> removeRooms = new List<rooms>();
            foreach (bookings b in allBookings) {
                foreach(rooms r in allRooms)
                {
                    if (b.roomID == r.roomID)
                    {
                        if (date_from <= b.dateTo && date_to >= b.dateFrom)
                        {
                            removeRooms.Add(r);
                        }
                    }
                }
            }
            return removeRooms;
        }
    }

}
