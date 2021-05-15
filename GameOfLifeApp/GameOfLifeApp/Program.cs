
namespace GameOfLifeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.ProcessUserInput();
            g.Start(1);
            g.Finish();
        }
    }
}
