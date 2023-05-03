using model_beautycontrol.Utils;


namespace model_beautycontrol.Model.CE
{
    public class CE_Departamento : EntityBase
    {
        private string _nome;
        private string _sigla;

        public CE_Departamento()
        {

        }

        public CE_Departamento(int _id, string _nome, string _sigla)
        {
            this.id = _id;
            this.nome = _nome;
            this._sigla = _sigla;
        }

        public string nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string sigla
        {
            get { return _sigla; }
            set { _sigla = value;  }
        }
    }
}
