using System;

namespace BYymmOrMmyy
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().ToCharArray();

            // ２桁ずつの値を int に変換
            var first = int.Parse(String.Concat(inputs[0], inputs[1]));
            var second = int.Parse(String.Concat(inputs[2], inputs[3]));

            // それぞれが月の可能性があるか否か
            var maybeMmFirst = 1 <= first && first <= 12;
            var maybeMmSecond = 1 <= second && second <= 12;

            // 解答の出力
            if (maybeMmFirst && maybeMmSecond) Console.WriteLine("AMBIGUOUS");
            else if (maybeMmFirst && !maybeMmSecond) Console.WriteLine("MMYY");
            else if (!maybeMmFirst && maybeMmSecond) Console.WriteLine("YYMM");
            else Console.WriteLine("NA");
        }
    }
}
