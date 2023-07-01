using System.Collections.Generic;

namespace TuringMachine;

public interface IProgram
{
    string StartState { get; }
    int StartPosition { get; }
    IEnumerable<Rule> Rules { get; }
}