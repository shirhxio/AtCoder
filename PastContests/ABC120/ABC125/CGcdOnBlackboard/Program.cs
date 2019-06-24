using System;
using System.Linq;

// https://atcoder.jp/contests/abc125/tasks/abc125_c
namespace CGcdOnBlackboard
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 1つの数字を書き換えて、最大公約数が変わり得るのはUNIQUEな数字のみ
            // UNIQUEな数字に対して、その他の数字の最大公約数を計算して、そのうち最大のものが解答
            var numbersWithCount = inputNums.GroupBy(x => x).Select(g => Tuple.Create(g.Key, g.Count())).ToArray();
            var numbers = numbersWithCount.Select(x => x.Item1).ToArray();
            var uniqueNumbers = numbersWithCount.Where(x => x.Item2 == 1).Select(x => x.Item1).ToArray();

            var maxGcd = 0;
            if (uniqueNumbers.Any())
            {
                foreach (var uniqueNum in uniqueNumbers)
                {
                    var otherGcd = numbers.Where(num => num != uniqueNum)
                        .Aggregate((gcd, num) => Gcd(num, gcd));
                    if (maxGcd < otherGcd) maxGcd = otherGcd;
                }
            }
            else
            {
                maxGcd = numbers.Aggregate((gcd, num) => Gcd(num, gcd));
            }

            // 解答の出力
            Console.WriteLine(maxGcd);
        }

        static int Gcd(int a, int b)
        {
            if (a < b) return Gcd(b, a);
            if (0 < b) return Gcd(b, a % b);
            return a;
        }
    }
}
