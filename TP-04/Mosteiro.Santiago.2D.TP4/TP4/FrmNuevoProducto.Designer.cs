namespace TP4
{
    partial class FrmNuevoProducto
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
            this.tituloNuevoProductoLbl = new System.Windows.Forms.Label();
            this.nombreProductoLbl = new System.Windows.Forms.Label();
            this.nombreTxtBox = new System.Windows.Forms.TextBox();
            this.precioProductoLbl = new System.Windows.Forms.Label();
            this.precioTxtBox = new System.Windows.Forms.TextBox();
            this.stockProductoLbl = new System.Windows.Forms.Label();
            this.stockTxtBox = new System.Windows.Forms.TextBox();
            this.tipoProductoLbl = new System.Windows.Forms.Label();
            this.cmbTipoProductos = new System.Windows.Forms.ComboBox();
            this.agregarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tituloNuevoProductoLbl
            // 
            this.tituloNuevoProductoLbl.AutoSize = true;
            this.tituloNuevoProductoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloNuevoProductoLbl.Location = new System.Drawing.Point(47, 32);
            this.tituloNuevoProductoLbl.Name = "tituloNuevoProductoLbl";
            this.tituloNuevoProductoLbl.Size = new System.Drawing.Size(272, 25);
            this.tituloNuevoProductoLbl.TabIndex = 4;
            this.tituloNuevoProductoLbl.Text = "Información del producto";
            // 
            // nombreProductoLbl
            // 
            this.nombreProductoLbl.AutoSize = true;
            this.nombreProductoLbl.Location = new System.Drawing.Point(49, 93);
            this.nombreProductoLbl.Name = "nombreProductoLbl";
            this.nombreProductoLbl.Size = new System.Drawing.Size(44, 13);
            this.nombreProductoLbl.TabIndex = 5;
            this.nombreProductoLbl.Text = "Nombre";
            // 
            // nombreTxtBox
            // 
            this.nombreTxtBox.Location = new System.Drawing.Point(157, 93);
            this.nombreTxtBox.Name = "nombreTxtBox";
            this.nombreTxtBox.Size = new System.Drawing.Size(121, 20);
            this.nombreTxtBox.TabIndex = 6;
            this.nombreTxtBox.TextChanged += new System.EventHandler(this.oyenteTextosCambiados);
            this.nombreTxtBox.Leave += new System.EventHandler(this.oyenteFocoSalidaTextos);
            // 
            // precioProductoLbl
            // 
            this.precioProductoLbl.AutoSize = true;
            this.precioProductoLbl.Location = new System.Drawing.Point(49, 140);
            this.precioProductoLbl.Name = "precioProductoLbl";
            this.precioProductoLbl.Size = new System.Drawing.Size(37, 13);
            this.precioProductoLbl.TabIndex = 7;
            this.precioProductoLbl.Text = "Precio";
            // 
            // precioTxtBox
            // 
            this.precioTxtBox.Location = new System.Drawing.Point(157, 137);
            this.precioTxtBox.Name = "precioTxtBox";
            this.precioTxtBox.Size = new System.Drawing.Size(121, 20);
            this.precioTxtBox.TabIndex = 8;
            this.precioTxtBox.TextChanged += new System.EventHandler(this.oyenteTextosCambiados);
            this.precioTxtBox.Leave += new System.EventHandler(this.oyenteFocoSalidaTextos);
            // 
            // stockProductoLbl
            // 
            this.stockProductoLbl.AutoSize = true;
            this.stockProductoLbl.Location = new System.Drawing.Point(49, 184);
            this.stockProductoLbl.Name = "stockProductoLbl";
            this.stockProductoLbl.Size = new System.Drawing.Size(85, 13);
            this.stockProductoLbl.TabIndex = 9;
            this.stockProductoLbl.Text = "Stock disponible";
            // 
            // stockTxtBox
            // 
            this.stockTxtBox.Location = new System.Drawing.Point(157, 181);
            this.stockTxtBox.Name = "stockTxtBox";
            this.stockTxtBox.Size = new System.Drawing.Size(121, 20);
            this.stockTxtBox.TabIndex = 10;
            this.stockTxtBox.TextChanged += new System.EventHandler(this.oyenteTextosCambiados);
            this.stockTxtBox.Leave += new System.EventHandler(this.oyenteFocoSalidaTextos);
            // 
            // tipoProductoLbl
            // 
            this.tipoProductoLbl.AutoSize = true;
            this.tipoProductoLbl.Location = new System.Drawing.Point(49, 233);
            this.tipoProductoLbl.Name = "tipoProductoLbl";
            this.tipoProductoLbl.Size = new System.Drawing.Size(73, 13);
            this.tipoProductoLbl.TabIndex = 11;
            this.tipoProductoLbl.Text = "Tipo producto";
            // 
            // cmbTipoProductos
            // 
            this.cmbTipoProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoProductos.FormattingEnabled = true;
            this.cmbTipoProductos.Location = new System.Drawing.Point(157, 230);
            this.cmbTipoProductos.Name = "cmbTipoProductos";
            this.cmbTipoProductos.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoProductos.TabIndex = 12;
            this.cmbTipoProductos.SelectedIndexChanged += new System.EventHandler(this.oyenteTextosCambiados);
            // 
            // agregarButton
            // 
            this.agregarButton.Enabled = false;
            this.agregarButton.Location = new System.Drawing.Point(52, 282);
            this.agregarButton.Name = "agregarButton";
            this.agregarButton.Size = new System.Drawing.Size(267, 23);
            this.agregarButton.TabIndex = 13;
            this.agregarButton.Text = "Agregar";
            this.agregarButton.UseVisualStyleBackColor = true;
            this.agregarButton.Click += new System.EventHandler(this.agregarButton_Click);
            // 
            // FrmNuevoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(408, 327);
            this.Controls.Add(this.agregarButton);
            this.Controls.Add(this.cmbTipoProductos);
            this.Controls.Add(this.tipoProductoLbl);
            this.Controls.Add(this.stockTxtBox);
            this.Controls.Add(this.stockProductoLbl);
            this.Controls.Add(this.precioTxtBox);
            this.Controls.Add(this.precioProductoLbl);
            this.Controls.Add(this.nombreTxtBox);
            this.Controls.Add(this.nombreProductoLbl);
            this.Controls.Add(this.tituloNuevoProductoLbl);
            this.Name = "FrmNuevoProducto";
            this.Text = "Nuevo producto";
            this.Load += new System.EventHandler(this.FrmNuevoProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tituloNuevoProductoLbl;
        private System.Windows.Forms.Label nombreProductoLbl;
        private System.Windows.Forms.TextBox nombreTxtBox;
        private System.Windows.Forms.Label precioProductoLbl;
        private System.Windows.Forms.TextBox precioTxtBox;
        private System.Windows.Forms.Label stockProductoLbl;
        private System.Windows.Forms.TextBox stockTxtBox;
        private System.Windows.Forms.Label tipoProductoLbl;
        private System.Windows.Forms.ComboBox cmbTipoProductos;
        private System.Windows.Forms.Button agregarButton;
    }
}