using model_beautycontrol.Model.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.DOM
{
    public class DOM_Movimentacao
    {
        public DOM_Movimentacao()
        {
            boBairro = new BO_Bairro();
            boAuxiliar = new BO_Auxiliar();
            boProduto01 = new BO_Produto01();
            boEstoque = new BO_Estoque();
        }

        public BO_Bairro boBairro;
        public BO_Auxiliar boAuxiliar;
        public BO_Produto01 boProduto01;
        public BO_Estoque boEstoque;

        public void DoInserirOuAlterarProduto01(CE_Produto01 produto)
        {
            if (produto.id == 0)
            {
                boProduto01.doInserir(produto);
                int idproduto = boProduto01.doObterUltimoID_Produto();
                boEstoque.doInserir(idproduto);
            }

        }
    }
}
