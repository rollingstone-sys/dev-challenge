using GameOfLifeApp.Models;
using System.Collections.Generic;

namespace GameOfLifeApp.Interface
{
    interface IGridHelper
    {
        Grid CreateGridForInitialSeed(List<Point> points);
        void UpdateGridOneGeneration(Grid gObj);
    }
}
