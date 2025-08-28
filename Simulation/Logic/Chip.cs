using System.Collections.Generic;

using System;

namespace Simulation.Logic;

public class Chip 
{
    public readonly int id;
    public readonly bool isBuiltIn;

    public readonly string name;
    public readonly string description;

    public List<Chip> subChips;
    public Wire[] wires;
    
    public List<Pin> inputPins;
    public List<Pin> outputPins;

    public Chip()
    {
        this.id = -1;
    }

    public Chip(string name, string description, int id, List<Wire> wires, List<Chip> subChips)
    {
        this.name = name;
        this.description = description;
        this.id = id;
        this.wires = wires;
        this.subChips = subChips;
    }
}
