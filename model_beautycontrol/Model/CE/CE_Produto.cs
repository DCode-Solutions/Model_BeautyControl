using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Produto : EntityBase
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public double preco { get; set; }
        public int minutosestimado { get; set; }
        public int idstatus { get; set; }
        public int idcategoria { get; set; }

        public CE_Auxiliar Status { get; set; }
        public CE_Categoria Categoria { get; set; }

        public CE_Produto()
        {
            Status = new CE_Auxiliar();
            Categoria = new CE_Categoria();
        }


        public CE_Produto(string Nome, string Descricao, double Preco, int MinEst, int Categoria_Id)
        {
            Status = new CE_Auxiliar();
            Categoria = new CE_Categoria();
            nome = Nome;
            descricao = Descricao;
            preco = Preco;

            if (MinEst != 0)
                minutosestimado = MinEst;

            Categoria.id = idcategoria = Categoria_Id;
        }

        public CE_Produto(int Id,string Nome, string Descricao,  int MinEst, int Categoria_Id)
        {
            Status = new CE_Auxiliar();
            Categoria = new CE_Categoria();
            id = Id;
            nome = Nome;
            descricao = Descricao;
           // preco = Preco;

            if (MinEst != 0)
                minutosestimado = MinEst;

            Categoria.id = idcategoria = Categoria_Id;
        }
    }
}
