using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PathFinding
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = new PathFinder();
            var grid = path.BlankGrid(5, 5);
            var graph = path.BuildGraphFromGrid(grid);
            path.PrintGraph(graph);
            path.Dijkstra(graph, 0, 4);

            Console.ReadLine();
        }
    }

    class PathFinder
    {
        public Dictionary<int, List<int[]>> BuildGraphFromGrid(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                throw new ArgumentException("Grid must be defined");
            else
                for (int i = 0; i < grid.Length; i++)
                    if (grid[0].Length != grid[i].Length)
                        throw new ArgumentException("Grid must be rectangular");

            var graph = new Dictionary<int, List<int[]>>();

            var height = grid.Length;
            var width = grid[0].Length;
            var gridNodes = CreateGridNodes(height, width);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var node = gridNodes[i][j];
                    var childNodes = new List<int[]>();
                    var mul = 1;
                    if (i - 1 >= 0)
                        if (grid[i - 1][j] == 0)
                            childNodes.Add(new int[] { gridNodes[i - 1][j], mul });
                    if (i + 1 < height)
                        if (grid[i + 1][j] == 0)
                            childNodes.Add(new int[] { gridNodes[i + 1][j], mul });
                    if (j - 1 >= 0)
                        if (grid[i][j - 1] == 0)
                            childNodes.Add(new int[] { gridNodes[i][j - 1], mul });
                    if (j + 1 < width)
                        if (grid[i][j + 1] == 0)
                            childNodes.Add(new int[] { gridNodes[i][j + 1], mul });
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

        public List<int> Dijkstra(Dictionary<int, List<int[]>> graph, int start, int goal)
        {
            var path = new List<int>();
            var unseenNodes = graph;
            var infinity = 100;
            var shortestDistance = new Dictionary<int, int>();
            var predecessor = new Dictionary<int, int>();

            foreach (var g in graph)
                shortestDistance.Add(g.Key, infinity);

            shortestDistance[start] = 0;

            while (unseenNodes.Count > 0)
            {
                int minNode = -1;
                foreach (var node in unseenNodes)
                {
                    if (minNode < 0)
                        minNode = node.Key;
                    else if (shortestDistance[node.Key] < shortestDistance[node.Key])
                        minNode = node.Key;
                }

                foreach (var kvp in graph[minNode])
                {
                    int childNode = kvp[0];
                    int weight = kvp[1];
                    if (weight + shortestDistance[minNode] < shortestDistance[childNode])
                    {
                        shortestDistance[childNode] = weight + shortestDistance[minNode];
                        predecessor.Add(childNode, minNode);
                    }
                }
                unseenNodes.Remove(minNode);
            }

            var currentNode = goal;
            while (currentNode != start)
            {

            }

            Debugger.Break();


            /*
    shortest_distance = {}
    predecessor = {}
    unseenNodes = graph
    infinity = 100
    path = []

    for node in unseenNodes:
        shortest_distance[node] = infinity

    shortest_distance[start] = 0

    while unseenNodes:
        minNode = None
        for node in unseenNodes:
            if minNode is None:
                minNode = node
            elif shortest_distance[node] < shortest_distance[minNode]:
                minNode = node

        for childNode, weight in graph[minNode].items():
            if weight + shortest_distance[minNode] < shortest_distance[childNode]:
                shortest_distance[childNode] = weight + shortest_distance[minNode]
                predecessor[childNode] = minNode

        unseenNodes.pop(minNode)

    currentNode = goal
    while currentNode != start:
        try:
            path.insert(0, currentNode)
            currentNode = predecessor[currentNode]
        except:
            path = None
            break

    if path is not None:
        path.insert(0, start)

    return path
            */

            return new List<int>();
        }

        public int GetCell(int row, int column, int width, int height)
        {
            return row * width + column;
        }

        public (int, int) GetRowCol(int cell, int width, int height)
        {
            int row = cell / width;
            int col = cell % width;
            return (row, col);
        }

        public void PrintGrid(float[][] grid)
        {

        }

        public void PrintGraph(Dictionary<int, List<int[]>> graph)
        {
            foreach (var g in graph)
            {
                string output = $"{g.Key}: ";
                foreach (var v in g.Value)
                    output += $"{v[0]},";
                Console.WriteLine(output);
            }

        }
    }
}
