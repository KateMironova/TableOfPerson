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
using TableOfPerson;
using TableOfPerson.DataBaseApi;

namespace DB_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tm.SetDataBase(comboDB.SelectedItem.ToString());
        }

        TableModel tm = new TableModel();
        private Person GetPerson()
        {
            int id = Int32.Parse(txtId.Text);
            string fn = txtFirstName.Text;
            string ln = txtLastName.Text;
            int age = Int32.Parse(txtAge.Text);
            return new Person(id, fn, ln, age);
        }
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            dataGridView1.ItemsSource = tm.Read();
            dataGridView1.Items.Refresh();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tm.Create(GetPerson());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            tm.Update(GetPerson());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            tm.Delete(GetPerson());
        }

        private void comboDB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tm.SetDataBase(comboDB.SelectedItem.ToString());
        }
    }
}
