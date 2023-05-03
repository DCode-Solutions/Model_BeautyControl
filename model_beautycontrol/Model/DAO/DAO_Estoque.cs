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
    public class DAO_Estoque : Context
    {
        public void doInserir(int idproduto)
        {

            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO tb_estoque(");
            str.AppendLine("id_produto,quantidade) ");
            str.AppendLine("VALUES(:p_id_produto,0)");

            str.Replace(":p_id_produto", idproduto.ToString());

            ExecutarComando(str.ToString());
        }

        public int getQuantidadeEstoqueProduto(int codProduto)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT quantidade ");
            str.AppendLine("FROM TB_ESTOQUE e ");
            str.AppendLine("WHERE e.id_produto = " + codProduto);

            DataTable dt = Obter(str.ToString());

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public List<CE_Estoque> getEstoque()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT e.id_produto,e.quantidade,p.nome ");
            str.AppendLine("FROM TB_ESTOQUE e ");
            str.AppendLine("INNER JOIN TB_PRODUTO01 p on p.id = e.id_produto");

            DataTable dt = Obter(str.ToString());

            return (from row in dt.AsEnumerable()
                    select new CE_Estoque()
                    {
                        id_produto = row["id_produto"] == DBNull.Value ? 0 : Convert.ToInt32(row["id_produto"])
                        ,
                        quantidade = row["quantidade"] == DBNull.Value ? 0 : Convert.ToInt32(row["quantidade"])
                        ,
                        Produto = new CE_Produto01() { nome = row["nome"].ToString() }
                    }).ToList();

           
        }

        public void doAtualizarEstoque(int id_produto, int quantidade, bool isEntrada)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("UPDATE tb_estoque ");

            if (isEntrada)
                str.AppendLine("SET quantidade = quantidade + " + quantidade);
            else
                str.AppendLine("SET quantidade = quantidade - " + quantidade);

            str.AppendLine(" WHERE id_produto = " + id_produto);


            ExecutarComando(str.ToString());
        }
    }
}
