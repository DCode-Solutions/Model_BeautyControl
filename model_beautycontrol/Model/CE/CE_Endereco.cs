using model_beautycontrol.Utils;

namespace model_beautycontrol.Model.CE
{
    public class CE_Endereco : EntityBase
    {
        private string _rua;
        private string _referencia;
        private double _latitude;
        private double _longitude;
        private string _cep;

        public int id_bairro { get; set; }

        //nao mapeada
        private CE_Bairro _bairro;


        //[Required(ErrorMessage = "Campo obrigatório!")]
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

        public double latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
             
            }
        }

        public double longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
           
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




    }
}
