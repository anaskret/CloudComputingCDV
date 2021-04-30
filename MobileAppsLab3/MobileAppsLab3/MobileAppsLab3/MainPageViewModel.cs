using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileAppsLab3
{
    public class MainPageViewModel: INotifyPropertyChanged
    {

        private string _firstNameEntryText;
        private string _lastNameEntryText;
        private string _phoneNumberEntryText;

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
