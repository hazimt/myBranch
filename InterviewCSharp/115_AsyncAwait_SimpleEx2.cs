
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//Async/Await
//https://www.c-sharpcorner.com/article/async-and-await-in-c-sharp/




//https://www.google.com/search?q=c%23%20What%20is%20the%20difference%20between%20async%20await%20and%20Taske%20wait
//https://stiller.blog/2012/12/task-wait-vs-await/

//Wait and await - while similar conceptually - are actually completely different. 
//Wait will synchronously block until the task completes. ...

//await will asynchronously wait until the task completes. 
//This means the current method is "paused" (its state is captured) and the method returns an incomplete task to its caller

//Async/Await, vs Task/Wait
//Asynchronous and Multi-threading concepts.


//C# program that uses async, await, Task
namespace TestCases
{
    class asyncProgramEx2
    {     

        public static async void callMethod()  
        {  
            /*
                This is just part of how async/await works.

                Any method declared as async has to have a return type of:

                * void (avoid if possible)
                * Task (no result beyond notification of completion/failure)
                * Task<T> (for a logical result of type T in an async manner)
            */

            Task<int> task = Method1();  
            Method2();  
            int count = await task;  
            Method3(count);  
        }  

        public static async Task<int> Method1()  
        {  
            int count = 0;
            await Task.Run(() =>  
            {  
                for (int i = 0; i < 100; i++)  
                {  
                    Console.WriteLine("{0}: Method 1", i);  
                    count += 1;
                }  
            });
            return count;
        }  
    
    
        public static void Method2()  
        {  
            for (int i = 0; i < 25; i++)  
            {  
                Console.WriteLine("{0}: Method 2", i);  
            }  
        }  

        public static void Method3(int count)  
        {  
            Console.WriteLine("Method3: Total count is " + count);  
        } 

    }  


    public class asyncTaskDriverSimpleEx2
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" 114_AsyncAwait_TaskWait_SimpleEx2.cs  ");

            asyncProgramEx2 sn = new asyncProgramEx2();

            asyncProgramEx2.callMethod();  


            Console.ReadLine();             
        }
    }

}

