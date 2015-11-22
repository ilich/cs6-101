using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp6
{
    class Student : Person
    {
        public Student(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            DateTime enrolmentDate) : base(firstName, lastName, dateOfBirth)
        {
            if (enrolmentDate <= dateOfBirth)
            {
                throw new ArgumentException("Wrong enrolment date", "enrolmentDate");
            }

            EnrolmentDate = enrolmentDate;
        }

        public DateTime EnrolmentDate { get; }

        public string StudentId => Guid.NewGuid().ToString();

        public IDictionary<string, Mark> Transcript { get; set; }

        public double GPA => Transcript?.Average(t => (int)t.Value) ?? 0.0;

        public override string ToString() => string.Format("{0}: {1}", StudentId, FullName);
    }
}
