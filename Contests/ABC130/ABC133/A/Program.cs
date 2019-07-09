using System;
using System.Linq;

// https://atcoder.jp/contests/abc133/tasks/abc133_a
namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputs[0], a = inputs[1], b = inputs[2];

            var trainCost = n * a;
            var answer = trainCost < b ? trainCost : b;

            // 解答の出力
            Console.WriteLine(answer);
        }
    }
}
