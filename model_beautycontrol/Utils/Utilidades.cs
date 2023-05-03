using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace model_beautycontrol.Utils
{
    public static class Utilidades
    {
        /// <ConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING>
        /// Converte uma data que esta em formato inteiro ANOMESDIA ex: 20160224
        /// para string no formato DIA/MES/ANO ex: 24/02/2016
        /// ex: 20160224  = > 24/02/2016
        /// </ConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING>
        /// <param name="data">um numero inteiro que representa uma data no formato anomesdia ex: 20160224</param>
        /// <returns>returna uma string no formato dia/mes/ano</returns>
        public static String getConverterDataTIPO_INTEIRO_ANO_MES_DIA_PARA_DIA_MES_ANO_PARA_STRING(int data)
        {
            string d = data.ToString();
            string ano = d.Substring(0, 4);
            string mes = d.Substring(4, 2);
            string dia = d.Substring(6, 2);

            string result = dia + "/" + mes + "/" + ano;

            return result;

        }

        public static int getDataFormatoInt_yyyyMMdd(DateTime dateTime)
        {
            try
            {
                return dateTime == null ? 0 : Convert.ToInt32(dateTime.ToString("yyyyMMdd"));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Retorna true se o tamanho da texto for menor que o tamanhomaximo permitido
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="tamanhomaximo"></param>
        /// <returns></returns>
        public static bool isTamanhoStringEhMenorQueTamMax(int tamanhoatual, int tamanhomaximo)
        {
            return tamanhoatual < tamanhomaximo ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="tamanhomaximo"></param>
        /// <returns></returns>
        public static bool isTamanhoStringEhDiferenteQueTamMax(int tamanhoatual, int tamanhomaximo)
        {
            return tamanhoatual != tamanhomaximo ? true : false;
        }

        public static bool isNumeroMaiorQueZero(double value)
        {
            return value > 0 ? true : false;
        }

        /// <summary>
        /// Retorna uma string em cascata se mensagem for diferente de nulo ou vazio  pula uma linha
        /// </summary>
        /// <param name="mensagem"></param>
        /// <param name="novaLinha"></param>
        /// <returns></returns>
        public static string getObterMensagem01(string mensagem, string novaLinha)
        {
            return string.IsNullOrEmpty(mensagem) ? novaLinha : mensagem + "\n" + novaLinha;
        }

        public static ObservableCollection<T> ConverterL2OC<T>(IList<T> obj)
        {
            return obj == null ? null : new ObservableCollection<T>(obj);
        }

        public static List<T> ConverterOC2L<T>(ObservableCollection<T> obj)
        {
            return obj == null ? null : new List<T>(obj);
        }

        public static byte[] ObterArrayByteFromImageControl(BitmapImage bitmapImage)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        public static string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static byte[] getImageToBytearray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }

        public static string getGerarSenha01(string value)
        {
            string r = value + DateTime.Now.ToString("dd/MM/yyyy");

            return r;
        }

        public static string getUsuarioDoEmail(string login)
        {
            return getParcialStringAteDeterminadoChar(login,'@');
        }


        public static string getParcialStringAteDeterminadoChar(string value,char caracterLimite)
        {
            string resultado = "";

            // Convert value em um Arrayde Caractere 
            char[] caracter = value.ToCharArray();

            // Percorre o laço de repetição ate encontrar o caractere de parada
            for (int i = 0; i < caracter.Length; i++)
            {
                if (caracter[i] == '@')
                    break;

                resultado = resultado + caracter[i];
            }

            return resultado;
        }
        
        public static bool getIsHora1MenorQueHora2(TimeSpan horainicio, TimeSpan horafim)
        {
            try
            {
                int hora1 = Convert.ToInt32(horainicio.ToString(@"hh\:mm").Replace(":", ""));
                int hora2 = Convert.ToInt32(horainicio.ToString(@"hh\:mm").Replace(":", ""));

                return hora1 > hora2 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static ImageSource ByteToImage(byte[] foto)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(foto);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();
            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }



        //Retorna mensagem de Exceção
        public static string GetMensagemExcecao(Exception ex)
        {
            string r = null;

            //if (ex is DbUpdateException)
            //{

            //    r = ex.InnerException.InnerException.Message;
            //    if (r.Substring(0, 5) == "23503")
            //    {
            //        r = "Você tentou atualizar ou excluir um objeto que possui outros objetos associados a ele através de uma chave-extrangeira." +
            //            "\nExclua os objetos associados e tente novamente.";
            //    }
            //}
            //else
            if (ex is Npgsql.NpgsqlException)
            {
                r = ex.Message;
                if (r.Substring(0, 5) == "23503")
                {
                    r = "Você tentou atualizar ou excluir um objeto que possui outros objetos associados a ele através de uma chave-extrangeira." +
                        "\nExclua os objetos associados e tente novamente.";
                }
                else if (r.Substring(0, 5) == "28P01")
                {
                    r = "O usuário ou senha para o acesso a base de dados não está correto.\nVerifique se no arquivo de configuração o usuario e a senha são os mesmos utilizados para acessar o sbgd!.";
                }
                else if (r.Substring(0, 5) == "3D000")
                {
                    r = "A base de dados não foi encontrada.\nVerifique o arquivo de configuração ou se existe base de dados criado para este sistema!.";
                }
                else if (r.Substring(0, 5) == "42601")
                {
                    r = "Erro de sintaxe na consulta sql ";
                    r += ex.Message;
                }
                else if (r.Substring(0, 5) == "42703")
                {
                    r = "Erro no sql de coluna não existe: " + ex.Message;
                }

            }
            else if (ex is InvalidOperationException)
            {
                r = ex.Message;
                if (r.Substring(0, 15) == "Member 'Reload'")
                {
                    r = "Você tentou atualizar uma entidade que nao existe no contexto";
                    //Member 'Reload' cannot be called for the entity of type 'Categoria' 
                    //because the entity does not exist in the context. To add an entity to the context call the Add or Attach method of DbSet<Categoria>.
                }


            }
            //else if (ex is ProviderIncompatibleException)
            //{
            //    r = ex.Message;
            //    if (r.Substring(0, 40) == "An error occurred accessing the database")
            //    {
            //        r = "O sistema não consegue acessar o banco de dados.";
            //    }
            //}
            else if (ex is IndexOutOfRangeException)
            {
                r = ex.Message;
                if (r.Substring(0, 29) == "Index was outside the bounds ")
                {
                    r = "Erro no Índice,esta fora dos limites da matriz";
                }
            }
            else
            {
                //se chegar aqui é pq nenhuma das Exceptions específicas acima foi encontrada. Então trata-se de um Exception puro.
                r = ex.Message;
            }

            return r;
        }


        public static Int64 getInt64ValorDoItemDataRow(DataRow item, string nomeColunaSql)
        {
            return item[nomeColunaSql] == DBNull.Value ? 0 : item.Field<Int64>(nomeColunaSql);
        }

        public static DateTime getTimeSpanToDateTime(TimeSpan timeSpan)
        {
            DateTime dt = new DateTime();
            dt = dt + timeSpan;

            return dt;
        }

        public static TimeSpan getTimeSpanDoItemDataRow(DataRow item, string nomeColunaSql)
        {
            return item.Field<TimeSpan>(nomeColunaSql);
        }

        public static DateTime getDateTimeDoItemDataRow(DataRow item, string nomeColunaSql)
        {
            return item.Field<DateTime>(nomeColunaSql);
        }

        public static int getInt32ValorDoItemDataRow(DataRow item, string nomeColunaSql)
        {
            return item[nomeColunaSql] == DBNull.Value ? 0 : item.Field<Int32>(nomeColunaSql);
        }

        public static double getDoubleValorDoItemDataRow(DataRow item, string nomeColunaSql)
        {
            return item[nomeColunaSql] == DBNull.Value ? 0 : item.Field<double>(nomeColunaSql);
        }

        public static DateTime GetDataUltimoDiaMes(DateTime datainicio)
        {
            try
            {
                int ultimoDia = DateTime.DaysInMonth(datainicio.Year, datainicio.Month);
                DateTime data = new DateTime(datainicio.Year, datainicio.Month, ultimoDia);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime GetDataPrimeiroDiaMes(DateTime datainicio)
        {
            try
            {
                DateTime data = new DateTime(datainicio.Year, datainicio.Month, 1);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Valor2CasaDecimais(string s)
        {
            string x = "";

            if (s.Contains(','))
            {
                char[] caracter = s.ToCharArray();

                int cont = 0;
                bool y = false;
                for (int i = 0; i < caracter.Length; i++)
                {
                    x = x + caracter[i];
                    if (caracter[i] == ',')
                    {
                        y = true;
                    }

                    if (y)
                    {
                        cont++;
                        if (cont == 3)
                        {
                            break;
                        }
                    }

                }
            }
            else
            {
                x = s + ",00";
            }
            return x;
        }

        public static int getLengthString(object v)
        {
            throw new NotImplementedException();
        }

        public static string getSomenteDigitosDePhone(string text)
        {
            text = text.Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "");
            return text;
        }

        //Converte String em Decimal
        public static decimal getConvertToDecimal(string p)
        {
            p = p.Replace('.', ',');
            return Convert.ToDecimal(p);
        }

        public static void AbrirArquivo(string fileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            try
            {
                process.StartInfo.FileName = fileName;
                process.Start();
                //process.WaitForInputIdle();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível abrir o arquivo.\nDetalhe do erro : " + ex.Message);
            }
        }
    }
}
