using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace HotelLibrary
{

    public enum Size
    {
        Single,
        Double,
        Triple,
        Suite
    }
    public enum maintenanceType
    {
        RoomService,
        Maintenance,
        Cleaning
    }
    public enum maintenanceStatus
    {
        Todo,
        Doing,
        Done
    }

    public enum Status
    {
        Booked,
        CheckedIn,
        CheckedOut
    }

    //public class Rooms
    //{
    //    public int nBeds { get; set; }
    //    public Size s { get; set; }
    //    public int roomId { get; set; }
    //    public Rooms(int roomId, Size s, int nBeds)
    //    {
    //        this.roomId = roomId;
    //        this.s = s;
    //        this.nBeds = nBeds;

    //    }
    //}



    //public class Booking
    //{
    //    public int customerId { get; set; }
    //    public int roomId { get; set; }
    //    public DateTime to { get; set; }
    //    public DateTime from { get; set; }
    //    public Status status { get; set; }
    //    public string note { get; set; }
    //    public Booking(int customerId, int roomId, DateTime to, DateTime from, Status status, string note)
    //    {
    //        this.customerId = customerId;
    //        this.roomId = roomId;
    //        this.to = to;
    //        this.from = from;
    //        this.status = status;
    //        this.note = note;
    //    }
    //}

    //public class Services
    //{
    //    public maintenanceType mt { get; set; }
    //    public int roomId { get; set; }
    //    public string note { get; set; }
    //    public maintenanceStatus ms { get; set; }

    //    public Services(maintenanceType mt, int roomId, maintenanceStatus ms, string note)
    //    {
    //        this.mt = mt;
    //        this.roomId = roomId;
    //        this.ms = ms;
    //        this.note = note;
    //    }
    //}

    //public class User
    //{
    //    public int userId { get; set; }
    //    public string firstName { get; set; }
    //    public string surName { get; set; }
    //    public User(int userId, string firstName, string surName)
    //    {
    //        this.userId = userId;
    //        this.firstName = firstName;
    //        this.surName = surName;
    //    }
    //}

    public class bookingService
    {
        //TODO Get DB call
        public List<bookings> bookings { get; set; }
        public List<rooms> rooms { get; set; }

        public bookingService()
        {
            bookings = new List<bookings>();//ServerKall();
            rooms = new List<rooms>(); //ServerKall();   //bare tull etter = , errorfiks
        }
        public bookings newBooking(Size size, int nbeds, int customerId, DateTime to, DateTime from, Status status)
        {
            int roomId = firstValidRoomFromList(AvailableRooms(bookings, rooms, from, to, nbeds, size)).roomID;


            string s = "Customer Id: " + customerId.ToString() + " has booked this room";
            bookings b = new bookings(customerId, roomId, from, to, s);

            return b;
        }


        public T convertToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }


        public bool DateCheck(List<bookings> bookings, DateTime dateFrom, DateTime dateTo, rooms room)
        {

            for (DateTime date = dateFrom; date <= dateTo; date = date.AddDays(1))
            {

                foreach (bookings b in bookings)
                {
                    if (!(date >= b.dateFrom && date <= b.dateTo))
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public List<rooms> AvailableRooms(List<bookings> bookings, List<rooms> r, DateTime dateFrom, DateTime dateTo, int nBeds, Size s)
        {

            string si = s.ToString();


           var validRooms = rooms.Where((Func<rooms, bool>)(i => i.beds == nBeds && i.size.Equals(si)));

            List<rooms> validR = validRooms.ToList();

            //loop through rooms and filter with date
            foreach (rooms ro in validR)
            {
                if (!DateCheck(bookings, dateFrom, dateTo, ro))

                {
                    validR.Remove(ro);
                }

            }
            return validR;

        }



        public rooms firstValidRoomFromList(List<rooms> availableRooms)
        {
            return availableRooms.First();
        }



    }

    public class DBService

    {
        static string connstring = "Server=tcp:hotel-server-dat154.database.windows.net,1433;Initial Catalog = HotelDB; Persist Security Info=False;User ID = admin1; Password={your_password }; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        public DBService()
        {

        }

        List<rooms> DBgetrooms()
        {
            List<rooms> rooms = new List<rooms>();

            /*
            TODO: Add a connection to the database
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                SqlDataReader rdr = null;

                
                
            }
            */


            return rooms;
        }
    }

}
