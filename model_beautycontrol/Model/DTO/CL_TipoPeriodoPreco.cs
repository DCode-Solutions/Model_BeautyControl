using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.DTO
{
    public class CL_TipoPeriodoPreco
    {
        public int prioridade { get; set; }
        public string nome { get; set; }

        public CL_TipoPeriodoPreco() { }

        public CL_TipoPeriodoPreco(string Nome, int Prioridade)
        {
            prioridade = Prioridade;
            nome = Nome;
        }

        public List<CL_TipoPeriodoPreco> listaTipoPromocao
        {
            get { return getTipoPromocao(); }
        }

        private List<CL_TipoPeriodoPreco> getTipoPromocao()
        {
            List<CL_TipoPeriodoPreco> lista = new List<CL_TipoPeriodoPreco>();
            lista.Add(new CL_TipoPeriodoPreco("Dia Especial", 100));
            lista.Add(new CL_TipoPeriodoPreco("Mensal", 60));
            //   lista.Add(new Tipos("Período",80));            

            return lista;
        }
    }

   
}
