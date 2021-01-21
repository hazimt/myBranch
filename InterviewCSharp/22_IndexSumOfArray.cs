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
    public class sumEqualsAgivenNumber
    {
        public List<int> sumEqualsAgivenNumberEx1()
        {
            //From John Gibbs to Everyone:  02:59 PM
            //Given a list of integers and a target value, find the indexes of the first two numbers in the list whose sum equals the target value.

            //int[]     numList = new int[]     { 1, 3, 5, 7, 9 };
            //int       target  = 8;

            //int[] numList = new int[] { 1, 5, 7, 2, 9, 8, 4, 3, 6 }; // given array
            int[] numList = new int[] { 1, 3, 5, 7, 9 }; // given array

            List<int> numlistIndex = new List<int>();

            int target = 8;
            int i; 

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("The Pairs");
            for (i = 0; i <= numList.Count() - 1; i++)
                if (numList.Contains(target - numList[i]))
                //liqpad
                {
                    Console.WriteLine("{0}, {1}", numList[i], target - numList[i]);
                    //Console.WriteLine("{0}, {1}", i, target - numList[i]);
                }

            return numlistIndex;
        }

        public List<int> sumEqualsAgivenNumberEx2()
        {
            int[] numList = new int[] { 1, 3, 5, 7, 9 }; // given array

            List<int> numlistIndex = new List<int>();

            int target = 8;
            int i; 

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("The pair Index");
            int k = -1;
            for (i = 0; i <= numList.Count() - 1; i++)
            {
                k = Array.IndexOf(numList, target - numList[i]);
                Console.WriteLine("Outside: {0}, {1}", i, k);
                if (k != -1)
                {
                    numlistIndex.Add(i);
                    numlistIndex.Add(k);
                    Console.WriteLine("Inside: {0}, {1}", i, k);
                    Console.WriteLine("Inside: {0}, {1}", numList[i], numList[k]);
                    return numlistIndex; 
                }
            }

            return numlistIndex;
        }

    }
    
    public class testCase22
    {
        //Driver Function
        public void  driverCall()
        {
            sumEqualsAgivenNumber sn = new sumEqualsAgivenNumber();

            sn.sumEqualsAgivenNumberEx1();
            sn.sumEqualsAgivenNumberEx2();

            Console.ReadLine();             
        }
    }

}

