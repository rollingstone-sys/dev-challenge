
namespace GameOfLifeApp.Models
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public int NeighbourLiveCount { get; set; }

        public Cell(bool IsAlive)
        {
            this.IsAlive = IsAlive;
        }

        public void UpdateStatus()
        {
            if (this.IsAlive)
                this.IsAlive = this.NeighbourLiveCount == 2 || this.NeighbourLiveCount == 3;
            else
                this.IsAlive = this.NeighbourLiveCount == 3;
        }
    }
}
