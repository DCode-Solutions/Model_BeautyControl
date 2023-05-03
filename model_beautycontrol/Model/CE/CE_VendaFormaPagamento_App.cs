using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_VendaFormaPagamento_App : EntityBase
    {
        public double valor { get; set; }
        public int id_venda { get; set; }
        public string id_formapagamento { get; set; }

        public CE_Venda Venda { get; set; }
       
    }
}
