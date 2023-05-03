using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;
using System.Data;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_PeriodoAssociado : Context
    {
        public void doInserir(CE_Funcionario obj, int dtinicio)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO tb_periodoassociado(datainicio,id_vinculo,id_funcionario)");
            str.AppendLine("values (:p_datainicio,:p_idvinculo,:p_idfuncionario)");

            str.Replace(":p_datainicio",dtinicio.ToString());
            str.Replace(":p_idvinculo", obj.idvinculoatual.ToString());
            str.Replace(":p_idfuncionario", obj.id.ToString());

            ExecutarComando(str.ToString());
        }

        public int getDataInicioVinculo(int idfuncionario, int idvinculoatual)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT datainicio ");
            str.AppendLine("FROM tb_periodoassociado");
            str.AppendLine("WHERE id_funcionario = :p_idfuncionario ");
            str.AppendLine("  AND id_vinculo = :p_idvinculo");

            str.Replace(":p_idfuncionario", idfuncionario.ToString());
            str.Replace(":p_idvinculo", idvinculoatual.ToString());

            DataTable dt = Obter(str.ToString());

            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}
