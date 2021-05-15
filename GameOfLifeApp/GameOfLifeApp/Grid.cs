using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLifeApp
{
    public class Grid
    {
        private int Size { get; set; }
        private List<Row> Rows { get; set; }

        public Grid(int size, List<Point> points)
        {
            Size = size;
            Rows = new List<Row>();
            if (size <= 0) 
                throw new ArgumentOutOfRangeException("Grid size must be greater than zero");
            for (int i = 0; i < size; i++)
            {
                Row row = new Row();
                for (int j = 0; j < size; j++)
                {
                    Cell cell = new Cell(points.Any(point => point.Xc == i && point.Yc == j));
                    row.AddCell(cell);
                }
                Rows.Add(row);
            }
        }

        public void UpdateGeneration()
        {
            UpdateNeighbourCellCount();
            UpdateCellStatus();
        }

        private void UpdateNeighbourCellCount()
        {
            Parallel.For(0, Size, i =>
            {
                Parallel.For(0, Size, j =>
                {
                    UpdateAliveNeighbours(i, j);
                });
            });

        }

        private void UpdateAliveNeighbours(int x, int y)
        {
            int liveCount = 0;
            if (x + 1 < Size)
            {
                if (Rows[x + 1].GetCell(y).Status())
                    liveCount++;
                if (y + 1 < Size && Rows[x + 1].GetCell(y + 1).Status())
                    liveCount++;
                if (y - 1 >= 0 && Rows[x + 1].GetCell(y - 1).Status())
                    liveCount++;

            }
            if (x - 1 >= 0)
            {
                if (Rows[x - 1].GetCell(y).Status())
                    liveCount++;
                if (y + 1 < Size && Rows[x - 1].GetCell(y + 1).Status())
                    liveCount++;
                if (y - 1 >= 0 && Rows[x - 1].GetCell(y - 1).Status())
                    liveCount++;

            }
            if (y + 1 < Size && Rows[x].GetCell(y + 1).Status())
                liveCount++;
            if (y - 1 >= 0 && Rows[x].GetCell(y - 1).Status())
                liveCount++;

            Rows[x].GetCell(y).SetNeighbourLiveCount(liveCount);

        }

        private void UpdateCellStatus()
        {
            foreach (var row in Rows)
            {
                for (int j = 0; j < Size; j++)
                {
                    row.GetCell(j).UpdateStatus();
                }
            }
        }

        public void DisplayGrid()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Rows[i].GetCell(j).Status())
                        Console.WriteLine("{0}, {1}", i, j);

                }


            }
        }

        public List<Row> GetRows()
        {
            return Rows;
        }
    }
}
