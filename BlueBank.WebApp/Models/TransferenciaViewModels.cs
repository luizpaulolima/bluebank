using BlueBank.WebApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlueBank.WebApp.Models
{
    public class TransferenciaViewModels
    {
        public ContaViewModels ContaOrigem { get; set; }
        public ContaViewModels ContaDestino { get; set; }

        [Display(Name = "Valor da Transferência")]
        [Required(ErrorMessage = Mensagem.Requerido)]
        [Range(0.01, 999999999999999999.99, ErrorMessage = Mensagem.ValorInvalido)]
        public decimal ValorDaTransferencia { get; set; }   
    }
}