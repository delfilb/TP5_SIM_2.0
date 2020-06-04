using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP5_SIM_2._02.Clases;

//Ver el tiempo de atencion
//
namespace TP5_SIM_2._02.Formularios
{
    public partial class Menu : Form
    {
        private static readonly Random random = new Random();

        public Menu()
        {

            InitializeComponent();

        }

        private void inicio()
        {

            // int iter = tbxMedia.Text;

        }


  

        public double actualizarReloj(double demora)
        {

        }

        
        public void llegada_cli(double media, List<Cliente> clientes, Caja caja1, Caja caja2)
        {
            //llega un cliente y se genera la proxima llegada, se genera el tiempo en gondola
            double rnd = random.NextDouble();
            double entre_llegada = -media * Math.Log(1 - rnd);

            
            


        }

        public void fin_gondola(Caja caja1, Caja caja2)
        {
            //crear cliente y chequear cajas
            Cliente cli = new Cliente();
            if (caja1.estado != "Ocupado")
            {
                cli.estado = "SA";
                cli.numCaja = 1;
                caja1.estado = "Ocupado";
            }
            else if (caja1.getTamCola() > 4)
            {
                if (caja2.estado == "Cerrado")
                {
                    cli.estado = "SA";
                    cli.numCaja = 2;
                    caja2.estado = "Ocupado";
                    if ()
                    {

                    }
                    caja1.clientes.Enqueue.re
                }
                else if (caja1.getTamCola() <= caja2.getTamCola())
                {
                    cli.estado = "EA";
                    cli.numCaja = 1;
                    caja1.clientes.Enqueue(cli);
                }
            }
            else if (caja1.getTamCola() < caja2.getTamCola())
            {
                cli.estado = "EA";
                caja1.clientes.Enqueue(cli);
            }
            else {
                cli.estado = "EA";
                caja2.clientes.Enqueue(cli);
            }
        }

        public double fin_atencion(double reloj)
        {
            double demoraCajaDesde = double.Parse(tbxDesdeDemoraCaja.Text);
            double demoraCajaHasta = double.Parse(tbxHastaDemoraCaja.Text);

            double rnd_fin_at = random.NextDouble();

            // X = A + RND (B - A)
            double tiempo_fin_atencion = demoraCajaDesde + rnd_fin_at * (demoraCajaHasta - demoraCajaDesde);
            double rnd_pago = random.NextDouble();
            double fin_at = 0;
            if (rnd_pago < 0.5)
            {
                string metodo_pago = "Efectivo";
                fin_at = tiempo_fin_atencion + reloj;

            }
            //tarjeta
            else
            {
                string metodo_pago = "Tarjeta";
                fin_at = tiempo_fin_atencion + 2 + reloj;

            }
            // acumulador de tiempo de atencion
            double acum_tiempo_at = 0;
            acum_tiempo_at = acum_tiempo_at + fin_at;
            return fin_at;
        }

