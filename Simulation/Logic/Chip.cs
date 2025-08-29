namespace Simulation.Logic;

public class Chip 
{
    public readonly int id;
    public readonly bool isBuiltIn;

    public readonly string name;
    public readonly string description;

    public Chip[] subChips;
    public Wire[] wires;
    
    public Pin[] inputPins;
    public Pin[] outputPins;

    public Chip()
    {
        this.id = -1;
    }

    public Chip(string name, string description, int id, Wire[] wires, Chip[] subChips)
    {
        this.name = name;
        this.description = description;
        this.id = id;
        this.wires = wires;
        this.subChips = subChips;
    }
}
