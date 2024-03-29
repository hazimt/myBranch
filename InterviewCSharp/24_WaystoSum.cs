/*
Ways to Sum
An automated packaging system is responsible for packing boxes. A box is certified to hold a certain weight. Given an integer total, calculate the number of possible ways to achieve total as a sum of the weights of items weighing integer weights from 1 to k, inclusive.

Example

total = 8

k = 2

To reach a weight of 8, there are 5 different ways that items with weights between 1 and 2 can be combined:

[1, 1, 1, 1, 1, 1, 1, 1]
[1, 1, 1, 1, 1, 1, 2]
[1, 1, 1, 1, 2, 2]
[1, 1, 2, 2, 2]
[2, 2, 2, 2]
 
Function Description
Complete the function ways in the editor below.
ways has the following parameter(s):

    total:  an integer that denotes the value to which the integers  should sum

    k:  an integer that represents the maximum of the range of integers to consider when summing to total

Returns
    int: the number of ways to sum to the total; the number might be very large, so return the integer modulo 1000000007 (109+7)

Constraints
1 ≤ total ≤ 1000
1 ≤ k ≤ 100

Input Format For Custom Testing
Sample Case 0
Sample Input For Custom Testing

STDIN     Function
-----     --------
5      →  total = 5    
3      →  k = 3
Sample Output

5
Explanation

The sum required is 5. k = 3 so the integers that can be considered to reach the sum are [ 1, 2, 3 ].

 

The 5 ways to reach the target sum are:

  1 + 1 + 1 + 1 + 1 = 5
  1 + 1 + 1 + 2 = 5
  1 + 2 + 2 = 5
  1 + 1 + 3 = 5
  2 + 3 = 5
 

5 modulo 1000000007 = 5

Sample Case 1
Sample Input For Custom Testing

STDIN    Function 
-----    -------- 
4     →  total = 4   
2     →  k = 2

Sample Output

3
Explanation

The sum required is 4, and the range of integers is [ 1, 2 ] 

There are 3 ways to reach the target sum:

  1 + 1 + 1 + 1 = 4
  1 + 1 + 2 = 4
  2 + 2 = 4
 

3 modulo 1000000007 = 3.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    class testCase24
    {
        /*
        * Complete the 'ways' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts following parameters:
        *  1. INTEGER total
        *  2. INTEGER k
        */

        //int numOfWays = printAllUniqueParts(total, k);
        //public int printAllUniqueParts(int n, int maxVal) 
        public int printAllUniqueParts(int total, int k) 
        { 
            Console.WriteLine();
            Console.WriteLine("printAllUniqueParts:");
            int ways = 0;
            // An array to store a partition 
            int[] p = new int[total];
            int totalorg = total;
            
            // Index of last element in a
            // partition
            int i = 0;
            p[i] = total;

            Console.WriteLine("Create: Index of last element in a partition: p[i]");
            for (int a = 0; a < totalorg; a++)
                Console.Write(a + " " );
            Console.WriteLine();

            for (int a = 0; a < totalorg; a++)
                Console.Write(p[a] + " " );
            Console.WriteLine();

            // for (int a = 0; a < n; a++)
            //     Console.Write("p[{0}] = {1}, ", a, p[a]);
            // Console.WriteLine();

            // Initialize first partition as  
            // number itself 
            //effectively: p[total] = [k,k,k,k,0,0,0,0], where k+k+k+k = total
            //e.g. p[8] = [2,2,2,2,0,0,0,0]   2+2+2+2 = 8, the reset all zeros
            Console.WriteLine("Loop while i > 0");
            while (total > 0)
            {
                p[i++] = k;
                total -= k;
                if (total< k)
                        //save the remainder back in k
                        k = total;
            }
            --i;
            
            Console.WriteLine("i: {0}", i);
            Console.WriteLine("p[i]:");
            for (int a = 0; a < totalorg; a++)
                Console.Write(a + " " );
            Console.WriteLine();

            for (int a = 0; a < totalorg; a++)
                Console.Write(p[a] + " " );
            Console.WriteLine();

            // This loop first prints current  
            // partition, then generates next 
            // partition. The loop stops when  
            // the current partition has all 1s 
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("While(True)");
            Console.WriteLine();
            while (true) 
            { 
                //Part 1: Initalize
                // print current partition 
                //printArray(p, k+1); 
                ways++;
                
                // Generate next partition 
    
                // Find the rightmost non-one  
                // value in p[]. Also, update  
                // the rem_val so that we know 
                // how much value can be  
                // accommodated 
                //rem_val: how many 1's are there in p[k] 
                int rem_val = 0;
                
                Console.WriteLine();
                Console.WriteLine("i*: {0}", i);
                //Scan the k array for values of 1.
                //n starts from the total - 1 and decreases.
                Console.WriteLine("Scan for 1 in p[i] == 1");
                Console.WriteLine("While loop ---  i >= 0 && p[n] == 1");

                //Part 2: Scan for 1's
                while (i >= 0 && p[i] == 1)
                {
                    Console.Write("rem_val: {0}", rem_val);
                    Console.Write(", p[{0}] = {1}, ", i, p[i]);
                    rem_val += p[i]; 
                    i--; 
                } 
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Done: rem_val: {0}", rem_val);
                for (int a = 0; a < totalorg; a++)
                    Console.Write(a + " " );
                Console.WriteLine();

                for (int a = 0; a < totalorg; a++)
                    Console.Write(p[a] + " " );
                Console.WriteLine();

                //Part 3: Exit Condition
                // if k < 0, all the values are 1 so 
                // there are no more partitions 
                if (i < 0)
                    return ways; 
    
                //Part 4: recalibrate
                //subtract one from the last value in P[n].
                // Decrease the p[k] found above  
                // and adjust the rem_val 
                p[i]--; 
                rem_val++; 
        
                // If rem_val is more, then the sorted 
                // order is violated. Divide rem_val in 
                // different values of size p[k] and copy 
                // these values at different positions 
                // after p[k] 

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("n**: {0}", i);
                Console.WriteLine("After Decrement:");
                for (int a = 0; a < totalorg; a++)
                    Console.Write(a + " " );
                Console.WriteLine();

                for (int a = 0; a < totalorg; a++)
                    Console.Write(p[a] + " " );
                Console.WriteLine();

                //Part 5: Loop through all the 1s
                //Loop through all the ones:
                while (rem_val > p[i])
                {
                    p[i+1] = p[i];
                    rem_val = rem_val - p[i];
                    i++;
                } 
    
                Console.WriteLine();
                Console.WriteLine();
                for (int a = 0; a < totalorg; a++)
                    Console.Write(a + " " );
                Console.WriteLine();

                for (int a = 0; a < totalorg; a++)
                    Console.Write(p[a] + " " );
                Console.WriteLine();

                //Part 6: clean up.
                // Copy rem_val to next position and  
                // increment position 
                p[i+1] = rem_val; 
                i++; 
                Console.WriteLine("+++++++++++++++++++++++++++++++");
            } 
            return ways;
        } 
    
        public int ways(int total, int k)
        {
            Console.WriteLine();
            Console.WriteLine("ways:");

            int numOfWays = printAllUniqueParts(total, k);
            Console.WriteLine();
            Console.WriteLine("numOfWays before mode:", numOfWays);
            Console.WriteLine();
            return numOfWays % 1000000007 ;
        }

        public void exampleInfo()
        {
            Console.WriteLine();
            Console.WriteLine("example:");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("total = 8, k = 2");
            Console.WriteLine("To reach a weight of 8, there are 5 different ways that items with weights between [ 1, 2 ] can be combined:");
            Console.WriteLine("[1, 1, 1, 1, 1, 1, 1, 1]");
            Console.WriteLine("[1, 1, 1, 1, 1, 1, 2]");
            Console.WriteLine("[1, 1, 1, 1, 2, 2]");
            Console.WriteLine("[1, 1, 2, 2, 2]");
            Console.WriteLine("[2, 2, 2, 2]");
            
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("total = 5, k = 3");
            Console.WriteLine("The sum required is 5, and the range of integers is [ 1, 2, 3 ]");
            Console.WriteLine("The 5 ways to reach the target sum are:");

            Console.WriteLine("1 + 1 + 1 + 1 + 1 = 5");
            Console.WriteLine("1 + 1 + 1 + 2 = 5");
            Console.WriteLine("1 + 2 + 2 = 5");
            Console.WriteLine("1 + 1 + 3 = 5");
            Console.WriteLine("2 + 3 = 5");
            
            Console.WriteLine("5 modulo 1000000007 = 5");

            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("total = 4, k = 2");
            Console.WriteLine("Sample Output: 3");
            Console.WriteLine("The sum required is 4, and the range of integers is [ 1, 2 ]");
            Console.WriteLine("There are 3 ways to reach the target sum:");

            Console.WriteLine("1 + 1 + 1 + 1 = 4");
            Console.WriteLine("1 + 1 + 2 = 4");
            Console.WriteLine("2 + 2 = 4");
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine();
            Console.WriteLine();
        }

    }
    
    public class WaystoSum
    {
        //Driver Function like main
        public void driverCall()
        {
            testCase24 sn = new testCase24();

            sn.exampleInfo();
            int total = 8;
            int k = 2;

            Console.WriteLine("Total: {0}, k = {1}", total, k);
            Console.Write("No of ways are: ");
            Console.WriteLine(sn.ways(total, k));

            Console.ReadLine();
        }
    }

}
