using Simulation.Logic;

namespace Simulation.Components.Gates;

public class NotGate : Gate
{
    private static string gateName = "NOT";
    private static string gateDesc = "Outputs [HIGH] if the input is [LOW]";

    private static Pin[] inputs = 
    {
        new Pin(0,false,null),
    };
    

    public NotGate() :base(gateName, gateDesc, 0)
    {
        base.inputPins = inputs; 
    }

    public override State Evaluate()
    {
        if(inputPins[0].state == State.off)
            return State.off;

        if(inputPins[0].state == State.high)
            return State.low;

        return State.high;
    }
}
