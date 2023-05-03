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
    public class DAO_Bairro : Context
    {
        public List<CE_Bairro> getListaBairro(int idCidade)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * ");
            str.AppendLine("from tb_bairro ");
            str.AppendLine("where id_cidade = :p_idcidade ORDER by nome");

            str.Replace(":p_idcidade", idCidade.ToString());

            var dt = Obter(str.ToString());

            List<CE_Bairro> lista = new List<CE_Bairro>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        private CE_Bairro PopularObjeto(DataRow item)
        {
            CE_Bairro result = new CE_Bairro();
            result.id = item.Field<Int32>("id");
            result.nome = item.Field<String>("nome");            

            return result;
        }
    }
}
