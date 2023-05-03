using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_Funcionario
    {
        private DAO_Funcionario dao;

        public BO_Funcionario()
        {
            dao = new DAO_Funcionario();
        }

        public List<CE_Funcionario> getFuncionariosProducao()
        {
            return dao.ObterFuncionariosProducao();
        }


        public List<CE_Funcionario> getProfissionais()
        {
            return dao.getFuncionarios();
        }

        public void doInserir(CE_Funcionario obj)
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

        public List<CE_Funcionario> getFuncionariosSemUsuarios()
        {
            return dao.getFuncionariosSemUsuarios();
        }

        public List<CE_Funcionario> getFuncionariosAtivos()
        {
            return dao.getFuncionariosAtivos();
        }

        public CE_Funcionario getFuncionario(int id)
        {
            return dao.getFuncionario(id);
        }

        public int getUltimoId()
        {
            return dao.getUltimoId();
        }

        /// <getSqlInsercao>
        /// Insere um novo usuario na base de dados
        /// 1. Se Somente usuario "usuario nao vinculado com funcionario" : funcionario e null
        ///    Se nao usuario "usuario é associado a um funcionario" : usuario recebe id do funcionario
        /// </getSqlInsercao>
        /// <param name="obj"></param>
        private StringBuilder getSqlInsercao(CE_Funcionario obj)
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
                str.AppendLine("p_datanascimento,");

            str.AppendLine("':p_email',@p_foto,':p_telefone',':p_celular01',':p_celular02',':p_celular03',':p_rua',':p_referencia',':p_cep',");

            if(obj.idbairro!=0)
                str.AppendLine(":p_idbairro,");
            if (obj.idsexo != 0)
                str.AppendLine(":p_idsexo,");

            str.AppendLine(":p_idvinculoatual,:p_idfuncaoprincipal,:p_idempresa)");

            str.Replace(":p_nome", obj.nome);
            str.Replace(":p_rg", obj.rg);
            str.Replace(":p_cpf", obj.cpf);
            str.Replace(":p_datanascimento",obj.datanascimento.ToString());
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
            str.Replace(":p_id_bairro", obj.idbairro == 0 ? "" : obj.idbairro.ToString());
            str.Replace(":p_id_sexo", obj.idsexo.ToString());
            str.Replace(":p_id_vinculo", obj.idvinculoatual.ToString());
            str.Replace(":p_id_empresa", obj.idempresa.ToString());
            str.Replace(":p_funcaoprincipal", obj.idfuncao.ToString());

            return str;
        }

        public void doAlterar(CE_Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
