using System;
using System.Linq;

namespace ABC085B
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の受け取り
            var n = int.Parse(Console.ReadLine());
            var diameters = new int[n];
            for (int i = 0; i < n; i++)
            {
                diameters[i] = int.Parse(Console.ReadLine());
            }

            // 重ねられない同じ直径の餅を省いて数える
            var count = diameters.Distinct().Count();

            // 解答の出力
            Console.WriteLine(count);
        }
    }
}
