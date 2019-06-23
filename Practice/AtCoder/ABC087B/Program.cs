using System;

namespace ABC087B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の受け取り
            var a = int.Parse(Console.ReadLine());    // ¥500 枚数
            var b = int.Parse(Console.ReadLine());    // ¥100 枚数
            var c = int.Parse(Console.ReadLine());    // ¥50 枚数
            var x = int.Parse(Console.ReadLine());    // 目標金額

            // 組み合わせの走査
            var count = 0;
            var minA = CalcMinCoins(500, x, 100 * b + 50 * c);
            var maxA = Math.Min(x / 500, a);

            for (var i = minA; i <= maxA; i++)
            {
                var targetBC = x - 500 * i;
                var minB = CalcMinCoins(100, targetBC, 50 * c);
                var maxB = Math.Min(targetBC / 100, b);

                for (var j = minB; j <= maxB; j++)
                {
                    var targetC = x - 500 * i - 100 * j;
                    if (targetC / 50 <= c) count++;
                }
            }

            // 解答の出力
            Console.WriteLine(count);
        }

        static int CalcMinCoins(int coin, int targetSum, int otherSum)
        {
            return targetSum > otherSum ? (int)Math.Ceiling((double)(targetSum - otherSum) / coin) : 0;
        }
    }
}
