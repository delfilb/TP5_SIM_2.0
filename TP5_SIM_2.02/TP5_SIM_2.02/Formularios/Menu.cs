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

       
      
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            

            Cliente cli = new Cliente();
            Caja caja1 = new Caja();
            Caja caja2 = new Caja();
            caja1.estado = "Libre";
            caja1.nroCaja = 1;
            caja2.estado = "Cerrado";
            caja2.nroCaja = 2;


            int media = int.Parse(tbxMedia.Text);
            int demoraCajaDesde = int.Parse(tbxDesdeDemoraCaja.Text);
            int demoraCajaHasta = int.Parse(tbxHastaDemoraCaja.Text);


            string nombre_evento = "";
            string metodo_pago = "";
            double fin_at_caja_1 = 100;
            double fin_at_caja_2 = 100;
            string estado_caja_1 = "";
            int cola_caja_1 = 0;
            string estado_caja_2 = "";
            int cola_caja_2 = 0;
            int cant_clientes_finalizados = 0;

            double acum_tiempo_at = 0;
            double acum_tiempo_ocioso_caja1 = 0;
            int acum_clientes_at_finalizada = 0;

            double tiempo_ocioso_caja_1;
            
            int cant_caja_2_usada;
            double rnd_pago = 0;
            double rnd_fin_at = 0;
            double tiempo_fin_atencion = 0;

            double rnd_lleg_cliente = 0;
            double tiempo_entre_llegadas = 0;
            double prox_llegada = 0;
            int x = 1;
            double reloj = 0;


            //Este metodo sirve para calcular el final de atención teniendo en cuenta
            //la forma de pago con efectivo y con tarjeta
            //retorna un número que es el tiempo de fin de atención para un cliente

            double fin_atencion()
            {
                double fin_at;
                rnd_fin_at = random.NextDouble();

                //Cami, acá te corregí la fórmula porque habias puesto demora_caja_desde * ...
                //Lo correcto era sumarle la media
                tiempo_fin_atencion = media + rnd_fin_at * (demoraCajaHasta - demoraCajaDesde);
                rnd_pago = random.NextDouble();
                if (rnd_pago < 0.5)
                {
                    metodo_pago = "Efectivo";
                    fin_at = tiempo_fin_atencion + reloj;

                }
                //tarjeta
                else
                {
                    metodo_pago = "Tarjeta";
                    fin_at = tiempo_fin_atencion + 2 + reloj;

                }
                // acumulador de tiempo de atencion
                acum_tiempo_at = acum_tiempo_at + fin_at;
                return fin_at;
            }


            // i = filas
            // caso A
            if (rbCasoA.Checked)
            { //for para cada cliente el id = x y le vamos sumando 1 por cada iteración.
                for (int i = 0; i < 11; i++)
                {

                    //evento de inicialización
                    if (i == 0)
                    {
                        rnd_lleg_cliente = random.NextDouble();
                        tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
                        prox_llegada = tiempo_entre_llegadas;
                        caja1.estado = "Libre";
                        nombre_evento = "Inicialización";
                        caja1.clientes[caja1.clientes.Length] = 0;
                        dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, prox_llegada, rnd_fin_at, fin_at_caja_1, rnd_pago, metodo_pago, fin_at_caja_1, 0 /*Acá le puse 0 porque la caja 2 aun no atiende*/ , caja1.estado + ' '  + caja1.nroCaja.ToString(), caja1.cola.ToString(), caja2.estado, caja2.cola.ToString());
                    }
                    else
                    {
                        if (prox_llegada < fin_at_caja_1 && prox_llegada < fin_at_caja_2)
                        {
                            Cliente cl = new Cliente();
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
                                fin_at_caja_1 = fin_atencion();
                                caja1.clientes[caja1.clientes.Length] = cl;

                            }

                            if (caja1.estado == "Ocupado")
                            {
                                if (caja2.estado == "Cerrado")
                                {

                                    if (caja1.cola < 4)
                                    {
                                        //agrega el cliente a la cola de la caja 1, le cambia su estado

                                        cl.estado = "EA";
                                        cl.numCaja = 1;
                                        caja1.clientes[caja1.clientes.Length] = cl;



                                    }
                                    else
                                    {

                                        caja2.estado = "Ocupado";
                                        cl.estado = "SA";
                                        cl.numCaja = 2;
                                        caja2.clientes[caja2.clientes.Length] = cl;


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
                                    if (caja1.cola <= caja2.cola)
                                    {
                                        //agregar a cola 1
                                        cl.estado = "EA";
                                        cl.numCaja = 1;
                                        caja1.clientes[caja1.clientes.Length] = cl;

                                    }
                                    else
                                    {
                                        //agregar a cola 2
                                        cl.estado = "EA";
                                        cl.numCaja = 2;
                                        caja2.clientes[caja2.clientes.Length] = cl;

                                    }

                                    cl.estado = "EA";
                                }

                            }
                        }
                        if (fin_at_caja_1 < prox_llegada && fin_at_caja_1 < fin_at_caja_2)
                        {
                            reloj = fin_at_caja_1;
                            //acumulador de cantidad de clientes con atencion finalizada
                            acum_clientes_at_finalizada = acum_clientes_at_finalizada + 1;
                            // actualizar AC tiempo de atención y contador clientes con atención finalizada
                            //eliminar al cliente que se va
                            if (caja1.cola == 0)
                            {
                                caja1.estado = "Libre";
                            }
                            else
                            {
                                //estado de cliente a SA
                                caja1.estado = "Ocupado";
                                fin_at_caja_1 = fin_atencion();   //fin de atención del nuevo cliente atendido

                            }
                        }
                        // Cami, acá te cambié esto porque sino nunca iba a entrar a este if que habías puesto,
                        // tiene que estar afuera
                        if (fin_at_caja_2 < prox_llegada && fin_at_caja_2 < fin_at_caja_1)
                        {
                            reloj = fin_at_caja_2;
                            //acumulador de cantidad de clientes con atencion finalizada
                            acum_clientes_at_finalizada = acum_clientes_at_finalizada + 1;

                            // actualizar AC tiempo de atención y contador clientes con atención finalizada
                            //elimina al cliente que se va
                            if (caja2.cola == 0)
                                {
                                    caja2.estado = "Cerrado";
                                }
                                else
                                {
                                    //estado de cliente a SA
                                    caja2.estado = "Ocupado";
                                    fin_at_caja_2 = fin_atencion();   //fin de atención del nuevo cliente atendido

                                }
                            
                        }
                    }
                }
            }


        }

        private void rbCasoA_CheckedChanged(object sender, EventArgs e)
        {
            tbxDesdeDemoraCliente.Enabled = false;
            tbxHastaDemoraCliente.Enabled = false;
            tbxMinutosSimularB.Enabled = false;
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
            tbxMinutosSimularB.Clear();
            tbxMinutosSimularB.Enabled = true;
            

            dgv_datos.DataSource = null;

        }
    }
}

