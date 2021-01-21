
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//yield
//When you use the yield contextual keyword in a statement, you indicate that the method, operator, 
//or get accessor in which it appears is an iterator.

//https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/


//https://www.google.com/search?client=opera&sxsrf=ALeKk02SbkNO4ped6OWZDD1WVn_QSKmVrA%3A1607034637969&ei=DWfJX73OOurA0PEPsuCu8Aw&q=%22yield%22++C%23&oq=%22yield%22++C%23&gs_lcp=CgZwc3ktYWIQAzIKCAAQsQMQgwEQQzIGCAAQBxAeMgYIABAHEB4yBggAEAcQHjICCAAyBggAEAcQHjIGCAAQBxAeMgYIABAHEB4yBggAEAcQHjIGCAAQBxAeOgQIABBHOgYIABAIEB5QmRBYzRZgrhtoAHADeACAAXGIAdkBkgEDMC4ymAEAoAEBoAECqgEHZ3dzLXdpesgBCMABAQ&sclient=psy-ab&ved=0ahUKEwj9iPPF7rLtAhVqIDQIHTKwC84Q4dUDCA0&uact=5



namespace TestCases
{
    class yieldClass
    {
        bool debug = false;        

        public void yieldEx1()
        {

            //No yeild return in GenerateWithoutYieldAtAll() so this doesn't work.
            //Compile time Error
/*             foreach (var number in GenerateWithoutYieldAtAll())
                Console.WriteLine(number); */

            //Another way
            var number1 = 0;
             while (GenerateWithoutYieldAtAll() < 1000)
             {
                Console.WriteLine(number1);
             }

            Console.WriteLine(GenerateWithoutYieldAtAll());

            foreach (var number in GenerateWithoutYield())
                Console.WriteLine(number);

        }

        //yeild This method 
        public static int GenerateWithoutYieldAtAll()
        {
            var i = 0;
            var list = new List<int>();
        
            while (i < 5)  // yield gives the control to this part and will hit only this part everytime we call GenerateWithoutYield
                return ++i;           //using yield says this method is an iterator

            return i=100;
        }

        public static IEnumerable<int> GenerateWithoutYield()
        {
            var i = 0;
            var list = new List<int>();
        
            while (i < 5)  // yield gives the control to this part and will hit only this part everytime we call GenerateWithoutYield
                yield return ++i;           //using yield says this method is an iterator
        }

    }
   
    public class yieldkDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");

            yieldClass sn = new yieldClass();

            sn.yieldEx1();

            Console.ReadLine();             
        }
    }

}

