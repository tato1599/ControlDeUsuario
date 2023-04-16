namespace ControlesPersonalizados.Buscador
{
    partial class Buscador
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnbuscar = new System.Windows.Forms.Button();
            this.tbbuscar = new System.Windows.Forms.TextBox();
            this.dgvCanciones = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demo = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnbuscar.ForeColor = System.Drawing.Color.Black;
            this.btnbuscar.Location = new System.Drawing.Point(292, 26);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(75, 23);
            this.btnbuscar.TabIndex = 0;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // tbbuscar
            // 
            this.tbbuscar.Location = new System.Drawing.Point(19, 27);
            this.tbbuscar.Name = "tbbuscar";
            this.tbbuscar.Size = new System.Drawing.Size(267, 23);
            this.tbbuscar.TabIndex = 1;
            this.tbbuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbbuscar_KeyDown);
            // 
            // dgvCanciones
            // 
            this.dgvCanciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Artista,
            this.Demo});
            this.dgvCanciones.Location = new System.Drawing.Point(19, 55);
            this.dgvCanciones.Name = "dgvCanciones";
            this.dgvCanciones.RowTemplate.Height = 25;
            this.dgvCanciones.Size = new System.Drawing.Size(348, 150);
            this.dgvCanciones.TabIndex = 2;
            this.dgvCanciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCanciones_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Artista
            // 
            this.Artista.HeaderText = "Artista";
            this.Artista.Name = "Artista";
            // 
            // Demo
            // 
            this.Demo.HeaderText = "Demo";
            this.Demo.Name = "Demo";
            this.Demo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Demo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Buscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCanciones);
            this.Controls.Add(this.tbbuscar);
            this.Controls.Add(this.btnbuscar);
            this.Name = "Buscador";
            this.Size = new System.Drawing.Size(382, 219);
            this.Load += new System.EventHandler(this.Buscador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnbuscar;
        private TextBox tbbuscar;
        private DataGridView dgvCanciones;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Artista;
        private DataGridViewLinkColumn Demo;
    }
}
