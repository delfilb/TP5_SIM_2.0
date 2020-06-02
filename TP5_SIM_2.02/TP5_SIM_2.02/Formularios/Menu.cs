﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP5_SIM_2._02.Clases;

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
            Dictionary<int, string> clientesEnCola = new Dictionary<int, string>();

            Cliente cli = new Cliente();
            Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();

            int n = 0;
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
            double tiempo_ocioso_caja_1 = 0;
            int cant_caja_2_usada = 0;

            double rnd_lleg_cliente = random.NextDouble();
            double rnd_fin_at = 0;
            double rnd_pago = 0;
            double tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
            double tiempo_fin_atencion = 0;
            double tiempo_atencion = tiempo_entre_llegadas;

            double[] acum_tiempo_at;
            acum_tiempo_at = new double[100];

            int[] acum_clientes_at_finalizada;
            acum_clientes_at_finalizada = new int[100];

            // i = filas
            for (int i = 0; acum_clientes_at_finalizada[i] < 11; i++)
            {

                // calculo estado caja 2
                if (cola_caja_1 == 5)
                {
                    estado_caja_2 = "Ocupado";
                    cola_caja_2 = 2;
                    cola_caja_1 = 3;
                }
                else
                {
                    estado_caja_2 = "Cerrado";

                }

                // fila: Inicializacion  ->  reloj = 0,00
                if (i == 0)
                {
                    nombre_evento = "Inicializacion";
                    reloj = 0.00;
                    acum_tiempo_at[i] = 0;
                    acum_clientes_at_finalizada[i] = 0;
                    rnd_lleg_cliente = random.NextDouble();
                    tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
                    tiempo_atencion = tiempo_entre_llegadas + reloj;

                    dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, tiempo_atencion, rnd_fin_at, tiempo_fin_atencion, rnd_pago, metodo_pago, fin_at_caja_1, fin_at_caja_2, estado_caja_1, cola_caja_1, estado_caja_2, cola_caja_2, acum_tiempo_at[i], acum_clientes_at_finalizada[i], tiempo_ocioso_caja_1, cant_caja_2_usada);
                }
                // a partir de fila = 1 ->   eventos tienen nombre
                else
                {
                    // calculo proximo evento
                    // tiempo_atencion, fin_at_caja_1, fin_at_caja_2  ->  valores vienen de la fila anterior
                    // nombre_evento, reloj  ->  fila actual
                    // por cada 'llegada_cliente' agrego un cliente 'cli' al diccionario, lo que cambia es el indice (x) de ese diccionario.
                    // si es la fila 1 se crea el cliente con todos sus atributos 
                    // sino se crea solo con su estado 
                    if (tiempo_atencion < fin_at_caja_1 && tiempo_atencion < fin_at_caja_2)
                    {
                        nombre_evento = "llegada_cliente";
                        reloj = tiempo_atencion;

                        x = x + 1;
                        clientes.Add(x, cli);
                        // si es la primer fila o el dicionario clientes no tiene ninguna cliente guardado, el cliente nuevo se guarda en el indice 1
                        // en otro caso, se añade el cliente en el indice x con estado "EA";
                        if (i == 1 || clientes.Count() == 0)
                        {
                            clientes[1].estado = "SAC";
                        }
                        else
                        {
                            clientes[x].estado = "EA";
                            cola_caja_1 = cola_caja_1 + 1;
                        }
                    }
                    else
                    {
                        if (fin_at_caja_1 < tiempo_atencion && fin_at_caja_1 < fin_at_caja_2)
                        {
                            // se elimina el cliente que tiene indice 1, por ende estado "SAC", en el diccionario clientes.
                            // pasa al indice 1 el que tenia indice 2 y su estado cambia a "SAC"
                            reloj = fin_at_caja_1;
                            nombre_evento = "fin_atencion_caja_1";
                            clientes.Remove(1);
                            clientes[1].estado = "SAC";
                            x = x - 1;
                            cola_caja_1 = cola_caja_1 - 1;
                        }
                        else
                        {
                            reloj = fin_at_caja_2;
                            nombre_evento = "fin_atencion_caja_2";
                        }
                    }

                    // todos estos datos son de la fila actual
                    // se calcula toda las columnas de "llegada cliente" y "fin atencion caja (i)"
                    // ya sea cuando la caja con cola se desocupa y se atiende al siguiente en cola
                    // o cuando llega un nuevo cliente
                    if ((nombre_evento == "fin_atencion_caja_1" && cola_caja_1 > 0) || nombre_evento == "llegada_cliente")
                    {
                        estado_caja_1 = "Ocupado";

                        rnd_lleg_cliente = random.NextDouble();
                        rnd_fin_at = random.NextDouble();
                        rnd_pago = random.NextDouble();

                        tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
                        tiempo_fin_atencion = demoraCajaDesde + rnd_fin_at * (demoraCajaHasta - demoraCajaDesde);
                        tiempo_atencion = tiempo_entre_llegadas + reloj;

                        // definicion metodo de pago -> P(), si paga con tarjeta la atencion de caja se demora 2 min mas
                        if (rnd_pago < 0.8)
                        {
                            metodo_pago = "Efectivo";
                            fin_at_caja_1 = tiempo_fin_atencion + reloj;
                        }
                        else
                        {
                            metodo_pago = "Tarjeta";
                            fin_at_caja_1 = tiempo_fin_atencion + reloj + 2;
                        }
                    }
                    else
                    {
                        estado_caja_1 = "Libre";
                    }


                    // acumulador tiempo de atencion segun estado caja 
                    if (estado_caja_1 == "Libre")
                    {
                        acum_tiempo_at[i] = acum_tiempo_at[i - 1] + reloj;
                    }
                    else
                    {
                        acum_tiempo_at[i] = acum_tiempo_at[i - 1];
                    }

                    // acumulador cantidad de clientes con atencion finalizada
                    if (nombre_evento == "fin_atencion_caja_2" || nombre_evento == "fin_atencion_caja_1")
                    {
                        acum_clientes_at_finalizada[i] = acum_clientes_at_finalizada[i - 1] + 1;
                    }
                    else
                    {
                        acum_clientes_at_finalizada[i] = acum_clientes_at_finalizada[i - 1];
                    }


                    dgv_datos.Rows.Add(nombre_evento, reloj, rnd_lleg_cliente, tiempo_entre_llegadas, tiempo_atencion, rnd_fin_at, tiempo_fin_atencion, rnd_pago, metodo_pago, fin_at_caja_1, fin_at_caja_2, estado_caja_1, cola_caja_1, estado_caja_2, cola_caja_2, acum_tiempo_at[i], acum_clientes_at_finalizada[i], tiempo_ocioso_caja_1, cant_caja_2_usada);


                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

