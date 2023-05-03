using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_PerfilDeUsuario
    {
        private DAO_PerfilDeUsuario dao;

        public BO_PerfilDeUsuario()
        {
            dao = new DAO_PerfilDeUsuario();
        }


        public CE_PerfilDeUsuario getPerfilMaster()
        {
            return dao.getPerfilMaster();
        }

        public void doInserirPerfilDefault(int id)
        {
            dao.doInserirPerilPadrao(id);
        }

        public List<CE_PerfilDeUsuario> getPerfis()
        {
            return dao.getPerfis();
        }

        public void doDeletar(int idempresa)
        {
            try
            {
                dao.IniciarTransacao();
                dao.doDeletar(idempresa);
                dao.FinalizarTranzacao();
            }
            catch (Exception ex)
            {
                dao.DesfazerTransacao();
                throw new Exception("Ocorreu um erro na exclusão: " + ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de perfis e marca selecionado para os perfis ao qual o usuario ja esta associado
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public List<CE_PerfilDeUsuario> getPerfisVerificados(CE_Usuario _user)
        {
            if (_user == null)
                throw new Exception("Não foi possível identificar o usuario!");

            var listaPerfilAssociado = getPerfisAssociadoAoUsuario(_user);
            var listaPerfis = getPerfis();

            foreach (var perfilUsuario in listaPerfilAssociado)
            {
                foreach (var perfil in listaPerfis)
                {
                    if(perfilUsuario.id == perfil.id)
                    {
                        perfil.isSelecionado = true;
                        break;
                    }
                }
            }

            return listaPerfis;
        }

        /// <summary>
        /// Retorna uma lista de perfis associados ao usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<CE_PerfilDeUsuario> getPerfisAssociadoAoUsuario(CE_Usuario usuario)
        {
            return dao.getPerfisAssociadoAoUsuario(usuario.id);
        }
    }
}
