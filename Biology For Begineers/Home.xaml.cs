using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
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

namespace Biology_For_Begineers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
        }

        private void tappedContent(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            
            if (args.SelectedItem is NavigationViewItem btnItem)
            {
                string menuItem = (string)btnItem.Content;
                switch (menuItem)
                {
                    case "Mammals":
                        Frame.Navigate(typeof(MammalsPage));
                        break;
                    case "Birds":
                        Frame.Navigate(typeof(BirdsPage1));
                        break;
                    case "Reptiles":
                        Frame.Navigate(typeof(ReptilesPage));
                        break;
                    case "Marine":
                        Frame.Navigate(typeof(MarinePage));
                        break;
                }
            }
        }
    }
}
