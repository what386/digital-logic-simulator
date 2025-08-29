using Simulation.Logic;

namespace Simulation.Gates;

public class ImpliesGate : Gate
{
    private static string gateName = "IMP";
    private static string gateDesc = "Outputs [HIGH] if both input A and input B are [HIGH] or if input A is [LOW], otherwise outputs [LOW]";

    private static Pin[] inputs = 
    {
        new Pin(0,false,null),
        new Pin(1,false,null)
    };
    

    public ImpliesGate() :base(gateName, gateDesc, 0, inputs) { }

    public override State Evaluate()
    {
        if(inputPins[0].state == State.off || inputPins[1].state == State.off)
            return State.off;

        if(inputPins[0].state == State.high)
            return inputPins[1].state;

        return State.high;
    }
}
