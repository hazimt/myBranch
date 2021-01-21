using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    class removeDups
    {
        List<int> myList = new List<int>();

        private removeDups()
        {
            int size = myList.Count;
        }

        public removeDups(List<int> oList)
        {
            int size = myList.Count;

            myList = oList;
        }

        public int removeDupsIterative(List<int> oList)
        {

            Dictionary<int, bool> mp = new Dictionary<int, bool>();

            //foreach (KeyValuePair<int, bool> kvp in mp)
            //    Console.WriteLine(kvp.Key, kvp.Value);

            Dictionary<int, bool>.ValueCollection valCol = mp.Values;
            foreach (bool i in valCol)
                Console.WriteLine("value = {0}", i);

            Dictionary<int, bool>.KeyCollection keyCol = mp.Keys;
            foreach (int s in keyCol)
                Console.WriteLine("key = {0}", s);

            for (int k = 0; k < oList.Count; k++)
            {

                //if (mp.ToLookup<)
                int i = 0;
                mp[oList[i]] = true;
            }

            return 1;
        }
    }

    class testCase5
    {
        public void removeDupsDriver()
        {

            List<int> dupList = new List<int> { 1, 2, 5, 1, 7, 2, 4, 2 };
            int n = dupList.Count();

            removeDups rDup = new removeDups(dupList);

            rDup.removeDupsIterative(dupList);

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

