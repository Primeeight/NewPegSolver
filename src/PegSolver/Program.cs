using System;

public class Program
{
        //size of the triangle, default is 4.
        static int tSize = 4;
        //state representation of the triangle, default is empty table.
        static int[][] stateMap = [[]];

        static int[][] triMap = [[]];
        static int[][] adjMap = [[]];
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
            int[][] newTriMap = [[]];
            for (int i = 0; i < triMap.Length; i++)
            {
            if ( )
            {

             }
                for (int j = 0; j < triMap[i].Length; j++)
            {


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
                return (v2.Item1 + direction.Item1, v2.Item2+direction.Item2);       
                
        }
        public static void Main(string[] args)
        {
                createTriangle();
                displayTriangle(triMap);
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
        

        //     static int[][] representation =
        //             [
        //             [0],
        //             [1, 1],
        //             [1, 1, 1],
        //             [1, 1, 1, 1]
        //             ];
        //     static int[][] rep =
        //             [
        //             //0 [1, 2],
        //             //1 [0, 2, 3, 4],
        //             //2 [0, 1, 4, 5],
        //             //3 [1, 4, 6, 7],
        //             //4 [0, 1, 2, 7, 8],
        //             //5 [2, 4, 8, 9],
        //             //6 [3, 7],
        //             //7 [3, 4, 6, 8],
        //             //8 [4, 5, 7, 9],
        //             //9 [5, 8] 
        //             ];

}