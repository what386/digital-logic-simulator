using System.Collections.Generic;

namespace Simulation.Logic;

public class Wire
{
    public readonly int id;
    
    public readonly List<Pin> sourcePins;
    public readonly List<Pin> destPins;

    public readonly State wireState = State.off;

    public void AddSourcePin(Pin pin) => sourcePins.Add(pin);
    public void AddDestPin(Pin pin) => sourcePins.Add(pin);

    public Wire(int id, List<Pin> sourcePins, List<Pin> destPins)
    {
        this.id = id;
        this.sourcePins = sourcePins;
        this.destPins = destPins;

        ConnectToPins();
    }

    private void ConnectToPins()
    {
        foreach (Pin pin in sourcePins)
            pin.ConnectWire(this);
        
         foreach (Pin pin in destPins)
            pin.ConnectWire(this);
    }

    public void PropagateSignal(State state)
    {
        foreach (Pin pin in destPins)
            pin.SetState(state);
    } 
}
