using System;

namespace CSharp6
{
    class Address
    {
        public Address(
            string line1,
            string city,
            string state,
            string zipCode,
            string line2 = null)
        {
            if (string.IsNullOrWhiteSpace(line1))
            {
                throw new ArgumentNullException("line1");
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentNullException("city");
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ArgumentNullException("state");
            }

            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ArgumentNullException("zipCode");
            }

            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Line1 { get; private set; }

        public string Line2 { get; private set; }
        
        public string City { get; private set; }

        public string State { get; private set; }

        public string ZipCode { get; private set; }

        public override string ToString()
        {
            var address = Line1;
            if (!string.IsNullOrWhiteSpace(Line2))
            {
                address += Environment.NewLine + Line2;
            }

            return string.Format(@"{0}
{1}, {2} {3}", address, City, State, ZipCode);
        }
    }
}
