
namespace GameOfLifeApp
{
    public class Cell
    {
        private bool IsAlive { get; set; }
        private int NeighbourLiveCount { get; set; }

        public Cell(bool IsAlive)
        {
            this.IsAlive = IsAlive;
        }

        public bool Status()
        {
            return IsAlive;
        }

        public int GetNeighbourLiveCount()
        {
            return NeighbourLiveCount;
        }

        public void SetNeighbourLiveCount(int liveCount)
        {
            NeighbourLiveCount = liveCount;
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
