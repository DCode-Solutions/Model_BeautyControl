using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model_beautycontrol.Model.DTO
{
    public class GraficoStringInt
    {
        double valueDouble;
        int value;
        string argument;

        public int Value
        {
            get { return value; }
        }

        public double ValueDouble
        {
            get { return valueDouble; }
        }

        public string Argument
        {
            get { return argument; }
        }

        public GraficoStringInt(string argument, int value)
        {
            this.argument = argument;
            this.value = value;
        }

        public GraficoStringInt(string argument, double value)
        {
            this.argument = argument;
            this.valueDouble = value;
        }
    }
}
