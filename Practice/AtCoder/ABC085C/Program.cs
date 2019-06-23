using System;
using System.Linq;

namespace ABC085C
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の受け取り
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var y = inputs[1];

            // Y が ¥1,000 * N枚より小さい or ¥10,000 * N枚より大きい場合は明らかにありえない
            if (y < 1000 * n || 10000 * n < y)
            {
                Console.WriteLine("-1 -1 -1");
                return;
            }

            // a + b + c = n
            // 10000 * a + 5000 * b + 1000 * c = y
            // -> 9000 * a + 4000 * b = y - 1000 * n
            var countA = (y / 1000 - n) % 2 == 0 ? 0 : 1;
            var maxA = (y - 1000 * n) / 9000;
            while (countA <= maxA)
            {
                var mod = (y - 1000 * n - 9000 * countA) % 4000;
                var countB = (y - 1000 * n - 9000 * countA) / 4000;
                var countC = n - countA - countB;

                // 該当の組み合わせが見つかったら、解答を出力して終了
                if (mod == 0 && countB >= 0 && countC >= 0)
                {
                    Console.WriteLine(String.Format("{0} {1} {2}", countA, countB, countC));
                    return;
                }
                countA += 2;
            }

            // 該当の組み合わせが見つからなければ、"-1 -1 -1" を出力して終了
            Console.WriteLine("-1 -1 -1");
        }
    }
}
