using System;
using System.Linq;

namespace CGcdOnBlackboard
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // １つの数字以外の最大公約数を全て計算する
            var gcdList = new int[n];
            for (var i = 0; i < n; i++)
            {
                gcdList[i] = numbers
                    .Where((_, idx) => idx != i)
                    .Distinct()
                    .Aggregate((gcd, num) => Gcd(num, gcd));
            }

            var answer = gcdList.Max();

            // 解答の出力
            Console.WriteLine(answer);
        }

        static int Gcd(int a, int b)
        {
            if (a < b) return Gcd(b, a);
            if (0 < b) return Gcd(b, a % b);
            return a;
        }
    }
}
