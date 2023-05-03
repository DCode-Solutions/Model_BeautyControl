using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Venda : EntityBase
    {
        public int dataservico { get; set; }
        public int horainicio { get; set; }
        public int horafim { get; set; }
        public bool isPago { get; set; }
        public int id_servico { get; set; }
        public int id_cliente { get; set; }
        public double  desconto { get; set; }

        public CE_Auxiliar Servico { get; set; }
        public CE_Cliente Cliente { get; set; }

        public string dataFormatada
        {
            get { return Utilidades.getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(dataservico); }
        }

        public CE_Venda() { Servico = new CE_Auxiliar(); Cliente = new CE_Cliente(); }

        
    }
}
