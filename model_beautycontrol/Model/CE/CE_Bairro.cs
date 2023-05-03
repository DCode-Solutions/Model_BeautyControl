using model_beautycontrol.Utils;


namespace model_beautycontrol.Model.CE
{
    public class CE_Bairro : EntityBase
    {

        public int id_cidade { get; set; }
        public int id_zona { get; set; }
        private string _nome;
        private CE_Cidade _cidade;
        private CE_Auxiliar _zona;


        public CE_Bairro()
        {

        }

        public CE_Bairro(int id, string nome, int id_cidade)
        {
            this.id = id;
            this.nome = nome;
            this.id_cidade = id_cidade;
        }

      
        public string nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
              
            }
        }

   
        public CE_Cidade cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        public CE_Auxiliar zona
        {
            get { return _zona; }
            set { _zona = value; }
        }


    }
}
