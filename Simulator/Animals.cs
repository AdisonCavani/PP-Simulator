﻿namespace Simulator;

public class Animals
{
    private string _description = "Unknown";
    public required string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;
    public virtual string Info { get; }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Description} {Info}<{Size}>";
}

