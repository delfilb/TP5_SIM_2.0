using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_SIM_2._02.Clases
{
    public class Caja
    {
        
        public double tiempoFinAtencion { get; set; }
        public double finAtencion { get; set; }
        public int nroCaja { get; set; }
        // el atributo clientes guarda los clientes en la cola mas el que esta atendiendo
        public Queue<Cliente> clientes { get; set; }
        public string estado { get; set; }

        public int getTamCola()
        {
            int x = 0;
            x = this.clientes.Count;
            return x-1;
        }

        
        
    }
    
}
