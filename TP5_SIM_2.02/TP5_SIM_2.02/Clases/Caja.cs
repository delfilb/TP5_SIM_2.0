using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_SIM_2._02.Clases
{
    public class Caja
    {
        public Caja()
        {
            int nroCaja = 1;
            double tiempoFinAtencion = 0;
            double finAtencion = 0;
            string estado = "";
            int cola = 0;
        }

        public double tiempoFinAtencion, finAtencion;
        int nroCaja, cola;
        public string estado;
    }
}
