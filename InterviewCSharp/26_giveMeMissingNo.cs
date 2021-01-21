//
//Input: [4, 1, 5, 3] (unsorted, progressive array)
//Output: 2

//sum of all numbers in a progression = n*(n+1)/2, where n is the highest number in the series

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class TestCases26
    {
        public int giveMeMissingNo(int [] a, int n)
        {
            //1,2,3,4,5 = 15 == 4
            //1,2,4,5 = 12 == 3
            int total = n*(n+1)/2;
            
            for (int i=0; i<n-1; i++)
                total -= a[i];
            
            return total;
        }
    }
    
    public class giveMeMissingValue
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine("26_giveMeMissingValue");

            TestCases26 sn = new TestCases26();

            Console.WriteLine("Hello World");
            
            int [] a = {1, 2, 4, 5};
            
            int missing = sn.giveMeMissingNo(a, 5);
            Console.WriteLine(missing);		

            Console.ReadLine();             
        }
    }

}

