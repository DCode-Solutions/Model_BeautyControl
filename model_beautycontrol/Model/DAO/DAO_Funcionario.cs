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
    public class DAO_Funcionario : Context
    {
        public void doInserir(CE_Funcionario obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO tb_funcionario(");
            //str.AppendLine("nome,rg,cpf,email,foto,telelogin,senha,id_status,id_funcionario) ");
            str.AppendLine("nome,rg,cpf,");

            if (obj.datanascimento != 0)
                str.AppendLine("datanascimento,");

            str.AppendLine("email,foto,telefone,celular01,celular02,celular03,rua,referencia,cep,");

            if (obj.idbairro != 0)
                str.AppendLine("id_bairro,");

            if (obj.idsexo != 0)
                str.AppendLine("id_sexo,");

            str.AppendLine("id_vinculoatual,id_funcaoprincipal,id_empresa)");

            str.AppendLine("values(':p_nome',':p_rg',':p_cpf',");

            if (obj.datanascimento != 0)
                str.AppendLine(":p_datanascimento,");

            str.AppendLine("':p_email',@p_foto,':p_telefone',':p_celular01',':p_celular02',':p_celular03',':p_rua',':p_referencia',':p_cep',");

            if (obj.idbairro != 0)
                str.AppendLine(":p_idbairro,");
            if (obj.idsexo != 0)
                str.AppendLine(":p_idsexo,");

            str.AppendLine(":p_idvinculoatual,:p_idfuncaoprincipal,:p_idempresa)");

            str.Replace(":p_nome", obj.nome);
            str.Replace(":p_rg", obj.rg);
            str.Replace(":p_cpf", obj.cpf);
            str.Replace(":p_datanascimento", obj.datanascimento.ToString());
            str.Replace(":p_email", obj.email);
            str.Replace(":p_telefone", obj.telefone01);
            str.Replace(":p_celular01", obj.celular01);
            str.Replace(":p_celular02", obj.celular02);
            str.Replace(":p_celular03", obj.celular03);
            str.Replace(":p_rua", obj.rua);
            str.Replace(":p_referencia", obj.referencia);
            str.Replace(":p_latitude", obj.latitude.ToString());
            str.Replace(":p_longitude", obj.longitude.ToString());
            str.Replace(":p_cep", obj.cep);
            str.Replace(":p_idbairro", obj.idbairro == 0 ? "" : obj.idbairro.ToString());
            str.Replace(":p_idsexo", obj.idsexo.ToString());
            str.Replace(":p_idvinculoatual", obj.idvinculoatual.ToString());
            str.Replace(":p_idempresa", obj.idempresa.ToString());
            str.Replace(":p_idfuncaoprincipal", obj.idfuncao.ToString());

            List<DTO.ImagemParametroToCmdSql> listaParamentrosByte = new List<DTO.ImagemParametroToCmdSql>();
            listaParamentrosByte.Add(new DTO.ImagemParametroToCmdSql("@p_foto", obj.foto));

            ExecutarComandoComImagem(str.ToString(), listaParamentrosByte);
        }

        public List<CE_Funcionario> getFuncionariosAtivos()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("");
            str.AppendLine("select f.id,f.nome,f.datanascimento,f.foto,f.id_sexo,f.id_vinculo,");
            str.AppendLine("       f.cpf,f.id_empresa,f.id_funcaoprincipal, s.descricao sexo,");
            str.AppendLine("       v.descricao vinculo, funcao.nome funcaoprincipal");
            str.AppendLine("from tb_funcionario f");
            str.AppendLine("inner join tb_auxiliar v on v.id = f.id_vinculo");
            str.AppendLine("inner join tb_auxiliar s on s.id = f.id_sexo");
            str.AppendLine("inner join tb_funcao funcao on funcao.id = f.id_funcaoprincipal");
            str.AppendLine("where v.tipo = 'vinculo' and (v.descricao = 'Efetivo' or v.descricao ='Temporário')  and f.datainicio > datafim and f.id not in (select id_funcionario from tb_usuario u ");
            str.AppendLine("inner join tb_funcionario f on f.id = u.id_funcionario)");


            var dt = Obter(str.ToString());

            List<CE_Funcionario> lista = new List<CE_Funcionario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public List<CE_Funcionario> getFuncionariosSemUsuarios()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("");
            str.AppendLine("SELECT f.id,f.nome,f.datanascimento,f.foto,f.id_sexo,f.id_vinculoatual,");
            str.AppendLine("       f.cpf,f.id_empresa,f.id_funcaoprincipal, s.descricao sexo,");
            str.AppendLine("       v.descricao vinculo, funcao.nome funcaoprincipal");
            str.AppendLine("FROM tb_funcionario f ");
            str.AppendLine("INNER JOIN tb_auxiliar v on v.id = f.id_vinculoatual");
            str.AppendLine("INNER JOIN tb_auxiliar s on s.id = f.id_sexo");
            str.AppendLine("INNER JOIN tb_funcao funcao on funcao.id = f.id_funcaoprincipal");
            str.AppendLine("INNER JOIN tb_periodoassociado p ON f.id =  p.id_funcionario");
            str.AppendLine("WHERE f.id not in (SELECT id_funcionario FROM tb_usuario u");
            str.AppendLine("                                         INNER JOIN tb_funcionario f on f.id = u.id_funcionario)");



            var dt = Obter(str.ToString());

            List<CE_Funcionario> lista = new List<CE_Funcionario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public int getUltimoId()
        {
            string sql = "SELECT MAX(id) as id FROM tb_funcionario ";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public CE_Funcionario getFuncionario(int id_funcionario)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * ");
            str.AppendLine("from tb_funcionario f ");
            str.AppendLine(" where f.id = " + id_funcionario);

            var dt = Obter(str.ToString());

            List<CE_Funcionario> lista = new List<CE_Funcionario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjetoAll(item));
            }

            return lista.FirstOrDefault();
        }

        private CE_Funcionario PopularObjetoAll(DataRow row)
        {
            CE_Funcionario result = new CE_Funcionario();
            result.id = Convert.ToInt32(row["id"].ToString());
            result.nome = row.Field<String>("nome");
            result.datanascimento = row["datanascimento"] == DBNull.Value ? 0 : Convert.ToInt32(row["datanascimento"].ToString());
            result.cpf = row.Field<String>("cpf");
            result.rg = row.Field<string>("rg");
            result.celular01 = row.Field<String>("celular01");
            result.celular02 = row.Field<String>("celular02");
            result.celular03 = row.Field<String>("celular03");
            result.telefone01 = row.Field<String>("telefone");
            result.email = row.Field<String>("email");
            result.idsexo = row["id_sexo"] == DBNull.Value ? 0 : Convert.ToInt32(row["id_sexo"].ToString());
            result.idvinculoatual = row["id_vinculoatual"] == DBNull.Value ? 0 : Convert.ToInt32(row["id_vinculoatual"].ToString());
            result.idempresa = row["id_empresa"] == DBNull.Value ? 0 : Convert.ToInt32(row["id_empresa"].ToString());
            result.idfuncao = row["id_funcaoprincipal"] == DBNull.Value ? 0 : Convert.ToInt32(row["id_funcaoprincipal"].ToString());
            var fotoX = row["foto"];
            result.foto = fotoX as byte[];

            result.rua = row.Field<String>("rua");
            result.referencia = row.Field<String>("referencia");
            result.cep = row.Field<String>("cep");
            // result.latitude = row.Field<double>("latitude");
            //  result.longitude = row.Field<double>("longitude");
            result.idbairro = row["id_bairro"] == DBNull.Value ? 0 : row.Field<Int32>("id_bairro");

            return result;
        }

        public int ObterUltimoId()
        {
            string sql = "SELECT MAX(id) as id FROM tb_funcionario ";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        /// <getSqlInsercao>
        /// Insere um novo funcionario na base de dados
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


        public List<CE_Funcionario> ObterFuncionariosProducao()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("select distinct on(fu.id) fu.*");
                str.AppendLine("from tb_funcionariofuncao ff");
                str.AppendLine("inner join tb_funcao fc on fc.id = ff.id_funcao");
                str.AppendLine("inner join tb_departamento d on d.id = fc.id_departamento");
                str.AppendLine("inner join tb_funcionario fu on fu.id = ff.id_funcionario");
                str.AppendLine("where d.sigla = 'PDC'");

                var dt = Obter(str.ToString());

                List<CE_Funcionario> lista = new List<CE_Funcionario>();

                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(PopularObjetoAll(item));
                }

                return lista;
            }
            catch (Exception)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("select distinct fu.*");
                str.AppendLine("from tb_funcionariofuncao ff");
                str.AppendLine("inner join tb_funcao fc on fc.id = ff.id_funcao");
                str.AppendLine("inner join tb_departamento d on d.id = fc.id_departamento");
                str.AppendLine("inner join tb_funcionario fu on fu.id = ff.id_funcionario");
                str.AppendLine("where d.sigla = 'PDC'");

                var dt = Obter(str.ToString());

                List<CE_Funcionario> lista = new List<CE_Funcionario>();

                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(PopularObjetoAll(item));
                }

                return lista;
            }
        }

        public List<CE_Funcionario> getFuncionarios()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select f.id,f.nome,f.datanascimento,f.foto,f.id_sexo,f.id_vinculoatual,f.cpf,f.id_empresa,f.id_funcaoprincipal, s.descricao sexo,v.descricao vinculo, funcao.nome funcaoprincipal");
            str.AppendLine("from tb_funcionario f");
            str.AppendLine("inner join tb_auxiliar s on s.id = f.id_sexo");
            str.AppendLine("inner join tb_auxiliar v on v.id = f.id_vinculoatual");
            str.AppendLine("inner join tb_funcao funcao on funcao.id = f.id_funcaoprincipal");
          //  str.AppendLine("where id_empresa =" + idempresa + " order by f.nome;");


            var dt = Obter(str.ToString());

            List<CE_Funcionario> lista = new List<CE_Funcionario>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        private CE_Funcionario PopularObjeto(DataRow row)
        {
            CE_Funcionario result = new CE_Funcionario();
            result.id = Convert.ToInt32(row["id"].ToString());
            result.nome = row.Field<String>("nome");
            result.datanascimento = row["datanascimento"] == DBNull.Value ? new Nullable<Int32>() : Convert.ToInt32(row["datanascimento"].ToString());
            result.cpf = row.Field<String>("cpf");
            result.idsexo = Convert.ToInt32(row["id_sexo"].ToString());
            result.idvinculoatual = Convert.ToInt32(row["id_vinculoatual"].ToString());
            result.idempresa = Convert.ToInt32(row["id_empresa"].ToString());
            result.idfuncao = Convert.ToInt32(row["id_funcaoprincipal"].ToString());
            var fotoX = row["foto"];
            result.foto = fotoX as byte[];

            CE_Auxiliar sexo = new CE_Auxiliar();
            sexo.id = result.idsexo;
            sexo.descricao = row.Field<String>("sexo");

            CE_Auxiliar vinculo = new CE_Auxiliar();
            vinculo.id = result.idvinculoatual;
            vinculo.descricao = row.Field<String>("vinculo");

            CE_Funcao funcao = new CE_Funcao();
            funcao.id = result.idfuncao;
            funcao.nome = row.Field<String>("funcaoprincipal");

            result.sexo = sexo;
            result.vinculoatual = vinculo;
            result.funcao = funcao;

            return result;
        }
    }
}
