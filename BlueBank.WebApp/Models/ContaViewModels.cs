using BlueBank.WebApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlueBank.WebApp.Models
{
    public class ContaViewModels
    {
        public int Id { get; set; }

        [Display(Name = "Agência")]
        [Required(ErrorMessage = Mensagem.Requerido)]
        [StringLength(10, ErrorMessage = Mensagem.CampoLimitadoDigitos)]
        public string Agencia { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = Mensagem.Requerido)]
        [StringLength(10, ErrorMessage = Mensagem.CampoLimitadoDigitos)]
        public string Numero { get; set; }

        [Display(Name = "Saldo")]
        public decimal Saldo { get; set; }
    }
}