using System;
using System.Collections.Generic;
using System.Linq;

namespace DisarmBomb
{
    public static class GameSetUp
    {
        public static void SetRules(ICollection<ColorRule> rules)
        {
            rules.Add(new ColorRule(Color.Branco, null, new List<Color> { Color.Branco, Color.Preto }));
            rules.Add(new ColorRule(Color.Vermelho, new List<Color> { Color.Verde }, null));
            rules.Add(new ColorRule(Color.Preto, null, new List<Color> { Color.Branco, Color.Verde, Color.Laranja }));
            rules.Add(new ColorRule(Color.Laranja, new List<Color> { Color.Vermelho, Color.Preto }, null));
            rules.Add(new ColorRule(Color.Verde, new List<Color> { Color.Laranja, Color.Branco }, null));
            rules.Add(new ColorRule(Color.Roxo, null, new List<Color> { Color.Roxo, Color.Verde, Color.Laranja, Color.Branco }));
        }

        public static List<Color> GenerateWires(List<ColorRule> rules, int numberWires)
        {
            List<Color> wiresList = null;
            var randomGenerator = new Random();
            var isGamePossible = false;

            while (!isGamePossible)
            {
                wiresList = new List<Color>();
                for (var i = 0; i < numberWires; i++)
                {
                    var colorIndex = randomGenerator.Next(1, Enum.GetValues<Color>().Length);
                    wiresList.Add((Color)colorIndex);
                }

                isGamePossible = CheckIfGameIsPossible(wiresList, rules);
            }
            return wiresList;
        }

        public static bool CheckIfGameIsPossible(ICollection<Color> wires, IReadOnlyCollection<ColorRule> rules)
        {
            foreach (var wire in wires)
            {
                var colorRule = SelectCorrectRule(rules, wire);
                if (colorRule is null)
                {
                    throw new ArgumentException($"No rule created for color {wire}");
                }
                var colorsMustCut = colorRule.GetColorsMustCutList();
                if (colorsMustCut.Count == 0) continue;

                foreach (var colorMustCut in colorsMustCut)
                {
                    if (wires.Contains(colorMustCut))
                    {
                        return true;
                    }

                    if (wires.Count(color => color == colorMustCut) == 1 && colorMustCut == wire)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private static ColorRule SelectCorrectRule(IEnumerable<ColorRule> rules, Color color)
        {
            return rules.FirstOrDefault(rule => rule.GetPreviousColor() == color);
        }
    }
}