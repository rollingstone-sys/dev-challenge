using GameOfLifeApp.Models;
using System.Collections.Generic;

namespace GameOfLifeApp.Interface
{
    interface IHelperIO
    {
        List<Point> ProcessInput();
        void DisplayGrid(Grid gObj);
    }
}
