using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_SIM_2._02.Clases
{
    public class Cliente
    {
        public Cliente()
        {
            double tiempoEntreLLegadas = 0;
            double tiempoAtencionProxCliente = 0;
            string estado = "";
            double probMetodoPago = 0;
            string metodoPago = "";
            Boolean finalizado = false;
        }

        public double tiempoEntreLLegadas, tiempoAtencionProxCliente, probMetodoPago;
        public string estado, metodoPago;
        public Boolean finalizado;
    }
}
