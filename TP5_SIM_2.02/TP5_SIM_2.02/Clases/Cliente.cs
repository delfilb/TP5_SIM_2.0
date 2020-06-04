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
            int id = 1;
            double tiempoEntreLLegadas = 0;
            double tiempoAtencionCliente = 0;
            string estado = "";
            double probMetodoPago = 0;
            string metodoPago = "";
            Boolean finalizado = false;
            int numCaja = 1;
            double tiempo_fin_gondola = 0;
        }

        public double tiempoEntreLLegadas, tiempoAtencionCliente, probMetodoPago, tiempo_fin_gondola;
        public string estado, metodoPago;
        public Boolean finalizado;
        public int id, numCaja;

        

    }

    }
