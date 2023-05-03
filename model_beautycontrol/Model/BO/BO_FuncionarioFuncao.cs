using model_beautycontrol.Model.CL;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_FuncionarioFuncao 
    {
        private DAO_FuncionarioFuncao dao;

        public BO_FuncionarioFuncao() { dao = new DAO_FuncionarioFuncao(); }

        public List<CL_FuncionarioFuncao> getFuncoesAssocidasAoFuncionario(int id)
        {
            return dao.getFuncoesAssocidasAoFuncionario(id);
        }

        public void doDeleteAll(int idfuncionario)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeleteAll(idfuncionario);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro no delete: " + ex.Message);
            }
        }

        public void doInserir(int idfuncionario, int idfuncao)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doInserir(idfuncionario, idfuncao);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na inserção: " + ex.Message);
            }
        }
    }
}
