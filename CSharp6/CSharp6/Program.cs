using System;
using System.Collections.Generic;
using static System.Console;

namespace CSharp6
{
    class Program
    {
        public static void Main()
        {
            var student = new Student("1", "John", "Smith", new DateTime(1990, 1, 1), new DateTime(2015, 1, 1));
            WriteLine(student);
            WriteLine(student.Address?.ToString());

            student.Address = new Address("9049 Main St", "Maple Grove", "MN", "55311", "Apt. 10");
            WriteLine("Address: ");
            WriteLine("----------------------------");
            WriteLine(student.Address?.ToString());
            WriteLine("----------------------------");
            WriteLine();

            WriteLine("GPA (no transcript): {0}", student.GPA);

            student.Transcript = LoadTranscript();
            WriteLine("GPA: {0}", student.GPA);
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
