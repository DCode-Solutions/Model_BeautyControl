using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.BO
{
    public class BO_Produto01
    {
        private DAO_Produto01 dao;

        public BO_Produto01()
        {
            dao = new DAO_Produto01();
        }

        public void doInserir(CE_Produto01 obj)
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

        public int doObterUltimoID_Produto()
        {
            return dao.doObterUltimoID_Produto();
        }

        public List<CE_Produto01> getListaProduto01()
        {
            return dao.getListaProduto01();
        }
    }
}
