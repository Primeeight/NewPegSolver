using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

public class Move(((int, int), (int, int), (int, int)) value)
{

    public (int, int) GetItem(int i)
    {
        switch (i)
        {
            case 1: return (value.Item1);
            case 2: return (value.Item2);
            case 3: return (value.Item3);
            default: return (-1, -1);
        }
    }
    public ((int, int), (int, int), (int, int)) GetRep()
    {
        return value;
    }
    public void setRep(((int, int), (int, int), (int, int)) newRep)
    {
        value = newRep;
    }
    public override bool Equals(object other)
    {
        if (other as Move == null)
            return false;
        
        Move otherMove = (Move)other;
        if (otherMove == null)
        return false;
        return value.Item1 == otherMove.GetItem(1) && value.Item2 == otherMove.GetItem(2) && value.Item3 == otherMove.GetItem(3);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}