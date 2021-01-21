//https://java2blog.com/lowest-common-ancestor-n-ary-tree/

//https://stackoverflow.com/questions/40675162/install-a-nuget-package-in-visual-studio-code
//Nuget

/*
Output

Programs: Hello World!
Done
 32_GeneralNodeTree.cs
The size of the org chart is: 18
Root: 1
First & Child Node: 1, 2
___________________________________________________
2, 1
3, 1
4, 1
5, 2
6, 2
7, 3
8, 4
9, 4
10, 4
11, 5
12, 11
13, 11
14, 7
15, 7
16, 15
17, 15
18, 15
21, 18
___________________________________________________
i: 0: Manager: 1, Employee: 2
i: 1: Manager: 1, Employee: 3
i: 2: Manager: 1, Employee: 4
i: 3: Manager: 2, Employee: 5
i: 4: Manager: 2, Employee: 6
i: 5: Manager: 3, Employee: 7
i: 6: Manager: 4, Employee: 8
i: 7: Manager: 4, Employee: 9
i: 8: Manager: 4, Employee: 10
i: 9: Manager: 5, Employee: 11
i: 10: Manager: 11, Employee: 12
i: 11: Manager: 11, Employee: 13
i: 12: Manager: 7, Employee: 14
i: 13: Manager: 7, Employee: 15
i: 14: Manager: 15, Employee: 16
i: 15: Manager: 15, Employee: 17
i: 16: Manager: 15, Employee: 18
i: 17: Manager: 18, Employee: 21
___________________________________________________
Plesae provide the names of the values of the two children nodes:


*/


