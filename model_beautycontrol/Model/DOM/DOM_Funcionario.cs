using model_beautycontrol.Model.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.DOM
{
    public class DOM_Funcionario
    {
        public DOM_Funcionario()
        {
            boFuncionario = new BO_Funcionario();
            boAuxiliar = new BO_Auxiliar();
            boBairro = new BO_Bairro();
            boFuncao = new BO_Funcao();
            boPeriodoAssociado = new BO_PeriodoAssociado();
            boFuncionarioFuncao = new BO_FuncionarioFuncao();
        }

        public BO_Funcionario boFuncionario;
        public BO_Auxiliar boAuxiliar;
        public BO_Bairro boBairro;
        public BO_Funcao boFuncao;
        public BO_PeriodoAssociado boPeriodoAssociado;
        public BO_FuncionarioFuncao boFuncionarioFuncao;

        public void InserirOuAlterar(CE_Funcionario funcionario, DateTime dataInicio)
        {
            if (funcionario.id == 0)
            {
                boFuncionario.doInserir(funcionario);
                if (boAuxiliar.getAuxiliar(funcionario.idvinculoatual).descricao.ToLower() != "freelancer")
                {
                    funcionario.id = boFuncionario.getUltimoId();
                    boPeriodoAssociado.doInserir(funcionario, dataInicio);
                    boFuncionarioFuncao.doInserir(funcionario.id, funcionario.idfuncao);
                }
            }
            else
            {
                boFuncionario.doAlterar(funcionario);
            }
        }

        public void doAssociar(List<CE_Funcao> lista, CE_Funcionario funcionario)
        {
            boFuncionarioFuncao.doDeleteAll(funcionario.id);
            foreach (var funcao in lista)
            {
                if (funcao.isSelecionado)
                {
                    boFuncionarioFuncao.doInserir(funcionario.id, funcao.id);
                }
            }
        }

        public List<CE_Funcao> getFuncoesParaAssociar(CE_Funcionario funcionario)
        {
            List<CE_Funcao> listaFuncoes = new List<CE_Funcao>();

            listaFuncoes = (from x in boFuncao.getListaFuncao() where x.id != funcionario.idfuncao select x).ToList();
            var listaFuncoesAssociadas = boFuncionarioFuncao.getFuncoesAssocidasAoFuncionario(funcionario.id);

            foreach (var item in listaFuncoes)
            {
                item.isSelecionado = false;
                foreach (var item2 in listaFuncoesAssociadas)
                {
                    if (item.id == item2.idfuncao)
                        item.isSelecionado = true;
                }
            }

            return listaFuncoes;
        }
    }
}
