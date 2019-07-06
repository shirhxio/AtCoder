using System;
using System.Linq;

// https://atcoder.jp/contests/abc132/tasks/abc132_b
namespace BOrdinaryNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var pArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var answer = 0;
            for (var i = 1; i < n - 1; i++)
            {
                if ((pArray[i - 1] < pArray[i] && pArray[i] < pArray[i + 1]) ||
                    (pArray[i - 1] > pArray[i] && pArray[i] > pArray[i + 1]))
                {
                    answer++;
                }
            }

            // 解答の出力
            Console.WriteLine(answer);
        }
    }
}