using System;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestCases
{
    public class orgListList : List<orgList> { }  

    public class orgList : List<org> { }

    public class org
    {
        public int Manager { get; set; }
        public string Employee { get; set; }
    }




    public class Orgchart    {
        public string Manager { get; set; } 
        public string Employee { get; set; } 
    }

    public class Root    {
        public List<Orgchart> orgchart { get; set; } 
        public int count { get; set; } 
    }





   

    public static class GlobalVar
    {
        public const string JASONFILEPATH = @"C:\Users\Mars\source\myBranch\InterviewCSharp\InterviewQuestionsVisualCode\32_OrgChart.json";
    }

    //Copy the jason file in 32_OrgChart.json to https://json2csharp.com/json-to-csharp 
    //It will generate the below class 
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Node {
        public string Manager { get; set; } 
        public string Employee { get; set; } 
    }

    public class ListNode : List<Node> {}
    
    //https://csharp.net-tutorials.com/collections/lists/
    //Simple List class example

    public class processJasonFile
    {
        public static bool debug = false;
        //public List<Node> readjason(string jasonFilePath, ref Node root)
        public List<Node> readjason(string jasonFilePath, ref String root)
        {
            Node node = new Node();

            try
            {
                //RootObject rootObj= JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(pathFile));
                List<Node> myNode = JsonConvert.DeserializeObject<List<Node>>(File.ReadAllText(jasonFilePath));
                
                Console.Write("The size of the org chart is: ");
                Console.WriteLine(myNode.Count());
                Console.WriteLine("Root: {0}", myNode[0].Manager);
                //Root
                string str = myNode[0].Manager;
                root = str;
                Console.WriteLine("First & Child Node: {0}, {1}", myNode[0].Manager, myNode[0].Employee);
                
                return myNode;

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }      
        }

        public void printTreeNode(List<Node> myNode)
        {
            //Example1 Sample#1 print nodes
            Console.WriteLine("___________________________________________________");
            foreach (Node nodeItems in myNode)
                Console.WriteLine("{0}, {1}", nodeItems.Employee, nodeItems.Manager);

            Console.WriteLine("___________________________________________________");
            //Example2 Sample#2 print nodes
            for(int i = 0; i < myNode.Count; i++)
            {
                Console.WriteLine("i: " + i + ": Manager: " + myNode[i].Manager + ", Employee: " + myNode[i].Employee);
            }
            Console.WriteLine("___________________________________________________");
        }


        public void printTreeNodeListOfList(List<List<string>> myNode)
        {
            int i = 0; int j = 0;
            //Example1 Sample#1 print nodes

            Console.WriteLine("___________________________________________________");
            //Example2 Sample#2 print nodes
            for(i = 0; i < myNode.Count; i++) {
                Console.Write("i: " + i + ": Employee: ");
                for (j = 0; j < myNode[i].Count; j++) {
                    Console.Write(" " + myNode[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("___________________________________________________");
        }


        public void printTreeNodeListOfList(List<List<int>> myNode)
        {
            int i = 0; int j = 0;
            //Example1 Sample#1 print nodes

            Console.WriteLine("___________________________________________________");
            //Example2 Sample#2 print nodes
            for(i = 0; i < myNode.Count; i++) {
                Console.Write("i: " + i + ": Employee: ");
                for (j = 0; j < myNode[i].Count; j++) {
                    Console.Write(" " + myNode[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("___________________________________________________");
        }



        //https://www.google.com/search?q=C%23+read+a+json+file+one+record+at+a+time&oq=C%23+read+a+json+file+one+record+at+a+time&aqs=chrome..69i57j69i58.7344j0j7&sourceid=chrome&ie=UTF-8
        //https://stackoverflow.com/questions/14934360/how-to-deserialize-json-string-to-object-list-in-c-sharp-dot
        //public List<Node> readjason(string jasonFilePath, ref Node root)
        public Root readjasonListOfList(string jasonFilePath, ref String root)
        {
            Node node = new Node();

            try
            {
                //RootObject rootObj= JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(pathFile));
                //List<Node> myNode = JsonConvert.DeserializeObject<List<Node>>(File.ReadAllText(jasonFilePath));
                jasonFilePath = @"C:\Users\Mars\source\myBranch\InterviewCSharp\InterviewQuestionsVisualCode\32_OrgChartArrayList.json";

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(File.ReadAllText(jasonFilePath)); 
                

                Console.Write("The size of the org chart is: ");
                Console.WriteLine(myDeserializedClass.count);
                Console.WriteLine("Root: {0}", myDeserializedClass.orgchart[0].Manager[0]);
                //Root
                
                char a = myDeserializedClass.orgchart[0].Manager[0];
                //root = (int)char.GetNumericValue(a);
                root = (String)char.ToString(a);
                root = a.ToString();
                Console.WriteLine("First & Child Node: {0}, {1}", root, myDeserializedClass.orgchart[0].Employee[0]);

                Console.Write("Manager & Employee: ");
                Console.Write(myDeserializedClass.orgchart[0].Manager[0]);
                Console.WriteLine(" & {0}", myDeserializedClass.orgchart[0].Employee[0]);

                if (debug) {                
                    Console.Write(myDeserializedClass.orgchart[1].Manager[0]);
                    Console.WriteLine(" & {0}", myDeserializedClass.orgchart[1].Employee[0]);

                    Console.Write(myDeserializedClass.orgchart[2].Manager[0]);
                    Console.WriteLine(" & {0}", myDeserializedClass.orgchart[2].Employee[0]);
                }

                return myDeserializedClass;

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }      
        }


        public void printTreeListOfListNode(Root myRoot)
        {
               //Example1 Sample#1 print nodes
                // Console.WriteLine("___________________________________________________");
                // foreach (Root nodeItems in myRoot)
                //     Console.WriteLine("{0}, {1}", nodeItems.orgchart[0].Employee[0], nodeItems.orgchart[0]);

                // Console.WriteLine("Root: {0}", myDeserializedClass.orgchart[0].Manager[0]);
                // //Root
                
                Console.WriteLine("___________________________________________________");
                //Example2 Sample#2 print nodes
                for(int i = 0; i < myRoot.count; i++)
                {
                    Console.WriteLine("i: " + i + ": Manager: " + myRoot.orgchart[i].Manager[0] + ", Employee: " + myRoot.orgchart[i].Employee[0]);
                }
                Console.WriteLine("___________________________________________________");
        }


        public void listToListOfListConversion(Root myRoot)
        {
               //Example1 Sample#1 print nodes
                // Console.WriteLine("___________________________________________________");
                // foreach (Root nodeItems in myRoot)
                //     Console.WriteLine("{0}, {1}", nodeItems.orgchart[0].Employee[0], nodeItems.orgchart[0]);

                // Console.WriteLine("Root: {0}", myDeserializedClass.orgchart[0].Manager[0]);
                // //Root


                Console.WriteLine("___________________________________________________");
                //Example2 Sample#2 print nodes
                for(int i = 0; i < myRoot.count; i++)
                {
                    Console.WriteLine("i: " + i + ": Manager: " + myRoot.orgchart[i].Manager[0] + ", Employee: " + myRoot.orgchart[i].Employee[0]);
                }
                Console.WriteLine("___________________________________________________");

                if (myRoot.count < 2) 
                    return;

                List<Node> myNodeParent = new List<Node>();

                Console.WriteLine("___________________________________________________");
                //Example2 Sample#2 print nodes
                int a = 0; int b = 0;
                
                //Read myRoot
                //Setup
                Console.WriteLine("Start Reading");
                //int currentManager = (int)Char.GetNumericValue(myRoot.orgchart[0].Manager[0]);
                //int NextManager = (int)Char.GetNumericValue(myRoot.orgchart[1].Manager[0]);

                int currentEmployee = (int)Char.GetNumericValue(myRoot.orgchart[0].Employee[0]);
                int NextEmployee = (int)Char.GetNumericValue(myRoot.orgchart[1].Employee[0]);

                //First populate the first index:
                //myNode[0].Manager.currentManager;
                //myNode[currentManager].Add(currentEmployee);

                Console.WriteLine("Start Writing");

                // List<TreeNode> myNode = new List<TreeNode>();
                // TreeNode treeNode = new TreeNode();

                // treeNode.id = count++;
                // treeNode.name = MyData.labelName;
                // treeNode.leaf = false;  

                // List<Node> firstStack = new List<Node>();
                // firstStack.Add(tree);
                // List<List<Node>> childListStack = new List<List<Node>>();
                // childListStack.Add(firstStack);

                //Create a node of type Node to insert.
                Node treeNode = new Node();
                // treeNode.Manager  = currentManager;
                // treeNode.Employee = currentEmployee;

                myNodeParent.Add(treeNode);

                List<List<Node>> sameManagerListChild = new List<List<Node>>();
                sameManagerListChild.Add(myNodeParent);

                //Scan myRoot for the same Manager
                int currentManager = (int)Char.GetNumericValue(myRoot.orgchart[0].Manager[0]);
                int NextManager = (int)Char.GetNumericValue(myRoot.orgchart[1].Manager[0]);
goto skipthis1;
                int j = 1;
                for (int i = 0; i < myRoot.count; i++) {
                    currentManager = (int)Char.GetNumericValue(myRoot.orgchart[i].Manager[0]);
                    NextManager = (int)Char.GetNumericValue(myRoot.orgchart[i].Manager[0]);                        
                    if (myRoot.orgchart[i].Manager != null)
                    {
                        if (currentManager == NextManager)
                            j++;
                        else
                        {
                            List<Node> sameManagerChild = sameManagerListChild[j];
                            while(j > 0) 
                            {
                                Node mytreeNode = new Node();
                                mytreeNode.Manager  = myRoot.orgchart[i].Manager;
                                mytreeNode.Employee = myRoot.orgchart[i].Employee;

                                sameManagerChild.Add(mytreeNode);
                                j--;
                            }
                            j = 0;
                        }

                        //Console.WriteLine(i + ": " + myRoot.orgchart[i].Manager[j]);
                        //Console.WriteLine(i + ": " + myRoot.orgchart[i].Employee[j]);
                    }
                }
                currentEmployee = (int)Char.GetNumericValue(myRoot.orgchart[0].Employee[0]);
                NextEmployee = (int)Char.GetNumericValue(myRoot.orgchart[1].Employee[0]);                 
skipthis1:
                //List<Node> childStack = sameManagerListChild[sameManagerListChild.Count - 1];

            //         Level1.Add(node1);
            //         treeNode.children = Level1;
            //         myNode.Add(treeNode);
                
                

                // myNodeParent[0] = new Node() { Manager = -1, Employee = -1 };
                // myNodeParent[currentManager] = new Node() { Manager = currentManager, Employee = currentEmployee };
                // myNodeParent[currentManager] = new Node() { Manager = currentManager+1, Employee = currentEmployee+1 };

                Console.WriteLine("myNodeParent[0]: " + myNodeParent[0]);
                Console.WriteLine("myNodeParent[0]: " + myNodeParent[0].Manager);
                Console.WriteLine("myNodeParent[0]: " + myNodeParent[0].Employee);

                Console.WriteLine("___________________________________________________");
                //Example2 Sample#2 print nodes
                for(int i = 0; i < myRoot.count; i++)
                {
                    Console.WriteLine("i: " + i + ": Manager: " + myRoot.orgchart[i].Manager[0] + ", Employee: " + myRoot.orgchart[i].Employee[0]);
                }
                Console.WriteLine("___________________________________________________");

goto skipthis2;
                j = 0;
                for (int i = 0; i < myRoot.count; i++) {
                    while (myRoot.orgchart[i].Manager != null) 
                    {
                        Console.WriteLine(i + ": " + myRoot.orgchart[i].Manager[j]);
                        Console.WriteLine(i + ": " + myRoot.orgchart[i].Employee[j]);
                        j++;
                    }
                }
                


                for(int i = 0; i < myRoot.count; i++)
                {
                    while (currentManager == NextManager)
                    {
                        //myNodeParent[i] = new Node() { Manager = 1, Employee = 42 };
                        currentManager = (int)Char.GetNumericValue(myRoot.orgchart[i].Manager[0]);
                        currentEmployee = (int)Char.GetNumericValue(myRoot.orgchart[i].Employee[0]);
                    }

                    //Console.WriteLine("i: " + i + ": Manager: " + myRoot.orgchart[i].Manager[0] + ", Employee: " + myRoot.orgchart[i].Employee[0]);
                }
skipthis2:                
                Console.WriteLine("___________________________________________________");
        }







        //public void populateRoot(Root myRoot)
        public List<List<string>> populateRootString()
        {
            List<string> Reportee = new List<string>();
            //arr.Add(new ArrayList(new[] { "value 1.1", "value 1.2" }));
            List<List<string>> ManagersList = new List<List<string>>();

            int i = 0; int j = 0;

            //Manager 0
//Block 0 ---------------------------------------------
            Reportee.Add("0");

            //Will add to ManagersList[0]
            ManagersList.Add(Reportee);             //Same as ManagersList[0].Add(arrya1);
            //Fails
            //ManagersList[1].Add(Reportee[0]);

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


//Block 3 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("7");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[3][0]);



//Block 4 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("8");
            Reportee.Add("9");
            Reportee.Add("10");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[4][2]);


//Block 5 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("11");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[5][0]);

//Block 6 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("0");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[6][0]);

//Block 7 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("14");
            Reportee.Add("15");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[7][1]);


//Block 8-10 ---------------------------------------------
            //Blank
            for (i = 8; i < 11; i++) {
                Reportee = null;
                Reportee = new List<string>();
                Reportee.Add("0");

                //Will add to ManagersList[2]
                ManagersList.Add(Reportee);

                Console.WriteLine("-------------CHeck---------------------");
                Console.WriteLine(ManagersList[i][0]);
            }


//Block 11 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("12");
            Reportee.Add("13");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[11][1]);


//Block 12-14 ---------------------------------------------
            //Blank
            for (i = 12; i < 15; i++) {
                Reportee = null;
                Reportee = new List<string>();
                Reportee.Add("0");

                //Will add to ManagersList[2]
                ManagersList.Add(Reportee);

                Console.WriteLine("-------------CHeck---------------------");
                Console.WriteLine(ManagersList[i][0]);
            }


//Block 15 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("16");
            Reportee.Add("17");
            Reportee.Add("18");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[15][2]);



//Block 16-17 ---------------------------------------------
            //Blank
            for (i = 16; i < 18; i++) {
                Reportee = null;
                Reportee = new List<string>();
                Reportee.Add("0");

                //Will add to ManagersList[2]
                ManagersList.Add(Reportee);

                Console.WriteLine("-------------CHeck---------------------");
                Console.WriteLine(ManagersList[i][0]);
            }



//Block 18 ---------------------------------------------
            Reportee = null;

            Reportee = new List<string>();
            Reportee.Add("21");

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[18][0]);






            if (debug)
                Console.WriteLine(ManagersList[0][0]);






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
                Console.Write("r: " + i);
                foreach (string r in rlist) {
                    Console.Write(" " + r.ToString());
                    //For verification.
                    if (processJasonFile.debug)
                        Console.WriteLine(ManagersList[i][j++]);
                }
                Console.WriteLine();
                i++;
            }

            // int NoOfParentsFromJsonFile = 9;
            // int NoOfChildrenFromJsonFile = 0;
            // Console.WriteLine("-----------------2-----------------");
            // for (int i = 1; i < NoOfParentsFromJsonFile; i++)
            // {
            //     for (int j = 1; j < NoOfChildrenFromJsonFile; j++)
            //     {
            //         //tree(new ArrayList(new[] { "value " + j++, "value " + j++}));
            //         tree[i] = new ArrayList();
            //             //new Node() { Manager = "1", Employee = "2"}
                    
            //         //new Node() { Manager = "1", Employee = "2" };
            //     }
            // }

            return ManagersList;
        }



        //public void populateRoot(Root myRoot)
        public List<List<int>> populateRoot()
        {
            List<int> Reportee = new List<int>();
            //arr.Add(new ArrayList(new[] { "value 1.1", "value 1.2" }));
            List<List<int>> ManagersList = new List<List<int>>();

            int i = 0; int j = 0;

            //Manager 0
//Block 0 ---------------------------------------------
            Reportee.Add(0);

            //Will add to ManagersList[0]
            ManagersList.Add(Reportee);             //Same as ManagersList[0].Add(arrya1);
            //Fails
            //ManagersList[1].Add(Reportee[0]);

            Console.WriteLine("----------------------------------");
            Console.WriteLine(Reportee[0]);
            Console.WriteLine(ManagersList[0][0]);

            Console.WriteLine("----------------------------------");
    

//Block 1 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(2);
            Reportee.Add(3);
            Reportee.Add(4);

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

            Reportee = new List<int>();
            Reportee.Add(5);
            Reportee.Add(6);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[0][0]);
            Console.WriteLine(ManagersList[2][1]);


//Block 3 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(7);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[3][0]);



//Block 4 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(8);
            Reportee.Add(9);
            Reportee.Add(10);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[4][2]);


//Block 5 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(11);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[5][0]);

//Block 6 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(0);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[6][0]);

//Block 7 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(14);
            Reportee.Add(15);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[7][1]);


//Block 8-10 ---------------------------------------------
            //Blank
            for (i = 8; i < 11; i++) {
                Reportee = null;
                Reportee = new List<int>();
                Reportee.Add(0);

                //Will add to ManagersList[2]
                ManagersList.Add(Reportee);

                Console.WriteLine("-------------CHeck---------------------");
                Console.WriteLine(ManagersList[i][0]);
            }


//Block 11 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(12);
            Reportee.Add(13);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[11][1]);


//Block 12-14 ---------------------------------------------
            //Blank
            for (i = 12; i < 15; i++) {
                Reportee = null;
                Reportee = new List<int>();
                Reportee.Add(0);

                //Will add to ManagersList[2]
                ManagersList.Add(Reportee);

                Console.WriteLine("-------------CHeck---------------------");
                Console.WriteLine(ManagersList[i][0]);
            }


//Block 15 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(16);
            Reportee.Add(17);
            Reportee.Add(18);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[15][2]);



