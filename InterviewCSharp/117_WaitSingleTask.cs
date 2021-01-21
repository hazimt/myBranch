
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Need more Task/Wait examples.


//Async/Await gave many examples.
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
    class syncProgramEx1
    {     
        public void waitOnTask()
        {
            Task output = Task.Factory.StartNew(LongRunningOperation); 
            output.Wait(); 
            Console.WriteLine(output.Status);            
        }

        private static int LongRunningOperation()
        {
            Thread.Sleep(2000);
            return 2000;
        }
    }  


    public class syncTaskDriverSimpleEx1
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" 117_WaitSingleTask.cs  ");

            syncProgramEx1 sn = new syncProgramEx1();

            sn.waitOnTask();


            Console.ReadLine();             
        }
    }

}

