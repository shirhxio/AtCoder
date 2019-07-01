using System;
using System.Linq;

// https://atcoder.jp/contests/abc123/tasks/abc123_c
namespace CFiveTransportations
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Transportations = 5;
            // 入力の取得
            var n = long.Parse(Console.ReadLine());
            var capacities = new long[Transportations];
            for (var i = 0; i < Transportations; i++)
            {
                capacities[i] = long.Parse(Console.ReadLine());
            }

            // すべての交通手段の所要時間が1minなため、それぞれの収容人数によってボトルネックが決まる
            var bottleneck = capacities.Min();
            var bottleneckRequiredTime = (long)Math.Ceiling((double)n / bottleneck);
            var allRequiredTime = Transportations + bottleneckRequiredTime - 1;

            // 解答の出力
            Console.WriteLine(allRequiredTime);
        }
    }
}
