// Interview2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <stdio.h>

//strlen
#include <iostream>
#include <string.h>
#include <malloc.h>
#include "unordered_map" 

#include <iomanip>
using std::endl;
using std::setw;

#include "Elements.h"

//#include "my.h"
//#include "Functions.cpp"
using namespace std;


//__________________________________________________
void CallTestFunction();
void testFunction();

void CallDisplayBits();
int DisplayBits(int);

void CallCountBits();
int CountBits(int);
int CountBitsImproved(int);
void show_binary(unsigned int);
void displayBits2(unsigned);

void CallMyPointers();
void myPointers0();
double ** GetWeeklySalary();
void myPointers1();
void myPointers2();

void CallStrToInt();
int strToInt(const char[], int);

void CallIntToStr();
void IntToStr(int, char[]);

void CallReverseSpecial();
void CallIntToStrBase();
void IntToStrBase(int, char[], int base);

void CallReverseWords();
void ReverseWords(char[]);
void reverseStr(char[], int, int);
void printStr(char[], char, int);

void CallRemoveChars();
void removeChars(char[], char[]);

void CallFirstNonRepeat();
char firstNonRepeat(char[]);

void CallBinarySearch();
int binarySearch(int *, int, int, int);
int binarySearchRecursive(int *, int, int, int);


void CallRemoveDupFromOrderedList();
int * compact(int [], int);

//Using ONLY for loops NO map or dictionary
//unordered
int callRemoveDuplicatesForLoop();
int removeDuplicatesForLoop(int[], int);

void CallRemoveDupUnordered();
void removeDupUnordered(int [], int);

void CallRemoveDupSpaces();
void RemoveDupSpaces(char *);


// Function to rotate the matrix 90 degree clockwise 
#define N 4
void rotate90Clockwise(int a[N][N]);
// Function for print matrix 
void printMatrix(int [N][N]);
void callRotate90Clockwise();

void CallrotateMatrixBy2();
//void rotateMatrixBy2(int A[][3], int, int);
void rotateMatrixBy2(int A[3][3], int, int);

void CallLinkedList();
int CreateHeadTailNodes(element **, element **, int, int);
int insertHead(element **);
void removeHead(element **);
int deleteElement(element **, element *);
int insertAfter(element *, int);
void printLinkList(element *);
int deleteLinkList(element *);
element *FindMToLastElement(element *, int);
element *confirmNonCyclic(element *);

void CallTrees();
node *CreateBinarySearchTree(int[], int);
void printBinarySearchTree(int[]);
void print_inorder(node *);

element *gHead, *gTail;

//__________________________________________________
int main(int argc, char *argv[])
{
	printf("\n");
	printf("Main Function.");
	printf("\n");
	//test();

	printf("___________________\n");
	printf("callRemoveDuplicatesForLoop\n\n");
	callRemoveDuplicatesForLoop();
	goto end;

	printf("___________________\n");
	printf("CallReverseSpecial\n\n");
	CallReverseSpecial();

	goto end;

	printf("___________________\n");
	printf("CallTestFunction\n\n");
	CallTestFunction();

	printf("___________________\n");
	printf("CallIntToStrBase\n\n");
	CallIntToStrBase();
	

	printf("___________________\n");
	printf("CallDisplayBits\n\n");
	CallDisplayBits();

	printf("___________________\n");
	printf("CallCountBits\n\n");
	CallCountBits();

	printf("___________________\n");
	printf("CallMyPointers\n\n");
	CallMyPointers();

	printf("___________________\n");
	printf("CallStrToInt\n\n");
	CallStrToInt();

	printf("___________________\n");
	printf("CallIntToStr\n\n");
	CallIntToStr();

	printf("___________________\n");
	printf("CallIntToStrBase\n\n");
	CallIntToStrBase();
	

	printf("___________________\n");
	printf("CallReverseWords\n\n");
	CallReverseWords();

	printf("___________________\n");
	printf("CallRemoveChars\n\n");
	CallRemoveChars();

	printf("___________________\n");
	printf("CallFirstNonRepeat\n\n");
	CallFirstNonRepeat();

	printf("___________________\n");
	printf("CallBinarySearch\n\n");
	CallBinarySearch();

	printf("___________________\n");
	printf("CallrotateMatrixBy2\n\n");
	CallrotateMatrixBy2();

	printf("___________________\n");
	printf("CallRemoveDupFromOrderedList\n\n");
	CallRemoveDupFromOrderedList();

	printf("___________________\n");
	printf("callRemoveDuplicatesForLoop\n\n");
	callRemoveDuplicatesForLoop();

	printf("___________________\n");
	printf("CallRemoveDupUnordered\n\n");
	CallRemoveDupUnordered();

	printf("___________________\n");
	printf("CallRemoveDupSpaces\n\n");
	CallRemoveDupSpaces();

	printf("___________________\n");
	printf("CallLinkedList\n\n");
	CallLinkedList();

	printf("___________________\n");
	printf("CallTrees\n\n");
	CallTrees();

	end:
	return 0;
}


//====================== Implementation ====================================
//__________________________________________________
void CallTestFunction()
{
	testFunction();
}

void testFunction()
{

	unordered_map<int, node*> mp;

	mp.insert(make_pair(5, nullptr));
	mp.insert(make_pair(10, nullptr));
	mp.insert(make_pair(8, nullptr));

	for (auto x : mp) cout << x.first << x.second;

}
//-------------------------------------------------
//A?BCD --> D?CBA
bool isAlphaNumeric(char x)
{
	return ((x >= 'A' && x <= 'Z') || (x >= 'a' && x <= 'z') || (x >= '0' && x <= '9'));
}

