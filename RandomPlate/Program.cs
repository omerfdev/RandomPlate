using System.Security.Cryptography;
using System.Threading.Channels;

namespace RandomPlate
{
	public class Program
	{
		public delegate char CodeValueDelegate(bool numeric);
		public static CodeValueDelegate codevalueDelegate = CodeValue;
		public delegate string RandomPlateMethodDelegate(int y);
		public static RandomPlateMethodDelegate randomplatemethodDelegate = RandomPlateMethod;
		public static void Main(string[] args)
		{
			Console.WriteLine("Enter Number of Code Length");
			int x = int.Parse(Console.ReadLine());
			Console.WriteLine(randomplatemethodDelegate(x));
			Console.ReadLine();
		}
		/// <summary>
		/// Method Gives Random Plate Code
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public static string RandomPlateMethod(int x)
		{
			string code = "";
			for (int i = 0; i < x; i++)
			{
				code += CodeValue(i % 2 == 0);
			}
			return code;
		}

		public static char CodeValue(bool numeric)
		{
			Random rnd = new Random();
			if (numeric)
			{
				int number = rnd.Next(2);
				if (number == 0) return (char)rnd.Next(97, 122);
				else return  (char)rnd.Next(65, 91);
			}

			else
			{
				int number = rnd.Next(5);
				if (number == 0) { return (char)rnd.Next(95, 96); }
				else if (number == 1) { return (char)rnd.Next(45, 47); }
				else if (number == 2) { return (char)rnd.Next(33, 34); }
				else if (number == 3) { return (char)rnd.Next(48, 58); }
				else { return (char)rnd.Next(42, 43); }
			}
		}


	}
}
