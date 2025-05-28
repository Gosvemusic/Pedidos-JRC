namespace Capa_Interfaz
{
    partial class FrmRegistroRepartidor
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
            lblFechaNa = new Label();
            dtpFechaContratacion = new DateTimePicker();
            lblFechaCon = new Label();
            cboActivo = new ComboBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            SuspendLayout();
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(78, 42);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(175, 23);
            txtIdentificacion.TabIndex = 0;
            txtIdentificacion.Text = "Identificacion";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(78, 128);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(175, 23);
            txtNombre.TabIndex = 1;
            txtNombre.Text = "Nombre";
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.Location = new Point(78, 220);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(175, 23);
            txtPrimerApellido.TabIndex = 2;
            txtPrimerApellido.Text = "Primer Apellido";
            // 
            // txtSegundoApellido
            // 
            txtSegundoApellido.Location = new Point(78, 297);
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(175, 23);
            txtSegundoApellido.TabIndex = 3;
            txtSegundoApellido.Text = "Segundo Apellido";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(65, 407);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 4;
            // 
            // lblFechaNa
            // 
            lblFechaNa.AutoSize = true;
            lblFechaNa.Location = new Point(109, 375);
            lblFechaNa.Name = "lblFechaNa";
            lblFechaNa.Size = new Size(103, 15);
            lblFechaNa.TabIndex = 5;
            lblFechaNa.Text = "Fecha Nacimiento";
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Location = new Point(65, 506);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(200, 23);
            dtpFechaContratacion.TabIndex = 6;
            // 
            // lblFechaCon
            // 
            lblFechaCon.AutoSize = true;
            lblFechaCon.Location = new Point(102, 474);
            lblFechaCon.Name = "lblFechaCon";
            lblFechaCon.Size = new Size(110, 15);
            lblFechaCon.TabIndex = 7;
            lblFechaCon.Text = "Fecha Contratacion";
            // 
            // cboActivo
            // 
            cboActivo.FormattingEnabled = true;
            cboActivo.Location = new Point(78, 571);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(175, 23);
            cboActivo.TabIndex = 8;
            cboActivo.Text = "Activo";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(122, 631);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 36);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(261, 638);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // FrmRegistroRepartidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 679);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(cboActivo);
            Controls.Add(lblFechaCon);
            Controls.Add(dtpFechaContratacion);
            Controls.Add(lblFechaNa);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtSegundoApellido);
            Controls.Add(txtPrimerApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtIdentificacion);
            Name = "FrmRegistroRepartidor";
            Text = "FrmRegistroRepartidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdentificacion;
        private TextBox txtNombre;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblFechaNa;
        private DateTimePicker dtpFechaContratacion;
        private Label lblFechaCon;
        private ComboBox cboActivo;
        private Button btnGuardar;
        private Button btnLimpiar;
    }
}