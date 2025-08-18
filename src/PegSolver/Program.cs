using System;
using System.Collections;
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
        public void initState()
        {
                stateMap = new int[triMap.Length][];
                Array.Copy(triMap, stateMap, triMap.Length);
                for (int i = 0; i < stateMap.Length; i++)
                {
                        for (int j = 0; j < stateMap[i].Length ; j++)
                        {
                                stateMap[i][j] = stateMap[i][j] == 0? -1 : 1;
                         }
                 }
                stateMap[2][3] = 0;
         }
        public void mapTriangle()
        {
                initDictionary();
                initState();
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


        public void init()
        {
                //create path queue
                // create bfs Queue
                //call bfs
                //call backtrace

        }
        //Recursive method to search for goal state
        public void bfs()
        {
                //base case
                //if !checksolution(bfsqueue[0])
                {
                        //node currNode = bfsQueuee.pop();
                        // currNode.childern = currNode.getChildern
                        //if currNode.childern:
                        //for i in currNode.childern:
                        //i.parent = currNode.child
                        //bfsQueue.append(i)
                        //next call
                        //bfsHelper()

                }
        }
        public Node[] getChildern(Node currNode)
        {
                //ArrayList of Childern
                //Node[] childern = new Node[](i)
                Move[]availMoves = GetMoves(currNode);
                Node[] childern = new Node[availMoves.Length];

                //end get moves.
                //foreach(availMove in availmoves)
                for (int i = 0; i < availMoves.Length; i++)
                {
                        //Node node = new Node();
                        childern[i] = new Node();
                        //Verifiy this does not share a multable array.
                        childern[i].setState(currNode.getState());
                        // node.setState =  move(node.state, availMove);
                        move(childern[i].getState(), availMoves[i].GetItem(1), availMoves[i].GetItem(2));
                                
                        //childern.append(node)
                }
                //end add childern
                return childern;
        }
        
        //move alot of functionality from git childern to GetMoves.
        public Move[] GetMoves(Node currNode)
        {
                var currState = currNode.getState();
                //may make this into a class
                //(tuple, tuple, tuple)[] availMoves = new (tuple, tuple, tuple)[](i)
                // Move[] availMoves = new Move[3];
                List <Move> availMoves = new List<Move>();
                (int, int)[] keyValues = adjList.Keys.ToArray();

                //for i in currNode.state
                for (int i = 0; i < currState.Length; i++)
                {
                        //for j in currNode.state[i]
                        for (int j = 0; j < currState[i].Length; j++)
                        {
                                //if currnode.state[i][j] == 0
                                if (currState[i][j] == 0)
                                {
                                        //foreach (pos in adjList(i, j))
                                        //make sure this reflects correct adjlist
                                        foreach ((int, int) pos in adjList[(i, j)])
                                        {
                                                //if currNode.state[pos.Item1][pos.Item2] == 1 && 
                                                // currNode.state[getThirdPoint((i, j), pos).Item1][getThirdPoint((i, j), pos).Item2] == 1
                                                var thirdPos = getThirdPoint((i, j), pos);
                                                if (currState[pos.Item1][pos.Item2] == 1 && currState[thirdPos.Item1][thirdPos.Item2] == 1)
                                                {
                                                        //availMoves.add((i, j), pos, getThirdPoint((i, j), pos));
                                                        availMoves.Add(new Move((getThirdPoint((i, j), pos), pos, (i, j))));

                                                }

                                        }
                                }
                        }


                }


                return availMoves.ToArray();
        }


}
