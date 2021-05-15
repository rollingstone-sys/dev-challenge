using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLifeApp.Test
{
    public class GridTest
    {
        [Fact]
        public void Grid_Constructor_ValidInput_Test()
        {
            Grid g = new Grid(4, new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(2, 1),
                new Point(2, 2)
            });
            List<Row> r = g.GetRows();
            Assert.Equal(4, g.GetRows().Count);
            Assert.True(r[1].GetCell(1).Status());
            Assert.True(r[1].GetCell(2).Status());
            Assert.True(r[2].GetCell(1).Status());
            Assert.True(r[2].GetCell(2).Status());
        }

        [Fact]
        public void Grid_Constructor_InValidInput_Test()
        {
           Assert.Throws<ArgumentOutOfRangeException>(() => new Grid(0, new List<Point>())); 
        }


        [Fact]
        public void UpdateGeneration_BlockPattern_Test()
        {
            Grid g = new Grid(4, new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(2, 1),
                new Point(2, 2)
            });
            g.UpdateGeneration();
            List<Row> r = g.GetRows();
            Assert.True(r[1].GetCell(1).Status());
            Assert.True(r[1].GetCell(2).Status());
            Assert.True(r[2].GetCell(1).Status());
            Assert.True(r[2].GetCell(2).Status());
        }

        [Fact]
        public void UpdateGeneration_BoatPattern_Test()
        {
            Grid g = new Grid(5, new List<Point>
            {
                new Point(0, 1),
                new Point(1, 0),
                new Point(2, 1),
                new Point(0, 2),
                new Point(1, 2),
            });
            g.UpdateGeneration();
            List<Row> r = g.GetRows();
            Assert.True(r[0].GetCell(1).Status());
            Assert.True(r[1].GetCell(0).Status());
            Assert.True(r[2].GetCell(1).Status());
            Assert.True(r[0].GetCell(2).Status());
            Assert.True(r[1].GetCell(2).Status());

        }

        [Fact]
        public void UpdateGeneration_BlinkerPattern_Test()
        {
            Grid g = new Grid(3, new List<Point>
            {
                new Point(1, 1),
                new Point(1, 0),
                new Point(1, 2)
            });
            g.UpdateGeneration();
            List<Row> r = g.GetRows();
            Assert.True(r[1].GetCell(1).Status());
            Assert.True(r[0].GetCell(1).Status());
            Assert.True(r[2].GetCell(1).Status());
        }

        [Fact]
        public void UpdateGeneration_ToadPattern_Test()
        {
            Grid g = new Grid(6, new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(1, 3),
                new Point(2, 2),
                new Point(2, 3),
                new Point(2, 4)

            });
            g.UpdateGeneration();
            List<Row> r = g.GetRows();
            Assert.True(r[0].GetCell(2).Status());
            Assert.True(r[1].GetCell(1).Status());
            Assert.True(r[1].GetCell(4).Status());
            Assert.True(r[2].GetCell(1).Status());
            Assert.True(r[2].GetCell(4).Status());
            Assert.True(r[3].GetCell(3).Status());

        }

    }
}
