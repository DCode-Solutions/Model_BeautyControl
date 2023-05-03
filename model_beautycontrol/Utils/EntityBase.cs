using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Utils
{
    public class EntityBase
    {
        public int id { get; set; }
       // [NotMapped]
        public bool isSelecionado { get; set; }
       // [NotMapped]
        public bool isAlterado { get; set; }

        public bool isHabilitado { get; set; }

        public bool isVisivel { get; set; }
        // check for general model error    
        public string Error { get { return null; } }

      
    
}
}
