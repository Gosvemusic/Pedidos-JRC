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
            gbDetalle = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // txtNumeroPedido
            // 
            txtNumeroPedido.Location = new Point(279, 74);
            txtNumeroPedido.Name = "txtNumeroPedido";
            txtNumeroPedido.Size = new Size(174, 23);
            txtNumeroPedido.TabIndex = 0;
            txtNumeroPedido.Text = "Numero de Pedido";
            // 
            // dtpFechaPedido
            // 
            dtpFechaPedido.Location = new Point(265, 152);
            dtpFechaPedido.Name = "dtpFechaPedido";
            dtpFechaPedido.Size = new Size(200, 23);
            dtpFechaPedido.TabIndex = 1;
            // 
            // llbFechaPedido
            // 
            llbFechaPedido.AutoSize = true;
            llbFechaPedido.Location = new Point(313, 122);
            llbFechaPedido.Name = "llbFechaPedido";
            llbFechaPedido.Size = new Size(97, 15);
            llbFechaPedido.TabIndex = 2;
            llbFechaPedido.Text = "Fecha del Pedido";
            // 
            // cboCliente
            // 
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(279, 209);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(174, 23);
            cboCliente.TabIndex = 3;
            cboCliente.Text = "Cliente";
            // 
            // cboRepartidor
            // 
            cboRepartidor.FormattingEnabled = true;
            cboRepartidor.Location = new Point(279, 284);
            cboRepartidor.Name = "cboRepartidor";
            cboRepartidor.Size = new Size(174, 23);
            cboRepartidor.TabIndex = 4;
            cboRepartidor.Text = "Repartidor";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(279, 354);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(174, 23);
            txtDireccion.TabIndex = 5;
            txtDireccion.Text = "Direccion de Entrega";
            // 
            // cboArticulo
            // 
            cboArticulo.FormattingEnabled = true;
            cboArticulo.Location = new Point(279, 451);
            cboArticulo.Name = "cboArticulo";
            cboArticulo.Size = new Size(174, 23);
            cboArticulo.TabIndex = 8;
            cboArticulo.Text = "Articulo";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(279, 509);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(174, 23);
            txtCantidad.TabIndex = 9;
            txtCantidad.Text = "Cantidad";
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.Location = new Point(304, 558);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(129, 35);
            btnAgregarArticulo.TabIndex = 10;
            btnAgregarArticulo.Text = "Agregar Articulo";
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
            label2.Location = new Point(12, 588);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 12;
            label2.Text = "Lista Detalle";
            // 
            // btnRegistrarPedido
            // 
            btnRegistrarPedido.Location = new Point(304, 820);
            btnRegistrarPedido.Name = "btnRegistrarPedido";
            btnRegistrarPedido.Size = new Size(129, 33);
            btnRegistrarPedido.TabIndex = 13;
            btnRegistrarPedido.Text = "Registrar Pedido";
            btnRegistrarPedido.UseVisualStyleBackColor = true;
            btnRegistrarPedido.Click += btnRegistrarPedido_Click;
            // 
            // gbEncabezado
            // 
            gbEncabezado.Location = new Point(73, 12);
            gbEncabezado.Name = "gbEncabezado";
            gbEncabezado.Size = new Size(612, 378);
            gbEncabezado.TabIndex = 14;
            gbEncabezado.TabStop = false;
            gbEncabezado.Text = "PEDIDO";
            // 
            // gbDetalle
            // 
            gbDetalle.Location = new Point(12, 396);
            gbDetalle.Name = "gbDetalle";
            gbDetalle.Size = new Size(771, 418);
            gbDetalle.TabIndex = 15;
            gbDetalle.TabStop = false;
            gbDetalle.Text = "DETALLE DEL PEDIDO";
            // 
            // FrmRegistroPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 865);
            Controls.Add(btnRegistrarPedido);
            Controls.Add(label2);
            Controls.Add(dgvDetalle);
            Controls.Add(btnAgregarArticulo);
            Controls.Add(txtCantidad);
            Controls.Add(cboArticulo);
            Controls.Add(txtDireccion);
            Controls.Add(cboRepartidor);
            Controls.Add(cboCliente);
            Controls.Add(llbFechaPedido);
            Controls.Add(dtpFechaPedido);
            Controls.Add(txtNumeroPedido);
            Controls.Add(gbEncabezado);
            Controls.Add(gbDetalle);
            Name = "FrmRegistroPedido";
            Text = "FrmRegistroPedido";
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
    }
}