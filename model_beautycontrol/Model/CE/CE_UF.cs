using model_beautycontrol.Utils;

namespace model_beautycontrol.Model.CE
{
    public class CE_UF : EntityBase
    {

        private string _nome;
        private string _sigla;

        //[Display(Name = "Id ")]
        //public Int32 id { get; set; }

        //[Display(Name = "Id Cliente IRQ ")]
        //public String nome { get; set; }

        public string nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                

            }
        }

        public string sigla
        {
            get
            {
                return _sigla;
            }

            set
            {
                _sigla = value;
            }
        }
    }
}