//Block 16-17 ---------------------------------------------
            //Blank
            for (i = 16; i < 18; i++) {
                Reportee = null;
                Reportee = new List<int>();
                Reportee.Add(0);

                //Will add to ManagersList[2]
                ManagersList.Add(Reportee);

                Console.WriteLine("-------------CHeck---------------------");
                Console.WriteLine(ManagersList[i][0]);
            }



//Block 18 ---------------------------------------------
            Reportee = null;

            Reportee = new List<int>();
            Reportee.Add(21);

            //Will add to ManagersList[2]
            ManagersList.Add(Reportee);

            Console.WriteLine("-------------CHeck---------------------");
            Console.WriteLine(ManagersList[18][0]);






            if (debug)
                Console.WriteLine(ManagersList[0][0]);






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
            foreach (List<int> rlist in ManagersList) {
                j=0;
                Console.Write("r: " + i);
                foreach (int r in rlist) {
                    Console.Write(" " + r.ToString());
                    //For verification.
                    if (processJasonFile.debug)
                        Console.WriteLine(ManagersList[i][j++]);
                }
                Console.WriteLine();
                i++;
            }

            // int NoOfParentsFromJsonFile = 9;
            // int NoOfChildrenFromJsonFile = 0;
            // Console.WriteLine("-----------------2-----------------");
            // for (int i = 1; i < NoOfParentsFromJsonFile; i++)
            // {
            //     for (int j = 1; j < NoOfChildrenFromJsonFile; j++)
            //     {
            //         //tree(new ArrayList(new[] { "value " + j++, "value " + j++}));
            //         tree[i] = new ArrayList();
            //             //new Node() { Manager = "1", Employee = "2"}
                    
            //         //new Node() { Manager = "1", Employee = "2" };
            //     }
            // }

            return ManagersList;
        }




        //Bug: notworking
        static int lca = -1;
        public static bool getLCA(int index, List<List<int>> tree, int sNode1, int sNode2)
        {
            /* if current node is equal to one of the nodes whose lca 
            we are finding, then it is a potential candidate for 
            being the lca.
            */
            bool self = index == sNode1 || index == sNode2 ? true : false;

            int count = 0;
            // for (int child : tree[node]) {
            //     if (getLCA(child, tree, u, v)) {
            //         count++;
            //     }
            // }
            
            /* recurring for every child. and keeping a count of result
            of how many times we are getting true.
            */
            String str;
            Console.WriteLine("Count: " + tree[index].Count);
            foreach (int child in tree[index]) {
                if (getLCA(child, tree, sNode1, sNode2))
                    count++;                
            }

            for (int i = 0; i < tree[index].Count; i++)
            {
                int child = tree[index][i];
                if (getLCA(child, tree, sNode1, sNode2))
                    count++;
                //Console.WriteLine("Manager: " + tree[i].Manager + ", Employee: " + tree[i].Employee);
            }

            // foreach (Node child in tree)
            //     if (getLCA(child.Manager, tree, child1, child2))
            //         count++;

            /* this is the main check, if current node itself is one of 
            the node whose lca is to be found and its getting true from 
            any of its child, then surely it is LCA of given nodes.
            also, if we get true from exactly two sides, this means 
            that current node is the node after which the path for 
            both nodes diverge, and hence it is the LCA for given nodes.
            */ 
            if (((self && count == 1) || (count == 2))) {
                /* lca will be set only once, as the parent of
                lca will have the count==2 condition as true,
                but that is not the correct answer.
                */
                if (lca == -1) {
                    lca = index;
                }
                return true;
            }
            /* current node will return true only if either the 
            current node is one of the given nodes, or one of its 
            children return true for count == 2, we already handled it
            while setting LCA.
            */

            return self || count == 1;
        }


        //Bug: notworking
        public static bool getLCAStr(int index, string cnode, List<String> tree, String child1, String child2)
        {
            /* if current node is equal to one of the nodes whose lca 
            we are finding, then it is a potential candidate for 
            being the lca.
            */
            bool self = cnode == child1 || cnode == child2 ? true : false;

            int count = 0;
            // for (int child : tree[node]) {
            //     if (getLCA(child, tree, u, v)) {
            //         count++;
            //     }
            // }
            
            /* recurring for every child. and keeping a count of result
            of how many times we are getting true.
            */
            String str;
            Console.WriteLine("Count: " + tree[index].Count());
            for (int i = 0; i < tree[index].Count(); i++)
            {
                if (getLCAStr(index++, cnode, tree, child1, child2))
                    count++;
                //Console.WriteLine("Manager: " + tree[i].Manager + ", Employee: " + tree[i].Employee);
            }

            // foreach (Node child in tree)
            //     if (getLCA(child.Manager, tree, child1, child2))
            //         count++;

            /* this is the main check, if current node itself is one of 
            the node whose lca is to be found and its getting true from 
            any of its child, then surely it is LCA of given nodes.
            also, if we get true from exactly two sides, this means 
            that current node is the node after which the path for 
            both nodes diverge, and hence it is the LCA for given nodes.
            */ 
            if (((self && count == 1) || (count == 2))) {
                /* lca will be set only once, as the parent of
                lca will have the count==2 condition as true,
                but that is not the correct answer.
                */
                if (lca == -1) {
                    lca = index;
                }
                return true;
            }
            /* current node will return true only if either the 
            current node is one of the given nodes, or one of its 
            children return true for count == 2, we already handled it
            while setting LCA.
            */

            return self || count == 1;
        }

        //https://stackoverflow.com/questions/55361628/how-do-i-print-out-a-tree-structure-in-c/55364949
        //https://stackoverflow.com/questions/1649027/how-do-i-print-out-a-tree-structure.
        // public class Node
        // {
        //     public string Name; // method name
        //     public decimal Time; // time spent in method
        //     public List<Node> Children;
        // }
        public void PrintTree(Node tree)
        {
            List<Node> firstStack = new List<Node>();
            firstStack.Add(tree);

            List<List<Node>> childListStack = new List<List<Node>>();
            childListStack.Add(firstStack);

            while (childListStack.Count > 0)
            {
                List<Node> childStack = childListStack[childListStack.Count - 1];

                if (childStack.Count == 0)
                {
                    childListStack.RemoveAt(childListStack.Count - 1);
                }
                else
                {
                    tree = childStack[0];
                    childStack.RemoveAt(0);

                    string indent = "";
                    for (int i = 0; i < childListStack.Count - 1; i++)
                    {
                        indent += (childListStack[i].Count > 0) ? "|  " : "   ";
                    }

                    Console.WriteLine(indent + "+- " + tree.Manager);

                    if (tree.Employee != "0")
                    {
                        //childListStack.Add(new List<Node>(tree.Employee));
                    }
                }
            }
        }
        
    }


    
        // public void PrintTree(Node tree)
        // {
        //     List<Node> firstStack = new List<Node>();
        //     firstStack.Add(tree);

        //     List<List<Node>> childListStack = new List<List<Node>>();
        //     childListStack.Add(firstStack);

        //     while (childListStack.Count > 0)
        //     {
        //         List<Node> childStack = childListStack[childListStack.Count - 1];

        //         if (childStack.Count == 0)
        //         {
        //             childListStack.RemoveAt(childListStack.Count - 1);
        //         }
        //         else
        //         {
        //             tree = childStack[0];
        //             childStack.RemoveAt(0);

        //             string indent = "";
        //             for (int i = 0; i < childListStack.Count - 1; i++)
        //             {
        //                 indent += (childListStack[i].Count > 0) ? "|  " : "   ";
        //             }

        //             Console.WriteLine(indent + "+- " + tree.Manager);

        //             if (tree.Employee != 0)
        //             {
        //                 childListStack.Add(new List<Node>(tree.Employee));
        //             }
        //         }
        //     }
        // }

    public class generalNodeTreeJ
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" 32_GeneralNodeTree.cs  ");

            //Node root = null;
            String rootStr = "1";
            // String child1Str = "-1";
            // String child2Str = "-1";
            int root = 1;
            int Parent = 18;
            int Child = 17;
            //int Parent = 18;
            //int Child = 11;

            processJasonFile rjf = new processJasonFile();

            //List<List<String>> kTreeS = rjf.populateRootString;
            List<List<int>> kTree = rjf.populateRoot();

            if (processJasonFile.debug) {
                Root tree1 = rjf.readjasonListOfList(GlobalVar.JASONFILEPATH, ref rootStr);
                rjf.printTreeListOfListNode(tree1);
                rjf.listToListOfListConversion(tree1);
            
                //rjf.readjason(GlobalVar.JASONFILEPATH);
                List<Node> mytree = rjf.readjason(GlobalVar.JASONFILEPATH, ref rootStr);
                rjf.printTreeNode(mytree);
            }

            rjf.printTreeNodeListOfList(kTree);

            //Node root = null;
            //rjf.PrintTree(root);

            //rjf.findLCA()
		    //rjf.getLCA(1, tree, scn.nextInt(), scn.nextInt());
            Console.WriteLine("Plesae provide the names of the values of the two children nodes:", Parent, Child);
            int index = 0;

            processJasonFile.getLCA(root, kTree, Parent, Child);

            //processJasonFile.getLCA(index, root, kTree[0], child1, child2);
            //public void findLCA(int root, List<Node> tree, int child1, int child2)

            Console.ReadLine();
        }
    }
}