//isAlphaNumeric
//void reverse(char str[])
//string reverseSpecial(string s)
string reverseSpecial(string s)
{
	//Initialize the R & L markers
	//int r = strlen(s) - 1, l = 0;
	//int r = s.length - 1, l = 0;
	int r = s.length() - 1;
	//int r = strlen(s) - 1;
	int l = 0;

	//Traverse the string from both sides/ends.
	while (r >= l)
	{
		// A?BCD
		//ignore any specail char
		if (!isAlphaNumeric(s[l]))
			l++;
		else if (!isAlphaNumeric(s[r]))
			r--;
		else 	//Neither l nor r are not a speical character 
		{
			swap(s[l], s[r]);
			l++;
			r--;
		}

	}
	return s;
}


string reverseSpecial2(string s)
{
	for (int i = 0, j = s.length() - 1; i < s.length() / 2; i++, j--) {
		while (!isAlphaNumeric(s[i])) {
			i++;
		}
		while (!isAlphaNumeric(s[j])) {
			j--;
		}
		swap(s[i], s[j]);
	}
	//cout << s << endl;     //dlro$W olleH
	//printf("The string is %s \n", s);

	return s;
}
//__________________________________________________
void CallReverseSpecial()
{
	//string s = "Hell$o World"; 
	string s = "A$BCD";

	reverseSpecial(s);
	printf("The string is %s \n", s);
}

//__________________________________________________
void CallDisplayBits()
{
	DisplayBits(3);
}

int DisplayBits(int n)
{
	printf("Display bits for n=%d \n", n);
	//int temp=0%4;
	//printf ("n MOD 4=%d \n", temp);
	for (int i = 0; i < 32; i++)
	{
		//printf ("%d, %d \n", i, (i%4));
		if ((i >= 4) & (i % 4 == 0))
			printf(" ");
		if (n & (1 << i))
			printf("1");
		else
			printf("0");
	}
	printf("\n");

	return 0;
}

//__________________________________________________
void CallCountBits()
{
	CountBits(3);
	CountBitsImproved(3);

	unsigned u = 123;
	cout << "Here's the number in binary: ";
	show_binary(u);

	cout << "Here's the complement of the number: ";
	show_binary(~u);

	unsigned value = 21845;
	cout << "show_binary: " << value << ": ";
	show_binary(value);

	displayBits2(value);
}

int CountBits(int n)
{
	int bCount = 0;

	printf("Counting bits for n=%d \n", n);
	for (int i = 0; i < 32; i++)
		if (n & (1 << i))
			bCount++;
	printf("\n");
	printf("bCount= %d\n", bCount);
	return 0;
}

int CountBitsImproved(int n)
{
	int bCount = 0;

	printf("Counting bits for n=%d \n", n);
	while (n)
	{
		n = n & (n - 1);
		bCount++;
	}
	printf("\n");
	printf("bCount= %d\n", bCount);
	return 0;
}

void show_binary(unsigned int u)
{
	int t;

	for (t = 128; t>0; t = t / 2)
		if (u & t) cout << "1 ";		//to test a bit &
		else cout << "0 ";

		cout << "\n";
}

void displayBits2(unsigned value)
{
	const int SHIFT = 8 * sizeof(unsigned) - 1;
	const unsigned MASK = 1 << SHIFT;
	cout << "MASK:" << MASK << endl;

	cout << "show_binary: " << MASK << ": ";
	show_binary(MASK);
	cout << endl;

	cout << setw(10) << value << " = ";

	for (unsigned i = 1; i <= SHIFT + 1; i++) {
		cout << (value & MASK ? '1' : '0');
		value <<= 1;

		if ((i & 8) == 0)
			cout << ' ';
	}

	cout << endl;
}

//__________________________________________________
void CallMyPointers()
{
	myPointers0();
	myPointers1();
	myPointers2();
}

//---------------------------------------------------------------------------
void myPointers0()
{
	double WeeklySalary = **GetWeeklySalary();

	cout << "Weekly Salary: " << WeeklySalary << endl;

	return;
}
//---------------------------------------------------------------------------

double ** GetWeeklySalary()
{
	double w = 880.24;
	double *ws = &w;
	double **wwss = &ws;

	return wwss;
}

void myPointers1()
{
	//int const * Constant2
	//is an alternative syntax which does the same, whereas 
	//int * const Constant3

	char A[10] = "helloA";
	char B[10] = "helloB";

	//**char *myp1 = "hi1";
	//**char *myp2 = "hi2";

	//Address these
	//----------------------------------------
	//p1 is a pointer to a char const
	//Can change where it points. Can NOT change the contents. 
	const char *p1;		//can assign to any other pointer const or otherwise.  
						//Can NOT change the contents of what it points to.
						//p2 is a pointer to a const char
	char const *p2;		//same as above.

	p1 = A;
	p1 = B;
	//*p1='x'; //or p1[0]='x';		//can NOT change the value it points to.

	p2 = A;
	p2 = B;
	//*p2='x'; //or p1[0]='x';		//can NOT change the value it points to.

	//----------------------------------------
	//p3 is a const pointer to a char
	//Can NOT change where it points. Can change the contents. 
	//**char * const p3 = "hi1p3";			//Constant Must be initialized. Once set can NOT change.
										//p3=A;			//Can NOT change the address. i.e can NOT point somewhere else.
										//p3=B;

										//p3="hi2p3";	//Can NOT change the address. i.e can NOT point somewhere else.

	//**p3[0] = 'x';		//Can change contents.

						//----------------------------------------
	const char * const p4 = "HelloP4";
	//p4=B;			//Can NOT change where it points.
	//p4[0]='x';	//Can NOT the contents.
}

