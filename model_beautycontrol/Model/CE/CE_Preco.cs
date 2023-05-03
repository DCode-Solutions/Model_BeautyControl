using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Preco : EntityBase
    {
        public string descricao { get; set; }
        public int prioridade { get; set; }
        public double preco { get; set; }
        public int datainicio { get; set; }
        public int datafim { get; set; }
        public string detalhe { get; set; }
        public int idproduto { get; set; }

        public CE_Produto Produto { get; set; }

        public CE_Preco()
        {
            Produto = new CE_Produto();
        }

        public CE_Preco(string _descricao, double _preco, int _datainicio, int _datafim, int _idproduto, string _detalhe, int _prioridade)
        {
            this.descricao = _descricao;
            this.preco = _preco;
            this.datafim = _datafim;
            this.datainicio = _datainicio;
            this.idproduto = _idproduto;
            this.detalhe = _detalhe;
            this.prioridade = _prioridade;
            Produto = new CE_Produto();
        }
    }
}
