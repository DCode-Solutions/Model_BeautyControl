using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CL
{
    public class CL_VendaRegistro : EntityBase
    {
        public int dataservico { get; set; }
        public string cliente { get; set; }
        public bool ispago { get; set; }
        public string horainicio { get; set; }
        public string horafim { get; set; }
        public int qtditem { get; set; }
        public double valorpago { get; set; }   // valor pago pelo cliente
        public double precocobrado { get; set; } // preco total do serviço
        public double desconto { get; set; }
        public int id_servico { get; set; }
        public string servico { get; set; }

        public string Dataformadata
        {
            get { return Utilidades.getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(dataservico); }
        }

        public string status
        {
            get { return getObterSituacao(); }
        }

        // Total da venda
        public double total
        {
            get { return precocobrado - desconto; }
        }

        public double totalentrada
        {
            get
            {
                if (valorpago == 0)
                    return 0;
                else
                    return valorpago <= total ? valorpago : total;
            }
        }

        private string getObterSituacao()
        {
            if (this.ispago)
                return "Finalizado";

            if (qtditem == 0)
                return "Aberto - Venda não possui servico";

            if (valorpago >= precocobrado && !ispago)
                return "Aberto - Aguardando finalização da venda";

            return "Aberto - Aguardando pagamento do cliente";
        }
    }
}
