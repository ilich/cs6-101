using System;
using System.Collections.Generic;

namespace CSharp6
{
    class Program
    {
        public static void Main()
        {
            var student = new Student("1", "John", "Smith", new DateTime(1990, 1, 1), new DateTime(2015, 1, 1));
            Console.WriteLine(student);
            if (student.Address != null)
            {
                Console.WriteLine(student.Address);
            }

            student.Address = new Address("9049 Main St", "Maple Grove", "MN", "55311", "Apt. 10");
            Console.WriteLine("Address: ");
            Console.WriteLine("----------------------------");
            if (student.Address != null)
            {
                Console.WriteLine(student.Address);
            }

            Console.WriteLine("----------------------------");

            Console.WriteLine("GPA (no transcript): {0}", student.GPA);

            student.Transcript = LoadTranscript();
            Console.WriteLine("GPA: {0}", student.GPA);
        }

        private static IDictionary<string, Mark> LoadTranscript()
        {
            var transcript = new Dictionary<string, Mark>();
            transcript.Add("Math", Mark.A);
            transcript.Add("Science", Mark.B);
            transcript.Add("Art", Mark.C);
            transcript.Add("Programming", Mark.A);

            return transcript;
        }
    }
}
