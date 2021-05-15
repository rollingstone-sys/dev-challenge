using System.Collections.Generic;

namespace GameOfLifeApp
{
    public class Row
    {
        private List<Cell> Cells { get; set; }
        public Row()
        {
            this.Cells = new List<Cell>();
        }

        public Cell GetCell(int index)
        {
            return Cells[index];
        }

        public void AddCell(Cell cell)
        {
            this.Cells.Add(cell);
        }
    }
}
