using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Bingo_buddy
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<int> availableNumbers = new ObservableCollection<int>();
        private ObservableCollection<int> pickedNumbers = new ObservableCollection<int>();
        private Random random = new Random();

        private int _currentNumber;
        public int CurrentNumber
        {
            get => _currentNumber;
            set
            {
                _currentNumber = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
         
            for (int i = 1; i <= 90; i++)
            {
                availableNumbers.Add(i);
            }

            ListBox1.ItemsSource = availableNumbers;
            ListBox2.ItemsSource = pickedNumbers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (availableNumbers.Count == 0)
            {
                MessageBox.Show("All numbers have been picked!");
                return;
            }

            int index = random.Next(availableNumbers.Count);
            int pickedNumber = availableNumbers[index];
            CurrentNumber = pickedNumber;

            Label.Content = CurrentNumber;

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
