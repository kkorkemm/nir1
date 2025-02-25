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
using System.Windows.Shapes;
using WpfApp234234.Entities;

namespace WpfApp234234.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddClassWindow.xaml
    /// </summary>
    public partial class AddClassWindow : Window
    {
        private NewClass userClass = new NewClass();
        private bool isNew = true;

        public AddClassWindow(NewClass newClass)
        {
            InitializeComponent();

            userClass.Attributes = new List<ClassAttributes>();
            userClass.Methods = new List<ClassMethods>();

            if (newClass != null)
            {
                userClass = newClass;
                isNew = false;
            }

            DataContext = userClass;
            GridClassAttributes.ItemsSource = userClass.Attributes;
            GridClassMethods.ItemsSource = userClass.Methods;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var attributes = GridClassAttributes.ItemsSource as List<ClassAttributes>;
            var attributesCopy = attributes.Take(attributes.Count() - 2).ToList();
            if (attributesCopy != null)
            {
                foreach (var attribute in attributesCopy)
                {
                    userClass.Attributes.Add(attribute);
                }
            }

            var methods = GridClassMethods.ItemsSource as List<ClassMethods>;
            var methodsCopy = methods.Take(methods.Count() - 2).ToList();
            if (methodsCopy != null)
            {
                foreach(var method in methodsCopy)
                {
                    userClass.Methods.Add(method);
                }
            }

            if (isNew)
            {
                User.UserClasses.Add(userClass);
            }

            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
