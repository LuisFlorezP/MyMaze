using Maze.Logic;


try
{
    var maze = new MyMaze(50, 100);
    maze.Solution();
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(maze);
    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}