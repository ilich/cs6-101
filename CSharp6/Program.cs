using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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

            try
            {
                // student.Transcript = LoadTranscript();
                student.Transcript = LoadTranscriptWithException();
                WriteLine($"GPA: {student.GPA:0.00}");
            }
            catch(Exception err) when(!Debugger.IsAttached)
            {
                WriteLine($"Error: {err.Message}");
                WriteLine($"Stack Trace:\n{err.StackTrace}");
                WriteLine("FAIL!");
            }
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

        private static int _fails;

        private static IDictionary<string, Mark> LoadTranscriptWithException()
        {
            _fails = 0;
            while (true)
            {
                try
                {
                    WriteLine("Loadin transcript...");
                    throw new Exception("Cannot load transcript");
                }
                catch (Exception err) when (_fails > 10)
                {
                    WriteLine(err.Message);
                    throw;
                }
                catch (Exception)
                {
                    _fails++;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
