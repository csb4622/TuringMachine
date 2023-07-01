

using System;

namespace TuringMachine;

public static class Program
{
    public static void Main(params string[] args)
    {
        var program = new BinaryPalindrome();
        //var program = new Inverter();
        
        var machine = new TuringMachine(program);
        
        machine.Reset(new[]{'1','0','1','1','1','0'});

        
        Console.WriteLine($"Staring Tape: {machine.DisplayTape()}");
        machine.Run();
        Console.WriteLine($"Ending Tape:  {machine.DisplayTape()}");
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}