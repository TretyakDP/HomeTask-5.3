using System;

class Program
{
    static void Main()
    {
        Console.Write("Выберите алфавит (русский - 1, английский - 2): ");
        int alphabetChoice = int.Parse(Console.ReadLine());

        if (alphabetChoice != 1 && alphabetChoice != 2)
        {
            Console.WriteLine("Некорректный выбор алфавита.");
            return;
        }

        Console.Write("Введите шаг шифрования: ");
        int shift = int.Parse(Console.ReadLine());

        Console.Write("Введите строку для шифрования/дешифрования: ");
        string input = Console.ReadLine();

        string result = CaesarCipher(input, alphabetChoice, shift);
        Console.WriteLine("Результат: " + result);
    }

    static string CaesarCipher(string input, int alphabetChoice, int shift)
    {
        string alphabet;
        if (alphabetChoice == 1)
        {
            alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        }
        else
        {
            alphabet = "abcdefghijklmnopqrstuvwxyz";
        }

        string result = "";

        foreach (char character in input)
        {
            if (char.IsLetter(character))
            {
                char lowercaseChar = char.ToLower(character);
                int position = alphabet.IndexOf(lowercaseChar);

                if (position >= 0)
                {
                    int shiftedPosition = (position + shift) % alphabet.Length;
                    char shiftedChar = char.IsUpper(character) ? char.ToUpper(alphabet[shiftedPosition]) : alphabet[shiftedPosition];
                    result += shiftedChar;
                }
                else
                {
                    result += character;
                }
            }
            else
            {
                result += character;
            }
        }

        return result;
    }
}

