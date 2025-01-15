using System;
using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private int _index;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public IMappable CurrentCreature => Creatures[_index % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName { get
        {
            var directions = DirectionParser.Parse(Moves);

            if (directions.Length > _index)
                return directions[_index].ToString().ToLower();

            return "";
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> creatures, List<Point> positions, string moves)
    {
        Map = map;

        if (creatures.Count == 0)
            throw new ArgumentException("At least one creature is required");
        else if (creatures.Count != positions.Count)
            throw new ArgumentException("Something went wrong. Positions out of sync???");

        Creatures = creatures;
        Positions = positions;
        Moves = DirectionParser.ParseStr(moves);

        _index = 0;

        for (int i = 0; i < Creatures.Count; i++)
            Creatures[i].Initialize(map, Positions[i], true);
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        CurrentCreature.Go(DirectionParser.Parse(Moves)[_index++]);

        if (_index == DirectionParser.Parse(Moves).Count())
            Finished = true;
    }
}
