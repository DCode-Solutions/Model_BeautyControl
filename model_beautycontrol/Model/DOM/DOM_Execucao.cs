using model_beautycontrol.Model.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using model_beautycontrol.Model.CE;

namespace model_beautycontrol.Model.DOM
{
    public class DOM_Execucao
    {
        public DOM_Execucao()
        {
            boCliente = new BO_Cliente();
            boFuncionario = new BO_Funcionario();
            boBairro = new BO_Bairro();
            boFuncao = new BO_Funcao();
            boAuxiliar = new BO_Auxiliar();
            boFuncionarioFuncao = new BO_FuncionarioFuncao();
            boCategoria = new BO_Categoria();
            boProduto = new BO_Produto();
            boPreco = new BO_Preco();
            boVenda = new BO_Venda();
            boVendaProduto = new BO_VendaProduto();
            boVendaFormaPagamento = new BO_VendaFormaPagamento();
        }

        public List<CE_VendaProduto> getListaVendaProdutoParaDetelhe(int id)
        {
            var lista = boVendaProduto.getListaVendaProduto(id);
            foreach (var item in lista)
            {
                item.Produto = boProduto.getProduto(item.id_produto);
                item.Funcionario = boFuncionario.getFuncionario(item.id_funcionario);
            }

            return lista;
        }

        public BO_Cliente boCliente;
        public BO_Funcionario boFuncionario;
        public BO_Bairro boBairro;
        public BO_Funcao boFuncao;
        public BO_Auxiliar boAuxiliar;
        public BO_FuncionarioFuncao boFuncionarioFuncao;
        public BO_Categoria boCategoria;
        public BO_Produto boProduto;
        public BO_Preco boPreco;
        public BO_Venda boVenda;
        public BO_VendaProduto boVendaProduto;
        public BO_VendaFormaPagamento boVendaFormaPagamento;

        public void InserirOrAlterarProduto(CE_Produto obj)
        {
            if (obj.id == 0)
                doInserirProduto(obj);
            else
                boProduto.doAlterar(obj);
        }

        private void doInserirProduto(CE_Produto obj)
        {
            boProduto.doInserir(obj);
            boPreco.doInserir(obj.preco);
        }

      

        public List<CE_Preco> getProdutos()
        {
            List<CE_Preco> lista = boPreco.getProdutos();

            foreach (var item in lista)
            {
                item.Produto.Categoria = boCategoria.getCategoria(item.Produto.idcategoria);
            }

            return lista;
        }

        public void doRegistrarNovaVenda(ref CE_Venda obj, List<CE_VendaProduto> lista)
        {
            int? idVenda=null;
            try
            {
                idVenda = obj.id = boVenda.getID_After_Inserir(obj);

                foreach (var item in lista)
                {
                    item.id_venda = (int)idVenda;
                    boVendaProduto.doInserir(item);
                }
            }
            catch (Exception ex)
            {
                if (idVenda != null)
                {
                    boVendaProduto.doDeleteAll((int)idVenda);
                    boVenda.doDelete((int)idVenda);
                    throw new Exception("Não foi possível realizar esta operação:" +ex.Message);
                }
                
            }
            


        }

        public void doAtualizarVenda(ref CE_Venda obj, List<CE_VendaProduto> lista)
        {
            try
            {
                boVenda.doAtualizar(obj);
                boVendaProduto.doDeleteAll(obj.id);
                foreach (var item in lista)
                {
                    item.id_venda = obj.id;
                    boVendaProduto.doInserir(item);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível realizar esta operação:" + ex.Message);
            }
        }

        public void doSalvarVendaFormaPgto(List<CE_VendaFormaPagamento> lista)
        {
            lista = (from x in lista where x.id == 0 select x).ToList();

            foreach (var item in lista)
            {
                boVendaFormaPagamento.doInserir(item);
            }

        }

        public void doVerificarValorPago(double valorTotalPago, double valorSubTotal)
        {
            if (valorTotalPago < valorSubTotal)
            {
                throw new Exception("O pedido não pode ser finalizado, valor insuficiente!");
            }
        }

        public void doFinalizarVenda(CE_Venda obj)
        {
            obj.isPago = true;
            boVenda.doFinalizarVenda(obj);
        }

        /// <summary>
        /// Deleta todos os pagamento, produtos e venda pelo id de uma venda
        /// </summary>
        /// <param name="id"></param>
        public void doDeletarVenda(int id)
        {
            boVendaFormaPagamento.doDeletar_PorVendaId(id);
            boVendaProduto.doDeletar_PorVendaID(id);
            boVenda.doDelete(id);
        }
    }
}
