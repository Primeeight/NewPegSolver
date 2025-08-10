using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

public partial class Program
{
        //size of the triangle, default is 4.
        public int tSize = 4;
        //state representation of the triangle, default is empty table.
        public int[][] stateMap = [[]];

        public int[][] triMap = [[]];
        public Dictionary<(int, int), (int, int)[]> adjList = new Dictionary<(int, int), (int, int)[]>();
        //Generate a new trinagle from the given size.
        public void createTriangle()
        {
                int[][] newTriMap = new int[tSize + 1][];
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
                        newTriMap[i][tSize - i + 1] = 1;
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
                                        blankArray = new (int, int)[8];
                                        for (int x = 0; x < blankArray.Length - 1; x++)
                                        {
                                                blankArray[x] = (0, 0);
                                        }
                                        adjList.Add((i, j), blankArray);
                                }
                        }
                }
        }
        public void mapTriangle()
        {
                initDictionary();
                //max of 8 adjacent elements
                (int, int)[] keys = adjList.Keys.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {

                        (int, int) curr = keys[i];
                        //obtain the current key's value list.
                        (int, int)[] currArr = adjList[curr];
                        //initialize an array to hold the next key's array.
                        (int, int)[] nextArr = new (int, int)[(int)currArr.Length];
                        //search each surronding key next to the current key, starting with the left-diagonal.
                        // (int, int) next = (curr.Item1 + 1, curr.Item2 - 1);
                        (int, int)[] adjacentSpots = new (int, int)[4];
                        int arrIndex = -1;
                        adjacentSpots[0] = (curr.Item1 + 1, curr.Item2 - 1);
                        adjacentSpots[1] = (curr.Item1 + 1, curr.Item2);
                        adjacentSpots[2] = (curr.Item1 + 1, curr.Item2 + 1);
                        adjacentSpots[3] = (curr.Item1, curr.Item2 + 2);

                        foreach ((int, int) next in adjacentSpots)
                        {
                                if (keys.Contains(next))
                                {
                                        nextArr = adjList[next];
                                        //left diagonal
                                        arrIndex++;
                                        currArr[arrIndex] = next;
                                        //add the current key to the next key's corrosponding values.
                                        //top right diagonal
                                        arrIndex++;
                                        nextArr[arrIndex] = curr;
                                        adjList[next] = nextArr;

                                }
                        }
                        adjList[curr] = currArr;

                }
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
        public (int, int) getThirdPoint((int, int) v1, (int, int) v2)
        {
                (int, int) direction = (v2.Item1 - v1.Item1, v2.Item2 - v1.Item2);
                return (v2.Item1 + direction.Item1, v2.Item2 + direction.Item2);
        }
        public void move(int[][] state, (int, int) pos1, (int, int) pos2)
        {
                (int, int) pos3 = getThirdPoint(pos1, pos2);
                (int, int)[] positions = { pos1, pos2, pos3 };
                foreach (var pos in positions)
                {
                        state[pos.Item1][pos.Item2] = ~state[pos.Item1][pos.Item2];
                 }
         }
}