void myPointers2()
{
	printf("\nDeclaring Pointers");
	printf("\n**********************\n");
	//Address these (Read right to left.  i.e <---)
	//p1 is a pointer to a char const
	//const char *p1;		//can assign to any other pointer const or otherwise.  
	//Can NOT change the contents of what it points to.
	//p2 is a pointer to a const char
	//char const *p2;		//same as above.

	//p3 is a const pointer to a char
	//char * const p3;

	//p4 is a const pointer to a char const 
	//const char * const p4;

	//"Upon declaration char *p can be initialized to point to a constant String.
	//e.g so here "AlSalam Alikum" is a constant string.
	char str[15] = "AlSalam Alikum";
	char *p = str;

	//"AlSalam Alikum" - str once declared it's declared into the read ONLY memory segment

	printf("*p=");
	for (int i = 0; i < (signed)strlen("AlSalam Alikum"); i++)
		printf("%c", p[i]);
	printf("\n");



	printf("\nDeclaring char const Pointer");
	printf("\n**********************\n");
	//Can point to different location in memory.  
	//But can NOT change the contents of the location.
	char const * ptr;

	printf("\nPoint to a regular pointer");
	printf("\n**********************\n");
	//ptr is a const ptr.  a is an array which is a constant pointer
	//This won't work - need to add const
	//char *myp1; //="hi1";
	char const *myp1; //="hi1";
	//SHould fail
	char *myp2; //="hi2";

				//Point ptr to an array A works
	char A[10] = "hello";

	//ptr is a const ptr.  A is an array which is a constant pointer
	ptr = A;

	printf("print a[10]= ");
	for (int i = 0; i < 10; i++)
		printf("%c", ptr[i]);
	printf("\n");

	//Point ptr to a regular pointer works
	//re-assing constant ptr to a regular pointer myp;
	myp1 = "abc";
	ptr = myp1;

	//Point ptr to an array B works
	//Declare another array
	char B[10] = "myhello";
	//re-assign ptr to the new array.
	ptr = B;

	printf("print b[10]= ");
	for (int i = 0; i < 10; i++)
		printf("%c", ptr[i]);
	printf("\n");

	//All about examples ptr was changed to point to a different memory location.
	//But can NOT change the contents of what is being pointed at.
	//e.g.
	//With regular ptrs you can
	char myV = 'a';
	myp1 = &myV;

	//** Testing
	//** *myp1 = 'x';
	//** *(myp1 + 1) = '\0';
	//Change contents of a const char pointer is NO.
	//ptr[0]='x';		//Fails to compile. cannot assign to a variable that is const
	//*ptr='x';			//Fails to compile. cannot assign to a variable that is const

	printf("\n\n");
}

//__________________________________________________
//atoi
void CallStrToInt()
{
	printf("Str=12345");

	char str[5];
	str[0] = '1';
	str[1] = '2';
	str[2] = '3';
	str[3] = '4';
	str[4] = '5';

	//strcpy_s(str, "12345");
	int num = strToInt(str, 5);
	printf("num = %d\n", num);
	printf("Salam\n");
}


/*
ASCII	Hex	Symbol
48		30		0
49		31		1
50		32		2
51		33		3
52		34		4
53		35		5
54		36		6
55		37		7
56		38		8
57		39		9
*/

//atoi
int strToInt(const char str[], int len)
{
	//Scan str
	//		num=num*10;
	//		num=num+str[i++]-'0';

	//Given an str= 12345 --> num=12345
	int i = 0, num = 0, isNeg = 0;

	if (str[0] == '-')
	{
		isNeg = 1; i++;
	}

	while (str[i])
	{
		num = num * 10;
		num = num + str[i++] - '0';
	}
	// from IntToStr --> tempStr[i++] = (num % 10) + '0';			//ASCII '0' is 48, ASCII '9' 57
	if (isNeg)
	{
		num *= -1;
	}

	return num;
}

//itoa
//__________________________________________________
void CallIntToStr()
{
	int i = 0;
	int num = 1234;
	int const SIZE = 8;
	//char *myStr="       ";		//Causes an assert
	char myStr[SIZE] = "";

	//int result = scanf( "%d ", &i);
	//printf("result=%d", result);

	printf("\n");
	printf("num= %d\n\n", num);
	IntToStr(num, myStr);

	//int len = strlen(myStr);
	//printf("len=%d\n", len);
	printf("\"");
	while (i < SIZE)
		printf("%c", myStr[i++]);
	printf("\"");

	printf("\n");
}


/*
ASCII	Hex	Symbol
48		30		0
49		31		1
50		32		2
51		33		3
52		34		4
53		35		5
54		36		6
55		37		7
56		38		8
57		39		9
*/
//tempStr[i++] = (num % 10) + '0';
//tempStr[i++] =   say 6 + 48 = 54 ascii
// 54 ascii is 6 digit

