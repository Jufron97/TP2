namespace Academia.UI.Desktop
{
    partial class formLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLetrero = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lnkOlvidoPass = new System.Windows.Forms.LinkLabel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLetrero
            // 
            this.lblLetrero.AutoSize = true;
            this.lblLetrero.Location = new System.Drawing.Point(145, 34);
            this.lblLetrero.Name = "lblLetrero";
            this.lblLetrero.Size = new System.Drawing.Size(202, 52);
            this.lblLetrero.TabIndex = 0;
            this.lblLetrero.Text = "¡Bienvenido al Sistema!\r\nPor favor digite su información de Ingreso\r\n\r\n\r\n";
            this.lblLetrero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(120, 92);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(104, 13);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Nombre de Usuario :";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(145, 128);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(67, 13);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Contraseña :";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(247, 89);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(247, 125);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(100, 20);
            this.txtContraseña.TabIndex = 4;
            // 
            // lnkOlvidoPass
            // 
            this.lnkOlvidoPass.AutoSize = true;
            this.lnkOlvidoPass.Location = new System.Drawing.Point(12, 256);
            this.lnkOlvidoPass.Name = "lnkOlvidoPass";
            this.lnkOlvidoPass.Size = new System.Drawing.Size(106, 13);
            this.lnkOlvidoPass.TabIndex = 5;
            this.lnkOlvidoPass.TabStop = true;
            this.lnkOlvidoPass.Text = "Olvide mi contraseña";
            this.lnkOlvidoPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOlvidoPass_LinkClicked);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(199, 174);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // formLogin
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 278);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lnkOlvidoPass);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblLetrero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingreso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLetrero;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.LinkLabel lnkOlvidoPass;
        private System.Windows.Forms.Button btnIngresar;
    }
}

