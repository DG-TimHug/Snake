namespace Snake;

public class Snake
{
    public (int horizontal, int vertical) SnakeHead { get; set; } = (10, 5);
    public List<(int horizontal, int vertical)> SnakeBody { get; set; } = new();
    public (int horizontal, int vertical)? RemovedTail { get; set; }
}