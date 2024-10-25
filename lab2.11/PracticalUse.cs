using System;
namespace GTFO;
public class IDK : Field
{
    private string location1,location2;
    public IDK(bool x, bool y,  string location1,  string location2) : base(x, y)
    {
        this.location1 = location1;
        this.location2 = location2;
    }
    public string  FindClosedDores()
    {
        if (!field1) return (location1);
        if (!field2) return (location2);
        else return ("Нет такой двери двери");
    }

    public bool CloseTheDoor(string location)
    {
        if (location == location1) return field1 = false;
        if (location == location2) return field2 = false;
        else
        {
            Console.WriteLine("нет такой двери!");
            return false;
        }
        
    }

    public override string ToString()
    {
        return base.ToString() + $", Название: {location1}, локация 2: {location2}";
    }
}