/*
1. Describe what the MysteryFunction1 does
2. Review the code (Provide any suggestion, fixes or concerns)
3. Provide test cases to ensure code works properly
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person
            int[] list = { 1, 3, 5, 6, 8 };
            int[] temp = list;
            //Person myPers = new Person("someName", { 'a', 'b' });
            List<Person> per = new List<Person>();

            //NPerson
            NPerson nper = new NPerson("Fname", "Lname");
        }

    }
}
