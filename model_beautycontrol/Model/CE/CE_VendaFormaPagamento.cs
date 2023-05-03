using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_VendaFormaPagamento : EntityBase
    {
        public double valor { get; set; }
        public int id_venda { get; set; }
        public int id_formapagamento { get; set; }

        public CE_Venda Venda { get; set; }
        public CE_Auxiliar FormaPagamento { get; set; }

        public CE_VendaFormaPagamento()
        {
            Venda = new CE_Venda();
            FormaPagamento = new CE_Auxiliar();
        }
    }
}
