public class ProgramStart
{
        public static void Main(string[] args)
        {
                Program program = new Program();
                program.createTriangle();

                program.displayTriangle(program.triMap);
                program.mapTriangle();
                Console.WriteLine(program.checkSolution(program.triMap));
                if (program.move((2, 2), (1, 1)) == (0, 0))
                {
                        Console.WriteLine("move from 2,2 to 1,1 is 0,0");
                }
                else
                {
                        Console.WriteLine("move failed");
                }

                //Dictionary testing
                Console.WriteLine("Dictionary testing");
                (int, int)[] keys = program.adjList.Keys.ToArray();
                (int, int)[][] values = program.adjList.Values.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {
                        Console.Write("Keys" + keys[i]);
                        Console.Write("Values");
                        for (int j = 0; j < values[i].Length; j++)
                        {
                                if (values[i][j] != (0, 0))
                                {
                                        Console.Write(values[i][j]);
                                }
                        }
                        Console.WriteLine("");
                }

    }
 }
