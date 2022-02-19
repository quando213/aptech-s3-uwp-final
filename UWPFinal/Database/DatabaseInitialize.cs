using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPFinal.Entities;

namespace UWPFinal.Database
{
    class DatabaseInitialize
    {
        private static SQLiteConnection conn = new SQLiteConnection("final.db");

        public static bool CreateTable()
        {
            var sql = @"CREATE TABLE IF NOT EXISTS contacts(Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Name NVARCHAR(255) NOT NULL,PhoneNumber NVARCHAR(100) NOT NULL);";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public bool InsertContact(Contact contact)
        {
            var sql = $"INSERT INTO contacts (Name, PhoneNumber) VALUES ('{contact.name}', '{contact.phoneNumber}')";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public List<Contact> ListContact()
        {
            List<Contact> contacts = new List<Contact>();
            var sql = "SELECT * FROM contacts";
            using (var statement = conn.Prepare(sql))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    var name = (string)statement["Name"];
                    var phoneNumber = (string)statement["PhoneNumber"];
                    var obj = new Contact(name, phoneNumber);
                    contacts.Add(obj);
                }
            }
            return contacts;
        }

        public Contact FindByName(string name)
        {
            try
            {
                SQLiteConnection cnn = new SQLiteConnection("final.db");
                using (var stt = cnn.Prepare($"select * from contacts where Name Like '%{name}%'"))
                {
                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        var contact = new Contact()
                        {
                            name = (string)stt["Name"],
                            phoneNumber = (string)stt["PhoneNumber"],
                        };
                        return contact;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Contact FindByPhone(string phoneNumber)
        {
            try
            {
                SQLiteConnection cnn = new SQLiteConnection("final.db");
                using (var stt = cnn.Prepare($"select * from contacts where PhoneNumber = '{phoneNumber}'"))
                {
                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        var contact = new Contact()
                        {
                            name = (string)stt["Name"],
                            phoneNumber = (string)stt["PhoneNumber"],
                        };
                        Debug.WriteLine(contact);
                        return contact;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
