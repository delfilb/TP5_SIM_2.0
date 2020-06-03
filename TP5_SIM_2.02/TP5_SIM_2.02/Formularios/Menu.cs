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
            caja2.estado = "Cerrado";



            int x = 1;

            int media = int.Parse(tbxMedia.Text);
            int demoraCajaDesde = int.Parse(tbxDesdeDemoraCaja.Text);
            int demoraCajaHasta = int.Parse(tbxHastaDemoraCaja.Text);

            string nombre_evento = "";
            double reloj = 0;
            string metodo_pago = "";
            double fin_at_caja_1 = 100;
            double fin_at_caja_2 = 100;
            string estado_caja_1 = "";
            int cola_caja_1 = 0;
            string estado_caja_2 = "";
            int cola_caja_2 = 0;
            int cant_clientes_finalizados = 0;

            double acum_tiempo_at = 0;
            int acum_clientes_at_finalizada = 0;

            double tiempo_ocioso_caja_1;
            
            int cant_caja_2_usada;
            

            // variables que se necesitan para la fila Inicializacion 
            double rnd_lleg_cliente = random.NextDouble();
            double rnd_fin_at = 0;
            double rnd_pago = 0;
            double tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
            double tiempo_fin_atencion = 0;
            double prox_llegada = tiempo_entre_llegadas;

            double fin_atencion()
            {
                double fin_at;
                rnd_fin_at = random.NextDouble();
                tiempo_fin_atencion = demoraCajaDesde * rnd_fin_at * (demoraCajaHasta - demoraCajaDesde);
                rnd_pago = random.NextDouble();
                if (rnd_pago < 0.5)
                {
                    metodo_pago = "Efectivo";
                    fin_at = tiempo_fin_atencion + reloj;

                }
                //tarjeta
                else
                {
                    fin_at = tiempo_fin_atencion + 2 + reloj;

                }
                return fin_at;
              }


            // i = filas
            // caso A
            if (rbCasoA.Checked)
            { //for para cada cliente i = id ??
                for (int i = 0; i < 11)
                {

                    if (prox_llegada < fin_at_caja_1 && prox_llegada < fin_at_caja_2)
                    {
                        Cliente cl = new Cliente();
                        cl.id = i;
                        reloj = prox_llegada;
                        rnd_lleg_cliente = random.NextDouble();
                        tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
                        prox_llegada = tiempo_entre_llegadas;
                        if (caja1.estado == "Libre")
                        {
                            cl.estado = "SA";
                            caja1.estado = "Ocupado";

                            fin_at_caja_1 = fin_atencion();

                        }

                        if (caja1.estado == "Ocupado")
                        {
                            if (caja2.estado == "Cerrado")
                            {
                                if (caja1.cola < 4)
                                {
                                    //agrega el cliente a la cola de la caja 1, le cambia su estado

                                    cl.estado = "EA";
                                }
                                else
                                {
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

                                }
                                else
                                {
                                    //agregar a cola 2

                                }

                                cl.estado = "EA";
                            }

                        }
                    }
                    if (fin_at_caja_1 < prox_llegada && fin_at_caja_1 < fin_at_caja_2)
                    {
                        reloj = fin_at_caja_1;
                        // actualizar AC tiempo de atención y contador clientes con atención finalizada
                        //elimina al cliente que se va
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

                        if (fin_at_caja_2 < prox_llegada && fin_at_caja_2 < fin_at_caja_1)
                        {
                            reloj = fin_at_caja_2;
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
            
            dgv_datos.DataSource = null;

        }
    }
}

