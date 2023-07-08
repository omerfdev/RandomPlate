using System;

namespace PasswordRandom
{
	internal class Program
	{
		static Random random = new Random();

		static void Main()
		{
			string password = GeneratePassword();
			Console.WriteLine("Oluşturulan şifre: " + password);
			Console.ReadLine();
		}
		static string GeneratePassword()
		{
			string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789*-_,!.";
			int length = random.Next(8, 17);

			char[] password = new char[length];

			// En az bir büyük harf, bir küçük harf ve özel karakter eklemek için flag'ler kullanılıyor
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
