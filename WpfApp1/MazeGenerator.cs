using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MazeGenerator
    {
        static private Random _rnd = new Random();
        private LabyrinthSquare[,] _environment;
        private bool[,] _visited;

        public LabyrinthSquare[,] GenerateMaze(uint xSize, uint ySize)
        {
            _environment = new LabyrinthSquare[xSize, ySize];
            for (int i = 0; i < xSize; ++i)
                for (int j = 0; j < ySize; ++j)
                    _environment[i, j] = new LabyrinthSquare(i, j);
            _visited = new bool[xSize, ySize];
            for (int i = 0; i < xSize; ++i)
                for (int j = 0; j < ySize; ++j)
                    _visited[i, j] = false;
            GenerateMazeRec(0, 0);
            return _environment;
        }

        private void GenerateMazeRec(int x, int y)
        {
            _visited[x, y] = true;
            LabyrinthSquare.Dir[] dirs = (LabyrinthSquare.Dir[])LabyrinthSquare.Dirs.Clone();
            Shuffle(dirs);
            foreach (var d in dirs)
            {
                int dd = (int)d;
                int xx = x + LabyrinthSquare.DX[dd];
                if (xx < 0 || xx >= _environment.GetLength(0))
                    continue;
                int yy = y + LabyrinthSquare.DY[dd];
                if (yy < 0 || yy >= _environment.GetLength(1))
                    continue;
                if (_visited[xx, yy])
                    continue;
                _environment[x, y].Walls[dd] = false;
                _environment[xx, yy].Walls[(dd+2)%4] = false;
                GenerateMazeRec(xx, yy);
            }
        }

        private void Shuffle(LabyrinthSquare.Dir[] dirs)
        {
            for (int i=0; i<dirs.Length; ++i)
            {
                int j = _rnd.Next(dirs.Length);
                var tmp = dirs[i];
                dirs[i] = dirs[j];
                dirs[j] = tmp;
            }
        }
    }
}
