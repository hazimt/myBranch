
using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class ListEx
    {
        bool debug = false;        

        //List equivalent to ArrayList
        public int ListOfListEx1()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ListOfListEx1   ");

            List<string> array1 = new List<string>();
            array1.Add("test1");
            array1.Add("test2");
            array1.Add("test3");

            //Can I change array1[0] location?
            array1[0] = "testChange";

            List<List<string>> array2 = new List<List<string>>();
            array2.Add(array1);

            Console.WriteLine("----------------------------------");
            Console.WriteLine(array2[0][0]);
            Console.WriteLine(array2[0][1]);


            string myStr = array2[0][0]; //Whatever indexers you want here
            myStr = array2[0][1]; //Whatever indexers you want here

            Console.WriteLine("----------------------------------");
            Console.WriteLine(array2[0][0]);
            Console.WriteLine(array2[0][1]);

            //myStr = array2[1][0]; //Whatever indexers you want here
            return 1;
        }        

        //Excellent example for list of lists
        public int ListOfListEx1_1()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ListOfListEx1_1   ");

            List<string> array1 = new List<string>();               //list
            // array1.Add(1);
            // array1.Add(2);
            // array1.Add(3);
            array1.Add("test1");
            array1.Add("test2");
            array1.Add("test3");

            List<List<string>> array2 = new List<List<string>>();       //list of lists

            //Simple: Add adds to the end of the array1.
            //**A** Done in a single line:
            array2.Add(array1);             //Same as array2[0].Add(arrya1);
            array2[0].Add(array1[0]);

            //**A** but Done in a 3 lines:
            //Exactly the same as above:  array2.Add(array1); 
            array2[0].Add(array1[0]);
            array2[0].Add(array1[1]);
            array2[0].Add(array1[2]);            


            Console.WriteLine("----------------------------------");
            Console.WriteLine(array2[0][0]);
            Console.WriteLine(array2[0][1]);
            Console.WriteLine(array2[0][2]);

            string myStr = array2[0][0]; //Whatever indexers you want here
            myStr = array2[0][1]; //Whatever indexers you want here 

            Console.WriteLine("----------------------------------");
            Console.WriteLine(myStr);

            array1 = null;
            array1 = new List<string>();
            array1.Add("test4");
            array1.Add("test5");
            array1.Add("test6");
            // array1.Add(10);
            // array1.Add(11);
            // array1.Add(12);

            //Added to the end NOT as expected replace.
            //array2.Add(array1);             //Same as array2[0].Add(arrya1);
            array2[0].Add(array1[0]);
            array2[0].Add(array1[1]);
            array2[0].Add(array1[2]);

            //Write to a specific location.
            //This is what you want.
            //To actually change array2[0] you do it this way:
            array2[0][0] = array1[0];

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(array2[0][0]);
            Console.WriteLine(array2[0][1]);
            Console.WriteLine(array2[0][2]);

            Console.WriteLine(array2[0][3]);
            Console.WriteLine(array2[0][4]);
            Console.WriteLine(array2[0][5]);





            array2[0].Append(array1[0]);
            array2[0].Append(array1[1]);
            array2[0].Append(array1[2]);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(array2[0][0]);
            Console.WriteLine(array2[0][1]);
            Console.WriteLine(array2[0][2]);

            Console.WriteLine(array2[0][3]);
            Console.WriteLine(array2[0][4]);
            Console.WriteLine(array2[0][5]);



            //myStr = array2[1][0]; //Whatever indexers you want here
            return 1;
        }        



        //Semi Works
        //Excellent example for list of lists
        public int ListOfListEx1_1_NameChange()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ListOfListEx1_1   ");

            List<string> Reportee = new List<string>();               //list
            // Reportee.Add(1);
            // Reportee.Add(2);
            // Reportee.Add(3);
            Reportee.Add("test1");
            Reportee.Add("test2");
            Reportee.Add("test3");
            //Change Reportee by index
            Reportee[0] = "sqBq";

            List<List<string>> ManagersList = new List<List<string>>();       //list of lists

            //Simple: Add adds to the end of the Reportee.
            //**A** Done in a single line:
            ManagersList.Add(Reportee);             //Same as ManagersList[0].Add(arrya1);
            //Fails
            //ManagersList[1].Add(Reportee[0]);

            //**A** but Done in a 3 lines:
            //Exactly the same as above:  ManagersList.Add(Reportee); 
            ManagersList[0].Add(Reportee[0]);
            ManagersList[0].Add(Reportee[1]);
            ManagersList[0].Add(Reportee[2]);            


            Console.WriteLine("----------------------------------");
            Console.WriteLine(ManagersList[0][0]);
            Console.WriteLine(ManagersList[0][1]);
            Console.WriteLine(ManagersList[0][2]);

            string myStr = ManagersList[0][0]; //Whatever indexers you want here
            myStr = ManagersList[0][1]; //Whatever indexers you want here 

            Console.WriteLine("----------------------------------");
            Console.WriteLine(myStr);

    
            Reportee = null;
            ManagersList = null;

            Reportee = new List<string>();
            Reportee.Add("test4");
            Reportee.Add("test5");
            Reportee.Add("test6");
            // Reportee.Add(10);
            // Reportee.Add(11);
            // Reportee.Add(12);

            //Added to the end NOT as expected replace.
            //ManagersList.Add(Reportee);             //Same as ManagersList[0].Add(arrya1);
            ManagersList[0].Add(Reportee[0]);
            ManagersList[0].Add(Reportee[1]);
            ManagersList[0].Add(Reportee[2]);

            //Write to a specific location.
            //This is what you want.
            //To actually change ManagersList[0] you do it this way:
            ManagersList[0][0] = Reportee[0];

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[0][0]);
            Console.WriteLine(ManagersList[0][1]);
            Console.WriteLine(ManagersList[0][2]);

            Console.WriteLine(ManagersList[0][3]);
            Console.WriteLine(ManagersList[0][4]);
            Console.WriteLine(ManagersList[0][5]);





            ManagersList[0].Append(Reportee[0]);
            ManagersList[0].Append(Reportee[1]);
            ManagersList[0].Append(Reportee[2]);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[0][0]);
            Console.WriteLine(ManagersList[0][1]);
            Console.WriteLine(ManagersList[0][2]);

            Console.WriteLine(ManagersList[0][3]);
            Console.WriteLine(ManagersList[0][4]);
            Console.WriteLine(ManagersList[0][5]);



            //myStr = ManagersList[1][0]; //Whatever indexers you want here
            return 1;
        }        





        //Excellent example for list of lists
        //Works 100%
        public int ListOfListEx1_2_NameChange()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ListOfListEx1_2_NameChange   ");

            int i = 0; int j = 0;

