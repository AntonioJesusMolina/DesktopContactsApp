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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            ReadDataBase();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDataBase();
        } 
        void ReadDataBase()
        {
            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.nombre).ToList();

                //var variable = from c2 in contacts
                //               orderby c2.nombre
                //               select c2;
            }

            if(contacts != null)
            {
                contactsListView.ItemsSource = contacts;

            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox seacrhTextBox = sender as TextBox;
            var filteredList = contacts.Where(c => c.nombre.ToLower().Contains(seacrhTextBox.Text.ToLower())).ToList();

            var filteredList2 = (from c2 in contacts
                                where c2.nombre.ToLower().Contains(seacrhTextBox.Text.ToLower())
                                orderby c2.email
                                select c2).ToList();
            

            contactsListView.ItemsSource = filteredList;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if(selectedContact != null)
            {
                ContactDetaisWindows contactDetaisWindows = new ContactDetaisWindows(selectedContact);
                contactDetaisWindows.ShowDialog();
                ReadDataBase();

            }
        }
    }
}
