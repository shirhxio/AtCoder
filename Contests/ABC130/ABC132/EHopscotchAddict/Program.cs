using System;
using System.Collections.Generic;
using System.Linq;

// https://atcoder.jp/contests/abc132/tasks/abc132_e
namespace EHopscotchAddict
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力の取得
            var inputNM = Console.ReadLine().Split().ToArray();
            var n = int.Parse(inputNM[0]);
            var m = long.Parse(inputNM[1]);

            // 各ノードの移動可能先一覧を取得
            var nodes = new List<int>[n + 1];
            for (var i = 0; i < n + 1; i++) nodes[i] = new List<int>();
            for (var i = 0; i < m; i++)
            {
                var inputUV = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int u = inputUV[0], v = inputUV[1];
                nodes[u].Add(v);
            }

            // スタート・ゴール地点のノード取得
            var inputST = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int s = inputST[0], t = inputST[1];

            // 幅優先探索を用いて、各ノードへの最短経路を求める
            // distances はけんけんぱの各状態での最短経路の一覧となる
            // distances : 0 -> ぴったり、 1 -> けんけんば１歩目、 2 -> けんけんぱ２歩目
            var distances = new int[n + 1, 3];
            var queue = new Queue<Tuple<int, int>>();

            for (var i = 0; i < n + 1; i++)
            {
                distances[i, 0] = -1;
                distances[i, 1] = -1;
                distances[i, 2] = -1;
            }
            distances[s, 0] = 0;
            queue.Enqueue(Tuple.Create(s, 0));

            while (queue.Any())
            {
                var path = queue.Dequeue();
                int node = path.Item1, state = path.Item2;

                var nextState = (state + 1) % 3;
                foreach (var dest in nodes[node])
                {
                    if (distances[dest, nextState] != -1) continue;
                    distances[dest, nextState] = distances[node, state] + 1;
                    queue.Enqueue(Tuple.Create(dest, nextState));
                }
            }

            var goalDistance = distances[t, 0];
            var answer = goalDistance < 0 ? -1 : goalDistance / 3;

            // 解答の出力
            Console.WriteLine(answer);
        }
    }
}
