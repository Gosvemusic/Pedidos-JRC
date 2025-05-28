namespace Capa_Interfaz
{
    partial class FrmRegistroCliente
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
            txtIdentificacion = new TextBox();
            txtNombre = new TextBox();
            txtPrimerApellido = new TextBox();
            txtSegundoApellido = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            lblFechaNacimiento = new Label();
            cboActivo = new ComboBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            SuspendLayout();
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(119, 35);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(169, 23);
            txtIdentificacion.TabIndex = 0;
            txtIdentificacion.Text = "Identificacion";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(119, 102);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(169, 23);
            txtNombre.TabIndex = 1;
            txtNombre.Text = "Nombre";
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.Location = new Point(119, 182);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(169, 23);
            txtPrimerApellido.TabIndex = 2;
            txtPrimerApellido.Text = "Primer Apellido";
            // 
            // txtSegundoApellido
            // 
            txtSegundoApellido.Location = new Point(119, 266);
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(169, 23);
            txtSegundoApellido.TabIndex = 3;
            txtSegundoApellido.Text = "Segundo Apellido";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(107, 358);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 4;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(150, 325);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(103, 15);
            lblFechaNacimiento.TabIndex = 5;
            lblFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // cboActivo
            // 
            cboActivo.FormattingEnabled = true;
            cboActivo.Location = new Point(119, 434);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(169, 23);
            cboActivo.TabIndex = 6;
            cboActivo.Text = "Activo";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(166, 496);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(87, 33);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(322, 501);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // FrmRegistroCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 541);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(cboActivo);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtSegundoApellido);
            Controls.Add(txtPrimerApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtIdentificacion);
            Name = "FrmRegistroCliente";
            Text = "FrmRegistroCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdentificacion;
        private TextBox txtNombre;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblFechaNacimiento;
        private ComboBox cboActivo;
        private Button btnGuardar;
        private Button btnLimpiar;
    }
}