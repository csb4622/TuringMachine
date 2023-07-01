using System.Collections.Generic;

namespace TuringMachine.Programs;

public interface IProgram
{
    string StartState { get; }
    int StartPosition { get; }
    IEnumerable<Rule> Rules { get; }
}