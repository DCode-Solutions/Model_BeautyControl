using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CL;
using System.Data;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_FuncionarioFuncao : Context
    {
        public List<CL_FuncionarioFuncao> getFuncoesAssocidasAoFuncionario(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * from tb_funcionariofuncao where id_funcionario = " + id + " order by id_funcionario,id_funcao ");

            var dt = Obter(str.ToString());

            List<CL_FuncionarioFuncao> lista = (from item in dt.AsEnumerable()
                                             select new CL_FuncionarioFuncao
                                             {
                                                 //id = item.Field<Int32>("id")
                                                 //,
                                                 idfuncao = item.Field<Int32>("id_funcao")
                                                 ,
                                                 idfuncionario = item.Field<Int32>("id_funcionario")
                                             }
                                ).ToList();

            return lista;
        }

        public void doInserir(int idfuncionario, int idfuncao)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("INSERT INTO tb_funcionariofuncao ");
            str.AppendLine("(id_funcionario");
            str.AppendLine(", id_funcao) ");

            str.AppendLine("VALUES ");
            str.AppendLine("(:p_idfuncionario");
            str.AppendLine(", :p_idfuncao)");

            str.Replace(":p_idfuncionario", idfuncionario.ToString());
            str.Replace(":p_idfuncao", idfuncao.ToString());

            ExecutarComando(str.ToString());
        }

        public void doDeleteAll(int idfuncionario)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("DELETE FROM tb_funcionariofuncao WHERE id_funcionario = " + idfuncionario);

            ExecutarComando(str.ToString());
        }
    }
}
