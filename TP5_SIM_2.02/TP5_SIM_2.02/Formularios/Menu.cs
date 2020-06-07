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

/*
COSAS QUE FALTAN:

PROGRAMACION:
    1- ARREGLAR LOS ACUMULADORES Y CONTADORES -- DELFI Y YO. 
    2- MOSTRAR ESTADOS DE LOS CLIENTES -- JOSÉ
    3- COLA 2 -- DELFI Y IO 

WORD/PDF:
    1- ESPECIFICACIÓN DE REQUERIMIENTOS (a) -- JOSÉ
    2- DIAGRAMA DE FLUJO (c) -- CAMI Y DAI
    3- MODELADO (b) -- DAI


OPCIONAL: (SI PINTA VERLO)
    1- HACER UNA MÉTRICA MÁS PIOLA
 */

//Ver el tiempo de atencion
//
namespace TP5_SIM_2._02.Formularios
{
    public partial class Menu : Form
    {
        private static readonly Random random = new Random();
        private object DataControlRowType;
        

        public Menu()
        {

            InitializeComponent();

            tbxDesdeDemoraCliente.Text = 0.ToString();
            tbxHastaDemoraCliente.Text = 0.ToString();
            tbxCorteB.Text = 0.ToString();
            tbxDesdeDemoraCliente.Enabled = false;
            tbxHastaDemoraCliente.Enabled = false;
            tbxCorteB.Enabled = false;

        }
        

        
        public void mayorACero(List<double> valores)
        {
            for (int i = 0; i < valores.Count; i++)
            {
                if (valores[i] == 0.0)
                {
                    valores[i] = 9999.99;
                }
            }
        }

        // En este foreach lo que se hace es recorrer el vector con clientes que están en las góndolas. 
        // Se fija si el fin de gondola coincide con el tiempo de reloj y si es true, lo quita del vector gondolas.
        public void quitarClientesGondola(List<Cliente> gondolas, double reloj, Cliente cli)
        {
            foreach (Cliente c in gondolas)
            {
                if (c.fin_gondola == reloj)
                {
                    cli = c;
                    gondolas.Remove(c);
                }
            }
        }

