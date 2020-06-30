namespace EditorTest
{
    partial class CaminoVertices
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
            this.cancel = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.comboVertIni = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboVertFin = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(9, 89);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // aceptar
            // 
            this.aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.aceptar.Location = new System.Drawing.Point(137, 89);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 4;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // comboVertIni
            // 
            this.comboVertIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVertIni.FormattingEnabled = true;
            this.comboVertIni.Location = new System.Drawing.Point(15, 37);
            this.comboVertIni.Name = "comboVertIni";
            this.comboVertIni.Size = new System.Drawing.Size(74, 21);
            this.comboVertIni.TabIndex = 6;
            this.comboVertIni.SelectedIndexChanged += new System.EventHandler(this.comboVertIni_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Vertice inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vertice final";
            // 
            // comboVertFin
            // 
            this.comboVertFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVertFin.FormattingEnabled = true;
            this.comboVertFin.Location = new System.Drawing.Point(134, 37);
            this.comboVertFin.Name = "comboVertFin";
            this.comboVertFin.Size = new System.Drawing.Size(74, 21);
            this.comboVertFin.TabIndex = 8;
            this.comboVertFin.SelectedIndexChanged += new System.EventHandler(this.comboVertFin_SelectedIndexChanged);
            // 
            // CaminoVertices
            // 
            this.AcceptButton = this.aceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(223, 129);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboVertFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboVertIni);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.aceptar);
            this.Name = "CaminoVertices";
            this.Text = "Vertices";
            this.Load += new System.EventHandler(this.CaminoVertices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboVertFin;
        private System.Windows.Forms.ComboBox comboVertIni;
    }
}