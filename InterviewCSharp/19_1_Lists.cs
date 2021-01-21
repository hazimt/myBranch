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
    public class listEx
    {
        public void listInsert(List<string> mL,  string sItem)
        {
            int binarySearchIndex = mL.BinarySearch(sItem);
            if (binarySearchIndex < 0)
                mL.Insert(~binarySearchIndex, sItem);
        }
        public List<string> listAdd()
        {

            List<string> lstMyString = new List<string>();
            lstMyString.Add("Apple");
            lstMyString.Add("Mango");
            lstMyString.Add("Banana");
            lstMyString.Add("papya ");
            
            foreach (var r in lstMyString)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Now Sort");
            lstMyString.Sort();
            foreach (var r in lstMyString)
            {
                Console.WriteLine(r);
            }

            Console.ReadKey(true);            
            
            return lstMyString;
        }

    }
    
    public class testCase191
    {
        //Driver Function
        public void  driverCall()
        {
            listEx sn = new listEx();

            List<string> myList = sn.listAdd();

            Console.WriteLine("---------------------------------");
            string item = "Cashaw";
            sn.listInsert(myList, item);

            Console.ReadLine();             
        }
    }

}

