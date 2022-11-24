using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Lógica de interacción para ContactDetaisWindows.xaml
    /// </summary>
    public partial class ContactDetaisWindows : Window
    {
        Contact contact;
        public ContactDetaisWindows(Contact contact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.contact = contact;
            NameTextBox.Text = contact.nombre;
            PhoneTextBox.Text = contact.telefono;
            EmailTextBox.Text = contact.email;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.nombre = NameTextBox.Text;
            contact.telefono = PhoneTextBox.Text;
            contact.email = EmailTextBox.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);

            }
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
                
            }
            Close();
        }
    }
}
