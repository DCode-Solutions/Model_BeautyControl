using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.BO
{
    public class BO_Venda
    {
        private DAO_Venda dao;

        public BO_Venda() { dao = new DAO_Venda(); }

        public void doInserir(CE_Venda obj)
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

        public int getIDUltimaVenda()
        {
            return dao.getUltimoId();
        }

        public int getID_After_Inserir(CE_Venda obj)
        {
            try
            {
                return dao.getID_After_Inserir(obj);
            }
            catch (Exception ex)
            {
                // dao.DesfazerTransacao();
                throw new Exception("Ops!: " + Utils.Utilidades.GetMensagemExcecao(ex));
            }
        }

        public void doDelete(int idVenda)
        {
            try
            {
                dao.IniciarTransacao();
                dao.Delete(idVenda);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na deleção: " + ex.Message);
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
                throw new Exception("Ocorreu um erro na deleção: " + ex.Message);
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
                throw new Exception("Ocorreu um erro na deleção: " + ex.Message);
            }
        }

        public CE_Venda getVenda(int id)
        {
            return dao.getVenda(id);
        }

        public void doAtualizar(CE_Venda vendaCorrente)
        {
            try
            {
                dao.IniciarTransacao();
                dao.Atualizar(vendaCorrente);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na atualização: " + ex.Message);
            }
        }

        public void doAtualizarDesconto(CE_Venda obj)
        {
            try
            {
                if (obj != null && obj.desconto >= 0)
                {
                    dao.IniciarTransacao();
                    dao.doAtualizarDesconto(obj);
                    dao.FinalizarTranzacao();
                }

            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na alteraçao do desconto: " + ex.Message);
            }
        }

        public void doFinalizarVenda(CE_Venda obj)
        {
            try
            {
                if (obj != null && obj.desconto >= 0)
                {
                    dao.IniciarTransacao();
                    dao.doFinalizarVenda(obj);
                    dao.FinalizarTranzacao();
                }

            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na finalizaçao da venda: " + ex.Message);
            }
        }

        
    }
}
