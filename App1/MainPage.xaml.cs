using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> Items { get; set; } = new List<string>() { "Test1", "Test2" };
        public int SelectedIndex { get; set; } = 1;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Replace Items, keeping everything default.
            Items = new List<string>() { "Test1", "Test2" };
            SelectedIndex = 1;

            // Sets SelectedIndex to -1 if it wasn't -1. Otherwise the new SelectedIndex is untouched.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));

            // Changing SelectedIndex here instead would avoid this bug.
            // SelectedIndex = 1;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndex)));
        }
    }
}