#define MAX_DIGISTS_INT 10
void IntToStr(int num, char str[])
{
	//1. Create large enough buffer (one more for NULL and one more for sign) 
	//										- or count no of digits
	//2. Scan the num and place the digit into the buffer.
	//		tempStr[i++]=(num%10)+'0';
	//		num=num/10;
	//3. Reverse

	//Given a num= 12345 --> str="12345"
	int i = 0, j = 0, isNeg = 0;

	//Count the no of digits in a no
	int temp = 0, count=0;
	temp /= 10;
	while (temp > 0)
	{
		count++;
		temp = temp / 10;
	}
	
	//1. Create large enough buffer (one more for NULL and one more for sign)
	// or allocate using malloc or calloc the size of count
	int *tempStr;
	tempStr = new int[count];
	//char tempStr[MAX_DIGISTS_INT + 2];

	if (num < 0)
	{
		isNeg = 1;
		num *= -1;
	}

	//2. Scan the num and place the digit into the buffer.
	//Given a num= 12345 --> str="12345"
	i = 0;
	do {
		//printf("num= %d, Mode=%d \n", num, temp);
		tempStr[i++] = (num % 10) + '0';			//ASCII '0' is 48
		//printf("tempStr[%d]= %c\n", i, tempStr[i]);
		num = num / 10;
	} while (num);

	if (isNeg)
		tempStr[i++] = '-';

	//Print
	/*temp=i; i--;
	while (i > -1)
	printf("after scan- tempStr[%d]= %c\n", i, tempStr[i--]);
	i=temp;*/

	//3. Reverse
	temp = i;
	//printf("%d\n", i);
	while (i > 0)
	{
		printf("Values - str[%d]= %c, tempStr[%d]=%c \n", --i, str[j++], i, tempStr[i]);
		//str[j++]=tempStr[--i];
		str[j] = tempStr[i];
	}
	tempStr[j] = '\0';

	//Print
	//for (int k=0; k<4; k++)
	//while (j > -1)
	//	printf("tempStr[%d]= %c\n", k, tempStr[k]);

	return;
}

//itoa
//__________________________________________________
void CallIntToStrBase()
{
	int i = 0;
	int num = 1234;
	int const SIZE = 8;
	int base[4];

	base[0] = 2;
	base[1] = 8;
	base[2] = 10;
	base[3] = 16;

	//Also right
	//int base[] = { 2, 8, 10, 16 };
	//most likely right
	//int base[4] = { 2, 8, 10, 16 };

	//char *myStr="       ";		//Causes an assert
	char myStr[SIZE] = "";

	//int result = scanf( "%d ", &i);
	//printf("result=%d", result);

	for (int var : base)
	{
		printf("\n");
		printf("num= %d\n\n", num);
		IntToStrBase(num, myStr, base[var]);

		//int len = strlen(myStr);
		//printf("len=%d\n", len);
		printf("\"");
		while (i < SIZE)
			printf("%c", myStr[i++]);
		printf("\"");

		printf("\n");
	}

}

//
void IntToStrBase(int num, char str[], int base)
{
	//1. Create large enough buffer (one more for NULL and one more for sign)
	//2. Scan the num and place the digit into the buffer.
	//		tempStr[i++]=(num%10)+'0';
	//		num=num/10;
	//3. Reverse

	//Given a num= 12345 --> str="12345"
	int i = 0, j = 0, isNeg = 0, temp = 0;

	//1. Create large enough buffer (one more for NULL and one more for sign)
	char tempStr[MAX_DIGISTS_INT + 2];

	if (num < 0)
	{
		isNeg = 1;
		num *= -1;
	}

	//2. Scan the num and place the digit into the buffer.
	//Given a num= 12345 --> str="12345"
	i = 0;
	do {
		int rem = num % base;			//1234 % 10 = 4 ONLY
		//printf("num= %d, Mode=%d \n", num, temp);
		tempStr[i++] = (rem > 9)? ((rem - 10) + 'a') : (rem + '0');
		//printf("tempStr[%d]= %c\n", i, tempStr[i]);
	} while (num);

	if (isNeg)
		tempStr[i++] = '-';

	//Print
	/*temp=i; i--;
	while (i > -1)
	printf("after scan- tempStr[%d]= %c\n", i, tempStr[i--]);
	i=temp;*/

	//3. Reverse string
	temp = i;
	//printf("%d\n", i);
	while (i > 0)
	{
		printf("Values - str[%d]= %c, tempStr[%d]=%c \n", --i, str[j++], i, tempStr[i]);
		//str[j++]=tempStr[--i];
		str[j] = tempStr[i];
	}
	tempStr[j] = '\0';

	//Print
	//for (int k=0; k<4; k++)
	//while (j > -1)
	//	printf("tempStr[%d]= %c\n", k, tempStr[k]);

	return;
}

//__________________________________________________
//Reverse words in a sentence.
//e.g. This is my sentence. --> sentence. my is This

void CallReverseWords()
{
	int i = 0; int const SIZE = 21;
	//char *myStr="This is my sentence.";
	char myStr[SIZE] = "This is my sentence.";

	printf("\n");
	printf("Goal: e.g. This is my sentence. --> sentence. my is This\n");
	printf("\n");

	printStr(myStr, '1', SIZE);

	ReverseWords(myStr);

	printStr(myStr, '2', SIZE);

	printf("\n");
}

void ReverseWords(char str[])
{
	//Reverse the string
	//scan string
	//Only if not a space
	//save position
	//scan for space
	//Backup one up
	//reverse word.
	//increment counter

	int start = 0, end = 0, len = 0;
	len = strlen(str);

	// Goal: e.g. This is my sentence. -- becomes -> ecnetnes. ym si sihT
	//Reverse string
	printStr(str, 'b', len);
	reverseStr(str, start, len - 1);
	printStr(str, 'a', len);

	//Scan String - for next space/non-word
	while (end < len)
	{
		if (str[end] != ' ')
		{
			//Save position
			start = end;

			//Scan for next space/non-word
			while (end < len && str[end] != ' ')
				end++;

			//move one back
			end--;

			//Goal: e.g. This is my sentence. --> sentence. my is This
			// e.g. ecnetnes. ym si sihT -- becomes -> sentence. ym si sihT
			//Reverse word
			reverseStr(str, start, end);
		}
		end++;
	}

	printStr(str, 'e', len);
	return;
}

