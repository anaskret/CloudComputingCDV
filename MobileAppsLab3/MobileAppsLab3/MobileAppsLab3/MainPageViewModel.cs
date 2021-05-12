using MobileAppsLab3.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobileAppsLab3
{
    public class MainPageViewModel: INotifyPropertyChanged
    {

        private string _firstNameEntryText;
        private string _lastNameEntryText;
        private string _phoneNumberEntryText;
        private Person _person;

        public Person PersonModel { 
            get
            {
                return _person;
            }
            set 
            {
                _person = value;
                OnPropertyChanged();
            }}

        public MainPageViewModel()
        {

        }

        public string FirstNameEntryText //Property we will bind our Entry Text to so we can pass it as a parameter to our MainPage view.
        {
            get => _firstNameEntryText;
            set
            {
                _firstNameEntryText = value;
            }

        }

        public string LastNameEntryText //Property we will bind our Entry Text to so we can pass it as a parameter to our MainPage view.
        {
            get => _lastNameEntryText;
            set
            {
                _lastNameEntryText = value;
            }

        }

        public string PhoneNumberEntryText //Property we will bind our Entry Text to so we can pass it as a parameter to our MainPage view.
        {
            get => _phoneNumberEntryText;
            set
            {
                _phoneNumberEntryText = value;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
