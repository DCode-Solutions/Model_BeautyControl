using model_beautycontrol.Model.CE;
using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CL
{
    public class CL_FuncionarioFuncao : EntityBase
    {
        public int idfuncionario { get; set; }
        public int idfuncao { get; set; }

        public CE_Funcionario  funcionario { get; set; }
        public CE_Funcao funcao { get; set; }

    }
}
