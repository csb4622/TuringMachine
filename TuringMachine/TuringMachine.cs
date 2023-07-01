using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuringMachine;

public class TuringMachine
{
    private readonly IProgram _program;
    private bool _ready;
    
    private List<char>? _tape;
    private string? _state;
    private int _position;


    public TuringMachine(IProgram program)
    {
        _program = program;
    }
    
    
    public void Reset(IEnumerable<char> tape)
    {
        _ready = true;
        _tape = tape.ToList();
        _state = _program.StartState;

        if (_program.StartPosition < 0)
        {
            for (var i = -1; i >= _program.StartPosition; --i)
            {
                _tape.Insert(0, ' ');
            }
            _position = 0;
        }
        else if(_program.StartPosition >= _tape.Count)
        {
            for (var i = 0; i < (_program.StartPosition - (_tape.Count - 1)); ++i)
            {
                _tape.Add(' ');
            }
            _position = _tape.Count - 1;
        }
        else
        {
            _position = _program.StartPosition;
        }
        
        _tape.Insert(0, ' ');
        ++_position;
        _tape.Add(' ');
    }


    public bool Step()
    {
        if (!_ready)
        {
            Console.WriteLine("No Tape in the machine, Call Reset to pass in a tape");
            return false;
        }
        var currentTapeSymbol = _tape![_position];;
        var foundRule = _program.Rules.FirstOrDefault(r => r.StateInput == _state && r.TapeInput == currentTapeSymbol);

        if (foundRule == null)
        {
            return false;
        }
        
        _state = foundRule.StateOutput;
        _tape[_position] = foundRule.TapeOutput;
        if (_position == 0)
        {
            _tape.Insert(0, ' ');
            ++_position;
        }
        else if (_position == _tape.Count-1)
        {
            _tape.Add(' ');
        }

        if (foundRule.Direction != Direction.None)
        {
            _position = foundRule.Direction == Direction.Left ? _position - 1 : _position + 1;
        }
        return true;
    }

    public bool Run(int? numberOfSteps = null)
    {
        if (!_ready)
        {
            Console.WriteLine("No Tape in the machine, Call Reset to pass in a tape");
            return false;
        }

        if (numberOfSteps.HasValue)
        {
            for (var i = 0; i < numberOfSteps; ++i)
            {
                if (!Step())
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            var done = false;
            while (!done)
            {
                done = !Step();
            }
            return false;
        }
    }

    public string DisplayTape()
    {
        if (!_ready)
        {
            return "No Tape Given.";
        }
        else
        {
            var builder = new StringBuilder();
            for (var i = 1; i < _tape!.Count - 1; ++i)
            {
                builder.Append(_tape[i]);
                builder.Append(' ');
            }

            builder.Append("STATE: ");
            builder.Append(_state);
            
            return builder.ToString();
        }
    }
}

public class Rule
{
    public string StateInput { get; }
    public char TapeInput { get; }
    public char TapeOutput { get; }
    public string StateOutput { get; }
    public Direction Direction { get; }

    public Rule(string stateInput, char tapeInput, char tapeOutput, string stateOutput, Direction direction)
    {
        StateInput = stateInput;
        TapeInput = tapeInput;
        TapeOutput = tapeOutput;
        StateOutput = stateOutput;
        Direction = direction;
    }
}

public enum Direction
{
    None,
    Left,
    Right
}