//https://www.youtube.com/watch?time_continue=4&v=LvQzYMXEANs&feature=emb_logo

//    array A = [150, 85, 62, 75, 60, 76, 90];  --> array b = [no of continous days just before the given day 
//                                 where the prices is less or equal to the current day]
//                            [1, 1, 1, 2, 1, 4, 6]
// i = 3 c = 1


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class testCase23
    {
        public void CalculateSpan(int[] A, int n, int[] ans)
        {
            //Span value of 1st element
            if (n >= 1) 
                ans[0] = 1;
            
            //print incoming area
            bool debug = true;
            if (debug) {
                for (int i = 0; i < n; i++)
                    Console.Write(A[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //loop O(n)
            //Odd even
            //Console.WriteLine("150, 85, 62, 75, 60, 76, 90");

            Console.WriteLine();
            //Console.WriteLine("Counter:");
            //Console.WriteLine("1   1  1  2  1  4  6");
            
            Console.WriteLine();
            Console.WriteLine("i: ");
            for (int i = 1; i < n; i++)
            {
                //reset counter to 1 so as to scan backward all the elements.
                int counter = 1;
                // (i - counter): this is going from i backward all the way to zero && Check if next no is greater than current
                //(i - counter) >= 0  to make sure we don't go past index 0.
                //A[i] >= A[i - counter] : the span condition.  Geater or equal
                while ((i - counter) >= 0 && A[i] >= A[i - counter])
                {
                    Console.Write(i + "  ");
                    counter += ans[i - counter];
                    //counter = counter + ans[i - counter];
                }
                ans[i] = counter;
            }
            Console.WriteLine();
            Console.WriteLine("______");
            Console.WriteLine();
        }

        //Same as above.  Built it from the scratch up.
        public void CalculateSpanTest(int[] A, int n, int[] ans)
        {
            //Span value of 1st element
            if (n >= 1) 
                ans[0] = 1;

            
            //print incoming area
            bool debug = true;
            if (debug) {
                for (int i = 0; i < n; i++)
                    Console.Write(A[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //loop O(n)
            //Odd even
            Console.WriteLine();

            Console.WriteLine();
            //Console.WriteLine("Counter proper result:");
            //Console.WriteLine("1   1  1  2  1  4  6");
            
            Console.WriteLine();
            Console.WriteLine("i: ");

            for (int i = 1; i < n; i++)
            {
                int c = 1;
                while (((i - c) >= 0) && A[i] > A[i-c])
                {
                    Console.Write(i + "  ");
                    c += ans[i - c];        //Counter = Counter + the previous 
                                            //elements counter value which is  ans[i -c]
                }
                ans[i] = c;
            }
            Console.WriteLine();
            Console.WriteLine("______");
            Console.WriteLine();
        }

        public void printArray(int[] arr, int n)
        {
            Console.WriteLine("printArray: ");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + "  ");

            Console.WriteLine();
        }
    }
    
    public class stocksapn
    {
        //Driver Function
        public void driverCall()
        {
            testCase23 sn = new testCase23();

            Console.WriteLine("Hello World");
            
            //Odd even
            //Works
            int[] price0 = {150, 85, 62, 75, 60, 76, 90};
            //Works
            int[] price1 = {150, 85, 62, 75, 60, 76};

            //Huge
            //normal
            //Work
            int[] price2 = {150, 85, 62, 75, 60, 76, 90};
            //First one broken
            int[] price3 = {150, 150, 150, 150, 150, 150, 150};
            //single element
            //Works
            int[] price4 = {150};

            int[] price5 = {150, 63, 76};
            int[] price6 = {150, 151, 152};
            int[] price7 = {150, 149, 148};
            //Works
            int[] price8 = {};
            //First one broken
            int[] price = {0,0};
            
            int n = price.Length;
            int[] S = new int[n];
            
            //Calculate the span
            Console.WriteLine("================================");
            sn.CalculateSpan(price, n, S);
            sn.printArray(S, n);

            Console.WriteLine("================================");
            sn.CalculateSpanTest(price, n, S);            
            sn.printArray(S, n);

            Console.ReadLine();
            Console.ReadLine();
        }
    }
}


