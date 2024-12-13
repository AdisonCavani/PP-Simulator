namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level;

    public abstract int Power { get; }
    public abstract string Info { get; }

    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
        
    }

    public abstract void SayHi();

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public void Go(Direction direction) => Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");

    public void Go(Direction[] directions) => Array.ForEach(directions, Go);

    public void Go(string input)
    {
        Go(DirectionParser.Parse(input));
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }
}
