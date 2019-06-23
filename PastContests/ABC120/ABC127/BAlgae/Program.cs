using System;
using System.Linq;

namespace BAlgae
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var r = inputs[0];
            var d = inputs[1];
            var start = inputs[2];

            // 解答の計算・出力
            var weight = start;
            for (var i = 1; i <= 10; i++)
            {
                weight = r * weight - d;
                Console.WriteLine(weight);
            }
        }
    }
}
