using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_PeriodoAssociado : EntityBase
    {
        public int idfuncionario { get; set; }
        public int idvinculo { get; set; }
        public int datainicio { get; set; }
        public int datafim { get; set; }

        public CE_Funcionario funcionario { get; set; }
        public CE_Auxiliar vinculo { get; set; }
    }
}
