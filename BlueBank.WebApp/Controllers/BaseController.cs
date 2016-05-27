using BlueBank.WebApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBank.WebApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Habilita uma mensagem de erro no console do navegador.
        /// Geralmente utlizado para erros técnicos, que não são de interesse do cliente.
        /// </summary>
        public void HabilitaErroTecnicoNoConsoleNavegador(Exception ex)
        {
            TempData["ErroTecnico"] = null;

            TempData["ErroTecnico"] = Helper.ConstroiMensagemErroDeException(ex);
        }
    }
}