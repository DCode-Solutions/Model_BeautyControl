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
    public class DAO_Fornecedor : Context
    {
        public void doInserir(CE_Fornecedor obj)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("INSERT INTO TB_FORNECEDOR (NOME,RAZAOSOCIAL,TELEFONE,CELULAR01,CELULAR02,");
                str.AppendLine("			               CELULAR03,EMAIL,CEP,RUA,REFERENCIA,ID_BAIRRO,");
                str.AppendLine("			               SITE,CNPJ,INSCRICAOESTADUAL,INSCRICAOMUNICIPAL)");
                str.AppendLine("	           VALUES (':p_nome',':p_razaosocial',':p_telefone',':p_celular01',':p_celular02',");
                str.AppendLine("	                   ':p_celular03',':p_email',':p_cep',':p_rua',':p_referencia',:p_idbairro,");
                str.AppendLine("	                   ':p_site',':p_cnpj',':p_inscricaoestadual',':p_inscricaomunicipal')");

                str.Replace(":p_nome", obj.nome);
                str.Replace(":p_razaosocial", obj.razaosocial);
                str.Replace(":p_telefone", obj.telefone);
                str.Replace(":p_celular01", obj.celular01);
                str.Replace(":p_celular02", obj.celular02);//obj.ce == 0 ? "null" : obj.codigobarra.ToString());//obj.codigobarra == 0 ? "" : obj.id_bairro.ToString());
                str.Replace(":p_celular03", obj.celular03);
                str.Replace(":p_email", obj.email);
                str.Replace(":p_rua", obj.rua);
                str.Replace(":p_referencia", obj.referencia);
                str.Replace(":p_idbairro", obj.id_bairro == 0 ? "" : obj.id_bairro.ToString());
                str.Replace(":p_site", obj.site);
                str.Replace(":p_cep", obj.cep);
                str.Replace(":p_cnpj", obj.cnpj);
                str.Replace(":p_inscricaoestadual", obj.inscricaoestadual);
                str.Replace(":p_inscricaomunicipal", obj.inscricaomunicipal);

                ExecutarComando(str.ToString());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<CE_Fornecedor> getListaFornecedores0()
        {
            throw new NotImplementedException();
        }

        public List<CE_Fornecedor> getListaFornecedores1()
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("SELECT ID,NOME,RUA,CNPJ FROM TB_FORNECEDOR");


                var dt = Obter(str.ToString());

                List<CE_Fornecedor> lista = new List<CE_Fornecedor>();

                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(new CE_Fornecedor()
                    {
                        id = Convert.ToInt32(item["id"].ToString())
                                    ,
                        nome = item["nome"].ToString()
                                    ,
                        rua = item["rua"].ToString()
                                    ,
                        cnpj = item["cnpj"].ToString()
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
