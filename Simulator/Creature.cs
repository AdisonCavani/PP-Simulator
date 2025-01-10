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

    public abstract string Greeting();

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public string Go(Direction direction) => $"{Name} goes {direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        var arr = new string[directions.Length];

        for (int i = 0; i < directions.Length; i++)
        {
            arr[i] = Go(directions[i]);
        }

        return arr;
    }

    public string[] Go(string input)
    {
        return Go(DirectionParser.Parse(input));
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Name} [{Level}]{Info}";
    }
}
