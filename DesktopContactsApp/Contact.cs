using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }

        public override string ToString()
        {
            return $"{nombre} - {email} -  {telefono}";
        }

    }

}   
