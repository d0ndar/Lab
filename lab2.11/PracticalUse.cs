using System;
namespace GTFO;
public class IDK : Field
{
    private int width, height;
    //проверка что из России и какой гендер
    public IDK(bool x, bool y, int width, int height) : base(x, y)
    {
        this.width = width;
        this.height = height;
    }
    public int Area()
    {
        return width * height;
    }
    public (int x, int y) GetBottomLeftCorner()
    {
        return (Convert.ToInt32(field1), Convert.ToInt32(field2));
    }
    public override string ToString()
    {
        return base.ToString() + $", Ширина: {width}, Высота: {height}";
    }
}