using System;
using System.IO;
using System.Linq;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 解答の出力
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            // 出力の操作
            Console.Out.Flush();
        }
    }
}
