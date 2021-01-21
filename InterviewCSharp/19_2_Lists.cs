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
    public class listEx2
    {
        List<string> mylistName;
        List<int> mylistNo;
        const int itemLimit = 5;
        
         public void cart()
        {
            List<string> mylistName= new List<string>(itemLimit);
            List<int> mylistNo = new List<int>(itemLimit);        
        }

        public List<string> listAddItem(string item)
        {
            mylistName.Add(item);

            return mylistName;
        }        
        public List<int> listAddCount(int count)
        {
            mylistNo.Add(count);

            return mylistNo;
        }

    }
    
    public class testCase192
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

