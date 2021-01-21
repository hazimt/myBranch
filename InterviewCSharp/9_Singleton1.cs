using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Singleton1.cs == SingletonBasic.cs
//Basic Singleton No instance blocking, No threads
/// <summary>
/// First SingletonBasic version
/// </summary>

namespace TestCases  //SingletonBasicDemo
{
    //SingletonBasic.cs

    public class SingletonBasic
    {    
        private static int counter = 0;
        public SingletonBasic()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        public void printDetails(string message)
        {
            Console.WriteLine(message);
        }
    }


    //SingletonBasicDemo
    public class testCase9
    {
        public void SingletonBasicDemoCall()
        {
            Console.WriteLine("SingletonBasic Demo Call");
            
            //Step 1
            SingletonBasic s1 = new SingletonBasic();
            s1.printDetails("From S1");

            //Step 2
            SingletonBasic fromStudent =  new SingletonBasic();
            fromStudent.printDetails("from Student");

            //Step 3
            SingletonBasic fromEmploy =  new SingletonBasic();
            fromEmploy.printDetails("from Employee");

            Console.ReadLine();
        }
    }

}

