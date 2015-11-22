using System;
using System.Collections.Generic;
using static System.Console;

namespace CSharp6
{
    class Program
    {
        public static void Main()
        {
            var student = new Student("John", "Smith", new DateTime(1990, 1, 1), new DateTime(2015, 1, 1));
            WriteLine(student);
            WriteLine(student.Location?.Home?.ToString());

            var address = new Address("9049 Main St", "Maple Grove", "MN", "55311", "Apt. 10");
            student.SetHomeAddress(address);

            WriteLine("Address: ");
            WriteLine("----------------------------");
            WriteLine(student.Location?.Home?.ToString());
            WriteLine("----------------------------");
            WriteLine();

            WriteLine($"GPA (no transcript): {student.GPA:0.00}");

            student.Transcript = LoadTranscript();
            WriteLine($"GPA: {student.GPA:0.00}");
        }

        private static IDictionary<string, Mark> LoadTranscript()
        {
            var transcript = new Dictionary<string, Mark>()
            {
                ["Math"] = Mark.A,
                ["Science"] = Mark.B,
                ["Art"] = Mark.C,
                ["Programming"] = Mark.A
            };

            return transcript;
        }
    }
}