void reverseStr(char str[], int start, int end)
{
	char temp;

	while (start < end)
	{
		temp = str[start];
		str[start] = str[end];
		str[end] = temp;

		start++; end--;
	}
	return;
}

void printStr(char str[], char msg, int mylen)
{
	int beg = 0;
	printf("%c: ", msg);
	printf("\n");
	while (beg < mylen)
	{
		printf("%c", str[beg++]);
	}
	printf("\n");

	return;
}

//__________________________________________________
int const SIZE1 = 39 + 1;		//plus NULL
int const SIZE2 = 6 + 1;		//plus NULL

void CallRemoveChars()
{
	//Given two strings.  Remove the 2nd str from the 1st
	//e.g. Str1="Battle of the Vowels: Hawaii vs. Grozny"
	//e.g  Rmove Str2="aeiou"
	//Result: Bttl f th Vwls:Hw vs.Grzny"	(no aeiou letters in the result)

	printf("Str:    Battle of the Vowels: Hawaii vs. Grozny\n");
	printf("Remove: aeiou\n");
	printf("Result: Bttl f th Vwls:Hw vs.Grzny\n");

	char Str[SIZE1] = "Battle of the Vowels: Hawaii vs. Grozny";
	char Remove[SIZE2] = "aeiou";

	printStr(Str, '1', SIZE1);
	printStr(Remove, '1', SIZE2);
	removeChars(Str, Remove);
	printStr(Str, '2', SIZE1 - SIZE2);
}

void removeChars(char str[], char remove[])
{
	//1. Create and initalize removearray[256].
	//2. Scan removesrc array but for setting removeArray to 1 (delete letter) if matches found.
	//3. Scan Str array and Copy chars to Str array (itself) unless they are marked for delete.

	//1. Create and initialize remove array.
	int src, dst;
	int removeArray[256];

	for (int src = 0; src<256; src++)
		removeArray[src] = 0;

	//2. Scan the min remove list/array and mark the newly created 256 array letters to be deleted.
	src = 0;
	while (remove[src])
		removeArray[remove[src++]] = 1;		//mark for delete

											//3. Copy chars to new array unless they are marked for delete.
	src = dst = 0;
	do
	{
		if (removeArray[str[src]] == 0)
			str[dst++] = str[src];
	} while (str[src++]);

	printf("in\n");
	printStr(str, 'i', SIZE1 - SIZE2);

	return;
}

//__________________________________________________
int const SIZE3 = 5 + 1;		//plus NULL

void CallFirstNonRepeat()
{
	char myChar;
	//Given two strings.  Remove the 2nd str from the 1st
	//e.g. Str1="Battle of the Vowels: Hawaii vs. Grozny"
	//e.g  Rmove Str2="aeiou"
	//Result: Bttl f th Vwls:Hw vs.Grzny"	(no aeiou letters in the result)

	printf("Str:    total\n");
	printf("Find: Find first non-repeat char in total is o.\n");
	printf("Result: o \n");

	char Str[SIZE1] = "total";

	printStr(Str, '1', SIZE3);
	myChar = firstNonRepeat(Str);
	printf("First Non repeat in Str is: %c\n", myChar);

}

char firstNonRepeat(char str[])
{
	//1. Scan Str. for ever using 2 prts. e.g. total
	//1. Exit condition.
	//2. if repeat is found condition.
	//3. Keep incrementing moving pointer.

	//1. Scan Str. for ever using 2 prts. e.g. total
	char *p, *mp;

	//initialize
	p = str;
	mp = p + 1;
	int len = strlen(str);

	while (1)
	{
		//exit condition
		if (*p != *mp && str + len - 1 == mp)
			return *p;

		//if repeat is found condition
		if (*p == *mp)
		{
			p++;
			mp = p + 1;
			continue;
		}

		//keep moving
		mp++;
	}
	printf("in\n");
}

//__________________________________________________
int const SIZE4 = 5 + 1;		//plus NULL

#define E_TARGET_NOT_IN_ARRAY	-1
#define E_LIMITS_REVERSED		-2
#define E_ARRAY_UNORDERED		-3

								//Array is sorted.
void CallBinarySearch()
{
	//Given a sorted Array.  search it using binary search to find a target.
	//e.g. int Array="123456" find 4
	//Result: index=3

	int lower = 0, upper = 0, target = 0;
	int myTarget = 4, myTargetIndex = 0;
	int Array[SIZE4] = { 1,2,3,4,5 };

	printf("int Array:    12345\n");
	printf("Find: 4 \n");
	printf("Result index:3 \n");

	//myTargetIndex = binarySearch(Array, lower, SIZE4, myTarget); //? asserting
	printf("Element %d in the Array is at index: %d\n", myTarget, myTargetIndex);
}

//Array is sorted.
int binarySearch(int * Array, int lower, int upper, int target)
{
	//1. check valid limits
	//1. Scan Array for ever.
	//1. check if target does NOT exist in array.
	//2. Check for unorder array.
	//3. Find Target
	//1. Using if else if else search using Center.
	int center;

	if (lower > upper)
		return E_LIMITS_REVERSED;

	while (1)
	{
		int range = upper - lower;

		//1. check if target does NOT exist in array.
		if (range == 0 && Array[lower] != target)
			return E_TARGET_NOT_IN_ARRAY;

		//2. Check for unorder array
		if (Array[lower] > Array[upper])
			return E_ARRAY_UNORDERED;

		//3. Find Target
		center = range / 2 + lower;

		if (target == Array[center])
			return center;
		else if (target <  Array[center])
		{
			upper = center - 1;
		}
		else
			lower = center + 1;

	}
	return 1;
	printf("\n");
}

