/*
// {{2,5}, {3,6}, {5,7}}  -> 2


list of jobs {start, end}, over a 24hour period, not scoping to the next day. 
//Constraint. Only one job can run on a VM at a time. 
//Objective is to find how many VMs we'll need to accomplish the list.

Case 1:
(1 vm)
2,5
5,7

or 
2,5
2,6

end1 = start2
end1 < start2

Case 2:
(2 VM)
2,5
3,6 

end1 > start2



*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class VMList
    {
        //int[] startJobArray;
        int[] startJobArray = new int[24];
        int[] endJobArray;


        public VMList()
        {
            endJobArray = new int[24];
        }

        //initialize job arrays to zeros
        public void myListInit()
        {
            for (int i = 0; i < startJobArray.Length; i++)
                startJobArray[i] = 0;

            //foreach (int item in endJobArray)
            for (int i = 0; i < endJobArray.Length; i++)
                endJobArray[i] = 0;

            printArrays("myListInit", startJobArray, endJobArray);

        }

        //Assign the jobs within order of the keys (startJobArray)
        public void myListJobAssignment(Dictionary<int,int> mDic)
        {
            //mDic

            Console.WriteLine();
            foreach (int item in mDic.Keys)
                Console.Write("{0,3}", item);
            Console.WriteLine();

            Console.WriteLine();
            foreach (int item in mDic.Values)
                Console.Write("{0,3}", item);
            Console.WriteLine();

            //Convert whats' in the dictionary into an arry.
            //Keys (start) into one array startJobArray
            //Values (end) into another array endJobArray 
            startJobArray = mDic.Keys.ToArray();
            endJobArray = mDic.Values.ToArray();

            Console.WriteLine();
            foreach (int item in startJobArray)
                Console.Write("{0,3}", item);
            Console.WriteLine();

            Console.WriteLine();
            foreach (int item in endJobArray)
                Console.Write("{0,3}", item);
            Console.WriteLine();

            printArrays("myListJobAssignment with Dic", startJobArray, endJobArray);
        }

        public void listEx()
        {
            //To Sort use quickSort to sort startJobArray.  And at the same time just copy the endJobArray corresponding item to the same index.
            int lens = startJobArray.Length;
            int lene = endJobArray.Length;
            int jobs = 1;       //Make sure you at least have one job.  Check.
            int saveJobNo = 0;

            printArrays("listEx", startJobArray, endJobArray);

            //Broken
            //scan array2 endJobArray
            for (int i = 1; i < lens; i++)
            {
                for (int j = 0; j < lens; j++)
                {
                    if (startJobArray[i] >= endJobArray[i])
                            jobs = jobs;       //do nothing
                    if (startJobArray[i] < endJobArray[j]) 
                            jobs++;

                }
                //
                if ((endJobArray[i] != 0) && (startJobArray[endJobArray[i]] != 0)) 
                {
                    jobs++;
                    saveJobNo = startJobArray[i];
                    startJobArray[i] = endJobArray[i];
                    //This is not be needed at all.
                    //Do this ONLY if need to update the endJobArray.  
                    //Scan endJobArray and update the end jobs id to be the zero since it's already been counted.
                    for (int j = 0; j < lene; j++)
                        if (saveJobNo == endJobArray[j])
                            endJobArray[j] = 0;
                }
            }

            printArrays("listEx", startJobArray, endJobArray);
            Console.WriteLine("jobs = " + jobs);

        }

        public void printArrays(string fnName, int[] startJobArray, int[] endJobArray)
        {
            int lens = startJobArray.Length;
            int lene = endJobArray.Length;

            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(fnName + ":");

            Console.WriteLine("Print startJobArray");
            for (int i = 0; i < lens; i++)
            {
                Console.Write("{0,3}", startJobArray[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < lens; i++)
            {
                Console.Write("{0,3}", i);
            }
            Console.WriteLine();
            Console.WriteLine("lens = " + lens);
 
            Console.WriteLine();
            Console.WriteLine("Print endJobArray");
            for (int i = 0; i < lene; i++)
            {
                Console.Write("{0,3}", endJobArray[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < lens; i++)
            {
                Console.Write("{0,3}", i);
            }
            Console.WriteLine();
            Console.WriteLine("lene = " + lene);

            Console.WriteLine("Print Done");
        }

    }
    
    public class testCase19
    {
        //Driver Function
        public void  driverCall()
        {
            VMList sn = new VMList();

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            //Assign list
            //Declare a dictionary
            //Dictionary<int, int> myDic = new Dictionary<int, int> {{2,5}, {3,6}, {5,7}};
            Dictionary<int, int> myDic = new Dictionary<int, int> ();
            //Add to a dictionary
            //sorted
            myDic.Add(2,5);
            myDic.Add(3,6);
            myDic.Add(5,7);
            myDic.Add(6,8);
            myDic.Add(7,8);
            myDic.Add(9,11);

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("mys");
            VMList mys = new VMList();

            Console.WriteLine("{{2,5}, {3,6}, {5,7}, {6,8}, {7,8}, {9,11}}");
            mys.myListInit();

            Console.WriteLine();
            foreach (int item in myDic.Keys)
                Console.Write("{0,3}", item);
            Console.WriteLine();

            Console.WriteLine();
            foreach (int item in myDic.Values)
                Console.Write("{0,3}", item);
            Console.WriteLine();

            mys.myListJobAssignment(myDic);
            mys.listEx();

            Console.ReadLine();             

        }
    }

}
