using System.Collections.Generic;

namespace GameOfLifeApp.Models
{
    public class Row
    {
        public List<Cell> Cells { get; set; }
        public Row()
        {
            this.Cells = new List<Cell>();
        }

        public void AddCell(Cell cell)
        {
            this.Cells.Add(cell);
        }
    }
}
