using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_Usuario : EntityBase
    {
        public int id_funcionario { get; set; }
        public int id_status { get; set; }

        private string login;
        private string senha;


        private CE_Auxiliar status;
        private CE_Funcionario funcionario;

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public CE_Auxiliar Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public CE_Funcionario Funcionario
        {
            get
            {
                return funcionario;
            }

            set
            {
                funcionario = value;
            }
        }

        public string NomeFuncionario
        {
            get {
                if (Funcionario == null)
                {
                    return "";
                }
                else
                {
                    return String.IsNullOrEmpty(Funcionario.nome) ? "" : Funcionario.nome;
                    
                }
            }
        }

        
        public CE_Usuario()
        {

        }

        public CE_Usuario(string _login, string _senha, int _idstatus, int _idfuncionario)
        {
            
            this.login = _login;
            this.senha = _senha;
            this.id_status = _idstatus;
            this.id_funcionario = _idfuncionario;
        }

        public CE_Usuario(string _login, string _senha)
        {
            this.login = _login;
            this.senha = _senha;            
        }

    }
}
