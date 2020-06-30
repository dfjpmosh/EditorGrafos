namespace EditorTest
{
    partial class Longitud
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
            this.label1 = new System.Windows.Forms.Label();
            this.textLon = new System.Windows.Forms.TextBox();
            this.aceptar = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Longitud:";
            // 
            // textLon
            // 
            this.textLon.Location = new System.Drawing.Point(24, 37);
            this.textLon.Name = "textLon";
            this.textLon.Size = new System.Drawing.Size(100, 20);
            this.textLon.TabIndex = 1;
            this.textLon.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // aceptar
            // 
            this.aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar.Location = new System.Drawing.Point(199, 73);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 2;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(12, 73);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // Longitud
            // 
            this.AcceptButton = this.aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(286, 108);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.textLon);
            this.Controls.Add(this.label1);
            this.Name = "Longitud";
            this.Text = "Ingresa la longitud del camino";
            this.Load += new System.EventHandler(this.Longitud_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textLon;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button cancel;
    }
}