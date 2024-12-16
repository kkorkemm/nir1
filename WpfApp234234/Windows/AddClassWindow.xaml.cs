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

        public AddClassWindow(NewClass userClass)
        {
            InitializeComponent();

            if (userClass != null)
            {
                this.userClass = userClass;
                isNew = false;
            }

            DataContext = this.userClass;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {      
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
