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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(78, 59);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(175, 23);
            txtIdentificacion.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(78, 139);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(175, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.Location = new Point(78, 220);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(175, 23);
            txtPrimerApellido.TabIndex = 2;
            // 
            // txtSegundoApellido
            // 
            txtSegundoApellido.Location = new Point(78, 297);
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(175, 23);
            txtSegundoApellido.TabIndex = 3;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(65, 373);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 4;
            // 
            // lblFechaNa
            // 
            lblFechaNa.AutoSize = true;
            lblFechaNa.Location = new Point(109, 355);
            lblFechaNa.Name = "lblFechaNa";
            lblFechaNa.Size = new Size(103, 15);
            lblFechaNa.TabIndex = 5;
            lblFechaNa.Text = "Fecha Nacimiento";
            // 
            // dtpFechaContratacion
            // 
            dtpFechaContratacion.Location = new Point(65, 465);
            dtpFechaContratacion.Name = "dtpFechaContratacion";
            dtpFechaContratacion.Size = new Size(200, 23);
            dtpFechaContratacion.TabIndex = 6;
            // 
            // lblFechaCon
            // 
            lblFechaCon.AutoSize = true;
            lblFechaCon.Location = new Point(109, 447);
            lblFechaCon.Name = "lblFechaCon";
            lblFechaCon.Size = new Size(110, 15);
            lblFechaCon.TabIndex = 7;
            lblFechaCon.Text = "Fecha Contratacion";
            // 
            // cboActivo
            // 
            cboActivo.FormattingEnabled = true;
            cboActivo.Location = new Point(78, 560);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(175, 23);
            cboActivo.TabIndex = 8;
            cboActivo.SelectedIndexChanged += cboActivo_SelectedIndexChanged;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 41);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 11;
            label1.Text = "Numero de identificacion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 121);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 12;
            label2.Text = "Nombre Repatidor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 202);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 13;
            label3.Text = "Primer Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(122, 279);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 14;
            label4.Text = "Segundo Apellido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(89, 542);
            label5.Name = "label5";
            label5.Size = new Size(164, 15);
            label5.TabIndex = 15;
            label5.Text = "Estado del Repartidor (Activo)";
            // 
            // FrmRegistroRepartidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 679);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}