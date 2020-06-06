namespace TP5_SIM_2._02.Formularios
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbCasoB = new System.Windows.Forms.RadioButton();
            this.rbCasoA = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCorteB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxHastaDemoraCliente = new System.Windows.Forms.TextBox();
            this.tbxDesdeDemoraCliente = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxMedia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxHastaDemoraCaja = new System.Windows.Forms.TextBox();
            this.tbxDesdeDemoraCaja = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgv_datos = new System.Windows.Forms.DataGridView();
            this.evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reloj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rndTiempoLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoEntreLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxLLegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rndGondola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoGondola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rndTiempoFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rndMetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finAt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finAt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cola1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cola2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acTiempoFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acClientesFinalizados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoOciosoCaja1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantCaja2Usada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoPermanencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxCorteA = new System.Windows.Forms.TextBox();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.tbxDesde = new System.Windows.Forms.TextBox();
            this.tbxHasta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPromedioAtencion = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPromedioOcioso = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPromedioPermanencia = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbCasoB);
            this.groupBox5.Controls.Add(this.rbCasoA);
            this.groupBox5.Location = new System.Drawing.Point(369, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(142, 149);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Casos";
            // 
            // rbCasoB
            // 
            this.rbCasoB.AutoSize = true;
            this.rbCasoB.Location = new System.Drawing.Point(30, 97);
            this.rbCasoB.Name = "rbCasoB";
            this.rbCasoB.Size = new System.Drawing.Size(86, 24);
            this.rbCasoB.TabIndex = 19;
            this.rbCasoB.TabStop = true;
            this.rbCasoB.Text = "Caso B";
            this.rbCasoB.UseVisualStyleBackColor = true;
            this.rbCasoB.CheckedChanged += new System.EventHandler(this.rbCasoB_CheckedChanged_1);
            // 
            // rbCasoA
            // 
            this.rbCasoA.AutoSize = true;
            this.rbCasoA.Location = new System.Drawing.Point(30, 43);
            this.rbCasoA.Name = "rbCasoA";
            this.rbCasoA.Size = new System.Drawing.Size(86, 24);
            this.rbCasoA.TabIndex = 18;
            this.rbCasoA.TabStop = true;
            this.rbCasoA.Text = "Caso A";
            this.rbCasoA.UseVisualStyleBackColor = true;
            this.rbCasoA.CheckedChanged += new System.EventHandler(this.rbCasoA_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbxCorteB);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbxHastaDemoraCliente);
            this.groupBox3.Controls.Add(this.tbxDesdeDemoraCliente);
            this.groupBox3.Location = new System.Drawing.Point(879, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 149);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Demora Clientes recorriendo Gondolas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Cortar al minuto";
            // 
            // tbxCorteB
            // 
            this.tbxCorteB.Location = new System.Drawing.Point(129, 114);
            this.tbxCorteB.Name = "tbxCorteB";
            this.tbxCorteB.Size = new System.Drawing.Size(160, 26);
            this.tbxCorteB.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Demora hasta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Demora desde";
            // 
            // tbxHastaDemoraCliente
            // 
            this.tbxHastaDemoraCliente.Location = new System.Drawing.Point(129, 71);
            this.tbxHastaDemoraCliente.Name = "tbxHastaDemoraCliente";
            this.tbxHastaDemoraCliente.Size = new System.Drawing.Size(160, 26);
            this.tbxHastaDemoraCliente.TabIndex = 16;
            // 
            // tbxDesdeDemoraCliente
            // 
            this.tbxDesdeDemoraCliente.Location = new System.Drawing.Point(129, 29);
            this.tbxDesdeDemoraCliente.Name = "tbxDesdeDemoraCliente";
            this.tbxDesdeDemoraCliente.Size = new System.Drawing.Size(160, 26);
            this.tbxDesdeDemoraCliente.TabIndex = 15;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbxMedia);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(1200, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 71);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Llegada de clientes";
            // 
            // tbxMedia
            // 
            this.tbxMedia.Location = new System.Drawing.Point(87, 32);
            this.tbxMedia.Name = "tbxMedia";
            this.tbxMedia.Size = new System.Drawing.Size(103, 26);
            this.tbxMedia.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Media";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbxHastaDemoraCaja);
            this.groupBox2.Controls.Add(this.tbxDesdeDemoraCaja);
            this.groupBox2.Location = new System.Drawing.Point(549, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 149);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Demora en Caja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Y:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "minutos";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(164, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "minutos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Entre:";
            // 
            // tbxHastaDemoraCaja
            // 
            this.tbxHastaDemoraCaja.Location = new System.Drawing.Point(68, 92);
            this.tbxHastaDemoraCaja.Name = "tbxHastaDemoraCaja";
            this.tbxHastaDemoraCaja.Size = new System.Drawing.Size(88, 26);
            this.tbxHastaDemoraCaja.TabIndex = 16;
            // 
            // tbxDesdeDemoraCaja
            // 
            this.tbxDesdeDemoraCaja.Location = new System.Drawing.Point(68, 40);
            this.tbxDesdeDemoraCaja.Name = "tbxDesdeDemoraCaja";
            this.tbxDesdeDemoraCaja.Size = new System.Drawing.Size(88, 26);
            this.tbxDesdeDemoraCaja.TabIndex = 15;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(1444, 157);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(106, 38);
            this.btnGenerar.TabIndex = 22;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dgv_datos
            // 
            this.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.evento,
            this.reloj,
            this.rndTiempoLlegada,
            this.tiempoEntreLlegada,
            this.proxLLegada,
            this.rndGondola,
            this.tiempoGondola,
            this.rndTiempoFin,
            this.tiempoAtencion,
            this.rndMetodoPago,
            this.metodoPago,
            this.finAt1,
            this.finAt2,
            this.estado1,
            this.cola1,
            this.estado2,
            this.cola2,
            this.acTiempoFin,
            this.acClientesFinalizados,
            this.tiempoOciosoCaja1,
            this.CantCaja2Usada,
            this.tiempoPermanencia});
            this.dgv_datos.Location = new System.Drawing.Point(4, 222);
            this.dgv_datos.Name = "dgv_datos";
            this.dgv_datos.RowHeadersWidth = 51;
            this.dgv_datos.RowTemplate.Height = 24;
            this.dgv_datos.Size = new System.Drawing.Size(1521, 428);
            this.dgv_datos.TabIndex = 21;
            // 
            // evento
            // 
            this.evento.HeaderText = "Evento";
            this.evento.MinimumWidth = 6;
            this.evento.Name = "evento";
            this.evento.Width = 125;
            // 
            // reloj
            // 
            this.reloj.HeaderText = "Reloj (min)";
            this.reloj.MinimumWidth = 6;
            this.reloj.Name = "reloj";
            this.reloj.Width = 125;
            // 
            // rndTiempoLlegada
            // 
            this.rndTiempoLlegada.HeaderText = "RND";
            this.rndTiempoLlegada.MinimumWidth = 6;
            this.rndTiempoLlegada.Name = "rndTiempoLlegada";
            this.rndTiempoLlegada.Width = 125;
            // 
            // tiempoEntreLlegada
            // 
            this.tiempoEntreLlegada.HeaderText = "Tiempo entre llegadas";
            this.tiempoEntreLlegada.MinimumWidth = 6;
            this.tiempoEntreLlegada.Name = "tiempoEntreLlegada";
            this.tiempoEntreLlegada.Width = 125;
            // 
            // proxLLegada
            // 
            this.proxLLegada.HeaderText = "Próxima llegada";
            this.proxLLegada.MinimumWidth = 8;
            this.proxLLegada.Name = "proxLLegada";
            this.proxLLegada.Width = 150;
            // 
            // rndGondola
            // 
            this.rndGondola.HeaderText = "RND";
            this.rndGondola.MinimumWidth = 8;
            this.rndGondola.Name = "rndGondola";
            this.rndGondola.Width = 150;
            // 
            // tiempoGondola
            // 
            this.tiempoGondola.HeaderText = "Tiempo Góndola";
            this.tiempoGondola.MinimumWidth = 8;
            this.tiempoGondola.Name = "tiempoGondola";
            this.tiempoGondola.Width = 150;
            // 
            // rndTiempoFin
            // 
            this.rndTiempoFin.HeaderText = "RND";
            this.rndTiempoFin.MinimumWidth = 6;
            this.rndTiempoFin.Name = "rndTiempoFin";
            this.rndTiempoFin.Width = 125;
            // 
            // tiempoAtencion
            // 
            this.tiempoAtencion.HeaderText = "Tiempo Atencion";
            this.tiempoAtencion.MinimumWidth = 6;
            this.tiempoAtencion.Name = "tiempoAtencion";
            this.tiempoAtencion.Width = 125;
            // 
            // rndMetodoPago
            // 
            this.rndMetodoPago.HeaderText = "RND";
            this.rndMetodoPago.MinimumWidth = 6;
            this.rndMetodoPago.Name = "rndMetodoPago";
            this.rndMetodoPago.Width = 125;
            // 
            // metodoPago
            // 
            this.metodoPago.HeaderText = "Metodo Pago";
            this.metodoPago.MinimumWidth = 6;
            this.metodoPago.Name = "metodoPago";
            this.metodoPago.Width = 125;
            // 
            // finAt1
            // 
            this.finAt1.HeaderText = "Fin At. 1";
            this.finAt1.MinimumWidth = 6;
            this.finAt1.Name = "finAt1";
            this.finAt1.Width = 125;
            // 
            // finAt2
            // 
            this.finAt2.HeaderText = "Fin At. 2";
            this.finAt2.MinimumWidth = 6;
            this.finAt2.Name = "finAt2";
            this.finAt2.Width = 125;
            // 
            // estado1
            // 
            this.estado1.HeaderText = "Estado 1";
            this.estado1.MinimumWidth = 6;
            this.estado1.Name = "estado1";
            this.estado1.Width = 125;
            // 
            // cola1
            // 
            this.cola1.HeaderText = "Cola 1";
            this.cola1.MinimumWidth = 6;
            this.cola1.Name = "cola1";
            this.cola1.Width = 125;
            // 
            // estado2
            // 
            this.estado2.HeaderText = "Estado 2";
            this.estado2.MinimumWidth = 6;
            this.estado2.Name = "estado2";
            this.estado2.Width = 125;
            // 
            // cola2
            // 
            this.cola2.HeaderText = "Cola 2";
            this.cola2.MinimumWidth = 6;
            this.cola2.Name = "cola2";
            this.cola2.Width = 125;
            // 
            // acTiempoFin
            // 
            this.acTiempoFin.HeaderText = "AC Tiempo Fin At";
            this.acTiempoFin.MinimumWidth = 6;
            this.acTiempoFin.Name = "acTiempoFin";
            this.acTiempoFin.Width = 125;
            // 
            // acClientesFinalizados
            // 
            this.acClientesFinalizados.HeaderText = "AC Clientes Finalizados";
            this.acClientesFinalizados.MinimumWidth = 6;
            this.acClientesFinalizados.Name = "acClientesFinalizados";
            this.acClientesFinalizados.Width = 125;
            // 
            // tiempoOciosoCaja1
            // 
            this.tiempoOciosoCaja1.HeaderText = "Tiempo ocioso de la caja 1";
            this.tiempoOciosoCaja1.MinimumWidth = 6;
            this.tiempoOciosoCaja1.Name = "tiempoOciosoCaja1";
            this.tiempoOciosoCaja1.Width = 125;
            // 
            // CantCaja2Usada
            // 
            this.CantCaja2Usada.HeaderText = "Cant veces caja 2 abierta";
            this.CantCaja2Usada.MinimumWidth = 6;
            this.CantCaja2Usada.Name = "CantCaja2Usada";
            this.CantCaja2Usada.Width = 125;
            // 
            // tiempoPermanencia
            // 
            this.tiempoPermanencia.HeaderText = "AC Tiempo permanencia clientes";
            this.tiempoPermanencia.MinimumWidth = 8;
            this.tiempoPermanencia.Name = "tiempoPermanencia";
            this.tiempoPermanencia.Width = 150;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1444, 102);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(106, 49);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.tbxCorteA);
            this.groupBox6.Location = new System.Drawing.Point(1200, 125);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(222, 86);
            this.groupBox6.TabIndex = 32;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Promedio tiempo atención";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Nro de clientes:";
            // 
            // tbxCorteA
            // 
            this.tbxCorteA.Location = new System.Drawing.Point(136, 43);
            this.tbxCorteA.Name = "tbxCorteA";
            this.tbxCorteA.Size = new System.Drawing.Size(78, 26);
            this.tbxCorteA.TabIndex = 15;
            // 
            // txtIteraciones
            // 
            this.txtIteraciones.Location = new System.Drawing.Point(138, 48);
            this.txtIteraciones.Name = "txtIteraciones";
            this.txtIteraciones.Size = new System.Drawing.Size(163, 26);
            this.txtIteraciones.TabIndex = 15;
            // 
            // tbxDesde
            // 
            this.tbxDesde.Location = new System.Drawing.Point(141, 94);
            this.tbxDesde.Name = "tbxDesde";
            this.tbxDesde.Size = new System.Drawing.Size(160, 26);
            this.tbxDesde.TabIndex = 15;
            // 
            // tbxHasta
            // 
            this.tbxHasta.Location = new System.Drawing.Point(141, 143);
            this.tbxHasta.Name = "tbxHasta";
            this.tbxHasta.Size = new System.Drawing.Size(160, 26);
            this.tbxHasta.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Minutos a simular:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Desde:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Hasta:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 658);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(380, 20);
            this.label13.TabIndex = 15;
            this.label13.Text = "Promedio tiempo atención para los primeros clientes:";
            // 
            // lblPromedioAtencion
            // 
            this.lblPromedioAtencion.AutoSize = true;
            this.lblPromedioAtencion.Location = new System.Drawing.Point(420, 658);
            this.lblPromedioAtencion.Name = "lblPromedioAtencion";
            this.lblPromedioAtencion.Size = new System.Drawing.Size(0, 20);
            this.lblPromedioAtencion.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(727, 658);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(231, 20);
            this.label15.TabIndex = 15;
            this.label15.Text = "Promedio tiempo ocioso Caja 1:";
            // 
            // lblPromedioOcioso
            // 
            this.lblPromedioOcioso.AutoSize = true;
            this.lblPromedioOcioso.Location = new System.Drawing.Point(964, 658);
            this.lblPromedioOcioso.Name = "lblPromedioOcioso";
            this.lblPromedioOcioso.Size = new System.Drawing.Size(0, 20);
            this.lblPromedioOcioso.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 708);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(286, 20);
            this.label14.TabIndex = 15;
            this.label14.Text = "Promedio tiempo permanencia clientes:";
            // 
            // lblPromedioPermanencia
            // 
            this.lblPromedioPermanencia.AutoSize = true;
            this.lblPromedioPermanencia.Location = new System.Drawing.Point(324, 708);
            this.lblPromedioPermanencia.Name = "lblPromedioPermanencia";
            this.lblPromedioPermanencia.Size = new System.Drawing.Size(0, 20);
            this.lblPromedioPermanencia.TabIndex = 15;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 766);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPromedioAtencion);
            this.Controls.Add(this.lblPromedioOcioso);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblPromedioPermanencia);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.tbxHasta);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tbxDesde);
            this.Controls.Add(this.txtIteraciones);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgv_datos);
            this.Name = "Menu";
            this.Text = "Form1";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbCasoB;
        private System.Windows.Forms.RadioButton rbCasoA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxHastaDemoraCliente;
        private System.Windows.Forms.TextBox tbxDesdeDemoraCliente;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbxMedia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxHastaDemoraCaja;
        private System.Windows.Forms.TextBox tbxDesdeDemoraCaja;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgv_datos;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxCorteB;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxCorteA;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.TextBox tbxDesde;
        private System.Windows.Forms.TextBox tbxHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblPromedioAtencion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblPromedioOcioso;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblPromedioPermanencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn reloj;
        private System.Windows.Forms.DataGridViewTextBoxColumn rndTiempoLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoEntreLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn proxLLegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn rndGondola;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoGondola;
        private System.Windows.Forms.DataGridViewTextBoxColumn rndTiempoFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoAtencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn rndMetodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn metodoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn finAt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn finAt2;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cola1;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cola2;
        private System.Windows.Forms.DataGridViewTextBoxColumn acTiempoFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn acClientesFinalizados;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoOciosoCaja1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantCaja2Usada;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoPermanencia;
    }
}

