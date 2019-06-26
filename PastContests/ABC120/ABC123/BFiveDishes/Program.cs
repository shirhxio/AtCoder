using System;
using System.Linq;

// https://atcoder.jp/contests/abc123/tasks/abc123_b
namespace BFiveDishes
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            const int DishCount = 5;
            var timeWithPaddings = new Tuple<int, int>[DishCount];
            for (var i = 0; i < DishCount; i++)
            {
                var cookingTime = int.Parse(Console.ReadLine());
                var padding = cookingTime % 10 == 0 ? 0 : 10 - cookingTime % 10;
                timeWithPaddings[i] = Tuple.Create(cookingTime, padding);
            }

            // 一番 PaddingTime の長い料理を最後に注文することで最短時間となる
            var maxPadding = timeWithPaddings.Max(t => t.Item2);
            var sum = timeWithPaddings.Sum(t => t.Item1 + t.Item2) - maxPadding;

            // 解答の出力
            Console.WriteLine(sum);
        }
    }
}
