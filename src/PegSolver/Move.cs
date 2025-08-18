using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

public class Move(((int, int), (int, int), (int, int)) representation)
{
    ((int, int), (int, int), (int, int)) rep = representation;

    public (int, int) GetItem(int i)
    {
        switch (i)
        {
            case 1: return (rep.Item1);
            case 2: return (rep.Item2);
            case 3: return (rep.Item3);
            default: return (-1, -1);
        }
    }
    public ((int, int), (int, int), (int, int)) GetRep()
    {
        return representation;
    }
    public void setRep(((int, int), (int, int), (int, int)) newRep)
    {
        rep = newRep;
    }
    public override bool Equals(object other)
    {
        if (other == null)
        return false;
        
        Move otherMove = other as Move;
        return rep.Item1 == otherMove.GetItem(1) && rep.Item2 == otherMove.GetItem(2) && rep.Item3 == otherMove.GetItem(3);
    }
}