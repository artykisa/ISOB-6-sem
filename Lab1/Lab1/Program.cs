using System;
using System.IO;
using System.Text;

namespace Lab1
{
    internal static class Program
    {
        private const string AlphabetDigitRu = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string AlphabetRu = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        private const string AlphabetEng = "abcdefghijklmnopqrstuvwxyz";
        private const string AlphabetDigitEng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private const int Depth = 3;
        private const string Key = "KEY";

        private static StringBuilder ToCaesar(StringBuilder text, int depth)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    if (Char.IsUpper(text[i]))
                    {
                        text[i] = AlphabetDigitRu[(AlphabetDigitRu.IndexOf(text[i]) + depth) % AlphabetDigitRu.Length];
                    }
                    else
                    {
                        text[i] = AlphabetRu[(AlphabetRu.IndexOf(text[i]) + depth) % AlphabetRu.Length];
                    }
                }
            }

            return text;
        }


        private static StringBuilder FromCaesar(StringBuilder text, int depth)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    if (Char.IsUpper(text[i]))
                    {
                        text[i] = AlphabetDigitRu[(AlphabetDigitRu.IndexOf(text[i]) - depth + AlphabetDigitRu.Length) % AlphabetDigitRu.Length];
                    }
                    else
                    {
                        text[i] = AlphabetRu[(AlphabetRu.IndexOf(text[i]) - depth + AlphabetRu.Length) % AlphabetRu.Length];
                    }
                }
            }
            return text;
        }

        private static void FileToCaesar(int depth)
        {
            var text = File.ReadAllText(Directory.GetCurrentDirectory() + "/Text1.txt");
            var textForFunction = new StringBuilder();
            textForFunction.Append(text);
            var result = ToCaesar(textForFunction, depth);
            Console.WriteLine(result);
            File.WriteAllText(Directory.GetCurrentDirectory() + "/Text2.txt",result.ToString());
        }

        private static void FileFromCaesar(int depth)
        {
            var text = File.ReadAllText(Directory.GetCurrentDirectory() + "/Text2.txt");
            var textForFunction = new StringBuilder();
            textForFunction.Append(text);
            Console.WriteLine(FromCaesar(textForFunction, depth));
        }

        private static StringBuilder ToVigenere(StringBuilder text, string key)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    if (Char.IsUpper(text[i]))
                    {
                        text[i] = AlphabetDigitEng[(AlphabetDigitEng.IndexOf(text[i]) + AlphabetDigitEng.IndexOf(key[i])) % AlphabetDigitEng.Length];
                    }
                    else
                    {
                        text[i] = AlphabetEng[(AlphabetEng.IndexOf(text[i]) + AlphabetEng.IndexOf(key[i])) % AlphabetEng.Length];
                    }
                }
            }
            return text;
        }

        private static StringBuilder FromVigenere(StringBuilder text, string key)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    if (Char.IsUpper(text[i]))
                    {
                        text[i] = AlphabetDigitEng[(AlphabetDigitEng.IndexOf(text[i]) - AlphabetDigitEng.IndexOf(key[i]) + AlphabetDigitEng.Length) % AlphabetDigitEng.Length];
                    }
                    else
                    {
                        text[i] = AlphabetEng[(AlphabetEng.IndexOf(text[i]) - AlphabetEng.IndexOf(key[i]) + AlphabetEng.Length) % AlphabetEng.Length];
                    }
                }
            }
            return text;
        }

        private static void FileToVingenere(string key)
        {
            var text = File.ReadAllText(Directory.GetCurrentDirectory() + "/Text3.txt");
            var textForFunction = new StringBuilder();
            textForFunction.Append(text);
            for (var i = 0; text.Length > key.Length; i++)
            {
                key += key[i % key.Length];
            }
            var result = ToVigenere(textForFunction, key);
            Console.WriteLine(result);
            File.WriteAllText(Directory.GetCurrentDirectory() + "/Text4.txt", result.ToString());
        }

        private static void FileFromVingenere(string key)
        {
            var text = File.ReadAllText(Directory.GetCurrentDirectory() + "/Text4.txt");
            var textForFunction = new StringBuilder();
            textForFunction.Append(text);
            for (var i = 0; text.Length > key.Length; i++)
            {
                key += key[i % key.Length];
            }
            Console.WriteLine(FromVigenere(textForFunction, key));
        }
        
        static void Main()
        {
            FileToCaesar(Depth);
            FileFromCaesar(Depth);
            FileToVingenere(Key);
            FileFromVingenere(Key);
        }
    }
}