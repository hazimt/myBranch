//https://www.youtube.com/watch?v=YGGg9ecy0K4&list=PL6n9fhu94yhUbctIoxoVTrklN3LMwTCmd&index=2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Singleton2 == SingletonOneInstanceNoThread.cs
//Protection against muliple instances, No threads

/// <summary>
/// First SingletonOneInstanceNoThread version
/// </summary>

namespace TestCases  //SingletonOneInstanceNoThreadDemo
{
    /*
     *  Sealed restricts the inheritance
     *  and prevents nested classes from multiple instantiation of the singleton class
     */

     //sealed: means no one can inherit from Singleton3 because it's sealed.
     //However due to the constructor being private the inherting class is blocked 
     //from instantiating a new instance of the Singleton class.
     //However there is something called nested classes in C#.  i.e you can put:
     // class public Singleton
     //{
     //     ............
     //
     //    public class DerivedSingleton : Singleton
     //     {
     //         
    //      }
    //}  

    public sealed class SingletonOneInstanceNoThread
    {
        //To Find out if several obj are crated create two things: Counter, a constructor 
        private static int counter = 0;

        //Restrict the multiple instance creation
        //1. All constructors private --> 1.1 This will cause inaccssible due to protection level. -->
        // 1.2 Create a public field/Constructor.
        // 1.3 Create a new private 
        
        //1.3 Create a new private field to prevent multiple instances.  
        private static SingletonOneInstanceNoThread instance = null;
        //2. change the class to a Sealed class so it can't be inhertied.
        //1.2 This will indirectly give access to the private constrctor. 
        public static SingletonOneInstanceNoThread GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonOneInstanceNoThread();
                return instance;
            }
        }

        private SingletonOneInstanceNoThread()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
    
        public void printDetails(string message)
        {
            Console.WriteLine(message);
        }
    }


    //SingletonOneInstanceNoThreadDemo
    public class testCase10
    {
        public void SingletonOneInstanceNoThreadDemoCall()
        {
            Console.WriteLine("SingletonOneInstanceNoThread Demo Call");
            
            //Step 1
            SingletonOneInstanceNoThread s1 = SingletonOneInstanceNoThread.GetInstance;
            s1.printDetails("From S1");

            //Step 2
            SingletonOneInstanceNoThread fromStudent = SingletonOneInstanceNoThread.GetInstance;
            fromStudent.printDetails("from Student");

            //Step 3
            SingletonOneInstanceNoThread fromEmploy = SingletonOneInstanceNoThread.GetInstance;
            fromEmploy.printDetails("from Employee");

            Console.ReadLine();
        }
    }

}

