using System;
using System.Linq;

// https://atcoder.jp/contests/abc124/tasks/abc124_c
namespace CColoringColorfully
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var colors = Console.ReadLine().ToCharArray().Select(x => x - '0').ToArray();

            // 奇数番目が黒、偶数番目が白というルールを満たす数Xを数える
            // 上記ルールを満たすものが半分より多いならば N - X が解答
            // もし半分以下ならば X が解答
            var n = colors.Length;
            var oddBlackRule = colors.Where((c, i) => i % 2 == c).Count();
            var answer = n / 2 < oddBlackRule ? n - oddBlackRule : oddBlackRule;

            // 解答の出力
            Console.WriteLine(answer);
        }
    }
}
