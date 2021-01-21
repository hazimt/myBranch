
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCases
{
    class linqClass
    {
        bool debug = false;        

        public void linqEx1()
        {

            // Data source
            string[] names = {"Bill", "Steve", "James", "Mohan" };

            //https://www.w3schools.com/sql/
            
            // LINQ Query 
            var myLinqQuery = from name in names
                            where name.Contains('a')
                            select name;
                
            // Query execution
            foreach(var name in myLinqQuery)
                Console.Write(name + " ");

        }
    }
   
    public class LinkDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");

            linqClass sn = new linqClass();

            sn.linqEx1();

            Console.ReadLine();             
        }
    }

}

