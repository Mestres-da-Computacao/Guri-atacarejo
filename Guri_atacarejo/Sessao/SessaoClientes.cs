using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guri_atacarejo
{
    public static class SessaoClientes
    {
        public static string NomeCliente { get; set; }
        public static string Senha { get; set; }
    }

    // para logout:
    //SessaoClientes.NomeCliente = null;
    //SessaoClientes.Senha = null;

    //using:
    // using Guri_atacarejo.SessaoClientes;
}
