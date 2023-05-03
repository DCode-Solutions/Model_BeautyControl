using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.BO
{
    public class BO_Produto
    {
        private DAO_Produto dao;

        public BO_Produto() { dao = new DAO_Produto(); }

        public void doAlterar(CE_Produto obj)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doAlterar(obj);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na alteração: " + ex.Message);
            }
        }

        public void doInserir(CE_Produto obj)
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

        public CE_Produto getProduto(int idproduto)
        {
            return dao.getProduto(idproduto);
        }
    }
}
