namespace Simulator;

public class Creature
{
    private string _name = "Unknown";
    private int _level;

    public string Name
    {
        get => _name;
        init
        {
            var name = value.Trim();

            if (string.IsNullOrEmpty(name))
                return;

            if (name.Length > 25)
                name = name.Substring(25).TrimEnd();

            if (name.Length < 3)
                name = name.PadRight(3, '#');

            if (char.IsLower(name[0]))
                name = char.ToUpper(name[0]) + name.Substring(1);

            _name = name;
        }
    }

    public int Level
    {
        get => _level;
        init => _level = Math.Clamp(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
        
    }

    public void SayHi() => Console.WriteLine($"Hi, I am {Name}, my level is {Level}");

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public string Info
    {
        get => $"{Name} [{Level}]";
    }
}
