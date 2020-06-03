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
            Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();

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

            double[] acum_tiempo_at;
            acum_tiempo_at = new double[100];

            int acum_clientes_at_finalizada = 0;

            double[] tiempo_ocioso_caja_1;
            tiempo_ocioso_caja_1 = new double[100];

            int[] cant_caja_2_usada;
            cant_caja_2_usada = new int[100];

            // variables que se necesitan para la fila Inicializacion 
            double rnd_lleg_cliente = random.NextDouble();
            double rnd_fin_at = 0;
            double rnd_pago = 0;
            double tiempo_entre_llegadas = -media * Math.Log(1 - rnd_lleg_cliente);
            double tiempo_fin_atencion = 0;
            double prox_llegada = tiempo_entre_llegadas;

            // i = filas
            // caso A
            if (rbCasoA.Checked)
            {
              

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