//Array is sorted.
int binarySearchRecursive(int * Array, int lower, int upper, int target)
{
	//1. check valid limits
	//1. Scan Array for ever.
	//1. check if target does NOT exist in array.
	//2. Check for unorder array.
	//3. Find Target
	//1. Using if else if else search using Center.
	int center;

	if (lower > upper)
		return E_LIMITS_REVERSED;

	while (1)
	{
		int range = upper - lower;

		//1. check if target does NOT exist in array.
		if (range == 0 && Array[lower] != target)
			return E_TARGET_NOT_IN_ARRAY;

		//2. Check for unorder array
		if (Array[lower] > Array[upper])
			return E_ARRAY_UNORDERED;

		//3. Find Target
		center = range / 2 + lower;

		if (target == Array[center])
			return center;
		else if (target <  Array[center])
		{
			upper = center - 1;
		}
		else
			lower = center + 1;

	}
	return 1;
	printf("\n");
}

//Remove Dups from a sorted array
// 12
//__________________________________________________
void CallRemoveDupFromOrderedList()
{
	//int const SIZE = 7;
	//int a[SIZE] = { 1,2,2,3,4,4,5 };
	//int a[SIZE] = { 1,1,1,1,1,1,1 };
	//int const SIZE = 1;
	//int a[SIZE] = { 1 };
	//int const SIZE = 6;
	//int a[SIZE] = { 1,2,1,2,1,2 };		//Fails because it's not ordered.
	int const SIZE = 6;
	int a[SIZE] = { 1,1,1,2,2,2 };		//Fails because it's not ordered.

	int * lastItem;

	lastItem = compact(a, SIZE);

	cout << "The full list with dups" << endl;
	cout << "\"";
	for (int i = 0; i < SIZE; i++)
	{
		cout << a[i];
	}
	cout << "\"" << endl;

	if (lastItem == NULL) {
		cout << "Obviously no dups" << endl;
		return;
	}

	cout << "---------------------------" << endl;
	cout << "Last item: " << *lastItem;
	cout << endl;

	cout << "The list without dups" << endl;
	cout << "\"";
	for (int *i = a; i <= lastItem; i++)
	{
		cout << *i;
	}
	cout << "\"" << endl;
}

//CallRemoveDupFromOrderedList
int * compact(int a[], int size)
{
	int *ptr1, *ptr2, *ptr3;
	ptr1 = a; ptr2 = a + 1;		//Simple answer is: it adds a number of bytes equal to the size of the data type of the pointer. If that type is int, then it increases with 4 or 8, depending on the architecture
	bool flag1 = false;
	bool flag2 = false;
	int count = 0;
	ptr3 = ptr1 + size - 1;

	//If size is one there are no dups.
	if (size == 1) return NULL;

	//cout << (*ptr3);
	while (ptr2 <= ptr3)
	{
		if (*ptr1 != *ptr2)
		{
			ptr1++;
			if (flag1)
			{
				*ptr1 = *ptr2;
				flag1 = false;
				if (ptr2 == ptr3) break;
			}
		} else {
			flag1 = true;
			*ptr2++;
			count++;
		}
	}

	return ptr1;
}


//------------------------------------------
//Using ONLY for loops NO map or dictionary - BAD

// Driver code
int callRemoveDuplicatesForLoop()
{
	int arr[] = { 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1 };  //26 items
	int n = sizeof(arr) / sizeof(arr[0]);		//n will equal 26, sizeof(arr) 26* 4 bytes = 126, sizeof(arr[0]) of int, 

	n = removeDuplicatesForLoop(arr, n);

	for (int i = 0; i<n; i++)
		cout << arr[i] << " ";

	return 0;
}


int removeDuplicatesForLoop(int arr[], int n)
{
	int j = 0;

	for (int i = 0; i < n; i++) {
		for (int j = 0; j<i; j++) {

			if (arr[i] == arr[j]) {
				n--;
				for (int k = i; k<n; k++) {
					arr[k] = arr[k + 1];
				}
				i--;     // you forgot to decrement i
			}
		}
	}

	return n;
}


//Remove Dups from a unsorted array
//Attempt using map
//__________________________________________________
void CallRemoveDupUnordered()
{
	int arr[] = { 1, 2, 5, 1, 7, 2, 4, 2 };
	int n = sizeof(arr) / sizeof(arr[0]);
	removeDupUnordered(arr, n);
}

void removeDupUnordered(int arr[], int n)
{
	// Hash map which will store the 
	// elements which has appeared previously. 
	unordered_map<int, bool> mp;

	for (int i = 0; i < n; ++i) {

		// Print the element if it is 
		// there in the hash map 
		if (mp.find(arr[i]) == mp.end()) {
			//cout << mp.find(arr[i]);
			cout << arr[i] << " ";
		}

		// Insert the element in the hash map 
		mp[arr[i]] = true;
	}
}

//__________________________________________________
void CallRemoveDupSpaces()
{
	char const *str = "  a b   c  ";

	//cout << "hi" << endl;

	//RemoveDupSpaces(str);  //? asserting

	cout << "\"";
	for (int i = 0; i<12; i++)
		cout << str[i];
	cout << "\"" << endl;
}

