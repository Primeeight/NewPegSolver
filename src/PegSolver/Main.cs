public class ProgramStart
{
        public static void Main(string[] args)
        {
                Program program = new Program();
                //Triangel Creation testing
                Console.WriteLine("Testing Program Creation: " + TestTriangleCreation(program));
                //Solution testing
                Console.WriteLine("Testing checking solution " + TestSolutionTesting(program));
                //Getting the next point testing
                Console.WriteLine("Testing getting the next point: " + TestGetThirdPoint(program));
                //Dictionary testing
                Console.WriteLine("Testing Dictionary Creation: " + TestDictionaryCreation(program));

        }
        static bool TestTriangleCreation(Program program)
        {
                program.createTriangle();
                int[][] triangle = program.triMap;
                if (triangle[1] == new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 } && triangle[2] == new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 0 })
                {
                        return true;
                }
                return false;

        }

        static bool TestSolutionTesting(Program program)
        {
                program.mapTriangle();
                return program.checkSolution(program.triMap) == false;
        }

        static bool TestDictionaryCreation(Program program)
        {
                (int, int)[] keys = program.adjList.Keys.ToArray();
                (int, int)[] values1 = program.adjList[keys[6]];
                (int, int)[][] values = program.adjList.Values.ToArray();
                if (keys[6] == ((4, 1)) && values1.Contains((4, 3)) && values1.Contains((3, 2)))
                {
                        return true;
                }
                return false;
        }
        static bool TestGetThirdPoint(Program program)
        {
                if (program.getThirdPoint((2, 2), (1, 1)) == (0, 0))
                {
                        return true;
                }
                return false;
         }
 }
