using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Auxiliar : EntityBase
    {

        private string _descricao;
        private string _sigla;
        private string _tipo;

       
        public string descricao
        {
            get { return _descricao; }
            set
            {
                _descricao = value;
              

            }
        }

       
        public string sigla
        {
            get { return _sigla; }
            set
            {
                _sigla = value;
               

            }
        }

      
        public string tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value;
            

            }
        }
    }
}
