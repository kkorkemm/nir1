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
            Windows.AddClassWindow addClassWindow = new Windows.AddClassWindow(null);
            addClassWindow.ShowDialog();

            if (count < User.UserClasses.Count)
            {
                var newClass = new ClassBox(CNV);
                User.UserClassBoxes.Add(newClass);
            }

            ListClasses.ItemsSource = User.UserClasses.ToList();
        }

        private ClassBox copiedClass;

        public void CopyClass(ClassBox classBox)
        {
            copiedClass = classBox;
            ListClasses.ItemsSource = User.UserClasses.ToList();
        }

        public void PasteClass(NewClass myClass)
        {
            if (copiedClass == null) return;

            // Создаем новый класс на основе скопированного
            var newClass = new ClassBox(CNV, copiedClass);
            User.UserClassBoxes.Add(newClass);
            User.UserClasses.Add(myClass);
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

            Windows.AddLinkWindow addLinkWindow = new Windows.AddLinkWindow(null); 
            addLinkWindow.ShowDialog();

            if (count < User.UserConnections.Count)
            {
                var newLine = new ConnectionLine(CNV);
               
            }

            ListConnections.ItemsSource = User.UserConnections.ToList();
        }

        private void ListClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var userClass = ListClasses.SelectedItem as NewClass;
            var box = User.UserClassBoxes.Where(p => p.ClassInfo.Name == userClass.Name).FirstOrDefault();

            Windows.AddClassWindow editClassWindow = new Windows.AddClassWindow(userClass);
            editClassWindow.ShowDialog();

        }

        private void ListConnections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var connection = ListConnections.SelectedItem as Connection;
            Windows.AddLinkWindow editConnectionWindow = new Windows.AddLinkWindow(connection);
            editConnectionWindow.ShowDialog();
        }
    }
}
