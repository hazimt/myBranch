
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//final
//Java has final keyword, but C# does not have its implementation. For the same implementation, use the sealed keyword.

//With sealed, you can prevent overriding of a method. When you use sealed modifiers in C# on a method, then the method loses its capabilities of overriding. The sealed method should be part of a derived class and the method must be an overridden method.


//https://www.tutorialspoint.com/Final-keyword-in-Chash
//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sealed


//Finalize 
//Finalizers (which are also called destructors) are used to perform any necessary final clean-up when a class instance is being collected by the garbage collector.
//The Finalize in C# is used to free unmanaged resources like database connections etc. The method finalize() is for unmanaged resources.

//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/destructors

//e.g.
    // class Car
    // {
    //     ~Car()  // finalizer
    //     {
    //         // cleanup statements...
    //     }
    // }

namespace TestCases
{
    //**************************Final == Sealed example****************************************
    class ClassOne 
    {
        public virtual void display() 
        {
                Console.WriteLine("Dispaly: Baseclass");
        }
        public ClassOne()
        {
            Console.WriteLine("Baseclass costructor.");
        }         
        ~ClassOne()     // finalizer
        {
            Console.WriteLine("Finalizer: Baseclass destructor.");
        }       }

    class ClassTwo : ClassOne 
    {
        public sealed override void display() 
        {
            Console.WriteLine("Dispaly: ClassTwo:derivedClass");
        }
        public ClassTwo()
        {
            Console.WriteLine("ClassTwo:derivedClass Costructor");
        }         
        ~ClassTwo()     // finalizer
        {
            Console.WriteLine("Finalizer: ClassTwo:derivedClass destructor.");
        }        
    }

    //This will fail.  Because you can NOT inheret from a sealed class
    class ClassThree : ClassTwo 
    {
        //Complier Error:
        //'ClassThree.display()': cannot override inherited member 'ClassTwo.display()' because it is sealed 
        // public override void display() 
        // {
        //     Console.WriteLine("ClassThree: Another Derived Class");
        // }
        public ClassThree()
        {
            Console.WriteLine("ClassThree:derivedClass conestructor.");
        }
        ~ClassThree()     // finalizer
        {
            Console.WriteLine("Finalizer: ClassThree:derivedClass destructor.");
            Console.ReadLine();             

        }
    }
    //**************************Final == Sealed example Ends****************************************




    public class FinalSealed_Finalize_Driver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" FinalSealed_Finalize_Driver  ");

            //**************************Final == Sealed example****************************************
            ClassOne sn1 = new ClassOne();
            sn1.display();

            ClassTwo sn2 = new ClassTwo();
            sn2.display();

            Console.WriteLine();
            Console.WriteLine(" ............  ");

            //**************************Finalize Example Start****************************************
            ClassThree t = new ClassThree();
            /* Output (to VS Output Window):
                Third's destructor is called.
                Second's destructor is called.
                First's destructor is called.
            */

            Console.ReadLine();             
        }
    }

}

