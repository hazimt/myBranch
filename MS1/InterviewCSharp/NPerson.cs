//https://codereview.stackexchange.com/questions/160172/a-person-class-containing-a-list-of-persons/160174

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class NPerson
    {
        private string firstName, lastName;
        private int id;
        private static int statId;
        private static List<NPerson> NPersons = new List<NPerson>();
        public NPerson(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;

            //Like this, everytime a new object of NPerson is created, the ID will be the id of the last created object +1
            id = statId;
            statId++;

            //Everytime you create a new instance of this class, it will be added to the list
            NPersons.Add(this);

        }
        public static NPerson GetNPersonById(int id)
        {
            foreach (NPerson per in NPersons)
            {
                if (per.ID == id)
                    return per;
            }
            return null;
        }
        public int ID
        {
            get { return id; }
        }

        public static List<NPerson> GetNPersons()
        {
            return NPersons;
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
