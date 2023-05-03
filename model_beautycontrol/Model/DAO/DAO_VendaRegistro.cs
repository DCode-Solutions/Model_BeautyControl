using model_beautycontrol.Model.CL;
using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_VendaRegistro : Context
    {
        public List<CL_VendaRegistro> getVendaRegistro(DateTime data)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select  v.id venda,a.descricao tiposerviconome,v.dataservico,c.nome cliente ,v.ispago Pago,v.horainicio,v.horafim ,count(vp.id) qtdProduto,");
            str.AppendLine("       (select sum(vfp.valor) ");
            str.AppendLine("               from tb_venda v2 ");
            str.AppendLine("               inner join tb_vendaformapagamento vfp on vfp.id_venda = v2.id ");
            str.AppendLine("               where v2.id = v.id group by v2.id) valorpago,");
            str.AppendLine("        sum(vp.precocobrado * vp.qtdproduto) precocobrado,v.id_servico,        ");
            str.AppendLine("        v.desconto desconto");
            str.AppendLine("from tb_venda v");
            str.AppendLine("inner join tb_auxiliar a on a.id = v.id_servico");
            str.AppendLine("inner join tb_cliente c on c.id = v.id_cliente");
            str.AppendLine("left join tb_vendaproduto vp  on v.id = vp.id_venda");
            str.AppendLine("left join tb_produto p on p.id = vp.id_produto ");
            str.AppendLine("WHERE v.dataservico = :p_data");
            str.AppendLine("group by 1,2,4");
            str.AppendLine("order by v.ispago, v.id");

            str.Replace(":p_data", data.ToString("yyyyMMdd"));
            var dt = Obter(str.ToString());

            List<CL_VendaRegistro> lista = new List<CL_VendaRegistro>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public List<CL_VendaRegistro> getVendaRegistro_App()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT  v.id venda,a.id id_servico,v.dataservico,c.nome cliente ,a.descricao tiposerviconome,v.ispago Pago,count(vp.QTDPRODUTO) qtdProduto,");
            str.AppendLine("	(SELECT SUM(vfp.valor) ");
            str.AppendLine("                           from tb_venda_app v2 ");
            str.AppendLine("                           inner join tb_vendaformapagamento_app vfp on vfp.id_venda = v2.id ");
            str.AppendLine("                           where v2.id = v.id group by v2.id) valorpago,");
            str.AppendLine("        sum(vp.precocobrado * vp.qtdproduto) precocobrado,  ");
            str.AppendLine("        v.desconto desconto");
            str.AppendLine("   FROM tb_venda_app v");
            str.AppendLine("   INNER JOIN tb_auxiliar a on  lower(a.descricao) = lower(v.servico) and a.tipo='tiposervico' ");
            str.AppendLine("   INNER JOIN tb_cliente c on c.id = v.id_cliente");
            str.AppendLine("   LEFT JOIN tb_vendaproduto_app vp  on v.id = vp.id_venda");
            str.AppendLine("   left join tb_produto p on p.id = vp.id_produto ");
            str.AppendLine("   GROUP BY 1,2,4");
            str.AppendLine("order by v.ispago, v.dataservico");

            var dt = Obter(str.ToString());

            List<CL_VendaRegistro> lista = new List<CL_VendaRegistro>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto_App(item));
            }

            return lista;

        }

        

        public List<CL_VendaRegistro> getVendaRegistroEntreDatas(DateTime data1, DateTime data2)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select  v.id venda,a.descricao tiposerviconome,v.dataservico,c.nome cliente ,v.ispago Pago,v.horainicio,v.horafim ,count(vp.id) qtdProduto,");
            str.AppendLine("       (select sum(vfp.valor) ");
            str.AppendLine("               from tb_venda v2 ");
            str.AppendLine("               inner join tb_vendaformapagamento vfp on vfp.id_venda = v2.id ");
            str.AppendLine("               where v2.id = v.id group by v2.id) valorpago,");
            str.AppendLine("        sum(vp.precocobrado * vp.qtdproduto) precocobrado,v.id_servico,        ");
            str.AppendLine("        v.desconto desconto");
            str.AppendLine("from tb_venda v");
            str.AppendLine("inner join tb_auxiliar a on a.id = v.id_servico");
            str.AppendLine("inner join tb_cliente c on c.id = v.id_cliente");
            str.AppendLine("left join tb_vendaproduto vp  on v.id = vp.id_venda");
            str.AppendLine("left join tb_produto p on p.id = vp.id_produto ");
            str.AppendLine("WHERE v.dataservico >= :p_data1 AND v.dataservico <=:p_data2");
            str.AppendLine("group by 1,2,4");
            str.AppendLine("order by v.ispago, v.dataservico");

            str.Replace(":p_data1", data1.ToString("yyyyMMdd"));
            str.Replace(":p_data2", data2.ToString("yyyyMMdd"));
            var dt = Obter(str.ToString());

            List<CL_VendaRegistro> lista = new List<CL_VendaRegistro>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public List<CL_VendaRegistro> getVendaRegistroAberto()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select  v.id venda,a.descricao tiposerviconome,v.dataservico,c.nome cliente ,v.ispago Pago,v.horainicio,v.horafim ,count(vp.id) qtdProduto,");
            str.AppendLine("       (select sum(vfp.valor) ");
            str.AppendLine("               from tb_venda v2 ");
            str.AppendLine("               inner join tb_vendaformapagamento vfp on vfp.id_venda = v2.id ");
            str.AppendLine("               where v2.id = v.id group by v2.id) valorpago,");
            str.AppendLine("        v.desconto desconto,");
            str.AppendLine("        sum(vp.precocobrado * vp.qtdproduto) precocobrado ,v.id_servico       ");
            str.AppendLine("from tb_venda v");
            str.AppendLine("inner join tb_auxiliar a on a.id = v.id_servico");
            str.AppendLine("inner join tb_cliente c on c.id = v.id_cliente");
            str.AppendLine("left join tb_vendaproduto vp  on v.id = vp.id_venda");
            str.AppendLine("left join tb_produto p on p.id = vp.id_produto ");
            str.AppendLine("WHERE v.ispago = false");
            str.AppendLine("group by 1,2,4");
            str.AppendLine("order by v.ispago, v.id");


            var dt = Obter(str.ToString());

            List<CL_VendaRegistro> lista = new List<CL_VendaRegistro>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public List<CL_VendaRegistro> getEntradaVendaLocalDomicilioMes(DateTime data)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select  v.id venda,a.descricao tiposerviconome,v.dataservico,c.nome cliente ,v.ispago Pago,v.horainicio,v.horafim ,count(vp.id) qtdProduto,");
            str.AppendLine("       (select sum(vfp.valor) ");
            str.AppendLine("               from tb_venda v2 ");
            str.AppendLine("               inner join tb_vendaformapagamento vfp on vfp.id_venda = v2.id ");
            str.AppendLine("               where v2.id = v.id group by v2.id) valorpago,");
            str.AppendLine("        sum(vp.precocobrado * vp.qtdproduto) precocobrado,");
            str.AppendLine("        v.desconto desconto,");
            str.AppendLine("        v.id_servico    ");
            str.AppendLine("from tb_venda v");
            str.AppendLine("inner join tb_auxiliar a on a.id = v.id_servico");
            str.AppendLine("inner join tb_cliente c on c.id = v.id_cliente");
            str.AppendLine("left join tb_vendaproduto vp  on v.id = vp.id_venda");
            str.AppendLine("left join tb_produto p on p.id = vp.id_produto");
            str.AppendLine("WHERE dataservico >= :p_dtinicio AND dataservico <= :p_dtfim");
           // str.AppendLine("where (EXTRACT(month FROM (SELECT dataservico)) = ':p_mes' and ");
           // str.AppendLine("       EXTRACT(year FROM (SELECT dataservico)) = ':p_ano')");
            str.AppendLine("group by 1,2,4");
            str.AppendLine("order by v.ispago, v.id");

            str.Replace(":p_dtinicio", data.ToString("yyyyMM")+"01");
            str.Replace(":p_dtfim", data.ToString("yyyyMM")+31);

            var dt = Obter(str.ToString());

            List<CL_VendaRegistro> lista = new List<CL_VendaRegistro>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        private CL_VendaRegistro PopularObjeto_App(DataRow item)
        {
            CL_VendaRegistro result = new CL_VendaRegistro();

            result.id = item.Field<Int32>("venda");
            result.dataservico = item.Field<Int32>("dataservico");
            result.cliente = item.Field<string>("cliente");
            result.ispago = item.Field<bool>("Pago");
            result.isHabilitado = result.ispago ? false : true;
            //  result.horafim = item.Field<TimeSpan>("horafim").ToString().Substring(0, 5);
            //result.horainicio = item.Field<TimeSpan>("horainicio").ToString().Substring(0, 5);
            result.precocobrado = Utilidades.getDoubleValorDoItemDataRow(item, "precocobrado");// item.Field<double>("precocobrado");
            result.valorpago = Utilidades.getDoubleValorDoItemDataRow(item, "valorpago");
            result.qtditem = Convert.ToInt32(item["qtdproduto"]);// Utilidades.getInt64ValorDoItemDataRow(item, "qtdProduto");
            result.id_servico = item.Field<Int32>("id_servico");
            result.servico = item.Field<string>("tiposerviconome");
            result.desconto = Utilidades.getDoubleValorDoItemDataRow(item, "desconto");
            // result.precoproduto = MeusUtils.getDoubleValorDoItemDataRow(item, "precoproduto");// item.Field<double>("precoproduto");
            // result.precocobradounitario = MeusUtils.getDoubleValorDoItemDataRow(item, "precocobradounitario");

            return result;
        }

        private CL_VendaRegistro PopularObjeto(DataRow item)
        {
            CL_VendaRegistro result = new CL_VendaRegistro();

            result.id = item.Field<Int32>("venda");
            result.dataservico = item.Field<Int32>("dataservico");
            result.cliente = item.Field<string>("cliente");
            result.ispago = item.Field<bool>("Pago");
            result.isHabilitado = result.ispago ? false : true;
          //  result.horafim = item.Field<TimeSpan>("horafim").ToString().Substring(0, 5);
            //result.horainicio = item.Field<TimeSpan>("horainicio").ToString().Substring(0, 5);
            result.precocobrado = Utilidades.getDoubleValorDoItemDataRow(item, "precocobrado");// item.Field<double>("precocobrado");
            result.valorpago = Utilidades.getDoubleValorDoItemDataRow(item, "valorpago");
            result.qtditem = Convert.ToInt32(item["qtdproduto"]);// Utilidades.getInt64ValorDoItemDataRow(item, "qtdProduto");
            result.id_servico = item.Field<Int32>("id_servico");
            result.servico = item.Field<string>("tiposerviconome");
            result.desconto = Utilidades.getDoubleValorDoItemDataRow(item, "desconto");
            // result.precoproduto = MeusUtils.getDoubleValorDoItemDataRow(item, "precoproduto");// item.Field<double>("precoproduto");
            // result.precocobradounitario = MeusUtils.getDoubleValorDoItemDataRow(item, "precocobradounitario");

            return result;
        }
    }
}
