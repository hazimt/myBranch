using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    class printRandomNo
    {
        public Random rand = new Random();

        public printRandomNo()
        {
            Console.WriteLine(rand);
        }

        public void printRandomNoEverySec()
        {

            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                    Console.WriteLine("Genom");
                if (i % 10 == 0)
                    Console.WriteLine("Microsoft");
                if (i%2==0 && i%10 == 0)
                    Console.WriteLine("Genom Micorosft");
                else 
                    Console.WriteLine("else area");
                    //printRandomNo();
            }

        }
    }

    class testCase6
    {
        public void printRandomNo()
        {

            printRandomNo pR = new printRandomNo();

            pR.printRandomNoEverySec();

        }
    }

}


/*

        public void callRemoveDups()
        {
            int[] arr = { 1, 2, 5, 1, 7, 2, 4, 2 };
            //int n = sizeof(arr) / sizeof(arr[0]);
            int n = arr.Length;
            removeDups(arr, n);
        }
        
        //public void removeDups(int arr[], int n)
        public void removeDups(int[] arr, int n)
        {
            // Hash map which will store the 
            // elements which has appeared previously. 
            //unordered_map <int, bool> mp;
            //https://programmingwithmosh.com/csharp/csharp-collections/
            Dictionary<string, int> mp = new Dictionary<string, int>();

            //var dictionary = new Dictionary<int, Customer>();
            // Iterate over keys 
            foreach (var key in mp.Keys)
                Console.WriteLine(mp[key]);

            // Iterate over values
            foreach (var value in mp.Values)
                Console.WriteLine(value);

            // Iterate over dictionary
            foreach (var keyValuePair in mp)
            {
                Console.WriteLine(keyValuePair.Key);
                Console.WriteLine(keyValuePair.Value);
            }

            for (int i = 0; i < n; ++i)
            {
                // Print the element if it is 
                // there in the hash map 
                //if (mp.find(arr[i]) == mp.end())
                if (mp.ToLookup<arr[i]> == mp.Last())           //(arr[i]) == mp.Last())
                {
                    Console.WriteLine("<< arr[i] <<");
                }

                // Insert the element in the hash map 
                mp[arr[i]] = true;
            }
        }

*/

