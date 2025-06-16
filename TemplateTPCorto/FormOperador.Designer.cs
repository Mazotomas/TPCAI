namespace TemplateTPCorto
{
    partial class FormOperador
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCambioClave = new System.Windows.Forms.Button();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "PORTAL OPERADOR";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Elija una opcion:";
            // 
            // BtnCambioClave
            // 
            this.BtnCambioClave.Location = new System.Drawing.Point(65, 219);
            this.BtnCambioClave.Name = "BtnCambioClave";
            this.BtnCambioClave.Size = new System.Drawing.Size(183, 47);
            this.BtnCambioClave.TabIndex = 2;
            this.BtnCambioClave.Text = "Cambiar contraseña";
            this.BtnCambioClave.UseVisualStyleBackColor = true;
            this.BtnCambioClave.Click += new System.EventHandler(this.BtnCambioClave_Click);
            // 
            // BtnSiguiente
            // 
            this.BtnSiguiente.Location = new System.Drawing.Point(65, 148);
            this.BtnSiguiente.Name = "BtnSiguiente";
            this.BtnSiguiente.Size = new System.Drawing.Size(183, 47);
            this.BtnSiguiente.TabIndex = 3;
            this.BtnSiguiente.Text = "Cargar Ventas";
            this.BtnSiguiente.UseVisualStyleBackColor = true;
            this.BtnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // FormOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 286);
            this.Controls.Add(this.BtnSiguiente);
            this.Controls.Add(this.BtnCambioClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormOperador";
            this.Text = "Operador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCambioClave;
        private System.Windows.Forms.Button BtnSiguiente;
    }
}