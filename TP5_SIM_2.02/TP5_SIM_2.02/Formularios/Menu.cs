using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        

        public void mayorACero(List<double> valores)
        {
            for (int i = 0;i<valores.Count; i++)
            {
                if (valores[i] == 0)
                {
                    valores[i] = 9999;
                }
            }
        }


        public void finGondola(List<Cliente> gondolas ,object[][] vector, double proximaLlegada,double reloj, Caja caja1, Caja caja2, double a, double b, double acTiempoPerm, double acTiempoAtencion, int cantClientesAtendedios, double acTiempoOcioso, int vecesCaja2Abrio)
        {
            Cliente cli = new Cliente();
            foreach(Cliente c in gondolas)
            {
                if (c.fin_gondola == reloj)
                {
                    cli = c;
                    gondolas.Remove(c);
                }
            }
            string evento = "Fin Góndola";
            double rndDemora = 0;
            double demoraAtencion = 0;
            double rndMetodo = 0;
            string metodo = "";
            if (caja1.estado != "Ocupado")
            {
                rndDemora = random.NextDouble();
                demoraAtencion = a + (rndDemora * (b - a));
                rndMetodo = random.NextDouble();
                if (rndMetodo < 0.2)
                {
                    metodo = "Tarjeta";
                    demoraAtencion += 2;
                }
                else
                {
                    metodo = "Efectivo";
                }
                cli.estado = "SA";
                cli.numCaja = 1;
                caja1.estado = "Ocupado";
                caja1.finAtencion = demoraAtencion + reloj;
                caja1.clientes.Enqueue(cli);
            }
            else if (caja1.clientes.Count > 4)
            {
                if (caja2.estado == "Cerrado")
                {
                    // cola caja1.clientes se copia a una pila, luego de esa pila se sacan los ultimos dos
                    // se le asigan esos dos a caja2.clientes
                    // esa pila, sin esos dos ultimos, se pasa a cola de nuevo y se lo asigna a caja1.clientes
                    Stack<Cliente> pila = colaAPila(caja1.clientes);
                    Cliente extraccion_1 = pila.Pop();
                    caja2.clientes.Enqueue(extraccion_1);
                    caja1.clientes.Clear();
                    caja1.clientes = pilaACola(pila);

                    rndDemora = random.NextDouble();
                    demoraAtencion = a + (rndDemora * (b - a));
                    rndMetodo = random.NextDouble();
                    if (rndMetodo < 0.2)
                    {
                        metodo = "Tarjeta";
                        demoraAtencion += 2;
                    }
                    else
                    {
                        metodo = "Efectivo";
                    }
                    caja2.finAtencion = demoraAtencion + reloj;
                    cli.estado = "SA";
                    cli.numCaja = 2;
                    caja2.estado = "Ocupado";
                    caja2.clientes.Enqueue(cli);

                }
                else if (caja1.getTamCola() <= caja2.getTamCola())
                {
                    cli.estado = "EA";
                    cli.numCaja = 1;
                    caja1.clientes.Enqueue(cli);
                }
                else
                {
                    cli.estado = "EA";
                    cli.numCaja = 2;
                    caja2.clientes.Enqueue(cli);
                }
            }
            else
            {
                cli.estado = "EA";
                cli.numCaja = 1;
                caja1.clientes.Enqueue(cli);
            }


            double menorGondola;
            if (gondolas.Count > 0)
            {
                menorGondola = menorGondolas(gondolas).fin_gondola;
            }
            else
            {
                menorGondola = 0;
            }
            vector[1] = vector[0];
            vector[0] = new object[] { evento, reloj, 0, 0, proximaLlegada, 0, menorGondola, rndDemora, demoraAtencion, rndMetodo, metodo, caja1.finAtencion, caja2.finAtencion, caja1.estado, caja1.getTamCola(), caja2.estado, caja2.getTamCola(), acTiempoAtencion, cantClientesAtendedios, acTiempoOcioso, vecesCaja2Abrio, acTiempoPerm };

        }


        public void llegadaGodola(double media, List<Cliente> gondolas, object[][] vector, double reloj, Caja caja1, Caja caja2, double a, double b, double acTiempoPerm, double acTiempoAtencion, int cantClientesAtendedios, double acTiempoOcioso, int vecesCaja2Abrio)
        {
            string evento = "Llegada Cliente";
            double rndLlegada = random.NextDouble();
            double entre_llegada = -media * Math.Log(1 - rndLlegada);
            double proximaLlegada = entre_llegada + reloj;
            double rndDemoraGondola = random.NextDouble();
            double demoraGondola = a + (rndDemoraGondola * (b - a));
            double finGondola = demoraGondola + reloj;

            Cliente cli = new Cliente();
            cli.fin_gondola = finGondola;
            cli.hora_llegada = reloj;
            gondolas.Add(cli);
            double menorGondola = menorGondolas(gondolas).fin_gondola;

            vector[1] = vector[0];
            vector[0] = new object[] { evento, reloj, rndLlegada, entre_llegada, proximaLlegada, rndDemoraGondola, menorGondola, 0, 0, 0, "", caja1.finAtencion, caja2.finAtencion, caja1.estado, caja1.getTamCola(), caja2.estado, caja2.getTamCola(), acTiempoAtencion, cantClientesAtendedios, acTiempoOcioso, vecesCaja2Abrio, acTiempoPerm };


        }


        public void llegadaClienteA(double media, object[][] vector, double reloj, Caja caja1, Caja caja2, double a, double b, double acTiempoPerm, double acTiempoAtencion, int cantClientesAtendedios, double acTiempoOcioso, int vecesCaja2Abrio)
        {
            string evento = "Llegada Cliente";
            double rndLlegada = random.NextDouble();
            double entre_llegada = -media * Math.Log(1 - rndLlegada);
            double proximaLlegada = entre_llegada + reloj;
            double rndDemora = 0;
            double demoraAtencion = 0;
            double rndMetodo = 0;
            string metodo = "";

            Cliente cli = new Cliente();
            cli.hora_llegada = reloj;
            if (caja1.estado != "Ocupado")
            {
                rndDemora = random.NextDouble();
                demoraAtencion = a + (rndDemora * (b - a));
                rndMetodo = random.NextDouble();
                if (rndMetodo < 0.2)
                {
                    metodo = "Tarjeta";
                    demoraAtencion += 2;
                }
                else
                {
                    metodo = "Efectivo";
                }
                cli.estado = "SA";
                cli.numCaja = 1;
                caja1.estado = "Ocupado";
                caja1.finAtencion = demoraAtencion + reloj;
                caja1.clientes.Enqueue(cli);
            }
            else if (caja1.clientes.Count > 4)
            {
                if (caja2.estado == "Cerrado")
                {
                    // cola caja1.clientes se copia a una pila, luego de esa pila se sacan los ultimos dos
                    // se le asigan esos dos a caja2.clientes
                    // esa pila, sin esos dos ultimos, se pasa a cola de nuevo y se lo asigna a caja1.clientes
                    Stack<Cliente> pila = colaAPila(caja1.clientes);
                    Cliente extraccion_1 = pila.Pop();
                    caja2.clientes.Enqueue(extraccion_1);
                    caja1.clientes.Clear();
                    caja1.clientes = pilaACola(pila);

                    rndDemora = random.NextDouble();
                    demoraAtencion = a + (rndDemora * (b - a));
                    rndMetodo = random.NextDouble();
                    if (rndMetodo < 0.2)
                    {
                        metodo = "Tarjeta";
                        demoraAtencion += 2;
                    }
                    else
                    {
                        metodo = "Efectivo";
                    }
                    caja2.finAtencion = demoraAtencion + reloj;
                    cli.estado = "SA";
                    cli.numCaja = 2;
                    caja2.estado = "Ocupado";
                    caja2.clientes.Enqueue(cli);

                }
                else if (caja1.getTamCola() <= caja2.getTamCola())
                {
                    cli.estado = "EA";
                    cli.numCaja = 1;
                    caja1.clientes.Enqueue(cli);
                }
                else
                {
                    cli.estado = "EA";
                    cli.numCaja = 2;
                    caja2.clientes.Enqueue(cli);
                }
            }
            else
            {
                cli.estado = "EA";
                cli.numCaja = 1;
                caja1.clientes.Enqueue(cli);
            }
            vector[1] = vector[0];
            vector[0] = new object[] { evento, reloj, rndLlegada,entre_llegada , proximaLlegada,0,0, rndDemora, demoraAtencion, rndMetodo, metodo, caja1.finAtencion, caja2.finAtencion, caja1.estado, caja1.getTamCola(), caja2.estado, caja2.getTamCola(), acTiempoAtencion, cantClientesAtendedios, acTiempoOcioso, vecesCaja2Abrio, acTiempoPerm };


        }

        public void finAtencion(double finGondola,double a, double b, Caja caja1, Caja caja2, double reloj, double proximaLlegada, double acTiempoPerm, double acTiempoAtencion, int cantClientesAtendidos, object[][]vector, double acTiempoOcioso, int vecesCaja2Abrio)
        {
            string evento = "Fin Atención";
            double rndDemora = 0;
            double demoraAtencion = 0;
            double rndMetodo = 0;
            string metodo = "";


            if (caja1.finAtencion == reloj)
            {
                
                acTiempoAtencion += caja1.finAtencion;
                Cliente cliAtendido = caja1.clientes.First();
                double tiempoPermanencia = reloj - cliAtendido.hora_llegada;
                acTiempoPerm += tiempoPermanencia;
                caja1.clientes.Dequeue();
                

                if (caja1.clientes.Count > 0)
                {
                    rndDemora = random.NextDouble();
                    demoraAtencion = a + (rndDemora * (b - a));
                    rndMetodo = random.NextDouble();
                    if (rndMetodo < 0.2)
                    {
                        metodo = "Tarjeta";
                        demoraAtencion += 2;
                    }
                    else
                    {
                        metodo = "Efectivo";
                    }
                    caja1.finAtencion = demoraAtencion + reloj;
                    Cliente siguiente = caja1.clientes.First();
                    siguiente.estado = "SA";
                    siguiente.numCaja = 1;

                }
                else if (caja1.clientes.Count == 0)
                {
                    caja1.estado = "Libre";
                    caja1.finAtencion = 0;
                }

            }
            if (caja2.finAtencion == reloj)
            {
                acTiempoAtencion += caja2.finAtencion;
                Cliente cliAtendido = caja2.clientes.Peek();
                double tiempoPermanencia = reloj - cliAtendido.hora_llegada;
                acTiempoPerm += tiempoPermanencia;
                caja2.clientes.Dequeue();
                if (caja2.clientes.Count > 0)
                {
                    rndDemora = random.NextDouble();
                    demoraAtencion = a + (rndDemora * (b - a));
                    rndMetodo = random.NextDouble();
                    if (rndMetodo < 0.2)
                    {
                        metodo = "Tarjeta";
                        demoraAtencion += 2;
                    }
                    else
                    {
                        metodo = "Efectivo";
                    }
                    caja2.finAtencion = demoraAtencion + reloj;
                    Cliente siguiente = caja2.clientes.First();
                    siguiente.estado = "SA";
                    siguiente.numCaja = 2;
                }
                else if (caja2.clientes.Count == 0)
                {
                    caja2.estado = "Cerrado";
                    caja2.finAtencion = 0;
                }

            }
            vector[1] = vector[0];
            vector[0] = new object[] { evento, reloj, 0, 0, proximaLlegada,0,finGondola, rndDemora, demoraAtencion, rndMetodo, metodo, caja1.finAtencion, caja2.finAtencion, caja1.estado, caja1.getTamCola(), caja2.estado, caja2.getTamCola(), acTiempoAtencion, cantClientesAtendidos, acTiempoOcioso, vecesCaja2Abrio, acTiempoPerm };

        }


        public void inicializacion(double media ,object[][]vector)
        {
            double reloj = 0.0;
            string evento = "Inicializacion";            
            double rnd = random.NextDouble();
            double entre_llegada = -media * Math.Log(1 - rnd);
            double proximaLlegada = entre_llegada + reloj;
            vector[0] = new object[]{ evento, reloj, rnd, entre_llegada, proximaLlegada,0,0, 0, 0, 0, "", 0, 0, "Libre", 0, "Cerrado", 0, 0, 0, 0, 0,0};
            vector[1] = vector[0];
        }

        public Stack<Cliente> colaAPila(Queue<Cliente> clientes) 
        {
            
            Stack<Cliente> pilaClientes = new Stack<Cliente>();

            foreach (Cliente cli in clientes)
            {
                pilaClientes.Push(cli);
            }
            return pilaClientes;
        }

        public Queue<Cliente> pilaACola(Stack<Cliente> pilaClientes) {
            
            Queue<Cliente> colaClientes = new Queue<Cliente>();

            foreach (Cliente cli in pilaClientes)
            {
                colaClientes.Enqueue(cli);
            }
            return colaClientes;
        }

        

        public Cliente menorGondolas(List<Cliente> cli_gondolas)
        {
            double menor = 0;
            
            List<double> tiempos = new List<double>();
            foreach(Cliente cli in cli_gondolas)
            {
                tiempos.Add(cli.fin_gondola);
            }
            menor = tiempos.Min();
            return cli_gondolas.Find(c => c.fin_gondola == menor);
                  
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            Caja caja1 = new Caja();
            
            Caja caja2 = new Caja();

            string iter = txtIteraciones.Text;
            string des = tbxDesde.Text;
            string has = tbxHasta.Text;

            if (iter == "" || des == "" || has == "")
            {
                MessageBox.Show("Ingrese todo los valores");
                txtIteraciones.Focus();
            }
            else
            {
                double iteracion = double.Parse(iter);
                double desde = double.Parse(des);
                double hasta = double.Parse(has);
                double media = double.Parse(tbxMedia.Text);
                double a = double.Parse(tbxDesdeDemoraCaja.Text);
                double b = double.Parse(tbxHastaDemoraCaja.Text);
                double desdeGondola = double.Parse(tbxDesdeDemoraCliente.Text);
                double hastaGondola = double.Parse(tbxHastaDemoraCliente.Text);

                object[][] vectorEstado = new object[2][];
                vectorEstado[0] = new object[22];
                vectorEstado[1] = new object[22];

                //**************Esto agregue
                //contador
                int[] contador;
                contador = new int[2];
                //***************************

                if (desde >= hasta)
                {
                    MessageBox.Show("El valor 'Hasta' debe ser mayor al valor 'Desde'");
                    tbxDesde.Focus();
                }
                else
                {
                    if (desde < iteracion && hasta <= iteracion && hasta > desde)
                    {
                        double minuto= 0.0;
                        double proximaLlegada;
                        double finAtencion1;
                        double finAtencion2;

                        //estadisticas
                        double acTiempoAtencion = 0;
                        int acClientesAtendidos = 0;
                        double acTiempoOciosoCaja1 = 0;
                        int vecesCaja2Abierta = 0;
                        double acTiempoPermanencia = 0;

                        //promedios
                        double promedioTiempoAtencion;

                        while (minuto <= iteracion)
                        {
                            if (rbCasoA.Checked)
                            {

                                int hastaClientes = int.Parse(tbxCorteA.Text);
                                if (acClientesAtendidos == hastaClientes)
                                {
                                    promedioTiempoAtencion = acTiempoAtencion / hastaClientes;
                                    lblPromedioAtencion.Text = promedioTiempoAtencion.ToString();
                                }


                                //inicializacion
                                if (minuto == 0.0)
                                {
                                    caja1.estado = "Libre";
                                    caja1.clientes = new Queue<Cliente>();
                                    caja2.estado = "Cerrado";
                                    caja2.clientes = new Queue<Cliente>();
                                    inicializacion(media, vectorEstado);
                                    dgv_datos.Rows.Add(vectorEstado[0]);
                                    //vectorEstado[0] =[evento, minuto, rnd, entre_llegada, proximaLlegada, 0, 0, 0, 0, 0, 0, caja1.estado, caja1.getTamCola(), caja2.estado, caja2.getTamCola(), acTiempoAtencion, acClientesAtendidos, acTiempoOciosoCaja1, vecesCaja2Abierta];
                                    minuto = Convert.ToDouble(vectorEstado[0][4]);
                                }
                                else
                                {
                                    proximaLlegada = Convert.ToDouble(vectorEstado[0][4]);
                                    finAtencion1 = Convert.ToDouble(vectorEstado[0][11]);
                                    finAtencion2 = Convert.ToDouble(vectorEstado[0][12]);
                                    List<double> tiemposComparar = new List<double> { proximaLlegada, finAtencion1, finAtencion2 };
                                    mayorACero(tiemposComparar);
                                    


                                    double menorTiempo = tiemposComparar.Min();
                                    if (menorTiempo == proximaLlegada)
                                    {
                                        minuto = proximaLlegada;
                                        llegadaClienteA(media, vectorEstado, minuto, caja1, caja2, a, b, acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos,acTiempoOciosoCaja1,vecesCaja2Abierta);
                                        if (vectorEstado[1][11].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 += (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        if (vectorEstado[1][13].ToString() == "Cerrado" && vectorEstado[0][15].ToString() == "Ocupado")
                                        {
                                            vecesCaja2Abierta++;
                                        }
                                        vectorEstado[0][19] = acTiempoOciosoCaja1;
                                        vectorEstado[0][20] = vecesCaja2Abierta;
                                        if (minuto >= desde && minuto <= hasta)
                                        {
                                            dgv_datos.Rows.Add(vectorEstado[0]);
                                        }
                                    }
                                    else if (menorTiempo == finAtencion1)
                                    {
                                        minuto = finAtencion1;
                                        finAtencion(0,a, b, caja1, caja2, minuto, proximaLlegada,acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos, vectorEstado, acTiempoOciosoCaja1, vecesCaja2Abierta);
                                        if (vectorEstado[1][11].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 += (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        acClientesAtendidos++;
                                        vectorEstado[0][16] = acClientesAtendidos;
                                        vectorEstado[0][17] = acTiempoOciosoCaja1;
                                        if (minuto >= desde && minuto <= hasta)
                                        {
                                            dgv_datos.Rows.Add(vectorEstado[0]);
                                        }
                                        
                                    }
                                    else
                                    {
                                        minuto = finAtencion2;
                                        finAtencion(0,a, b, caja1, caja2, minuto, proximaLlegada, acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos, vectorEstado, acTiempoOciosoCaja1, vecesCaja2Abierta);
                                        if (vectorEstado[1][11].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 += (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        acClientesAtendidos++;
                                        vectorEstado[0][16] = acClientesAtendidos;
                                        vectorEstado[0][17] = acTiempoOciosoCaja1;
                                        if (minuto >= desde && minuto <= hasta)
                                        {
                                            dgv_datos.Rows.Add(vectorEstado[0]);
                                        }
                                    }

                                }
                            }
                            else if (rbCasoB.Checked)
                            {
                                List<Cliente> gondolas = new List<Cliente>();
                                double tiempoGondola;
                                double hastaMin = double.Parse(tbxCorteB.Text);
                                

                                //inicializacion
                                if (minuto == 0.0)
                                {
                                    caja1.estado = "Libre";
                                    caja1.clientes = new Queue<Cliente>();
                                    caja2.estado = "Cerrado";
                                    caja2.clientes = new Queue<Cliente>();
                                    inicializacion(media, vectorEstado);
                                    dgv_datos.Rows.Add(vectorEstado[0]);
                                    //vectorEstado[0] =[evento, minuto, rnd, entre_llegada, proximaLlegada, 0, 0, 0, 0, 0, 0, caja1.estado, caja1.getTamCola(), caja2.estado, caja2.getTamCola(), acTiempoAtencion, acClientesAtendidos, acTiempoOciosoCaja1, vecesCaja2Abierta];
                                    minuto = Convert.ToDouble(vectorEstado[0][4]);
                                }
                                else
                                {
                                    proximaLlegada = Convert.ToDouble(vectorEstado[0][4]);
                                    finAtencion1 = Convert.ToDouble(vectorEstado[0][11]);
                                    finAtencion2 = Convert.ToDouble(vectorEstado[0][12]);
                                    tiempoGondola = Convert.ToDouble(vectorEstado[0][6]);
                                    List<double> tiemposComparar = new List<double> { proximaLlegada, finAtencion1, finAtencion2, tiempoGondola };
                                    mayorACero(tiemposComparar);

                                    double menorTiempo = tiemposComparar.Min();

                                    double promedioPermanencia = 0;
                                    if (promedioPermanencia == 0 && menorTiempo > hastaMin)
                                    {
                                        promedioPermanencia = acTiempoPermanencia / acClientesAtendidos;
                                        lblPromedioPermanencia.Text = promedioPermanencia.ToString();
                                    }

                                    if (menorTiempo == proximaLlegada)
                                    {
                                        minuto = proximaLlegada;
                                        llegadaGodola(media, gondolas, vectorEstado, minuto, caja1, caja2, desdeGondola, hastaGondola, acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos, acTiempoOciosoCaja1, vecesCaja2Abierta);
                                        if (vectorEstado[1][13].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 += (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        if (vectorEstado[1][15].ToString() == "Cerrado" && vectorEstado[0][15].ToString() == "Ocupado")
                                        {
                                            vecesCaja2Abierta++;
                                        }
                                        
                                        vectorEstado[0][19] = acTiempoOciosoCaja1;
                                        vectorEstado[0][20] = vecesCaja2Abierta;
                                        if (minuto >= desde && minuto <= hasta)
                                        {
                                            dgv_datos.Rows.Add(vectorEstado[0]);
                                        }
                                    }
                                    else if (menorTiempo == tiempoGondola)
                                    {
                                        minuto = tiempoGondola;
                                        finGondola(gondolas, vectorEstado, proximaLlegada, minuto, caja1, caja2, a, b, acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos, acTiempoOciosoCaja1, vecesCaja2Abierta);
                                        
                                        if (vectorEstado[1][13].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 += (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        vectorEstado[0][17] = acTiempoOciosoCaja1;
                                        if (minuto >= desde && minuto <= hasta)
                                        {
                                            dgv_datos.Rows.Add(vectorEstado[0]);
                                        }

                                    }
                                    else if (menorTiempo == finAtencion1)
                                    {
                                        minuto = finAtencion1;
                                        finAtencion(tiempoGondola, a, b, caja1, caja2, minuto, proximaLlegada, acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos, vectorEstado, acTiempoOciosoCaja1, vecesCaja2Abierta);
                                        if (vectorEstado[1][13].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 += (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        
                                        acTiempoPermanencia += Convert.ToDouble(vectorEstado[1][21]);
                                        acClientesAtendidos++;
                                        vectorEstado[0][18] = acClientesAtendidos;
                                        vectorEstado[0][19] = acTiempoOciosoCaja1;
                                        if (minuto >= desde && minuto <= hasta)
                                        {
                                            dgv_datos.Rows.Add(vectorEstado[0]);
                                        }

                                    }
                                    else
                                    {
                                        minuto = finAtencion2;
                                        finAtencion(tiempoGondola, a, b, caja1, caja2, minuto, proximaLlegada, acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos, vectorEstado, acTiempoOciosoCaja1, vecesCaja2Abierta);
                                        if (vectorEstado[1][11].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 += (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        acTiempoPermanencia += Convert.ToDouble(vectorEstado[1][21]);
                                        acClientesAtendidos++;
                                        vectorEstado[0][18] = acClientesAtendidos;
                                        vectorEstado[0][19] = acTiempoOciosoCaja1;
                                        if (minuto >= desde && minuto <= hasta)
                                        {
                                            dgv_datos.Rows.Add(vectorEstado[0]);
                                        }
                                    }
                                }
                            }
                            
                        }
                        lblPromedioOcioso.Text = (acTiempoOciosoCaja1 / minuto).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Valores fuera de rango");
                        tbxDesde.Focus();
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
            tbxDesde.Clear();
            tbxHasta.Clear();
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

