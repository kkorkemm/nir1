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
            Windows.AddClassWindow addClassWindow = new Windows.AddClassWindow();
            addClassWindow.ShowDialog();

            var newClass = new ClassBox(CNV);
            User.UserClassBoxes.Add(newClass);

            ListClasses.Items.Add(newClass);
        }

        private void BtnAddLink_Click(object sender, RoutedEventArgs e)
        {
            if (User.UserClassBoxes.Count < 2)
            {
                MessageBox.Show("Количество классов должно быть >= 2", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Windows.AddLinkWindow addLinkWindow = new Windows.AddLinkWindow(); 
            addLinkWindow.ShowDialog();
        }
    }
}
