using System;
using System.Linq;

namespace ABC081A
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の受け取り
            var inputs = Console.ReadLine().ToCharArray();

            // ビー玉のマスの数をカウント
            var count = inputs.Count(x => x == '1');

            // 解答を出力
            Console.WriteLine(count);
        }
    }
}
