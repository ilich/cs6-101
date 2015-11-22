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
            DateTime enrolmentDate,
            Address address = null) : base(firstName, lastName, dateOfBirth, address)
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

        public double GPA
        {
            // Cannot use expression-bodied member here because there are few statements here
            get
            {
                if (Transcript == null)
                {
                    return 0;
                }

                return Transcript.Average(t => (int)t.Value);
            }
        }

        public override string ToString() => string.Format("{0}: {1}", StudentId, FullName);
    }
}
