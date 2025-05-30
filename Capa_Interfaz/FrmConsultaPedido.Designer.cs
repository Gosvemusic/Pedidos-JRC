namespace Capa_Interfaz
{
    partial class FrmConsultaPedido
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
            gbConsultaP = new GroupBox();
            lblDetalles = new Label();
            lblEncabezados = new Label();
            dgvDetalles = new DataGridView();
            dgvEncabezados = new DataGridView();
            gbConsultaP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEncabezados).BeginInit();
            SuspendLayout();
            // 
            // gbConsultaP
            // 
            gbConsultaP.Controls.Add(dgvDetalles);
            gbConsultaP.Controls.Add(lblDetalles);
            gbConsultaP.Controls.Add(dgvEncabezados);
            gbConsultaP.Controls.Add(lblEncabezados);
            gbConsultaP.Location = new Point(12, 12);
            gbConsultaP.Name = "gbConsultaP";
            gbConsultaP.Size = new Size(776, 426);
            gbConsultaP.TabIndex = 0;
            gbConsultaP.TabStop = false;
            gbConsultaP.Text = "Consulta de Pedidos";
            // 
            // lblDetalles
            // 
            lblDetalles.AutoSize = true;
            lblDetalles.Location = new Point(6, 250);
            lblDetalles.Name = "lblDetalles";
            lblDetalles.Size = new Size(107, 15);
            lblDetalles.TabIndex = 2;
            lblDetalles.Text = "Detalles del Pedido";
            // 
            // lblEncabezados
            // 
            lblEncabezados.AutoSize = true;
            lblEncabezados.Location = new Point(0, 47);
            lblEncabezados.Name = "lblEncabezados";
            lblEncabezados.Size = new Size(136, 15);
            lblEncabezados.TabIndex = 0;
            lblEncabezados.Text = "Encabezados de Pedidos";
            // 
            // dgvDetalles
            // 
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Location = new Point(6, 278);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.Size = new Size(764, 133);
            dgvDetalles.TabIndex = 3;
            // 
            // dgvEncabezados
            // 
            dgvEncabezados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEncabezados.Location = new Point(6, 76);
            dgvEncabezados.Name = "dgvEncabezados";
            dgvEncabezados.Size = new Size(764, 133);
            dgvEncabezados.TabIndex = 1;
            // 
            // FrmConsultaPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gbConsultaP);
            Name = "FrmConsultaPedido";
            Text = "FrmConsultaPedido";
            gbConsultaP.ResumeLayout(false);
            gbConsultaP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEncabezados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbConsultaP;
        private DataGridView dgvDetalles;
        private DataGridView dgvEncabezados;
    }
}