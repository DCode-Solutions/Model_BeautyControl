using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Fornecedor : EntityBase
    {
        public string nome { get; set; }
        public string razaosocial { get; set; }
        public string telefone { get; set; }
        public string celular01 { get; set; }
        public string celular02 { get; set; }
        public string celular03 { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public string referencia { get; set; }
        public string site { get; set; }
        public string cnpj { get; set; }
        public string inscricaoestadual { get; set; }
        public string inscricaomunicipal { get; set; }
        public int id_bairro { get; set; }

        public CE_Bairro bairro { get; set; }

    }
}
