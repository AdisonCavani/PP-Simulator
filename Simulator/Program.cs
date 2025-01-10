using Simulator;

Console.WriteLine("Starting Simulator!\n");

Lab5a();

static void Lab5a()
{
    try
    {
        var rect1 = new Rectangle(10, 20, 5, 15);
        Console.WriteLine($"Rectangle 1: {rect1}");

        var point11 = new Point(3, 7);
        var point12 = new Point(8, 2);
        var rect2 = new Rectangle(point11, point12);
        Console.WriteLine($"Rectangle 2: {rect2}");

        var flatRect = new Rectangle(5, 5, 10, 5);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }

    var rect3 = new Rectangle(2, 3, 7, 8);
    var point31 = new Point(4, 5);
    var point32 = new Point(1, 1);

    Console.WriteLine($"Rectangle: {rect3}");
    Console.WriteLine($"Rectangle contains point {point31}: {rect3.Contains(point31)}");
    Console.WriteLine($"Rectangle contains point {point32}: {rect3.Contains(point32)}");
}