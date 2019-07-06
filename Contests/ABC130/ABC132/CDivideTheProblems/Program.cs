using System;
using System.Linq;

// https://atcoder.jp/contests/abc132/tasks/abc132_c
namespace CDivideTheProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var n = int.Parse(Console.ReadLine());
            var difficulties = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 昇順に並び替えた difficulties の n/2 - 1 までが ABC 問題、 n/2 から ARC 問題
            // n/2 - 1 と n/2 が同じ難易度の場合、ちょうど半分には分けられない
            Array.Sort(difficulties);
            var left = difficulties[n / 2 - 1];
            var right = difficulties[n / 2];
            var answer = right - left;

            // 解答の出力
            Console.WriteLine(answer);
        }
    }
}
