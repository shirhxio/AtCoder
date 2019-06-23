using System;
using System.Linq;

// https://atcoder.jp/contests/abc130/tasks/abc130_d
namespace DEnoughArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().ToArray();
            var n = int.Parse(inputs[0]);
            var k = long.Parse(inputs[1]);

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            long partialSum = 0;
            var tailIndex = -1;
            for (var i = 0; i < n; i++)
            {
                partialSum += numbers[i];

                if (partialSum >= k)
                {
                    tailIndex = i;
                    break;
                }
            }

            // 全ての数字を足しても K に届かない場合は 0 を出力して終了
            if (tailIndex < 0)
            {
                Console.WriteLine(0);
                return;
            }

            long subsetCount = n - tailIndex;
            for (var i = 1; i < n; i++)
            {
                partialSum -= numbers[i - 1];
                var nextTail = -1;
                if (partialSum >= k)
                {
                    nextTail = tailIndex;
                }
                else
                {
                    for (var j = tailIndex + 1; j < n; j++)
                    {
                        partialSum += numbers[j];

                        if (partialSum >= k)
                        {
                            nextTail = j;
                            break;
                        }
                    }
                }

                // i 以降の数字を足しても K に届かない場合、あとの部分列でも K には届かない
                if (nextTail < 0) break;

                tailIndex = nextTail;
                subsetCount += n - tailIndex;
            }

            // 解答の出力
            Console.WriteLine(subsetCount);
        }
    }
}
