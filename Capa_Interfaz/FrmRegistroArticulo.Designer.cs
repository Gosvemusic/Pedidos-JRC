namespace Capa_Interfaz
{
    partial class FrmRegistroArticulo
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
            txtId = new TextBox();
            txtNombre = new TextBox();
            cboTipoArticulo = new ComboBox();
            txtValor = new TextBox();
            txtInventario = new TextBox();
            cboActivo = new ComboBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(99, 57);
            txtId.Name = "txtId";
            txtId.Size = new Size(190, 23);
            txtId.TabIndex = 0;
            txtId.Text = "ID";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(99, 139);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(190, 23);
            txtNombre.TabIndex = 1;
            txtNombre.Text = "Nombre";
            // 
            // cboTipoArticulo
            // 
            cboTipoArticulo.FormattingEnabled = true;
            cboTipoArticulo.Location = new Point(99, 230);
            cboTipoArticulo.Name = "cboTipoArticulo";
            cboTipoArticulo.Size = new Size(190, 23);
            cboTipoArticulo.TabIndex = 2;
            cboTipoArticulo.Text = "Tipo Articulo";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(99, 322);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(190, 23);
            txtValor.TabIndex = 3;
            txtValor.Text = "Valor";
            // 
            // txtInventario
            // 
            txtInventario.Location = new Point(99, 395);
            txtInventario.Name = "txtInventario";
            txtInventario.Size = new Size(190, 23);
            txtInventario.TabIndex = 4;
            txtInventario.Text = "Inventario";
            // 
            // cboActivo
            // 
            cboActivo.FormattingEnabled = true;
            cboActivo.Location = new Point(99, 464);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(190, 23);
            cboActivo.TabIndex = 5;
            cboActivo.Text = "Activo";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(144, 528);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(101, 36);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(306, 535);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // FrmRegistroArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 576);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(cboActivo);
            Controls.Add(txtInventario);
            Controls.Add(txtValor);
            Controls.Add(cboTipoArticulo);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Name = "FrmRegistroArticulo";
            Text = "FrmRegistroArticulo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private TextBox txtNombre;
        private ComboBox cboTipoArticulo;
        private TextBox txtValor;
        private TextBox txtInventario;
        private ComboBox cboActivo;
        private Button btnGuardar;
        private Button btnLimpiar;
    }
}