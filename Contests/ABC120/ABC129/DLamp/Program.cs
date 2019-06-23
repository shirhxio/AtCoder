using System;
using System.Linq;

namespace DLamp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 入力 H/W の取得
            var inputsHW = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var h = inputsHW[0];
            var w = inputsHW[1];

            // マップの配列と行、列の各マスの点数表を生成
            var map = new bool[h][];
            var rows = new MapLine[h];
            var columns = new MapLine[w];
            for (var i = 0; i < h; i++)
            {
                var row = Console.ReadLine().ToCharArray().Select(c => c == '#').ToArray();
                map[i] = row;
                rows[i] = new MapLine(row);
            }

            for (var i = 0; i < w; i++)
            {
                var column = map.Select(row => row[i]).ToArray();
                columns[i] = new MapLine(column);
            }

            // 各マスでの照らし出されるマス数を計算
            var maxCount = 0;
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (map[i][j]) continue;

                    var lightCount = rows[i].Scores[j] + columns[j].Scores[i] - 1;
                    if (maxCount < lightCount) maxCount = lightCount;
                }
            }

            // 解答の出力
            Console.WriteLine(maxCount);
        }
    }

    class MapLine
    {
        int[] _walls;
        public readonly int[] Scores;

        public MapLine(bool[] elements)
        {
            _walls = elements.Select((e, i) => Tuple.Create(e, i)).Where(t => t.Item1).Select(t => t.Item2).ToArray();

            Scores = new int[elements.Length];
            foreach (var wall in _walls) Scores[wall] = 0;
            for (var i = 0; i < _walls.Length + 1; i++)
            {
                var wall = i != _walls.Length ? _walls[i] : elements.Length;
                var prev = i != 0 ? _walls[i - 1] : -1;

                var score = wall - prev - 1;
                for (var j = prev + 1; j < wall; j++)
                {
                    Scores[j] = score;
                }
            }
        }
    }
}
