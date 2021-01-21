//https://github.com/Microsoft/azure-repos-vscode/blob/master/TFVC_README.md#quick-start

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {

            int tcNo;
            int tcCounter;

            if (args.Length > 2)
            {
                Console.WriteLine("Pls enter two values.");
                tcNo = Int32.Parse(args[0]);
                //tcNo = Convert.ToInt32((args[0]);
                tcCounter = Int32.Parse(args[1]);
            }

            foreach (string arg in args)
                Console.WriteLine(arg);

            tcNo = 1;
            tcCounter = 1;

            //Read from Console
            /*
            Console.WriteLine("Enter tcNo:");
            tcNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter tcCounter:");
            tcCounter = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Read the values");
            */
            
            //Start the program
            Console.WriteLine("Programs: Hello World!");

            Thread.Sleep(1000);
            Console.WriteLine("Done");

            TestCases.testCall tc1 = new TestCases.testCall(tcNo, tcCounter);
        }
    }
}
