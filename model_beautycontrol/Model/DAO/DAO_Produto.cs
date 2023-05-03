using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_Produto : Context
    {
        public void doInserir(CE_Produto obj)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("INSERT INTO tb_produto ");
            str.AppendLine("(nome");
            str.AppendLine(", descricao");
            str.AppendLine(", minutosestimado");
            str.AppendLine(", id_status");
          //  str.AppendLine(", id_filial");
            str.AppendLine(", id_categoria) ");

            str.AppendLine("VALUES ");
            str.AppendLine("(':p_nome'");
            str.AppendLine(", ':p_descricao'");
            str.AppendLine(", :p_minutosestimado");
            str.AppendLine(", (select id from tb_auxiliar where tipo = 'status' and descricao = 'Ativo')");
        //    str.AppendLine(", :p_idfilial");
            str.AppendLine(", :p_idcategoria) ");

            str.Replace(":p_nome", obj.nome);
            str.Replace(":p_descricao", obj.descricao);
            //str.Replace(":p_preco", obj.preco.ToString().Replace(",", "."));
            str.Replace(":p_minutosestimado", obj.minutosestimado.ToString());
        //    str.Replace(":p_idfilial", 1.ToString()); //.id_filial.ToString());
            str.Replace(":p_idcategoria", obj.idcategoria.ToString());

            ExecutarComando(str.ToString());
        }

        public CE_Produto getProduto(int idproduto)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select p.id,p.nome,p.descricao,p.minutosestimado,p.id_status,p.id_categoria,c.nome categoria ");
            str.AppendLine("from tb_produto p ");
            str.AppendLine("inner join tb_categoria c on c.id = p.id_categoria  ");
            str.AppendLine("Where p.id = " + idproduto + " order by nome");

            var dt = Obter(str.ToString());

            List<CE_Produto> lista = (from item in dt.AsEnumerable()
                                   select new CE_Produto
                                   {
                                       id = item.Field<Int32>("id")
                                       ,
                                       nome = item.Field<string>("nome")
                                       ,
                                       descricao = item.Field<string>("descricao")
                                       ,
                                       minutosestimado = item.Field<int>("minutosestimado")
                                       ,
                                       idcategoria = item.Field<int>("id_categoria")
                                       ,
                                       Categoria = new CE_Categoria()
                                       {
                                           nome = item.Field<string>("categoria")
                                       }
                                   }

                               ).ToList();
            return lista.FirstOrDefault();
        }

        public void doAlterar(CE_Produto obj)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("UPDATE tb_produto SET ");
            str.AppendLine("  nome = ':p_nome', ");
            str.AppendLine("  descricao = ':p_descricao',");
            //str.AppendLine("  preco = :p_preco,");
            str.AppendLine("  minutosestimado = :p_minutosestimado,");
            //str.AppendLine(" id_status");
            //str.AppendLine(" id_filial");
            str.AppendLine("  id_categoria = :p_idcategoria");
            str.AppendLine("  WHERE id  = :p_id");

            str.Replace(":p_nome", obj.nome);
            str.Replace(":p_descricao", obj.descricao);
            //str.Replace(":p_preco", obj.preco.ToString().Replace(",", "."));
            str.Replace(":p_minutosestimado", obj.minutosestimado.ToString());
            // str.Replace(":p_idfilial", 1.ToString()); //.id_filial.ToString());
            str.Replace(":p_idcategoria", obj.idcategoria.ToString());
            str.Replace(":p_id", obj.id.ToString());

            ExecutarComando(str.ToString());
        }
    }
}
