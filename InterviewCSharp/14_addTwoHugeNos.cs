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
    public class addTwoHugeNos 
    { 
       public string findsum(string str1, string str2)
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

            //String to Array conversion, Array to String conversion
            char[] ch2 = str2.ToCharArray();
            Array.Reverse(ch2);
            //convert back char array to string
            str2 = new string(ch2);

            // Do school mathematics, compute sum of  
            // current digits and carry              
            string str = "";        //Output str
            int carry = 0;

            //Scanning the smaller of the two strings i.e Str1, n1
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

        //It's 10 to 30 times faster than the accepted answer.
        public string AddNumStr(string v1, string v2)
        {
            var v1Len = v1.Length;
            var v2Len = v2.Length;
            var count = Math.Max(v1Len, v2Len);
            var answ = new char[count + 1];

            while (count >= 0) 
            {
                answ[count--] = (char)(
                            (v1Len > 0 ? v1[--v1Len] & 0xF:0) +
                                                         (v2Len>0 ? v2[--v2Len]&0xF : 0));
            }

            for (var i = answ.Length - 1; i >= 0; i--)
            {
                if (answ[i] > 9)
                {
                    answ[i - 1]++;
                    answ[i] -= (char)10;
                }
                answ[i] = (char)(answ[i] | 48);
            }
            return new string(answ).TrimStart('0');
        }
    }

    public class driver14
    {
        public void driverCall()
        {
            Console.WriteLine("driverCall: Hello World");
            Console.WriteLine("");

            //string str1 = "34324234324325341957697";
            //string str2 = "48504768756827312546899";
            string str1 = "47812345";
            string str2 = "12345";
            //str1+str2 = 24690     24690.246

            //string str1 = "13";
            //string str2 = "35";
            //str1+str2 = 24690     24690.246
            addTwoHugeNos an = new addTwoHugeNos();

            Console.WriteLine("Method 1: " + '\n' + an.AddNumStr(str1, str2));
            Console.ReadLine(); 

            string str = an.findsum(str1, str2);
            
            Console.WriteLine("{0}", str1);
            Console.WriteLine("+");
            Console.WriteLine("{0}", str2);
            Console.WriteLine("=");
            Console.WriteLine("{0}", str);

            Console.ReadLine(); 
        }

    }

}