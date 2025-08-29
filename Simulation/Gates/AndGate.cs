using Simulation.Logic;

namespace Simulation.Gates;

public class AndGate : Gate
{
    private static string gateName = "AND";
    private static string gateDesc = "Outputs [HIGH] if both inputPins are [HIGH], otherwise outputs [LOW]";

    private static Pin[] inputs = 
    {
        new Pin(0,false,null),
        new Pin(1,false,null)
    };
    

    public AndGate() :base(gateName, gateDesc, 0, inputs)
    {
    }

    public override State Evaluate()
    {
        if(inputPins[0].state == State.off || inputPins[1].state == State.off)
            return State.off;

        if(inputPins[0].state == State.high && inputPins[1].state == State.high)
            return State.high;

        return State.low;
    }
}
