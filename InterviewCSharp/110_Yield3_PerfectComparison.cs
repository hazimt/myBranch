
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//yield2
//When you use the yield contextual keyword in a statement, you indicate that the method, operator, 
//or get accessor in which it appears is an iterator.

//The following example demonstrates a get accessor that is an iterator. 
//In the example, 
//each yield return statement returns an instance of a user-defined class.

//https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/



namespace TestCases
{
    public class withoutYieldEx1
    {
        public void withoutYield() 
        {
            int[] a = new int[10]; 
            a = func(2, 10);

            for (int i = 0; i < 10; i++) 
                Console.WriteLine(a[i]); 
            
            Console.Read();         

        }
        public static int[] func(int start, int number) 
        { 
            int[] _number = new int[number];

            for (int i = 0; i < number; i++) 
            { 
                _number[i] = start + 2 * i; 
            }

            return _number;
        }
    }


    public class withYieldEx1
    {
        public static void withYield() 
        {
            foreach (var item in func(2,10)) 
                Console.WriteLine(item); 
            
            Console.Read();         
        }

        //By using yield, it's actually returning/yielding the elements of the array one by one.  
        //Can't be done without yield. Without yield it has to be done like above.
        public static IEnumerable func(int start, int number) 
        { 

            for (int i = 0; i < number; i++) 
            { 
                yield return start + 2 * i; 
            }
        }
    }

    public class yield3kDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");

            withoutYieldEx1 sn = new withoutYieldEx1();

            sn.withoutYield();
            Console.ReadLine();

            withYieldEx1 sn1 = new withYieldEx1();
            sn.withoutYield();             
            Console.ReadLine();
        }
    }

}

/* 
2
4
6
8
10
12
14
16
18
20

*/