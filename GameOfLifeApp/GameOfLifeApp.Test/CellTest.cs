using Xunit;

namespace GameOfLifeApp.Test
{
    public class CellTest
    {
        [Fact]
        public void UpdateStatus_CellNotAlive_Test()
        {
            Cell c = new Cell(false);
            c.SetNeighbourLiveCount(3);
            c.UpdateStatus();
            Assert.True(c.Status());

        }

        [Fact]
        public void UpdateStatus_CellAlive_Test()
        {
            Cell c = new Cell(true);
            c.SetNeighbourLiveCount(3);
            c.UpdateStatus();
            Assert.True(c.Status());
        }
    }
}
