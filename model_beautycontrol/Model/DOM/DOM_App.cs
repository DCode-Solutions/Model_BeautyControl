using model_beautycontrol.Model.BO;
using model_beautycontrol.Model.CE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.DOM
{
    public class DOM_App
    {
        public DOM_App()
        {
            boCliente = new BO_Cliente();
            boFuncionario = new BO_Funcionario();
            boAuxiliar = new BO_Auxiliar();
            boProduto = new BO_Produto();
            boPreco = new BO_Preco();
            boVenda = new BO_Venda();
            boVendaProduto = new BO_VendaProduto();
            boVendaFormaPagamento = new BO_VendaFormaPagamento();
            boVendaApp = new BO_VendaApp();
            boVendaProdutoApp = new BO_VendaProdutoApp();
            boVendaFormaPagamentoApp = new BO_VendaformaPagamentoApp();
        }

        public bool doInserirVendaFormaPagamentoApp(CE_VendaFormaPagamento_App item)
        {
            Int32? id = boVendaFormaPagamentoApp.ObterUltimoId();

            if (id == null)
                id = 0;

            item.id = (int)id + 1;

            try
            {
                boVendaFormaPagamentoApp.doInserir(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool doInserirVendaApp(CE_Venda_App item)
        {
            Int32? id = boVendaApp.ObterUltimoId();

            if (id == null)
                id = 0;

            item.id = (int)id + 1;

            try
            {
                boVendaApp.doInserir(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool doInserirVendaProdutoApp(CE_VendaProduto_App item)
        {
            Int32? id = boVendaProdutoApp.ObterUltimoId();

            if (id == null)
                id = 0;

            item.id = (int)id + 1;

            try
            {
                boVendaProdutoApp.doInserir(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BO_VendaApp boVendaApp;
        public BO_VendaProdutoApp boVendaProdutoApp;
        public BO_VendaformaPagamentoApp boVendaFormaPagamentoApp;
        public BO_Cliente boCliente;
        public BO_Funcionario boFuncionario;
        public BO_Auxiliar boAuxiliar;
        public BO_Produto boProduto;
        public BO_Preco boPreco;
        public BO_Venda boVenda;
        public BO_VendaProduto boVendaProduto;
        public BO_VendaFormaPagamento boVendaFormaPagamento;
    }
}
