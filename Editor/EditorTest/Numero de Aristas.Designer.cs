namespace EditorTest
{
    partial class Numero_de_Aristas
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
            this.aceptar = new System.Windows.Forms.Button();
            this.aristasLabel = new System.Windows.Forms.Label();
            this.NumAriLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aceptar
            // 
            this.aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar.Location = new System.Drawing.Point(167, 91);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 3;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            // 
            // aristasLabel
            // 
            this.aristasLabel.AutoSize = true;
            this.aristasLabel.Location = new System.Drawing.Point(164, 31);
            this.aristasLabel.Name = "aristasLabel";
            this.aristasLabel.Size = new System.Drawing.Size(0, 13);
            this.aristasLabel.TabIndex = 5;
            // 
            // NumAriLabel
            // 
            this.NumAriLabel.AutoSize = true;
            this.NumAriLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumAriLabel.Location = new System.Drawing.Point(24, 31);
            this.NumAriLabel.Name = "NumAriLabel";
            this.NumAriLabel.Size = new System.Drawing.Size(114, 13);
            this.NumAriLabel.TabIndex = 4;
            this.NumAriLabel.Text = "Numero de Aristas:";
            // 
            // Numero_de_Aristas
            // 
            this.AcceptButton = this.aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 126);
            this.Controls.Add(this.aristasLabel);
            this.Controls.Add(this.NumAriLabel);
            this.Controls.Add(this.aceptar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 164);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(270, 164);
            this.Name = "Numero_de_Aristas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Numero_de_Aristas";
            this.Load += new System.EventHandler(this.Numero_de_Aristas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label aristasLabel;
        private System.Windows.Forms.Label NumAriLabel;
    }
}