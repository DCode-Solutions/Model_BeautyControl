using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Cidade : EntityBase
    {

        public int idestado { get; set; }
       

        private string _nome;
        private CE_UF _estado;
      
  
        public CE_Cidade()
        {

        }

        public CE_Cidade(int id, string nome, int id_estado)
        {
            this.id = id;
            this.nome = nome;
            this.idestado = id_estado;
            
        }

       
        public string nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
               
            }
        }

       
        public CE_UF estado
        {
            get { return _estado; }
            set { _estado = value;  }
        }

        
    }
}