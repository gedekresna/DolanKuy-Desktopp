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
using Velacro.UIElements.Basic;
using Velacro.UIElements.Button;

namespace DolanKuyDesktopPalingbaru.ListWisata
{
    /// <summary>
    /// Interaction logic for ListWisata.xaml
    /// </summary>
    public partial class ListWisata : MyPage
    {
        private BuilderButton buttonBuilder;
        private IMyButton buttonGet;
        private List<ModelListWisata> listServices;
        private List<int> actualId = new List<int>();
        String token;

        public ListWisata(string token)
        {
            this.token = token;
            InitializeComponent();
            setController(new ListWisataController(this));
            initUIBuilders();
            getData();
        }

        private void initUIBuilders()
        {
            buttonBuilder = new BuilderButton();
        }

        public void getData()
        {
            getController().callMethod("getLocation");
        }

        public void setLocation(List<ModelListWisata> locationList)
        {
            this.listServices = locationList;
            /*actualId.Clear();
            int id = 1;
            foreach (ModelCategory category in categoryList)
            {
                actualId.Add(category.id);
                category.id = id;
                id++;
            }*/

            this.Dispatcher.Invoke((Action)(() => {
                serviceList.ItemsSource = locationList;
            }));
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

            // editPage = new EditLokasi.EditPage();
            //this.NavigationService.Navigate(editPage);
            Button button = sender as Button;
            ModelListWisata dataObject = button.DataContext as ModelListWisata;
            this.NavigationService.Navigate(new EditPageLokasi(dataObject.id));
            //getController().callMethod("putCategory", dataObject.id);

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listServices.Count; i++)
            {
                //listServices.ElementAt(i).id = actualId.ElementAt(i);
            }

            Button button = sender as Button;
            ModelListWisata dataObject = button.DataContext as ModelListWisata;
            Console.WriteLine(dataObject.id);
            MessageBoxResult result = MessageBox.Show("Are you sure want to perform this action?", "Delete Service", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    getController().callMethod("deleteService", dataObject.id);

                    break;
            }
        }
    }
}
