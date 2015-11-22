using System;

namespace CSharp6
{
    class Person
    {
        private const int MinAge = 18;

        public Person(
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            Address address = null)
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
            Address = address;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        public DateTime DateOfBirth { get; private set; }

        public Address Address { get; set; }

        public override string ToString()
        {
            return FullName;
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
