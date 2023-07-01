using System.Collections.Generic;

namespace TuringMachine.Programs;

public class Inverter: IProgram
{
    public string StartState => "i";
    public int StartPosition => 0;

    public IEnumerable<Rule> Rules => new[]
    {
        new Rule("i", '0', '1', "i", Direction.Right),
        new Rule("i", '1', '0', "i", Direction.Right),
        new Rule("i", ' ', ' ', "HALT", Direction.None)
    };
}