using System;
using System.Collections.Generic;
using System.Linq;
using static DisarmBomb.Prints;
using static DisarmBomb.GameSetUp;
using static System.Console;
using static DisarmBomb.Output;
using static DisarmBomb.Color;

namespace DisarmBomb
{
    public static class Start
    {
        private const int NumberWires = 5;
        private static readonly List<ColorRule> Rules = new();
        private static List<Color> _wires = new();
        private static Color _lastColorCut = Nenhuma;
        private static void Main()
        {
            SetRules(Rules);
            _wires = GenerateWires(Rules, NumberWires);
            StartGame();
        }

        private static void StartGame()
        {
            WriteLine();
            WriteLine($"Uma bomba com {NumberWires} fio(s)!");
            WriteLine("Escolhe uma cor de fio para cortares, mas respeita as regras!");
            WriteLine();

            while (true)
            {
                WriteLine("Ainda falta cortar as seguintes cores:");
                PrintWires(_wires);
                WriteLine();
                
                var inputColor = ReadLine();
                if (inputColor is null)
                {
                    WriteLine("Não introduziste nada!");
                    WriteLine();
                    continue;
                }

                var color = ReadColor(inputColor);
                if (color is Nenhuma)
                {
                    WriteLine("Introduziste uma cor inválida!");
                    WriteLine();
                    continue;
                }

                if (!CheckIfWireColorExists(color))
                {
                    PrintOutput(NonExistentColor);
                    continue;
                }

                
                var ruleRespected = RulesRespected(color);
                _lastColorCut = color;
                if (!ruleRespected)
                {
                    PrintOutput(WentOff);
                    break;
                }

                if (_wires.Any())
                {
                    PrintOutput(StillActive);
                    _wires.Remove(color);
                }
                else
                {
                    PrintOutput(Disarmed);
                    break;
                }
            }
        }

        private static bool CheckIfWireColorExists(Color color)
        {
            return _wires.Contains(color);
        }

        public static Color ReadColor(string inputColor)
        {
            var colors = Enum.GetNames<Color>();
            for (var i = 0; i < colors.Length; i++)
            {
                var color = colors[i];
                if (color.Equals(inputColor, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (Color)i;
                }
            }
            return Nenhuma;
        }

        private static bool RulesRespected(Color colorCut)
        {
            return Rules.All(rule => rule.RuleRespected(_lastColorCut, colorCut));
        }
    }
}