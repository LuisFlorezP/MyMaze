using Maze.Logic;


try
{
    var maze = new MyMaze(50, 100);
    Console.WriteLine(maze);
    maze.Solution();
    Console.WriteLine(maze);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}