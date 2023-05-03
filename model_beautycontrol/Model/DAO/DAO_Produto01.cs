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
    public class DAO_Produto01 : Context
    {
        public void doInserir(CE_Produto01 obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO tb_produto01(");
            str.AppendLine("nome,marca,descricao,observacao,codigobarra,id_tipoproduto) ");
            str.AppendLine("VALUES(':p_nome',':p_marca',':p_descricao',':p_observacao',:p_codigobarra,:p_id_tipoproduto)");

            str.Replace(":p_nome", obj.nome);
            str.Replace(":p_marca", obj.marca);
            str.Replace(":p_descricao", obj.descricao);
            str.Replace(":p_observacao", obj.observacao);
            str.Replace(":p_codigobarra", obj.codigobarra == 0 ? "null" : obj.codigobarra.ToString());//obj.codigobarra == 0 ? "" : obj.id_bairro.ToString());
            str.Replace(":p_id_tipoproduto", obj.id_tipoproduto.ToString());

            ExecutarComando(str.ToString());
        }

        public List<CE_Produto01> getListaProduto01()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT prod.*,aux.descricao tipo");
            str.AppendLine("	FROM TB_PRODUTO01 prod");
            str.AppendLine("	INNER JOIN TB_AUXILIAR aux ON aux.id = prod.id_tipoproduto");

            var dt = Obter(str.ToString());

            List<CE_Produto01> lista = new List<CE_Produto01>();

            foreach (DataRow item in dt.Rows)
            {

                lista.Add(new CE_Produto01()
                {
                    id = item.Field<Int32>("id")
                    ,
                    editvalue = item.Field<Int32>("id")
                    ,
                    nome = item.Field<String>("nome")
                    ,
                    marca = item.Field<String>("marca")
                    ,
                    TipoProduto = new CE_Auxiliar() { descricao = item.Field<String>("tipo")}
                });
            }

            return lista;

        }

        internal int doObterUltimoID_Produto()
        {

            string sql = "SELECT MAX(id) as id FROM tb_produto01";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);

        }
    }
}
