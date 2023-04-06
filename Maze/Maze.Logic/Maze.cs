﻿namespace Maze.Logic
{
    public class MyMaze
    {
        private char[,] _maze;

        public MyMaze(int n, int obstacles)
        {
            N = n;
            Obstacles = obstacles;
            _maze = new char[N, N];
            FillMaze();
        }

        public int N { get; }

        private char[,] Maze { set => _maze = value; }

        public int Obstacles { get; }

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    output += $"{_maze[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        private void FillMaze()
        {
            FillBorders();
            FillObstacles();
        }

        private void FillBorders()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    _maze[i, j] = ' ';
                }
            }
            for (int i = 0; i < N; i++)
            {
                _maze[0, i] = '█';
            }
            _maze[1, N - 1] = '█';
            for (int i = 2; i < N - 2; i++)
            {
                _maze[i, 0] = '█';
                _maze[i, N - 1] = '█';
            }
            _maze[N - 2, 0] = '█';
            for (int i = 0; i < N; i++)
            {
                _maze[N - 1, i] = '█';
            }
        }

        private void FillObstacles()
        {
            var random = new Random();
            int obstaclesCount = 0;
            do
            {
                var i = random.Next(1, N - 1);
                var j = random.Next(1, N - 1);
                if (!(i == 1 && j == 1 || i == N - 2 && j == N - 2))
                {
                    if (_maze[i, j] == ' ')
                    {
                        _maze[i, j] = '█';
                        obstaclesCount++;
                    }
                }
            } while (obstaclesCount < Obstacles);
        }

        public void Solution()
        {
            _maze[1, 0] = 'R';
            int i = 1, j = 1;
            while (true)
            {
                if (i < N - 2) 
                {
                    if (_maze[i, j + 1] != 'L')
                    {
                        if (_maze[i, j + 1] != '█')
                        {
                            _maze[i, j] = 'R';
                            j++;
                        }
                        else
                        {
                            if (_maze[i + 1, j] != '█')
                            {
                                _maze[i, j] = 'D';
                                i++;
                            }
                            else
                            {
                                if (_maze[i, j - 1] != '█')
                                {
                                    _maze[i, j] = 'L';
                                    j--;
                                }
                                else
                                {
                                    throw new Exception("Maze is not valid.");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_maze[i + 1, j] != '█')
                        {
                            _maze[i, j] = 'D';
                            i++;
                        }
                        else
                        {
                            throw new Exception("Maze is not valid.");
                        }
                    }
                }
                else
                {
                    if (j < N - 1)
                    {
                        if (_maze[N - 2, j + 1] != '█')
                        {
                            _maze[N - 2, j] = 'R';
                            j++;
                        }
                        else
                        {
                            throw new Exception("Maze is not valid.");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            _maze[N - 2, N - 1] = 'R';
        }
    }
}