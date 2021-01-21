/* 
     Find maximum consecutive repeating character in string.
     Input : str = "aaaaaabbcbbbbbcbbbb"

    Output :a
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class testCase25
    {
        bool debug = false;
       
        public void MaxConsecutiveRepeatingCharacter1(string str, ref int maxLen, ref char keepMax)
        {
            maxLen = 0;
            int currMax = 0;
            char keep = str[0];
            keepMax = '\n';

            if (str.Length == 1)
            {
                maxLen = 1;
                keepMax = keep;
                return;
            }
            
            for (int i = 1; i < str.Length; i++)
            {
                if (debug) Console.WriteLine("{0} {1}", str[i], str[i-1]);
                if (str[i] == str[i-1])
                    currMax++;
                else
                {
                    keep = str[i-1];
                    currMax = 0;
                }
                if (debug) Console.WriteLine("{0} {1} {2}", currMax, maxLen, keep);
                //Math.Max: Find the largest of the two provided numbers
                maxLen = Math.Max(maxLen, currMax+1);
                if (maxLen <= currMax+1)
                    keepMax = keep;
            }

            return;
        }

        public string MaxConsecutiveRepeatingCharacter2(string str)
        {
           string longestRun = new string(
                str.Select((c, index) => str.Substring(index).TakeWhile(e => e == c))
                                         .OrderByDescending(e => e.Count())
                                         .First().ToArray());
            return  longestRun;
        }
    }
    
    public class maxCrc
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine("25_MaxConsecutiveRepeatingCharacter.cs");
            testCase25 sn = new testCase25();

            string str = "aaaaaabbcbbbbbcbbbb";
            int maxLen = 0; char letter = '\n';
            
            sn.MaxConsecutiveRepeatingCharacter1(str, ref maxLen, ref letter);
            Console.WriteLine("Original Str: {0}, maxLen: {1} letter: {2}", str, maxLen, letter);
            //print a letter maxLen number of times.
            string result = new string(letter, maxLen);
            Console.WriteLine();
            Console.WriteLine("The max repating string: {0}, {1} times.", result, maxLen);

            Console.WriteLine("longestRun: {0}", sn.MaxConsecutiveRepeatingCharacter2(str));

            Console.ReadLine();
        }
    }

}

