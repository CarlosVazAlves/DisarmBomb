using System.Collections.Generic;
using static DisarmBomb.Color;

namespace DisarmBomb
{
    public class ColorRule
    {
        private readonly Color _previousColorCut;
        private readonly List<Color> _colorsMustCut;
        private readonly List<Color> _colorsCannotCut;

        public ColorRule(Color color, List<Color> colorsMustCut, List<Color> colorsCannotCut)
        {
            _previousColorCut = color;
            _colorsMustCut = colorsMustCut ?? new List<Color>();
            _colorsCannotCut = colorsCannotCut ?? new List<Color>();
        }

        public bool RuleRespected(Color previousColor, Color colorCut)
        {
            if (previousColor is Nenhuma || previousColor != _previousColorCut) return true;
            return _colorsMustCut.Contains(colorCut) || !_colorsCannotCut.Contains(colorCut);
        }

        public List<Color> GetColorsMustCutList() => _colorsMustCut;
        
        public Color GetPreviousColor() => _previousColorCut;
    }
}