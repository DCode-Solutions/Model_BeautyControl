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
    public class DAO_Venda : Context
    {
        public void doInserir(CE_Venda obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO TB_VENDA(dataservico,horainicio,horafim,ispago,id_servico,id_cliente)");
            str.AppendLine("            values(:p_dataservico,null,null,false,:p_idservico,:p_idcliente)");

            str.Replace(":p_dataservico", obj.dataservico.ToString());
            str.Replace(":p_idservico", obj.id_servico.ToString());
            str.Replace(":p_idcliente", obj.id_cliente.ToString());

            //ExecutarComando(str.ToString());
        }

        public int getUltimoId()
        {
            string sql = "SELECT MAX(id) as id FROM tb_Venda ";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int getID_After_Inserir(CE_Venda obj)
        {
            StringBuilder str = getSqlInsercao(obj);
            //str.Replace(")", " RETURNING id)");
            str.AppendLine("RETURNING id");

            DataTable dt = Obter(str.ToString());

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        private StringBuilder getSqlInsercao(CE_Venda obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO TB_VENDA(dataservico,horainicio,horafim,ispago,id_servico,id_cliente)");
            str.AppendLine("            values(:p_dataservico,null,null,false,:p_idservico,:p_idcliente)");

            str.Replace(":p_dataservico", obj.dataservico.ToString());
            str.Replace(":p_idservico", obj.id_servico.ToString());
            str.Replace(":p_idcliente", obj.id_cliente.ToString());

            return str;
        }

        public CE_Venda getVenda(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT v.*,c.nome cliente,a.descricao servico");
            str.AppendLine("	FROM TB_VENDA v");
            str.AppendLine("    INNER JOIN TB_CLIENTE c on c.id = v.id_cliente");
            str.AppendLine("    INNER JOIN TB_AUXILIAR a on a.id = v.id_servico");
            str.AppendLine("	WHERE v.id = " + id);

            var dt = Obter(str.ToString());

            List<CE_Venda> lista = new List<CE_Venda>();

            foreach (DataRow item in dt.Rows)
            {

                lista.Add(new CE_Venda()
                {
                    id = item.Field<Int32>("id")
                    ,
                    Cliente = new CE_Cliente() { id = item.Field<Int32>("id_cliente"), nome = item["cliente"].ToString() }
                    ,
                    dataservico = item.Field<Int32>("dataservico")
                    ,
                    desconto = item["desconto"] == DBNull.Value ? 0.0 : Convert.ToDouble(item["desconto"])
                    ,
                    horafim = item["horafim"] == DBNull.Value ? 0 :  item.Field<Int32>("horafim")
                    ,
                    horainicio = item["horainicio"] == DBNull.Value ? 0 : item.Field<Int32>("horainicio")
                    ,
                    id_cliente = item.Field<Int32>("id_cliente")
                    ,
                    id_servico = item.Field<Int32>("id_servico")
                    ,
                    isPago = item.Field<bool>("isPago")
                     ,
                    Servico = new CE_Auxiliar() { id = item.Field<Int32>("id_servico"), descricao = item["servico"].ToString() }

                });
            }

            return lista.FirstOrDefault();
        }

        public void doDeletarApartirDeUmID(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("DELETE FROM TB_VENDA WHERE id > " + id);

            ExecutarComando(str.ToString());
        }

        public void doFinalizarVenda(CE_Venda obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(" UPDATE tb_venda SET");
            str.AppendLine("			ispago = true ");
            str.AppendLine("	Where id = " + obj.id + ";");

            ExecutarComando(str.ToString());
        }

        public void doAtualizarDesconto(CE_Venda obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(" UPDATE tb_venda SET");
            str.AppendLine("			desconto = :p_desconto");
            str.AppendLine("	Where id = " + obj.id + ";");

            str.Replace(":p_desconto", obj.desconto.ToString().Replace(",", "."));
            ExecutarComando(str.ToString());
        }

        public void Atualizar(CE_Venda obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("UPDATE TB_VENDA ");
            str.AppendLine(" SET dataservico = :p_dataservico,");
            str.AppendLine("     horainicio =  "+ (obj.horainicio == 0 ? "null" : obj.horainicio.ToString())+"   ,");
            str.AppendLine("     horafim =     " + (obj.horafim == 0 ? "null" : obj.horafim.ToString()) + "   ,");
            str.AppendLine("     id_servico =    :p_idservico ,");
            str.AppendLine("     id_cliente = :p_idcliente");
            str.AppendLine(" WHERE id = :p_id");

            str.Replace(":p_dataservico", obj.dataservico.ToString());
            str.Replace(":p_idservico", obj.id_servico.ToString());
            str.Replace(":p_idcliente", obj.id_cliente.ToString());
            str.Replace(":p_id", obj.id.ToString());

            ExecutarComando(str.ToString());
        }

        public void Delete(int idVenda)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("DELETE FROM TB_VENDA WHERE id = " + idVenda);

            ExecutarComando(str.ToString());
        }

        public void doDeleteAll_App()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("DELETE FROM TB_VENDA_app");

            ExecutarComando(str.ToString());
        }
    }
}
