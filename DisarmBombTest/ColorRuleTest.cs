using System.Collections.Generic;
using DisarmBomb;
using NUnit.Framework;
using static DisarmBomb.Color;

namespace DisarmBombTest
{
    public static class ColorRuleTest
    {
        private static ColorRule _colorRule;
        
        [SetUp]
        public static void Setup()
        {
            _colorRule = new ColorRule(Preto, new List<Color> { Verde }, new List<Color> { Vermelho });
        }
        
        [Test]
        public static void PreviousColorNone()
        {
            var ruleRespected = _colorRule.RuleRespected(Nenhuma, Preto);
            Assert.That(ruleRespected, Is.True);
        }
        
        [Test]
        public static void RuleNotApplicableToColorCut()
        {
            var ruleRespected = _colorRule.RuleRespected(Verde, Preto);
            Assert.That(ruleRespected, Is.True);
        }
        
        [Test]
        public static void ColorCutIsMatchToColorsMustCut()
        {
            var ruleRespected = _colorRule.RuleRespected(Preto, Verde);
            Assert.That(ruleRespected, Is.True);
        }
        
        [Test]
        public static void ColorCutIsMatchToColorsCannotCut()
        {
            var ruleRespected = _colorRule.RuleRespected(Preto, Vermelho);
            Assert.That(ruleRespected, Is.False);
        }
    }
}