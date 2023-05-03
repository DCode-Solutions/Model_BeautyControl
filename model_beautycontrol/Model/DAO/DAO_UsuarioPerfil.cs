using model_beautycontrol.Model.CE;
using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_UsuarioPerfil : Context
    {
        public int ObterPrioridadeMaximoDoUsuario(int idusuario)
        {
            string sql = "SELECT MAX(p.prioridade) as prioridade FROM tb_usuarioperfil up inner join tb_perfil p on p.id=up.id_perfil where up.id_usuario = " + idusuario;

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void inserir(int idUsuario, int idPerfil)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("INSERT INTO tb_usuarioperfil ");
            str.AppendLine("(id_usuario");
            str.AppendLine(", id_perfil) ");

            str.AppendLine("VALUES ");
            str.AppendLine("(:p_idusuario");
            str.AppendLine(", :p_idperfil)");

            str.Replace(":p_idusuario", idUsuario.ToString());
            str.Replace(":p_idperfil", idPerfil.ToString());

            ExecutarComando(str.ToString());
        }

        public List<CE_UsuarioPerfil> ObterPerfis()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * from tb_usuarioperfil up ");
            str.AppendLine("inner join tb_perfil p on p.id=up.id_perfil ");

            var dt = Obter(str.ToString());

            List<CE_UsuarioPerfil> lista = (from item in dt.AsEnumerable()
                                         select new CE_UsuarioPerfil
                                         {
                                             id_usuario = item.Field<Int32>("id_usuario"),
                                             id_perfil = item.Field<Int32>("id_perfil"),
                                             perfil = new CE_PerfilDeUsuario()
                                             {
                                                 id = item.Field<Int32>("id_perfil"),
                                                 descricao = item.Field<string>("descricao"),
                                                 prioridade = item.Field<Int32>("prioridade")
                                             }
                                         }
                                ).ToList();
            return lista;


        }

        public List<CE_UsuarioPerfil> ObterPerfisPorIdUsuario(int id_usuario)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * from tb_usuarioperfil up ");
            str.AppendLine("inner join tb_perfil p on p.id=up.id_perfil ");
            str.AppendLine("where up.id_usuario = " + id_usuario);

            var dt = Obter(str.ToString());

            List<CE_UsuarioPerfil> lista = (from item in dt.AsEnumerable()
                                         select new CE_UsuarioPerfil
                                         {
                                             id_usuario = item.Field<Int32>("id_usuario"),
                                             id_perfil = item.Field<Int32>("id_perfil"),
                                             perfil = new CE_PerfilDeUsuario()
                                             {
                                                 id = item.Field<Int32>("id_perfil"),
                                                 descricao = item.Field<string>("descricao"),
                                                 prioridade = item.Field<Int32>("prioridade")
                                             }
                                         }
                                ).ToList();
            return lista;
        }

        public void deletaAllPerfildoUsuario(int id)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("DELETE FROM tb_usuarioperfil WHERE id_usuario = " + id);

            ExecutarComando(str.ToString());
        }
    }
}
