using model_beautycontrol.Model.BO;
using model_beautycontrol.Model.CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.DOM
{
    public class DOM_Seguranca
    {
        public DOM_Seguranca()
        {
            boFuncionario = new BO_Funcionario();
            boAuxiliar = new BO_Auxiliar();
            boPerfil = new BO_PerfilDeUsuario();
            boUsuario = new BO_Usuario();
            boUsuarioPerfil = new BO_UsuarioPerfil();
            boEmpresa = new BO_Empresa();
        }

        private BO_Funcionario boFuncionario;
        private BO_Auxiliar boAuxiliar;
        private BO_PerfilDeUsuario boPerfil;
        private BO_Usuario boUsuario;
        private BO_UsuarioPerfil boUsuarioPerfil;
        private BO_Empresa boEmpresa;

        /// <summary>
        /// Cadastra um novo usuario no sistema na tabela de usuarios <para/>
        /// Para cada perfil selecionado, sera associado ao usuario que esta sendo inseirdo na base 
        /// Inserindo o idusario + idPerfil na tabela UsuarioPerfil
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="listaPerfisMarcados"></param>
        public void doInserirNovoUsuario(CE_Usuario usuario, List<CE_PerfilDeUsuario> listaPerfisMarcados)
        {
            usuario.Status = boAuxiliar.getStatus("Ativo");
            usuario.id_status = usuario.Status.id;

            int idUsuario = boUsuario.getID_After_Inserir(usuario);

            foreach (var item in listaPerfisMarcados)
            {
               boUsuarioPerfil.doInserir(idUsuario, item.id);
            }
        }

       
        /// <summary>
        /// Atualiza o usuario se houve mudanças<para/>
        /// Deleta todos os perfis associados ao usuario
        /// <para/>
        /// Insere usuario perfil selecionados 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="listaPerfisMarcados"></param>
        /// <param name="isUsuarioAlterado"></param>
        public void doAlterarUsuario(CE_Usuario usuario, List<CE_PerfilDeUsuario> listaPerfisMarcados, bool isUsuarioAlterado)
        {
            if (isUsuarioAlterado)
                boUsuario.doAlterar(usuario);

            // Excluir usuario perfil 
            boUsuarioPerfil.doDeletaAllPerfildoUsuario(usuario);

            foreach (var item in listaPerfisMarcados)
            {
                boUsuarioPerfil.doInserir(usuario.id, item.id);
            }
        }

        

        /// <doInserirEmpresaComUsuarioMaster>
        /// 1 Este metodo é acionado quando o programa roda pel primeira vez ou quando nao existir na base uma empresa
        /// 2.Insere a empresa na base retornando o seu id de cadastro
        /// 3. Insere na base os perfis padrão para a empresa inserida
        /// 4. Recupera um perfil Master : pois o primeiro usuario desta empresa deve possuir ou ser um usuario master
        /// 5. Recupera o status de usuario do Tipo Ativo: pois o primeiro usuario do sistema deve possuir um status ativo
        /// 6. Insere o usuario na base retornando o id de cadastro
        /// 7. Insere na base o usuario - perfil; numa tabela onde é guarda todos os perfis que o usuario possui no sistema
        /// </doInserirEmpresaComUsuarioMaster>
        /// <param name="empresa">Empresa</param>
        /// <param name="usuario">Usuario</param>
        public void doInserirEmpresaComUsuarioMaster(CE_Empresa empresa,ref CE_Usuario usuario)
        {
            try
            {
                empresa.id = boEmpresa.getID_After_Inserir(empresa);

                boPerfil.doInserirPerfilDefault(empresa.id);
                var perfil = boPerfil.getPerfilMaster();

                usuario.Status = boAuxiliar.getStatus("Ativo");
                usuario.id_status = usuario.Status.id;
                usuario.id = boUsuario.getID_After_Inserir(usuario);

                boUsuarioPerfil.doInserir(usuario.id, perfil.id);
            }
            catch (Exception ex)
            {
                /* Caso ocorra uma excessao Verifica se a empresa possui um id diferente de 0
                 * Caso isso ocorrer significa que houve uma excessao depois que a empresa ja foi cadastrada
                 * Com isso a empresa sera removida da base com seus devidos perfis associados a ela
                 * O mesmo acontece para o usuario
                 */
                if (empresa.id != 0)
                {
                    boPerfil.doDeletar(empresa.id);
                    boEmpresa.doDeletar(empresa.id);
                }

                if (usuario.id != 0)
                    boUsuario.doDeletar(usuario.id);
                
                throw new Exception(Utils.Utilidades.GetMensagemExcecao(ex));
            }
            
        }

        public List<CE_PerfilDeUsuario> getPerfisAssociadoAoUsuario(CE_Usuario usuario)
        {
            List<CE_PerfilDeUsuario> lista = boPerfil.getPerfisAssociadoAoUsuario(usuario);

            return lista;
        }

        public void doMudarStatusUsuario(CE_Usuario usuario, string statusSelecionado)
        {
            // Pega da base informaçao como o id do campo selecionado para atualizar o status do usuario
            usuario.Status = boAuxiliar.getStatus(statusSelecionado);
            usuario.id_status = usuario.Status.id;

            boUsuario.doAlterar(usuario);
        }
    }
}
