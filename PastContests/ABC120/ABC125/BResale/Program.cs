using System;
using System.Linq;

// https://atcoder.jp/contests/abc125/tasks/abc125_b
namespace BResale
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var costs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var profits = values.Zip(costs, (v, c) => v - c).ToArray();
            var maxProfit = profits.Where(x => x > 0).Sum();

            // 解答の取得
            Console.WriteLine(maxProfit);
        }
    }
}
