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
        public ICommand OnClickStartButton { get; set; }
        public ICommand OnUpButton { get; set; }
        public ICommand OnDownButton { get; set; }

        public string inputNumber;

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<ModelKulka> kulki { get; set; } = new ObservableCollection<ModelKulka>();

        private ModelAbstractApi modelApi;

        public bool IsStartEnabled
        {
            get { return isStartEnabled; }
            set
            {
                isStartEnabled = value;
                OnPropertyChanged();
            }
        }

        public ViewModelApi()
        {
            OnClickStartButton = new RelayCommand(() => StartButtonHandle());
            OnUpButton = new RelayCommand(() => UpButtonHandle());
            OnDownButton = new RelayCommand(() => DownButtonHandle());
            modelApi = ModelAbstractApi.CreateApi();
            inputNumber = "5";
        }

        public void StartButtonHandle()
        {
            int value = getInputValue();
            
            if (value > 0)
            {
                OnPropertyChanged(nameof(kulki));
                modelApi.Start(value);
                for (int i = 0; i < value; i++)
                {
                    kulki.Add(modelApi.GetKulka(i));
                }
                //kulki.Add(modelApi.GetKulka(1));
                IsStartEnabled = false;
            }
            
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //System.Diagnostics.Trace.WriteLine("Property changed");
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string InputNumber
        {
            get { return inputNumber; }
            set
            {
                if (Int32.Parse(value) < 6 && Int32.Parse(value) > 0)
                    inputNumber = value;
                OnPropertyChanged();
            }
        }

        public int getInputValue()
        {
            if (Int32.TryParse(InputNumber, out int value) && InputNumber != "0")
            {
                return Int32.Parse(InputNumber);
            }

            return 0;
        }

        public void UpButtonHandle()
        {
            InputNumber = (getInputValue() + 1).ToString();
            //inputNumber = (getInputValue() + 1).ToString();
        }

        public void DownButtonHandle()
        {
            InputNumber = (getInputValue() - 1).ToString();
            //inputNumber = (getInputValue() + 1).ToString();
        }
    }
}
