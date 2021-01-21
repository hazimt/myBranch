
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Sealed Class
//A sealed class cannot be used as a base class. For this reason, it cannot also be an abstract class. 
//Sealed classes prevent derivation. Because they can never be used as a base class, some run-time optimizations 
//can make calling sealed class members slightly faster.


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
    public class A
    {
        public virtual void test1()
        {
            Console.WriteLine("Test 1 in A class");
        }

        public virtual void test3()
        {
            Console.WriteLine("Test 3 in A class");
        }

        public void test2()
        {
            Console.WriteLine("Test 2 in A class");
        }

        public void test4()
        {
            Console.WriteLine("Test 4 in A class");
        }
    }

    public class B : A
    {
        //polymorphic method because A.test1 is virtual and B.test1 is overriden
        public override void test1()
        {
            Console.WriteLine("Test 1 in B class");
        }

        //Missing overriden so even though test3 in A is virtual it's not polymorphic because B.test3 is NOT overriden. 
        public void test3()
        {
            Console.WriteLine("Test 3 in B class");
        }

        new public void test2()
        {
            Console.WriteLine("Test 2 in B class");
        }

        //Instead of using the word override before test4.
        //Use the word: new before test4.
        //now test4 is exactly like test2.
        public new void test4()
        {
            Console.WriteLine("Test 4 in B class");
        }
    }


    public class TestVirtualOverrideDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" TestVirtualOverride  ");

            A a = new A();

            a.test1();          //Test 1 in A class (Virtual)
            a.test2();          //Test 2 in A class (regular method)
            a.test3();          //Test 3 in A class (virutal)
            a.test4();          //Test 4 in A class (regular)

            Console.ReadLine();             
            //Line 35: Create an instance of B and assign it to class A.
            A c = new B();

            c.test1();          //Test 1 in B class (Because test1 in B overrides the one in class A.  <-----
                                //So Class B override Class A method)
                                //(virtual/overriden) classical
            c.test2();          //Test 2 in A class (regular/new) classical
            c.test3();          //Test 3 in A class (virtual, not overriden)
            c.test4();          //Test 4 in A class (virtual/new)

            //This doesn't work.
            //B x = new A()       //"Cannot implicitly convert type 'TestCases.A' to 'TestCases.B'. An explicit conversion exists (are you missing a cast?) [InterviewQuestionsVisualCode]",

            Console.ReadLine();             
            //-----------------------------------------------------------------------

            B b = new B();

            b.test1();          //Test 1 in B class (overriden)
            b.test2();          //Test 2 in B class (new)
            b.test3();          //Test 3 in B class (regular, not overriden)
            b.test4();          //Test 4 in B class (new)

            Console.ReadLine();             

            //-------------------------------------------------------------------------
            b.test3();          //Test 1 in B class (regular, not overriden))
            c.test3();          //Test 1 in A class  [instead of printing Test 2 in A class becuase test3 isn't overriden]
                                //Still calling A.test3 instead of B.test3 which is the object it's pointing at.
                                //whereas test2 prints Test 2 in B class, because test2 is overriden.
                                //(virtual/regular, not overriden)

            Console.ReadLine();             
        }
    }

}

