using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BlueBank.WebApp.Utils
{
    public class Helper
    {
        /// <summary>
        /// Método recursivo que captura todas as mensagens do InnerException, independente da quantidade de níveis.
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns></returns>
        public static string ConstroiMensagemErroDeException(Exception ex)
        {
            StringBuilder m = new StringBuilder();

            if (ex != null)
            {
                m.AppendLine(ex.Message);

                if (ex.InnerException != null)
                {
                    m.Append(ConstroiMensagemErroDeException(ex.InnerException));
                }
            }

            // alguns caracteres vindo do BD não são aceitos em HTML, então realizamos um replace para esse ajuste
            return m.ToString().Replace("\r\n", "\\n").Replace("\r", "\\n").Replace("'", "\"");
        }
    }
}