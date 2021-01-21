
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Every world has its meaning
// S: is single responsibility principle (SRP) 
//    A class should take care of a Single Responsibility
   
// O: stands for open closed principle (OCP) 
//    Prefer extension over modification
   
// L: Liskov substitution principle (LSP)
//    The parent class should be able to refer child objects seamlessly during runtime polymorphism
     
// I: interface segregation principle (ISP)
//    A client should not be forced to use an interface, if it doesn’t need it 
   
// D: Dependency injection principle (DIP)
//    High level modules should not depend on low-level modules, but should depend on abstraction.

//https://www.google.com/search?q=c%23+solid+principles&oq=c%23+solid+prin&aqs=chrome.0.0i457j69i57j0j0i22i30l3j0i10i22i30j69i58.2912j0j4&sourceid=chrome&ie=UTF-8


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCases
{
    class SolidClass
    {
        bool debug = false;        

        public void SolidEx1()
        {


        }
    }
   
    public class SOLIDDriverS
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");

            linqClass sn = new linqClass();

            sn.linqEx1();

            Console.ReadLine();             
        }
    }

}