void RemoveDupSpaces(char *str)
{
	char *p1 = str;
	char *p2 = str;
	int len = strlen(str);
	cout << "len:" << len << endl;
	cout << "len bTOe:" << ((*str) + len - 1) << endl;
	cout << "\"";
	for (int i = 0; i<12; i++)
		cout << p1[i];
	cout << "\"" << endl;

	while (1)
	{
		cout << "-" << *p1 << "-";
		cout << "_" << p2 - p1 << "_";
		while ((*p2 == ' ') && (p2 < str + len - 1))
			p2++;
		if ((p2 - p1) > 1)
		{
			p1++;
			*p1 = *p2;
			*p2 = ' ';

			cout << "^" << *p1 << "^" << endl;
			cout << "#" << *p2 << "#" << endl;
		}
		//exit condition
		if ((p1 == (str)+len - 1))
			break;
	}
}
//https://www.geeksforgeeks.org/rotate-a-matrix-by-90-degree-in-clockwise-direction-without-using-any-extra-space/

// Function to rotate the matrix 90 degree clockwise 
void rotate90Clockwise(int a[N][N])
{

	// Traverse each cycle 
	for (int i = 0; i < N / 2; i++) {
		for (int j = i; j < N - i - 1; j++) {

			// Swap elements of each cycle 
			// in clockwise direction 
			int temp = a[i][j];
			a[i][j] = a[N - 1 - j][i];
			a[N - 1 - j][i] = a[N - 1 - i][N - 1 - j];
			a[N - 1 - i][N - 1 - j] = a[j][N - 1 - i];
			a[j][N - 1 - i] = temp;
		}
	}
}

// Function for print matrix 
void printMatrix(int arr[N][N])
{
	for (int i = 0; i < N; i++) {
		for (int j = 0; j < N; j++)
			cout << arr[i][j] << " ";
		cout << '\n';
	}
}

// Driver code 
void callRotate90Clockwise()
{
	int arr[N][N] = { { 1, 2, 3, 4 },
	{ 5, 6, 7, 8 },
	{ 9, 10, 11, 12 },
	{ 13, 14, 15, 16 } };
	rotate90Clockwise(arr);
	printMatrix(arr);
}

//__________________________________________________
void CallrotateMatrixBy2()
{
	int A[3][3] = { { 1,2,3 },{ 4,5,6 },{ 7,8,9 } };

	for (int i = 0; i<3; i++)
		for (int j = 0; j<3; j++)
		{
			cout << "A[" << i << "][" << j << "]: ";
			cout << A[i][j] << endl;
		}

	rotateMatrixBy2(A, 3, 3);
}

//void rotateMatrixBy2(int A[][3], int i, int j)
void rotateMatrixBy2(int A[3][3], int i, int j)
{

	for (int i = 0; i<3; i++)
		for (int j = 0; j<3; j++)
		{
			cout << "A[" << i << "][" << j << "]: ";
			cout << A[i][j] << endl;
		}
}

//__________________________________________________
void CallLinkedList()
{
	//Create 2 Nodes a head and a tail.
	element *head, *tail, *deleteMe, *temp;

	CreateHeadTailNodes(&head, &tail, 1, 100);

	deleteMe = head;
	insertHead(&head);
	removeHead(&head);
	deleteElement(&head, deleteMe);
	insertAfter(gHead, 10);
	insertAfter(gHead, 20);
	insertAfter(gHead, 30);
	insertAfter(gHead, 40);

	//printLinkList(head);		//? fix they loop

	//deleteLinkList(head);		//? fix they loop

	//temp= FindMToLastElement(head,10);	//? fix they loop

	confirmNonCyclic(head);
}

int insertHead(element **head)
{
	element *newElm;
	newElm = (element *)malloc(sizeof(element));
	if (!newElm)
		return 0;
	newElm->next = *head;
	*head = newElm;
	return 1;
}

void removeHead(element **head)
{
	element *curPos;

	if (head) {
		curPos = (*head)->next;
		free(*head);
		*head = curPos;
	}
	return;
}

//delete an element
int deleteElement(element **head, element *deleteMe)
{
	//1. Make sure head can be deleted.
	//2. Make sure Make sure deleteMe exist
	//3. Make sure 

	element * curPos = *head;

	if (!*head)
		return 0;

	//Not needed.  The while loop will fall throw if not found.
	//Delete for optimization.
	if (!deleteMe)
		return 0;

	//What if deleting head, and head is a single element
	if (*head == deleteMe)
	{
		*head = curPos->next;
		free(deleteMe);

		if (!*head)
			gTail = NULL;
		return 1;
	}

	//Scan list for deleteMe item.
	while (curPos)
	{
		if (curPos->next == deleteMe)
		{
			curPos->next = (curPos->next)->next;
			deleteMe->next = NULL;
			free(deleteMe);

			if (curPos->next = NULL)
				gTail = curPos;

			return 1;
		}
		curPos = curPos->next;
	}
	//deleteMe NOT found
	return 0;
}

//Insert 
int CreateHeadTailNodes(element **head, element **tail, int headData, int tailData)
{
	//1. Create memory location for new node.
	//2. Check if inserting at begining of list.
	//3. Check if inserting at the end of the link list.
	//3. Scan linked list and insert node.

	*head = (element *)malloc(sizeof(element));
	if (!*head)
		return 0;

	(*head)->data = (void *)headData;		//?
	(*head)->mydata = headData;

	cout << "Head Value: " << ((*head)->data) << endl;
	cout << "Head2 Value: " << (*head)->mydata << endl;

	*tail = (element *)malloc(sizeof(element));
	if (!*tail)
		return 0;

	(*tail)->data = (void *)(tailData);		//?
	(*tail)->mydata = tailData;

	cout << "Tail Value: " << (*tail)->data << endl;
	cout << "Tail Value1: " << (*tail)->mydata << endl;

	gHead = *head;
	gTail = *tail;

	return 1;
}

