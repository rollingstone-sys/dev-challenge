using GameOfLifeApp.Interface;
using GameOfLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApp.Implementation
{
    class GridHelper : IGridHelper
    {
        public Grid CreateGridForInitialSeed(List<Point> points)
        {
            int max = points.Max(point => point.Xc > point.Yc ? point.Xc : point.Yc);
            Grid gNew = new Grid(max + 1);
            for (int i = 0; i <= max; i++)
            {
                Row row = new Row();
                for (int j = 0; j <= max; j++)
                {
                    Cell cell = new Cell(points.Any(point => point.Xc == i && point.Yc == j));
                    row.AddCell(cell);
                }
                gNew.Rows.Add(row);
            }
            return gNew;
        }

        public void UpdateGridOneGeneration(Grid gObj)
        {
            
            Parallel.For(0, gObj.Size, i =>
            {
                Parallel.For(0, gObj.Size, j =>
                {
                    UpdateAliveNeighbour(gObj, i, j);
                });
            });

            foreach (var row in gObj.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    cell.UpdateStatus();
                }
            }
        }

        private void UpdateAliveNeighbour(Grid gObj, int x, int y)
        {
            int size = gObj.Size;
            int liveCount = 0;
            if (x + 1 < size)
            {
                if (gObj.Rows[x + 1].Cells[y].IsAlive)
                    liveCount++;
                if (y + 1 < size && gObj.Rows[x + 1].Cells[y + 1].IsAlive)
                    liveCount++;
                if (y - 1 >= 0 && gObj.Rows[x + 1].Cells[y - 1].IsAlive)
                    liveCount++;

            }
            if (x - 1 >= 0)
            {
                if (gObj.Rows[x - 1].Cells[y].IsAlive)
                    liveCount++;
                if (y + 1 < size && gObj.Rows[x - 1].Cells[y + 1].IsAlive)
                    liveCount++;
                if (y - 1 >= 0 && gObj.Rows[x - 1].Cells[y - 1].IsAlive)
                    liveCount++;

            }
            if (y + 1 < size && gObj.Rows[x].Cells[y + 1].IsAlive)
                liveCount++;
            if (y -1 >= 0 && gObj.Rows[x].Cells[y - 1].IsAlive)
                liveCount++;

            gObj.Rows[x].Cells[y].NeighbourLiveCount = liveCount;

        }

    }
}
