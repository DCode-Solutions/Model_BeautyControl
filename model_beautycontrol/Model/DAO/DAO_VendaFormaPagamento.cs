using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using model_beautycontrol.Model.CE;
using System.Data;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_VendaFormaPagamento : Context
    {
        public List<CE_VendaFormaPagamento> getPagamentosdaVenda(int idvenda)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * ");
            str.AppendLine("from tb_vendaformapagamento vfp");
            str.AppendLine("inner join tb_auxiliar fp on fp.id=vfp.id_formapagamento");
            str.AppendLine("where id_venda = " + idvenda);

            var dt = Obter(str.ToString());

            List<CE_VendaFormaPagamento> lista = new List<CE_VendaFormaPagamento>();

            foreach (System.Data.DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public List<CE_VendaFormaPagamento> getPagamentosdaVenda_App(int idvenda)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT vfp.id,vfp.valor,vfp.id_venda,fp.id id_formapagamento,fp.descricao ");
            str.AppendLine("FROM tb_vendaformapagamento_app vfp");
            str.AppendLine("INNER JOIN tb_auxiliar fp on fp.descricao=vfp.id_formapagamento AND fp.tipo = 'formapagamento'");
            str.AppendLine("where id_venda = " + idvenda);

            var dt = Obter(str.ToString());

            List<CE_VendaFormaPagamento> lista = new List<CE_VendaFormaPagamento>();

            foreach (System.Data.DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public void doDeletarApartirDeUmID(int id)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(" DELETE FROM tb_vendaformapagamento WHERE id >" + id);

            ExecutarComando(str.ToString());
        }

        public void doDeletarAll_App()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(" DELETE FROM tb_vendaformapagamento_app");

            ExecutarComando(str.ToString());
        }

        public void doInserir(CE_VendaFormaPagamento obj)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("INSERT INTO tb_vendaformapagamento ");
            str.AppendLine("(valor");
            str.AppendLine(", id_venda");
            str.AppendLine(", id_formapagamento) ");

            str.AppendLine("VALUES ");
            str.AppendLine("(:p_valor");
            str.AppendLine(", :p_idvenda");
            str.AppendLine(", :p_idformapagamento) ");


            str.Replace(":p_valor", obj.valor.ToString().Replace(",", "."));
            str.Replace(":p_idvenda", obj.id_venda.ToString());
            str.Replace(":p_idformapagamento", obj.id_formapagamento.ToString());

            ExecutarComando(str.ToString());
        }

        public void doDeletar_PorVendaId(int id)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(" DELETE FROM tb_vendaformapagamento WHERE id_venda =" + id);

            ExecutarComando(str.ToString());
        }

        public int getUltimoId()
        {
            string sql = "SELECT MAX(id) as id FROM tb_vendaformapagamento ";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void doDeletar(int id)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(" DELETE FROM tb_vendaformapagamento WHERE id =" + id);

            ExecutarComando(str.ToString());
        }

        public void deletar(int id)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(" DELETE FROM tb_vendaformapagamento WHERE id =" + id);

            ExecutarComando(str.ToString());
        }

        private CE_VendaFormaPagamento PopularObjeto(DataRow item)
        {
            CE_VendaFormaPagamento result = new CE_VendaFormaPagamento();
            result.id = item.Field<Int32>("id");
            result.valor = item.Field<double>("valor");
            result.id_venda = item.Field<Int32>("id_venda");
            result.id_formapagamento = item.Field<Int32>("id_formapagamento");

            CE_Auxiliar formapagamento = new CE_Auxiliar();
            formapagamento.id = result.id_formapagamento;
            formapagamento.descricao = item.Field<string>("descricao");

            result.FormaPagamento = formapagamento;

            return result;
        }
    }
}
