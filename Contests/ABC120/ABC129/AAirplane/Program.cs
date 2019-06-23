using System;
using System.Linq;

namespace AAirplane
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var p = inputs[0];
            var q = inputs[1];
            var r = inputs[2];

            var sum = inputs.OrderBy(x => x).Take(2).Sum();

            // 解答の出力
            Console.WriteLine(sum);
        }
    }
}
