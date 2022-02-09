using System.ComponentModel;

namespace DisarmBomb
{
    public enum Output
    {
        [Description("A bomba continua activa! Corta outro fio.")]
        StillActive,
        
        [Description("A bomba explodiu!")]
        WentOff,
        
        [Description("Muito bem! Bomba desactivada. Ufa...")]
        Disarmed,
        
        [Description("Não existe nenhum fio dessa cor!")]
        NonExistentColor
    }
}