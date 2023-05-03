using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Produto01 : EntityBase
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public string marca { get; set; }
        public string observacao { get; set; }
        public int codigobarra { get; set; }

        public int id_tipoproduto { get; set; }

        public CE_Auxiliar TipoProduto { get; set; }

        public int? editvalue { get; set; }

        public CE_Produto01()
        {
            TipoProduto = new CE_Auxiliar();
        }

        public CE_Produto01(string Nome, string Descricao, string Marca, string Observacao, int CodigoBarra)
        {
            TipoProduto = new CE_Auxiliar();
            nome = Nome;
            descricao = Descricao;
            observacao = Observacao;
            codigobarra = CodigoBarra;

        }

        public String DisplayMember01
        {
            get { return nome + (String.IsNullOrEmpty(marca) ? "" : " - " + marca) + " - " + TipoProduto.descricao; }
        }
    }
}
