using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_VendaApp
    {
        private DAO_VendaApp dao;

        public BO_VendaApp() {

            dao = new DAO_VendaApp();
        }

        public Int32 ObterUltimoId()
        {
            return dao.ObterUltimoId();
        }

        public void doInserir(CE_Venda_App obj)
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


        public CE_Venda_App getVenda(int id)
        {
            return dao.getVenda(id);
        }
    }
}
