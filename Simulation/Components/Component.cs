using Simulation.Logic;

namespace Simulation.Components;

public abstract class Component: Chip
{
    public string data { get; private set; }

    public Component(string name, string description, int id, Pin[] inputs) :base(name,description,id,null,null)
    {
        base.inputPins = inputs;
        base.outputPins = null;
    }

    public void ConnectWire(Wire wire, Pin pin) => pin.ConnectWire(wire);

    public void SetInternalData(string data) => this.data = data;

    public abstract void Update();
}
