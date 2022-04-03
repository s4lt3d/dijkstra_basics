using System;
using System.Collections.Generic;

namespace PathFinding
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = new PathFinder();

            var grid = path.BlankGrid(5, 5);
            var graph = path.BuildGraphFromGrid(grid);

            foreach(var g in graph)
            {

            }
        }
    }

    class PathFinder
    {
        public Dictionary<int, Dictionary<int, int>> BuildGraphFromGrid(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                throw new ArgumentException("Grid must be defined");
            else
                for (int i = 0; i < grid.Length; i++)
                    if (grid[0].Length != grid[i].Length)
                        throw new ArgumentException("Grid must be rectangular");

            var graph = new Dictionary<int, Dictionary<int, int>>();

            var height = grid.Length;
            var width = grid[0].Length;
            var gridNodes = CreateGridNodes(height, width);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var node = gridNodes[i][j];
                    var childNodes = new Dictionary<int, int>();
                    var mul = 1;
                    if (i - 1 >= 0)
                        if (grid[i - 1][j] == 0)
                            childNodes.Add(gridNodes[i - 1][j], mul);
                    if (i + 1 < height)
                        if(grid[i + 1][j] == 0)
                            childNodes.Add(gridNodes[i + 1][j], mul);
                    if (j - 1 >= 0)
                        if(grid[i][j - 1] == 0)
                            childNodes.Add(gridNodes[i][j - 1], mul);
                    if (j + 1 < width)
                        if (grid[i][j + 1] == 0)
                            childNodes.Add(gridNodes[i][j + 1], mul);
                    graph.Add(node, childNodes);
                }
            }
            return graph;
        }

        protected int[][] CreateGridNodes(int height, int width)
        {
            var gridNodes = new int[height][];
            var gridIndex = 0;
            for (int i = 0; i < height; i++)
            {
                gridNodes[i] = new int[width];
                for (int j = 0; j < width; j++)
                {
                    gridNodes[i][j] = gridIndex++;
                }
            }
            return gridNodes;
        }

        public int[][] BlankGrid(int height, int width)
        {
            var gridNodes = new int[height][];
            for (int i = 0; i < height; i++)
            {
                gridNodes[i] = new int[width];
                for (int j = 0; j < width; j++)
                {
                    gridNodes[i][j] = 0;
                }
            }
            return gridNodes;
        }

            public List<int> Dijkstra(List<List<int>> graph, int start, int goal)
        {
            return new List<int>();
        }

        public int GetCell(int row, int column, int width, int height)
        {
            return 0;
        }

        public (int, int) GetRowCol(int cell, int width, int height)
        {
            return (0, 0);
        }

        public void PrintGrid(float[][] grid)
        {

        }

        public void PrintGraph(List<List<int>> graph)
        {

        }
    }
}
