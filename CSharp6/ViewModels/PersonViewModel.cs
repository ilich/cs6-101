using System.ComponentModel;

namespace CSharp6.ViewModels
{
    class PersonViewModel : INotifyPropertyChanged
    {
        private string firstName;

        private string lastName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                // Old way of doing PropertyChanged notification
                if (value != firstName)
                {
                    firstName = value;

                    var handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs("FirstName"));
                    }
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                // C# 6.0 way of doing PropertyChanged notification
                if (value != lastName)
                {
                    lastName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                }
            }
        }
    }
}
