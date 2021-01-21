/*
Print Fibonacci Series in reverse order

Input : n = 5
Output : 3 2 1 1 0

Input : n = 8
Output : 13 8 5 3 2 1 1 0

1) Declare an array of size n.
2) Initialize a[0] and a[1] to 0 and 1 respectively.
3) Run a loop from 2 to n-1 and store
sum of a[i-2] and a[i-1] in a[i].
4) Print the array in the reverse order.
*/

//https://stackoverflow.com/questions/42000798/how-do-i-add-assembly-references-in-visual-studio-code/42399545#42399545
//https://www.nuget.org/packages/System.Drawing.Common/
//add a nuget or a reference 
//From a terminal (cmd) windows type:
//dotnet add package System.Drawing  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Threading;
using System.Drawing;


namespace TestCases
{
    public class parrallelProgramming
    {
        public void parrallelProgrammingEx1()
        {

            //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-simple-parallel-foreach-loop#example

            // A simple source for demonstration purposes. Modify this path as necessary.
            //string[] files = Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg");
            //string newDir = @"C:\Users\Public\Pictures\Sample Pictures\Modified";
            string[] files = Directory.GetFiles(@"C:\Users\Mars\Pictures\Feedback", "*.jpg");
            string newDir = @"C:\Users\Mars\Pictures\Modified";
            
            Directory.CreateDirectory(newDir);

            // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
            Parallel.ForEach(files, (currentFile) => 
                                    {
                                        //C:\Users\Mars\source\myBranch\InterviewCSharp\InterviewQuestionsVisualCode\obj
                                        //C:\Program Files\Microsoft SDKs\Azure\.NET SDK\v2.9\packages
                                        //C:\Program Files (x86)\Microsoft Visual Studio\Shared\Packages
                                        //C:\Users\Mars\Downloads\system.drawing.common.4.7.0.nupkg
                                        //C:\Users\Mars\AppData\Local\AzureFunctionsTools\Releases\1.4.0\cli

                                        // The more computational work you do here, the greater 
                                        // the speedup compared to a sequential foreach loop.
                                        string filename = Path.GetFileName(currentFile);
                                        //var bitmap = new Bitmap(currentFile);

                                        //bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                        //bitmap.Save(Path.Combine(newDir, filename));
                                        //File

                                        // Peek behind the scenes to see how work is parallelized.
                                        // But be aware: Thread contention for the Console slows down parallel loops!!!

                                        Console.WriteLine($"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}");
                                        //close lambda expression and method invocation
                                    });

            // Keep the console window open in debug mode.
            Console.WriteLine("Processing complete. Press any key to exit.");
            Console.ReadKey();
        }

    }


    public class testCase21
    {
        //Driver Function
        public void  driverCall()
        {
            parrallelProgramming sn = new parrallelProgramming();

            sn.parrallelProgrammingEx1();

            Console.ReadLine();             
        }
    }

}

