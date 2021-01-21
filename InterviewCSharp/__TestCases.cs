/* namespace InterviewQuestions
{
    class TestCases
    {
    }
}*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    class testCall
    {
        public testCall(int tcNo, int tcCounter)
        {
            int testCaseToDo = 117;     //  32    100
            int testCaseMax = 117;

            //Get Stuck here
            //example tc0 = new example();
            //tc0.driverCall();

            //testCaseToDo = tcNo;
            //testCaseMax = tcCounter;
            //Loop through all test cases. Make it
            for (int testCase = testCaseToDo; testCase <= testCaseMax; ++testCase)
            {
                switch (testCase)
                {
                    case 0:
                        testCase0 tc0 = new testCase0();
                        break;

                    case 1:
                        testCase1 tc1 = new testCase1();
                        tc1.Inheritance_explainDriver();
                        break;

                    case 2:
                        testCase2 tc2 = new testCase2();
                        tc2.degreeOfArrayDriver();
                        break;

                    case 3:
                        //formateDate
                        testCase3 tc3 = new testCase3();
                        tc3.formateDatesDriver();
                        break;

                    case 4:
                        //formateDate
                        testCase4 tc4 = new testCase4();
                        tc4.bSearchDriver();
                        break;

                    case 5:
                        //formateDate
                        testCase5 tc5 = new testCase5();
                        tc5.removeDupsDriver();
                        break;

                    case 6:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase6 tc6 = new testCase6();
                        tc6.printRandomNo();
                        break;

                    case 7:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase7 tc7 = new testCase7();
                        tc7.constructorCalls();
                        break;

                    case 8:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase8 tc8 = new testCase8();
                        tc8.cse_staticMethodsCall();
                        break;

                    case 9:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase9 tc9 = new testCase9();
                        tc9.SingletonBasicDemoCall();
                        break;

                    case 10:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase10 tc10 = new testCase10();
                        tc10.SingletonOneInstanceNoThreadDemoCall();
                        break;

                    case 11:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase11 tc11 = new testCase11();
                        tc11.Singleton3DemoCall();
                        break;

                    case 12:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase12 tc12 = new testCase12();
                        tc12.evMathExpCall();
                        break;

                    case 13:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        driver13 tc13 = new driver13();
                        tc13.driverCall();
                        break;

                    case 14:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        driver14 tc14 = new driver14();
                        tc14.driverCall();
                        break;

                    case 15:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        driver15 tc15 = new driver15();
                        tc15.driverCall();
                        break;

                    case 16:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase16 tc16 = new testCase16();
                        tc16.driverCall();
                        break;

                    case 17:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase17 tc17 = new testCase17();
                        tc17.driverCall();
                        break;

                    case 18:
                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                        testCase18 tc18 = new testCase18();
                        tc18.driverCall();
                        break;

                        //Print Genom for even numbers, print Microsoft for 100, hello Genom, 1-100 
                    case 19:
                        testCase19 tc19 = new testCase19();
                        tc19.driverCall();
                        break;

                    case 191:
                        testCase191 tc191 = new testCase191();
                        tc191.driverCall();
                        break;

                    case 20:
                        testCase20 tc20 = new testCase20();
                        tc20.driverCall();
                        break;

                    case 21:
                        testCase21 tc21 = new testCase21();
                        tc21.driverCall();
                        break;

                    case 22:
                        testCase22 tc22 = new testCase22();
                        tc22.driverCall();
                        break;

                    case 23:
                        stocksapn tc23 = new stocksapn();
                        tc23.driverCall();
                        break;

                    case 24:
                        WaystoSum tc24 = new WaystoSum();
                        tc24.driverCall();
                        break;

                    case 25:
                        maxCrc tc25 = new maxCrc();
                        tc25.driverCall();
                        break;

                    case 26:
                        giveMeMissingValue tc26 = new giveMeMissingValue();
                        tc26.driverCall();
                        break;

                    case 27:
                        zeroSumList tc27 = new zeroSumList();
                        tc27.driverCall();
                        break;

                    case 28:
                         mergeToArrays tc28 = new mergeToArrays();
                         tc28.driverCall();
                         break;

                    // case 29:
                    //      leastCommonAncestorEx1 tc29 = new leastCommonAncestorEx1();
                    //      tc29.driverCall();
                    //      break;

                    // case 30:
                    //      leastCommonAncestorEx2 tc30 = new leastCommonAncestorEx2();
                    //      tc30.driverCall();
                    //      break;

                    case 31:
                         generalNodeTree tc31 = new generalNodeTree();
                         tc31.driverCall();
                         break;

                    case 32:
                         generalNodeTreeJ tc32 = new generalNodeTreeJ();
                         tc32.driverCall();
                         break;

                    case 100:
                        ArrayListExDriver tc100 = new ArrayListExDriver();
                        tc100.driverCall();                         
                         break;

                    case 101:
                        ListExDriver tc101 = new ListExDriver();
                        tc101.driverCall();                         
                         break;

                    case 102:
                        TestVirtualOverrideDriver tc102 = new TestVirtualOverrideDriver();
                        tc102.driverCall();                         
                         break;

                    case 103:
                        TestAbstractOverrideDriver tc103 = new TestAbstractOverrideDriver();
                        tc103.driverCall();                         
                         break;

                    case 104:
                        WaitDriver tc104 = new WaitDriver();
                        tc104.driverCall();                         
                         break;

                    case 105:
                        LinkDriver tc105 = new LinkDriver();
                        tc105.driverCall();                         
                         break;

                    case 106:
                        LinkDefExDriver tc106 = new LinkDefExDriver();
                        tc106.driverCall();                         
                         break;

                    case 107:
                        SOLIDDriverS tc107 = new SOLIDDriverS();
                        tc107.driverCall();                         
                         break;

                    case 108:
                        yieldkDriver tc108 = new yieldkDriver();
                        tc108.driverCall();                         
                         break;

                    case 109:
                        yield2kDriver tc109 = new yield2kDriver();
                        tc109.driverCall();                         
                         break;

                    case 110:
                        yield3kDriver tc110 = new yield3kDriver();
                        tc110.driverCall();                         
                         break;

                    case 111:
                        PolymorphismDriver tc111 = new PolymorphismDriver();
                        tc111.driverCall();                         
                         break;

                    case 112:
                        FinallyDriver tc112 = new FinallyDriver();
                        tc112.driverCall();                         
                         break;

                    case 113:
                        FinalSealed_Finalize_Driver tc113 = new FinalSealed_Finalize_Driver();
                        tc113.driverCall();                         
                         break;

                    case 114:
                        asyncTaskDriverSimpleEx1 tc114 = new asyncTaskDriverSimpleEx1();
                        tc114.driverCall();                         
                         break;

                    case 115:
                        asyncTaskDriverSimpleEx2 tc115 = new asyncTaskDriverSimpleEx2();
                        tc115.driverCall();                         
                         break;

                    case 116:
                        lambdaDriver tc116 = new lambdaDriver();
                        tc116.driverCall();                         
                         break;

                    case 117:
                        asyncTaskDriverSimpleEx3 tc117 = new asyncTaskDriverSimpleEx3();
                        tc117.driverCall();                         
                        break;

                    case 118:
                        syncTaskDriverSimpleEx1 tc118 = new syncTaskDriverSimpleEx1();
                        tc118.driverCall();                         
                        break;



/*                     case 114:
                        asyncTaskDriver tc114 = new asyncTaskDriver();
                        tc114.driverCall();                         
                         break;

                    case 115:
                        lambdaDriver tc115 = new lambdaDriver();
                        tc115.driverCall();                         
                         break;

 */
/*                     case 116:
                        lambdaDriver2 tc116 = new lambdaDriver2();
                        tc116.driverCall();                         
                         break;
 */
                    default:
                        Console.WriteLine("");
                        break;

                }
            }
        }


    }
}



