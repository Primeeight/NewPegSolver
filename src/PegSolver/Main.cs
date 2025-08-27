public class ProgramStart
{
        public static void Main(string[] args)
        {
                Program program = new Program();
                program.createTriangle();
                program.mapTriangle();
                Node node = new Node(true);
                Program bfsProgram = new Program();
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
                // Testing move performance
                // Console.WriteLine("Testing move performance " + TestMove(program));
                // BFS testing
                Console.WriteLine("BFS testing " + TestBfs(bfsProgram));
                program = new Program();
                program.createTriangle();
                program.mapTriangle();
                // Console.WriteLine("Testing childern generation " + TestChildernGeneration(program));    


        }
        static bool TestTriangleCreation(Program program)
        {
                int[][] triangle = program.triMap;
                return triangle[1].SequenceEqual(new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 }) && triangle[2].SequenceEqual(new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 0 });
        }

        static bool TestSolutionTesting(Program program)
        {
                return program.checkSolution(program.stateMap) == false;
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
        static bool TestMove(Program program)
        {
                Move desiredMove = new Move(((4, 1), (3, 2), (2, 3)));
                int[][] currState = program.stateMap;
                Node node = new Node();
                node.setState(currState);
                var desiredMoveState = (1-currState[4][1], 1-currState[3][2], 1-currState[2][3]);
                program.move(node.getState(), desiredMove.GetItem(1), desiredMove.GetItem(2));
                currState = node.getState();
                
                if ((currState[4][1], currState[3][2], currState[2][3]) == desiredMoveState)
                {
                        return true;
                }
                return false;
        }
        static bool TestChildernGeneration(Program program)
        {
                int[][] currState = program.stateMap;
                Node node = new Node();
                node.setState(currState);
                //either get moves or get childern modifies the base state.
                Move[] moves = program.GetMoves(node);
                Node[] childern = program.getChildern(node);
                //doesn't get a valid move.
                var topMove = moves[0].GetRep();

                foreach (Node child in childern)
                {
                        int[][]newState = child.getState();
                        (int, int, int) moveResult =
                        (newState[topMove.Item1.Item1][topMove.Item1.Item2],
                        newState[topMove.Item2.Item1][topMove.Item2.Item2],
                        newState[topMove.Item3.Item1][topMove.Item3.Item2]);
                        Console.WriteLine(moveResult);
                        if (moveResult == (0, 0, 1))
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
                foreach (var move in program.movePath)
                {
                        Console.WriteLine(move.GetRep());
                 }
                return program.path.Count >= 9 ? true : false;
        }
        
 }
