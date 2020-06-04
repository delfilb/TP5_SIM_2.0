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
            //el nroCaja es como el id de la caja. Puede ser 1 o 2.
            /*el estado de la caja, dependiendo de si es de la 1 o 2 puede ser
             para caja1 {libre;ocupado} caja2 {cerrado; ocupado}
            La cola hace referencia a la cantidad de elementos que se tienen en el vector
            clientes - 1
            la queue clientes lo que hace es guardar la instancia de los objetos clientes que
            vayan llegando a cada caja correspondientemente
             */


            int nroCaja = 1;
            double tiempoFinAtencion = 0;
            double finAtencion = 100;
            string estado = "";
          

        }

        public double tiempoFinAtencion, finAtencion;
        public int nroCaja, cola;
        public Queue<Cliente> cliente;
        public string estado;

        public int getTamCola()
        {
            int x = 0;
            x = this.cliente.Count;
            return x;
        }

        public double getfinAtencion()
        {
            return finAtencion;
        }
    }
    
}
