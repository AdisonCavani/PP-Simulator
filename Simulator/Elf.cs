namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _agilityMultiplier = 3;
    private int _count = 0;

    public override int Power
    {
        get => 8 * Level + 2 * Agility;
    }

    public override string Info
    {
        get => $"[{Agility}]";
    }

    public int Agility
    {
        get => _agility;
        init => _agility = Validator.Limiter(value, 0, 10);
    }

    public Elf() : base("Unknown Elf", 1)
    {

    }


    public Elf(string name, int level = 1, int agility = 0) : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }

    public void Sing()
    {
        _count++;

        if (_count % _agilityMultiplier == 0 && Agility < 10)
        {
            _agility++;
            Console.WriteLine($"{Name} is singing. You gained +1 in agility. Your agility is now {Agility}.");
            _count = 0;
        }
        else if ((_count % _agilityMultiplier == 0 && Agility >= 10) || Agility >= 10)
        {
            Console.WriteLine($"{Name} is singing. You reached max agility.");
            _count = 0;
        }

        else
            Console.WriteLine($"{Name} is singing. Sing {_agilityMultiplier - _count} more time(s) to +1 in agility.");
    }
}
