//Generate a Node Tree

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{

    // public class testCase29
    // {

    //}

    public class Node<T> where T:IComparable
    {

        bool debug = false;
        public T Value { get; set; }

        public IList<Node<T>> Children { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static Func<T, Node<T>, Node<T>> GetFindFirstFunc()
        {
            Func<T, Node<T>,Node<T>> func = null;
            func = (value,currentNode) =>
                {
                    if (currentNode.Value.CompareTo(value) == 0)
                    {
                        return currentNode;
                    }
                    if (currentNode.Children != null)
                    {
                        foreach (var child in currentNode.Children)
                        {                            
                            var result = func(value, child);
                            if (result != null)
                            {
                                //found the first match, pass that out as the return value as the call stack unwinds
                                return result;
                            }
                        }
                    }
                    return null;
                };
            return func;
        }

        public static Func<T, Node<T>, IEnumerable<Node<T>>> GetFindAllFunc()
        {
            Func<T, Node<T>, IEnumerable<Node<T>>> func = null;
            List<Node<T>> matches = new List<Node<T>>();
            func = (value, currentNode) =>
            {
                //capture the matches  List<Node<T>> in a closure so that we don't re-create it recursively every time.
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    matches.Add(currentNode);
                }
                if (currentNode.Children != null)
                {
                    //process all nodes
                    foreach (var child in currentNode.Children)
                    {
                        func(value, child);
                    }
                }
                return matches;
            };
            return func;
        }       
    }












    public class generalNodeTree
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" 31_GeneralNodeTree.cs  ");

            //https://stackoverflow.com/questions/1174840/recursive-non-binary-non-sorted-tree-search-using-c-sharp-lambdas
            Node<int> rootNode = new Node<int>
            {
                Value = 1,
                Children = new List<Node<int>>
                {
                    new Node<int>
                    {  Value = 2,
                                    Children = new List<Node<int>>
                                    {
                                        new Node<int>{ Value = 7},
                                        new Node<int>{ Value = 4}                                                            
                                    }
                    },
                    new Node<int>
                    {  Value = 5,
                                    Children = new List<Node<int>>
                                    {
                                        new Node<int>{ Value = 6},
                                        new Node<int>{ Value = 7}                                                            
                                    }
                    }
                }
            };

            Func<int, Node<int>, Node<int>> findFirst = Node<int>.GetFindFirstFunc();
            var firstValue = findFirst(7, rootNode);           

            Func<int, Node<int>, IEnumerable<Node<int>>> findAll = Node<int>.GetFindAllFunc();
            var allvalues = findAll(7, rootNode);   

            Console.WriteLine("allvalues: {0}", allvalues);        

            Console.ReadLine();             
        }
    }

}

