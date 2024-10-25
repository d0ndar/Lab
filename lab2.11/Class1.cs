using System;

namespace GTFO;
public class Field
{
    protected bool field1;
    protected bool field2;


    public Field(bool field1, bool field2)
    {
        this.field1 = field1;
        this.field2 = field2;
    }


    public Field(Field other)
    {
        this.field1 = other.field1;
        this.field2 = other.field2;
    }


    public bool Implication()
    {
        return (!field1 || field2) ;
    }

    public override string ToString()
    {
        return $"Значение 1: {field1}, Значение 2: {field2}";
    }
}


