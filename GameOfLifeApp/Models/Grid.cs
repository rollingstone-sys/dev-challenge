using System.Collections.Generic;

namespace GameOfLifeApp.Models
{
    public class Grid
    {
        public int Size { get; set; }
        public List<Row> Rows { get; set; }

        public Grid(int Size)
        {
            this.Size = Size;
            this.Rows = new List<Row>();
        }
    }
}
