
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//final == Sealed fn (can't be inherited)
//Java has final keyword, but C# does not have its implementation. For the same implementation, use the sealed keyword.

//With sealed, you can prevent overriding of a method. When you use sealed modifiers in C# on a method, then the method loses its capabilities of overriding. The sealed method should be part of a derived class and the method must be an overridden method.

//Finally == execute the block always and regardless.
//The finally block is used to execute a given set of statements, whether an exception is thrown or not thrown. For example, if you open a file, it must be closed whether an exception is raised or not.

//https://www.tutorialspoint.com/final-finally-and-finalize-in-Chash


namespace TestCases
{

    public class Demo 
    {
        int result;
        public Demo() {
            result = 0;
        }
        public void division(int num1, int num2) 
        {
            try 
            {
                result = num1 / num2;
            
            } catch (DivideByZeroException e) {
                Console.WriteLine("Exception caught = {0}", e);
            
            } finally {         //the last thing executed. 
                Console.WriteLine("Result = {0}", result);
            }
        }

    }

 
    public class FinallyDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" ............  ");


            Demo d = new Demo();
            d.division(100, 0);


            Console.ReadLine();             
        }
    }

}

