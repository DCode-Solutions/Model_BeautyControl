using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_Funcao
    {
        private DAO_Funcao dao;

        public BO_Funcao()
        {
            dao = new DAO_Funcao();
        }

        /// <summary>
        /// Retorna uma lista de todas as funções registradas na base de dados
        /// </summary>
        /// <returns>Lista de funçoes</returns>
        public List<CE_Funcao> getListaFuncao()
        {
            return dao.getListaFuncao();
        }

        
    }
}
