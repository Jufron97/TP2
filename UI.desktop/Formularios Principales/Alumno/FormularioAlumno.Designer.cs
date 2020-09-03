namespace Academia.UI.Desktop
{
    partial class FormularioAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioAlumno));
            this.btnVisualizarCursos = new System.Windows.Forms.Button();
            this.btnInscripcionCursos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblNombreyApellido = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.pnlAlumno = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlAlumno.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVisualizarCursos
            // 
            this.btnVisualizarCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizarCursos.Location = new System.Drawing.Point(292, 104);
            this.btnVisualizarCursos.Name = "btnVisualizarCursos";
            this.btnVisualizarCursos.Size = new System.Drawing.Size(237, 33);
            this.btnVisualizarCursos.TabIndex = 0;
            this.btnVisualizarCursos.Text = "Visualizar Cursos";
            this.btnVisualizarCursos.UseVisualStyleBackColor = true;
            this.btnVisualizarCursos.Click += new System.EventHandler(this.btnVisualizarCursos_Click);
            // 
            // btnInscripcionCursos
            // 
            this.btnInscripcionCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscripcionCursos.Location = new System.Drawing.Point(292, 182);
            this.btnInscripcionCursos.Name = "btnInscripcionCursos";
            this.btnInscripcionCursos.Size = new System.Drawing.Size(237, 33);
            this.btnInscripcionCursos.TabIndex = 1;
            this.btnInscripcionCursos.Text = "Inscripción a Cursos";
            this.btnInscripcionCursos.UseVisualStyleBackColor = true;
            this.btnInscripcionCursos.Click += new System.EventHandler(this.btnInscripcionCursos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSalir.Location = new System.Drawing.Point(12, 329);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Cerrar Sesion";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblNombreyApellido
            // 
            this.lblNombreyApellido.AutoSize = true;
            this.lblNombreyApellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombreyApellido.Location = new System.Drawing.Point(94, 23);
            this.lblNombreyApellido.Name = "lblNombreyApellido";
            this.lblNombreyApellido.Size = new System.Drawing.Size(86, 13);
            this.lblNombreyApellido.TabIndex = 3;
            this.lblNombreyApellido.Text = "nombreYApellido";
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLegajo.Location = new System.Drawing.Point(104, 56);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(35, 13);
            this.lblLegajo.TabIndex = 4;
            this.lblLegajo.Text = "legajo";
            // 
            // pnlAlumno
            // 
            this.pnlAlumno.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pnlAlumno.Controls.Add(this.panel1);
            this.pnlAlumno.Controls.Add(this.btnSalir);
            this.pnlAlumno.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAlumno.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.pnlAlumno.Location = new System.Drawing.Point(0, 0);
            this.pnlAlumno.Name = "pnlAlumno";
            this.pnlAlumno.Size = new System.Drawing.Size(200, 364);
            this.pnlAlumno.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblNombreyApellido);
            this.panel1.Controls.Add(this.lblLegajo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormularioAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 364);
            this.Controls.Add(this.pnlAlumno);
            this.Controls.Add(this.btnInscripcionCursos);
            this.Controls.Add(this.btnVisualizarCursos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormularioAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioAlumno";
            this.pnlAlumno.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVisualizarCursos;
        private System.Windows.Forms.Button btnInscripcionCursos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblNombreyApellido;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Panel pnlAlumno;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}