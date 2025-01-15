using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    public int Counter { get; private set; }

    [BindProperty]
    public string? Moves { get; set; }

    [BindProperty]
    public int MapWidth { get; set; } = 8;

    [BindProperty]
    public int MapHeight { get; set; } = 6;

    public Simulation Simulation { get; set; } = new(
        new SmallTorusMap(8, 6),
        [
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals() {Description = "Rabbits", Size = 5},
            new Birds() {Description = "Eagles", Size = 15, CanFly = true},
        ],
        [new(0, 0), new(0, 0), new(0, 0), new(0, 0)],
        ""
    );

    public void OnGet()
    {
        CreateSimulation();

        Counter = Math.Clamp(Counter, 0, Simulation.Moves.Length);

        RunSimulation();
    }

    public void OnPostSubmit()
    {
        HttpContext.Session.SetString("Moves", Moves ?? "");
        HttpContext.Session.SetInt32("MapWidth", Math.Clamp(MapWidth, 5, 20));
        HttpContext.Session.SetInt32("MapHeight", Math.Clamp(MapHeight, 5, 20));

        CreateSimulation();

        if (Simulation.Moves.Length > 0)
            Counter = 1;
        else
            Counter = 0;

        HttpContext.Session.SetInt32("Counter", Counter);

        RunSimulation();
    }

    public void OnPostDecrement()
    {
        CreateSimulation();

        Counter--;
        Counter = Math.Clamp(Counter, 0, Simulation.Moves.Length);

        HttpContext.Session.SetInt32("Counter", Counter);

        RunSimulation();
    }

    public void OnPostIncrement()
    {
        CreateSimulation();

        Counter++;
        Counter = Math.Clamp(Counter, 0, Simulation.Moves.Length);

        HttpContext.Session.SetInt32("Counter", Counter);

        RunSimulation();
    }

    private void CreateSimulation()
    {
        Moves = HttpContext.Session.GetString("Moves") ?? "";
        MapWidth = Math.Clamp(HttpContext.Session.GetInt32("MapWidth") ?? 8, 5, 20);
        MapHeight = Math.Clamp(HttpContext.Session.GetInt32("MapHeight") ?? 6, 5, 20);

        Simulation = new(
            new SmallTorusMap(MapWidth, MapHeight),
            [
                new Orc("Gorbag"),
                new Elf("Elandor"),
                new Animals() {Description = "Rabbits", Size = 5},
                new Birds() {Description = "Eagles", Size = 15, CanFly = true},
            ],
            [new(0, 0), new(0, 0), new(0, 0), new(0, 0)],
            Moves
        );

        if (Simulation.Moves.Length > 0)
            Counter = HttpContext.Session.GetInt32("Counter") ?? 1;
        else
            Counter = 0;
    }

    private void RunSimulation()
    {
        for (int i = 1; i < Counter; i++)
        {
            Simulation.Turn();
        }
    }

    public string? GetSymbol(List<IMappable>? creatures)
    {
        if (creatures is null || creatures.Count == 0)
            return null;

        if (creatures.Count > 1)
            return "~/img/combo-80.png";

        var creature = creatures.First();
        return creature switch
        {
            Orc => "~/img/ork-80.png",
            Elf => "~/img/elf-80.png",
            Birds => ((Birds)creature).CanFly ? "~/img/eagle-80.png" : "~/img/emu-80.png",
            _ => "~/img/rabbit-80.png",
        };
    }
}
