using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.BO
{
    public class BO_Movimentacao01 
    {
        private DAO_Movimentacao01 dao;

        public BO_Movimentacao01()
        {
            dao = new DAO_Movimentacao01();
        }

        public void doInserir(CE_Movimentacao01 obj)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doInserir(obj);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na inserção: " + ex.Message);
            }
        }

        public List<CE_Movimentacao01> getListaMovimentacaoProduto(int idproduto)
        {
            return dao.getListaMovimentacaoProduto(idproduto);
        }
    }
}
