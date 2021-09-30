using Calculator.Commands;
using System;
using System.Windows.Input;

namespace Calculator.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        public ICommand AddNumberCommand { get; set; }

        public int MaxScreenLenght { get; set; }

        private string _currentValue = "0";
        public string CurrentValue
        {
            get => _currentValue;
            set
            {
                if (value != _currentValue)
                {
                    _currentValue = value;
                    OnPropertyChanged(nameof(CurrentValue));
                }
            }
        }

        public CalculatorViewModel()
        {
            InitCommands();
        }

        public CalculatorViewModel(int maxScreenLength)
        {
            MaxScreenLenght = maxScreenLength;
            InitCommands();
        }

        private void InitCommands()
        {
            AddNumberCommand = new RelayCommand(AddNumber);
        }

        private void AddNumber(object sender)
        {
            if (sender is null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            var number = sender as string;

            if (number is null)
            {
                throw new ArgumentException("Sender is not of type string", nameof(sender));
            }

            if (CurrentValue.Length + 1 > MaxScreenLenght)
            {
                return;
            }

            if (CurrentValue == "0")
            {
                CurrentValue = number;
                return;
            }

            CurrentValue += number;
        }
    }
}
