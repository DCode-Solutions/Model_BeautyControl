namespace model_beautycontrol.Model.DTO
{
    public class ImagemParametroToCmdSql
    {
        public string parametroOut { get; set; }
        public byte[] parametroIn { get; set; }

        public ImagemParametroToCmdSql()
        {

        }

        public ImagemParametroToCmdSql(string parametroout_, byte[] parametroin_)
        {
            this.parametroIn = parametroin_;
            this.parametroOut = parametroout_;
        }
    }
}
