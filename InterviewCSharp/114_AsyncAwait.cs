
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//Async/Await, vs Task/Wwit
//Asynchronous and Multi-threading concepts .

//https://www.dotnetperls.com/async


//C# program that uses async, await, Task
namespace TestCases
{
    class Program
    {
        public static async Task<int> HandleFileAsync()
        {            
            string file = @"C:\Users\Mars\source\myBranch\InterviewCSharp\InterviewQuestionsVisualCode\Files\enable1.txt";
            //Part 2: status messages and long-running calculations.
            Console.WriteLine("HandleFile enter");
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(file))
            {
                //await
                string v = await reader.ReadToEndAsync();

                Console.WriteLine(v);
                Console.ReadLine();

                // ... Process the file data somehow.
                count += v.Length;

                //Do something very slow
                int j = 0;
                foreach (char word in v)
                {
                    //Console.WriteLine(v.ToString());
                    Console.WriteLine("{0}: ___________________________________________", j);
                    for (int i = 0; i < 100000; i++)
                            if (j < 2000000000) j++;
                            else j = 0;
                            //Do nothing.
                }

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {

                    foreach (char word in v)
                    {
                        //Console.WriteLine(v.ToString());
                        Console.WriteLine("{0}: ___________________________________________", j);
                        for (int k = 0; k < 100000; k++)
                                if (j < 2000000000) j++;
                                else j = 0;
                                //Do nothing.
                    }

                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }

            Console.WriteLine("HandleFile exit");
            return count;
        }
    }


 
    public class asyncTaskDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" async Task Driver  ");

            Program sn = new Program();

            // Part 1: start the HandleFile method.
            Task<int> task = Program.HandleFileAsync();

            // Control returns here before HandleFileAsync returns.
            // ... Prompt the user.
            Console.WriteLine("Please wait patiently " +
                "while I do something important.");

            // Do something at the same time as the file is being read.
            string line = Console.ReadLine();
            Console.WriteLine("You entered (asynchronous logic): " + line);

            // Part 3: wait for the HandleFile task to complete.
            // ... Display its results.
            task.Wait();
            var x = task.Result;
            Console.WriteLine("Count: " + x);

            Console.WriteLine("[DONE]");
            Console.ReadLine();


            Console.ReadLine();             
        }
    }

}

