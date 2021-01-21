//https://www.youtube.com/watch?v=_DY09T3cbu4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class cse_ConstructorsDemo
    {
        public static int y;
        //The field x
        public int x;
        
        //Will deal with the static var static int y field.
        //Note: You can't overload a static constructor.  
        //For static constructors you can't do like this:  public cse_ConstructorsDemo(int x)
        static cse_ConstructorsDemo()
        {
            //static Constructor called only once when the class is invoked.
            Console.WriteLine("Static Constructor");
        }

        //Will deal with the regular var non static int x field.
        public cse_ConstructorsDemo()
        {
            //every time an instace of the class is created the instance/normal constructor is called.
            Console.WriteLine("Instance or Non-static Constructor");
        }
        public cse_ConstructorsDemo(int x)
        {
            this.x = x;         //this.x refers to "The field x" above
            //every time an instace of the class is created the instance/normal constructor is called.
            Console.WriteLine("Instance or Non-static Constructor");
        }
    }



    class testCase7
    {
        public void constructorCalls()
        {
            //Before anything the static constructor is invoked.
            //In the life cycle of a class the static constructor is instansiated only ONCE  
            Console.WriteLine("Main method is called.");

            //The field x has a different values or is instanciated as many times as the class is instanciated. 
            //Here 3 times.
            cse_ConstructorsDemo d1 = new cse_ConstructorsDemo();
            cse_ConstructorsDemo d2 = new cse_ConstructorsDemo();
            cse_ConstructorsDemo d3 = new cse_ConstructorsDemo();

            //The field x has a different values or is instanciated as many times as the class is instanciated. 
            //Here 3 times.
            cse_ConstructorsDemo d4 = new cse_ConstructorsDemo(10);
            cse_ConstructorsDemo d5 = new cse_ConstructorsDemo(20);
            cse_ConstructorsDemo d6 = new cse_ConstructorsDemo(30);

            //This is how you call a static field
            Console.WriteLine(cse_ConstructorsDemo.y);
            Console.WriteLine(d4.x + " " + d4.x + " " + d5.x); 
            Console.ReadLine();            
        }
    }

}