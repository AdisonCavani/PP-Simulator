
using System.Text;
using SimConsole;
using Simulator;
using Simulator.Maps;

Console.OutputEncoding = Encoding.UTF8;

SmallTorusMap map = new(8, 6);
List<IMappable> creatures = [
    new Orc("Gorbag"),
    new Elf("Elandor"),
    new Animals() {Description = "Rabbits", Size = 5},
    new Birds() {Description = "Eagles", Size = 15, CanFly = true},
    new Birds() {Description = "Ostriches", Size = 75, CanFly = false}
];
List<Point> points = [new(2, 2), new(3, 1), new(4, 2), new(5, 0), new(7, 3)];
var moves = "dlrludlrdudrduu";

Simulation simulation = new(map, creatures, points, moves);
MapVisualizer mapVisualizer = new(simulation.Map);

mapVisualizer.Draw();

while (!simulation.Finished)
{
    Console.WriteLine(new string(Box.Horizontal, 30));

    Console.WriteLine($"{simulation.CurrentCreature} - {simulation.CurrentMoveName}:");
    simulation.Turn();
    mapVisualizer.Draw();
    
    Console.ReadKey();
}