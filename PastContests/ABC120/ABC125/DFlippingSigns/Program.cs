using System;
using System.Linq;

// https://atcoder.jp/contests/abc125/tasks/abc125_d
namespace DFlippingSigns
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var inputNums = Console.ReadLine().Split().Select(long.Parse).ToArray();
            
            // 任意回の操作を行えば、負の数が偶数個ならば全て正の数に奇数個ならば1つ以外正の数にできる
            // ただし、1つでも0が含まれれば、全ての数字を正の数にすることができる
            var negativeCount = inputNums.Count(num => num < 0);
            var absNums = inputNums.Select(Math.Abs).ToArray();
            var minAbsNum = absNums.Min();

            var sum = absNums.Sum();
            if (negativeCount % 2 != 0 && minAbsNum != 0)
            {
                sum -= minAbsNum * 2;
            }

            // 解答の出力
            Console.WriteLine(sum);
        }
    }
}
