using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    public int Counter { get; private set; }

    public Simulation Simulation = new(
        new SmallTorusMap(8, 6),
        [
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals() {Description = "Rabbits", Size = 5},
            new Birds() {Description = "Eagles", Size = 15, CanFly = true},
            new Birds() {Description = "Ostriches", Size = 75, CanFly = false}
        ],
        [new(2, 2), new(3, 1), new(4, 2), new(5, 0), new(7, 3)],
        "dlrludlrdudrduu"
    );

    public void OnGet()
    {
        Counter = Math.Clamp(HttpContext.Session.GetInt32("Counter") ?? 1, 1, Simulation.Moves.Length);
        RunSimulation();
    }

    public void OnPost()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 1;

        if (Request.Form["type"] == "increment")
            Counter++;
        else if (Counter > 1)
            Counter--;

        Counter = Math.Clamp(Counter, 1, Simulation.Moves.Length);

        HttpContext.Session.SetInt32("Counter", Counter);
        RunSimulation();
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
