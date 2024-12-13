namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _rageMultiplier = 2;
    private int _count = 0;

    public override int Power
    {
        get => 7 * Level + 3 * Rage;
    }

    public int Rage
    {
        get => _rage;
        init => _rage = Validator.Limiter(value, 0, 10);
    }

    public override string Info
    {
        get => $"[{Rage}]";
    }

    public Orc() : base("Unknown Orc", 1)
    {

    }

    public Orc(string name, int level = 1, int rage = 0) : base(name, level)
    {
        Rage = rage;
    }


    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }

    public void Hunt()
    {
        _count++;

        if (_count % _rageMultiplier == 0 && Rage < 10)
        {
            _rage++;
            Console.WriteLine($"{Name} is hunting. You gained +1 in rage. Your rage is now {Rage}.");
            _count = 0;
        }

        else if ((_count % _rageMultiplier == 0 && Rage >= 10) || Rage >= 10)
        {
            Console.WriteLine($"{Name} is hunting. You reached max rage.");
            _count = 0;
        }

        else
            Console.WriteLine($"{Name} is hunting. Hunt {_rageMultiplier - _count} more time(s) to +1 in rage.");
    }
}
