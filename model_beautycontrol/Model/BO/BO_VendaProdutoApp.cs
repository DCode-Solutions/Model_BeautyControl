using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.BO
{
    public class BO_VendaProdutoApp
    {
        private DAO_VendaProdutoApp dao;

        public BO_VendaProdutoApp()
        {
            dao = new DAO_VendaProdutoApp();
        }

        public void doInserir(CE_VendaProduto_App obj)
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

        public int? ObterUltimoId()
        {
            return dao.ObterUltimoId();
        }
    }
}
