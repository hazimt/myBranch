
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCases
{
    class waitClass
    {
        bool debug = false;        

        public void wait()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Sleep for 2 seconds.");
                //System.Threading.Thread.Sleep(Milliseconds);
                Thread.Sleep(2000);
            }

            Console.WriteLine("Main thread exits.");
        }
    }
   
    public class WaitDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");

            waitClass sn = new waitClass();

            sn.wait();

            Console.ReadLine();             
        }
    }

}

