using System;
using System.Collections.Generic;
using System.Linq;

// https://atcoder.jp/contests/abc124/tasks/abc124_d
namespace DHandstand
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputs[0];
            var k = inputs[1];

            var states = Console.ReadLine().ToCharArray().Select(x => x == '1').ToArray();

            // 逆立ちしている人を1度直立させる操作も考えうるが、010->101->111 も 010->110->111 も手数が同じであるため
            // 逆立ちしている人を直立させることは除外して、連続する直立の人を反転することだけを考えることとする
            // また、すべての人が逆立ちしたらそこで操作を終了する

            // 連続する直立/逆立ちの人数をまとめる
            var stateSummary = new List<Tuple<bool, int>>();
            var currentState = states[0];
            var stateCount = 0;
            foreach (var state in states)
            {
                if (currentState != state)
                {
                    stateSummary.Add(Tuple.Create(currentState, stateCount));
                    currentState = state;
                    stateCount = 0;
                }
                stateCount++;
            }
            stateSummary.Add(Tuple.Create(currentState, stateCount));

            var maxHandstands = 0;
            var uprightGroups = stateSummary.Count(t => !t.Item1);
            if (uprightGroups <= k)
            {
                // 直立している人のグループが操作回数以下であれば、全員逆立ちにできる
                maxHandstands = n;
            }
            else
            {
                // 直立している人のグループが操作回数より多いのであれば、連続する k 個の直立グループを反転させて最大をとる
                var left = stateSummary[0].Item1 ? 1 : 0;
                var right = left + 2 * (k - 1);
                var sum = 0;
                for (var i = left - 1; i <= right + 1; i++)
                {
                    if (i < 0) continue;
                    sum += stateSummary[i].Item2;
                }

                maxHandstands = sum;

                // 尺取り法で最大値を算出していく
                for (var i = 0; i < uprightGroups - k; i++)
                {
                    if (0 <= left - 1) sum -= stateSummary[left - 1].Item2;
                    sum -= stateSummary[left].Item2;
                    left += 2;
                    right += 2;
                    sum += stateSummary[right].Item2;
                    if (right + 1 < stateSummary.Count) sum += stateSummary[right + 1].Item2;

                    if (maxHandstands < sum) maxHandstands = sum;
                }
            }

            // 解答の出力
            Console.WriteLine(maxHandstands);
        }
    }
}
