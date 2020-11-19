namespace TP4
{
    partial class FrmNuevaVenta
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
            this.ventaTituloLbl = new System.Windows.Forms.Label();
            this.ventaSubtituloLbl = new System.Windows.Forms.Label();
            this.dataGridProductos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // ventaTituloLbl
            // 
            this.ventaTituloLbl.AutoSize = true;
            this.ventaTituloLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaTituloLbl.Location = new System.Drawing.Point(266, 9);
            this.ventaTituloLbl.Name = "ventaTituloLbl";
            this.ventaTituloLbl.Size = new System.Drawing.Size(134, 24);
            this.ventaTituloLbl.TabIndex = 2;
            this.ventaTituloLbl.Text = "Nueva venta";
            // 
            // ventaSubtituloLbl
            // 
            this.ventaSubtituloLbl.AutoSize = true;
            this.ventaSubtituloLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaSubtituloLbl.Location = new System.Drawing.Point(12, 47);
            this.ventaSubtituloLbl.Name = "ventaSubtituloLbl";
            this.ventaSubtituloLbl.Size = new System.Drawing.Size(487, 18);
            this.ventaSubtituloLbl.TabIndex = 3;
            this.ventaSubtituloLbl.Text = "Seleccioná el producto con doble click para realizar la venta";
            // 
            // dataGridProductos
            // 
            this.dataGridProductos.AllowUserToAddRows = false;
            this.dataGridProductos.AllowUserToDeleteRows = false;
            this.dataGridProductos.AllowUserToResizeColumns = false;
            this.dataGridProductos.AllowUserToResizeRows = false;
            this.dataGridProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridProductos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductos.Location = new System.Drawing.Point(47, 88);
            this.dataGridProductos.MultiSelect = false;
            this.dataGridProductos.Name = "dataGridProductos";
            this.dataGridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProductos.Size = new System.Drawing.Size(612, 262);
            this.dataGridProductos.TabIndex = 4;
            this.dataGridProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProductos_CellDoubleClick);
            // 
            // FrmNuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(695, 381);
            this.Controls.Add(this.dataGridProductos);
            this.Controls.Add(this.ventaSubtituloLbl);
            this.Controls.Add(this.ventaTituloLbl);
            this.Name = "FrmNuevaVenta";
            this.Text = "Nueva venta";
            this.Load += new System.EventHandler(this.FrmNuevaVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ventaTituloLbl;
        private System.Windows.Forms.Label ventaSubtituloLbl;
        private System.Windows.Forms.DataGridView dataGridProductos;
    }
}