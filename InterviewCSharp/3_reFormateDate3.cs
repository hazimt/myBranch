using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//20th Oct 2052 --> 2052-10-20
//23rd Jun 2072 --> 2072-06-23

//Create Days List
//Create a days List with matching format to input
//      Day {"1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "13th", ".....", "29th", "30th", "31st"}
//Create Months List
//      List<string> months = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

//spplit the input date into a var array.
//Parse var aray into separate parts (day, mon, year).

//Generate out string as per requested output formate
//Search findIndex for months and days
//confirm year within range and add to string
//Search for index of months
//Serch for index of days


namespace TestCases
{
    class FormateDate
    {
        List<String> dates = new List<String>();
        string data;
        static bool printFlag = true;


        public int findIndex(List<string> arr, string data)
        {
            for (int i = 0; i < arr.Count; i++)
                if (data == arr[i])
                    return i;
            return -1;
        }

        //Generate the Data structure
        public string reFormateDate(string date)
        {
            //Day {"1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "13th", ".....", "29th", "30th", "31st"}
            //Month {"Jan", "Feb", "Mar", "Apr", ".......", "Oct", "Nov", "Dec"}
            //Year range inclusive {1900, 2100}

            //Crreate Dates
            List<String> days = new List<String>();

            //Generate the day's array.
            //*****************************************************************
            //*****************************************************************
            //Day {"1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th", "11th", "12th", "13th", ".....", "29th", "30th", "31st"}
            //e.g.
            //20th Oct 2052 --> 2052-10-20
            //23rd Jun 2072 --> 2072-06-23

            for (int i = 1; i <= 31; i++)
            {
                string s = i.ToString();
                if (i == 1 || i == 21 || i == 31)
                    s = s + "st";
                else if (i == 2 || i == 22)
                    s = s + "nd";
                else if (i == 3 || i == 23)
                    s = s + "rd";
                else
                    s = s + "th";

                //Add days
                days.Add(s);
            }

            if (printFlag)
            {
                Console.WriteLine();
                Console.WriteLine("Days Template");
                Console.WriteLine("================================================");
                foreach (var a in days)
                    Console.Write("{0} ", a);
                Console.WriteLine();
            }

            //Generate the months's array.
            //Create Month
            //*****************************************************************
            //*****************************************************************
            //Month {"Jan", "Feb", "Mar", "Apr", ".......", "Oct", "Nov", "Dec"}
            List<String> months = new List<String> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };


            if (printFlag)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Months Template");
                Console.WriteLine("================================================");
                foreach (var a in months)
                    Console.Write("{0} ", a);
                Console.WriteLine();
                printFlag = false;
            }

            //Parse the input of date
            //Break down the input of the date into 3 parts.
            //*****************************************************************
            //*****************************************************************
            //e.g.
            //Date = 20th Oct 2052 --> Data = 2052-10-20
            //Date = 23rd Jun 2072 --> Data = 2072-06-23
            var data = date.Split(' ');
            if (data.Length < 3)
                return String.Empty;

            //Deciper the input values of 23rd Jun 2072, or 20th Oct 2052 ...etc
            var day = data[0];
            var mon = data[1];
            var year = data[2];

            //e.g.
            //20th Oct 2052 --> 2052-10-20
            //23rd Jun 2072 --> 2072-06-23

            //Generate the correct output:             2052-10-20, 2072-06-23
            //*****************************************************************
            //*****************************************************************
            //Year range inclusive {1900, 2100}
            if ((Convert.ToInt32(year) <= 1900) || (Convert.ToInt32(year) >= 2100))
                return String.Empty;

            string result = year + "-";

            //Convert Month name to month number
            int monVal = findIndex(months, mon) + 1;

            //or can use: Convert.ToString(monVal);
            if (monVal > 0)
                result = result + monVal.ToString("D2") + "-";      //D2 means a string decimal of size two digits.  i.e e.g a string of 02 not 2.

            //strip the two letter at the end of the number i.e remove the th from the string 20th 
            int dayVal = findIndex(days, day) + 1;
            if (dayVal > 0)
                result = result + dayVal.ToString("D2");

            System.Console.WriteLine(" --> {0}", result);
            System.Console.WriteLine();
            return result;
        }
        public List<String> reFormateDate(List<string> dates)
        {
            List<string> result = new List<string>();
            foreach (var date in dates)
                result.Add(reFormateDate(date));

            return result;
        }
    }

    class testCase3
    {
        public void formateDatesDriver()
        {
            FormateDate myDate = new FormateDate();
            string theDate = "20th Jan 2052";
            System.Console.Write(theDate);
            myDate.reFormateDate(theDate);

            //Read dates from a file.
            int counter = 0;
            string line;

            System.Console.WriteLine();
            System.IO.StreamReader file1 = new System.IO.StreamReader(@"C:\Users\Mars\source\myBranch\InterviewCSharp\InterviewQuestions\reFormateDate3input001.txt");
            //Skip first line.  It's just a count of the number of lines.
            if ((line = file1.ReadLine()) != null)
                System.Console.WriteLine("No of lines to read: {0}", line);
            while ((line = file1.ReadLine()) != null)
            {
                System.Console.Write(line);
                theDate = line;
                myDate.reFormateDate(theDate);
            }
            file1.Close();

            System.Console.WriteLine("==========================");
            System.IO.StreamReader file2 = new System.IO.StreamReader(@"C:\Users\Mars\source\myBranch\InterviewCSharp\InterviewQuestions\reFormateDate3input002.txt");
            //Skip first line.  It's just a count of the number of lines.
            if ((line = file2.ReadLine()) != null)
                System.Console.WriteLine("No of lines to read: {0}", line);
            while ((line = file2.ReadLine()) != null)
            {
                System.Console.Write(line);
                theDate = line;
                myDate.reFormateDate(theDate);
            }
            file2.Close();
        }
    }
}



//ElHaj
/*
//Search days and months arrays to obtain correct index
static int findIndex(List<string> arr, string data)
{
    for (int i = 0; i < arr.Count; ++i)
	if (data == arr[i])
	    return i;

    return -1;
}

static string reformatDate(string date)
{

    //20th Oct 2052 --> 2052-10-20
    //23rd Jun 2072 --> 2072-06-23
    
    //Create Days List
    //Create a days List with matching format to input
    List<string> days = new List<string>();
    for (int i=1; i <= 31; ++i)
    {
	string s = i.ToString();
	if (i == 1 || i == 21 || i == 31)
	    s = s + "st";
	else if (i == 2 || i == 22)
	    s = s + "nd";
	else if (i == 3 || i == 23)
	    s = s + "rd";
	else
	    s = s + "th";
	    days.Add(s);
    }

    //Create Months List
    List<string> months = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

    //spplit the input date into a var array.
    var data = date.Split(' ');
    if (data.Length < 3)
    	return String.Empty;

    //Parse var aray into separate parts (day, mon, year).
    var day = data[0];
    var mon = data[1];
    var year = data[2];

    //Generate out string as per requested output formate
    string result = year + "-";
    int monVal = findIndex(months, mon) + 1;
    if (monVal > 0)
	result = result + monVal.ToString("D2") + "-";
    int dayVal = findIndex(days, day) + 1;
    if (dayVal > 0)
	result = result + dayVal.ToString("D2");

    return result;
}

static List<string> reformatDate(List<string> dates)
{
    List<string> result = new List<string>();
    foreach (var date in dates)
    {
	result.Add(reformatDate(date));
    }
    return result;
}

*/
