using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Bingo_buddy
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        // This is the collection of availableNUmbers 
        private ObservableCollection<int> availableNumbers = new ObservableCollection<int>();
        //This is a collection of Pickednumbers
        private ObservableCollection<int> pickedNumbers = new ObservableCollection<int>();
        
        
        private Random random = new Random();

        //Here is the the property for current number (i don't even know why i bother comment this but i'll do it anyway)
        private int _currentNumber;
        public int CurrentNumber
        {
            get => _currentNumber;
            set
            {
                _currentNumber = value;
                //OnPropertyChanged will keep an eye _currentNumber and it will change it the when clicked. 
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            //The default picked number is 90
            for (int i = 1; i <= 90; i++)
            {
                availableNumbers.Add(i);
            }
            

            //
            ListBox1.ItemsSource = availableNumbers;
            ListBox2.ItemsSource = pickedNumbers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //When all the numbers have been picked 
            if (availableNumbers.Count == 0)
            {
            //it will return this
                MessageBox.Show("All numbers have been picked!");
                return;
            }

            //this is randomizing the numbers
            int index = random.Next(availableNumbers.Count);
            int pickedNumber = availableNumbers[index];
            CurrentNumber = pickedNumber;

            Label.Content = CurrentNumber;

            //Every time the "tryk her" button is clicked it will add to 'pickedNumber"
            pickedNumbers.Add(pickedNumber);
            availableNumbers.RemoveAt(index);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
