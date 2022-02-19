using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPFinal.Database;
using UWPFinal.Entities;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinal.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContact : Page
    {
        public AddContact()
        {
            this.InitializeComponent();
        }

        private async void HandleAddContact(object sender, RoutedEventArgs e)
        {
            var dialog = new ContentDialog();
            var contact = new Contact()
            {
                name = name.Text,
                phoneNumber = phoneNumber.Text
            };
            var database = new DatabaseInitialize();
            Contact existingContact = database.FindByPhone(phoneNumber.Text);
            if (existingContact != null)
            {
                dialog.Title = "Failed";
                dialog.Content = "Phone number already exists!";
                dialog.PrimaryButtonText = "Close";
                await dialog.ShowAsync();
                return;
            }
            var result = database.InsertContact(contact);
            if (result)
            {
                dialog.Title = "Success";
                dialog.Content = "Contact added.";
                dialog.PrimaryButtonText = "Close";
                await dialog.ShowAsync();
            }
            else
            {
                dialog.Title = "Failed";
                dialog.Content = "An error occurred. Please try again later.";
                dialog.PrimaryButtonText = "Close";
                await dialog.ShowAsync();
            }
        }

        private void GoToList(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
