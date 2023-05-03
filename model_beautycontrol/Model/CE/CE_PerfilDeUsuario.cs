using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_PerfilDeUsuario : EntityBase
    {

        private string _descricao;
        private int _prioridade;

        public int id_empresa { get; set; }

       
        public CE_Empresa empresa { get; set; }

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

        public int prioridade
        {
            get
            {
                return _prioridade;
            }

            set
            {
                _prioridade = value;
            }
        }
    }
}
