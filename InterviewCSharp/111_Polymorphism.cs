
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Polymorphism
//Polymorphism is a Greek word, meaning "one name many forms". 
//Polymorphism provides the ability to a class to have multiple implementations with the same name.

//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield



namespace TestCases
{
    class AnimalPoly
    {
        public virtual void animalSound() {
            Console.WriteLine("The animal makes a sound");
        }
    }

    class goat: AnimalPoly 
    {
        public  override void animalSound() {//override superclass method
            Console.WriteLine("The goat says: wee wee");
        }
    }

    class DogPoly: AnimalPoly 
    {
        public override void animalSound() {//override superclass method
            Console.WriteLine("The dog says: bow wow");
        }
    }

  
    public class PolymorphismDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" ............  ");


            //You can add all objects inherited from Animal to an Animal type list
            AnimalPoly[] animals = new AnimalPoly[3]; //Creating the Animal List




            //Decalre an array
            string[] arrayName = { "name1", "name2", "name3" };   // Array
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };   // Array
            //Decalre a list
            //using System.Collections.Generic   // You need to include this!
            // 1º Method
            var myList = new List<int>();
            //OR
            List<int> myList2 = new List<int>();            




            animals[0] = new AnimalPoly(); //Add a new animal object to the list
            animals[1] = new DogPoly(); //Add a new dog object to the list
            animals[2] = new goat(); //Add a goat object to the list
            foreach (AnimalPoly a in animals)
                a.animalSound(); //This statement prints the correct string no matter the class


            Console.ReadLine();             
        }
    }

}

