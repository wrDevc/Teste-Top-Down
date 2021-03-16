using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vaga_Top_Down2.Models;

namespace Vaga_Top_Down2.Controllers
{
    public class CalculoController : ApiController
    {
        public IHttpActionResult ObterValores([FromBody] CalculoModel model)
        {
            if (model != null)
            {
                if(model.qtdKmLitro > 0 && (model.tempoGastoHora > 0 || model.tempoGastoMinuto > 0) && model.velMedia > 0)
                {
                    model.obterDistanciaPercorrida();
                    model.obterLitrosUtilizado();
                    return Ok(new { IsValid = true, ErrorMessage = "", Resultado = new { VelocidadeMedia = model.velMedia, TempoGasto = model.tempoGastoTotal + " Horas", DistanciaPercorrida = model.resultadoDistancia, LitrosUtilizado = model.resultadoLitrosUtilizado + " Litros" } });
                }
                else
                {
                    return Json(new { IsValid = false, ErrorMessage = "Nem todos parâmetros foram preenchidos. Segue os parâmetros obrigatórios: qtdKmLitro, tempoGastoHora ou tempoGastoMinuto e velMedia" });
                }
            }
            else
            {
                return Json(new { IsValid = false, ErrorMessage = "Não foi encontrado nenhum parâmetro para a requisição, por favor preencha os parâmetros" });
            }

        }
    }
}
