//https://www.youtube.com/watch?v=QWrcOmLWi_Q&list=PL6n9fhu94yhUbctIoxoVTrklN3LMwTCmd&index=4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Singleton3 == SingletonOneInstanceThread.cs
//Protection against muliple instances, threads

/// <summary>
/// First Singleton3 version
/// </summary>

namespace TestCases  //Singleton3Demo
{
    //Singleton3.cs
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

    //https://www.youtube.com/watch?v=LypTOnfkfvA&list=PL6n9fhu94yhUbctIoxoVTrklN3LMwTCmd&index=3
    //Sealed
    public sealed class Singleton3
    {
        //To Find out if several obj are crated create two things: Counter, a constructor 
        private static int counter = 0;

        //Restrict the multiple instance creation
        //1. All constructors private --> 1.1 This will cause inaccssible due to protection level. -->
        // 1.2 Create a public field/Constructor.
        // 1.3 Create a new private 

        //add obj to address locking "lock" is costly so let's avoid entering lock unless it's needed.
        private static readonly object obj = new object();
        //this will prevent the singleton from generating more than one instance

        //1.3 Create a new private field to prevent multiple instances.  
        private static Singleton3 instance = null;
        //2. change the class to a Sealed class so it can't be inhertied.
        //1.2 This will indirectly give access to the private constrctor. 
        public static Singleton3 GetInstance
        {
            get
            {
                //Avoid the run time to enter the lock scope only when the instance is null.
                //This refered to as double check locking.
                if (instance == null)       
                {
                    //Will guarantee that only one thread will enter at a time.
                    //Locks are expensive to use.
                    lock(obj)  //this will prevent the singleton from generating more than one instance
                    {
                        if (instance == null)
                            instance = new Singleton3();
                    }
                }
                return instance;
            }
        }

        private Singleton3()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
    
        public void printDetails(string message)
        {
            Console.WriteLine(message);
        }
    }


    //Singleton3Demo
    public class testCase11
    {
        public void Singleton3DemoCall()
        {
            Console.WriteLine("Singleton3 Demo Call");

            //This way you can run both methods at the same time in parallel.
            //Invoke passes the methods as actions.
            Parallel.Invoke(
                //()=> lampda expression to invoke the lampda expression/function action.
                ()=>printStudDetails(),
                ()=>printEmpDetails()
            );

            printS1Details();

            printStudDetails();

            printEmpDetails();

            Console.ReadLine();
        }

        private static void printS1Details()
        {
            //Step 1
            Singleton3 s1 = Singleton3.GetInstance;
            s1.printDetails("From S1");
        }
        private static void printStudDetails()
        {
            //Step 2
            Singleton3 fromStudent = Singleton3.GetInstance;
            fromStudent.printDetails("from Student");            
        }
        private static void printEmpDetails()
        {
            //Step 3
            Singleton3 fromEmploy = Singleton3.GetInstance;
            fromEmploy.printDetails("from Employee");
        }

    }

}

