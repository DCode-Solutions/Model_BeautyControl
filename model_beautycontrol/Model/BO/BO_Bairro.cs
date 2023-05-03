using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_Bairro
    {
        private DAO_Bairro dao;
        public BO_Bairro()
        {
            dao = new DAO_Bairro();
        }

        /// <summary>
        /// Retorna uma lista de bairro de uma determinada cidade
        /// </summary>
        /// <param name="idCidade"></param>
        /// <returns></returns>
        public List<CE_Bairro> getListaBairro(int idCidade)
        {
            return dao.getListaBairro(idCidade);
        }
    }
}
