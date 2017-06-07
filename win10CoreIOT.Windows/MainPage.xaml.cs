﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace win10CoreIOT.Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Wv1.Navigate(new Uri("http://www.cnn.com"));
        }

        private void Address_LostFocus(object sender, RoutedEventArgs e)
        {

            Wv1.Navigate(new Uri(Address.Text));
        }
    }
}
