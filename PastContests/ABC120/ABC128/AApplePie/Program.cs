using System;
using System.Linq;

namespace AApplePie
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = inputs[0];
            var p = inputs[1];

            var pies = (3 * a + p) / 2;
            
            // 解答の出力
            Console.WriteLine(pies);
        }
    }
}
