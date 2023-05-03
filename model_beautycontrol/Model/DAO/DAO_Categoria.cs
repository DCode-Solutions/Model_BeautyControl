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
    public class DAO_Categoria : Context
    {
        public List<CE_Categoria> getCategorias()
        {
            //StringBuilder str = new StringBuilder();
            //str.AppendLine("select * from tb_categoria order by nome ");
            String sql = "SELECT * " +
                             " FROM tb_categoria c ORDER BY c.nome ";

            var dt = Obter(sql);

            List<CE_Categoria> lista = (from item in dt.AsEnumerable()
                                     select new CE_Categoria
                                     {
                                         id = item.Field<Int32>("id")
                                         ,
                                         nome = item.Field<String>("nome")
                                     }
                                ).ToList();
            return lista;
        }

        public CE_Categoria getCategorias(int idcategoria)
        {
            String sql = "SELECT * " +
                             " FROM tb_categoria c WHERE c.id = "+idcategoria+" ORDER BY c.nome ";

            var dt = Obter(sql);


            List<CE_Categoria> lista = (from item in dt.AsEnumerable()
                                     select new CE_Categoria
                                     {
                                         id = item.Field<Int32>("id")
                                         ,
                                         nome = item.Field<String>("nome")
                                     }
                                ).ToList();
            return lista.FirstOrDefault();
        }
    }
}
