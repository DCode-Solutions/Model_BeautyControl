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
    public class DAO_VendaProdutoApp : Context
    {
        public int? ObterUltimoId()
        {
            try
            {
                string sql = "SELECT MAX(id) as id FROM tb_vendaproduto_app ";

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

        public void doInserir(CE_VendaProduto_App obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO TB_VENDAPRODUTO_APP(id,qtdproduto,precocobrado,precoproduto,id_venda,id_produto,id_funcionario)");
            str.AppendLine("            values(:p_idVendaProduto,:p_qtdproduto,:p_precocobrado,:p_precoproduto,:p_idvendav,:p_idproduto,0)");

            str.Replace(":p_qtdproduto", obj.qtdproduto.ToString());
            str.Replace(":p_idVendaProduto", obj.id.ToString());
            str.Replace(":p_idproduto", obj.id_produto.ToString());
            str.Replace(":p_precocobrado", obj.precocobrado.ToString().Replace(",", "."));
            str.Replace(":p_precoproduto", obj.precoproduto.ToString().Replace(",", "."));
            str.Replace(":p_idvendav", obj.id_venda.ToString());

            ExecutarComando(str.ToString());
        }
    }
}
