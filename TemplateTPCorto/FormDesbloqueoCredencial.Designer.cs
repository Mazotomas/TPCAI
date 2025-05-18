namespace TemplateTPCorto
{
    partial class FormDesbloqueoCredencial
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
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSolicitarAutorizacion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNuevaContraseña = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desbloqueo Credencial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Introduzca el legajo a desbloquear:";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(63, 90);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(134, 20);
            this.txtLegajo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 3;
            // 
            // btnSolicitarAutorizacion
            // 
            this.btnSolicitarAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSolicitarAutorizacion.Location = new System.Drawing.Point(63, 203);
            this.btnSolicitarAutorizacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSolicitarAutorizacion.Name = "btnSolicitarAutorizacion";
            this.btnSolicitarAutorizacion.Size = new System.Drawing.Size(134, 31);
            this.btnSolicitarAutorizacion.TabIndex = 5;
            this.btnSolicitarAutorizacion.Text = "Solicitar Autorizacion";
            this.btnSolicitarAutorizacion.UseVisualStyleBackColor = true;
            this.btnSolicitarAutorizacion.Click += new System.EventHandler(this.btnSolicitarAutorizacion_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nueva contraseña:";
            // 
            // txtNuevaContraseña
            // 
            this.txtNuevaContraseña.Location = new System.Drawing.Point(63, 160);
            this.txtNuevaContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtNuevaContraseña.Name = "txtNuevaContraseña";
            this.txtNuevaContraseña.Size = new System.Drawing.Size(134, 20);
            this.txtNuevaContraseña.TabIndex = 7;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(85, 256);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormDesbloqueoCredencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 294);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtNuevaContraseña);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSolicitarAutorizacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDesbloqueoCredencial";
            this.Text = "Desbloquear Credencial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSolicitarAutorizacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNuevaContraseña;
        private System.Windows.Forms.Button btnVolver;
    }
}