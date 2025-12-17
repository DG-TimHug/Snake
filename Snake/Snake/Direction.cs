namespace Snake;

public record Direction(int Horizontal, int Vertical)
{
    public static Direction Up => new Direction(0, -1);
    public static Direction Down => new Direction(0, 1);
    public static Direction Left => new Direction(-1, 0);
    public static Direction Right => new Direction(1, 0);
}
