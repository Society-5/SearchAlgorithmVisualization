using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ViewModel
    {

        private MazeGenerator _mazeGenerator;
        public LabyrinthSquare[,] GenerateMaze(uint xSquares, uint ySquares)
        {
            return  _mazeGenerator.GenerateMaze(xSquares, ySquares);
        }

        public PathFindingSquare[,] FindPath(string algorithm)
        {
            throw new NotImplementedException();
        }

        public ViewModel()
        {
            _mazeGenerator = new MazeGenerator();
        }
    }
    public class LabyrinthSquare
    {
        public enum Dir
        {
            Right=0,
            Up=1,
            Left=2,
            Down=3,
        }
        public static Dir[] Dirs={ Dir.Right, Dir.Up, Dir.Left, Dir.Down};
        public static int[] DX = { 1, 0, -1, 0 };
        public static int[] DY = { 0, -1, 0, 1 };

        public int x { get; }
        public int y { get; }

        public bool[] Walls = { true, true, true, true };

        public int distanceUp;
        public int distanceRight;
        public int distanceDown;
        public int distanceLeft;

        public LabyrinthSquare(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class PathFindingSquare
    {
        public int x { get; }
        public int y { get; }

        public bool wasVisited;
        public bool wasObserved;
        public bool isStart;
        public bool isEnd;
    }
}
