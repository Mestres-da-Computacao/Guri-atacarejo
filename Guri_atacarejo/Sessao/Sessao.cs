using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guri_atacarejo
{
    public static class Sessao
    {
        public static int NivelFuncionario { get; set; }
        public static string Usuario { get; set; }
    }

    //para usar em outro form:
    //if (Sessao.NivelFuncionario == 1)
    //{
    //    // Usuário com nível 1
    //}

    // para logout:
    //Sessao.NivelFuncionario = 0;
    //Sessao.Usuario = null;

    //using:
    // using Guri_atacarejo.sessao;
}
