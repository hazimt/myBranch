using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    class degreeOfArray
    {
        int degree;
        List<int> arr;
        Dictionary<int, int> dic = new Dictionary<int, int>();

        private degreeOfArray()
        {
            degree = 0;
        }

        public degreeOfArray(List<int> array)
        {
            arr = array;
        }

        //Find Array Degree
        public int findDegree()
        {
            //Scan the given list of array of integers
            foreach (var a in arr)
            {
                //already exist
                if (dic.ContainsKey(a))
                    dic[a]++;               //increment counter, dictionary is a key, value pair.  dic[a] is the value of the key a.  So incrementing dic[a] is incrementing the value for key a;
                else
                    dic.Add(a, 1);          //first Occurance 

                //Update the degree variable which tracks the latest degree value.
                if (dic[a] > degree)
                    degree = dic[a];
            }
            return degree;
        }

        public int findShortestArray()
        {

            int min = int.MaxValue;
            for (int i = 0; i < arr.Count; i++)
            {
                if (dic[arr[i]] == degree)
                {
                    int len = 0;
                    int j = i + 1;
                    for (j = arr.Count - 1; j > i; j--)
                    {
                        if (arr[i] == arr[j])
                        {
                            //Find the length of the sub array.
                            len = j - i + 1;
                            //Find the min length.
                            if (min > len)
                                min = len;
                            dic[arr[i]] = 0;
                            break;
                        }
                    }
                }
            }
            return min;
        }

    }

    class testCase2
    {
        public void degreeOfArrayDriver()
        {
            List<int> a1 = new List<int> { 1, 2, 2, 3, 1 };         //degree 2 for both 1 and 2.  (Two element of digit 1) and 2 (two elements of digit 2)
            foreach (var a in a1)
                Console.Write("{0} ", a);
            Console.WriteLine();

            degreeOfArray dOA1 = new degreeOfArray(a1);
            int degree = dOA1.findDegree();
            int min = dOA1.findShortestArray();
            Console.WriteLine("degree = {0}, min len = {1}", degree, min);

            List<int> a2 = new List<int> { 6, 1, 1, 2, 1, 2, 2 };   //degree 3 for both 1, and 2 (there are three 1's and there are three 2's)
            foreach (var a in a2)
                Console.Write("{0} ", a);
            Console.WriteLine();

            degreeOfArray dOA2 = new degreeOfArray(a2);
            degree = dOA2.findDegree();
            min = dOA2.findShortestArray();
            Console.WriteLine("degree = {0}, min len = {1}", degree, min);

            List<int> a3 = new List<int> { 1, 1, 2, 1, 2, 2 };      //degree 3 for both 1 and 2  (there are three 1's and there are three 2's)
            foreach (var a in a3)
                Console.Write("{0} ", a);
            Console.WriteLine();

            degreeOfArray dOA3 = new degreeOfArray(a3);
            degree = dOA3.findDegree();
            min = dOA3.findShortestArray();
            Console.WriteLine("degree = {0}, min len = {1}", degree, min);

        }
    }
}


//ElHaj
/*


//1. find array degree
    //Create a dic
    //Scan array element by element
        //update count of dic for element
        //add to dic
//2. find shortest subarray
    //Scan array one for loop
        only if element equal degree
        Scan array from end 2nd for loop

static int degreeofArray(List<int> arr)
        {
            int degree = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();

            //1. find array degree
            foreach (var a in arr)
            {
                if (dic.ContainsKey(a))
                    dic[a]++;
                else
                    dic.Add(a, 1);

                if (dic[a] > degree)
                    degree = dic[a];
            }

            //2. find shortest subarray
            int min = int.MaxValue;
            for (int i=0; i < arr.Count; ++i)
            {
                if (dic[arr[i]] == degree)
                {
                    //int j = i + 1;
                    int len = 0;
                    for (j = arr.Count - 1; j > i; --j)
                        if (arr[j] == arr[i])
                        {
                            len = j - i + 1;
                            if (min > len)
                                min = len;
                            dic[arr[i]] = 0;
                            break;
                        }                 
                }
            }

            return min;
        }

*/
