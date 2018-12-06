using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_explain
{
    class Animal
    {
        /*public virtual void sound() 
        { 
           Console.WriteLine("Animal sound"); 
        }*/
        public Animal() {
            Console.WriteLine("In A");
        }
        static Animal() {
            Console.WriteLine("In A Static");
        }
        public void Method() {
            Console.WriteLine("In A method");
        }
    }
    class Dog : Animal
    {
        /*public override void sound() 
        { 
            base.sound(); 
        }*/
        public Dog() { Console.WriteLine("In B"); }
        static Dog() { Console.WriteLine("In B Static"); }
        public void Method1()
        {
            Console.WriteLine("In B method");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //A.A();                        //Needs to be instantiated 
            Console.WriteLine("Test1:");            //Test1:
            Animal a = new Animal();                //In A Static
                                                    //In A

            Console.WriteLine("Test2:");
            //Dog b = new Animal();   //Error CS0266  Cannot implicitly convert type 
                                    //'Inheritance_explain.Animal' to 'Inheritance_explain.Dog'.
                                    //An explicit conversion exists (are you missing a cast?)

            Console.WriteLine("Test3:");        //Test3:
            Animal c = new Dog();               //In B Static
                                                //In A
                                                //In B

            Console.WriteLine("Test4:");        //Test4:
            Dog d = new Dog();                  //In A
                                                //In B

            /*
            Dog d = new Dog(); 
            d.sound(); 

            Console.ReadKey(); 
            */
        }
    }


}

/*
 * Test1:
In A Static
In A
Test2:
Test3:
In B Static
In A
In B
Test4:
In A
In B
*/
 
