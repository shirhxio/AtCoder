using System;
using System.Linq;

namespace ABC086C
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力Nの取得
            var n = int.Parse(Console.ReadLine());

            var result = true;
            int prevT = 0, prevX = 0, prevY = 0;

            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var t = inputs[0];
                var x = inputs[1];
                var y = inputs[2];

                var diffX = Math.Abs(x - prevX);
                var diffY = Math.Abs(y - prevY);
                var diffT = t - prevT;
                var reachable = (diffX + diffY <= diffT) && ((diffX + diffY) % 2 == diffT % 2);
                result &= reachable;

                prevT = t;
                prevX = x;
                prevY = y;
            }

            // 解答を出力
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
