using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlueBank.WebApp.Utils
{
    public class Mensagem
    {
        public const string Requerido = "{0} requerido(a)";
        public const string CampoLimitadoDigitos = "{0} limitado a {1} dígitos";
        public const string RegularExpressionErro = "Valor inválido. Máximo duas casas decimais";
        public const string RangeErrorDecimal = "Valor inválido. Máximo 18 dígitos";
        public const string ValorInvalido = "Valor inválido";
        public const string ContaNumeroInvalidos = "Conta/Número informados não localizado";
        public const string FalhaRealizarConsultaBanco = "Falha ao realizar consulta ao sistema. Por favor, tente novamente em algums instantes.";
        public const string ValorInformadoMenorSaldoOrigem = "O valor a ser debitado deve ser maior ou igual ao saldo disponível na conta";
    }
}