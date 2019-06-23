using System;
using System.Linq;

namespace ABC083B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の受け取り
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var a = inputs[1];
            var b = inputs[2];

            // 愚直に 1~N の値のうち、条件を満たすものを加算
            var sum = Enumerable.Range(1, n)
                .Where(i => CheckDigitSum(i, a, b))
                .Sum();

            // 解答の出力
            Console.WriteLine(sum);
        }

        static bool CheckDigitSum(int num, int lower, int upper)
        {
            var sum = SumDigits(num);
            return lower <= sum && sum <= upper;
        }

        static int SumDigits(int num)
        {
            var sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
    }
}
