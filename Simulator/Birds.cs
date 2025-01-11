namespace Simulator;

public class Birds : Animals
{
    private bool _canFly = true;

    public bool CanFly
    {
        get => _canFly;
        init => _canFly = value;
    }

    public override string Info
    {
        get => CanFly == true ? "(fly+) " : "(fly-) ";
    }

    public override string Go(Direction direction)
    {
        if (Map is not null && !CanFly)
            Map.Move(this, Position, Map.NextDiagonal(Position, direction));
        else if (Map is not null)
        {
            Map.Move(this, Position, Map.Next(Position, direction));
            Map.Move(this, Position, Map.Next(Position, direction));
        }

        return direction.ToString().ToLower();
    }
}
