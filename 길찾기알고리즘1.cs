using System;
using System.Collections.Generic;

class 길찾기알고리즘1
{
    static void Main(string[] args)
    {
        int width = 5, height = 5;
        char[,] map = 
        {
            {' ', ' ', '▩', ' ', 'D'},
            {' ', ' ', '▩', ' ', ' '},
            {' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' '},
            {'S', ' ', ' ', ' ', ' '}
        };

        Point start = new Point(4, 0);
        Point destination = new Point(0, 4);

        List<Point> path = FindShortestPath(map, start, destination);

        PrintMap(map, path, start, destination);
    }

    struct Point
    {
        public int width, height;
        public Point(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }

    class Node
    {
        public Point Position { get; set; }
        public Node Parent { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public int F => G + H;

        public Node(Point position, Node parent = null)
        {
            Position = position;
            Parent = parent;
        }
    }

    static readonly Point[] directions = 
    {
        new Point(-1, 0),
        new Point(1, 0),
        new Point(0, -1),
        new Point(0, 1)
    };

    static List<Point> FindShortestPath(char[,] map, Point start, Point destination)
    {
        List<Node> openList = new List<Node>();
        List<Point> closedList = new List<Point>();
        Node startNode = new Node(start);
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = openList[0];
            foreach (var node in openList)
            {
                if (node.F < currentNode.F)
                    currentNode = node;
            }

            if (currentNode.Position.width == destination.width && currentNode.Position.height == destination.height)
            {
                return ReconstructPath(currentNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode.Position);

            foreach (var direction in directions)
            {
                Point neighborPos = new Point(currentNode.Position.width + direction.width, currentNode.Position.height + direction.height);

                if (neighborPos.width < 0 || neighborPos.width >= map.GetLength(0) ||
                    neighborPos.height < 0 || neighborPos.height >= map.GetLength(1) ||
                    map[neighborPos.width, neighborPos.height] == '▩' ||
                    closedList.Contains(neighborPos))
                {
                    continue;
                }

                Node neighborNode = new Node(neighborPos, currentNode);
                neighborNode.G = currentNode.G + 1;
                neighborNode.H = Math.Abs(neighborPos.width - destination.width) + Math.Abs(neighborPos.height - destination.height);
                neighborNode.Parent = currentNode;

                Node existingNode = openList.Find(node => node.Position.width == neighborNode.Position.width && node.Position.height == neighborNode.Position.height);
                if (existingNode != null)
                {
                    if (neighborNode.G < existingNode.G)
                    {
                        existingNode.G = neighborNode.G;
                        existingNode.Parent = currentNode;
                    }
                }
                else
                {
                    openList.Add(neighborNode);
                }
            }
        }
        return new List<Point>();
    }

    static List<Point> ReconstructPath(Node node)
    {
        List<Point> path = new List<Point>();
        while (node != null)
        {
            path.Add(node.Position);
            node = node.Parent;
        }
        path.Reverse();
        return path;
    }

    static void PrintMap(char[,] map, List<Point> path, Point start, Point destination)
    {
        for (int width = 0; width < map.GetLength(0); width++)
        {
            for (int height = 0; height < map.GetLength(1); height++)
            {
                Point current = new Point(width, height);

                if (current.width == start.width && current.height == start.height)
                {
                    Console.Write("[S]");
                }
                else if (current.width == destination.width && current.height == destination.height)
                {
                    Console.Write("[D]");
                }
                else if (map[width, height] == '▩')
                {
                    Console.Write("▩ ");
                }
                else if (path.Contains(current))
                {
                    Console.Write("[■]");
                }
                else
                {
                    Console.Write("[ ]");
                }
            }
            Console.WriteLine();
        }
    }
}
