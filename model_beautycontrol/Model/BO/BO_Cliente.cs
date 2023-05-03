using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_Cliente
    {
        private DAO_Cliente dao;

        public BO_Cliente()
        {
            dao = new DAO_Cliente();
        }

        public List<CE_Cliente> getListaClientes()
        {
           return dao.getListaClientes();
        }

        public void doInserirOuAlterar(CE_Cliente obj)
        {
            if (obj.id == 0)
                doInserir(obj);
            else
                doAlterar(obj);
        }

        private void doAlterar(CE_Cliente obj)
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
                throw new Exception("Ocorreu um erro na Alteração: " + ex.Message);
            }
        }

        private void doInserir(CE_Cliente obj)
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

        public CE_Cliente getCliente(int id)
        {
            return dao.getClientes(id);
        }

        public int getIdUltimoCliente()
        {
            return dao.getIdUltimoCliente();
        }
    }
}
