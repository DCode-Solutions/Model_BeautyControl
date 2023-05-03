using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Movimentacao01 : EntityBase
    {
        public int datamovimentacao { get; set; }
        public int quantidade { get; set; }
        public double custounit { get; set; }
        public bool iscompraefetuada { get; set; }
        public int? codclienteorfornecedor { get; set; }
        public string notafiscal { get; set; }
        public string observacao { get; set; }
        public int id_tipomovimentacao { get; set; }
        public int id_produto { get; set; }
        public int? responsavel { get; set; }

        public CE_Auxiliar TipoMovimentacao { get; set; }
        public CE_Produto Produto { get; set; }
        public CE_Funcionario Responsavel_ { get; set; }
        public CE_Cliente Cliente { get; set; }
        public CE_Fornecedor Fornecedor { get; set; }

        public string nomeCliOrFor { get; set; }

        public string dataMovimentacaoFormatada
        {
            get
            {
                if (datamovimentacao != 0)
                    return Utilidades.getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(datamovimentacao);
                else
                    return "";
            }
        }

        public CE_Movimentacao01()
        {
            TipoMovimentacao = new CE_Auxiliar();
            Produto = new CE_Produto();
            Responsavel_ = new CE_Funcionario();
            Cliente = new CE_Cliente();
            Fornecedor = new CE_Fornecedor();
        }
    }
}
