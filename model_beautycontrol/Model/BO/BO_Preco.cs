using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DTO;
using model_beautycontrol.Utils;

namespace model_beautycontrol.Model.BO
{
    public class BO_Preco
    {
        private DAO_Preco dao;

        public BO_Preco() { dao = new DAO_Preco(); }

        public List<CE_Preco> getProdutos()
        {
            return dao.getProdutos();
        }

        public void doInserir(double preco)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doInserir(preco);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na inserção: " + ex.Message);
            }
        }

        public double getPrecoPadrao(int id)
        {
            try
            {
                return dao.getPrecoPadrao(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public CE_Preco getObj(int idproduto, CL_TipoPeriodoPreco tipo, DateTime dateTime, Double preco, string detalhe)
        {
            int ano = dateTime.Year;
            CE_Preco obj = new CE_Preco();
            if (tipo.nome.ToLower() == "mensal")
            {
                obj.datainicio = Convert.ToInt32(dateTime.ToString("yyyyMM") + "01");
                obj.datafim = Convert.ToInt32(dateTime.ToString("yyyyMM") + DateTime.DaysInMonth(dateTime.Year,dateTime.Month));
            }else if(tipo.nome.ToLower() == "período")
            {

            }else if(tipo.nome.ToLower()== "dia especial")
            {
                obj.datainicio = obj.datafim = Convert.ToInt32(dateTime.ToString("yyyyMMdd"));
            }

            obj.descricao = tipo.nome;
            obj.prioridade = tipo.prioridade;
            obj.preco = preco;
            obj.idproduto = idproduto;
            obj.detalhe = detalhe;

            return obj;
        }

        public void doInserir(CE_Preco obj)
        {
            if (obj.prioridade == 100)
                if (getContPromocaoDiaEspecialNestaData(obj.datainicio, obj.idproduto) > 0)
                    throw new Exception("Já existem uma promoção 'Dia Especial' cadastrada para este dia : " + Utilidades.getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(obj.datainicio));
            else if (obj.prioridade == 60)
                if (getContPromocaoMensalNestaData(obj.datainicio,obj.datafim,obj.idproduto) > 0)
                    throw new Exception("Já existem uma promoção 'Mensal' cadastrada para este mês de : " + System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(Convert.ToDateTime(Utilidades.getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(obj.datainicio)).Month).ToLower());
            try
            {
                dao.IniciarTransacao();
                dao.doInserir(obj);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na inserção: " + ex.Message);
            }
           
        }

        private int getContPromocaoMensalNestaData(int datainicio,int datafim,int idproduto)
        {
            return dao.getContPromocaoMensalNestaData(datainicio,datafim,idproduto);
        }

        private int getContPromocaoDiaEspecialNestaData(int datainicio,int idproduto)
        {
            return dao.getContPromocaoDiaEspecialNestaData(datainicio,idproduto);
        }
    }
}
