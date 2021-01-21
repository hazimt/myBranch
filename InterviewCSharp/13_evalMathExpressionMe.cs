/*
Evalute Math Exp with Paranthesis
Add more test cases with paranthesis

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

    public class EvaluateString 
    { 
        public static int evaluate(string expression) 
        { 
            char[] tokens = expression.ToCharArray(); 
    
            // Stack for numbers: 'values'  
            Stack<int> values = new Stack<int>(); 
    
            // Stack for Operators: 'ops'  
            Stack<char> ops = new Stack<char>(); 
    
            for (int i = 0; i < tokens.Length; i++) 
            { 
                // Current token is a whitespace, skip it  
                if (tokens[i] == ' ') 
                { 
                    continue; 
                } 
    
                // Current token is a number, push it to stack for numbers  
                if (tokens[i] >= '0' && tokens[i] <= '9') 
                { 
                    StringBuilder sbuf = new StringBuilder(); 
                    // There may be more than one digits in number  
                    while (i < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9') 
                    { 
                        sbuf.Append(tokens[i++]); 
                    } 
                    values.Push(int.Parse(sbuf.ToString())); 
                } 
    
                // Current token is an opening brace, push it to 'ops'  
                else if (tokens[i] == '(') 
                { 
                    ops.Push(tokens[i]); 
                } 
    
                // Closing brace encountered, solve entire brace  
                else if (tokens[i] == ')') 
                { 
                    while (ops.Peek() != '(') 
                    { 
                    values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop())); 
                    } 
                    ops.Pop(); 
                } 
    
                // Current token is an operator.  
                else if (tokens[i] == '+' || tokens[i] == '-' || tokens[i] == '*' || tokens[i] == '/') 
                { 
                    // While top of 'ops' has same or greater precedence to current  
                    // token, which is an operator. Apply operator on top of 'ops'  
                    // to top two elements in values stack  
                    while (ops.Count > 0 && hasPrecedence(tokens[i], ops.Peek())) 
                    { 
                    values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop())); 
                    } 
    
                    // Push current token to 'ops'.  
                    ops.Push(tokens[i]); 
                } 
            } 
    
            // Entire expression has been parsed at this point, apply remaining  
            // ops to remaining values  
            while (ops.Count > 0) 
            { 
                values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop())); 
            } 
    
            // Top of 'values' contains result, return it  
            return values.Pop(); 
        } 
    
        // Returns true if 'op2' has higher or same precedence as 'op1',  
        // otherwise returns false.  
        public static bool hasPrecedence(char op1, char op2) 
        { 
            if (op2 == '(' || op2 == ')') 
            { 
                return false; 
            } 
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-')) 
            { 
                return false; 
            } 
            else
            { 
                return true; 
            } 
        } 
    
        // A utility method to apply an operator 'op' on operands 'a'   
        // and 'b'. Return the result.  
        public static int applyOp(char op, int b, int a) 
        { 
            switch (op) 
            { 
            case '+': 
                return a + b; 
            case '-': 
                return a - b; 
            case '*': 
                return a * b; 
            case '/': 
                if (b == 0) 
                { 
                    throw new System.NotSupportedException("Cannot divide by zero"); 
                } 
                return a / b; 
            } 
            return 0; 
        }
    }

    public class driver13
    {
        public void driverCall()
        {
            Console.WriteLine(EvaluateString.evaluate("10 + 2 * 6")); 
            Console.WriteLine(EvaluateString.evaluate("100 * 2 + 12")); 
            Console.WriteLine(EvaluateString.evaluate("100 * ( 2 + 12 )")); 
            Console.WriteLine(EvaluateString.evaluate("100 * ( 2 + 12 ) / 14"));

            Console.ReadLine(); 
        }

    }

}