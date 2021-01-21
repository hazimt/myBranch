
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//yield2
//When you use the yield contextual keyword in a statement, you indicate that the method, operator, 
//or get accessor in which it appears is an iterator.

//The following example demonstrates a get accessor that is an iterator. 
//In the example, 
//each yield return statement returns an instance of a user-defined class.

//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield



namespace TestCases
{
    public class Galaxy
    {
        public String Name { get; set; }
        public int MegaLightYears { get; set; }
    }

    public class Galaxies
    {
        public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
        {
            get
            {
                //each yield return statement returns an instance of a user-defined class.
                yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
            }
        }

        public void ShowGalaxies()
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
        }

    }




   
    public class yield2kDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");

            Galaxies sn = new Galaxies();

            sn.ShowGalaxies();

            Console.ReadLine();             
        }
    }

}

