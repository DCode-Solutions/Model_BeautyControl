using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;

namespace model_beautycontrol.Model.BO
{
    public class BO_VendaFormaPagamento
    {
        private DAO_VendaFormaPagamento dao;

        public BO_VendaFormaPagamento()
        {
            dao = new DAO_VendaFormaPagamento();
        }

        public List<CE_VendaFormaPagamento> getPagamentosdaVenda(int id)
        {
            return dao.getPagamentosdaVenda(id);
        }

        public List<CE_VendaFormaPagamento> getPagamentosdaVenda_App(int id)
        {
            return dao.getPagamentosdaVenda_App(id);
        }

        public void doInserir(CE_VendaFormaPagamento obj)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doInserir(obj);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na inserção do pagamento: " + ex.Message);
            }
        }

        public void doDeletar(int id)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeletar(id);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na deleção do pagamento: " + ex.Message);
            }
        }

        public void doDeletarApartirDeUmID(int id)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeletarApartirDeUmID(id);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na deleção do pagamento: " + ex.Message);
            }
        }

        public void doDeletarAll_App()
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeletarAll_App();
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na deleção do pagamento: " + ex.Message);
            }
        }

        public int getUltimoId()
        {
            return dao.getUltimoId();
        }

        /// <summary>
        /// Deleta todas os pagamento de uma venda 
        /// </summary>
        /// <param name="id"></param>
        public void doDeletar_PorVendaId(int id)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeletar_PorVendaId(id);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na deleção: " + ex.Message);
            }
        }
    }
}
