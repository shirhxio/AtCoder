using System;
using System.IO;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 最大の数字 A と 最小の数字 B を取得
            // その他の数字について、正の値は B - num 、負の値は A - num とする
            // 最後に A' - B' とすれば最大値となりそう?
            var maxNum = numbers.Max();
            var minNum = numbers.Min();

            var maxNumIndex = Array.IndexOf(numbers, maxNum);
            var minNumIndex = Array.LastIndexOf(numbers, minNum);    // maxNum == minNum の可能性があるため後ろから

            var others = numbers.Where((num, i) => i != maxNumIndex && i != minNumIndex).ToArray();

            var maxResult = maxNum - minNum + others.Sum(Math.Abs);

            // 解答の出力
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);

            Console.WriteLine(maxResult);

            var tmpMin = minNum;
            foreach (var num in others.Where(num => num >= 0))
            {
                Console.WriteLine("{0} {1}", tmpMin, num);
                tmpMin -= num;
            }

            var tmpMax = maxNum;
            foreach (var num in others.Where(num => num < 0))
            {
                Console.WriteLine("{0} {1}", tmpMax, num);
                tmpMax -= num;
            }

            Console.WriteLine("{0} {1}", tmpMax, tmpMin);

            Console.Out.Flush();
        }
    }
}
