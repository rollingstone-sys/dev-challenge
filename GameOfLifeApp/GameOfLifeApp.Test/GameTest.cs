using System.Collections.Generic;
using Xunit;

namespace GameOfLifeApp.Test
{
    public class GameTest
    {
        [Fact]
        public void Start_BlockPattern_OneGeneration_Test()
        {
            Game g = new Game();
            List<Point> p = new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(2, 1),
                new Point(2, 2)
            };
            g.SetPoints(p);
            g.Start(1);
            List<Row> r = g.GetGrid().GetRows();
            Assert.True(r[1].GetCell(1).Status());
            Assert.True(r[1].GetCell(2).Status());
            Assert.True(r[2].GetCell(1).Status());
            Assert.True(r[2].GetCell(2).Status());

        }

        [Fact]
        public void Start_BoatPattern_OneGeneration_Test()
        {
            Game g = new Game();
            List<Point> p = new List<Point>
            {
                new Point(0, 1),
                new Point(1, 0),
                new Point(2, 1),
                new Point(0, 2),
                new Point(1, 2),
            };
            g.SetPoints(p);
            g.Start(1);
            List<Row> r = g.GetGrid().GetRows();
            Assert.True(r[0].GetCell(1).Status());
            Assert.True(r[1].GetCell(0).Status());
            Assert.True(r[2].GetCell(1).Status());
            Assert.True(r[0].GetCell(2).Status());
            Assert.True(r[1].GetCell(2).Status());

        }

        [Fact]
        public void Start_BlinkerPattern_OneGeneration_Test()
        {
            Game g = new Game();
            List<Point> p = new List<Point>
            {
                new Point(1, 1),
                new Point(1, 0),
                new Point(1, 2)
            };
            g.SetPoints(p);
            g.Start(1);
            List<Row> r = g.GetGrid().GetRows();
            Assert.True(r[1].GetCell(1).Status());
            Assert.True(r[0].GetCell(1).Status());
            Assert.True(r[2].GetCell(1).Status());
        }

        [Fact]
        public void Start_ToadPattern_OneGeneration_Test()
        {
            Game g = new Game();
            List<Point> p = new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(1, 3),
                new Point(2, 2),
                new Point(2, 3),
                new Point(2, 4)

            };
            g.SetPoints(p);
            g.Start(1);
            List<Row> r = g.GetGrid().GetRows();
            Assert.True(r[0].GetCell(2).Status());
            Assert.True(r[1].GetCell(1).Status());
            Assert.True(r[1].GetCell(4).Status());
            Assert.True(r[2].GetCell(1).Status());
            Assert.True(r[2].GetCell(4).Status());
            Assert.True(r[3].GetCell(3).Status());

        }
    }
}
