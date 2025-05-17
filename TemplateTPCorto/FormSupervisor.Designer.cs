namespace TemplateTPCorto
{
    partial class FormSupervisor
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
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnDesbloquear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCambioClave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(41, 140);
            this.BtnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(203, 46);
            this.BtnModificar.TabIndex = 0;
            this.BtnModificar.Text = "Modificar Persona";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnDesbloquear
            // 
            this.BtnDesbloquear.Location = new System.Drawing.Point(41, 214);
            this.BtnDesbloquear.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDesbloquear.Name = "BtnDesbloquear";
            this.BtnDesbloquear.Size = new System.Drawing.Size(203, 46);
            this.BtnDesbloquear.TabIndex = 1;
            this.BtnDesbloquear.Text = "Desbloquear Credencial";
            this.BtnDesbloquear.UseVisualStyleBackColor = true;
            this.BtnDesbloquear.Click += new System.EventHandler(this.BtnDesbloquear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Portal Supervisor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elija una opción:";
            // 
            // BtnCambioClave
            // 
            this.BtnCambioClave.Location = new System.Drawing.Point(47, 370);
            this.BtnCambioClave.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCambioClave.Name = "BtnCambioClave";
            this.BtnCambioClave.Size = new System.Drawing.Size(179, 28);
            this.BtnCambioClave.TabIndex = 4;
            this.BtnCambioClave.Text = "Cambiar contraseña";
            this.BtnCambioClave.UseVisualStyleBackColor = true;
            this.BtnCambioClave.Click += new System.EventHandler(this.BtnCambioClave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sobre su cuenta:";
            // 
            // FormSupervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 425);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCambioClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDesbloquear);
            this.Controls.Add(this.BtnModificar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSupervisor";
            this.Text = "Supervisor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnDesbloquear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCambioClave;
        private System.Windows.Forms.Label label3;
    }
}