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
            this.tbxMinutosSimularB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxHastaDemoraCliente = new System.Windows.Forms.TextBox();
            this.tbxDesdeDemoraCliente = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbxMedia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxHastaDemoraCaja = new System.Windows.Forms.TextBox();
            this.tbxDesdeDemoraCaja = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxHastaFilas = new System.Windows.Forms.TextBox();
            this.tbxDesdeFilas = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dgv_datos = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reloj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rndTiempoLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoEntreLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxLLegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rndTiempoFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiempoFinAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbCasoB);
            this.groupBox5.Controls.Add(this.rbCasoA);
            this.groupBox5.Location = new System.Drawing.Point(246, 31);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(95, 97);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Casos";
            // 
            // rbCasoB
            // 
            this.rbCasoB.AutoSize = true;
            this.rbCasoB.Location = new System.Drawing.Point(20, 63);
            this.rbCasoB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCasoB.Name = "rbCasoB";
            this.rbCasoB.Size = new System.Drawing.Size(59, 17);
            this.rbCasoB.TabIndex = 19;
            this.rbCasoB.TabStop = true;
            this.rbCasoB.Text = "Caso B";
            this.rbCasoB.UseVisualStyleBackColor = true;
            // 
            // rbCasoA
            // 
            this.rbCasoA.AutoSize = true;
            this.rbCasoA.Location = new System.Drawing.Point(20, 28);
            this.rbCasoA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbCasoA.Name = "rbCasoA";
            this.rbCasoA.Size = new System.Drawing.Size(59, 17);
            this.rbCasoA.TabIndex = 18;
            this.rbCasoA.TabStop = true;
            this.rbCasoA.Text = "Caso A";
            this.rbCasoA.UseVisualStyleBackColor = true;
            this.rbCasoA.CheckedChanged += new System.EventHandler(this.rbCasoA_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbxMinutosSimularB);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbxHastaDemoraCliente);
            this.groupBox3.Controls.Add(this.tbxDesdeDemoraCliente);
            this.groupBox3.Location = new System.Drawing.Point(586, 31);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(203, 97);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Demora Clientes recorriendo Gondolas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Minutos";
            // 
            // tbxMinutosSimularB
            // 
            this.tbxMinutosSimularB.Location = new System.Drawing.Point(86, 74);
            this.tbxMinutosSimularB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxMinutosSimularB.Name = "tbxMinutosSimularB";
            this.tbxMinutosSimularB.Size = new System.Drawing.Size(108, 20);
            this.tbxMinutosSimularB.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Demora hasta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Demora desde";
            // 
            // tbxHastaDemoraCliente
            // 
            this.tbxHastaDemoraCliente.Location = new System.Drawing.Point(86, 46);
            this.tbxHastaDemoraCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxHastaDemoraCliente.Name = "tbxHastaDemoraCliente";
            this.tbxHastaDemoraCliente.Size = new System.Drawing.Size(108, 20);
            this.tbxHastaDemoraCliente.TabIndex = 16;
            // 
            // tbxDesdeDemoraCliente
            // 
            this.tbxDesdeDemoraCliente.Location = new System.Drawing.Point(86, 19);
            this.tbxDesdeDemoraCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxDesdeDemoraCliente.Name = "tbxDesdeDemoraCliente";
            this.tbxDesdeDemoraCliente.Size = new System.Drawing.Size(108, 20);
            this.tbxDesdeDemoraCliente.TabIndex = 15;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbxMedia);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(800, 31);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(144, 46);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Llegada de clientes";
            // 
            // tbxMedia
            // 
            this.tbxMedia.Location = new System.Drawing.Point(58, 21);
            this.tbxMedia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxMedia.Name = "tbxMedia";
            this.tbxMedia.Size = new System.Drawing.Size(70, 20);
            this.tbxMedia.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Media";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbxHastaDemoraCaja);
            this.groupBox2.Controls.Add(this.tbxDesdeDemoraCaja);
            this.groupBox2.Location = new System.Drawing.Point(366, 31);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(203, 97);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Demora Caja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Demora hasta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Demora desde";
            // 
            // tbxHastaDemoraCaja
            // 
            this.tbxHastaDemoraCaja.Location = new System.Drawing.Point(86, 63);
            this.tbxHastaDemoraCaja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxHastaDemoraCaja.Name = "tbxHastaDemoraCaja";
            this.tbxHastaDemoraCaja.Size = new System.Drawing.Size(108, 20);
            this.tbxHastaDemoraCaja.TabIndex = 16;
            // 
            // tbxDesdeDemoraCaja
            // 
            this.tbxDesdeDemoraCaja.Location = new System.Drawing.Point(86, 28);
            this.tbxDesdeDemoraCaja.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxDesdeDemoraCaja.Name = "tbxDesdeDemoraCaja";
            this.tbxDesdeDemoraCaja.Size = new System.Drawing.Size(108, 20);
            this.tbxDesdeDemoraCaja.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxHastaFilas);
            this.groupBox1.Controls.Add(this.tbxDesdeFilas);
            this.groupBox1.Location = new System.Drawing.Point(20, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(203, 97);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filas a mostrar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Fila hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Fila desde";
            // 
            // tbxHastaFilas
            // 
            this.tbxHastaFilas.Location = new System.Drawing.Point(86, 63);
            this.tbxHastaFilas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxHastaFilas.Name = "tbxHastaFilas";
            this.tbxHastaFilas.Size = new System.Drawing.Size(108, 20);
            this.tbxHastaFilas.TabIndex = 16;
            // 
            // tbxDesdeFilas
            // 
            this.tbxDesdeFilas.Location = new System.Drawing.Point(86, 28);
            this.tbxDesdeFilas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxDesdeFilas.Name = "tbxDesdeFilas";
            this.tbxDesdeFilas.Size = new System.Drawing.Size(108, 20);
            this.tbxDesdeFilas.TabIndex = 15;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(963, 102);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(71, 25);
            this.btnGenerar.TabIndex = 22;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
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
            this.rndTiempoFin,
            this.tiempoAtencion,
            this.tiempoFinAtencion,
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
            this.CantCaja2Usada});
            this.dgv_datos.Location = new System.Drawing.Point(20, 129);
            this.dgv_datos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_datos.Name = "dgv_datos";
            this.dgv_datos.RowHeadersWidth = 51;
            this.dgv_datos.RowTemplate.Height = 24;
            this.dgv_datos.Size = new System.Drawing.Size(1014, 293);
            this.dgv_datos.TabIndex = 21;
            this.dgv_datos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_datos_CellContentClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(963, 66);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(71, 32);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
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
            this.proxLLegada.Name = "proxLLegada";
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
            // tiempoFinAtencion
            // 
            this.tiempoFinAtencion.HeaderText = "Tiempo fin atencion";
            this.tiempoFinAtencion.MinimumWidth = 6;
            this.tiempoFinAtencion.Name = "tiempoFinAtencion";
            this.tiempoFinAtencion.Width = 125;
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
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 433);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgv_datos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxHastaFilas;
        private System.Windows.Forms.TextBox tbxDesdeFilas;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgv_datos;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxMinutosSimularB;
        private System.Windows.Forms.DataGridViewTextBoxColumn evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn reloj;
        private System.Windows.Forms.DataGridViewTextBoxColumn rndTiempoLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoEntreLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn proxLLegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn rndTiempoFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoAtencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiempoFinAtencion;
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
    }
}

