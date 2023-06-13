using System.Security.Cryptography;
using System.Threading.Channels;

namespace RandomPlate
{
    public class Program
    {
        public delegate char CodeValueDelegate(bool numeric);
        public static CodeValueDelegate codevalueDelegate = CodeValue;
        public delegate string RandomPlateMethodDelegate(int y);
        public static RandomPlateMethodDelegate randomplatemethodDelegate= RandomPlateMethod;
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Code Length"); 
            int x=int.Parse(Console.ReadLine());
            Console.WriteLine(randomplatemethodDelegate(x));
            Console.ReadLine();
        }

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
            if (numeric)  return (char)rnd.Next(48, 58); 
            else return (char)rnd.Next(65,91);
        }
        
    }
}