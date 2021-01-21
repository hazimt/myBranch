
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Abstract Class
//An abstract class cannot be instantiated
//The purpose of an abstract class is to provide a common definition of a base class that multiple derived classes can share.

//Abstract Override
//There's a useful example for this on Microsoft Docs - basically you can force a derived class 
//to provide a new implementation for a method.

//https://stackoverflow.com/questions/8905432/what-is-the-use-of-abstract-override-in-c
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members


//Virtual Override
//The virtual keyword is used to modify a method, property, indexer, or event declared in the base class 
//and allow it to be overridden in the derived class.

namespace TestCases
{
    public class D
    {
        public virtual void DoWork(int i)
        {
            // Original implementation.
            Console.WriteLine("Class D: DoWork (Vitual) i={0})", i);
        }
    }

    public abstract class E : D
    {
        public abstract override void DoWork(int i);
    }

    public class F : E
    {
        public override void DoWork(int i)
        {
            // Force a New implementation.
            Console.WriteLine("Class F: override DoWork(int i={0})", i);            
        }
    }


    public class TestAbstractOverrideDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" TestAbstractOverride  ");

            int i = 5;
            
            D d = new D();

            d.DoWork(i);

            Console.ReadLine();             
            //Line 35: Create an instance of B and assign it to class A.
            i = 6;
            
            //This doesn't work.
            //Cannot create an instance of the abstract type or interface 'E' [InterviewQuestionsVisualCode]csharp(CS0144)
            //Compile Error
            //E e = new E();

            //e.DoWork(i);

            //Console.ReadLine();             
            //-----------------------------------------------------------------------
            i = 6;

            F f = new F();

            f.DoWork(i);

            Console.ReadLine();             

            //-----------------------------------------------------------------------
            i = 7;

            D g = new F();

            g.DoWork(i);

            Console.ReadLine();             


        }
    }

}

