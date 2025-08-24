public class ProgramStart
{
        public static void Main(string[] args)
        {
                Program program = new Program();
                // Node node = new Node(true);
                // //Triangel Creation testing
                // Console.WriteLine("Testing Program Creation: " + TestTriangleCreation(program));
                // //Solution testing
                // Console.WriteLine("Testing checking solution " + TestSolutionTesting(program));
                // //Getting the next point testing
                // Console.WriteLine("Testing getting the next point: " + TestGetThirdPoint(program));
                // //Dictionary testing
                // Console.WriteLine("Testing Dictionary Creation: " + TestDictionaryCreation(program));
                // //Node Creation testing
                // Console.WriteLine("Testing Node Creation: " + TestNodeCreation(node));
                // //Move Creation testing
                // Console.WriteLine("Move Creation testing: " + TestMoveCreation(program));
                //BFS testing
                Console.WriteLine("BFS testing " + TestBfs(program));
                

        }
        static bool TestTriangleCreation(Program program)
        {
                program.createTriangle();
                int[][] triangle = program.triMap;
                return triangle[1].SequenceEqual(new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 }) && triangle[2].SequenceEqual(new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 0 });
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
        static bool TestNodeCreation(Node node)
        {
                int[][] newState = [[0, 0, 0]];
                node.setState(newState);
                Node[] nodes = { new Node(false) };
                node.setChildern(nodes);
                if (node.getState() == newState && node.getChildern() == nodes)
                {
                        return true;
                }

                return false;
        }
        static bool TestMoveCreation(Program program)
        {
                Move desiredMove = new Move(((4, 1), (3, 2), (2, 3)));
                int[][] currState = program.triMap;
                Node node = new Node();
                node.setState(currState);
                Move[] moves = program.GetMoves(node);
                foreach (var move in moves)
                {
                        if (move.Equals(desiredMove))
                        {
                                return true;
                        }
                }
                return false;
        }
        static bool TestBfs(Program program)
        {
                program.init();
                // foreach (var i in program.path)
                // {
                //         Console.WriteLine(i);
                //  }
                return program.path.Count >= 9 ? true : false;
        }
 }
