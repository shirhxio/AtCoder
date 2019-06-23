using System;
using System.Linq;

// https://atcoder.jp/contests/abc130/tasks/abc130_a
namespace ARounding
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var x = inputs[0];
            var a = inputs[1];

            var answer = x < a ? 0 : 10;

            // 解答の出力
            Console.WriteLine(answer);
        }
    }
}
