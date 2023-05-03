using model_beautycontrol.Model.CL;
using model_beautycontrol.Model.DAO;
using model_beautycontrol.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_VendaRegistro
    {
        private DAO_VendaRegistro dao;

        public BO_VendaRegistro()
        {
            dao = new DAO_VendaRegistro();
        }

        public List<CL_VendaRegistro> getVendaRegistro(DateTime dt)
        {
            return dao.getVendaRegistro(dt);
        }

        public List<CL_VendaRegistro> getVendaRegistroEntreDatas(DateTime dateTime1, DateTime dateTime2)
        {
            return dao.getVendaRegistroEntreDatas(dateTime1, dateTime2);
        }

        public List<CL_VendaRegistro> getVendaRegistro_App()
        {
            return dao.getVendaRegistro_App();
        }

        public List<CL_VendaRegistro> getVendaRegistroAberto()
        {
            return dao.getVendaRegistroAberto();
        }



        public List<CL_VendaRegistro> getVendaRegistroLocal(List<CL_VendaRegistro> list)
        {
            List<CL_VendaRegistro> lista = list.Count > 0
                                ? (from x in list where x.servico.ToUpper() == "LOCAL" select x).ToList()
                                : new List<CL_VendaRegistro>();

            return lista;
        }

        public List<GraficoStringInt> getEntradaVendaLocalDomicilioMes(DateTime dateTime)
        {
            List<GraficoStringInt> lista = new List<GraficoStringInt>();
            var vendas = dao.getEntradaVendaLocalDomicilioMes(dateTime);
            double valor = 0;

            valor = vendas.Where(o => o.servico.ToUpper() == "LOCAL").Sum(o => (o.valorpago));
            lista.Add(new GraficoStringInt("LOCAL", valor));

            valor = vendas.Where(o => o.servico.ToUpper() == "DOMICÍLIO").Sum(o => (o.valorpago));
            lista.Add(new GraficoStringInt("DOMÍCILIO", valor));

            return lista;
        }

        public List<CL_VendaRegistro> getVendaRegistroDomicilio(List<CL_VendaRegistro> list)
        {
            List<CL_VendaRegistro> lista = list.Count > 0
                                ? (from x in list where x.servico.ToUpper() == "DOMICÍLIO" select x).ToList()
                                : new List<CL_VendaRegistro>();

            return lista;
        }

        //public List<AuxiliarGraficoStringInt> getTotalVendaLocalDomicilio(ObservableCollection<CL_VendaRegistro> vendaregistros)
        //{
        //    List<AuxiliarGraficoStringInt> lista = new List<AuxiliarGraficoStringInt>();
        //    int qtd = 0;
        //    AuxiliarGraficoStringInt item;

        //    qtd = (from x in vendaregistros where x.tiposerviconome.ToUpper() == "LOCAL" select x).Count();
        //    item = new AuxiliarGraficoStringInt("Local", qtd);
        //    lista.Add(item);

        //    qtd = (from x in vendaregistros where x.tiposerviconome.ToUpper() == "DOMICÍLIO" select x).Count();
        //    item = new AuxiliarGraficoStringInt("Domicílio", qtd);
        //    lista.Add(item);

        //    return lista;
        //}

        //public List<AuxiliarGraficoStringInt> getEntradaVendaLocalDomicilioMes(DateTime dateTime)
        //{
        //    List<AuxiliarGraficoStringInt> lista = new List<AuxiliarGraficoStringInt>();
        //    var vendas = dao.getEntradaVendaLocalDomicilioMes(dateTime);
        //    double valor = 0;

        //    valor = vendas.Where(o => o.tiposerviconome.ToUpper() == "LOCAL").Sum(o => (o.valorpago));
        //    lista.Add(new AuxiliarGraficoStringInt("LOCAL", valor));

        //    valor = vendas.Where(o => o.tiposerviconome.ToUpper() == "DOMICÍLIO").Sum(o => (o.valorpago));
        //    lista.Add(new AuxiliarGraficoStringInt("DOMÍCILIO", valor));

        //    return lista;
        //}


    }
}
