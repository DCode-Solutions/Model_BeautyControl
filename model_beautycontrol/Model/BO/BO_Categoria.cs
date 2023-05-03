using model_beautycontrol.Model.CE;
using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_Categoria
    {
        private DAO_Categoria dao;

        public BO_Categoria()
        {
            dao = new DAO_Categoria();
        }

        public List<CE_Categoria> getCategorias()
        {
            return dao.getCategorias();
        }

        public CE_Categoria getCategoria(int idcategoria)
        {
            return dao.getCategorias(idcategoria);
        }
    }
}
