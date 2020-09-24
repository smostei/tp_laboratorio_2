namespace CalculadoraTP
{
    partial class FormCalculadora
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
            this.num1TxtBox = new System.Windows.Forms.TextBox();
            this.num2TxtBox = new System.Windows.Forms.TextBox();
            this.operadorCmbBox = new System.Windows.Forms.ComboBox();
            this.operarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.cerrarButton = new System.Windows.Forms.Button();
            this.parseBinarioButton = new System.Windows.Forms.Button();
            this.parseDecimalButton = new System.Windows.Forms.Button();
            this.resultadoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // num1TxtBox
            // 
            this.num1TxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num1TxtBox.Location = new System.Drawing.Point(88, 50);
            this.num1TxtBox.Name = "num1TxtBox";
            this.num1TxtBox.Size = new System.Drawing.Size(70, 26);
            this.num1TxtBox.TabIndex = 0;
            this.num1TxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // num2TxtBox
            // 
            this.num2TxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num2TxtBox.Location = new System.Drawing.Point(240, 50);
            this.num2TxtBox.Name = "num2TxtBox";
            this.num2TxtBox.Size = new System.Drawing.Size(70, 26);
            this.num2TxtBox.TabIndex = 1;
            this.num2TxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // operadorCmbBox
            // 
            this.operadorCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operadorCmbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operadorCmbBox.FormattingEnabled = true;
            this.operadorCmbBox.ItemHeight = 20;
            this.operadorCmbBox.Items.AddRange(new object[] {
            "/",
            "*",
            "+",
            "-"});
            this.operadorCmbBox.Location = new System.Drawing.Point(164, 49);
            this.operadorCmbBox.Name = "operadorCmbBox";
            this.operadorCmbBox.Size = new System.Drawing.Size(70, 28);
            this.operadorCmbBox.TabIndex = 2;
            this.operadorCmbBox.SelectedIndexChanged += new System.EventHandler(this.operadorCmbBox_SelectedIndexChanged);
            // 
            // operarButton
            // 
            this.operarButton.Enabled = false;
            this.operarButton.Location = new System.Drawing.Point(88, 108);
            this.operarButton.Name = "operarButton";
            this.operarButton.Size = new System.Drawing.Size(70, 23);
            this.operarButton.TabIndex = 3;
            this.operarButton.Text = "Operar";
            this.operarButton.UseVisualStyleBackColor = true;
            this.operarButton.Click += new System.EventHandler(this.operarButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(164, 108);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(70, 23);
            this.limpiarButton.TabIndex = 4;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // cerrarButton
            // 
            this.cerrarButton.Location = new System.Drawing.Point(240, 108);
            this.cerrarButton.Name = "cerrarButton";
            this.cerrarButton.Size = new System.Drawing.Size(70, 23);
            this.cerrarButton.TabIndex = 5;
            this.cerrarButton.Text = "Cerrar";
            this.cerrarButton.UseVisualStyleBackColor = true;
            this.cerrarButton.Click += new System.EventHandler(this.cerrarButton_Click);
            // 
            // parseBinarioButton
            // 
            this.parseBinarioButton.Location = new System.Drawing.Point(70, 161);
            this.parseBinarioButton.Name = "parseBinarioButton";
            this.parseBinarioButton.Size = new System.Drawing.Size(129, 23);
            this.parseBinarioButton.TabIndex = 6;
            this.parseBinarioButton.Text = "Convertir a Binario";
            this.parseBinarioButton.UseVisualStyleBackColor = true;
            this.parseBinarioButton.Click += new System.EventHandler(this.parseBinarioButton_Click);
            // 
            // parseDecimalButton
            // 
            this.parseDecimalButton.Location = new System.Drawing.Point(205, 161);
            this.parseDecimalButton.Name = "parseDecimalButton";
            this.parseDecimalButton.Size = new System.Drawing.Size(129, 23);
            this.parseDecimalButton.TabIndex = 7;
            this.parseDecimalButton.Text = "Convertir a Decimal";
            this.parseDecimalButton.UseVisualStyleBackColor = true;
            this.parseDecimalButton.Click += new System.EventHandler(this.parseDecimalButton_Click);
            // 
            // resultadoLabel
            // 
            this.resultadoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultadoLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resultadoLabel.Location = new System.Drawing.Point(217, 9);
            this.resultadoLabel.Name = "resultadoLabel";
            this.resultadoLabel.Size = new System.Drawing.Size(185, 20);
            this.resultadoLabel.TabIndex = 8;
            this.resultadoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 214);
            this.Controls.Add(this.resultadoLabel);
            this.Controls.Add(this.parseDecimalButton);
            this.Controls.Add(this.parseBinarioButton);
            this.Controls.Add(this.cerrarButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.operarButton);
            this.Controls.Add(this.operadorCmbBox);
            this.Controls.Add(this.num2TxtBox);
            this.Controls.Add(this.num1TxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCalculadora";
            this.Text = "Calculadora de Santiago Mosteiro del curso 2°D";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox num1TxtBox;
        private System.Windows.Forms.TextBox num2TxtBox;
        private System.Windows.Forms.ComboBox operadorCmbBox;
        private System.Windows.Forms.Button operarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button cerrarButton;
        private System.Windows.Forms.Button parseBinarioButton;
        private System.Windows.Forms.Button parseDecimalButton;
        private System.Windows.Forms.Label resultadoLabel;
    }
}

