using DisarmBomb;
using NUnit.Framework;
using static DisarmBomb.Color;

namespace DisarmBombTest
{
    public static class ReadColorTests
    {
        [Test]
        public static void ValidColorExactMatch()
        {
            const string colorString = "Verde";
            var color = Start.ReadColor(colorString);
            Assert.That(color, Is.EqualTo(Verde));
        }
        
        [Test]
        public static void ValidColorCaseMismatch()
        {
            const string colorString = "vErDe";
            var color = Start.ReadColor(colorString);
            Assert.That(color, Is.EqualTo(Verde));
        }
        
        [Test]
        public static void InValidColor()
        {
            const string colorString = "Verd2";
            var color = Start.ReadColor(colorString);
            Assert.That(color, Is.EqualTo(Nenhuma));
        }
    }
}