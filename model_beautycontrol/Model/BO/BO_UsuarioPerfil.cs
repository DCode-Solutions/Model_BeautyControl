using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_UsuarioPerfil
    {
        private DAO_UsuarioPerfil dao;

        public BO_UsuarioPerfil()
        {
            dao = new DAO_UsuarioPerfil();
        }

        public void doInserir(int idUsuario, int idPerfil)
        {
            try
            {
                dao.IniciarTransacao();
                dao.inserir(idUsuario, idPerfil);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na inserção: " + ex.Message);
            }
        }

        public int ObterPrioridadeMaximoDoUsuario(int id)
        {
            return dao.ObterPrioridadeMaximoDoUsuario(id);
        }

        public List<CE_UsuarioPerfil> ObterPerfis()
        {
            return dao.ObterPerfis();
        }

        public void doDeletaAllPerfildoUsuario(CE_Usuario usuario)
        {
            try
            {
                dao.IniciarTransacao();
                dao.deletaAllPerfildoUsuario(usuario.id);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro no delete: " + ex.Message);
            }

        }

        public List<CE_UsuarioPerfil> ObterPerfisPorIdUsuario(int id_usuario)
        {
            return dao.ObterPerfisPorIdUsuario(id_usuario);
        }

        
    }
}
