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

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Lógica de interacción para ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {

        //private Contact contact;

        //public Contact Contact
        //{
        //    get { return contact; }
        //    set { 
        //        contact = value;
        //        textName.Text = contact.nombre;
        //        textEmail.Text = contact.email;
        //        textPhone.Text = contact.telefono;

        //    }
        //}


        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact {  nombre = "Pepe", telefono="123123123", email= "ertregmail.dcac"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            if(control != null)
            {
                control.textName.Text = (e.NewValue as Contact).nombre;
                control.textEmail.Text = (e.NewValue as Contact).email;
                control.textPhone.Text = (e.NewValue as Contact).telefono;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
