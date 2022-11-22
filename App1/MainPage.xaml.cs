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
        public ComboboxViewModel ComboboxViewModel { get; set; } = new ComboboxViewModel();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Replace ComboboxViewModel, keeping everything default.
            ComboboxViewModel = new ComboboxViewModel();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComboboxViewModel)));
        }
    }

    public class ComboboxViewModel
    {
        // This should always be 0. But it switches between -1 and 0 instead for every replacement.
        public int SelectedIndex { get; set; } = 0;

        // Hardcoding the Items into the .xaml doesn't trigger this bug.
        public List<string> Items = new List<string>() { "Test1", "Test2" };
    }
}
