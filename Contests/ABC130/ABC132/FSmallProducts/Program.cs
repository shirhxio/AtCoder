using System;
using System.Collections.Generic;
using System.Linq;

// https://atcoder.jp/contests/abc132/tasks/abc132_f
namespace FSmallProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputs[0], k = inputs[1];

            // ある数aに対して a * b <= n となる最大値bの一覧を作成
            // for で n 回走査すると TLE のため,
            // 双曲線の特徴を活かして x == n/x となる √n までの x , n/x で一覧を作る
            List<int> divSummary = new List<int>();
            for (var i = 1; i * i <= n; i++)
            {
                divSummary.Add(i);
                if (i * i != n) divSummary.Add(n / i);
            }
            divSummary.Sort();

            var divCount = divSummary.Count;
            ModNum[,] dp = new ModNum[k, divCount];

            for (var i = 0; i < divCount; i++)
            {
                dp[0, i] = divSummary[i];
            }

            for (var i = 1; i < k; i++)
            {
                dp[i, 0] = dp[i - 1, divCount - 1];
                for (var j = 1; j < divCount; j++)
                {
                    var overlap = divSummary[j] - divSummary[j - 1];
                    dp[i, j] = dp[i, j - 1] + overlap * dp[i - 1, divCount - 1 - j];
                }
            }

            // 解答の出力
            Console.WriteLine(dp[k - 1, divCount - 1].X);
        }
    }

    public struct ModNum : IEquatable<ModNum>
    {
        const int Mod = 1000000007;
        public long X { get; }

        public ModNum(long x) { X = x % Mod; }
        public static implicit operator ModNum(long x) => new ModNum(x);

        public bool Equals(ModNum other) => X == other.X;
        public override bool Equals(object obj) => obj is ModNum && Equals((ModNum)obj);
        public override int GetHashCode() => X.GetHashCode();
        public static bool operator ==(ModNum a, ModNum b) => a.X == b.X;
        public static bool operator !=(ModNum a, ModNum b) => a.X != b.X;

        public static ModNum operator +(ModNum a, ModNum b) => a.X + b.X;
        public static ModNum operator -(ModNum a, ModNum b) => Mod + a.X - b.X;
        public static ModNum operator *(ModNum a, ModNum b) => a.X * b.X;
        public static ModNum operator /(ModNum a, ModNum b) => a.X * Pow(b, Mod - 2);

        public static ModNum Pow(ModNum baseNum, int exponent)
        {
            switch (exponent)
            {
                case 0:
                    return 1;
                case 1:
                    return baseNum;
                default:
                    var pow = Pow(baseNum, exponent / 2);
                    return (exponent % 2) == 0 ? pow * pow : pow * pow * baseNum;
            }
        }
    }
}
