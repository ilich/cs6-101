using System;
using System.IO;
using System.Threading.Tasks;

namespace CSharp6.Exceptions
{
    class AsyncExceptionHandlerSample
    {
        public async void Run()
        {
            using (var file = File.OpenWrite("Test.txt"))
            using (var writer = new StreamWriter(file))
            {
                try
                {
                    await WriteToFile(writer);
                }
                catch(Exception err)
                {
                    await writer.WriteLineAsync($"Error: {err.Message}");
                }
                
            }
        }

        private async Task WriteToFile(StreamWriter writer)
        {
            throw new InvalidOperationException("Operation failed");
            // await writer.WriteLineAsync("Hello C# 6.0");
        }
    }
}
