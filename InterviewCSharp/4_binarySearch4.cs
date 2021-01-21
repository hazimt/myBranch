using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://www.c-sharpcorner.com/blogs/binary-search-implementation-using-c-sharp1
namespace TestCases
{
    class binarySearch
    {
        List<int> arrList = new List<int>();
        private binarySearch()
        {
            int i = 0;
            int min, max = 0;
            max = arrList.Count();
        }
        public binarySearch(List<int> arrayList)
        {
            arrList = arrayList;
        }

        //Of a sorted array
        //Execute Binary Search
        public int bSearchIterative(List<int> arrayList, int key)
        {

            int min = 0;
            int max = arrayList.Count() - 1;

            while (max >= min)
            {
                //Find middle point
                int mid = (max + min) / 2;

                //Search for key in middle point.
                if (arrayList[mid] == key)
                    return mid;

                //Search for key in left side.
                if (arrayList[mid] > key)
                    max = mid - 1;

                //Search for key in right side.
                if (arrayList[mid] < key)
                {
                    min = mid + 1;
                }
            }

            return -1;
        }

        public int bSearchRec(List<int> arrayList, int key, int min, int max)
        {

            //Will fail without it.
            if (arrayList.Count >= max)
                return -1;

            //Every recursive fn must have an exit criteria
            if (min > max)
                return -1;
            else //(min <= max)
            {
                int mid = (max + min) / 2;

                if (key == arrayList[mid])
                    return mid;

                else if (key < arrayList[mid])
                    return bSearchRec(arrayList, key, min, mid - 1);

                else //(key > arrayList[mid])
                    return bSearchRec(arrayList, key, mid + 1, max);
            }
        }


    }

    class testCase4
    {
        public void bSearchDriver()
        {
            //Of a sorted array
            int key = 12;
            List<int> arr1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<int> arr2 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            binarySearch bs1 = new binarySearch(arr1);
            int i = bs1.bSearchIterative(arr1, key);

            Console.WriteLine("The key {0} has index {1}", key, i);

            bs1.bSearchRec(arr1, key, 0, arr1.Count());
            Console.WriteLine("Recursive: The key {0} has index {1}", key, i);


            Console.WriteLine("---------------------------------");

            binarySearch bs2 = new binarySearch(arr2);
            i = bs2.bSearchIterative(arr2, key);

            Console.WriteLine("The key {0} has index {1}", key, i);

            key = 3;

            binarySearch bs3 = new binarySearch(arr2);
            i = bs3.bSearchIterative(arr2, key);

            Console.WriteLine("The key {0} has index {1}", key, i);
            Console.WriteLine("---------------------------------");

            bs2.bSearchRec(arr1, key, 0, arr2.Count());
            Console.WriteLine("Recursive: The key {0} has index {1}", key, i);



        }
    }
}

