namespace Capa_Interfaz
{
    partial class FrmRegistroPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNumeroPedido = new TextBox();
            dtpFechaPedido = new DateTimePicker();
            llbFechaPedido = new Label();
            cboCliente = new ComboBox();
            cboRepartidor = new ComboBox();
            txtDireccion = new TextBox();
            cboArticulo = new ComboBox();
            txtCantidad = new TextBox();
            btnAgregarArticulo = new Button();
            dgvDetalle = new DataGridView();
            label2 = new Label();
            btnRegistrarPedido = new Button();
            gbEncabezado = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            gbDetalle = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            gbEncabezado.SuspendLayout();
            gbDetalle.SuspendLayout();
            SuspendLayout();
            // 
            // txtNumeroPedido
            // 
            txtNumeroPedido.Location = new Point(206, 37);
            txtNumeroPedido.Name = "txtNumeroPedido";
            txtNumeroPedido.Size = new Size(174, 23);
            txtNumeroPedido.TabIndex = 0;
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Location = new Point(191, 102);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(200, 23);
            dtpFechaPedido.TabIndex = 1;
            // 
            // llbFechaPedido
            // 
            llbFechaPedido.AutoSize = true;
            llbFechaPedido.Location = new Point(240, 84);
            llbFechaPedido.Name = "llbFechaPedido";
            llbFechaPedido.Size = new Size(97, 15);
            llbFechaPedido.TabIndex = 2;
            llbFechaPedido.Text = "Fecha del Pedido";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(206, 171);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(174, 23);
            cboCliente.TabIndex = 3;
            // 
            // cboRepartidor
            // 
            cboRepartidor.FormattingEnabled = true;
            cboRepartidor.Location = new Point(206, 229);
            cboRepartidor.Name = "cboRepartidor";
            cboRepartidor.Size = new Size(174, 23);
            cboRepartidor.TabIndex = 4;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(206, 300);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(174, 23);
            txtDireccion.TabIndex = 5;
            // 
            // cboArticulo
            // 
            cboArticulo.FormattingEnabled = true;
            cboArticulo.Location = new Point(268, 48);
            cboArticulo.Name = "cboArticulo";
            cboArticulo.Size = new Size(174, 23);
            cboArticulo.TabIndex = 8;
            cboArticulo.SelectedIndexChanged += cboArticulo_SelectedIndexChanged;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(268, 104);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(174, 23);
            txtCantidad.TabIndex = 9;
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.Location = new Point(292, 161);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(129, 35);
            btnAgregarArticulo.TabIndex = 10;
            btnAgregarArticulo.Text = "Agregar al Pedido";
            btnAgregarArticulo.UseVisualStyleBackColor = true;
            btnAgregarArticulo.Click += btnAgregarArticulo_Click;
            // 
            // dgvDetalle
            // 
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Location = new Point(12, 619);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.Size = new Size(771, 180);
            dgvDetalle.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 196);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 12;
            label2.Text = "Detalles del Pedido";
            // 
            // btnRegistrarPedido
            // 
            btnRegistrarPedido.Location = new Point(304, 820);
            btnRegistrarPedido.Name = "btnRegistrarPedido";
            btnRegistrarPedido.Size = new Size(129, 33);
            btnRegistrarPedido.TabIndex = 13;
            btnRegistrarPedido.Text = "Guardar Pedido";
            btnRegistrarPedido.UseVisualStyleBackColor = true;
            btnRegistrarPedido.Click += btnRegistrarPedido_Click;
            // 
            // gbEncabezado
            // 
            gbEncabezado.Controls.Add(label5);
            gbEncabezado.Controls.Add(label4);
            gbEncabezado.Controls.Add(label3);
            gbEncabezado.Controls.Add(label1);
            gbEncabezado.Controls.Add(txtNumeroPedido);
            gbEncabezado.Controls.Add(cboCliente);
            gbEncabezado.Controls.Add(cboRepartidor);
            gbEncabezado.Controls.Add(dtpFechaPedido);
            gbEncabezado.Controls.Add(llbFechaPedido);
            gbEncabezado.Controls.Add(txtDireccion);
            gbEncabezado.Location = new Point(73, 12);
            gbEncabezado.Name = "gbEncabezado";
            gbEncabezado.Size = new Size(612, 378);
            gbEncabezado.TabIndex = 14;
            gbEncabezado.TabStop = false;
            gbEncabezado.Text = "Registro de Pedido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(231, 282);
            label5.Name = "label5";
            label5.Size = new Size(116, 15);
            label5.TabIndex = 9;
            label5.Text = "Direccion de entrega";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(231, 211);
            label4.Name = "label4";
            label4.Size = new Size(109, 15);
            label4.TabIndex = 8;
            label4.Text = "Nombre Repartidor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(240, 153);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 7;
            label3.Text = "Nombre Cliente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 19);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 6;
            label1.Text = "Numero de Pedido";
            // 
            // gbDetalle
            // 
            gbDetalle.Controls.Add(label7);
            gbDetalle.Controls.Add(label6);
            gbDetalle.Controls.Add(cboArticulo);
            gbDetalle.Controls.Add(txtCantidad);
            gbDetalle.Controls.Add(btnAgregarArticulo);
            gbDetalle.Controls.Add(label2);
            gbDetalle.Location = new Point(12, 396);
            gbDetalle.Name = "gbDetalle";
            gbDetalle.Size = new Size(771, 418);
            gbDetalle.TabIndex = 15;
            gbDetalle.TabStop = false;
            gbDetalle.Text = "Agregar Articulos al Pedido";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(322, 86);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 14;
            label7.Text = "Cantidad";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(328, 30);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 13;
            label6.Text = "Articulo";
            // 
            // FrmRegistroPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 865);
            Controls.Add(btnRegistrarPedido);
            Controls.Add(dgvDetalle);
            Controls.Add(gbEncabezado);
            Controls.Add(gbDetalle);
            Name = "FrmRegistroPedido";
            Text = "FrmRegistroPedido";
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            gbEncabezado.ResumeLayout(false);
            gbEncabezado.PerformLayout();
            gbDetalle.ResumeLayout(false);
            gbDetalle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNumeroPedido;
        private DateTimePicker dtpFechaPedido;
        private Label llbFechaPedido;
        private ComboBox cboCliente;
        private ComboBox cboRepartidor;
        private TextBox txtDireccion;
        private ComboBox cboArticulo;
        private TextBox txtCantidad;
        private Button btnAgregarArticulo;
        private DataGridView dgvDetalle;
        private Label label2;
        private Button btnRegistrarPedido;
        private GroupBox gbEncabezado;
        private GroupBox gbDetalle;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label7;
        private Label label6;
    }
}