//Node class
using Microsoft.VisualBasic;

public class Node()
{
    //upon initialization of node, the set state method should be used to perform the move. 
    // int[,] state
    int[][]? state;
    //node parent
    Node? parent;
    //node[] childern
    Node[]? childern;
    //public Node(Boolean visited = false, int[,] state);
    Move? move;

    //Method set state
    public void setState(int[][] newState)
    {
        state = newState;
    }
    public int[][] getState()
    {

        return state == null? new int[0][]: state;
    }
    public int[][] getStateDP()
    {
        if (state == null)
        return new int[0][];

        int[][] target = new int[state.Length][];
        for (int i = 0; i < state.Length; i++)
        {
            target[i] = new int[state[i].Length];
            Array.Copy(state[i], target[i], state[i].Length);
        }
         return target;
     }
    public void setChildern(Node[] newChildern)
    {
        childern = newChildern;
    }
    public Node[] getChildern()
    {
        return childern == null? new Node[0]: childern;
    }
    public Move getMove()
    {
        return move == null? new Move(((-1, -1), (-1, -1), (-1, -1))) : move ;
     }
    public void setMove(Move move)
    {
        this.move = move;   
     }
    public Node getParent()
    {
        return parent;
    }
    public void setParent(Node parent)
    {
        this.parent = parent;
     }
} 