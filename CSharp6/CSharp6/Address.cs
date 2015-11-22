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

        public string Line1 { get; }

        public string Line2 { get; }
        
        public string City { get; }

        public string State { get; }

        public string ZipCode { get; }

        public override string ToString()
        {
            var address = Line1;
            if (!string.IsNullOrWhiteSpace(Line2))
            {
                address += Environment.NewLine + Line2;
            }

            return string.Format($@"{address}
{City}, {State} {ZipCode}");
        }
    }
}
