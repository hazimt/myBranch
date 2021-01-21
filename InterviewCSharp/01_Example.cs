
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class testCase00
    {
        public int somefn()
        { 
            int total = 5;
            int k = 3;

            int [] p = new int[total];
            int i = 0;
            int remainder = total; 

            while (remainder > 0)
            {
                p[i++] = k;
                //initally remainder = total 
                remainder = remainder - k;
                if (remainder < k)
                    k = remainder;
            }
            i--;

            while(true)
            {
                
            }

            return 1;
        }

    }
    
    public class example
    {
        //Driver Function
        public void  driverCall()
        {
            testCase00 sn = new testCase00();

            sn.somefn();

            Console.ReadLine();             
        }
    }

}

