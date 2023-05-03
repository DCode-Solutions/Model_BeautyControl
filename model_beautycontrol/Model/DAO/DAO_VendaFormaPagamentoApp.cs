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
    public class DAO_VendaFormaPagamentoApp : Context
    {
        public int? ObterUltimoId()
        {
            try
            {
                string sql = "SELECT MAX(id) as id FROM tb_vendaformapagamento_app ";

                DataTable dt = Obter(sql);

                if (dt.Rows[0][0] == null)
                    return 0;

                Int32 id = Convert.ToInt32(dt.Rows[0][0]);

                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void doInserir(CE_VendaFormaPagamento_App obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO TB_VENDAFORMAPAGAMENTO_APP(id,valor,id_venda,id_formapagamento)");
            str.AppendLine("            values(:p_idvendaForma,:p_valor,:p_idvendav,'Dinheiro')");

            str.Replace(":p_idvendaForma", obj.id.ToString());
            str.Replace(":p_valor", obj.valor.ToString().Replace(",", "."));
            str.Replace(":p_idvendav", obj.id_venda.ToString());

            ExecutarComando(str.ToString());
        }
    }
}
