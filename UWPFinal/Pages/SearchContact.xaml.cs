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
    public sealed partial class SearchContact : Page
    {
        public SearchContact()
        {
            this.InitializeComponent();
        }

        private async void HandleSearchContact(object sender, RoutedEventArgs e)
        {
            var database = new DatabaseInitialize();
            var result = database.FindByName(name.Text);
            var dialog = new ContentDialog();
            if (result != null)
            {
                phoneNumber.Text = result.phoneNumber;
            }
            else
            {
                dialog.Title = "None";
                dialog.Content = "Contact not found!";
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
