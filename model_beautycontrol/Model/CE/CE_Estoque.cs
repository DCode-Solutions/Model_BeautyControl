using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Estoque : EntityBase
    {
        public int id_produto { get; set; }
        public int quantidade { get; set; }
        public bool isAtivo { get; set; }

        public CE_Produto01 Produto { get; set; }

        public CE_Estoque()
        {
            Produto = new CE_Produto01();
        }
    }
}
