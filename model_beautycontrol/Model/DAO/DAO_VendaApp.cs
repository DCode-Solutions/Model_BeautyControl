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
    public class DAO_VendaApp : Context
    {
        public Int32 ObterUltimoId()
        {
            try
            {
                string sql = "SELECT MAX(id) as id FROM tb_venda_app ";

                DataTable dt = Obter(sql);

                if (dt.Rows[0][0] == null)
                    return 0;

                Int32 id = Convert.ToInt32(dt.Rows[0][0]);

                return id;
            }
            catch (Exception )
            {
                return 0;
            }
           
        }

        public void doInserir(CE_Venda_App obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO TB_VENDA_APP(id,dataservico,ispago,servico,id_cliente,desconto)");
            str.AppendLine("            values(:p_idvenda,:p_dataservico,:p_ispago,':p_servico',:p_idcliente,:p_desconto)");

            str.Replace(":p_dataservico", obj.dataservico.ToString());
            str.Replace(":p_ispago", obj.isPago.ToString());
            str.Replace(":p_idvenda", obj.id.ToString());
            str.Replace(":p_servico", obj.servico.ToString());
            str.Replace(":p_desconto", obj.desconto.ToString().Replace(",","."));
            str.Replace(":p_idcliente", obj.id_cliente.ToString());

            ExecutarComando(str.ToString());
        }

        public CE_Venda_App getVenda(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT v.*,c.nome cliente,a.descricao servico");
            str.AppendLine("	FROM TB_VENDA_APP v");
            str.AppendLine("    INNER JOIN TB_CLIENTE c on c.id = v.id_cliente");
            str.AppendLine("    INNER JOIN TB_AUXILIAR a on LOWER(a.descricao) =lower(v.servico) and a.tipo = 'tiposervico'");
            str.AppendLine("	WHERE v.id = " + id);

            var dt = Obter(str.ToString());

            List<CE_Venda_App> lista = new List<CE_Venda_App>();

            foreach (DataRow item in dt.Rows)
            {

                lista.Add(new CE_Venda_App()
                {
                    id = item.Field<Int32>("id")
                    ,
                    Cliente = new CE_Cliente() { id = item.Field<Int32>("id_cliente"), nome = item["cliente"].ToString() }
                    ,
                    dataservico = item.Field<Int32>("dataservico")
                    ,
                    desconto = item["desconto"] == DBNull.Value ? 0.0 : Convert.ToDouble(item["desconto"])
                    // ,
                    // horafim = item["horafim"] == DBNull.Value ? 0 : item.Field<Int32>("horafim")
                    //  ,
                    //  horainicio = item["horainicio"] == DBNull.Value ? 0 : item.Field<Int32>("horainicio")
                    ,
                    id_cliente = item.Field<Int32>("id_cliente")
                    ,
                    servico = item["servico"].ToString()
                    ,
                    isPago = item.Field<bool>("isPago")
                    
                });
            }

            return lista.FirstOrDefault();
        }
    }
}
