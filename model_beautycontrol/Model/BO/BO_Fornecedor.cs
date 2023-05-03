using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;

namespace model_beautycontrol.Model.BO
{
    public class BO_Fornecedor
    {
        private DAO_Fornecedor dao;

        public BO_Fornecedor()
        {
            dao = new DAO_Fornecedor();
        }

        public void doInserirOuAlterar(CE_Fornecedor fornecedor)
        {
            if (fornecedor.id == 0)
            {
                doInserir(fornecedor);
            }
            else
            {
                doAlterar(fornecedor);
            }
        }

        private void doInserir(CE_Fornecedor obj)
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
                throw new Exception("Ocorreu um erro na Inserção: " + ex.Message);
            }
        }

        public List<CE_Fornecedor> getListaFornecedores(int codigo)
        {
            switch (codigo)
            {
                case 0: return dao.getListaFornecedores0(); // Returno completo 
                case 1: return dao.getListaFornecedores1(); // only id, nome , rua e cnpj
                default: return null;
            }

        }

        private void doAlterar(CE_Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }
    }
}
