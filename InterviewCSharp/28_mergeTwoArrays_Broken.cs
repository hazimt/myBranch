using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class testCase28
    {

        bool debug = false;

        public int somefn()
        {

            return 1;
        }

    }
    
    public class mergeToArrays
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine("28_mergeTwoArrays.cs");
            
            int[] A = {1,5,7,12,18,32};
            int[] B = {2,4,9,16,27,76,98};       

            testCase28 sn = new testCase28();
            //sn.somefn(int array A, int array B);


            Console.ReadLine();
        }
    }

}

