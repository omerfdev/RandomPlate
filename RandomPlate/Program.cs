using System.Security.Cryptography;
using System.Threading.Channels;

namespace RandomPlate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Code Length"); 
            int x=int.Parse(Console.ReadLine());
            Console.WriteLine(RandomPlateMethod(x));
            Console.ReadLine();
        }

        private static string RandomPlateMethod(int x)
        {
            string code = "";
            for (int i = 0; i < x; i++)
            {
                code += CodeValue(i % 2 == 0);
            }
            return code;
        }
         
        private static char CodeValue(bool numeric)
        {
            Random rnd = new Random();  
            if (numeric)  return (char)rnd.Next(48, 58); 
            else return (char)rnd.Next(65,91);
        }
        
    }
}