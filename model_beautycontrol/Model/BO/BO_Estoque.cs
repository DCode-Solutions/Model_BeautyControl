using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_Estoque
    {
        private DAO_Estoque dao;

        public BO_Estoque()
        {
            dao = new DAO_Estoque();
        }

        public void doInserir(int idproduto)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doInserir(idproduto);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na inserção: " + ex.Message);
            }
        }

        public List<CE_Estoque> getEstoque()
        {
            return dao.getEstoque();
        }

        public int getQuantidadeEstoqueProduto(object editValue)
        {
            int codProduto = Convert.ToInt32(editValue);

            Int32? qt = dao.getQuantidadeEstoqueProduto(codProduto);

            if (qt == null)
                return 0;

            return (int)qt;
        }

        public void doAtualizarEstoque(int id_produto, int quantidade,int estoqueAtual, bool isEntrada)
        {
            try
            {
                if (isEntrada == false)
                    quantidade = quantidade > estoqueAtual ? estoqueAtual : quantidade;

                dao.IniciarTransacao();
                dao.doAtualizarEstoque(id_produto,quantidade,isEntrada);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro ao atualizar estoque: " + ex.Message);
            }
        }
    }
}
