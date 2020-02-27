using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelLibrary;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Media;

namespace WebAppClient
{
	public partial class CheckBooking : System.Web.UI.Page
	{

		bookingService bs = new bookingService();


        List<bookings> bookings = AllBookings();
        List<bookings> myBookings = new List<bookings>();

        List<rooms> rooms = AllRooms();

        public static List<bookings> AllBookings()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from b in db.bookings
                            select b;
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


        protected void Page_Load(object sender, EventArgs e)
		{

            DataTable dt = this.getData(bookings);

            StringBuilder html = new StringBuilder();
            html.Append("<table border = '1'>");


            html.Append("<tr>");


            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");


            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            //Table end.
            html.Append("</table>");
            string strText = html.ToString();




            ////Append the HTML string to Placeholder.
            ///
            
           
           

            placeholder.Controls.Add(new Literal { Text = html.ToString() });



        }


        public DataTable getData(List<bookings> allBookings)
        {

            int sessionID = (int)(Session["id"]);

            foreach (bookings b in allBookings)
            {
                if(b.customerID == sessionID)
                {
                    myBookings.Add(b);
                }             
                
            }


            DataTable dt = new DataTable();

            dt.Columns.Add("Room ID", typeof(int));
            dt.Columns.Add("Date From", typeof(DateTime));
            dt.Columns.Add("Date To", typeof(DateTime));
            dt.Columns.Add("Numbers of beds", typeof(int));
            dt.Columns.Add("Type", typeof(string));  //muligens dette må være string

            foreach (bookings b in myBookings)
            {
                foreach (rooms r in AllRooms())
                {
                    if (b.roomID == r.roomID)
                    {
                        dt.Rows.Add(b.roomID, b.dateFrom, b.dateTo, r.beds, r.size);
                    }
                }

            }


            return dt;
        }


        protected void LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Session.Abandon();
        }

    }
}
