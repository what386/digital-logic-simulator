using Simulation.Logic;

namespace Simulation.Gates;

public abstract class Gate : Chip
{
    public Gate(string name, string description, int id, Pin[] inputs) :base(name,description,id,null,null)
    {
        base.inputPins = inputs;
        base.outputPins = [ new Pin(0,true,this) ];
    }

    public void ConnectWire(Wire wire, Pin pin) => pin.ConnectWire(wire);

    public abstract State Evaluate();
}
