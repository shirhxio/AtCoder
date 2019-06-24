using System;

namespace Template
{
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
