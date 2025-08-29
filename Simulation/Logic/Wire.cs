using System.Collections.Generic;

namespace Simulation.Logic;

public class Wire
{
    public readonly int id;
    
    public readonly List<Pin> sourcePins;
    public readonly List<Pin> destPins;

    public State state = State.off;

    public void AddSourcePin(Pin pin)
    {
        sourcePins.Add(pin);
        pin.ConnectWire(this);
    }

    public void AddDestPin(Pin pin)
    {
        destPins.Add(pin);
        pin.ConnectWire(this);
    }

    public Wire(int id, Pin source, Pin dest)
    {
        this.id = id;
        this.sourcePins.Add(source);
        this.destPins.Add(dest);

        ConnectToPins();
    }

    public Wire(int id, Pin[] sourcePins, Pin[] destPins)
    {
        this.id = id;
        this.sourcePins = new List<Pin>(sourcePins);
        this.destPins = new List<Pin>(destPins);

        ConnectToPins();
    }

    private void ConnectToPins()
    {
        foreach (Pin pin in sourcePins)
            pin.ConnectWire(this);
        
         foreach (Pin pin in destPins)
            pin.ConnectWire(this);
    }

    public void UpdateState(State state) => this.state = state;

    public void PropagateSignal()
    {
        foreach (Pin pin in destPins)
            pin.SetState(this.state);
    } 
}
