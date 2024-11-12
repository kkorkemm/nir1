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
using WpfApp234234.Entities;

namespace WpfApp234234.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnAddClass_Click(object sender, RoutedEventArgs e)
        {
            int count = User.UserClasses.Count;
            Windows.AddClassWindow addClassWindow = new Windows.AddClassWindow();
            addClassWindow.ShowDialog();

            if (count < User.UserClasses.Count)
            {
                var newClass = new ClassBox(CNV);
            }

            ListClasses.ItemsSource = User.UserClasses.ToList();
        }

        private void BtnAddLink_Click(object sender, RoutedEventArgs e)
        {
            int count = User.UserConnections.Count;
            if (User.UserClasses.Count < 2)
            {
                MessageBox.Show("Количество классов должно быть >= 2", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Windows.AddLinkWindow addLinkWindow = new Windows.AddLinkWindow(); 
            addLinkWindow.ShowDialog();

            if (count < User.UserConnections.Count)
            {
                var newLine = new ConnectionLine(CNV);
            }

            ListConnections.ItemsSource = User.UserConnections.ToList();
        }
    }
}
