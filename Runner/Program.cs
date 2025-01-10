using Simulator;
using Simulator.Maps;

Console.WriteLine("Starting Simulator!\n");

Lab5b();

static void Lab5b()
{
    try
    {
        var map = new SmallSquareMap(10);
        Console.WriteLine("Created map (size = 10)");

        var p1 = new Point(0, 0);
        var p2 = new Point(9, 9);
        var p3 = new Point(5, 5);

        Console.WriteLine($"Point {p1} exists: {map.Exists(p1)}");
        Console.WriteLine($"Point {p2} exists: {map.Exists(p2)}");
        Console.WriteLine($"Point {p3} exists: {map.Exists(p3)}");

        var p4 = new Point(10, 10);
        Console.WriteLine($"Point {p4} exists: {map.Exists(p4)}");

        var next1 = map.Next(p1, Direction.Right);
        Console.WriteLine($"Next point from {p1} to Right: {next1}");

        var next2 = map.Next(p2, Direction.Right);
        Console.WriteLine($"Next point from {p2} to Right: {next2}");

        var nextDiagonal1 = map.NextDiagonal(p1, Direction.Up);
        Console.WriteLine($"Next diagonal point from {p1} Up: {nextDiagonal1}");

        var nextDiagonal2 = map.NextDiagonal(p2, Direction.Right);
        Console.WriteLine($"Next diagonal point from {p2} Right: {nextDiagonal2}");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }
}