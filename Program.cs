using System;

namespace ConsoleBuffer
{
    class Program
    {
        static ConsoleBuffer Front;
        static ConsoleBuffer Back;
        static string TestText = "The quick brown fox jumped over the lazy dog and then started singing some anime OP nonsense.";
        static int Times = 10000000;

        static void Main(string[] args)
        {
            Console.WriteLine("test");
            Front = new ConsoleBuffer();
            Back = new ConsoleBuffer();

            TestWithoutBuffers();

            Console.Clear();

            TestWithBuffers();
            
        }

        static void TestWithoutBuffers() 
        {
            for (int i = 0; i < Times; i++) {
                Console.WriteLine(TestText);
            }
        }

        static void TestWithBuffers() 
        {
            DateTime start = DateTime.Now;
        }

        static void SwapBuffers()
        {
            Front.Copy(Back);
            ConsoleBuffer temp = Front;
            Front = Back;
            Back = temp;
        }
    }
}