using System;
using System.IO;
using System.Linq;

// https://atcoder.jp/contests/abc132/tasks/abc132_d
namespace DBlueAndRedBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var k = inputs[1];

            var blueBalls = k;
            var redBalls = n - k;

            var answers = new ModNum[k];
            for (var i = 1; i <= k; i++)
            {
                if (i - 1 <= redBalls)
                {
                    var bluePatterns = MultiChoose(i, blueBalls - i);
                    var redPatterns = MultiChoose(i + 1, redBalls - i + 1);
                    answers[i - 1] = bluePatterns * redPatterns;
                }
                else // 赤玉が i - 1 の場合、青玉を i グループに分けるのは不可能なので 0
                {
                    answers[i - 1] = 0;
                }
            }

            // 解答の出力
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer.X);
            }
            Console.Out.Flush();
        }

        static ModNum MultiChoose(int i, int balls)
        {
            var n = i + balls - 1;
            ModNum numer = 1, denom = 1;
            for (var j = 1; j <= balls; j++)
            {
                denom *= j;
                numer *= n - j + 1;
            }
            return numer / denom;
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
