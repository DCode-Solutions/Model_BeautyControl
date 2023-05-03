using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Cliente : EntityBase
    {
        private string _nome;
        private string _rg;
        private string _cpf;
        private string _email;
        private int _datanascimento;
        private int _datainicio;
        private byte[] _foto;
        private string _telefone;
        private string _celular01;
        private string _celular02;
        private string _celular03;
        private string _rua;
        private string _referencia;
        private string _cep;

        public double latitude { get; set; }
        public double longitude { get; set; }
        public int id_bairro { get; set; }
        public int id_sexo { get; set; }

        private CE_Auxiliar _sexo;
        private CE_Bairro _bairro;

        public CE_Cliente()
        {
            this._sexo = new CE_Auxiliar();
        }

        public CE_Cliente(int _id, string _nome, string _rg, string _cpf, int _datanascimento, string _telefone, string _celular01, string _celular02, string _celular03, int _idbairro, int _idsexo, int _idempresa)
        {
            this.id = _id;
            this.nome = _nome;
            this.rg = _rg;
            this.cpf = _cpf;
            this.datanascimento = _datanascimento;
            this.telefone = _telefone;
            this.celular01 = _celular01;
            this.celular02 = _celular02;
            this.celular03 = _celular03;
            this.id_bairro = _idbairro;
            this.id_sexo = _idsexo;
        }


        public string nome
        {
            get { return _nome; }
            set
            {
                _nome = value;

            }
        }

        public string rg
        {
            get { return _rg; }
            set
            {
                _rg = value;

            }
        }

        public string fones
        {
            get
            {
                string f = "";
                try
                {
                    f += telefone.Length > 0 ? "Tel: " + telefone + " / " : "";
                    f += (celular01.Length + celular02.Length + celular03.Length) > 0 ? "Cel: " : "";
                    f += celular01.Length > 0 ? celular01 + " " : "";
                    f += celular02.Length > 0 ? celular01 + " " : "";
                    f += celular03.Length > 0 ? celular01 + " " : "";
                }
                catch (Exception)
                {
                    return "";
                }
                
               
                return f;

            }
        }

        //[Required(ErrorMessage = "Campo obrigatório!")]
        public string cpf
        {
            get { return _cpf; }
            set
            {
                _cpf = value;

            }
        }

        public string email
        {
            get { return _email; }
            set
            {
                _email = value;

            }
        }


        public int datanascimento
        {
            get { return _datanascimento; }
            set
            {
                _datanascimento = value;

            }
        }

        public string datanascimentoFormatada
        {
            get
            {
                if (_datanascimento != 0)
                    return Utilidades.getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(_datanascimento);
                else
                    return "";
            }
        }

        public int datainicio
        {
            get { return _datainicio; }
            set
            {
                _datainicio = value;
            }
        }

        public byte[] foto
        {
            get { return _foto; }
            set
            {
                _foto = value;
            }
        }

        public string telefone
        {
            get { return _telefone; }
            set
            {
                _telefone = value;
            }
        }

        public string celular01
        {
            get { return _celular01; }
            set
            {
                _celular01 = value;
            }
        }

        public string celular02
        {
            get { return _celular02; }
            set
            {
                _celular02 = value;
            }
        }

        public string celular03
        {
            get { return _celular03; }
            set
            {
                _celular03 = value;
            }
        }


        public string rua
        {
            get { return _rua; }
            set
            {
                _rua = value;
            }
        }


        public string referencia
        {
            get { return _referencia; }
            set
            {
                _referencia = value;
            }
        }


        public string cep
        {
            get { return _cep; }
            set
            {
                _cep = value;
            }
        }

        public CE_Bairro bairro
        {
            get { return _bairro; }
            set
            {
                _bairro = value;
            }
        }

        public CE_Auxiliar sexo
        {
            get { return _sexo; }
            set
            {
                _sexo = value;
            }
        }


    }
}
