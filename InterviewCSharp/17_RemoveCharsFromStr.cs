/*

removeChars

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class removeChars
    {
        static int maxKeybrd = 256;
        public void removechars(string str, string remove)
        {
            //1. Create and initalize removearray[256].
            //2. Scan removesrc array but for setting removeArray to 1 (delete letter) if matches found.
            //3. Scan Str array and Copy chars to Str array (itself) unless they are marked for delete.

            //Declare an Array.
            //1. Create and initalize removearray[256].
            int[] keyBoardArray = new int[maxKeybrd];

            if (remove == null)
                return;
            if (str == null)
                return;

            //initialize the entire keyboard keyBoardArray to zero
            //for (int i = 0; i < 256; i++)
            for (int i = 0; i < 256; i++)
                keyBoardArray[i] = 0;

        	//2. Scan the min remove list/array and mark the newly created keyBoardArray(256 array) letters to be deleted.
            int src, dst;
            src = 0;

            char[] removearray = remove.ToCharArray();
            int endrm = removearray.Length - 1;

            //scan remove array within keyBoardArray
            //while (remove[src])
            while (src < endrm)
                keyBoardArray[removearray[src++]] = 1;

            int endstr = str.Length - 1;
            char[] strArray = str.ToCharArray();
            endstr = strArray.Length;
            src = dst = 0;
            do 
            {
                if (strArray[dst] == 'y') {
                    string strNew1 = new string(strArray);
                    Console.WriteLine("src: " + src);
                    Console.WriteLine("dst: " + dst);
                    Console.WriteLine(strNew1);
                    Console.ReadLine();
                }
                if ((keyBoardArray[strArray[src]] == 0) && (dst < endstr-1))
                //if (keyBoardArray[strArray[src]] == 0)
                    strArray[dst++] = strArray[src];
            } while(src++ < endstr-1);
            //} while (str[src++]);
            //scan original array

            string strNew = new string(strArray);
            Console.WriteLine(strNew);
            Console.WriteLine("Expected Result:");
        	//Result: Bttl f th Vwls:Hw vs.Grzny"	(no aeiou letters in the result)
            Console.WriteLine("Bttl f th Vwls: Hw vs. Grzny (no aeiou letters in the result)");

            Console.WriteLine();

        }

    }
    
    public class testCase17
    {
        //Driver Function
        public void  driverCall()
        {
            string str = "Battle of the Vowels: Hawaii vs. Grozny";
            string remove = "aeiou";

            Console.WriteLine("str = " + str);
            Console.WriteLine("remove = " + remove);

            removeChars rmc = new removeChars();

            rmc.removechars(str, remove);

            Console.ReadLine();             
        }
    }

}

