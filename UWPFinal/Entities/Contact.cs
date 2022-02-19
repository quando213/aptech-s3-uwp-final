using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPFinal.Entities
{
    public class Contact
    {
        public string name { get; set; }
        public string phoneNumber { get; set; }

        public Contact()
        {
        }

        public Contact(string nameValue, string phoneNumberValue)
        {
            name = nameValue;
            phoneNumber = phoneNumberValue;
        }
    }
}