        public Cliente menorGondolas(Cliente cli_gondolas)
        {      
            if (cli_gondolas.Count > 0)
            {
                List<double> tiempos = new List<double>();
                for (int i = 0; i++; i < cli_gondolas.Count)
                {
                    tiempos.Add(cli.fin_gondola);
                }
                    menor = tiempos.Min();
                    return cli_gondolas.Find(c => c.fin_gondola == menor);
                } 
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            

            Caja caja1 = new Caja();
            Caja caja2 = new Caja();
            caja1.estado = "Libre";
            caja1.nroCaja = 1;
            caja2.estado = "Cerrado";
            caja2.nroCaja = 2;


            double media = double.Parse(tbxMedia.Text);
            int corteA = int.Parse(tbxCorteA.Text);
            int corteB = int.Parse(tbxCorteB.Text);
            double demoraGondolaDesde = double.Parse(tbxDesdeDemoraCliente.Text);
            double demoraGondolaHasta = double.Parse(tbxHastaDemoraCliente.Text);



            string nombre_evento = "";
            string metodo_pago = "";
            double fin_at_caja_1 = 100;
            double fin_at_caja_2 = 100;
            string estado_caja_1 = "";
            int cola_caja_1 = 0;
            string estado_caja_2 = "";
            int cola_caja_2 = 0;


            double acum_tiempo_at = 0;
            double acum_tiempo_ocioso_caja1 = 0;
            int acum_clientes_at_finalizada = 0;
            int acum_clientes_llegan = 0;
            double acum_tiempo_permanencia = 0;

            double tiempo_ocioso_caja_1;

            int cant_caja_2_usada = 0;
            double rnd_pago = 0;
            double rnd_fin_at = 0;

            double tiempo_fin_atencion = 0;

            double rnd_lleg_cliente = 0;
            double fin_at;
            double tiempo_entre_llegadas = 0;
            double prox_llegada = 0;
            double rnd_gondola = 0;
            double tiempo_gondola = 0;
            double tiempo_fin_gondola = 0;
            List<Cliente> cli_gondolas = new List<Cliente>();

            // El contador de x debería ser 0 para que el id del primer cliente no sea 2
            int x = -1;   // para que entre en inicialización;
            double reloj = 0;
          

            // i = filas
            // caso A
            if (rbCasoA.Checked)
            { //for para cada cliente el id = x y le vamos sumando 1 por cada iteración. 
                // el 11 debería ingresarse por parámetro
                while(acum_clientes_at_finalizada<=corteA)
                {

                    //evento de inicialización
                    if (x == -1)
                    {
                        rnd_lleg_cliente = random.NextDouble();
                        tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
                        prox_llegada = tiempo_entre_llegadas;
                        caja1.estado = "Libre";
                        nombre_evento = "Inicialización";
                        x = 0;
                        
                        dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_pago, metodo_pago, rnd_fin_at, tiempo_fin_atencion, caja1.finAtencion, caja2.finAtencion, caja1.estado + ' '  + caja1.nroCaja.ToString(), caja1.getTamCola().ToString(), caja2.estado, caja2.getTamCola().ToString());
                    }
                    else
                    {
                       if (prox_llegada < caja1.finAtencion && prox_llegada < caja2.finAtencion)
                        {
                            Cliente cl= new Cliente();

                            acum_clientes_llegan = acum_clientes_llegan + 1;
                            cl.id = x + 1;
                            nombre_evento = "Llegada_Cliente";
                            reloj = prox_llegada;
                            rnd_lleg_cliente = random.NextDouble();
                            tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
                            prox_llegada = tiempo_entre_llegadas;

                            if (caja1.estado == "Libre")
                            {
                                cl.estado = "SA";
                                caja1.estado = "Ocupado";
                                caja1.finAtencion = fin_atencion(reloj);
                                caja1.clientes.Enqueue(cl);

                            }

                            if (caja1.estado == "Ocupado")
                            {
                                if (caja2.estado == "Cerrado")
                                {

                                    if (caja1.getTamCola() < 4)
                                    {
                                        //agrega el cliente a la cola de la caja 1, le cambia su estado

                                        cl.estado = "EA";
                                        cl.numCaja = 1;
                                        caja1.clientes.Enqueue(cl);

                                        
                                    }
                                    else
                                    {
                                        //obtengo los dos últimos de la caja 1 y los pongo en la caja 2, y luego el cliente que llegó último
                                        Cliente clpos4;
                                        clpos4 = caja1.clientes.Last<Cliente>();
                                                                     
                                        caja2.clientes.Enqueue(clpos4);
                                        caja2.clientes.Enqueue(cl);

                                        //acutualiza estados
                                        caja2.estado = "Ocupado";
                                        clpos4.estado = "SA";
                                        cl.estado = "EA";
                                        clpos4.numCaja = 2;
                                        cl.numCaja = 2;

                                        //Invierto la cola de la caja1 para sacar los dos últimos elementos... no supe cómo borrar con el índice jujuju
                                        caja1.clientes.Reverse<Cliente>();
                                        caja1.clientes.Dequeue();

                                        caja1.clientes.Reverse<Cliente>();

                                        //fin de atención para el cliente que empezó a atender la caja 2
                                        caja2.finAtencion = fin_atencion(reloj);

                                        // contador caja 2 usada
                                        cant_caja_2_usada = cant_caja_2_usada + 1;



                                        /* 
                                         caja2.estado = "Ocupado"
                                         cola caja 2 = 2
                                         cola caja 1 = 2 (más el que está siendo atendido)
                                         agrego el cliente al vector de la caja 2 (el que será atendido es el que estaba 3ro en la cola, calculo el fin_at 
                                         para la caja 2
                                         caja 1 -> le cambio estado
                                         quedan en la cola el 4to cliente de la cola 1 y el que acaba de llegar

                                         */

                                    }
                                }
                                // la caja 2 estaría en Ocupado (No tiene estado Libre, porque cuando se desocupa cierra)
                                else
                                {
                                    if (caja1.getTamCola() <= caja2.getTamCola())
                                    {
                                        //agregar a cola 1
                                        cl.estado = "EA";
                                        cl.numCaja = 1;
                                        caja1.clientes.Enqueue(cl);

                                    }
                                    else
                                    {
                                        //agregar a cola 2
                                        cl.estado = "EA";
                                        cl.numCaja = 2;
                                        caja2.clientes.Enqueue(cl);

                                    }

                                    /*cl.estado = "EA";
                                    cl.numCaja = 1;
                                    caja1.clientes.Enqueue(cl);*/
                                }

                            }
                            dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_pago, metodo_pago, rnd_fin_at, tiempo_fin_atencion, caja1.finAtencion, caja2.finAtencion, caja1.estado + ' '  + caja1.nroCaja.ToString(), caja1.getTamCola().ToString(), caja2.estado, caja2.getTamCola().ToString());
                        }
                        if (caja1.finAtencion < prox_llegada && caja1.finAtencion < caja2.finAtencion)
                        {

                            reloj = caja1.finAtencion;
                            //acumulador de cantidad de clientes con atencion finalizada
                            acum_clientes_at_finalizada = acum_clientes_at_finalizada + 1;
                            //quitar el cliente que se va de la cola
                            caja1.clientes.Dequeue();

                            // actualizar AC tiempo de atención y contador clientes con atención finalizada
                            //eliminar al cliente que se va
                            if (caja1.clientes.Count == 0)
                            {
                                caja1.estado = "Libre";

                            }
                            else
                            {
                                //estado de cliente a SA
                                Cliente c;
                                c = caja1.clientes.First<Cliente>();
                                c.estado = "SA";
                                caja1.estado = "Ocupado";
                                caja1.finAtencion = fin_atencion(reloj);   //fin de atención del nuevo cliente atendido

                            }
                            dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_pago, metodo_pago, rnd_fin_at, tiempo_fin_atencion, caja1.finAtencion, caja2.finAtencion, caja1.estado + ' ' + caja1.nroCaja.ToString(), caja1.getTamCola().ToString(), caja2.estado, caja2.getTamCola().ToString());
                        }
                        // Cami, acá te cambié esto porque sino nunca iba a entrar a este if que habías puesto,
                        // tiene que estar afuera
                        if (caja2.finAtencion < prox_llegada && caja2.finAtencion < caja1.finAtencion)
                        {
                            reloj = caja2.finAtencion;
                            //acumulador de cantidad de clientes con atencion finalizada
                            acum_clientes_at_finalizada = acum_clientes_at_finalizada + 1;
                            //quitar el cliente que se va de la cola
                            caja2.clientes.Dequeue();

                            // actualizar AC tiempo de atención y contador clientes con atención finalizada
                            //eliminar al cliente que se va
                            if (caja2.clientes.Count == 0)
                            {
                                caja2.estado = "Cerrado";

                            }
                            else
                            {
                                //estado de cliente a SA

                                Cliente c;
                                c = caja2.clientes.First<Cliente>();
                                c.estado = "SA";
                                caja2.estado = "Ocupado";
                                caja2.finAtencion = fin_atencion(reloj);   //fin de atención del nuevo cliente atendido

                            }
                            dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_pago, metodo_pago, rnd_fin_at, tiempo_fin_atencion, caja1.finAtencion, caja2.finAtencion, caja1.estado + ' ' + caja1.nroCaja.ToString(), caja1.getTamCola().ToString(), caja2.estado, caja2.getTamCola().ToString());

                        }

                    }
                    
                }
            }
            if (rbCasoB.Checked)
            {
                for (int i = 0; i <= corteB; i++)
                {
                    //evento de inicialización
                    if (x == -1)
                    {
                        rnd_lleg_cliente = random.NextDouble();
                        tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
                        prox_llegada = tiempo_entre_llegadas;
                        caja1.estado = "Libre";
                        nombre_evento = "Inicialización";
                        x++;
                        
                        dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_pago, metodo_pago, rnd_fin_at, tiempo_fin_atencion, caja1.finAtencion, caja2.finAtencion, caja1.estado + ' ' + caja1.nroCaja.ToString(), caja1.getTamCola().ToString(), caja2.estado, caja2.getTamCola().ToString());
                    }
                    if (prox_llegada < caja1.finAtencion && prox_llegada < caja2.finAtencion && prox_llegada < menorGondolas(/*lista de clientes*/).fin_gondola) //comprar también con los fin_gondola 
                    {
                        Cliente cl = new Cliente();

                        acum_clientes_llegan = acum_clientes_llegan + 1;
                        cl.id = x + 1;
                        reloj = prox_llegada;
                        cl.hora_llegada = reloj;
                        nombre_evento = "Llegada_Cliente";
                        rnd_lleg_cliente = random.NextDouble();
                        tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
                        prox_llegada = tiempo_entre_llegadas;
                        cl.fin_gondola = fin_gondola() ;
                        cl.estado = "RG";
                        cli_gondolas.Add(cl);
                    }


                    //if de cuando ocurre tiempo_fin_gondola <............
                    /*
                     {
                     Cliente cl = new Cliente();
                     cl = menorGondolas();
                     reloj = cl.fin_gondola;
                     nombre_evento = "Fin_Recorrer_Góndolas"
                     cli_gondolas.Remove(cli);
                     
                     
                    /*
                   if (caja1.estado == "Libre")
                   {
                       cl.estado = "SA";
                       caja1.estado = "Ocupado";
                       caja1.finAtencion = fin_atencion();
                       caja1.cliente.Enqueue(cl);

                   }

                   if (caja1.estado == "Ocupado")
                   {
                       if (caja2.estado == "Cerrado")
                       {

                           if (caja1.getTamCola() < 4)
                           {
                               //agrega el cliente a la cola de la caja 1, le cambia su estado

                               cl.estado = "EA";
                               cl.numCaja = 1;
                               caja1.cliente.Enqueue(cl);


                           }
                           else
                           {
                               //obtengo los dos últimos de la caja 1 y los pongo en la caja 2, y luego el cliente que llegó último
                               Cliente clpos3 = new Cliente();
                               Cliente clpos4 = new Cliente();
                               clpos4 = caja1.cliente.Last<Cliente>();
                               clpos3 = caja1.cliente.Last<Cliente>();

                               caja2.cliente.Enqueue(clpos3);
                               caja2.cliente.Enqueue(clpos4);
                               caja2.cliente.Enqueue(cl);

                               //acutualiza estados
                               caja2.estado = "Ocupado";
                               clpos3.estado = "SA";
                               cl.estado = "EA";
                               clpos3.numCaja = 2;
                               clpos4.numCaja = 2;
                               cl.numCaja = 2;

                               //Invierto la cola de la caja1 para sacar los dos últimos elementos... no supe cómo borrar con el índice jujuju
                               caja1.cliente.Reverse<Cliente>();
                               caja1.cliente.Dequeue();
                               caja1.cliente.Dequeue();

                               caja1.cliente.Reverse<Cliente>();

                               //fin de atención para el cliente que empezó a atender la caja 2
                               caja2.finAtencion = fin_atencion();

                               // contador caja 2 usada
                               cant_caja_2_usada = cant_caja_2_usada + 1;

                           }
                       }
                       // la caja 2 estaría en Ocupado (No tiene estado Libre, porque cuando se desocupa cierra)
                       else
                       {
                           if (caja1.getTamCola() <= caja2.getTamCola())
                           {
                               //agregar a cola 1
                               cl.estado = "EA";
                               cl.numCaja = 1;
                               caja1.cliente.Enqueue(cl);

                           }
                           else
                           {
                               //agregar a cola 2
                               cl.estado = "EA";
                               cl.numCaja = 2;
                               caja2.cliente.Enqueue(cl);

                           }

                           cl.estado = "EA";
                           cl.numCaja = 1;
                           caja1.cliente.Enqueue(cl);
                       }

                   }
                   dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_pago, metodo_pago, rnd_fin_at, tiempo_fin_atencion, caja1.finAtencion, caja2.finAtencion, caja1.estado + ' ' + caja1.nroCaja.ToString(), caja1.getTamCola().ToString(), caja2.estado, caja2.getTamCola().ToString());
               }
               */

                    //if de los fin_atencion
                    if (caja1.finAtencion < prox_llegada && caja1.finAtencion < caja2.finAtencion && caja1.finAtencion < menorGondolas(caja1, caja2).fin_gondola) // agregar la comparación de los tiempos de góndola
                    {

                        reloj = caja1.finAtencion;
                        //acumulador de cantidad de clientes con atencion finalizada
                        acum_clientes_at_finalizada = acum_clientes_at_finalizada + 1;
                        
                        //acumulador de permanencia
                        Cliente clFuera = new Cliente();
                        clFuera = caja1.clientes.First<Cliente>();
                        acum_tiempo_permanencia = acum_tiempo_permanencia + (reloj - clFuera.hora_llegada);

                        //quitar el cliente que se va de la cola
                        caja1.clientes.Dequeue();

                        // actualizar AC tiempo de atención y contador clientes con atención finalizada
                        //eliminar al cliente que se va
                        if (caja1.clientes.Count == 0)
                        {
                            caja1.estado = "Libre";

                        }
                        else
                        {
                            //estado de cliente a SA
                            Cliente c = new Cliente();
                            c = caja1.clientes.First<Cliente>();
                            c.estado = "SA";
                            caja1.estado = "Ocupado";
                            caja1.finAtencion = fin_atencion(reloj);   //fin de atención del nuevo cliente atendido

                        }
                       
                        dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_pago, metodo_pago, rnd_fin_at, tiempo_fin_atencion, caja1.finAtencion, caja2.finAtencion, caja1.estado + ' ' + caja1.nroCaja.ToString(), caja1.getTamCola().ToString(), caja2.estado, caja2.getTamCola().ToString());
                    }
                    
                    if (caja2.finAtencion < prox_llegada && caja2.finAtencion < caja1.finAtencion)
                    {
                        reloj = caja2.finAtencion;
                        //acumulador de cantidad de clientes con atencion finalizada
                        acum_clientes_at_finalizada = acum_clientes_at_finalizada + 1;
                        //acumulador de permanencia
                        Cliente clFuera = new Cliente();
                        clFuera = caja2.clientes.First<Cliente>();
                        acum_tiempo_permanencia = acum_tiempo_permanencia + (reloj - clFuera.hora_llegada);

                        //quitar el cliente que se va de la cola
                        caja2.clientes.Dequeue();

                        if (caja2.cola == 0)
                        {
                            caja2.estado = "Cerrado";

                        }
                        else
                        {
                            //estado de cliente a SA

                            Cliente c = new Cliente();
                            c = caja2.clientes.First<Cliente>();
                            c.estado = "SA";
                            caja2.estado = "Ocupado";
                            caja2.finAtencion = fin_atencion(reloj);   // tiempo de fin de atención del nuevo cliente atendido

                        }
                        dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_pago, metodo_pago, rnd_fin_at, tiempo_fin_atencion, caja1.finAtencion, caja2.finAtencion, caja1.estado + ' ' + caja1.nroCaja.ToString(), caja1.getTamCola().ToString(), caja2.estado, caja2.getTamCola().ToString());

                     }

                }
            }
            
        }

        private void rbCasoA_CheckedChanged(object sender, EventArgs e)
        {
            tbxDesdeDemoraCliente.Enabled = false;
            tbxHastaDemoraCliente.Enabled = false;
            tbxCorteB.Enabled = false;
            
        }
        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rbCasoA.Checked = false;
            rbCasoB.Checked = false;
            tbxDesdeFilas.Clear();
            tbxHastaFilas.Clear();
            tbxDesdeDemoraCliente.Enabled = true;
            tbxDesdeDemoraCaja.Clear();
            tbxHastaDemoraCliente.Enabled = true;
            tbxHastaDemoraCaja.Clear();
            tbxDesdeDemoraCliente.Clear();
            tbxHastaDemoraCliente.Clear();
            tbxMedia.Clear();
            tbxCorteB.Clear();
            tbxCorteB.Enabled = true;
            

            dgv_datos.DataSource = null;

        }

        private void dgv_datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbCasoB_CheckedChanged_1(object sender, EventArgs e)
        {
            tbxDesdeDemoraCliente.Enabled = true;
            tbxHastaDemoraCliente.Enabled = true;
            tbxCorteB.Enabled = true;
            tbxCorteA.Enabled = false;
        }
    }
}

