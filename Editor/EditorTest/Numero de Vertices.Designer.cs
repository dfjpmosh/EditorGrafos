namespace EditorTest
{
    partial class Numero_de_Vertices
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
            this.NumVertLabel = new System.Windows.Forms.Label();
            this.verticesLabel = new System.Windows.Forms.Label();
            this.aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumVertLabel
            // 
            this.NumVertLabel.AutoSize = true;
            this.NumVertLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumVertLabel.Location = new System.Drawing.Point(12, 21);
            this.NumVertLabel.Name = "NumVertLabel";
            this.NumVertLabel.Size = new System.Drawing.Size(118, 13);
            this.NumVertLabel.TabIndex = 0;
            this.NumVertLabel.Text = "Numero de Vetices:";
            // 
            // verticesLabel
            // 
            this.verticesLabel.AutoSize = true;
            this.verticesLabel.Location = new System.Drawing.Point(136, 21);
            this.verticesLabel.Name = "verticesLabel";
            this.verticesLabel.Size = new System.Drawing.Size(0, 13);
            this.verticesLabel.TabIndex = 1;
            // 
            // aceptar
            // 
            this.aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar.Location = new System.Drawing.Point(167, 91);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 2;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            // 
            // Numero_de_Vertices
            // 
            this.AcceptButton = this.aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 126);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.verticesLabel);
            this.Controls.Add(this.NumVertLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 164);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(270, 164);
            this.Name = "Numero_de_Vertices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Numero de Vertices";
            this.Load += new System.EventHandler(this.Numero_de_Vertices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumVertLabel;
        private System.Windows.Forms.Label verticesLabel;
        private System.Windows.Forms.Button aceptar;
    }
}