namespace Capa_Interfaz
{
    partial class FrmRegistroTipoArticulo
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
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtId = new TextBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(94, 157);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(214, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(94, 258);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(214, 23);
            txtDescripcion.TabIndex = 1;
            // 
            // txtId
            // 
            txtId.Location = new Point(94, 54);
            txtId.Name = "txtId";
            txtId.Size = new Size(214, 23);
            txtId.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(152, 327);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(88, 31);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(308, 331);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 36);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 5;
            label1.Text = "Numero ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 139);
            label2.Name = "label2";
            label2.Size = new Size(158, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre del Tipo de Articulo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 240);
            label3.Name = "label3";
            label3.Size = new Size(202, 15);
            label3.TabIndex = 7;
            label3.Text = "Breve descripcion del tipo de articulo";
            // 
            // FrmRegistroTipoArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 390);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(txtId);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombre);
            Name = "FrmRegistroTipoArticulo";
            Text = "FrmRegistroTipoArticulo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private TextBox txtId;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}