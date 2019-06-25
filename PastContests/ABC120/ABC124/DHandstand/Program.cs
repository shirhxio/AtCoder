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
                for (var i = 0; i <= uprightGroups - k; i++)
                {
                    var handstands = n;
                    var uprightGroupCount = 0;
                    foreach (var group in stateSummary)
                    {
                        // i - 1 番目直立グループから前の人数を総計から差し引く
                        if (uprightGroupCount < i) handstands -= group.Item2;
                        if (!group.Item1) uprightGroupCount++;
                        // i + k 番目直立グループから後の人数を総計から差し引く
                        if (i + k < uprightGroupCount) handstands -= group.Item2;
                    }

                    if (maxHandstands < handstands) maxHandstands = handstands;
                }
            }

            // 解答の出力
            Console.WriteLine(maxHandstands);
        }
    }
}
