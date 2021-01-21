
using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class ArrayListEx
    {
        bool debug = false;        
        public void ArrayListOfArraysEx1()
        {
            Console.WriteLine(" ArrayListOfArraysEx1   ");
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");

            //First Array
            ArrayList[] myArrayOfArrays = new ArrayList[10];

            //Second Array
            ArrayList list = new ArrayList();
            list.Add("RHV");
            list.Add("Zen");

            //even if list is made null, myArrayOfArrays[0] persist the values of old list. 
            myArrayOfArrays[0] = list;


            int[] arr = new int[9];
            arr[0] = new int();

            myArrayOfArrays[0] = new ArrayList();
            //myArrayOfArrays



            //Failshere
            //Console.WriteLine(myArrayOfArrays[0][0]);
            //Console.WriteLine(myArrayOfArrays[0][1]);
            // Console.WriteLine(myArrayOfArrays[0][2]);
            // Console.WriteLine(myArrayOfArrays[0][3]);

            list = new ArrayList();
            list.Add("0_2hi");
            list.Add("1_2hello");
            list.Add("2_2hello");
            list.Add("3_2hello");

            myArrayOfArrays[1] = list;

            Console.WriteLine("----------------First------------------");
            // Console.WriteLine(myArrayOfArrays[0][0]);
            // Console.WriteLine(myArrayOfArrays[0][1]);
            Console.WriteLine("----------------Second------------------");
            // Console.WriteLine(myArrayOfArrays[1][0]);
            // Console.WriteLine(myArrayOfArrays[1][1]);
            // Console.WriteLine(myArrayOfArrays[1][2]);
            // Console.WriteLine(myArrayOfArrays[1][3]);


        }

        public void ArrayListOfArraysEx2()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ArrayListOfArraysEx2   ");
            
            //The clearest way
            ArrayList arr = new ArrayList();
            arr.Add(new ArrayList(new[] { "value 1.1", "value 1.2" }));
            arr.Add(new ArrayList(new[] { "value 2.1", "value 2.2" }));
            arr.Add(new ArrayList(new[] { "value 3.1", "value 3.2" }));
 
            Console.WriteLine("--------------1--------------------");
            foreach (ArrayList innerArr in arr)
            {
                foreach (object element in innerArr)
                {
                    // Do something with the elements.
                    Console.WriteLine("element" + element);
                }
            }
        }


        public void ArrayListOfArraysEx3()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ArrayListOfArraysEx3   ");

            int count = 18;
            ArrayList arr1 = new ArrayList();
            Console.WriteLine("-----------------2-----------------");
            for (int i = 1; i < count; i++)
            {
                for (int j = 1; j < 3; j++)
                    arr1.Add(new ArrayList(new[] { "value " + j++, "value " + j++}));
            }

            Console.WriteLine("--------------3--------------------");
            foreach (ArrayList innerArr in arr1)
            {
                foreach (object element in innerArr)
                {
                    // Do something with the elements.
                    Console.WriteLine("element" + element);
                }
            }
        }

        public void ArrayListOfArraysEx4()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ArrayListOfArraysEx4   ");

            ArrayList arr = new ArrayList();
            arr.Add(new ArrayList(new[] { "value 1.1", "value 1.2" }));
            arr.Add(new ArrayList(new[] { "value 2.1", "value 2.2" }));
            arr.Add(new ArrayList(new[] { "value 3.1", "value 3.2" }));
            foreach (ArrayList innerArr in arr)
            {
                foreach (object element in innerArr)
                {
                    // Do something with the elements.
                    Console.WriteLine("arr: " + element);
                }
            }

            Console.WriteLine("-------------------");
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //Console.WriteLine(arr[i].get(j));
                    //Console.WriteLine(arr.get(i).get(j));
                }
            }

        }

    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }    

    public class Nodetest
    {
        public static int n;
        public int Manager { get; set; } 
        public int Employee { get; set; } 
        public ArrayList SameManager = new ArrayList();
        public Nodetest[] SameManager2 = new Nodetest[n];
    }

    public class TreeNode
    {
        public int id { get; set; }
        public string name {get; set; }
        public bool leaf {get; set; }            
    }

    
    public class ArrayListExDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" 100_SimpleArrayList.cs  ");

            ArrayListEx sn = new ArrayListEx();

            sn.ArrayListOfArraysEx1();
            sn.ArrayListOfArraysEx2();
            sn.ArrayListOfArraysEx3();
            sn.ArrayListOfArraysEx4();

            Console.ReadLine();             
        }
    }

}

