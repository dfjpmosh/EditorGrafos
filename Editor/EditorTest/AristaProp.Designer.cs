namespace EditorTest
{
    partial class AristaProp
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pesoAristaUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.botonAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pesoAristaUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pesoAristaUpDown
            // 
            this.pesoAristaUpDown.Location = new System.Drawing.Point(66, 40);
            this.pesoAristaUpDown.Name = "pesoAristaUpDown";
            this.pesoAristaUpDown.Size = new System.Drawing.Size(67, 20);
            this.pesoAristaUpDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecciona el peso de la arista";
            // 
            // botonAceptar
            // 
            this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonAceptar.Location = new System.Drawing.Point(62, 71);
            this.botonAceptar.Name = "botonAceptar";
            this.botonAceptar.Size = new System.Drawing.Size(75, 23);
            this.botonAceptar.TabIndex = 3;
            this.botonAceptar.Text = "Aceptar";
            this.botonAceptar.UseVisualStyleBackColor = true;
            this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
            // 
            // AristaProp
            // 
            this.AcceptButton = this.botonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 106);
            this.Controls.Add(this.botonAceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pesoAristaUpDown);
            this.Name = "AristaProp";
            this.Text = "AristaProp";
            ((System.ComponentModel.ISupportInitialize)(this.pesoAristaUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown pesoAristaUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonAceptar;
    }
}