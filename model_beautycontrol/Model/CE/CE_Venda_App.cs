using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Venda_App : EntityBase
    {
        public int dataservico { get; set; }
        public bool isPago { get; set; }
        public string servico { get; set; }
        public int id_cliente { get; set; }
        public double desconto { get; set; }

        public CE_Cliente Cliente { get; set; }

        public string dataFormatada
        {
            get { return Utilidades.getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(dataservico); }
        }

       

    }
}
