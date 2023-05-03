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
    public class DAO_Cliente : Context
    {
        public List<CE_Cliente> getListaClientes()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT c.id,c.nome,c.datanascimento,c.email,c.telefone,c.celular01,c.celular02,c.celular03,c.id_sexo,c.cpf,s.descricao sexo");
            str.AppendLine("FROM tb_cliente c");
            str.AppendLine("INNER JOIN tb_auxiliar s on s.id = c.id_sexo ");
            // str.AppendLine("where id_empresa = 1");
            str.AppendLine("order by c.nome");

            var dt = Obter(str.ToString());

            List<CE_Cliente> lista = new List<CE_Cliente>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public void doAlterar(CE_Cliente obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("UPDATE tb_cliente SET");
            str.AppendLine("	nome = ':p_nome',");
            str.AppendLine("	rg = ':p_rg',cpf=':p_cpf',");

            if (obj.datanascimento != 0)
                str.AppendLine("	datanascimento = :p_datanascimento,");

            if (obj.id_bairro != 0)
                str.AppendLine("	id_bairro = :p_id_bairro,");

            if (obj.id_sexo != 0)
                str.AppendLine("	id_sexo = :p_id_sexo,");

            str.AppendLine("	email= ':p_email',");
            str.AppendLine("	telefone = ':p_telefone',");
            str.AppendLine("	celular01 = ':p_celular01',");
            str.AppendLine("	celular02 = ':p_celular02',");
            str.AppendLine("	celular03 = ':p_celular03',");
            str.AppendLine("	rua = ':p_rua',");
            str.AppendLine("	referencia = ':p_referencia',");
            str.AppendLine("	cep = ':p_cep'");

            str.AppendLine("WHERE id="+obj.id);

            str.Replace(":p_nome", obj.nome);
            str.Replace(":p_rg", obj.rg);
            str.Replace(":p_cpf", obj.cpf);
            str.Replace(":p_datanascimento", obj.datanascimento.ToString());
            str.Replace(":p_email", obj.email);
            str.Replace(":p_telefone", obj.telefone);
            str.Replace(":p_celular01", obj.celular01);
            str.Replace(":p_celular02", obj.celular02);
            str.Replace(":p_celular03", obj.celular03);
            str.Replace(":p_rua", obj.rua);
            str.Replace(":p_referencia", obj.referencia);
            str.Replace(":p_cep", obj.cep);
            str.Replace(":p_id_bairro", obj.id_bairro == 0 ? "" : obj.id_bairro.ToString());
            str.Replace(":p_id_sexo", obj.id_sexo.ToString());

            ExecutarComando(str.ToString());

        }

        public int getIdUltimoCliente()
        {
            string sql = "SELECT MAX(id) as id FROM tb_cliente ";

            DataTable dt = Obter(sql);

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public void doInserir(CE_Cliente obj)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("INSERT INTO tb_cliente(");
            str.AppendLine("nome,rg,cpf,");

            if (obj.datanascimento != 0)
                str.AppendLine("datanascimento,");

            str.AppendLine("email,telefone,celular01,celular02,celular03,rua,referencia,cep,");

            if (obj.id_bairro != 0)
                str.AppendLine("id_bairro,");

            if (obj.id_sexo != 0)
                str.AppendLine("id_sexo,");

            str.AppendLine("datainicio)");

            str.AppendLine("values(':p_nome',':p_rg',':p_cpf',");

            if (obj.datanascimento != 0)
                str.AppendLine(":p_datanascimento,");

            str.AppendLine("':p_email',':p_telefone',':p_celular01',':p_celular02',':p_celular03',':p_rua',':p_referencia',':p_cep',");

            if (obj.id_bairro != 0)
                str.AppendLine(":p_idbairro,");
            if (obj.id_sexo != 0)
                str.AppendLine(":p_idsexo,");

            str.AppendLine(":p_datainicio)");

            str.Replace(":p_nome", obj.nome);
            str.Replace(":p_rg", obj.rg);
            str.Replace(":p_cpf", obj.cpf);
            str.Replace(":p_datanascimento", obj.datanascimento.ToString());
            str.Replace(":p_datainicio", DateTime.Now.ToString("yyyyMMdd"));
            str.Replace(":p_email", obj.email);
            str.Replace(":p_telefone", obj.telefone);
            str.Replace(":p_celular01", obj.celular01);
            str.Replace(":p_celular02", obj.celular02);
            str.Replace(":p_celular03", obj.celular03);
            str.Replace(":p_rua", obj.rua);
            str.Replace(":p_referencia", obj.referencia);
            str.Replace(":p_latitude", obj.latitude.ToString());
            str.Replace(":p_longitude", obj.longitude.ToString());
            str.Replace(":p_cep", obj.cep);
            str.Replace(":p_idbairro", obj.id_bairro == 0 ? "" : obj.id_bairro.ToString());
            str.Replace(":p_idsexo", obj.id_sexo.ToString());

            ExecutarComando(str.ToString());
        }

        public CE_Cliente getClientes(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("SELECT * ");
            str.AppendLine("FROM tb_cliente c ");
            str.AppendLine(" WHERE c.id = " + id);

            var dt = Obter(str.ToString());

            List<CE_Cliente> lista = new List<CE_Cliente>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjetoAll(item));
            }

            return lista.FirstOrDefault();
        }

        private CE_Cliente PopularObjetoAll(DataRow row)
        {
            CE_Cliente result = new CE_Cliente();
            result.id = Convert.ToInt32(row["id"].ToString());
            result.nome = row.Field<String>("nome");
            result.datanascimento = row["datanascimento"] == DBNull.Value ? 0 : Convert.ToInt32(row["datanascimento"].ToString());
            result.cpf = row.Field<String>("cpf");
            result.rg = row.Field<string>("rg");
            result.celular01 = row.Field<String>("celular01");
            result.celular02 = row.Field<String>("celular02");
            result.celular03 = row.Field<String>("celular03");
            result.telefone = row.Field<String>("telefone");
            result.email = row.Field<String>("email");
            result.id_sexo = row["id_sexo"] == DBNull.Value ? 0 : Convert.ToInt32(row["id_sexo"].ToString());
            result.rua = row.Field<String>("rua");
            result.referencia = row.Field<String>("referencia");
            result.cep = row.Field<String>("cep");
            // result.latitude = row.Field<double>("latitude");
            //  result.longitude = row.Field<double>("longitude");
            result.id_bairro = row["id_bairro"] == DBNull.Value ? 0 : row.Field<Int32>("id_bairro");

            return result;
        }

        private CE_Cliente PopularObjeto(DataRow row)
        {
            CE_Cliente result = new CE_Cliente();
            result.id = Convert.ToInt32(row["id"].ToString());
            result.nome = row.Field<String>("nome");
            result.datanascimento = row["datanascimento"] == DBNull.Value ? 0 : Convert.ToInt32(row["datanascimento"]);
            result.cpf = row.Field<String>("cpf");
            result.id_sexo = Convert.ToInt32(row["id_sexo"].ToString());
            result.telefone = row.Field<String>("telefone");
            result.celular01 = row.Field<String>("celular01");
            result.celular02 = row.Field<String>("celular02");
            result.celular03 = row.Field<String>("celular03");
            result.email = row.Field<string>("email");

            CE_Auxiliar sexo = new CE_Auxiliar();
            sexo.id = result.id_sexo;
            sexo.descricao = row.Field<String>("sexo");

            result.sexo = sexo;

            return result;
        }
    }
}
