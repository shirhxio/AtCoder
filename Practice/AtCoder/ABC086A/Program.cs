using System;
using System.Linq;

namespace ABC086A
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の受け取り
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var a = inputs[0];
            var b = inputs[1];

            // 積の偶数・奇数を判定
            var result = (a * b) % 2 == 0 ? "Even" : "Odd";
            
            // 解答の出力
            Console.WriteLine(result);
        }
    }
}
