using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Services_Click(object sender, RoutedEventArgs e)
        {
            Services page = new Services();
            this.Content = page;
            this.DataContext = page;

        }

        private void DeleteReservations_Click(object sender, RoutedEventArgs e)
        {
            DeleteReservations mynewPage = new DeleteReservations(); 
            this.Content = mynewPage;
        }

        private void MakeReservations_Click(object sender, RoutedEventArgs e)
        {
            MakeReservations newMakeReservationPage = new MakeReservations();
            this.Content = newMakeReservationPage;
            this.DataContext = newMakeReservationPage;
        }
    }         
}
