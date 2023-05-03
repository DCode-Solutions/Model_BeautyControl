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
    public class DAO_Movimentacao01 : Context
    {
        public void doInserir(CE_Movimentacao01 obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO tb_movimentacao01(");
            str.AppendLine("datamovimentacao,quantidade,id_tipomovimentacao,custounit,");

            if (obj.responsavel !=null && obj.responsavel != 0)
                str.AppendLine("responsavel,");

            if (obj.iscompraefetuada == true)
                str.AppendLine("iscompraefetuada,");

            if (obj.codclienteorfornecedor != 0)
                str.AppendLine("codclienteorfornecedor,");

            if (obj.notafiscal != "")
                str.AppendLine("notafiscal,");

            if (obj.observacao !="")
                str.AppendLine("observacao,");

            str.AppendLine("id_produto)");

            str.AppendLine("VALUES(:p_datamovimentacao,:p_quantidade,:p_id_tipomovimentacao,:p_custounit,");

            if (obj.responsavel != null && obj.responsavel != 0)
                str.AppendLine(":p_responsavel,");

            if (obj.iscompraefetuada == true)
                str.AppendLine("true,");

            if (obj.codclienteorfornecedor != 0)
                str.AppendLine(":p_codclienteorfornecedor,");

            if (obj.notafiscal != "")
                str.AppendLine("':p_notafiscal',");

            if (obj.observacao != "")
                str.AppendLine("':p_observacao',");

            str.AppendLine(":p_id_produto)");

            str.Replace(":p_datamovimentacao", obj.datamovimentacao.ToString());
            str.Replace(":p_quantidade", obj.quantidade.ToString());
            str.Replace(":p_id_tipomovimentacao", obj.id_tipomovimentacao.ToString());
            str.Replace(":p_custounit", obj.custounit.ToString().Replace(',','.'));
            str.Replace(":p_codclienteorfornecedor",obj.codclienteorfornecedor.ToString());
            str.Replace(":p_notafiscal", obj.notafiscal);
            str.Replace(":p_observacao", obj.observacao);
            str.Replace(":p_id_produto", obj.id_produto.ToString());
            str.Replace(":p_responsavel", obj.responsavel.ToString());



            ExecutarComando(str.ToString());
        }

        public List<CE_Movimentacao01> getListaMovimentacaoProduto(int idproduto)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT m.*,a.descricao movimentacao,a.sigla ");
            str.AppendLine("FROM TB_MOVIMENTACAO01 m");
            str.AppendLine("INNER JOIN TB_AUXILIAR a on a.id = m.id_tipomovimentacao");
            str.AppendLine("WHERE id_produto = "+idproduto);
            str.AppendLine("ORDER BY m.datamovimentacao desc");

            var dt = Obter(str.ToString());

            List<CE_Movimentacao01> lista = new List<CE_Movimentacao01>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjetoAll(item));
            }

            return lista;

        }

        private CE_Movimentacao01 PopularObjetoAll(DataRow row)
        {
            CE_Movimentacao01 result = new CE_Movimentacao01();
           // result.TipoMovimentacao = new CE_Auxiliar();

            result.id = Convert.ToInt32(row["id"].ToString());
            result.TipoMovimentacao.id = result.id_tipomovimentacao = Convert.ToInt32(row["id_tipomovimentacao"].ToString());
            result.TipoMovimentacao.descricao = row["movimentacao"].ToString();
            result.TipoMovimentacao.sigla = row["sigla"].ToString();

            result.datamovimentacao = Convert.ToInt32(row["datamovimentacao"].ToString());


            if (result.TipoMovimentacao.descricao.Contains("(-)"))
                result.quantidade = -1*Convert.ToInt32(row["quantidade"].ToString());
            else
                result.quantidade = Convert.ToInt32(row["quantidade"].ToString());

            result.custounit = Convert.ToDouble(row["custounit"].ToString());

            result.responsavel = row["responsavel"] == DBNull.Value ? new Nullable<int>() : Convert.ToInt32(row["responsavel"].ToString());

//            if(result.responsavel != null)
                

            return result;
        }
    }
}
