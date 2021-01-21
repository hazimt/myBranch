//https://www.youtube.com/watch?v=yysUerUhxOE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class cse_staticMethods
    {
        //it's a method that is called without having to creat an instance of this class to use them.
        //like, 
        //Console.WriteLine(Math.Sqrt(144));
        public static void sayHi(string name)
        {
            Console.WriteLine("Hello " + name);
        }
    }

    public class testCase8 
    {
        public void cse_staticMethodsCall()
        {
            //e.g of a static method.
            Console.WriteLine(Math.Sqrt(144));
            cse_staticMethodsTest();
        }
        public static void cse_staticMethodsTest()
        {
            cse_staticMethods.sayHi("Hazim");
            Console.ReadLine(); 
        }
    }
}