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
}
