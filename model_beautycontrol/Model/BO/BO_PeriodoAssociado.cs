using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.BO
{
    public class BO_PeriodoAssociado
    {

        private DAO_PeriodoAssociado dao;

        public BO_PeriodoAssociado()
        {
            dao = new DAO_PeriodoAssociado();
        }

        public void doInserir(CE_Funcionario funcionario, DateTime dataInicio)
        {
            try
            {
                int dtinicio = Convert.ToInt32(dataInicio.ToString("yyyyMMdd"));
                dao.doInserir(funcionario, dtinicio);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
          

        }

        public int getDataInicioVinculo(int idfuncionario, int idvinculoatual)
        {
            return dao.getDataInicioVinculo(idfuncionario, idvinculoatual);
        }
    }
}
