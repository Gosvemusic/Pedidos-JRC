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
            label1 = new Label();
            txtIdentificacion = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtPrimerApellido = new TextBox();
            label4 = new Label();
            txtSegundoApellido = new TextBox();
            label5 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            cboActivo = new ComboBox();
            label6 = new Label();
            bnGuardar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 18);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 0;
            label1.Text = "Numero de Identificacion";
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(71, 36);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(172, 23);
            txtIdentificacion.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(106, 95);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre Cliente";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(71, 113);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(172, 23);
            txtNombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 164);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 4;
            label3.Text = "Primer Apellido";
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.Location = new Point(71, 182);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(172, 23);
            txtPrimerApellido.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 235);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 6;
            label4.Text = "Segundo Apellido";
            // 
            // txtSegundoApellido
            // 
            txtSegundoApellido.Location = new Point(71, 253);
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(172, 23);
            txtSegundoApellido.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(106, 307);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 8;
            label5.Text = "Fecha de Nacimiento";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(56, 325);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(200, 23);
            dtpFechaNacimiento.TabIndex = 9;
            // 
            // cboActivo
            // 
            cboActivo.FormattingEnabled = true;
            cboActivo.Location = new Point(71, 401);
            cboActivo.Name = "cboActivo";
            cboActivo.Size = new Size(172, 23);
            cboActivo.TabIndex = 10;
            cboActivo.SelectedIndexChanged += cboActivo_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(87, 383);
            label6.Name = "label6";
            label6.Size = new Size(146, 15);
            label6.TabIndex = 11;
            label6.Text = "Estado del Cliente (Activo)";
            label6.Click += label6_Click;
            // 
            // bnGuardar
            // 
            bnGuardar.Location = new Point(122, 454);
            bnGuardar.Name = "bnGuardar";
            bnGuardar.Size = new Size(87, 43);
            bnGuardar.TabIndex = 12;
            bnGuardar.Text = "Guardar";
            bnGuardar.UseVisualStyleBackColor = true;
            bnGuardar.Click += bnGuardar_Click;
            // 
            // FrmRegistroCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 526);
            Controls.Add(bnGuardar);
            Controls.Add(label6);
            Controls.Add(cboActivo);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(label5);
            Controls.Add(txtSegundoApellido);
            Controls.Add(label4);
            Controls.Add(txtPrimerApellido);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtIdentificacion);
            Controls.Add(label1);
            Name = "FrmRegistroCliente";
            Text = "FrmRegistroCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIdentificacion;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtPrimerApellido;
        private Label label4;
        private TextBox txtSegundoApellido;
        private Label label5;
        private DateTimePicker dtpFechaNacimiento;
        private ComboBox cboActivo;
        private Label label6;
        private Button bnGuardar;
    }
}