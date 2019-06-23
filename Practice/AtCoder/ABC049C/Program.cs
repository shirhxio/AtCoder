using System;
using System.Text;

namespace ABC049C
{
    class Program
    {
        const string DREAM = "dream";
        const string DREAMER = "dreamer";
        const string ERASE = "erase";
        const string ERASER = "eraser";

        static void Main(string[] args)
        {
            // 入力の受け取り
            var s = Console.ReadLine().ToCharArray();

            var strBuilder = new StringBuilder();
            var index = 0;
            var strLength = s.Length;

            // 頭文字と単語以降の文字を調べて、簡易的に接続する単語を決定していく
            while (index < strLength)
            {
                if (s[index] == 'd') // "dream" / "dreamer"
                {
                    if (CheckDreamer(s, index))
                    {
                        strBuilder.Append(DREAMER);
                        index += DREAMER.Length;
                    }
                    else
                    {
                        strBuilder.Append(DREAM);
                        index += DREAM.Length;
                    }
                }
                else if (s[index] == 'e') // "erase" / "eraser"
                {
                    if (CheckEraser(s, index))
                    {
                        strBuilder.Append(ERASER);
                        index += ERASER.Length;
                    }
                    else
                    {
                        strBuilder.Append(ERASE);
                        index += ERASE.Length;
                    }
                }
                else
                {
                    OutputResult(false);
                    return;
                }
            }

            OutputResult(String.Concat(s) == strBuilder.ToString());
        }

        static void OutputResult(bool result)
        {
            Console.WriteLine(result ? "YES" : "NO");
        }

        static bool CheckDreamer(char[] str, int index)
        {
            if (str.Length < index + DREAMER.Length) return false;
            if (str.Length == index + DREAMER.Length) return true;

            return str[index + DREAM.Length] == 'e' && str[index + DREAMER.Length] != 'a';
        }

        static bool CheckEraser(char[] str, int index)
        {
            if (str.Length < index + ERASER.Length) return false;
            if (str.Length == index + ERASER.Length) return true;

            return str[index + ERASE.Length] == 'r' && str[index + ERASER.Length] != 'a';
        }
    }
}
