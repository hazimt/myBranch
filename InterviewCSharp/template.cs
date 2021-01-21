
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class testCaseXX
    {
        bool debug = false;        
        public int somefn()
        {

            return 1;
        }

    }
    
    public class ProblemToFixTemplate
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" ------------  ");

            testCaseXX sn = new testCaseXX();

            sn.somefn();

            Console.ReadLine();             
        }
    }

}

