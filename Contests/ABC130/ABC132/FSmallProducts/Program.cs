using System;
using System.Collections;
using System.Linq;

namespace FSmallProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputs[0], k = inputs[1];

            var dp0 = new ModNum[n + 1];
            var dp1 = new ModNum[n + 1];

            dp0[0] = 0;
            for (var i = 1; i < n + 1; i++)
            {
                dp0[i] = dp0[i - 1] + n / i;
            }

            for (var i = 3; i <= k; i++)
            {
                var prevDp = i % 2 == 0 ? dp1 : dp0;
                var curDp = i % 2 == 0 ? dp0 : dp1;
                curDp[0] = 0;
                for (var j = 1; j < n + 1; j++)
                {
                    curDp[j] = curDp[j - 1] + prevDp[n / j];
                }
            }

            // 解答の出力
            Console.WriteLine(dp1[n].X);
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
