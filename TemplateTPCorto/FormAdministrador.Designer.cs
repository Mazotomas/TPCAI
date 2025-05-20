namespace TemplateTPCorto
{
    partial class FormAdministrador
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
            this.listCambios = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listDesbloqueo = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAutorizarCambios = new System.Windows.Forms.Button();
            this.btnCambioClavePropia = new System.Windows.Forms.Button();
            this.btnAutorizarDesbloq = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listCambios
            // 
            this.listCambios.FormattingEnabled = true;
            this.listCambios.HorizontalScrollbar = true;
            this.listCambios.ItemHeight = 16;
            this.listCambios.Location = new System.Drawing.Point(31, 97);
            this.listCambios.Name = "listCambios";
            this.listCambios.ScrollAlwaysVisible = true;
            this.listCambios.Size = new System.Drawing.Size(353, 132);
            this.listCambios.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(265, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Portal de Administrador";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listDesbloqueo
            // 
            this.listDesbloqueo.FormattingEnabled = true;
            this.listDesbloqueo.HorizontalScrollbar = true;
            this.listDesbloqueo.ItemHeight = 16;
            this.listDesbloqueo.Location = new System.Drawing.Point(418, 97);
            this.listDesbloqueo.Name = "listDesbloqueo";
            this.listDesbloqueo.ScrollAlwaysVisible = true;
            this.listDesbloqueo.Size = new System.Drawing.Size(353, 132);
            this.listDesbloqueo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Listado de cambios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Listado de desbloqueos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(331, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sobre su cuenta:";
            // 
            // btnAutorizarCambios
            // 
            this.btnAutorizarCambios.Location = new System.Drawing.Point(117, 247);
            this.btnAutorizarCambios.Name = "btnAutorizarCambios";
            this.btnAutorizarCambios.Size = new System.Drawing.Size(165, 23);
            this.btnAutorizarCambios.TabIndex = 6;
            this.btnAutorizarCambios.Text = "Autorizar cambios";
            this.btnAutorizarCambios.UseVisualStyleBackColor = true;
            this.btnAutorizarCambios.Click += new System.EventHandler(this.btnAutorizarCambios_Click);
            // 
            // btnCambioClavePropia
            // 
            this.btnCambioClavePropia.Location = new System.Drawing.Point(318, 364);
            this.btnCambioClavePropia.Name = "btnCambioClavePropia";
            this.btnCambioClavePropia.Size = new System.Drawing.Size(162, 23);
            this.btnCambioClavePropia.TabIndex = 7;
            this.btnCambioClavePropia.Text = "Cambiar contraseña";
            this.btnCambioClavePropia.UseVisualStyleBackColor = true;
            this.btnCambioClavePropia.Click += new System.EventHandler(this.btnCambioClavePropia_Click);
            // 
            // btnAutorizarDesbloq
            // 
            this.btnAutorizarDesbloq.Location = new System.Drawing.Point(527, 247);
            this.btnAutorizarDesbloq.Name = "btnAutorizarDesbloq";
            this.btnAutorizarDesbloq.Size = new System.Drawing.Size(165, 23);
            this.btnAutorizarDesbloq.TabIndex = 8;
            this.btnAutorizarDesbloq.Text = "Autorizar desbloqueo";
            this.btnAutorizarDesbloq.UseVisualStyleBackColor = true;
            this.btnAutorizarDesbloq.Click += new System.EventHandler(this.btnAutorizarDesbloq_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(327, 281);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(153, 23);
            this.btnActualizar.TabIndex = 9;
            this.btnActualizar.Text = "Actualizar Listados";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 399);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnAutorizarDesbloq);
            this.Controls.Add(this.btnCambioClavePropia);
            this.Controls.Add(this.btnAutorizarCambios);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listDesbloqueo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listCambios);
            this.Name = "FormAdministrador";
            this.Text = "Administrador";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormAdministrador_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listCambios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listDesbloqueo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAutorizarCambios;
        private System.Windows.Forms.Button btnCambioClavePropia;
        private System.Windows.Forms.Button btnAutorizarDesbloq;
        private System.Windows.Forms.Button btnActualizar;
    }
}