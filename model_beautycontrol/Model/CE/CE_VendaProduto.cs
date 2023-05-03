using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_VendaProduto : EntityBase
    {
        public int qtdproduto { get; set; }
        public double precocobrado { get; set; }
        public double precoproduto { get; set; }
        public string observacao { get; set; }
        public int id_venda { get; set; }
        public int id_funcionario { get; set; }
        public int id_produto { get; set; }

        public double Total
        {
            get { return qtdproduto * precocobrado; }
        }

        public CE_Venda Venda { get; set; }
        public CE_Funcionario Funcionario { get; set; }
        public CE_Produto Produto { get; set; }

        public CE_VendaProduto() { Venda = new CE_Venda(); Funcionario = new CE_Funcionario(); Produto = new CE_Produto(); }
    }
}
