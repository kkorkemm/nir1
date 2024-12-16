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

namespace WpfApp234234.Windows
{
    using Entities;
    using System.Windows.Media.TextFormatting;

    /// <summary>
    /// Логика взаимодействия для AddLinkWindow.xaml
    /// </summary>
    public partial class AddLinkWindow : Window
    {
        public List<NewClass> userclasses = User.UserClasses;
        public List<ConnectionType> userConnections = User.connectionTypes;

        public AddLinkWindow(Connection connection)
        {
            InitializeComponent();

            ComboClass1.ItemsSource = userclasses;
            ComboClass2.ItemsSource = userclasses;
            ComboLinkTypes.ItemsSource = userConnections;

            if (connection != null)
            {
                DataContext = connection;
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var connectionType = ComboLinkTypes.SelectedItem as ConnectionType;
            var class1 = ComboClass1.SelectedItem as NewClass;
            var class2 = ComboClass2.SelectedItem as NewClass;

            StringBuilder errors = new StringBuilder();

            if (class1 == null)
                errors.AppendLine("Выберите первый класс");
            if (class2 == null)
                errors.AppendLine("Выберите второй класс");
            if (connectionType == null)
                errors.AppendLine("Выберите тип связи");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Connection connection = new Connection()
            {
                Name = TextLinkName.Text,
                Class1 = class1,
                Class2 = class2,
                Type = connectionType
            };
            User.UserConnections.Add(connection);

            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnInfo1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Класс с указателем/ целый класс / зависимый класс / класс-предок", "Класс 1", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnInfo2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Класс на которого указывают / часть целого / используемый класс / класс-потомок", "Класс 2", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComboLinkTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var connectionType = ComboLinkTypes.SelectedItem as ConnectionType;
            var class1 = ComboClass1.SelectedItem as NewClass;
            var class2 = ComboClass2.SelectedItem as NewClass;

            if (connectionType != null && class1 != null && class2 != null)
            {
                TextLinkName.Text = $"{class1.Name} - {class2.Name}:  {connectionType.Name}";
            }
        }
    }
}
