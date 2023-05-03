using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Empresa : EntityBase
    {

        private string nome;
        private string razaosocial;
        private string cnpj;
        private string cpf;

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Razaosocial
        {
            get
            {
                return razaosocial;
            }

            set
            {
                razaosocial = value;
            }
        }

        public string Cnpj
        {
            get
            {
                return cnpj;
            }

            set
            {
                cnpj = value;
            }
        }

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public CE_Empresa()
        {

        }

        public CE_Empresa(string nome, string razaosocial, string cnpj, string cpf)
        {
            this.nome = nome;
            this.razaosocial = razaosocial;
            this.cnpj = cnpj;
            this.cpf = cpf;
        }
    }
}
