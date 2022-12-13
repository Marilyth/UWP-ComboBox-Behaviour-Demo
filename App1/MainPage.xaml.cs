using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App1
{
    public sealed partial class MainPage : Page 
    { 
        public ObservableCollection<Test> Items { get; set; } = new ObservableCollection<Test>() { new Test(), new Test() };

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Bug only triggers when items are removed.
            // Remove this line and it doesn't happen anymore.
            Items.RemoveAt(0);

            // It happens also after a delay. But the pattern changes slightly.
            //await Task.Delay(200);

            // The first n new items after n removals on an ObservableCollection have a chance to be set to null.
            // When and how often it happens is correlated to the amount of items in the collection at the time of removal.
            Items.Add(new Test());

            // It follows a pattern, e.g. 1 removed and 1 inserted per step:
            // Test1, null, null, null, Test1, Test1, Test1, null, null, null, ...
        }
    }

    public class Test : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<string> Options { get; set; } = new List<string>() { "Test1", "Test2" };

        private string _SelectedItem = "Test1";
        public string SelectedItem { 
            get { 
                return _SelectedItem; 
            } 
            set {
                if (_SelectedItem != value)
                {
                    _SelectedItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                }
            } 
        }
    }
}
