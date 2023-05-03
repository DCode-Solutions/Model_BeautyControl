using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;
using System.Data;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_PerfilDeUsuario : Context
    {
        public CE_PerfilDeUsuario getPerfilMaster()
        {
            
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * from tb_perfil where prioridade = 10");

            var dt = Obter(str.ToString());

            List<CE_PerfilDeUsuario> lista = new List<CE_PerfilDeUsuario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista[0];
        }

        public List<CE_PerfilDeUsuario> getPerfis()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * from tb_perfil");

            var dt = Obter(str.ToString());

            List<CE_PerfilDeUsuario> lista = new List<CE_PerfilDeUsuario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public void doDeletar(int idempresa)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("DELETE from tb_perfil ");
            str.AppendLine("  WHERE id_empresa  = :p_idempresa");

            str.Replace(":p_idempresa", idempresa.ToString());

            ExecutarComando(str.ToString());
        }

        public List<CE_PerfilDeUsuario> getPerfisAssociadoAoUsuario(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select p.descricao,p.prioridade,p.id from tb_usuarioperfil up");
            str.AppendLine("inner join tb_perfil p on up.id_perfil = p.id");
            str.AppendLine("where id_usuario = :p_idusuario");

            str.Replace(":p_idusuario", id.ToString());

            var dt = Obter(str.ToString());

            List<CE_PerfilDeUsuario> lista = new List<CE_PerfilDeUsuario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public void doInserirPerilPadrao(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("insert into tb_perfil (descricao,prioridade,id_empresa) values");
            str.AppendLine("('Administrador Master',10,:p_id),");
            str.AppendLine("('Gerente',8,:p_id),");
            str.AppendLine("('Profissional',6,:p_id),");
            str.AppendLine("('Auxiliar',4,:p_id),");
            str.AppendLine("('Administrador',9,:p_id);");

            str.Replace(":p_id", id.ToString());

            ExecutarComando(str.ToString());
        }

        private CE_PerfilDeUsuario PopularObjeto(DataRow item)
        {
            CE_PerfilDeUsuario r = new CE_PerfilDeUsuario();
            r.id = item.Field<int>("id");            
            r.prioridade = item.Field<Int32>("prioridade");
            r.descricao = item.Field<String>("descricao");

            return r;
        }
    }
}
