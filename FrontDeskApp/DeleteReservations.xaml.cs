using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HotelLibrary;

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
            ObservableCollection<rooms> res = new ObservableCollection<rooms>
                {
                    new rooms(1, HotelLibrary.Size.Double, 3),
                    new rooms(2, HotelLibrary.Size.Single, 1),
                    new rooms(4, HotelLibrary.Size.Suite, 3),
                    new rooms(7, HotelLibrary.Size.Double, 2),

                };
            //bs.rooms = res;
            RoomReservationList.ItemsSource = res;

            DeleteReservation = new RelayCommand(
                o =>
                {
                    //MessageBox.Show(((HotelRoom)o).roomId.ToString());
                    res.Remove((rooms)o);
                });
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
