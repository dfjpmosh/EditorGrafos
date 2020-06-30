namespace EditorTest
{
    partial class Datos
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
            this.Pantalla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textPantalla = new System.Windows.Forms.TextBox();
            this.textRelleno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RellenoVertice = new System.Windows.Forms.Button();
            this.textCVert = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ContornoVertice = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textAContorno = new System.Windows.Forms.TextBox();
            this.AnchoContorno = new System.Windows.Forms.TrackBar();
            this.Diametro = new System.Windows.Forms.TrackBar();
            this.textDiametro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.CheckBox();
            this.letra = new System.Windows.Forms.CheckBox();
            this.AnchoLinea = new System.Windows.Forms.TrackBar();
            this.textAnchoArista = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textColorArista = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Arista = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AnchoContorno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Diametro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnchoLinea)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pantalla";
            // 
            // Pantalla
            // 
            this.Pantalla.Location = new System.Drawing.Point(247, 45);
            this.Pantalla.Name = "Pantalla";
            this.Pantalla.Size = new System.Drawing.Size(85, 23);
            this.Pantalla.TabIndex = 2;
            this.Pantalla.Text = "Cambiar Color";
            this.Pantalla.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vertice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Color Fondo";
            // 
            // textPantalla
            // 
            this.textPantalla.Location = new System.Drawing.Point(106, 45);
            this.textPantalla.Name = "textPantalla";
            this.textPantalla.Size = new System.Drawing.Size(98, 20);
            this.textPantalla.TabIndex = 8;
            // 
            // textRelleno
            // 
            this.textRelleno.Location = new System.Drawing.Point(130, 98);
            this.textRelleno.Name = "textRelleno";
            this.textRelleno.Size = new System.Drawing.Size(98, 20);
            this.textRelleno.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Color Relleno Vertice";
            // 
            // RellenoVertice
            // 
            this.RellenoVertice.Location = new System.Drawing.Point(247, 98);
            this.RellenoVertice.Name = "RellenoVertice";
            this.RellenoVertice.Size = new System.Drawing.Size(94, 23);
            this.RellenoVertice.TabIndex = 9;
            this.RellenoVertice.Text = "Cambiar Relleno ";
            this.RellenoVertice.UseVisualStyleBackColor = true;
            // 
            // textCVert
            // 
            this.textCVert.Location = new System.Drawing.Point(137, 134);
            this.textCVert.Name = "textCVert";
            this.textCVert.Size = new System.Drawing.Size(98, 20);
            this.textCVert.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Color Contorno Vertice";
            // 
            // ContornoVertice
            // 
            this.ContornoVertice.Location = new System.Drawing.Point(247, 134);
            this.ContornoVertice.Name = "ContornoVertice";
            this.ContornoVertice.Size = new System.Drawing.Size(103, 23);
            this.ContornoVertice.TabIndex = 12;
            this.ContornoVertice.Text = "Cambiar Contorno";
            this.ContornoVertice.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ancho Contorno";
            // 
            // textAContorno
            // 
            this.textAContorno.Location = new System.Drawing.Point(108, 174);
            this.textAContorno.Name = "textAContorno";
            this.textAContorno.Size = new System.Drawing.Size(98, 20);
            this.textAContorno.TabIndex = 17;
            // 
            // AnchoContorno
            // 
            this.AnchoContorno.Location = new System.Drawing.Point(237, 174);
            this.AnchoContorno.Minimum = 1;
            this.AnchoContorno.Name = "AnchoContorno";
            this.AnchoContorno.Size = new System.Drawing.Size(104, 45);
            this.AnchoContorno.TabIndex = 18;
            this.AnchoContorno.Value = 1;
            // 
            // Diametro
            // 
            this.Diametro.Location = new System.Drawing.Point(237, 206);
            this.Diametro.Maximum = 100;
            this.Diametro.Minimum = 20;
            this.Diametro.Name = "Diametro";
            this.Diametro.Size = new System.Drawing.Size(104, 45);
            this.Diametro.TabIndex = 21;
            this.Diametro.Value = 20;
            // 
            // textDiametro
            // 
            this.textDiametro.AcceptsReturn = true;
            this.textDiametro.Location = new System.Drawing.Point(108, 206);
            this.textDiametro.Name = "textDiametro";
            this.textDiametro.Size = new System.Drawing.Size(98, 20);
            this.textDiametro.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Diametro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Tipo de Id";
            // 
            // numero
            // 
            this.numero.AutoSize = true;
            this.numero.Location = new System.Drawing.Point(94, 238);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(53, 17);
            this.numero.TabIndex = 23;
            this.numero.Text = "Digito";
            this.numero.UseVisualStyleBackColor = true;
            // 
            // letra
            // 
            this.letra.AutoSize = true;
            this.letra.Location = new System.Drawing.Point(192, 239);
            this.letra.Name = "letra";
            this.letra.Size = new System.Drawing.Size(50, 17);
            this.letra.TabIndex = 24;
            this.letra.Text = "Letra";
            this.letra.UseVisualStyleBackColor = true;
            // 
            // AnchoLinea
            // 
            this.AnchoLinea.Location = new System.Drawing.Point(237, 335);
            this.AnchoLinea.Minimum = 1;
            this.AnchoLinea.Name = "AnchoLinea";
            this.AnchoLinea.Size = new System.Drawing.Size(104, 45);
            this.AnchoLinea.TabIndex = 34;
            this.AnchoLinea.Value = 1;
            // 
            // textAnchoArista
            // 
            this.textAnchoArista.Location = new System.Drawing.Point(108, 335);
            this.textAnchoArista.Name = "textAnchoArista";
            this.textAnchoArista.Size = new System.Drawing.Size(98, 20);
            this.textAnchoArista.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Ancho Linea";
            // 
            // textColorArista
            // 
            this.textColorArista.Location = new System.Drawing.Point(108, 302);
            this.textColorArista.Name = "textColorArista";
            this.textColorArista.Size = new System.Drawing.Size(98, 20);
            this.textColorArista.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 302);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Color Arista";
            // 
            // Arista
            // 
            this.Arista.Location = new System.Drawing.Point(247, 300);
            this.Arista.Name = "Arista";
            this.Arista.Size = new System.Drawing.Size(94, 23);
            this.Arista.TabIndex = 26;
            this.Arista.Text = "Cambiar Color";
            this.Arista.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Arista";
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(366, 396);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 36;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(486, 396);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 37;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // Datos
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(573, 431);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.AnchoLinea);
            this.Controls.Add(this.textAnchoArista);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textColorArista);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Arista);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.letra);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Diametro);
            this.Controls.Add(this.textDiametro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AnchoContorno);
            this.Controls.Add(this.textAContorno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textCVert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ContornoVertice);
            this.Controls.Add(this.textRelleno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RellenoVertice);
            this.Controls.Add(this.textPantalla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Pantalla);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(589, 469);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(589, 469);
            this.Name = "Datos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos";
            this.Load += new System.EventHandler(this.Datos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnchoContorno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Diametro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnchoLinea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Pantalla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPantalla;
        private System.Windows.Forms.TextBox textRelleno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RellenoVertice;
        private System.Windows.Forms.TextBox textCVert;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ContornoVertice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAContorno;
        private System.Windows.Forms.TrackBar AnchoContorno;
        private System.Windows.Forms.TrackBar Diametro;
        private System.Windows.Forms.TextBox textDiametro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox numero;
        private System.Windows.Forms.CheckBox letra;
        private System.Windows.Forms.TrackBar AnchoLinea;
        private System.Windows.Forms.TextBox textAnchoArista;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textColorArista;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Arista;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}