//Block 0 ---------------------------------------------
            List<string> Reportee = new List<string>();               //list
            Reportee.Add("0");

            List<List<string>> ManagersList = new List<List<string>>();       //list of lists

            //Simple: Add adds to the end of the Reportee.
            //**A** Done in a single line:

            //Will add to ManagersList[0]
            ManagersList.Add(Reportee);             //Same as ManagersList[0].Add(arrya1);
            //Fails
            //ManagersList[1].Add(Reportee[0]);

            //**A** but Done in a 3 lines:
            //Exactly the same as above:  ManagersList.Add(Reportee); 
            //Will add to ManagersList[1]
            //ManagersList.Add(Reportee);

            Console.WriteLine("----------------------------------");
            Console.WriteLine(Reportee[0]);
            Console.WriteLine(ManagersList[0][0]);

            Console.WriteLine("----------------------------------");
    
//Block 1 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("2");
            Reportee.Add("3");
            Reportee.Add("4");

            //Fails
            //ManagersList[1].Add(Reportee[0]);
            //Will add to ManagersList[1]
            ManagersList.Add(Reportee);

            Console.WriteLine("----------------------------------");
            Console.WriteLine(Reportee[0]);
            Console.WriteLine(ManagersList[1][2]);

            Console.WriteLine("----------------------------------");
    


