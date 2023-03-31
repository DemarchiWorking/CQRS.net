using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.DominioServicos.Enum;
    public enum Categoria
    {
        [Description("Administrador")]
        Administrador = 0,

        [Description("Audiovisual")]
        Audiovisual = 1,

        [Description("Cinema")]
        Cinema = 2,

        [Description("Teatro")]
        Teatro = 3,

        [Description("Musico")]
        Musico = 4,

        [Description("Outros")]
        Outros = 99,

}

