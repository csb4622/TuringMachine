using System.Collections.Generic;

namespace TuringMachine;

public class BinaryPalindrome: IProgram
{
    public string StartState => "i";
    public int StartPosition => 0;

    public IEnumerable<Rule> Rules => new[]
    {
        new Rule("i", '0', ' ', "sr0", Direction.Right),
        new Rule("i", '1', ' ', "sr1", Direction.Right),
        
        new Rule("sr0", '0', '0', "sr0", Direction.Right),
        new Rule("sr0", '1', '1', "sr0", Direction.Right),
        new Rule("sr0", ' ', ' ', "l0", Direction.Left),
        
        new Rule("sr1", '0', '0', "sr1", Direction.Right),
        new Rule("sr1", '1', '1', "sr1", Direction.Right),
        new Rule("sr1", ' ', ' ', "l1", Direction.Left),
        
        
        new Rule("l0", '0', ' ', "l", Direction.Left),
        new Rule("l0", '1', '1', "FALSE", Direction.None),
        new Rule("l0", ' ', ' ', "TRUE", Direction.None),
        
        new Rule("l1", '1', ' ', "l", Direction.Left),
        new Rule("l1", '0', '0', "FALSE", Direction.None),
        new Rule("l1", ' ', ' ', "TRUE", Direction.None),
        
        new Rule("l", '0', ' ', "sl0", Direction.Left),
        new Rule("l", '1', ' ', "sl1", Direction.Left),
        new Rule("l", ' ', ' ', "TRUE", Direction.None),
        
        new Rule("sl0", '0', '0', "sl0", Direction.Left),
        new Rule("sl0", '1', '1', "sl0", Direction.Left),
        new Rule("sl0", ' ', ' ', "r0", Direction.Right),
        
        new Rule("sl1", '0', '0', "sl1", Direction.Left),
        new Rule("sl1", '1', '1', "sl1", Direction.Left),
        new Rule("sl1", ' ', ' ', "r1", Direction.Right),   
        
        new Rule("r0", '0', ' ', "lr", Direction.Right),
        new Rule("r0", '1', '1', "FALSE", Direction.None),
        new Rule("r0", ' ', ' ', "TRUE", Direction.None),
        
        new Rule("r1", '1', ' ', "lr", Direction.Right),
        new Rule("r1", '0', '1', "FALSE", Direction.None),
        new Rule("r1", ' ', ' ', "TRUE", Direction.None),
        
        new Rule("lr", '0', ' ', "sr0", Direction.Right),
        new Rule("lr", '1', ' ', "sr1", Direction.Right),
        new Rule("lr", ' ', ' ', "TRUE", Direction.None)
        
    };
}