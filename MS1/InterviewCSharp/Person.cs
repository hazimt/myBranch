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
    class Person
    {

        //region endregion used to hide code by clicking on the + or - sign.
        #region Data or Fields without Enacpsulation
        public string Name;
        public Person[] Aquaintances;
        #endregion

        #region Methods or Functions or behaviours 
        public Person() { }

        public Person(string name, Person[] acquaintances)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.", "name");
            }

            this.Name = name;
            this.Aquaintances = acquaintances;
        }

        public bool MysteryFunction1(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.", "name");
            }

            Stack<Person> myStack = new Stack<Person>();

            foreach (Person acquaintances in this.Aquaintances)
            {
                myStack.Push(acquaintances);
            }

            do
            {
                var person = myStack.Pop();
                if (person.Name.Equals(name))
                {
                    return true;
                }

                foreach (Person acquaintances in person.Aquaintances)
                {
                    myStack.Push(acquaintances);
                }

            } while (myStack.Count >= 0);

            return false;
        }
        #endregion
    }

}
