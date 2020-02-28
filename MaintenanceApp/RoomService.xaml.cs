using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MaintenanceApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RoomService : Page
    {
        ObservableCollection<services> serviceList = new ObservableCollection<services>();
        ObservableCollection<services> roomServiceList = new ObservableCollection<services>();

        public RoomService()
        {
            this.InitializeComponent();
            DataConnection.DefaultSettings = new MySettings();
            serviceList = getServices();
            workList();
        }

        private void workList()
        {
            foreach (services s in serviceList)
            {
                if (s.serviceType.ToLower().Equals("roomservice"))
                {
                    roomServiceList.Add(s);
                }
            }
            RoomServiceList.ItemsSource = roomServiceList;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem mfi = (MenuFlyoutItem)sender;
            String s = mfi.Text;
            int id = (int)mfi.Tag;
            updateService(s, id);
        }

        private ObservableCollection<services> getServices()
        {
            using (var db = new AzureDataBase())
            {
                var query = from p in db.services
                            select p;
                return new ObservableCollection<services>(query.ToList());
            }
        }

        private void updateService(String status, int id)
        {
            foreach (services m in roomServiceList)
            {
                if (m.serviceID == id)
                {
                    m.serviceStatus = status;
                }
            }
            using (var db = new AzureDataBase())
            {
                foreach (services s in roomServiceList)
                {
                    if (s.serviceID == id)
                    {
                        db.Update(s);
                    }
                }
            }
        }
    }
}
