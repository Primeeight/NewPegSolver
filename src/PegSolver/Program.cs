using System;

public class Program
{
        //size of the triangle, default is 4.
        static int tSize = 4;
        //state representation of the triangle, default is empty table.
        static int[][] stateMap = [[]];

        static int[][] triMap = [[]];
         static Dictionary<(int, int), (int, int)[]> adjList = new Dictionary<(int, int), (int,int)[]>();
        //Generate a new trinagle from the given size.
        public static void createTriangle()
        {
                int[][] newTriMap = new int[tSize][];
                //Generate the width of the graph.
                int width = 2 * tSize + 1;
                newTriMap[0] = new int[width];
                //initialize the values to 0.
                for (int i = 0; i < width; i++)
                {
                        newTriMap[0][i] = 0;
                }
                //initialize the first row.
                newTriMap[0][tSize] = 1;
                //for each row: Create a row of zeros, iterate from the left index to the right, changing each value as needed.
                for (int i = 1; i < tSize; i++)
                {
                        newTriMap[i] = new int[width];
                        for (int j = 0; j < width; j++)
                        {
                                newTriMap[i][j] = 0;
                        }
                        newTriMap[i][tSize - i] = 1;
                        for (int x = tSize - i; x <= tSize + i; x++)
                        {
                                if (newTriMap[i][x - 1] != 1)
                                {
                                        newTriMap[i][x] = 1;
                                }
                        }
                }
                triMap = newTriMap;
        }
        static public void displayTriangle(int[][] tirangle)
        {
                for (int i = 0; i < tirangle.Length; i++)
                {
                        foreach (int element in tirangle[i])
                        {
                                Console.Write(element);
                        }
                        Console.WriteLine();
                }
        }
        static public void mapTriangle()
        {
                
                int width = 2 * tSize + 1;
                int[,] newTriMap = new int[tSize, width];
                //max of 8 adjacent elements
                (int, int)[] currElement = new (int, int) [8];

                for (int i = 0; i < triMap.Length; i++)
                {
                        for (int j = 0; j < triMap[i].Length; j++)
                        {
                                if (triMap[i][j] == 1)
                                {
                                        adjList.Add((i, j), currElement);
                                        if (triMap[i + 1][j] == 1)
                                        {
                                                currElement[0] = (i + 1, j);
                                        }

                                }
                                Console.WriteLine(currElement[0]);

                        }
                }
        }
        static public Boolean checkSolution(int[][] triangle)
        {
                int count = 0;
                for (int i = 0; i < triangle.Length; i++)
                {
                        for (int j = 0; j < triangle[i].Length; j++)
                        {
                                count += triangle[i][j];
                                if (count > 1)
                                        return false;
                        }
                }
                return true;
        }
        //accepts two verticies
        //makes a move from the first verticie to the next space in the same direction as the second veritcie
        //assumes given veritcies are valid (for now).         
        public static (int, int) move((int, int) v1, (int, int) v2)
        {
                (int, int) direction = (v2.Item1 - v1.Item1, v2.Item2 - v1.Item2);
                return (v2.Item1 + direction.Item1, v2.Item2 + direction.Item2);

        }
        public static void Main(string[] args)
        {
                createTriangle();
                displayTriangle(triMap);
                mapTriangle();
                Console.WriteLine(checkSolution(triMap));
                if (move((2, 2), (1, 1)) == (0, 0))
                {
                        Console.WriteLine("move from 2,2 to 1,1 is 0,0");
                }
                else
                {
                        Console.WriteLine("move failed");
                }
        }
}
