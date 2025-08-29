using System.Collections.Generic;
using System.Linq;

namespace Simulation.Logic;

public class Port 
{
    public readonly int ID;
    public readonly Chip parentChip;
    private List<Bus> connectedBuses;

    public readonly bool isOutput;

    public State[] data;

    public Port(int id, int size, bool isOutput, Chip parentChip)
    {
        this.data = new State[size];

        this.parentChip = parentChip;
        this.isOutput = isOutput;
        ID = id;
    }

    public void SetData(State[] data) => this.data = data;

    public void UpdateConnectedBuses()
    {
        if (!isOutput) return;

        foreach (var (state, index) in data.Select((s, i) => (s, i)))
        {
            if (state != State.off)
                foreach (var bus in connectedBuses)
                    bus.SetDataIndex(state, index);
        }
    }


    public void ConnectBus(Bus bus) => this.connectedBuses.Add(bus);
    public void DisconnectBus(Bus bus) => this.connectedBuses.Remove(bus);
}