        public void llegadaCliente(Caja caja1, Caja caja2, double rndDemora, double a, double b, double rndMetodo, double demoraAtencion, string metodo, Cliente cli, double reloj)
        {
            if (caja1.estado != "Ocupado")
            {
                rndDemora = random.NextDouble();
                demoraAtencion = a + (rndDemora * (b - a));
                rndMetodo = random.NextDouble();

                metodo = "Efectivo";

                if (rndMetodo < 0.2)
                {
                    metodo = "Tarjeta";
                    demoraAtencion = demoraAtencion + 2;
                }
            
                

                /* Se modifica el estado del cliente a SA y se le pone el número de la caja1
                A la Caja1 se le cambia el estado a Ocupado 
                Se modifica el fin de atención sumandole a la demora de atención el reloj. 
                Esta demora de atención es el tiempo de atención, así le deciamos antes. 
                Por último agregamos a la cola de la caja 1, el cliente cli.*/

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

                    if (caja1.estado != "Ocupado")
                    {
                        rndDemora = random.NextDouble();
                        demoraAtencion = a + (rndDemora * (b - a));
                        rndMetodo = random.NextDouble();

                        metodo = "Efectivo";

                        if (rndMetodo < 0.2)
                        {
                            metodo = "Tarjeta";
                            demoraAtencion = demoraAtencion + 2;

                        }
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
        }

        //Obtiene el metodo de pago por cliente
        public double  metodoDePago(double rndDemora, double a, double b, double rndMetodo, double demoraAtencion)
        {
            rndDemora = random.NextDouble();
            demoraAtencion = a + (rndDemora * (b - a));
            rndMetodo = random.NextDouble();
            string metodo = "Efectivo";

            if (rndMetodo < 0.2)
            {
                metodo = "Tarjeta";
                demoraAtencion = demoraAtencion + 2;
                return demoraAtencion;
            }
            return demoraAtencion;
        }

        /*Compara si hay clientes en las gondolas, en el caso que si, busca el menor con la funcion menorGondolas y le setea
        el fin de gondola.
         */
        public double tiempoEnGondolas(List <Cliente> gondolas)
        {
            double menorGondola = 0;

            if (gondolas.Count > 0)
            {
                menorGondola = menorGondolas(gondolas).fin_gondola;
            }
            return menorGondola;
        }

        public void finGondola(List<Cliente> gondolas ,object[][] vector, double proximaLlegada,double reloj, Caja caja1, Caja caja2, double a, double b, double acTiempoPerm, double acTiempoAtencion, int cantClientesAtendedios, double acTiempoOcioso, int vecesCaja2Abrio)
        {
            // Se inicilializan las variables para la demora de la atención.            
            string evento = "Fin Góndola";
            double rndDemora = 0;
            double demoraAtencion = 0;
            double rndMetodo = 0;
            string metodo = "";
            Cliente cli = new Cliente();

            // Llamo esta función para quitar el cliente que esté bollando en las gondolas y quiere ir a la caja ya.
            quitarClientesGondola(gondolas, reloj, cli);

            

            //Se fija cuando llega el próximo cliente.
            llegadaCliente(caja1, caja2, rndDemora, a, b, rndMetodo, demoraAtencion, metodo, cli, reloj);
            
            //Obtiene el menor tiempo en gondola y se lo setea al prox cliente
            double menorGondola = tiempoEnGondolas(gondolas);

            //Crear el vector que va a crear la grilla. 
            vector[1] = vector[0];
            vector[0] = new object[] { evento, reloj, 0, 0, proximaLlegada, 0, menorGondola, rndDemora, demoraAtencion, rndMetodo, metodo, caja1.finAtencion, caja2.finAtencion, caja1.estado, caja1.getTamCola(), caja2.estado, caja2.getTamCola(), acTiempoAtencion, cantClientesAtendedios, acTiempoOcioso, vecesCaja2Abrio, acTiempoPerm };
        }


        // Esta función registra la llegada al cliente al local, mandandolo a la gondola.
        // Se le agrega 
        public void llegadaGodola(double media, List<Cliente> gondolas, object[][] vector, double reloj, Caja caja1, Caja caja2, double a, double b, double acTiempoPerm, double acTiempoAtencion, int cantClientesAtendedios, double acTiempoOcioso, int vecesCaja2Abrio)
        {
            /* Definicion de variables y cálculos*/
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

            /*Se obtiene el cliente con el tiempo de gondola más chico y se lo asigna a la variable menorGondola*/
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

                if (caja1.estado != "Ocupado")
                {
                    rndDemora = random.NextDouble();
                    demoraAtencion = a + (rndDemora * (b - a));
                    rndMetodo = random.NextDouble();

                    metodo = "Efectivo";

                    if (rndMetodo < 0.2)
                    {
                        metodo = "Tarjeta";
                        demoraAtencion = demoraAtencion + 2;

                    }
                }

                cli.estado = "SA";
                cli.numCaja = 1;
                caja1.estado = "Ocupado";
                caja1.finAtencion = demoraAtencion + reloj;
                caja1.clientes.Enqueue(cli);

                // para que en la columna de la tabla se muestren los valores (Antes: aparecian los valores 0)
                vector[0][7] = rndDemora;
                vector[0][8] = demoraAtencion;
                vector[0][9] = rndMetodo;
                vector[0][10] = metodo;

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


                    if (caja1.estado != "Ocupado")
                    {
                        rndDemora = random.NextDouble();
                        demoraAtencion = a + (rndDemora * (b - a));
                        rndMetodo = random.NextDouble();

                        metodo = "Efectivo";

                        if (rndMetodo < 0.2)
                        {
                            metodo = "Tarjeta";
                            demoraAtencion = demoraAtencion + 2;

                        }
                    }

                    caja2.finAtencion = demoraAtencion + reloj;
                    cli.estado = "SA";
                    cli.numCaja = 2;
                    caja2.estado = "Ocupado";
                    // para que en la columna de la tabla se muestre el estado OCUPADO (Antes: quedaba en "Cerrado")
                    vector[0][15] = caja2.estado;
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
                
                acTiempoAtencion = acTiempoAtencion + caja1.finAtencion;
                Cliente cliAtendido = caja1.clientes.First();
                double tiempoPermanencia = reloj - cliAtendido.hora_llegada;
                acTiempoPerm = acTiempoPerm + tiempoPermanencia;
                caja1.clientes.Dequeue();
                

                if (caja1.clientes.Count > 0)
                {
                    if (caja1.estado != "Ocupado")
                    {
                        rndDemora = random.NextDouble();
                        demoraAtencion = a + (rndDemora * (b - a));
                        rndMetodo = random.NextDouble();

                        metodo = "Efectivo";

                        if (rndMetodo < 0.2)
                        {
                            metodo = "Tarjeta";
                            demoraAtencion = demoraAtencion + 2;

                        }
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
                acTiempoAtencion = acTiempoAtencion + caja2.finAtencion;
                Cliente cliAtendido = caja2.clientes.Peek();
                double tiempoPermanencia = reloj - cliAtendido.hora_llegada;
                acTiempoPerm = acTiempoPerm + tiempoPermanencia;
                caja2.clientes.Dequeue();

                if (caja2.clientes.Count > 0)
                {
                    if (caja1.estado != "Ocupado")
                    {
                        rndDemora = random.NextDouble();
                        demoraAtencion = a + (rndDemora * (b - a));
                        rndMetodo = random.NextDouble();

                        metodo = "Efectivo";

                        if (rndMetodo < 0.2)
                        {
                            metodo = "Tarjeta";
                            demoraAtencion = demoraAtencion + 2;

                        }
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

            // Resolver el fin de gondola como temporal.

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

        // Cambia la cola de clientes en una pila
        public Stack<Cliente> colaAPila(Queue<Cliente> clientes) 
        {
            
            Stack<Cliente> pilaClientes = new Stack<Cliente>();

            foreach (Cliente cli in clientes)
            {
                pilaClientes.Push(cli);
            }
            return pilaClientes;
        }

        // Cambia la pila de clientes en una cola
        public Queue<Cliente> pilaACola(Stack<Cliente> pilaClientes) {
            
            Queue<Cliente> colaClientes = new Queue<Cliente>();

            foreach (Cliente cli in pilaClientes)
            {
                colaClientes.Enqueue(cli);
            }
            return colaClientes;
        }

        
        /*Se fija cual es el cliente con menor tiempo en las gondolas.
        Le pasa una lista de los clientes que están en gondola, se crea una lista con tiempos
        donde en cada iteracion del for le agrega los tiempos de fin de tiempo gondola de cada cliente
        Con la función MIN busca en la lista de tiempo el menor y la asigna a una variable "menor"
        Por último busca en el listado de clientes el cliente que coincida con ese tiempo.
        */
        
        public Cliente menorGondolas(List<Cliente> cli_gondolas)
        {
            double menor = 0;
            
            List<double> tiempos = new List<double>();
            foreach(Cliente cli in cli_gondolas)
            {
                tiempos.Add(cli.fin_gondola);
            }
            menor = tiempos.Min();

            //Habría un problema si hay más de un cliente con el mismo tiempo de fin de gondola. 

            return cli_gondolas.Find(c => c.fin_gondola == menor);
                  
        }


        // Objetos temporales finGondola, objetos temporales de clientes(Ailin, Delfi). Métricas (Acumuladores que acumulan para el orto)
        private void btnGenerar_Click(object sender, EventArgs e)
        {

            Caja caja1 = new Caja();
            
            Caja caja2 = new Caja();

            string iter = txtIteraciones.Text;
            string des = tbxDesde.Text;
            

            if (iter == "" || des == "")
            {
                MessageBox.Show("Ingrese todo los valores");
                txtIteraciones.Focus();
            }
            else
            {
                double iteracion = double.Parse(iter);
                double desde = double.Parse(des);
                double hasta = desde + 100;
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
                                // para el caso A oculta columndas del caso B  
                                dgv_datos.Columns["rndGondola"].Visible = false;
                                dgv_datos.Columns["tiempoGondola"].Visible = false;

                                double hastaClientes = double.Parse(tbxCorteA.Text);
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
                                            acTiempoOciosoCaja1 = acTiempoOciosoCaja1 + (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        if (vectorEstado[1][13].ToString() == "Cerrado" && vectorEstado[0][15].ToString() == "Ocupado")
                                        {
                                            vecesCaja2Abierta = vecesCaja2Abierta +1;
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
                                        acTiempoAtencion = acTiempoAtencion + minuto;
                                        finAtencion(0,a, b, caja1, caja2, minuto, proximaLlegada,acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos, vectorEstado, acTiempoOciosoCaja1, vecesCaja2Abierta);
                                        if (vectorEstado[1][11].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 = acTiempoOciosoCaja1 + (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        acClientesAtendidos = acClientesAtendidos+1;
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
                                        acTiempoAtencion = acTiempoAtencion + minuto;
                                        finAtencion(0,a, b, caja1, caja2, minuto, proximaLlegada, acTiempoPermanencia, acTiempoAtencion, acClientesAtendidos, vectorEstado, acTiempoOciosoCaja1, vecesCaja2Abierta);
                                        if (vectorEstado[1][11].ToString() == "Libre")
                                        {
                                            acTiempoOciosoCaja1 = acTiempoOciosoCaja1 + (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        acClientesAtendidos = acClientesAtendidos +1;
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
                                            acTiempoOciosoCaja1 = acTiempoOciosoCaja1+(minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        if (vectorEstado[1][15].ToString() == "Cerrado" && vectorEstado[0][15].ToString() == "Ocupado")
                                        {
                                            vecesCaja2Abierta = vecesCaja2Abierta + 1;
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
                                            acTiempoOciosoCaja1 = acTiempoOciosoCaja1 + (minuto - Convert.ToDouble(vectorEstado[1][1]));
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
                                            acTiempoOciosoCaja1 = acTiempoOciosoCaja1 + (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        
                                        acTiempoPermanencia = acTiempoPermanencia+ Convert.ToDouble(vectorEstado[1][21]);
                                        acClientesAtendidos = acClientesAtendidos + 1;
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
                                            acTiempoOciosoCaja1 = acTiempoOciosoCaja1 + (minuto - Convert.ToDouble(vectorEstado[1][1]));
                                        }
                                        acTiempoPermanencia = acTiempoPermanencia +  Convert.ToDouble(vectorEstado[1][21]);
                                        acClientesAtendidos = acClientesAtendidos +1 ;
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

            tbxDesdeDemoraCliente.Text = 0.ToString();
            tbxHastaDemoraCliente.Text = 0.ToString();
            tbxCorteB.Text = 0.ToString();
            tbxDesdeDemoraCliente.Enabled = false;
            tbxHastaDemoraCliente.Enabled = false;
            tbxCorteB.Enabled = false;

        }
        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            rbCasoA.Checked = false;
            rbCasoB.Checked = false;
            tbxDesde.Clear();
            tbxDesdeDemoraCliente.Enabled = true;
            tbxDesdeDemoraCaja.Clear();
            tbxHastaDemoraCliente.Enabled = true;
            tbxHastaDemoraCaja.Clear();
            tbxDesdeDemoraCliente.Clear();
            tbxHastaDemoraCliente.Clear();
            tbxMedia.Clear();
            tbxCorteB.Clear();
            tbxCorteB.Enabled = true;
            tbxCorteA.Clear();


            dgv_datos.Rows.Clear();

        }

        private void rbCasoB_CheckedChanged_1(object sender, EventArgs e)
        {
            
            tbxDesdeDemoraCliente.Enabled = true;
            tbxHastaDemoraCliente.Enabled = true;
            tbxCorteB.Enabled = true;
            tbxCorteA.Text = 0.ToString();
            tbxCorteA.Enabled = false;
            
        }
        
    }
}

