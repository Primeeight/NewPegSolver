using System;
using System.Drawing;
using System.Globalization;

public partial class Program
{
        //size of the triangle, default is 4.
        public int tSize = 4;
        //state representation of the triangle, default is empty table.
        public int[][] stateMap = [[]];

         public int[][] triMap = [[]];
        public Dictionary<(int, int), (int, int)[]> adjList = new Dictionary<(int, int), (int,int)[]>();
        //Generate a new trinagle from the given size.
        public  void createTriangle()
        {
                int[][] newTriMap = new int[tSize+1][];
                //Generate the width of the graph.
                int width = 2 * tSize + 1;
                newTriMap[0] = new int[width];
                newTriMap[1] = new int[width];
                //initialize the values to 0.
                for (int i = 0; i < width; i++)
                {
                        newTriMap[0][i] = 0;
                        newTriMap[1][i] = 0;
                }
                //initialize the first row.
                newTriMap[1][tSize] = 1;
                //for each row: Create a row of zeros, iterate from the left index to the right, changing each value as needed.
                for (int i = 2; i < tSize + 1; i++)
                {
                        newTriMap[i] = new int[width];
                        for (int j = 0; j < width; j++)
                        {
                                newTriMap[i][j] = 0;
                        }
                        newTriMap[i][tSize - i +1] = 1;
                        for (int x = tSize - i + 1; x <= tSize + i; x++)
                        {
                                if (newTriMap[i][x - 1] != 1)
                                {
                                        newTriMap[i][x] = 1;
                                }
                        }
                }
                triMap = newTriMap;
        }
         public void displayTriangle(int[][] tirangle)
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
        public void initDictionary()
        {
                (int, int)[] blankArray = new (int, int)[8];
                (int, int)[] targetArray = new (int, int)[8];
                for (int i = 0; i < blankArray.Length - 1; i++)
                {
                        blankArray[i] = (0, 0);
                }
                for (int i = 0; i < triMap.Length; i++)
                {
                        for (int j = 0; j < triMap[i].Length; j++)
                        {
                                if (triMap[i][j] == 1)
                                {
                                        blankArray.CopyTo(targetArray, 0);
                                        adjList.Add((i, j), targetArray);
                                 }    
                        }
                }
         }
        public void mapTriangle()
        {
                initDictionary();
                int width = 2 * tSize + 1;
                // int[,] newTriMap = new int[tSize + 1, width];
                //max of 8 adjacent elements
                // (int, int)[] currElement = new (int, int)[8];
                (int, int)[] keys = adjList.Keys.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {
                        (int, int) curr = keys[i];
                        (int, int)[] currArr = adjList[curr];
                        (int, int)[] nextArr = new (int, int)[(int)currArr.Length];
                        (int, int) next = (curr.Item1 + 1, curr.Item2 - 1);
                        if (keys.Contains(next))
                        {
                                nextArr = adjList[next];
                                currArr[0] = (next);
                                nextArr[1] = curr;
                                adjList[curr] = currArr;
                                adjList[next] = nextArr;
                                Console.WriteLine("Curr and Next");
                                Console.WriteLine(curr);
                                Console.WriteLine(next);

                        }
                        
                 }






                // for (int i = 1; i < triMap.Length; i++)
                // {
                //         for (int j = 0; j < triMap[i].Length; j++)
                //         {
                //                 if (triMap[i][j] == 1)
                //                 {
                //                         if (i < triMap.Length - 1)
                //                         {
                //                                 if (triMap[i + 1][j] == 1)
                //                                 {
                //                                         currElement[0] = (i + 1, j);
                //                                 }
                //                         }
                //                         adjList.Add((i, j), currElement);
                //                 }

                //         }
                // }
        }
         public Boolean checkSolution(int[][] triangle)
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
        public (int, int) move((int, int) v1, (int, int) v2)
        {
                (int, int) direction = (v2.Item1 - v1.Item1, v2.Item2 - v1.Item2);
                return (v2.Item1 + direction.Item1, v2.Item2 + direction.Item2);

        }
}
