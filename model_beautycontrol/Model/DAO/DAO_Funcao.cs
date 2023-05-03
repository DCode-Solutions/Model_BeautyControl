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
    public class DAO_Funcao : Context
    {
        public List<CE_Funcao> getListaFuncao()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * ");
            str.AppendLine("from tb_funcao ORDER BY nome");

            var dt = Obter(str.ToString());

            List<CE_Funcao> lista = new List<CE_Funcao>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        private CE_Funcao PopularObjeto(DataRow item)
        {
            CE_Funcao result = new CE_Funcao();
            result.id = item.Field<Int32>("id");
            result.nome = item.Field<String>("nome");
            result.descricao = item.Field<String>("descricao");

            return result;
        }
    }
}
