
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://www.codegrepper.com/code-examples/objectivec/lambda+return+c%23

namespace TestCases
{
    public class lambdaDriver
    {
        int[] numbers = {1, 3, 5, 6, 7, 8};
    
        //----------------------------------------------------------//
        //Original expression
        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
        //This becomes a lambda:
        //(num => num % 2 == 0)

        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" ------------  ");


            bool hasEvenNumber = Array.Exists(numbers, 
                                            IsEven);
            if (hasEvenNumber)
                Console.WriteLine("Has even? {0}", hasEvenNumber);



            //----------------------------------------------------------//
            //Lambda expression
            hasEvenNumber = Array.Exists(numbers, 
                                            (int num) => num % 2 == 0 );
            if (hasEvenNumber)
                Console.WriteLine("Has even? {0}", hasEvenNumber);




            //Some code can be removed: 
            // - The modulo operator (%) is only used with numbers*/
            hasEvenNumber = Array.Exists(numbers, 
                                            (num) => num % 2 == 0 );
            if (hasEvenNumber)
                Console.WriteLine("Has even? {0}", hasEvenNumber);




            // - just one parameter, we don’t need the parentheses
            hasEvenNumber = Array.Exists(numbers, 
                                            num => num % 2 == 0 );
            if (hasEvenNumber)
                Console.WriteLine("Has even? {0}", hasEvenNumber);


            //----------------------------------------------------------//
            Console.ReadLine();             
        }
    }

}

