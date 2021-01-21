
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//Async/Await
//https://www.c-sharpcorner.com/article/async-and-await-in-c-sharp/



//https://www.google.com/search?q=c%23%20What%20is%20the%20difference%20between%20async%20await%20and%20Taske%20wait
//https://stiller.blog/2012/12/task-wait-vs-await/

//Wait and await - while similar conceptually - are actually completely different. 
//Wait will synchronously block until the task completes. ...

//await will asynchronously wait until the task completes. 
//This means the current method is "paused" (its state is captured) and the method returns an incomplete task to its caller

//Async/Await, vs Task/Wait

//Async/Await, vs Task/Wait
//Asynchronous and Multi-threading concepts .


//C# program that uses async, await, Task
namespace TestCases
{
    class asyncProgramEx1
    {     
        //this is an async task = meaning run it and wait for it fot finish before exiting the program
        public static async Task Method1()  
        {  
            //Await for the async task to finish.
            await Task.Run(() =>  
            {  
                for (int i = 0; i < 100; i++)  
                {  
                    Console.WriteLine("{0}: Method 1", i);  
                }  
            });
        }  
    
    
        public static void Method2()  
        {  
            for (int i = 0; i < 25; i++)  
            {  
                Console.WriteLine("{0}: Method 2", i);  
            }  
        }  
    }  


    public class asyncTaskDriverSimpleEx1
    {
        //Driver Function like main
        public void driverCall()
        {
            Console.WriteLine(" ............  ");
            Console.WriteLine(" async Task Driver 2  ");

            asyncProgramEx1 sn = new asyncProgramEx1();


            asyncProgramEx1.Method1();  
            asyncProgramEx1.Method2();  


            Console.ReadLine();             
        }
    }

}

//Output1
/* Programs: Hello World!
Done
 ............
 async Task Driver 2
0: Method 1
1: Method 1
2: Method 1
3: Method 1
4: Method 1
5: Method 1
6: Method 1
7: Method 1
8: Method 1
9: Method 1
10: Method 1
11: Method 1
12: Method 1
13: Method 1
14: Method 1
15: Method 1
16: Method 1
17: Method 1
18: Method 1
19: Method 1

0: Method 2
1: Method 2
2: Method 2
3: Method 2
4: Method 2
5: Method 2
6: Method 2
7: Method 2
8: Method 2
9: Method 2
10: Method 2
11: Method 2
12: Method 2
13: Method 2
14: Method 2
15: Method 2
16: Method 2
17: Method 2
18: Method 2
19: Method 2
20: Method 2
21: Method 2
22: Method 2
23: Method 2
24: Method 2

20: Method 1
21: Method 1
22: Method 1
23: Method 1
24: Method 1
25: Method 1
26: Method 1
27: Method 1
28: Method 1
29: Method 1
30: Method 1
31: Method 1
32: Method 1
33: Method 1
34: Method 1
35: Method 1
36: Method 1
37: Method 1
38: Method 1
39: Method 1
40: Method 1
41: Method 1
42: Method 1
43: Method 1
44: Method 1
45: Method 1
46: Method 1
47: Method 1
48: Method 1
49: Method 1
50: Method 1
51: Method 1
52: Method 1
53: Method 1
54: Method 1
55: Method 1
56: Method 1
57: Method 1
58: Method 1
59: Method 1
60: Method 1
61: Method 1
62: Method 1
63: Method 1
64: Method 1
65: Method 1
66: Method 1
67: Method 1
68: Method 1
69: Method 1
70: Method 1
71: Method 1
72: Method 1
73: Method 1
74: Method 1
75: Method 1
76: Method 1
77: Method 1
78: Method 1
79: Method 1
80: Method 1
81: Method 1
82: Method 1
83: Method 1
84: Method 1
85: Method 1
86: Method 1
87: Method 1
88: Method 1
89: Method 1
90: Method 1
91: Method 1
92: Method 1
93: Method 1
94: Method 1
95: Method 1
96: Method 1
97: Method 1
98: Method 1
99: Method 1
 */

 //Output2
/*  0: Method 1
1: Method 1
2: Method 1
3: Method 1
4: Method 1
5: Method 1
6: Method 1
7: Method 1
8: Method 1
9: Method 1
10: Method 1
11: Method 1
12: Method 1
13: Method 1
14: Method 1
15: Method 1
16: Method 1
17: Method 1
18: Method 1
19: Method 1
20: Method 1
21: Method 1
22: Method 1
23: Method 1
24: Method 1
25: Method 1
26: Method 1
27: Method 1
28: Method 1
29: Method 1
30: Method 1
31: Method 1
32: Method 1
33: Method 1
34: Method 1
35: Method 1
36: Method 1
37: Method 1
38: Method 1
39: Method 1
40: Method 1
41: Method 1
42: Method 1
43: Method 1
44: Method 1
45: Method 1
46: Method 1
47: Method 1
48: Method 1
49: Method 1
50: Method 1
51: Method 1
52: Method 1
53: Method 1
54: Method 1
55: Method 1
56: Method 1
57: Method 1
58: Method 1
59: Method 1
60: Method 1
61: Method 1
62: Method 1
63: Method 1
64: Method 1
65: Method 1
66: Method 1
67: Method 1
68: Method 1
69: Method 1
70: Method 1
71: Method 1
72: Method 1
73: Method 1
74: Method 1
75: Method 1
76: Method 1
77: Method 1
0: Method 2
1: Method 2
2: Method 2
78: Method 1
79: Method 1
80: Method 1
81: Method 1
82: Method 1
83: Method 1
84: Method 1
85: Method 1
86: Method 1
87: Method 1
88: Method 1
89: Method 1
90: Method 1
91: Method 1
92: Method 1
93: Method 1
94: Method 1
95: Method 1
96: Method 1
97: Method 1
98: Method 1
99: Method 1
3: Method 2
4: Method 2
5: Method 2
6: Method 2
7: Method 2
8: Method 2
9: Method 2
10: Method 2
11: Method 2
12: Method 2
13: Method 2
14: Method 2
15: Method 2
16: Method 2
17: Method 2
18: Method 2
19: Method 2
20: Method 2
21: Method 2
22: Method 2
23: Method 2
24: Method 2 */