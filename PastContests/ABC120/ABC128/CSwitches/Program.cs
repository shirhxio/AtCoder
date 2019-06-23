using System;
using System.Linq;

namespace CSwitches
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力 N/M の取得
            var inputNM = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputNM[0];
            var m = inputNM[1];

            // 各電球の繋がってるスイッチ取得
            var lamps = new int[m][];
            for (var i = 0; i < m; i++)
            {
                var switches = Console.ReadLine().Split().Skip(1).Select(int.Parse).ToArray();
                lamps[i] = switches;
            }

            // 各電球の点灯条件を取得
            var conds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // 全部OFF ~ 全部ON の全てのパターンをビット演算でチェックして数える
            var count = 0;
            var patterns = Math.Pow(2, n);
            for (var pattern = 0; pattern < patterns; pattern++)
            {
                var isSatisfied = true;
                for (var i = 0; i < m; i++)
                {
                    var switches = lamps[i];
                    var switchCount = switches.Count(s => (1 << (s - 1) & pattern) > 0);
                    isSatisfied &= switchCount % 2 == conds[i];
                    if (!isSatisfied) break;
                }

                if (isSatisfied) count++;
            }

            // 解答の出力
            Console.WriteLine(count);
        }
    }
}
