using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaga_Top_Down2.Models
{
    public class CalculoModel
    {
        /// <summary>
        /// Quantidade de KM feitos com um litro
        /// </summary>
        public int qtdKmLitro { get; set; }

        /// <summary>
        /// Tempo gasto na viagem horas
        /// </summary>
        public int tempoGastoHora { get; set; }
        /// <summary>
        /// Tempo gasto na viagem minutos
        /// </summary>
        public int tempoGastoMinuto { get; set; }
        public decimal tempoGastoTotal
        {
            get
            {
                var result = (decimal)(this.tempoGastoMinuto + (this.tempoGastoHora * 60))/60;

                return Math.Round(result, 2);
            }
        }

        /// <summary>
        /// Velocidade média
        /// </summary>
        public int velMedia { get; set; }

        public decimal resultadoDistancia { get; set; }
        public decimal resultadoLitrosUtilizado { get; set; }

        public void obterDistanciaPercorrida()
        {
            this.resultadoDistancia = this.tempoGastoTotal * this.velMedia;
        }

        public void obterLitrosUtilizado()
        {
            this.resultadoLitrosUtilizado = this.resultadoDistancia / this.qtdKmLitro;
        }

    }
}