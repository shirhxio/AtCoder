using System;
using System.Linq;

namespace Dequeue
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];    // D に詰められている宝石の数
            var k = inputs[1];    // 操作回数
            var jewels = Console.ReadLine().Split().Select(int.Parse).ToArray();    // 宝石の価値
            
            // 左から left 個、右から right 個を獲得して、同じ宝石を stay 回出し入れし、ret 個を戻す
            // (合計価値が下がってしまう場合、'操作しない' が可能）
            // left + right + 2 * stay + ret <= k
            var maxPop = Math.Min(n, k);
            var maxPrice = int.MinValue;
            for (var left = 0; left <= maxPop; left++)
            {
                for (var right = 0; right <= maxPop - left; right++)
                {
                    // まずは左から left 個、右から right 個取り出してしまう
                    var poppedJewels = new int[left + right];
                    Array.Copy(jewels, 0, poppedJewels, 0, left);
                    Array.Copy(jewels, n - right, poppedJewels, left, right);
                    Array.Sort(poppedJewels);

                    var negatives = poppedJewels.Count(price => price < 0);
                    for (var stay = 0; 2 * stay + left + right <= k; stay++)
                    {
                        // 負の値だけ可能な限り戻す
                        var ret = k - (2 * stay + left + right);
                        if (negatives < ret) ret = negatives;
                        if (ret > left + right) continue;

                        var sum = poppedJewels.Skip(ret).Sum();
                        if (maxPrice < sum) maxPrice = sum;
                    }
                }
            }

            // 解答の出力
            Console.WriteLine(maxPrice);
        }
    }
}
