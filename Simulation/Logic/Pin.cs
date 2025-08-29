using System.Collections.Generic;

namespace Simulation.Logic;

public class Pin 
{
    public readonly int ID;
    public readonly Chip parentChip;
    private List<Wire> connectedWires;

    public readonly bool isOutput;

    public State state = State.off;

    public Pin(int id, bool isOutput, Chip parentChip)
    {
        this.parentChip = parentChip;
        this.isOutput = isOutput;
        ID = id;
    }

    public void SetState(State state) => this.state = state;

    public void UpdateConnectedWires()
    {
        if(!isOutput || this.state == State.off) return;

        foreach(Wire wire in connectedWires)
                wire.UpdateState(this.state);
    }

    public void ConnectWire(Wire wire) => this.connectedWires.Add(wire);
    public void DisconnectWire(Wire wire) => this.connectedWires.Remove(wire);
}
