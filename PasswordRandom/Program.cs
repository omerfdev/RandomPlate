using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordRandom
{
	internal class Program
	{
		static Random random = new Random();

		static void Main()
		{
			string password = GeneratePassword();
			string hashed = GenerateHash(password);
			Console.WriteLine("Created Password: " + password);
			Console.WriteLine("Hashed Output: " + hashed);
			Console.ReadLine();
		}

		private static string GenerateHash(string password)
		{
			byte[] inputBytes = Encoding.UTF8.GetBytes(password);
			byte[] hashedBytes;

			using (SHA256 sha256 = SHA256.Create())
			{
				hashedBytes = sha256.ComputeHash(inputBytes);
			}

			StringBuilder sb = new StringBuilder();
			foreach (byte b in hashedBytes)
			{
				sb.Append(b.ToString("x2"));
			}

			return sb.ToString();
		}

		static string GeneratePassword()
		{
			string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789*-_,!.";
			int length = random.Next(8, 17);
			char[] password = new char[length];
			bool hasUpper = false;
			bool hasLower = false;
			bool hasSpecial = false;

			for (int i = 0; i < length; i++)
			{
				password[i] = characters[random.Next(characters.Length)];
				if (char.IsUpper(password[i]))
					hasUpper = true;
				else if (char.IsLower(password[i]))
					hasLower = true;
				else if (IsSpecialCharacter(password[i]))
					hasSpecial = true;
			}

			if (!hasUpper || !hasLower || !hasSpecial)
				return GeneratePassword();

			return new string(password);
		}

		static bool IsSpecialCharacter(char c)
		{
			char[] specialChars = { '*', '-', '_', '!', '.' };
			return specialChars.Contains(c);
		}
	}
}
