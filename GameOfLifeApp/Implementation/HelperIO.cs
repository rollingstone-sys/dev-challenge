using GameOfLifeApp.Interface;
using GameOfLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameOfLifeApp.Implementation
{
    class HelperIO: IHelperIO
    {

        public List<Point> ProcessInput()
        {
            List<Point> points = new List<Point>();
            Console.WriteLine("-------------Enter Inital Pattern-----------------");
            Console.WriteLine("----------Type 'done' to display output----------------");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }
                else
                {
                    Regex.Replace(input, @"\s+", "");
                    string[] words = input.Split(',');
                    points.Add(new Point(Int32.Parse(words[0]), Int32.Parse(words[1])));
                }
            }
            return points;
        }

        public void DisplayGrid(Grid gObj)
        {
            int size = gObj.Size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (gObj.Rows[i].Cells[j].IsAlive)
                        Console.WriteLine("{0}, {1}", i, j);

                }

            }
        }
    }
}
