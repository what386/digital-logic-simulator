using Simulation.Logic;

namespace Simulation.Gates;

public class XorGate : Gate
{
    private static string gateName = "XOR";
    private static string gateDesc = "Outputs [HIGH] if inputs are different, otherwise outputs [LOW]";

    private static Pin[] inputs = 
    {
        new Pin(0,false,null),
        new Pin(1,false,null)
    };
    

    public XorGate() :base(gateName, gateDesc, 0, inputs)
    {
    }

    public override State Evaluate()
    {
        if(inputPins[0].state == State.off || inputPins[1].state == State.off)
            return State.off;

        if(inputPins[0].state != inputPins[1].state)
            return State.high;

        return State.low;
    }
}
