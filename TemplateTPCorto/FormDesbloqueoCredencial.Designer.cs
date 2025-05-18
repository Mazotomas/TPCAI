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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(42, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desbloqueo Credencial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Introduzca el legajo a desbloquear:";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(71, 124);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(178, 22);
            this.txtLegajo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 3;
            // 
            // btnSolicitarAutorizacion
            // 
            this.btnSolicitarAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSolicitarAutorizacion.Location = new System.Drawing.Point(71, 172);
            this.btnSolicitarAutorizacion.Name = "btnSolicitarAutorizacion";
            this.btnSolicitarAutorizacion.Size = new System.Drawing.Size(178, 38);
            this.btnSolicitarAutorizacion.TabIndex = 5;
            this.btnSolicitarAutorizacion.Text = "Solicitar Autorizacion";
            this.btnSolicitarAutorizacion.UseVisualStyleBackColor = true;
            this.btnSolicitarAutorizacion.Click += new System.EventHandler(this.btnSolicitarAutorizacion_Click);
            // 
            // FormDesloqueoCredencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 233);
            this.Controls.Add(this.btnSolicitarAutorizacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDesloqueoCredencial";
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
    }
}