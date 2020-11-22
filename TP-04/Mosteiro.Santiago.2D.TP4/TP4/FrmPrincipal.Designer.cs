namespace TP4
{
    partial class FrmPrincipal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verProductosDisponiblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ventasGridView = new System.Windows.Forms.DataGridView();
            this.emptyStateLbl = new System.Windows.Forms.Label();
            this.tituloVentasLbl = new System.Windows.Forms.Label();
            this.ventasTxtButton = new System.Windows.Forms.Button();
            this.ventasXmlButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ventasGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.verProductosDisponiblesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productoToolStripMenuItem,
            this.ventaToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.nuevoToolStripMenuItem.Text = "&Nuevo";
            // 
            // productoToolStripMenuItem
            // 
            this.productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            this.productoToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.productoToolStripMenuItem.Text = "Producto";
            this.productoToolStripMenuItem.Click += new System.EventHandler(this.productoToolStripMenuItem_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.ventaToolStripMenuItem.Text = "Venta";
            this.ventaToolStripMenuItem.Click += new System.EventHandler(this.ventaToolStripMenuItem_Click);
            // 
            // verProductosDisponiblesToolStripMenuItem
            // 
            this.verProductosDisponiblesToolStripMenuItem.Name = "verProductosDisponiblesToolStripMenuItem";
            this.verProductosDisponiblesToolStripMenuItem.Size = new System.Drawing.Size(155, 20);
            this.verProductosDisponiblesToolStripMenuItem.Text = "Ver productos disponibles";
            this.verProductosDisponiblesToolStripMenuItem.Click += new System.EventHandler(this.verProductosDisponiblesToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ventasGridView
            // 
            this.ventasGridView.AllowUserToAddRows = false;
            this.ventasGridView.AllowUserToDeleteRows = false;
            this.ventasGridView.AllowUserToResizeColumns = false;
            this.ventasGridView.AllowUserToResizeRows = false;
            this.ventasGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ventasGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ventasGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.ventasGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ventasGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ventasGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ventasGridView.Location = new System.Drawing.Point(63, 84);
            this.ventasGridView.MultiSelect = false;
            this.ventasGridView.Name = "ventasGridView";
            this.ventasGridView.ReadOnly = true;
            this.ventasGridView.Size = new System.Drawing.Size(661, 310);
            this.ventasGridView.TabIndex = 1;
            // 
            // emptyStateLbl
            // 
            this.emptyStateLbl.AutoSize = true;
            this.emptyStateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptyStateLbl.Location = new System.Drawing.Point(202, 195);
            this.emptyStateLbl.Name = "emptyStateLbl";
            this.emptyStateLbl.Size = new System.Drawing.Size(387, 25);
            this.emptyStateLbl.TabIndex = 2;
            this.emptyStateLbl.Text = "Todavía no tenés ventas realizadas";
            // 
            // tituloVentasLbl
            // 
            this.tituloVentasLbl.AutoSize = true;
            this.tituloVentasLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloVentasLbl.Location = new System.Drawing.Point(294, 56);
            this.tituloVentasLbl.Name = "tituloVentasLbl";
            this.tituloVentasLbl.Size = new System.Drawing.Size(201, 25);
            this.tituloVentasLbl.TabIndex = 3;
            this.tituloVentasLbl.Text = "Ventas realizadas";
            // 
            // ventasTxtButton
            // 
            this.ventasTxtButton.Enabled = false;
            this.ventasTxtButton.Location = new System.Drawing.Point(186, 415);
            this.ventasTxtButton.Name = "ventasTxtButton";
            this.ventasTxtButton.Size = new System.Drawing.Size(195, 23);
            this.ventasTxtButton.TabIndex = 4;
            this.ventasTxtButton.Text = "Descargar ventas (TXT)";
            this.ventasTxtButton.UseVisualStyleBackColor = true;
            this.ventasTxtButton.Click += new System.EventHandler(this.ventasTxtButton_Click);
            // 
            // ventasXmlButton
            // 
            this.ventasXmlButton.Enabled = false;
            this.ventasXmlButton.Location = new System.Drawing.Point(414, 415);
            this.ventasXmlButton.Name = "ventasXmlButton";
            this.ventasXmlButton.Size = new System.Drawing.Size(195, 23);
            this.ventasXmlButton.TabIndex = 5;
            this.ventasXmlButton.Text = "Descargar ventas (XML)";
            this.ventasXmlButton.UseVisualStyleBackColor = true;
            this.ventasXmlButton.Click += new System.EventHandler(this.ventasXmlButton_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ventasXmlButton);
            this.Controls.Add(this.ventasTxtButton);
            this.Controls.Add(this.tituloVentasLbl);
            this.Controls.Add(this.emptyStateLbl);
            this.Controls.Add(this.ventasGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Menú principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ventasGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView ventasGridView;
        private System.Windows.Forms.Label emptyStateLbl;
        private System.Windows.Forms.Label tituloVentasLbl;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verProductosDisponiblesToolStripMenuItem;
        private System.Windows.Forms.Button ventasTxtButton;
        private System.Windows.Forms.Button ventasXmlButton;
    }
}

