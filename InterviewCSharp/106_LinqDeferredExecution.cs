
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Deferred execution 
//means that the evaluation of an expression 
//is delayed until its realized value 
//is actually required. 
//It greatly improves performance by avoiding unnecessary execution.

//is applicable on any in-memory collection as well as remote LINQ providers
//like LINQ-to-SQL, LINQ-to-Entities, LINQ-to-XML, etc.



//https://www.tutorialsteacher.com/linq/linq-deferred-execution


namespace TestCases
{
    class LinkDefExClass
    {
        bool debug = false;        

        public void LinkDefExEx1()
        {

            // Data source
            string[] names = {"Bill", "Steve", "James", "Mohan" };

            //1. Deferred Execution <------ Execution is NOT done here.
            // LINQ Query 
            var myLinqQuery = from name in names
                            where name.Contains('a')
                            select name;
                
            //2. Deferred Execution <------ Execution IS/is done here.
            // Query execution
            foreach(var name in myLinqQuery)        //Deferred execution means the Qurery is executed individually i.e. the Query Execution happens in every iteration of the foreach loop.
                Console.Write(name + " ");

                                                    //If this was an eager Execution then the Query will be executed all at once in the first call of the foreach for the entire query.

        }
    }
   
    public class LinkDefExDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");

            LinkDefExClass sn = new LinkDefExClass();

            sn.LinkDefExEx1();

            Console.ReadLine();             
        }
    }

}

