using System.Collections.Generic;
using System.Linq;

namespace Simulation.Logic;

public class Bus
{
    public readonly int id;
    
    public readonly List<Port> sourcePorts;
    public readonly List<Port> destPorts;

    public State[] data { get; private set; } 

    public void AddSourcePort(Port port)
    {
        sourcePorts.Add(port);
        port.ConnectBus(this);
    }

    public void AddDestPort(Port port)
    {
        destPorts.Add(port);
        port.ConnectBus(this);
    }

    public Bus(int id, Port source, Port dest, int size)
    {
        this.id = id;
        this.sourcePorts.Add(source);
        this.destPorts.Add(dest);
        data = Enumerable.Repeat(State.off, size).ToArray(); 

        ConnectToBuses();
    }

    public Bus(int id, Port[] sourcePorts, Port[] destPorts, int size)
    {
        this.id = id;
        this.sourcePorts = new List<Port>(sourcePorts);
        this.destPorts = new List<Port>(destPorts);
        data = Enumerable.Repeat(State.off, size).ToArray(); 

        ConnectToBuses();
    }

    private void ConnectToBuses()
    {
        foreach (Port port in sourcePorts)
            port.ConnectBus(this);

        foreach (Port port in destPorts)
            port.ConnectBus(this);
    }

    public void SetData(State[] data) => this.data = data;

    public void SetDataIndex(State state, int index) => this.data[index] = state;

    public void PropagateData()
    {
        foreach (Port port in destPorts)
            port.SetData(this.data);
    } 
}
