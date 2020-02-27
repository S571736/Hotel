using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using HotelLibrary;
using System.Linq;
using System.Windows;

namespace FrontDeskApp
{
    /// <summary>
    /// Interaction logic for DeleteReservations.xaml
    /// </summary>
    public partial class DeleteReservations : Page
    {
        public DeleteReservations()
        {
            InitializeComponent();

            bookingService bs = new bookingService();
            ObservableCollection<bookings> bookingList = new ObservableCollection<bookings>(allBookings());

            RoomReservationList.ItemsSource = bookingList;

            DeleteReservation = new RelayCommand(
                o =>
                {
                    deleteBooking((bookings)o);
                    bookingList.Remove((bookings)o);
                });
        }

        private static List<bookings> allBookings()
        {
            using (var db = new HotelDBEntities())
            {
                var query = from b in db.bookings
                            select b;
                return query.ToList();
            }
        }

        private static void deleteBooking(bookings o)
        {
            using (var db = new HotelDBEntities())
            {
                db.Entry(o).State = System.Data.Entity.EntityState.Deleted;
                MessageBox.Show(("Deleted booking reservation on : " + ((bookings)o).roomID.ToString()));
                db.SaveChanges();
            }
        }

        public ICommand DeleteReservation { get; }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
