namespace Capa_Interfaz
{
    partial class FrmConsultaTipoArticulo
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
            dgvTipoArticulo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTipoArticulo).BeginInit();
            SuspendLayout();
            // 
            // dgvTipoArticulo
            // 
            dgvTipoArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipoArticulo.Location = new Point(12, 12);
            dgvTipoArticulo.Name = "dgvTipoArticulo";
            dgvTipoArticulo.Size = new Size(776, 426);
            dgvTipoArticulo.TabIndex = 0;
            dgvTipoArticulo.CellContentClick += dgvTipoArticulo_CellContentClick;
            // 
            // FrmConsultaTipoArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvTipoArticulo);
            Name = "FrmConsultaTipoArticulo";
            Text = "FrmConsultaTipoArticulo";
            ((System.ComponentModel.ISupportInitialize)dgvTipoArticulo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTipoArticulo;
    }
}