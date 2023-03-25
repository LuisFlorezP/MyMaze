using Maze.Logic;


try
{
    var maze = new MyMaze(10, 7);
    Console.WriteLine(maze);
    maze.Solution();
    Console.WriteLine(maze);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}