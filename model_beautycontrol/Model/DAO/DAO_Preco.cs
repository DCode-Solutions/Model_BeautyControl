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
    public class DAO_Preco : Context
    {
        public List<CE_Preco> getProdutos()
        {
            int datanow = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            StringBuilder str = new StringBuilder();
            str.AppendLine("select pr.id,pr.preco,pr.id_produto,pr.detalhe,pd.nome,pd.id_status,pd.id_categoria,pd.descricao");
            str.AppendLine("from tb_preco pr");
            str.AppendLine("inner join tb_produto pd on pd.id = pr.id_produto");
            //str.AppendLine("where (('2017-01-03' BETWEEN datainicio AND datafim) ");
            str.AppendLine("where ((" + datanow + ">=datainicio AND " + datanow + "<=datafim)");
            str.AppendLine("      or datafim is null) ");
            str.AppendLine("      and pr.id in (select id");
            str.AppendLine("                    from tb_preco pp");
            str.AppendLine("                    where prioridade = (select Max(prioridade)");
            str.AppendLine("                                        from tb_preco pr");
            str.AppendLine("                                        where id_produto = pp.id_produto");
            //  str.AppendLine("                                        and(('2017-01-03' BETWEEN datainicio AND datafim) or datafim is null)");
            str.AppendLine("                                            and((" + datanow + ">=datainicio AND " + datanow + "<=datafim) or datafim is null)");
            str.AppendLine("                                        )");
            //str.AppendLine("                    and(('2017-01-03' BETWEEN datainicio AND datafim) or datafim is null)");
            str.AppendLine("                                            and((" + datanow + ">=datainicio AND " + datanow + "<=datafim) or datafim is null)");
            str.AppendLine("                    );");

            var dt = Obter(str.ToString());

           

            List<CE_Preco> lista = new List<CE_Preco>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public double getPrecoPadrao(int id)
        {
            string sql = "Select preco from tb_preco where datafim is null and id_produto =" + id;

            DataTable dt = Obter(sql);

            return Convert.ToDouble(dt.Rows[0][0]);
        }

        public void doInserir(double preco)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Insert into tb_preco(descricao,prioridade,preco,datainicio,id_produto,detalhe)");
            str.AppendLine("            values('Padrão',10,:p_preco,"+Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"))+",(select Max(id) from tb_produto),'Preco Padrão Inicial')");

            str.Replace(":p_preco", preco.ToString().Replace(",", "."));
            ExecutarComando(str.ToString());
        }

        public void doInserir(CE_Preco obj)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("INSERT INTO tb_preco ");
            str.AppendLine("(descricao");
            str.AppendLine(", prioridade");
            str.AppendLine(", preco");
            str.AppendLine(", datainicio");
            str.AppendLine(", datafim");
            str.AppendLine(", detalhe");
            str.AppendLine(", id_produto) ");

            str.AppendLine("VALUES ");
            str.AppendLine("(':p_descricao'");
            str.AppendLine(", :p_prioridade");
            str.AppendLine(", :p_preco");
            str.AppendLine(", ':p_datainicio'");
            str.AppendLine(", ':p_datafim'");
            str.AppendLine(", ':p_detalhe'");
            str.AppendLine(", :p_idproduto) ");

            str.Replace(":p_descricao", obj.descricao);
            str.Replace(":p_prioridade", obj.prioridade.ToString());
            str.Replace(":p_preco", obj.preco.ToString().Replace(",", "."));
            str.Replace(":p_datainicio", obj.datainicio.ToString());
            str.Replace(":p_datafim", obj.datafim.ToString());
            str.Replace(":p_detalhe", obj.detalhe);
            str.Replace(":p_idproduto", obj.idproduto.ToString());

            ExecutarComando(str.ToString());
        }

        public int getContPromocaoMensalNestaData(int datainicio,int datafim, int idproduto)
        {
            string sql = "Select count(id) from tb_preco where (" + datainicio + "= datainicio and datafim= "+datafim+") and prioridade = 60 and id_produto ="+idproduto;

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int getContPromocaoDiaEspecialNestaData(int datainicio, int idproduto)
        {
            string sql = "Select count(id) from tb_preco where " + datainicio + " = datainicio and prioridade = 100 and id_produto ="+idproduto;

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        private CE_Preco PopularObjeto(DataRow item)
        {
            CE_Preco result = new CE_Preco();
            result.id = item.Field<Int32>("id");
            result.preco = item.Field<double>("preco");
            //result.detalhe = item.Field<string>("detalhe");

            CE_Produto produto = new CE_Produto();
            produto.id = item.Field<Int32>("id_produto");
            produto.nome = item.Field<string>("nome");
            produto.idstatus = item.Field<Int32>("id_status");
            //produto.id_filial = item.Field<Int32>("id_filial");
            produto.idcategoria = item.Field<Int32>("id_categoria");
            produto.descricao = item.Field<string>("descricao");

            result.idproduto = produto.id;

            result.Produto = produto;

            return result;
        }
    }
}
