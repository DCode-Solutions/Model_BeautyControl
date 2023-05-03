using model_beautycontrol.Model.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.DOM
{
    public class DOM_DadosDefault
    {
        public DOM_DadosDefault()
        {
            boAuxiliar = new BO_Auxiliar();
            boEstado = new BO_UF();
            boCidade = new BO_Cidade();
            boDepartamento = new BO_Departamento();
            boBairro = new BO_Bairro();
            boFuncao = new BO_Funcao();
        }

        private BO_Auxiliar boAuxiliar;
        private BO_UF boEstado;
        private BO_Cidade boCidade;
        private BO_Departamento boDepartamento;
        private BO_Funcao boFuncao;
        private BO_Bairro boBairro;

        public void doVerificarBaseDados()
        {
            boAuxiliar.doInserirDadosDefault();
            boAuxiliar.testeCreate();
        }
    }
}
