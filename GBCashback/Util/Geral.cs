using System;
using System.Linq;
using System.Text.RegularExpressions;
using GBCashback.Enums;

namespace GBCashback.Util
{
    public static class Geral
    {
        public static string Secret = "e5b3c21e1abe4d00a6a0eb8e2cf2ffe117b9a857b8e84037bc751c7bd55503be";

        public static string ApenasNumeros(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
                return new string(str.Where(char.IsDigit).ToArray());
        }

        public static string FormatarCpf(string cpf)
        {
            cpf = ApenasNumeros(cpf);

            if (string.IsNullOrEmpty(cpf))
                return string.Empty;
            else
                return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public static bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            cpf = ApenasNumeros(cpf);

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool ValidarEmail(string emailInput)
        {
            if (string.IsNullOrEmpty(emailInput)) return false;

            Regex regex = new Regex(
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.CultureInvariant | RegexOptions.Singleline);

            return regex.IsMatch(emailInput);
        }

        public static EnumStatus ObtemStatusParaCadastro(string cpf)
        {
            string cpfAprovado = "153.509.460-56";

            if (cpf == cpfAprovado)
            {
                return EnumStatus.Aprovado;
            }
            else
            {
                return EnumStatus.EmValidacao;
            }
        }
    }
}