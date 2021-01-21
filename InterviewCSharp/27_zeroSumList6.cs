using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    class TestCases27
    {
        List<int> myList = new List<int>();

        public void zeroSumList()
        {

        }

        public void zeroSumList(List<int> myList)
        {

        }

        public void findZeroSumList(List<int> myList)
        {

        }

    }

    class zeroSumList
    {
        public void driverCall()
        {

			Console.WriteLine("27_zeroSumList6.cs");
			
            List<int> zSumList1 = new List<int> { 4, 5, -3, 2, 1, 9, 11 };      //--> {-3,2,1} 
            int n = zSumList1.Count();

            List<int> zSumList2 = new List<int> { 4, -1, -1, -1, -1 };          //--> {4,-1,-1,-1,-1}
            n = zSumList2.Count();

            TestCases27 zList1 = new TestCases27();
            zList1.findZeroSumList(zSumList1);

            TestCases27 zList2 = new TestCases27();
            zList2.findZeroSumList(zSumList2);

            Console.ReadLine();
        }
    }

}





/* 
{

	// I/P - {4,5,-3,2,1,9,11}, {4,-1,-1,-1,-1}
// O/P - {-3,2,1}, {4,-1,-1,-1,-1}

	using System;
	using System.Collections.Generic;

	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Hello World");
		}

		public static int[] FindZeroSumSubSet(int[] input)
		{
			int n = input.Length;
			int[] zeroSumSubSet = new int[n];
			int res = int.MinValue;
			int min = 0;

			zeroSumSubSet[0] = input[0];
			for (int i = 1; i < n; i++)
			{
				zeroSumSubSet[i] = zeroSumSubSet[i - 1] + input[i];
			}
			for (int i = 0; i < n; i++)
			{
				res = Math.Max(res, zeroSumSubSet[i] - min);
				min = Math.Min(min, zeroSumSubSet[i]);
			}

			return zeroSumSubSet;
		}
	}
}

*/
