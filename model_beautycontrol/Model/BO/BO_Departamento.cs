using model_beautycontrol.Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.BO
{
    public class BO_Departamento
    {
        private DAO_Departamento dao;

        public BO_Departamento()
        {
            dao = new DAO_Departamento();
        }
    }
}