//Block 2 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("5");
            Reportee.Add("6");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[0][0]);
            Console.WriteLine(ManagersList[2][1]);

            //print the list (ManagersList) tree.
            Console.WriteLine("Print the tree:");
            for (i = 0; i < ManagersList.Count; i++)
            {
                int c = ManagersList[i].Count;
                Console.Write("Manager [" + i + "]: ");
                for (j = 0; j < c; j++)
                    Console.Write(ManagersList[i][j] + ", ");
                Console.WriteLine();
            }

            //print the list (ManagersList) tree. 
            //Using foreach example.
            Console.WriteLine("Print the tree:");
            i = 0; j = 0;
            foreach (List<string> rlist in ManagersList) {
                j=0;
                Console.Write("r: " + rlist + ": ");
                Console.Write("r: " + rlist[0] + ": ");
                foreach (string r in rlist) {
                    Console.Write(" " + r.ToString());
                    //For verification.
                    if (processJasonFile.debug)
                        Console.WriteLine(ManagersList[i][j++]);
                }
                Console.WriteLine();
                i++;
            }

            //myStr = ManagersList[1][0]; //Whatever indexers you want here
            return 1;
        }        





        //Works for Managers[0], Managers[1], Managers[2], Managers[3] etc .... 
        public int ListOfListEx1_2()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ListOfListEx1_2   ");

            List<Nodetest> myNode1 = new List<Nodetest>();
            List<List<Nodetest>> myNode2 = new List<List<Nodetest>>();

            List<string> arrayB = new List<string>();   //The second to the left array horizontal
            // array1.Add(1);
            // array1.Add(2);
            // array1.Add(3);
            arrayB.Add("test1");
            arrayB.Add("test2");
            arrayB.Add("test3");
            //myNode1.Manager[0].Add(1);
            //new User() { Name = "John Doe", Age = 42 },


            //arr.Add(new ArrayList(new[] { "value 1.1", "value 1.2" }));
            List<List<string>> arrayA = new List<List<string>>();

            Console.WriteLine("----------------------------------");
            // Console.WriteLine(arrayA[0][0]);
            // Console.WriteLine(arrayA[0][1]);

            Console.WriteLine("----------------------------------");
            // Console.WriteLine(arrayA[0][0]);
            // Console.WriteLine(arrayA[0][1]);

            arrayB = new List<string>();
            arrayB.Add("1");
            arrayB.Add("2");
            arrayB.Add("3");
            Console.WriteLine(arrayB[0]);
            Console.WriteLine(arrayB[1]);
            Console.WriteLine(arrayB[2]);

            arrayA.Add(arrayB);
            arrayA.Add(arrayB);
            arrayA.Add(arrayB);
            // array1.Add(10);
            // array1.Add(11);
            // array1.Add(12);
            Console.WriteLine(arrayA[0][0]);
            Console.WriteLine(arrayA[1][0]);
            Console.WriteLine(arrayA[2][0]);

            // arrayA[0].Add(arrayB[0]);
            // arrayA[0].Add(arrayB[1]);
            // arrayA[0].Add(arrayB[2]);

            Console.WriteLine("-------------CHeck---------------------");
            // Console.WriteLine(arrayB[0][0]);
            // Console.WriteLine(arrayB[0][1]);
            // Console.WriteLine(arrayB[0][2]);

            //string myStr = arrayA[0][0]; //Whatever indexers you want here
            //myStr = arrayA[0][1]; //Whatever indexers you want here

            //myStr = array2[1][0]; //Whatever indexers you want here
            return 1;
        }        

        public void ListOfListEx2()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ListOfListEx2   ");

            int count = 3;
            List<string> arrayA = new List<string>();
            //ArrayList arrayA = new ArrayList();
            //arrayA.Add("test1");
            Console.WriteLine("-----------------2-----------------");
            for (int i = 1; i < count; i++)
            {
                // for (int j = 1; j < 3; j++)
                //     //List<List<string>> arrayB = new List<List<string>>();
                //     arrayA.Add(new List(new[] {""}));

                // for (int j = 1; j < 3; j++)
                //     arrayA.Add(new ArrayList(new[] { "value " + j++, "value " + j++}));
            }            
        }

        public void ListOfListEx3()
        {
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            Console.WriteLine(" ListOfListEx3   ");

            List<UserL> listOfUsers = new List<UserL>()
            {
                new UserL() { Name = "John Doe", Age = 42 },
                new UserL() { Name = "Jane Doe", Age = 39 },
                new UserL() { Name = "Joe Doe", Age = 13 },
            };

            //listOfUsers. = new User() { Name = "Joe Doe", Age = 13 };

            listOfUsers.Sort(CompareUsers);
            
            foreach (UserL user in listOfUsers)
                Console.WriteLine(user.Name + ": " + user.Age + " years old");            
        }
        public int CompareUsers(UserL user1, UserL user2)
        {
            return user1.Age.CompareTo(user2.Age);
        }

        public void ListOfListEx4()
        {
            int count = 1;

//myNode - Main
            // List<TreeNode> myNode = new List<TreeNode>();
            // for (int i = 0; i < 5; i++)
            // {
//treeNode
            //     TreeNode treeNode = new TreeNode();
//populate treeNode - sub
            //     treeNode.id = count++;
            //     treeNode.name = "Label1";
            //     treeNode.leaf = false;
//----------------------------------------------------------------
                    //     for (int j = 0; j < 5; j++)
                    //     {
        //node1 - sub
                    //         TreeNode node1 = new TreeNode();
                    //         node1.id = count++;
                    //         node1.name = "label2";
                    //         node1.leaf = true;

        //Level1 - Main //node1 - sub
                    //         treeNode.children.Add(node1);
//----------------------------------------------------------------
//populate myNode
            //         myNode.Add(treeNode);
            //     }
            // }
        }



    }

    public class UserL
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }    

    public class NodetestL
    {
        public static int n;
        public int Manager { get; set; } 
        public int Employee { get; set; } 
        public ArrayList SameManager = new ArrayList();
        public Nodetest[] SameManager2 = new Nodetest[n];
    }

    public class TreeNodeL
    {
        public int id { get; set; }
        public string name {get; set; }
        public bool leaf {get; set; }            
    }

    
    public class ListExDriver
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" 100_ArrayList.cs  ");

            ListEx sn = new ListEx();

            sn.ListOfListEx1();
            //This one.
            //sn.ListOfListEx1_1();
            //sn.ListOfListEx1_1_NameChange();
            sn.ListOfListEx1_2_NameChange();

            sn.ListOfListEx2();
            sn.ListOfListEx1_2();
            sn.ListOfListEx3();

            Console.ReadLine();             
        }
    }

}