//insert after the element elem.
int insertAfter(element * elem, int data)
{

	//1. Create memory allocation for new node.
	//2. Insert at begining of list. check if list is empty - if so add to head.
	//3. Scan link list to insert after given node
	//3. check if adding to last element 

	element *newElm, *curPos = gHead;

	//1. Create memory allocatoin for new node.
	newElm = (element *)malloc(sizeof(element));
	if (!newElm)
		return 0;

	newElm->mydata = data;

	//Check if list is empty - if so add to head.
	if (!gHead)
	{
		newElm->next = gHead;
		gHead = newElm;

		//Check if list is empty.
		if (!newElm->next)
			gTail = newElm;

		return 1;
	}

	//3. Scan link list searching for elem
	while (curPos)
	{
		if (curPos = elem) {
			newElm = curPos->next;
			curPos->next = newElm;

			//Special case end of list
			if (curPos == gTail) {
				gTail = newElm;
			}
			return 1;
		}
		curPos = curPos->next;
	}

	//delete node if not found
	delete newElm;
	return 0;
}

void printLinkList(element *head)
{
	element *curPos = head;

	while (curPos)
	{
		cout << "value: " << curPos->mydata << endl;
		curPos = curPos->next;
	}
}

//Delete link list.  Need 2 ptrs
int deleteLinkList(element *head)
{
	element *deleteMe = head, *next = head->next;

	//might need this might NOT
	if (!head)
		return 0;

	while (deleteMe)
	{
		next = deleteMe->next;
		free(deleteMe);
		deleteMe = next;

		cout << "looping" << deleteMe->mydata << endl;
	}

	return 1;
}

//Array is sorted.
//Find mth element from the end.
//Need two pointers.  1st moved mth times. 2nd points to head. Then both move together.
element *FindMToLastElement(element *head, int m)
{
	//1. check valid limits
	//1. Scan Array for ever.
	//1. check if target does NOT exist in array.
	//2. Check for unorder array.
	//3. Find Target
	//1. Using if else if else search using Center.

	int nCounter = 0;
	element *current = head, *mBehind = head;

	//Make 1st pointer move mth times.
	for (int i = 0; i < m; i++)
	{
		if (current->next)
			current = current->next;
		else
			return NULL;		//if this is reached before i=m is ready then do exit.
	}

	//Make 2nd Pointer point to head. Then move both one by one.
	while (current->next)
	{
		current = current->next;
		mBehind = mBehind->next;
	}

	return mBehind;
}

element *confirmNonCyclic(element *head)
{
	element *p1 = head, *p2 = head;

	do {
		p1 = p1->next;
		p2 = p2->next->next;
	} while (p1 != p2);
	return p1;
}


//__________________________________________________
void CallTrees()
{
	node *root, *curPos;
	int seed = 5;
	int A[6] = { '3','1','4','10','7','12' };

	CreateBinarySearchTree(A, 5);
	printBinarySearchTree(A);
	//curPos = Find
}

node *CreateBinarySearchTree(int A[], int seed)
{
	node *temp = NULL, *curPos = NULL; //, *root=NULL;
	int i = 0;

	//root
	try {
		node *root = new node;
	}
	catch (bad_alloc xa) {
		cout << "Allocation Failed \n";
		return NULL;
	}
	cout << "hi" << endl;
	root->value = seed;
	cout << "hi2" << endl;
	cout << (root->value) << endl;

	int iii = 0;
	int result = scanf_s("%d ", &iii);
	printf("result=%d", iii);

	//1st level 3 10
	try {
		node *temp = new node;
	}
	catch (bad_alloc xa) {
		cout << "Allocation Failed \n";
		return NULL;
	}
	root->left = temp;
	temp->value = A[0];

	try {
		node *temp = new node;
	}
	catch (bad_alloc xa) {
		cout << "Allocation Failed \n";
		return NULL;
	}
	root->right = temp;
	curPos->value = A[3];


	//2nd level 1 4 7 12
	curPos = root->left;
	try {
		node *temp = new node;
	}
	catch (bad_alloc xa) {
		cout << "Allocation Failed \n";
		return NULL;
	}
	curPos->left = temp;
	temp->value = A[1];

	//4
	try {
		node *temp = new node;
	}
	catch (bad_alloc xa) {
		cout << "Allocation Failed \n";
		return NULL;
	}
	curPos->right = temp;
	temp->value = A[2];

	//7, 12
	curPos = root->right;
	try {
		node *temp = new node;
	}
	catch (bad_alloc xa) {
		cout << "Allocation Failed \n";
		return NULL;
	}
	curPos->left = temp;
	temp->value = A[4];

	//12
	curPos = root->right;
	try {
		node *temp = new node;
	}
	catch (bad_alloc xa) {
		cout << "Allocation Failed \n";
		return NULL;
	}
	curPos->right = temp;
	temp->value = A[5];

	return root;
}

void printBinarySearchTree(int A[])
{
	node *temp = NULL, *curPos = NULL, *root = NULL;
	int i = 0;

	//while (1)
	{

	}
}

// Inorder - left subtree, node, right subtree. This could be used to print a binary search tree in sorted order. 
void print_inorder(node *p) {
	if (p != NULL) {
		print_inorder(p->left);  // print left subtree
		cout << p->value << endl; // print this node
		print_inorder(p->right); // print right subtree
	}
}

