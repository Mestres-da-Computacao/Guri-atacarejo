using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guri_atacarejo.forms
{
    internal class ValidadorCPF
    {
        public bool ValidarCPF(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;
            // Verifica se todos os dígitos são iguais (ex: 111.111.111-11)
            if (cpf.Distinct().Count() == 1)
                return false;
            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);
            int resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : 11 - resto;
            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);
            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : 11 - resto;
            // Verifica se os dígitos calculados são iguais aos dígitos informados
            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }
    }
}
