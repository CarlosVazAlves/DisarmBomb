using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using static System.Console;

namespace DisarmBomb
{
    public static class Prints
    {
        public static void PrintWires(IEnumerable<Color> wires)
        {
            foreach (var wire in wires)
            {
                Write($"{wire.ToString()} ");
            }
            WriteLine();
        }

        public static void PrintOutput(Output output)
        {
            var outputInfo = output.GetType().GetField(output.ToString());
            var descriptionAttribute = outputInfo?.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
            WriteLine(descriptionAttribute?.Description);
            WriteLine();
        }
    }
}