using System;
using System.Linq;

// https://atcoder.jp/contests/abc124/tasks/abc124_b
namespace BGreateOceanView
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var heights = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxHeight = 0, oceanViews = 0;
            foreach (var height in heights)
            {
                if (maxHeight <= height)
                {
                    maxHeight = height;
                    oceanViews++;
                }
            }

            // 解答の出力
            Console.WriteLine(oceanViews);
        }
    }
}
