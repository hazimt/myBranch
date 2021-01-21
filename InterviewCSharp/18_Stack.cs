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
    public class myStack
    {
        public void stackEx()
        {
            // An example string array.
            string[] values = { "Dot", "Net", "Perls" };

            Console.Write("Array values = ");
            foreach (string item in values)
                Console.Write(item + " ");
            Console.WriteLine();

            // Copy an array into a Stack.
            var stack = new Stack<string>(values);

            // Display the Stack.
            Console.WriteLine("--- Stack contents ---");
            foreach (string value in stack)
            {
                Console.WriteLine(value);
            }

            // See if the stack contains "Perls"
            Console.WriteLine("--- Stack Contains Perls result ---");
            bool contains = stack.Contains("Perls");
            Console.WriteLine(contains);
        }
    } 

    public class testCase18
    {
        //Driver Function
        public void driverCall()
        {
            myStack mys = new myStack();

            mys.stackEx();
            
            Console.ReadLine();             
        }
    }
}

