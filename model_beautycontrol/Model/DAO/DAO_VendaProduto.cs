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
    public class DAO_VendaProduto : Context
    {
        public void doInserir(CE_VendaProduto obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO TB_VENDAPRODUTO(qtdproduto,precocobrado,precoproduto,");

            if (obj.observacao != null)
                str.AppendLine("observacao,");

            str.AppendLine("id_venda,id_produto,id_funcionario)");

            str.AppendLine("            values(:p_qtdproduto,:p_precocobrado,:precoproduto,");

            if (obj.observacao != null)
                str.AppendLine("':p_observacao',");

            str.AppendLine(":p_idvenda,:p_idproduto,:p_idfuncionario)");

            str.Replace(":p_qtdproduto", obj.qtdproduto.ToString());
            str.Replace(":p_precocobrado", obj.precocobrado.ToString().Replace(',', '.'));
            str.Replace(":precoproduto", obj.precoproduto.ToString().Replace(',', '.'));
            str.Replace(":p_observacao",string.IsNullOrEmpty(obj.observacao) ? "" : obj.observacao.ToString());
            str.Replace(":p_idvenda",  obj.id_venda.ToString());
            str.Replace(":p_idproduto", obj.id_produto.ToString());
            str.Replace(":p_idfuncionario", obj.id_funcionario.ToString());

            ExecutarComando(str.ToString());
        }

        public List<CE_VendaProduto> getListaVendaProduto_App(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT vp.*,f.nome funcionario,p.nome produto");
            str.AppendLine("	FROM TB_VENDAPRODUTO_APP vp");
            str.AppendLine("    INNER JOIN TB_PRODUTO p on p.id = vp.id_produto");
            str.AppendLine("    LEFT JOIN TB_FUNCIONARIO f on f.id = vp.id_funcionario");
            str.AppendLine("	WHERE vp.id_venda = " + id);

            var dt = Obter(str.ToString());

            List<CE_VendaProduto> lista = new List<CE_VendaProduto>();

            foreach (DataRow item in dt.Rows)
            {

                lista.Add(new CE_VendaProduto()
                {
                    id = item.Field<Int32>("id")
                    ,
                    Funcionario = new CE_Funcionario() { id = item.Field<Int32>("id_funcionario"), nome = item["funcionario"].ToString() }
                    ,
                    id_funcionario = item.Field<Int32>("id_funcionario")
                    ,
                    id_produto = item.Field<Int32>("id_produto")
                    ,
                    id_venda = item.Field<Int32>("id_venda")
                    ,
                    observacao = item["observacao"] == DBNull.Value ? "" : item.Field<String>("observacao")
                    ,
                    precocobrado = item.Field<double>("precocobrado")
                    ,
                    precoproduto = item.Field<double>("precoproduto")
                    ,
                    Produto = new CE_Produto() { id = item.Field<Int32>("id_produto"), nome = item.Field<String>("produto") }
                    ,
                    qtdproduto = item.Field<Int32>("qtdproduto")

                });
            }

            return lista;
        }

        public void doDeletar_PorVendaID(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("DELETE FROM TB_VENDAPRODUTO WHERE id_venda =" + id);

            ExecutarComando(str.ToString());
        }

        public void doDeletarApartirDeUmID(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("DELETE FROM TB_VENDAPRODUTO WHERE id >" + id);

            ExecutarComando(str.ToString());
        }

        public int getUltimoId()
        {
            string sql = "SELECT MAX(id) as id FROM tb_vendaproduto ";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void doAlterarFuncionarioDoServico(int id, int idFuncionario)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("UPDATE tb_vendaproduto_app SET id_funcionario = "+idFuncionario);
            str.AppendLine("WHERE id ="+id);

            ExecutarComando(str.ToString());
        }

        public List<CE_VendaProduto> getListaVendaProduto(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT vp.*,f.nome funcionario,p.nome produto");
            str.AppendLine("	FROM TB_VENDAPRODUTO vp");
            str.AppendLine("    INNER JOIN TB_PRODUTO p on p.id = vp.id_produto");
            str.AppendLine("    INNER JOIN TB_FUNCIONARIO f on f.id = vp.id_funcionario");
            str.AppendLine("	WHERE vp.id_venda = " + id);

            var dt = Obter(str.ToString());

            List<CE_VendaProduto> lista = new List<CE_VendaProduto>();

            foreach (DataRow item in dt.Rows)
            {

                lista.Add(new CE_VendaProduto()
                {
                    id = item.Field<Int32>("id")
                    ,
                    Funcionario = new CE_Funcionario() { id = item.Field<Int32>("id_funcionario"), nome = item["funcionario"].ToString() }
                    ,
                    id_funcionario = item.Field<Int32>("id_funcionario")
                    ,
                    id_produto = item.Field<Int32>("id_produto")
                    ,
                    id_venda = item.Field<Int32>("id_venda")
                    ,
                    observacao = item["observacao"] == DBNull.Value ? "" : item.Field<String>("observacao")
                    ,
                    precocobrado = item.Field<double>("precocobrado")
                    ,
                    precoproduto = item.Field<double>("precoproduto")
                    ,
                    Produto = new CE_Produto() { id = item.Field<Int32>("id_produto"), nome = item.Field<String>("produto") }
                    ,
                    qtdproduto = item.Field<Int32>("qtdproduto")

                });
            }

            return lista;
        }

        public void doDeleteAll(int idVenda)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("DELETE FROM TB_VENDAPRODUTO WHERE id_venda = " + idVenda);

            ExecutarComando(str.ToString());
        }

        public void doDeleteAll_App()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("DELETE FROM TB_VENDAPRODUTO_APP");

            ExecutarComando(str.ToString());
        }
    }
}
