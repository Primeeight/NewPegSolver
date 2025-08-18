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


    //Method set state
    public void setState(int[][] newState)
    {
        state = newState;
    }
    public int[][] getState()
    {
        return state;
    }
    public void setChildern(Node[] newChildern)
    {
        childern = newChildern;
    }
    public Node[] getChildern()
    {
        return childern;
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