using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_Empresa : Context
    {
        public int ObterQuantidadeDeEmpresasNoSistema()
        {
            string sql = "SELECT Count(id) as id FROM tb_empresa ";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int getID_After_Inserir(CE_Empresa obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("insert into tb_empresa(");
            str.AppendLine("nome,razaosocial,cnpj,cpf) ");
            str.AppendLine("values(':p_nome',':p_razaosocial',':p_cnpj',':p_cpf') RETURNING id");

            str.Replace(":p_nome", obj.Nome);
            str.Replace(":p_razaosocial", obj.Razaosocial);
            str.Replace(":p_cnpj", obj.Cnpj);
            str.Replace(":p_cpf", obj.Cpf);

            DataTable dt = Obter(str.ToString());

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void doDeletar(int id)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("DELETE from tb_empresa ");
            str.AppendLine("  WHERE id  = :p_id");
            
            str.Replace(":p_id", id.ToString());

            ExecutarComando(str.ToString());
        }
    }
}
