/*
Evalute Math Exp No Paranthesis

https://www.geeksforgeeks.org/program-evaluate-simple-expressions/

Program to evaluate simple expressions
You are given a string that represent an expression of digits and operands. E.g. 1+2*3, 1-2+4. You need to evaluate the string or the expression. NO BODMAS is followed. If the expression is of incorrect syntax return -1.
Test cases:
a) 1+2*3 will be evaluated to 9.
b) 4-2+6*3 will be evaluated to 24.
c) 1++2 will be evaluated to -1(INVALID).
Also, in the string spaces can occur. For that case we need to ignore the spaces. Like :- 1*2 -1 is equals to 1.

Source: Amazon Interview Question

It is strongly recommend to minimize the browser and try this yourself first.
The idea is simple start from the first character and traverse from left to right and check for errors like two consecutive operators and operands. We also keep track of result and update the result while traversing the expression.

---------------------
The above code doesn’t handle spaces. We can handle spaces by first removing all spaces from the given string. A better solution is to handle spaces in single traversal. This is left as an exercise.

Time Complexity is O(n) where n is length of the given expression.

This article is contributed by Abhishek. Please write comments if you find anything incorrect, or you want to share more information about the topic discussed above

But the Microsoft interview question is:
-----------------------------------------
Given a mathematical expression as string, can you write a function to check if it is a valid expression or not.
// Example: 3*4+1 is a valid
// 3*4+1 is valid
//3*4++1 is not valid
//+1 this is not valid
//3**4 is not valid
// 3*'/4+9 is not valid   remove the ' as it's need to keep the line as a comment.

//https://www.geeksforgeeks.org/expression-evaluation/
//with parenthesis

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    //

    public class GFG
    {    
        // A utility function to check if 
        // a given character is operand 
        public bool isOperand(char c) //ie is this a number?
        { 
            Console.WriteLine ("isOperand");
            return (c >= '0' && c <= '9');
        }

        // utility function to find value of and operand  
        public int value(char c) 
        { 
            return (int)(c - '0'); 
        }         

        // This function evaluates simple  
        // expressions. It returns -1 if the  
        // given expression is invalid.  
        public int evaluate(string exp)  
        {
            // Base Case: Given expression is empty  
            if (exp.Length == 0) return -1;
        
            // The first character must be 
            // an operand (means a number), find its value  
            //Fix
            //int res = value(exp[0]);  
            //Fix is
            int res=-1;

            if (isOperand(exp[0]))
                res = value(exp[0]);
            else 
                return -1;

            // Traverse the remaining characters in pairs  
            for (int i = 1; i<exp.Length; i += 2)  
            {  
                // The next character must be an operator, and  
                // next to next an operand  
                char opr = exp[i], opd = exp[i+1];  
        
                // If next to next character is not an operand  
                if (isOperand(opd)==false) return -1;  
        
                // Update result according to the operator  
                if (opr == '+') res += value(opd);  
                else if (opr == '-') res -= value(opd);  
                else if (opr == '*') res *= value(opd);  
                else if (opr == '/') res /= value(opd);  
        
                // If not a valid operator  
                else                 return -1;  
            }  
            return res;  
        }
    }


    //SingletonBasicDemo
    public class testCase12
    {
        public void evMathExpCall()
        {

            GFG ev = new GFG();

            string expr1 = "1+2*5+3";  
            int res = ev.evaluate(expr1);  
            if(res == -1)  
            Console.WriteLine(expr1+" is Invalid");  
            else
            Console.WriteLine("Value of "+expr1+" is "+res);  
        
            string expr2 = "1+2*3";  
            res = ev.evaluate(expr2);  
            if(res == -1)  
            Console.WriteLine(expr2+" is Invalid");  
            else         
            Console.WriteLine("Value of "+expr2+" is "+res); 
        
            string expr3 = "4-2+6*3";  
            res = ev.evaluate(expr3);  
            if(res == -1)  
            Console.WriteLine(expr3+" is Invalid");  
            else         
            Console.WriteLine("Value of "+expr3+" is "+res); 
        
            string expr4 = "1++2";  
            res = ev.evaluate(expr4);  
            if(res == -1)
            Console.WriteLine(expr4+" is Invalid");  
            else
            Console.WriteLine("Value of "+expr4+" is "+res);

            Console.ReadLine();
        }
    }

}