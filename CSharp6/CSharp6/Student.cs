using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp6
{
    class Student : Person
    {
        public Student(
            string studentId,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            DateTime enrolmentDate) : base(firstName, lastName, dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(studentId))
            {
                throw new ArgumentNullException("studentId");
            }

            if (enrolmentDate <= dateOfBirth)
            {
                throw new ArgumentException("Wrong enrolment date", "enrolmentDate");
            }

            StudentId = studentId;
            EnrolmentDate = enrolmentDate;
        }

        public DateTime EnrolmentDate { get; private set; }

        public string StudentId { get; private set; }

        public IDictionary<string, Mark> Transcript { get; set; }

        public double GPA => Transcript?.Average(t => (int)t.Value) ?? 0.0;

        public override string ToString() => string.Format("{0}: {1}", StudentId, FullName);
    }
}
