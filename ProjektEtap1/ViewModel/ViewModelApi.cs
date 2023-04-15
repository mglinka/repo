using Logika;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class ViewModelApi : INotifyPropertyChanged
    {
        public bool isStartEnabled { get; set; } = true;
        public bool isStopEnabled { get; set; } = false;
        public ICommand OnClickStartButton { get; set; }
        public ICommand OnClickStopButton { get; set; }
        public string inputNumber = "10";

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Kulka> kulki { get; set; } = new ObservableCollection<Kulka>();

        private ModelAbstractApi modelApi;

        public bool IsStartEnabled
        {
            get { return isStartEnabled; }
            set
            {
                isStartEnabled = value;
                OnPropertyChanged(nameof(isStartEnabled));
            }
        }

        public bool IsStopEnabled
        {
            get { return isStopEnabled; }
            set
            {
                isStopEnabled = value;
                OnPropertyChanged(nameof(isStopEnabled));
            }
        }

        public ViewModelApi()
        {
            System.Diagnostics.Trace.WriteLine("Konstruktor");
            OnClickStartButton = new RelayCommand(() => StartButtonHandle());
            OnClickStopButton = new RelayCommand(() => StopButtonHandle());
            modelApi = ModelAbstractApi.CreateApi();
        }

        public void StopButtonHandle()
        {
            modelApi.Stop();
            kulki.Clear();
            this.IsStartEnabled = true;
            this.IsStopEnabled = false;
        }

        public void StartButtonHandle()
        {
            System.Diagnostics.Trace.WriteLine("StartButtonCall");
            int value = getInputValue();
            if (value > 0)
            {
                this.IsStartEnabled = false;
                this.IsStopEnabled = true;
                for (int i = 0; i < value; i++)
                {
                    kulki.Add(modelApi.tworzKule());
                    System.Diagnostics.Trace.WriteLine("tworzKule");
                }
                OnPropertyChanged(nameof(kulki));
                modelApi.Start();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string InputNumber
        {
            get { return inputNumber; }
            set
            {
                inputNumber = value;
                OnPropertyChanged();
            }
        }

        public int getInputValue()
        {
            System.Diagnostics.Trace.WriteLine("GetInputValue");
            if (Int32.TryParse(InputNumber, out int value) && InputNumber != "0")
            {
                System.Diagnostics.Trace.WriteLine("Return " + Int32.Parse(InputNumber));
                return Int32.Parse(InputNumber);
            }

            return 0;
        }
    }
}
