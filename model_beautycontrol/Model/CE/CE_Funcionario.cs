using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Funcionario : EntityBase
    {
        private string _nome;
        private string _rg;
        private string _cpf;
        private string _email;
        private string _telefone01;
        private string _celular01;
        private string _celular02;
        private int? _datanascimento;
        //private int _datainicio;
        //private int _datafim;
        private byte[] _foto;

        public string celular03 { get; set; }
        public string rua { get; set; }
        public string referencia { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string cep { get; set; }

        public int idempresa { get; set; }
        public int idfuncao { get; set; }
        public int idsexo { get; set; }
        public int idbairro { get; set; }
        public int idvinculoatual { get; set; }

        public CE_Empresa empresa { get; set; }
        public CE_Funcao funcao { get; set; }
        public CE_Auxiliar sexo { get; set; }
        public CE_Bairro bairro { get; set; }
        public CE_Auxiliar vinculoatual { get; set; }

        public string DisplayMember01
        {
            get
            {
                if (funcao == null)
                    return nome;

                return nome + " - " + funcao.nome;
            }
        }

        public string datanascimentoFormatada
        {
            get
            {
                int dt = _datanascimento == null ? 0 : (int)_datanascimento;
                if (dt != 0)
                    return Utilidades.getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(dt);
                else
                    return "";
            }
        }

        public string nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        public string rg
        {
            get
            {
                return _rg;
            }

            set
            {
                _rg = value;
            }
        }

        public string cpf
        {
            get
            {
                return _cpf;
            }

            set
            {
                _cpf = value;
            }
        }

        public string email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string telefone01
        {
            get
            {
                return _telefone01;
            }

            set
            {
                _telefone01 = value;
            }
        }

        public string celular01
        {
            get
            {
                return _celular01;
            }

            set
            {
                _celular01 = value;
            }
        }

        public string celular02
        {
            get
            {
                return _celular02;
            }

            set
            {
                _celular02 = value;
            }
        }

        public int? datanascimento
        {
            get
            {
                return _datanascimento;
            }

            set
            {
                _datanascimento = value;
            }
        }

        //public int datainicio
        //{
        //    get
        //    {
        //        return _datainicio;
        //    }

        //    set
        //    {
        //        _datainicio = value;
        //    }
        //}

        //public int datafim
        //{
        //    get
        //    {
        //        return _datafim;
        //    }

        //    set
        //    {
        //        _datafim = value;
        //    }
        //}

        public byte[] foto
        {
            get
            {
                return _foto;
            }

            set
            {
                _foto = value;
            }
        }
    }
}
