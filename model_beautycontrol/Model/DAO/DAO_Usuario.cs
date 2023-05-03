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
    public class DAO_Usuario : Context
    {
        public List<CE_Usuario> getUsuarios()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select u.id,u.login,u.senha,a.descricao,u.id_status,f.nome,u.id_funcionario");
            str.AppendLine("from tb_usuario u");
            str.AppendLine("inner join tb_auxiliar a on a.id = u.id_status");
            str.AppendLine("left join tb_funcionario f on f.id = u.id_funcionario");

            var dt = Obter(str.ToString());

            List<CE_Usuario> lista = new List<CE_Usuario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto02(item));
            }

            return lista;
        }

        public void doAlterar(CE_Usuario obj)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("UPDATE tb_usuario SET ");
            str.AppendLine("  login = ':p_login', ");
            str.AppendLine("  senha = ':p_senha'");
            str.AppendLine("  WHERE id  = :p_id");

            str.Replace(":p_login", obj.Login);
            str.Replace(":p_senha", obj.Senha);
            str.Replace(":p_id", obj.id.ToString());

            ExecutarComando(str.ToString());
        }
        
        private CE_Usuario PopularObjeto01(DataRow item)
        {
            CE_Usuario result = new CE_Usuario();
            result.id = item.Field<Int32>("id");
            result.Login = item.Field<string>("login");
            result.Senha =item.Field<string>("senha");

            //result.id_status = item.Field<Int32>("id_status");

            result.id_funcionario = Utilidades.getInt32ValorDoItemDataRow(item, "id_funcionario");

            return result;
        }

        public void doInserir(CE_Usuario obj)
        {
            StringBuilder str = getSqlInsercao(obj);

            ExecutarComando(str.ToString());
        }

        public void doDeletar(int id)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("DELETE from tb_usuario ");
            str.AppendLine("  WHERE id  = :p_id");

            str.Replace(":p_id", id.ToString());

            ExecutarComando(str.ToString());
        }

        public CE_Usuario getUsuario(string email)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT *");
            str.AppendLine("FROM tb_usuario u");
            str.AppendLine("WHERE u.login = '"+email+"'");

            var dt = Obter(str.ToString());

            List<CE_Usuario> lista = new List<CE_Usuario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto01(item));
            }

            return lista.FirstOrDefault();
        }

        public int getID_After_Inserir(CE_Usuario obj)
        {
            StringBuilder str = getSqlInsercao(obj);
            //str.Replace(")", " RETURNING id)");
            str.AppendLine("RETURNING id");

            DataTable dt = Obter(str.ToString());

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void alterar(CE_Usuario obj)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("UPDATE tb_CE_Usuario SET ");
            str.AppendLine("  login = ':p_login', ");
            str.AppendLine("  senha = ':p_senha'");
            str.AppendLine("  WHERE id  = :p_id");

            str.Replace(":p_login", obj.Login);
            str.Replace(":p_senha", obj.Senha);
            str.Replace(":p_id", obj.id.ToString());

            ExecutarComando(str.ToString());
        }

        private CE_Usuario PopularObjeto02(DataRow item)
        {
            CE_Usuario result = new CE_Usuario();
            result.id = item.Field<Int32>("id");
            result.Login = item.Field<string>("login");
            result.id_funcionario = item["id_funcionario"] == DBNull.Value ? 0 : item.Field<Int32>("id_funcionario");
            // result.id_status = item["id_status"] == DBNull.Value ? 0 : item.Field<Int32>("id_status");
            // result.Senha = item.Field<string>("senha");

            CE_Auxiliar a = new CE_Auxiliar();
            a.id = item["id_status"] == DBNull.Value ? 0 : item.Field<Int32>("id_status");
            a.descricao = item.Field<string>("descricao");

            result.Status = a;

            CE_Funcionario f = new CE_Funcionario();
            if (String.IsNullOrEmpty(item.Field<string>("nome")))
            {
                f.nome = "Somente usuário";
            }
            else
            {
                f.id = result.id_funcionario;
                f.nome = item.Field<string>("nome");
            }

            result.Funcionario = f;

            return result;
        }

        public CE_Usuario getUsuario(string login, string senha)
        {

            StringBuilder str = new StringBuilder();
            str.AppendLine("");
            str.AppendLine("select u.id,u.login,u.id_status,u.id_funcionario,a.descricao, f.nome,f.email,f.id_funcaoprincipal");
            str.AppendLine("from tb_usuario u");
            str.AppendLine("inner join tb_auxiliar a on u.id_status = a.id");
            str.AppendLine("left join tb_funcionario f on u.id_funcionario = f.id");
            str.AppendLine("where u.login = ':p_login' and u.senha = ':p_senha'");

            str.Replace(":p_login", login);
            str.Replace(":p_senha", senha);

            var dt = Obter(str.ToString());

            List<CE_Usuario> lista = new List<CE_Usuario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto02(item));
            }

            return lista.FirstOrDefault();
        }

        public int ObterUltimoId()
        {
            string sql = "SELECT MAX(id) as id FROM tb_CE_Usuario ";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        /// <getSqlInsercao>
        /// Insere um novo usuario na base de dados
        /// 1. Se Somente usuario "usuario nao vinculado com funcionario" : funcionario e null
        ///    Se nao usuario "usuario é associado a um funcionario" : usuario recebe id do funcionario
        /// </getSqlInsercao>
        /// <param name="obj"></param>
        private StringBuilder getSqlInsercao(CE_Usuario obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("insert into tb_usuario(");
            str.AppendLine("login,senha,id_status,id_funcionario) ");
            str.AppendLine("values(':p_login',':p_senha',:p_idstatus,:p_idfuncionario ) ");

            str.Replace(":p_login", obj.Login);
            str.Replace(":p_senha", obj.Senha);
            str.Replace(":p_idstatus", obj.id_status.ToString());
            if (obj.id_funcionario == 0)
            {
                str.Replace(":p_idfuncionario", "null");
            }
            else
            {
                str.Replace(":p_idfuncionario", obj.id_funcionario.ToString());
            }

            return str;
        }

    }
}
