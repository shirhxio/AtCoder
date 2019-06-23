using System;
using System.Linq;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var k = inputs[1];

            // ひとつずつ配って余りを１人に配れば最大（１人だけは例外）
            var diff = k == 1 ? 0 : n - k;

            // 解答の出力
            Console.WriteLine(diff);
        }
    }
}
