using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;



namespace FrontDeskApp
{

    public partial class Services : Page, INotifyPropertyChanged
    {
       List<services> serviceList = AllServices();

        public static List<services> AllServices()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from s in db.services
                            select s;
                return query.ToList();
            }
        }

        public Services()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int roomID;
        private string serviceType;
        private string note;

        public int RoomID
        {
            get { return roomID; }
            set
            {
                if (value != roomID)
                {
                    roomID = value;
                    OnPropertyChanged("RoomID");
                }
            }
        }

        public string ServiceType
        {
            get { return roomService.Text; }
            set
            {
                if (value != serviceType)
                {
                    serviceType = value;
                    OnPropertyChanged("ServiceType");
                }
            }
        }

        public string Note
        {
            get { return note; }
            set
            {
                if (value != note)
                {
                    note = value;
                    OnPropertyChanged("Note");
                }
            }
        }

        private void CreateService_Click(object sender, RoutedEventArgs e)
        {
            services s = new services();
            var id = AllServices()[AllServices().Count - 1].serviceID+ 1;
            
            s.serviceID = id;
            s.serviceType = ServiceType;
            s.roomID = (int)roomID;
            s.serviceStatus = "NEW";
            s.note = note;
            addServices(s);
            MessageBox.Show("You have created a " + ServiceType + "Service for room: " + roomID);
        }

        private void addServices(services s)
        {
            using (var db = new HotelDBEntities())
            {
                db.services.Add(s);
                db.SaveChanges();                
            }
        }
    }
}



