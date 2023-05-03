using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;

namespace model_beautycontrol.Model.BO
{
    public class BO_Auxiliar
    {
        private DAO_Auxiliar dao;

        public BO_Auxiliar()
        {
            dao = new DAO_Auxiliar();
        }

        public CE_Auxiliar getStatus(string value)
        {
            try
            {
                return getObjetoAuxiliar(value, "status");
            }
            catch (Exception)
            {
                throw new Exception("Houve um problema na busca do status de usuario!");
            }
        }

        private CE_Auxiliar getObjetoAuxiliar(string value, string tipo)
        {
            return dao.getObjetoAuxiliar(value, tipo);
        }

        public void doInserirDadosDefault()
        {
            try
            {
                // Insere Dados nas tabelas com valores padrões se a qtd de tuplas for 0
                if (!dao.isPossuiTuplas())
                {
                    dao.IniciarTransacao();
                    dao.doInserirDadosDefault();
                    dao.FinalizarTranzacao();
                }               
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na inserção: " + Utils.Utilidades.GetMensagemExcecao(ex));
            }
        }

        
        public List<CE_Auxiliar> getListaAuxiliar(string tipo)
        {
            return dao.getListaAuxiliar(tipo);
        }

        public List<CE_Auxiliar> getListaMovimentacao(string tipo,string tipoMovimentacao)
        {
            List<CE_Auxiliar> lista = dao.getListaAuxiliar(tipo).Where(o=> o.descricao.Contains(tipoMovimentacao)).ToList();
           
            return lista;
        }

        public CE_Auxiliar getAuxiliar(int id)
        {
            return dao.getAuxiliar(id);
        }


        public void testeCreate()
        {
            dao.crete();
        }
    }
}
