using System;
using System.Linq;

// https://atcoder.jp/contests/abc130/tasks/abc130_c
namespace CRectangleCutting
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var width = inputs[0];
            var height = inputs[1];
            var x = inputs[2];
            var y = inputs[3];

            // 長方形内であれば、二等分する直線を引くことができるはず
            var rectangleSize = width * height;
            var maxSplitSize = (double)rectangleSize / 2;
            
            // 複数の二等分線を引けるのは長方形の中心点のみ
            var isCenter = false;
            if (width % 2 == 0 && height % 2 == 0)
            {
                isCenter = width / 2 == x && height / 2 == y;
            }

            // 解答の出力
            Console.WriteLine("{0} {1}", maxSplitSize, isCenter ? 1 : 0);
        }
    }
}
