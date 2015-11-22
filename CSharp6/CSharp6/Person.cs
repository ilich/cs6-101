using System;

namespace CSharp6
{
    class Person
    {
        private const int MinAge = 18;

        public Person(
            string firstName, 
            string lastName, 
            DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException("firstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException("lastName");
            }

            var age = Age(dateOfBirth);
            if (age < MinAge)
            {
                throw new ArgumentException("Person should be 18 years old or elder.", "dateOfBirth");
            }

            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime DateOfBirth { get; }

        public Location Location { get; private set; }

        public override string ToString() => FullName;

        public void SetHomeAddress(Address address)
        {
            if (Location == null)
            {
                Location = new Location();
            }

            Location.Home = address;
        }

        public void SetWorkAddress(Address address)
        {
            if (Location == null)
            {
                Location = new Location();
            }

            Location.Work = address;
        }

        private int Age(DateTime birthday)
        {
            var now = DateTime.Now;
            var age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
