using Simulation.Logic;

namespace Simulation.Gates;

public class NotGate : Gate
{
    public static readonly string gateName = "NOT";
    public static readonly string gateDesc = "Outputs [HIGH] if the input is [LOW]";

    public static Pin[] inputs = 
    {
        new Pin(0,false,null),
    };
    

    public NotGate() :base(gateName, gateDesc, 0, inputs) { }

    public override State Evaluate()
    {
        if(inputPins[0].state == State.off)
            return State.off;

        if(inputPins[0].state == State.high)
            return State.low;

        return State.high;
    }
}
