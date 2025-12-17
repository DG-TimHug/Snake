namespace Snake;

public class Snake
{
    public (int horizontal, int vertical) SnakeHead { get; set; } = (10, 5);
    public List<(int horizontal, int vertical)> SnakeBody { get; set; } = new();
    public (int horizontal, int vertical)? RemovedTail { get; set; }

    public void LengthSetter(int initialLength)
    {
        SnakeBody.Clear();
        // Add segments to the left of the head
        for (int i = 1; i < initialLength; i++)
        {
            SnakeBody.Add((SnakeHead.horizontal - i, SnakeHead.vertical));
        }
    }
}