using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.BO
{
    public class BO_Empresa
    {
        private DAO_Empresa dao;

        public BO_Empresa()
        {
            dao = new DAO_Empresa();
        }

        /// <isPossuiEmpresaNaBase>
        ///  Verifica quantas empresas cadastradas na base
        ///  se quantidade maior que 0 significa que ha empresa na base
        ///  se quantidade igual a 0 nao ha empresa na base de dados
        /// </isPossuiEmpresaNaBase>
        /// <returns></returns>
        public bool isPossuiEmpresaNaBase()
        {
            try
            {
                int cont = dao.ObterQuantidadeDeEmpresasNoSistema();

                return cont > 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public void doInserirEmpresa(CE_Empresa empresa)
        {
            throw new NotImplementedException();
        }

        public int getID_After_Inserir(CE_Empresa empresa)
        {
            return dao.getID_After_Inserir(empresa);
        }

        public void doDeletar(int id)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeletar(id);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na exclusão: " + ex.Message);
            }
        }
    }
}
