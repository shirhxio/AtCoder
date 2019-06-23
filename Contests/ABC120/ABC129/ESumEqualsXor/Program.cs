using System;

namespace ESumEqualsXor
{
    class Program
    {
        const int LAW = 1000000007;

        static void Main(string[] args)
        {
            // 入力の取得
            var l = Console.ReadLine().ToCharArray();
            // 101 (111 -> 3^3) -> 15
            // Exclusions: 111/000 110/001 101/010 100/011 110/000 100/010 -> 12
            // 1*b 0 1*a -> 3^(a + b + 1) - 2^b * 2 * 3^a  -> A
            // ↓↓↓
            // 1*c 0 1*b 0 1*a -> 3^(a + b + c + 2) - 2^c * 2 * A
            var powerMap3 = CalcPowerMap(3, 5);
            var powerMap2 = CalcPowerMap(2, 5);

            // 解答の出力
            Console.WriteLine();
        }

        /// <summary>
        /// 底 baseNum の冪乗 % 1000000007 の一覧を返す
        /// </summary>
        /// <param name="baseNum">冪乗の底</param>
        /// <param name="maxExponent">冪乗の冪指数の最大値</param>
        /// <returns></returns>
        static int[] CalcPowerMap(int baseNum, int maxExponent)
        {
            var powerMap = new int[maxExponent + 1];
            powerMap[0] = 1;
            for (var i = 1; i <= maxExponent; i++)
            {
                powerMap[i] = (int)(Math.BigMul(powerMap[i - 1], baseNum) % LAW);
            }

            return powerMap;
        }
    }
}
