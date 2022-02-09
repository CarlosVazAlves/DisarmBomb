using System.Collections.Generic;
using DisarmBomb;
using NUnit.Framework;
using static DisarmBomb.GameSetUp;
using static DisarmBomb.Color;

namespace DisarmBombTest
{
    public static class CheckIfGameIsPossibleTest
    {
        private static readonly List<ColorRule> Rules = new();
        private static List<Color> _wires = new();
        
        [SetUp]
        public static void Setup()
        {
            Rules.Add(new ColorRule(Verde, new List<Color> { Branco }, null));
            Rules.Add(new ColorRule(Preto, null, null));
        }
        
        [Test]
        public static void PossibleGame()
        {
            _wires = new List<Color> { Verde, Branco };
            var isGamePossible = CheckIfGameIsPossible(_wires, Rules);
            Assert.That(isGamePossible, Is.True);
        }
        
        [Test]
        public static void ImpossibleGame()
        {
            _wires = new List<Color> { Verde, Preto };
            var isGamePossible = CheckIfGameIsPossible(_wires, Rules);
            Assert.That(isGamePossible, Is.False);
        }
    }
}