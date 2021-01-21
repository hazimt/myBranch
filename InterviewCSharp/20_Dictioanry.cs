/*
How to search Dictionary using LINQ and Lambda Expression

https://www.completecsharptutorial.com/linqtutorial/linq-with-dictionary-search-using-lambda-expression.php
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class dictionaryEx
    {
        public int myDicSearchLinq()
        {
            Dictionary<string, int> productList = new Dictionary<string, int>();
 
            productList.Add("Hard Disk", 1280);
            productList.Add("Monitor", 3000);
            productList.Add("SSD Disk", 3500);
            productList.Add("RAM", 2450);
            productList.Add("Processor", 7680);
            productList.Add("Bluetooth", 540);
            productList.Add("Keyboard", 1130);
 
            //Method 1: Linq
            var search = from x in productList
                         where x.Key.Contains("Disk")
                         select x;

            //Method 2 - lambda not lampda
            //var search = productList.Where(p => p.Key.Contains("Disk"));
            
            foreach (var result in search)
            {
                Console.WriteLine("Product Name: {0}, Price: {1}", result.Key, result.Value);
            }
 
            Console.ReadKey();
            return 1;
        }

        public int myDicSearchLambda()
        {
            Dictionary<string, int> productList = new Dictionary<string, int>();
 
            productList.Add("Hard Disk", 1280);
            productList.Add("Monitor", 3000);
            productList.Add("SSD Disk", 3500);
            productList.Add("RAM", 2450);
            productList.Add("Processor", 7680);
            productList.Add("Bluetooth", 540);
            productList.Add("Keyboard", 1130);
 
            //Method 1: Linq
            /*var search = from x in productList
                         where x.Key.Contains("Disk")
                         select x;
            */
            //Method 2: lambda not lampda
            var search = productList.Where(p => p.Key.Contains("Disk"));
            
            foreach (var result in search)
            {
                Console.WriteLine("Product Name: {0}, Price: {1}", result.Key, result.Value);
            }
            Console.WriteLine();
 
            Console.ReadKey();
            return 1;
        }
        public void myDicSearchLambdaSameKey()
        {
            Dictionary<int,string> dic = new Dictionary<int, string>();

            try {
                dic.Add(12345,"Ahmad");
                dic.Add(123456, "Abas");
                dic.Add(1234, "Mike");
                dic.Add(1234, "Smith");     //This will carsh.  Same key isn't allowed in dictioanry.
            } catch (Exception e) {
                Console.WriteLine("Error: {0}", e);
            } 

            var search = dic.Where(p => p.Value.Contains("Abas"));

            foreach(var result in search)
                Console.WriteLine("Person Name: {0}, SSN: {1}", result.Key, result.Value);

        }
    }
    
    public class testCase20
    {
        //Driver Function
        public void  driverCall()
        {
            dictionaryEx sn = new dictionaryEx();

            sn.myDicSearchLambdaSameKey();

            sn.myDicSearchLinq();
            sn.myDicSearchLambda();

            Console.ReadLine();             
        }
    }

}

