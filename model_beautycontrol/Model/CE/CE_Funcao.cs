using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Funcao : EntityBase
    {
        private string _nome;
        private string _descricao;
        //private CE_Departamento _departamento;
        public int id_departamento { get; set; }

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

        public string descricao
        {
            get
            {
                return _descricao;
            }

            set
            {
                _descricao = value;
            }
        }

        public CE_Funcao()
        {

        }

        public CE_Funcao(int id_, string nome_, string descricao_, int _iddepartamento)
        {
            this.id = id_;
            this.nome = nome_;
            this.descricao = descricao_;
            this.id_departamento = _iddepartamento;
        }
    }
}
