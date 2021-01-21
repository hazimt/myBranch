
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
    public class Example
    {
        // public void withYield() 
        // {
        //     int[] a = new int[10]; 
        //     a = func(2, 10);

        //     foreach (var item in func(2,10)) 
        //         Console.WriteLine(item); 
            
        //     Console.Read();         

        // }
        // public static System.Collections.Generic.IEnumerable func(int start, int number) 
        // { 

        //     for (int i = 0; i < number; i++) 
        //     { 
        //         yield return start + 2 * i; 
        //     }
        // }
    }

    public class testCase0
    {
        public void withYield() 
        {
            foreach (var item in func(2,10)) 
                Console.WriteLine(item); 
            
            Console.Read();         

        }
        public static IEnumerable func(int start, int number) 
        { 

            for (int i = 0; i < number; i++) 
            { 
                yield return start + 2 * i; 
            }
        }


        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");

            testCase0 sn = new testCase0();

            sn.withYield();

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