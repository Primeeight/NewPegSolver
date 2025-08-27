//Node class
using Microsoft.VisualBasic;

public class Node(Boolean visited = false)
{
    //upon initialization of node, the set state method should be used to perform the move. 
    // int[,] state
    int[][]? state;
    //node parent
    Node parent;
    //node[] childern
    Node[]? childern;
    //public Node(Boolean visited = false, int[,] state);
    Move move;

    //Method set state
    public void setState(int[][] newState)
    {
        state = newState;
    }
    public int[][] getState()
    {
        return state;
    }
    public int[][] getStateDP()
    {
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
        return childern;
    }
    public Move getMove()
    {
        return move;
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