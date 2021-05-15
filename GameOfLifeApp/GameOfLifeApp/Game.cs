using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLifeApp
{
    public class Game
    {
        private List<Point> Points { get; set; }
        private Grid GridObj { get; set; }

        public Game()
        {
            Points = new List<Point>();
        }
       
        public void ProcessUserInput()
        {
            Console.WriteLine("-------------Enter Inital Pattern-----------------");
            Console.WriteLine("----------Type 'done' to display output----------------");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "done")
                {
                    break;
                }
                else
                {
                    Regex.Replace(input, @"\s+", "");
                    string[] words = input.Split(',');
                    Points.Add(new Point(Int32.Parse(words[0]), Int32.Parse(words[1])));
                }
            }
        }

        public void Start(int generations)
        {
            int max = Points.Max(point => point.Xc > point.Yc ? point.Xc : point.Yc);
            GridObj = new Grid(max + 1, Points);

            for (int i = 0; i < generations; i++)
            {
                GridObj.UpdateGeneration();
            }
        }

        public void Finish()
        {
            GridObj.DisplayGrid();
        }

        public Grid GetGrid()
        {
            return GridObj;
        }

        public List<Point> GetPoints()
        {
            return Points;
        }

        public void SetPoints(List<Point> points)
        {
            Points = points;
        }
    }
}
