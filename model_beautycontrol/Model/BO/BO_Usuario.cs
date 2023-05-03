using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;

namespace model_beautycontrol.Model.BO
{
    public class BO_Usuario
    {
        private DAO_Usuario dao;

        public BO_Usuario()
        {
            dao = new DAO_Usuario();
        }

        public List<CE_Usuario> getUsuarios()
        {
            return dao.getUsuarios();
        }

        public void doInserir(CE_Usuario obj)
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
                throw new Exception("Ocorreu um erro na inserção: " + Utils.Utilidades.GetMensagemExcecao(ex));
            }
        }

        public void doAlterar(CE_Usuario obj)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doAlterar(obj);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw ex;
            }
        }

        public CE_Usuario getUsuario(string login , string senha)
        {
            return dao.getUsuario(login,senha);
        }

        public CE_Usuario getUsuario(string login)
        {
            return dao.getUsuario(login);
        }

        public int getID_After_Inserir(CE_Usuario usuario)
        {
            try
            {
                
                var u = getUsuario(usuario.Login) as CE_Usuario;
                if (u == null)
                    return dao.getID_After_Inserir(usuario);
                else
                    throw new Exception("Já existem um usuário cadastrado com este email!");
               
            }
            catch (Exception ex)
            {
               // dao.DesfazerTransacao();
                throw new Exception("Ops!: " + Utils.Utilidades.GetMensagemExcecao(ex));
            }
        }

        public object getUsuarioParaEnviarEmailComNovaSenha(string login,string novaSenha)
        {
            var usuario = dao.getUsuario(login) as CE_Usuario;
            usuario.Senha =novaSenha;
            doAlterar(usuario);
            usuario = getUsuario(usuario.Login, novaSenha);

            return usuario;
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
                throw new Exception("Ocorreu um erro na exclusão: " + ex.Message);
            }
        }
    }
}
