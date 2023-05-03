using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.CE
{
    public class CE_UsuarioPerfil : EntityBase
    {
        public int id_usuario { get; set; }
        public int id_perfil { get; set; }

        private CE_Usuario _usuario;
        private CE_PerfilDeUsuario _perfil;


        // Nao mapeadas

        public CE_Usuario usuario
        {
            get { return _usuario; }
            set { _usuario = value;  }
        }

        public CE_PerfilDeUsuario perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }
    }
}
