using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ERoadwork
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力 N/Q の取得
            var inputNQ = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = inputNQ[0];    // 道路工事の数
            var q = inputNQ[1];    // 調査対象の人数

            // 道路工事情報の取得
            var roadworks = new Roadwork[n];
            for (var i = 0; i < n; i++)
            {
                var inputSTX = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var s = inputSTX[0];
                var t = inputSTX[1];
                var x = inputSTX[2];

                roadworks[i] = new Roadwork(s, t, x);
            }

            // 道路工事の位置順に並び替え
            Array.Sort(roadworks, (a, b) => a.Position.CompareTo(b.Position));

            var reachablePositions = new int[q];
            for (var i = 0; i < q; i++)
            {
                var departureTime = int.Parse(Console.ReadLine());
                Roadwork roadwork = null;
                foreach (var r in roadworks)
                {
                    if (!r.NeedToStop(departureTime)) continue;

                    roadwork = r;
                    break;
                }

                reachablePositions[i] = roadwork != null ? roadwork.Position : -1;
            }

            // 解答の出力
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            for (var i = 0; i < q; i++)
            {
                Console.WriteLine(reachablePositions[i]);
            }
            Console.Out.Flush();
        }
    }

    class Roadwork
    {
        readonly int startTime, endTime;

        public int Position { get; }

        public Roadwork(int s, int t, int x)
        {
            startTime = s;
            endTime = t;
            Position = x;
        }

        // 調査対象が到着時刻に工事中か否か
        public bool NeedToStop(int departureTime)
        {
            var arrivalTime = departureTime + Position;
            return startTime <= arrivalTime && arrivalTime < endTime;
        }

        public bool IsReachable(int departureTime)
        {
            return departureTime + Position < endTime;
        }
    }
}
