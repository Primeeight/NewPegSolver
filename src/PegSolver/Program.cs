using System;

public class Program
{
        //size of the triangle, default is 4.
        static int tSize = 4;
        //state representation of the triangle, default is empty table.
        static int[][] stateMap = [[]];

        static int[][] triMap = [[]];
        //Generate a new trinagle from the given size.
        public static void createTriangle()
        {
                int[][] newStateMap = new int[tSize][];
                newStateMap[0] = new int[] { 0 };
                int width = 2 * tSize + 1;
                int[][] newTriMap = new int[tSize+1][];
                // for (int i = 0; i < width; i++)
                // {
                //         newStateMap[0][i] = 0;
                // }
                newTriMap[1] = newStateMap[0];
                // newStateMap[1][0] = 1;


                for (int i = 1; i < tSize; i++)
                {
                        
                        newStateMap[i] = new int[i + 1];
                        for (int j = 0; j < newStateMap[i].Length; j++)
                        {
                                newStateMap[i][j] = 1;
                        }
                }
                stateMap = newStateMap;
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
        static public void mapTriangle(int[][] triangle)
        {
                for (int i = 0; i < triangle.Length; i++)
                {
                        for (int j = 0; j < triangle[i].Length; j++)
                        {
                                (int, int) curr = (i, j);
                                

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
                displayTriangle(stateMap);
                Console.WriteLine(checkSolution(stateMap));
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