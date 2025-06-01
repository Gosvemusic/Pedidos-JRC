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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(99, 57);
            txtId.Name = "txtId";
            txtId.Size = new Size(190, 23);
            txtId.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(99, 139);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(190, 23);
            txtNombre.TabIndex = 1;
            // 
            // cboTipoArticulo
            // 
            cboTipoArticulo.FormattingEnabled = true;
            cboTipoArticulo.Location = new Point(99, 230);
            cboTipoArticulo.Name = "cboTipoArticulo";
            cboTipoArticulo.Size = new Size(190, 23);
            cboTipoArticulo.TabIndex = 2;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(99, 322);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(190, 23);
            txtValor.TabIndex = 3;
            // 
            // txtInventario
            // 
            txtInventario.Location = new Point(99, 395);
            txtInventario.Name = "txtInventario";
            txtInventario.Size = new Size(190, 23);
            txtInventario.TabIndex = 4;
            // 
            // cboActivo
            // 
            cboActivo.FormattingEnabled = true;
            cboActivo.Location = new Point(99, 464);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(190, 23);
            cboActivo.TabIndex = 5;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 39);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 8;
            label1.Text = "Numero ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 121);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 9;
            label2.Text = "Nombre del Articulo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(153, 212);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 10;
            label3.Text = "Tipo de Articulo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(98, 304);
            label4.Name = "label4";
            label4.Size = new Size(191, 15);
            label4.TabIndex = 11;
            label4.Text = "Monto del artículo (Solo Numeros)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(98, 377);
            label5.Name = "label5";
            label5.Size = new Size(206, 15);
            label5.TabIndex = 12;
            label5.Text = "Cantidad de articulos  en el inventario";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(123, 446);
            label6.Name = "label6";
            label6.Size = new Size(151, 15);
            label6.TabIndex = 13;
            label6.Text = "Estado del Articulo (Activo)";
            // 
            // FrmRegistroArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 576);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}