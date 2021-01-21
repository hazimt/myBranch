/*

MS CA interview question
34324234324325341957697.4544 + 48504768756827312546899.322    

https://www.geeksforgeeks.org/sum-two-large-numbers/
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    public class addTwoHugeNosDec
    { 

        //For decimal.
        public bool findDec(ref string strNo, ref string strDec)
        {
            string strt = "";

            int iDec = strNo.IndexOf('.');
            strDec = strNo.Substring(iDec+1);
            strNo = strNo.Substring(0, iDec);

            Console.WriteLine(strNo);
            Console.WriteLine(strDec);
            //Console.ReadLine();

            return true;
        }

        public string addDecPart(string str1, string str2, ref int carry)
        {
            string stra = str1, strb = str2;
            
            //* Find the larger string. <------
            //Set str1 to be the longer string.  If not swap the strings.
            if (stra.Length == 0 || strb.Length == 0)
            return null;
            
            //* Swap strings, stra is assigned the smaller no.
            if (stra.Length > strb.Length) 
            {
                string t = stra;
                stra = strb;
                strb = t;
            }

            //So na is smaller, nb is larger.
            int na = stra.Length, nb = strb.Length;

            //* Revese both strings <------
            //Just like when doing by hand.
            char[] cha = stra.ToCharArray();
            Array.Reverse(cha);
            stra = new string(cha);

            char[] chb = strb.ToCharArray();
            Array.Reverse(chb);
            strb = new string(chb);

            //Copy the large str to the output str: strs  <------
            //string strs = strb; 
            
            //Start Copying from index = nb - na
            //start adding the sums into strs from index (nb-na). 
            carry = 0;
            string strs=""; 
            //Scanning the smaller of the two strings i.e Stra, n1
            for (int i = 0; i < na; i++)
            {
                int sum = (int)(stra[i] - '0') + (int)(strb[i+(nb-na)] - '0') +  carry;
                strs += (char)((sum % 10) + '0');        //12 % 10 = 2, 4 % 10 = 4, 10 % 10 = 0
                carry = sum/10;     // 12/10 = 1,  whereas 5/10 = 0                
            }

            // Reverse the string before appending the rest <------
            char[] ch = strs.ToCharArray();
            Array.Reverse(ch);
            
            strs = new string(ch);

            //add the rest of the digits to the right of the large num <------
            for (int i = 0; i < (nb-na); i++)
                                    strs += strb[i];

            Console.WriteLine("Carry = " + carry);

            return strs;
        }
        
       public string findsumDec(string str1, string str2, int carry)
        {
            Console.WriteLine("Enter findsum");
            
            //* Find the larger string.
            //Set str1 to be the longer string.  If not swap the strings.
            if (str1.Length == 0 || str2.Length == 0)
            return null;
            
            //* Swap strings, str1 is assigned the smaller no.
            if (str1.Length > str2.Length) 
            {
                string t = str1;
                str1 = str2;
                str2 = t;
            }

            //So n1 is smaller, n2 is larger.
            int n1 = str1.Length, n2 = str2.Length;
            
            //* Revese both strings
            //Just like when doing by hand.
            char[] ch1 = str1.ToCharArray();
            Array.Reverse(ch1);
            str1 = new string(ch1);

            char[] ch2 = str2.ToCharArray();
            Array.Reverse(ch2);
            str2 = new string(ch2);

            // Do school mathematics, compute sum of  
            // current digits and carry              
            string str = "";        //Output str
            //int carry = 0;

            //Scanning/adding the smaller of the two strings i.e Str1, n1
            for (int i = 0; i < n1; i++)
            {
                //(str1[i] - '0') --> gives 48 --> this asci needs convesion to int to get the numerial 
                int sum = (int)(str1[i] - '0') + (int)(str2[i] - '0') +  carry;
                str += (char)((sum % 10) + '0');        //12 % 10 = 2, 4 % 10 = 4, 10 % 10 = 0
                carry = sum/10;     // 12/10 = 1,  whereas 5/10 = 0
            }

            Console.WriteLine("findsum 2 {0}", str);    

            //add the rest of the digits for the large num
            for (int i = n1; i < n2; i++)
            {
                int sum = (int)(str2[i] - '0') +  carry;
                str += (char)((sum % 10) + '0');
                
                carry = sum/10;
            }
            
            //Add the carry which remained
            if (carry == 1) 
                str += (char)(carry + '0');
            else if (carry > 1)
                Console.WriteLine("Carry can't be greater than one.  But it is");
            
            char[] ch = str.ToCharArray();
            Array.Reverse(ch);
            
            str = new string(ch);

            return str;
        }
    }

    public class driver15
    {
        public void driverCall()
        {
            Console.WriteLine("driverCall: Hello World");
            Console.WriteLine("");

            //string str1 = "34324234324325341957697";
            //string str2 = "48504768756827312546899";
//            string str1 = "12345.123";
//            string str2 = "12345.123";
            //str1+str2 = 24690     24690.246

            string str1 = "12.634";
            string str2 = "34.5432";
            //str1+str2 = 24690     24690.246

            addTwoHugeNosDec an = new addTwoHugeNosDec();

            string strNo1 = str1, strDec1="";
            Console.WriteLine("Method 2: ");
            if (an.findDec(ref strNo1, ref strDec1) == null)
                Console.WriteLine("First No has no decimal.");

            string strNo2 = str2, strDec2="";
            if (an.findDec(ref strNo2, ref strDec2) == null)
                Console.WriteLine("Second No has no decimal.");

            int carry = 0;
            string strDec = an.addDecPart(strDec1, strDec2, ref carry);
            Console.WriteLine("strDec = " + strDec);
            Console.WriteLine("carry = " + carry);

            string strNo = an.findsumDec(strNo1, strNo2, carry);
            Console.WriteLine("strNo = " + strNo);

            //The finall string/result
            string str = strNo + "." + strDec;

            Console.WriteLine("----------------------");
            Console.WriteLine(" {0}", str1);
            Console.WriteLine("  +");
            Console.WriteLine(" {0}", str2);
            Console.WriteLine("  =");
            Console.WriteLine(" {0}", str);

            Console.ReadLine(); 
        }

    }

}