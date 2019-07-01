using System;
using System.Linq;

// https://atcoder.jp/contests/abc132/tasks/abc132_a
namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var s = Console.ReadLine().ToCharArray();

            var grouped = s.GroupBy(x => x).Select(x => x.Count()).ToArray();
            var answer = grouped.Length == 2 && grouped.All(x => x == 2);

            // 解答の出力
            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
