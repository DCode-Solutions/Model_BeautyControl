using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Utils
{
    public class Context
    {
        public static Context _instance;

        #region Posgreslq
        private NpgsqlConnection conexao;

        private NpgsqlTransaction transacao;

        public static Context Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Context();
                }

                return _instance;
            }

            set { _instance = value; }
        }

        public Context()
        {
            IniFile ini = new IniFile("C:\\btctrlconfig\\btctrlconfig.ini");
            string servidor = ini.IniReadValue("configuracoes", "servidor_postgres");
            string porta = ini.IniReadValue("configuracoes", "porta");
            string database = ini.IniReadValue("configuracoes", "database");
            string usuario = ini.IniReadValue("configuracoes", "usuario_postgres");
            string senha = ini.IniReadValue("configuracoes", "senha_postgres");

            conexao = new NpgsqlConnection("Server=" + servidor + ";Port=" + porta + ";Database= db_btctrl_teste;User Id=" + usuario + ";Password=" + senha + ";");
            //conexao = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=db_sabTeste;User Id=postgres;Password=iconmain;");
        }

        public DataTable Obter(String sql)
        {
            DataTable dt = new DataTable();

            try
            {
                if (conexao.State == ConnectionState.Closed)
                    conexao.Open();

                NpgsqlDataAdapter adpt = new NpgsqlDataAdapter(sql, conexao);

                adpt.Fill(dt);

            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }

            return dt;
        }

        public void ExecutarComando(String sql)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                    conexao.Open();

                NpgsqlCommand command = new NpgsqlCommand(sql, conexao);

                command.ExecuteNonQuery();

            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecutarComandoComImagem(String sql, List<Model.DTO.ImagemParametroToCmdSql> listaParametro)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                    conexao.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.CommandText = sql;
                foreach (var item in listaParametro)
                {
                    if (item.parametroIn == null)
                    {
                        command.Parameters.AddWithValue(item.parametroOut, NpgsqlDbType.Bytea, new byte[0]);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(item.parametroOut, NpgsqlDbType.Bytea, item.parametroIn);
                    }
                }

                command.Connection = conexao;

                command.ExecuteNonQuery();

            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IniciarTransacao()
        {
            if (conexao.State == ConnectionState.Closed)
                conexao.Open();

            transacao = conexao.BeginTransaction();
        }

        public void FinalizarTranzacao()
        {
            transacao.Commit();

            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }

        public void DesfazerTransacao()
        {
            transacao.Rollback();

            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }
        #endregion

       
    }
}
