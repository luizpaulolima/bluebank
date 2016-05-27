using BlueBank.WebApp.Models;
using BlueBank.WebApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBank.WebApp.Controllers
{
    public class TransferenciaController : BaseController
    {
        public ActionResult Index()
        {
            return View(new TransferenciaViewModels());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TransferenciaViewModels transferencia)
        {
            List<ErrosGeraisViewModels> errosGerais = new List<ErrosGeraisViewModels>();

            #region Validações simples

            if (transferencia.ValorDaTransferencia <= 0) ModelState.AddModelError("ValorDaTransferencia", Mensagem.ValorInvalido);
            if (String.IsNullOrEmpty(transferencia.ContaOrigem.Agencia) || String.IsNullOrWhiteSpace(transferencia.ContaOrigem.Agencia)) ModelState.AddModelError("ContaOrigem.Agencia", Mensagem.ValorInvalido);
            if (String.IsNullOrEmpty(transferencia.ContaOrigem.Numero) || String.IsNullOrWhiteSpace(transferencia.ContaOrigem.Numero)) ModelState.AddModelError("ContaOrigem.Numero", Mensagem.ValorInvalido);
            if (String.IsNullOrEmpty(transferencia.ContaDestino.Agencia) || String.IsNullOrWhiteSpace(transferencia.ContaDestino.Agencia)) ModelState.AddModelError("ContaDestino.Agencia", Mensagem.ValorInvalido);
            if (String.IsNullOrEmpty(transferencia.ContaDestino.Numero) || String.IsNullOrWhiteSpace(transferencia.ContaDestino.Numero)) ModelState.AddModelError("ContaDestino.Numero", Mensagem.ValorInvalido);

            #endregion

            // OBS 1: Como estamos trabalhando com texto em vez de número em Agência e Conta, passamos a ter problemas de comparação de letras maiúsculas ou minúsculas.
            //          Para esse exemplo de projeto, defini que não haverá diferenciação em valores maiúsculos e minúsculos.
            // OBS 2: Com o item 3 dos Requisitos Funcionais, o saldo da conta de Origem, após a primeira transação, SEMPRE irá ficar negativa (devido a premissa). Portanto, nas 2ª a enésima vez, a transação NUNCA irá ser negada !!!
            try
            {
                using (var db = new EntityFramework.bluebankdbEntities())
                {
                    // variáveis para as validações
                    EntityFramework.Conta contaOrigemEntity, contaDestinoEntity;

                    // Se a Agencia e Número da conta de Origem existe
                    contaOrigemEntity = db.Conta.FirstOrDefault(x => x.Agencia.ToUpper() == transferencia.ContaOrigem.Agencia.ToUpper() && x.Numero.ToUpper() == transferencia.ContaOrigem.Numero.ToUpper());
                    if (contaOrigemEntity == null || contaOrigemEntity.Id == 0)
                    {
                        errosGerais.Add(new ErrosGeraisViewModels()
                        {
                            TipoConta = "Origem",
                            Mensagem = Mensagem.ContaNumeroInvalidos
                        });
                    }

                    // Se a Agencia e Número da conta de Destino existe
                    contaDestinoEntity = db.Conta.FirstOrDefault(x => x.Agencia.ToUpper() == transferencia.ContaDestino.Agencia.ToUpper() && x.Numero.ToUpper() == transferencia.ContaDestino.Numero.ToUpper());
                    if (contaDestinoEntity == null || contaDestinoEntity.Id == 0)
                    {
                        errosGerais.Add(new ErrosGeraisViewModels()
                        {
                            TipoConta = "Destino",
                            Mensagem = Mensagem.ContaNumeroInvalidos
                        });
                    }

                    // Só iremos realizar a próxima validação (verficiar se existe saldo na conta Origem) caso as validações anteriores derem certo, caso contrário, não tem lógica realizar essa validação
                    if (errosGerais.Count == 0)
                    {
                        // Item 3 dos Requisitos Funcionais
                        if (transferencia.ValorDaTransferencia >= contaOrigemEntity.Saldo)
                        {

                            // Debitamos o valor informado da conta de Origem;
                            contaOrigemEntity.Saldo -= transferencia.ValorDaTransferencia;

                            // Creditamos o valor informado na conta de Destino
                            contaDestinoEntity.Saldo += transferencia.ValorDaTransferencia;

                            // Salvamos as transações
                            db.SaveChanges();
                        }
                        else
                        {
                            errosGerais.Add(new ErrosGeraisViewModels()
                            {
                                TipoConta = "Origem",
                                Mensagem = Mensagem.ValorInformadoMenorSaldoOrigem
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errosGerais.Add(new ErrosGeraisViewModels()
                {
                    TipoConta = "Comunicação",
                    Mensagem = Mensagem.FalhaRealizarConsultaBanco
                });

                HabilitaErroTecnicoNoConsoleNavegador(ex);
            }

            if (!ModelState.IsValid || errosGerais.Count > 0)
            {
                // Por uma questão de segurança, podemos apagar as informações da "props". Como exemplo, irei apagar o Valor da Tranferência, mas o caso pode ser aplicado a qualquer "prop"
                transferencia.ValorDaTransferencia = 0;
                ModelState.Remove("ValorDaTransferencia");

                // Adicionado a lista de erros na ViewBag, assim na tela, conseguimos ter uma listagem dos erros
                ViewBag.ErrosGerais = errosGerais;

                return View(transferencia);
            }

            // Poderíamos utilizar o Redirect to View, mas nesse caso, na url iria aparecer a Action chamada.
            // Foi uma questão de escolha
            return View("OperacaoRealizada");
        }

        public ActionResult OperacaoRealizada()
        {
            return View();
        }
    }
}