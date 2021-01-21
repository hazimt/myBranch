/*
Print Fibonacci Series in reverse order

Input : n = 5
Output : 3 2 1 1 0

Input : n = 8
Output : 13 8 5 3 2 1 1 0

1) Declare an array of size n.
2) Initialize a[0] and a[1] to 0 and 1 respectively.
3) Run a loop from 2 to n-1 and store
sum of a[i-2] and a[i-1] in a[i].
4) Print the array in the reverse order.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class fibNoReverse
    {
        int n;

        public fibNoReverse(int x)
        {
            n = x;
        }

        public void reverseFibonacci(int x)
        {
            n = x;
            int[]a = new int[n];

            a[0] = 0;
            a[1] = 1;

            //Generate the Fib array
            for (int i = 2; i < n; i++)
            {
                // storing sum in the 
                // preceding location                 
                a[i] = a[i-2] + a[i-1];
            }

            Console.WriteLine("n = "+ n);
            //print Fib array in reverse
            for (int i = n-1; i >= 0; i--)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
    
    public class testCase16
    {

        //Driver Function
        public void  driverCall()
        {
            int x = 5;
            fibNoReverse a = new fibNoReverse(x);
            //n = 5 means 5 fib nos.  Not the digit 5
            a.reverseFibonacci(5);    

            Console.WriteLine();
            a.reverseFibonacci(8);
            Console.ReadLine();
        }
    }

}

