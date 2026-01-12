public struct BulletVector
{
    public int X { get; set; }
    public int Y { get; set; }

    public BulletVector(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public static BulletVector Up => new BulletVector(0, -4);
    public static BulletVector Down => new BulletVector(0, 4);
    public static BulletVector Left => new BulletVector(-4, 0);
    public static BulletVector Right => new BulletVector(4, 0);
    
    public static BulletVector operator +(BulletVector a, BulletVector b)
        => new BulletVector(a.X + b.X, a.Y + b.Y);
}