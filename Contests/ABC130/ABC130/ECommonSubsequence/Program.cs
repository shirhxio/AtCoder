using System;
using System.Linq;

// https://atcoder.jp/contests/abc130/tasks/abc130_e
namespace ECommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var m = inputs[1];

            var sNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var tNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var dp = new ModNum[n + 1, m + 1];
            for (var i = 0; i < n + 1; i++) dp[i, 0] = 1;
            for (var i = 0; i < m + 1; i++) dp[0, i] = 1;

            for (var i = 1; i < n + 1; i++)
            {
                for (var j = 1; j < m + 1; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    if (sNumbers[i - 1] != tNumbers[j - 1]) dp[i, j] -= dp[i - 1, j - 1];
                }
            }

            // 解答の出力
            Console.WriteLine(dp[n, m].X);
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
    }
}
