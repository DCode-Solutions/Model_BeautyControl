using model_beautycontrol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model_beautycontrol.Model.CE;
using System.Data;

namespace model_beautycontrol.Model.DAO
{
    public class DAO_Auxiliar : Context
    {
        public CE_Auxiliar getObjetoAuxiliar(string value, string tipo)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * ");
            str.AppendLine("from tb_auxiliar ");
            str.AppendLine("where lower(tipo) = ':p_tipo' and lower(descricao) = ':p_descricao'");

            str.Replace(":p_tipo", tipo.ToLower());
            str.Replace(":p_descricao", value.ToLower());

            var dt = Obter(str.ToString());

            List<CE_Auxiliar> lista = new List<CE_Auxiliar>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista.FirstOrDefault();
        }

        public void doInserirDadosDefault()
        {
           
                StringBuilder str = new StringBuilder();
                str.AppendLine("");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Ativo','A','status');");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Inativo','I','status');");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Bloqueado','B','status');");
                str.AppendLine("");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Norte','N','zona');");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Sul','S','zona');");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Leste','L','zona');");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Oeste','O','zona');");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Centro-Sul','CS','zona');");
                str.AppendLine("insert into tb_auxiliar(descricao,sigla,tipo) values('Centro-Oeste','CO','zona');");

                ExecutarComando(str.ToString());
          

        }

        public CE_Auxiliar getAuxiliar(int id)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * ");
            str.AppendLine("from tb_auxiliar ");
            str.AppendLine("where id = :p_id");

            str.Replace(":p_id", id.ToString());

            var dt = Obter(str.ToString());

            List<CE_Auxiliar> lista = new List<CE_Auxiliar>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista.FirstOrDefault();
        }

        public List<CE_Auxiliar> getListaAuxiliar(string tipo)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select * ");
            str.AppendLine("from tb_auxiliar ");
            str.AppendLine("where tipo = ':p_tipo'");

            str.Replace(":p_tipo", tipo);
            
            var dt = Obter(str.ToString());

            List<CE_Auxiliar> lista = new List<CE_Auxiliar>();

            foreach (DataRow item in dt.Rows)
            {
                lista.Add(PopularObjeto(item));
            }

            return lista;
        }

        public void crete()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("CREATE TABLE IF NOT EXISTS tb_teste(id integer not null,nome varchar(20))");

            ExecutarComando(str.ToString());
        }

        public bool isPossuiTuplas()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("select count(*) ");
            str.AppendLine("from tb_auxiliar");

            DataTable dt = Obter(str.ToString());

            // Se a qtd for maior que 0 é true senao false
            return Convert.ToInt16(dt.Rows[0][0]) > 0 ? true : false;
           
        }

        private CE_Auxiliar PopularObjeto(DataRow item)
        {
            CE_Auxiliar result = new CE_Auxiliar();
            result.id = item.Field<Int32>("id");
            result.descricao = item.Field<String>("descricao");
            result.sigla = item.Field<string>("sigla");            

            return result;
        }
    }
}
