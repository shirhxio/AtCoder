using System;
using System.Linq;

namespace BGuidebook
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力Nの取得
            var n = int.Parse(Console.ReadLine());

            // 住所と点数を取得
            var addresses = new string[n];
            var scores = new int[n];
            for (var i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine().Split().ToArray();
                addresses[i] = inputs[0];
                scores[i] = int.Parse(inputs[1]);
            }

            // 住所の辞書順＞点数順で並び替え
            var orders = Enumerable.Range(1, n)
                .OrderBy(i => addresses[i - 1])
                .ThenByDescending(i => scores[i - 1])
                .ToArray();

            // 解答の出力
            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(orders[i]);
            }
        }
    }
}
