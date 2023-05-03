using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.BO
{
   public class BO_VendaProduto
    {
        private DAO_VendaProduto dao;

        public BO_VendaProduto() { dao = new DAO_VendaProduto(); }

        public void doInserir(CE_VendaProduto obj)
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
                throw new Exception("Ocorreu um erro na inserção: " + ex.Message);
            }
        }

        public void doDeleteAll(int idVenda)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeleteAll(idVenda);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na exclusao: " + ex.Message);
            }
        }

        public void doDeleteAll_App()
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeleteAll_App();
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na exclusao: " + ex.Message);
            }
        }



        public List<CE_VendaProduto> getListaVendaProduto(int id)
        {
            return dao.getListaVendaProduto(id);
        }

        public List<CE_VendaProduto> getListaVendaProduto_App(int id)
        {
            return dao.getListaVendaProduto_App(id);
        }

        public void doAlterarFuncionarioDoServico(int id, int idFuncionario)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doAlterarFuncionarioDoServico(id,idFuncionario);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na alteracao do profissional do servico: " + ex.Message);
            }
        }

        public int getUltimoId()
        {
            return dao.getUltimoId();
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
                throw new Exception("Ocorreu um erro na exclusao: " + ex.Message);
            }
        }

        /// <summary>
        /// Deleta todos os produtos/servicos de uma venda
        /// </summary>
        /// <param name="id"></param>
        public void doDeletar_PorVendaID(int id)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeletar_PorVendaID(id);
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
