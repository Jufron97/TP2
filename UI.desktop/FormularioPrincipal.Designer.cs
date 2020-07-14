namespace Academia.UI.Desktop
{
    partial class FormularioPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textoFormularioPrincipal = new System.Windows.Forms.Label();
            this.imgNet = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(421, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem1,
            this.listadoGeneralToolStripMenuItem});
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.loginToolStripMenuItem.Text = "Archivo";
            // 
            // loginToolStripMenuItem1
            // 
            this.loginToolStripMenuItem1.Name = "loginToolStripMenuItem1";
            this.loginToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.loginToolStripMenuItem1.Text = "Login";
            this.loginToolStripMenuItem1.Click += new System.EventHandler(this.loginToolStripMenuItem1_Click);
            // 
            // listadoGeneralToolStripMenuItem
            // 
            this.listadoGeneralToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.especialidadesToolStripMenuItem});
            this.listadoGeneralToolStripMenuItem.Name = "listadoGeneralToolStripMenuItem";
            this.listadoGeneralToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listadoGeneralToolStripMenuItem.Text = "ABM";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.especialidadesToolStripMenuItem.Text = "Especialidades";
            this.especialidadesToolStripMenuItem.Click += new System.EventHandler(this.especialidadesToolStripMenuItem_Click);
            // 
            // textoFormularioPrincipal
            // 
            this.textoFormularioPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textoFormularioPrincipal.AutoSize = true;
            this.textoFormularioPrincipal.Location = new System.Drawing.Point(103, 52);
            this.textoFormularioPrincipal.Name = "textoFormularioPrincipal";
            this.textoFormularioPrincipal.Size = new System.Drawing.Size(206, 52);
            this.textoFormularioPrincipal.TabIndex = 1;
            this.textoFormularioPrincipal.Text = "               ¡Bienvenido al Sistema!\r\nUsted esta navegando en la App. del TP2\r\n" +
    "\r\n\r\n";
            // 
            // imgNet
            // 
            this.imgNet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgNet.Image = ((System.Drawing.Image)(resources.GetObject("imgNet.Image")));
            this.imgNet.Location = new System.Drawing.Point(12, 146);
            this.imgNet.Name = "imgNet";
            this.imgNet.Size = new System.Drawing.Size(117, 102);
            this.imgNet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgNet.TabIndex = 2;
            this.imgNet.TabStop = false;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 260);
            this.Controls.Add(this.imgNet);
            this.Controls.Add(this.textoFormularioPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormularioPrincipal";
            this.Text = "FormularioPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgNet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listadoGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.Label textoFormularioPrincipal;
        private System.Windows.Forms.PictureBox imgNet;
    }
}