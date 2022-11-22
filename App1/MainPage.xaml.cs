using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App1
{
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

            // Sets internal SelectedIndex to -1 if it wasn't -1.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));

            // Changing SelectedIndex here instead would avoid this bug.
            // SelectedIndex = 1;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndex)));
        }
    }
}
