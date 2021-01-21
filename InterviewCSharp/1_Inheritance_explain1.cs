using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace constructorTest
namespace TestCases
{
    class Animal
    {
        public virtual void sound()
        {
            Console.WriteLine("Animal sound");
        }
        public Animal()
        {
            Console.WriteLine("In A");
        }
        static Animal()
        {
            Console.WriteLine("In A Static");
        }
        public void Method()
        {
            Console.WriteLine("In A method");
        }
    }
    class Dog : Animal
    {
        /*public override void sound() 
        { 
            base.sound(); 
        }*/
        public Dog() { Console.WriteLine("In D"); }
        static Dog() { Console.WriteLine("In D Static"); }
        public void MethodD()
        {
            Console.WriteLine("In D method");
        }
        public override void sound()
        {
            Console.WriteLine("Animal sound");
        }
    }

    class testCase1
    {

        //testCase1
        public void Inheritance_explainDriver()
        {
            //A.A();                        //Needs to be instantiated 
            Console.WriteLine("=============================");
            Console.WriteLine("Test1: Animal a = new Animal()");            //Test1:
            Animal a = new Animal();                //In A Static
                                                    //In A

            Console.WriteLine("=============================");
            Console.WriteLine("Test2: Dog b = new Animal()");
            //Dog b = new Animal();   //Error CS0266  Cannot implicitly convert type 
            //'Inheritance_explain.Animal' to 'Inheritance_explain.Dog'.
            //An explicit conversion exists (are you missing a cast?)
            //Meaning a child can't point to a parent.
            //But a parent can point to a child

            Console.WriteLine("=============================");
            Console.WriteLine("Test3: Animal c = new Dog()");        //Test3:
            Animal c = new Dog();               //In D Static
                                                //In A
                                                //In D

            Console.WriteLine("=============================");
            Console.WriteLine("Test4: Dog d = new Dog()");        //Test4:
            Dog d = new Dog();                  //In A
                                                //In D

            /*
            Dog d = new Dog(); 
            d.sound(); 

            Console.ReadKey(); 
            */

        }


        /* Result:
        =============================
        Test1: Animal a = new Animal()
        In A Static
        In A
        =============================
        Test2: Dog b = new Animal()
        =============================
        Test3: Animal c = new Dog()
        In D Static
        In A
        In D
        =============================
        Test4: Dog d = new Dog()
        In A
        In D

        */

    }
}
