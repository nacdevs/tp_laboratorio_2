namespace CorreoUTN
{
    partial class FrmPpal
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.direccionTxtBox = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.mostrarRTxtBox = new System.Windows.Forms.RichTextBox();
            this.ingresadoListBox = new System.Windows.Forms.ListBox();
            this.enViajeListBox = new System.Windows.Forms.ListBox();
            this.entregadoListBox = new System.Windows.Forms.ListBox();
            this.trackingIDTxtBox = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mostrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estado Paquetes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingresado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "En Viaje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(696, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Entregado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(742, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Paquete";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(742, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tracking ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(742, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Dirección";
            this.label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // direccionTxtBox
            // 
            this.direccionTxtBox.Location = new System.Drawing.Point(745, 416);
            this.direccionTxtBox.Name = "direccionTxtBox";
            this.direccionTxtBox.Size = new System.Drawing.Size(184, 20);
            this.direccionTxtBox.TabIndex = 10;
            this.direccionTxtBox.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(938, 363);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(97, 23);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(938, 413);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(97, 23);
            this.btnMostrarTodos.TabIndex = 13;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.BtnMostrarTodos_Click);
            // 
            // mostrarRTxtBox
            // 
            this.mostrarRTxtBox.Enabled = false;
            this.mostrarRTxtBox.Location = new System.Drawing.Point(12, 325);
            this.mostrarRTxtBox.Name = "mostrarRTxtBox";
            this.mostrarRTxtBox.Size = new System.Drawing.Size(668, 124);
            this.mostrarRTxtBox.TabIndex = 14;
            this.mostrarRTxtBox.Text = "";
            // 
            // ingresadoListBox
            // 
            this.ingresadoListBox.FormattingEnabled = true;
            this.ingresadoListBox.HorizontalScrollbar = true;
            this.ingresadoListBox.Location = new System.Drawing.Point(12, 63);
            this.ingresadoListBox.MultiColumn = true;
            this.ingresadoListBox.Name = "ingresadoListBox";
            this.ingresadoListBox.Size = new System.Drawing.Size(322, 225);
            this.ingresadoListBox.TabIndex = 15;
            // 
            // enViajeListBox
            // 
            this.enViajeListBox.FormattingEnabled = true;
            this.enViajeListBox.HorizontalScrollbar = true;
            this.enViajeListBox.Location = new System.Drawing.Point(351, 63);
            this.enViajeListBox.Name = "enViajeListBox";
            this.enViajeListBox.Size = new System.Drawing.Size(329, 225);
            this.enViajeListBox.TabIndex = 16;
            // 
            // entregadoListBox
            // 
            this.entregadoListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.entregadoListBox.FormattingEnabled = true;
            this.entregadoListBox.HorizontalScrollbar = true;
            this.entregadoListBox.Location = new System.Drawing.Point(699, 63);
            this.entregadoListBox.Name = "entregadoListBox";
            this.entregadoListBox.Size = new System.Drawing.Size(336, 225);
            this.entregadoListBox.TabIndex = 17;
            // 
            // trackingIDTxtBox
            // 
            this.trackingIDTxtBox.Location = new System.Drawing.Point(745, 365);
            this.trackingIDTxtBox.Mask = "00.000.000";
            this.trackingIDTxtBox.Name = "trackingIDTxtBox";
            this.trackingIDTxtBox.Size = new System.Drawing.Size(184, 20);
            this.trackingIDTxtBox.TabIndex = 18;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 26);
            // 
            // mostrarToolStripMenuItem
            // 
            this.mostrarToolStripMenuItem.Name = "mostrarToolStripMenuItem";
            this.mostrarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mostrarToolStripMenuItem.Text = "Mostrar";
            this.mostrarToolStripMenuItem.Click += new System.EventHandler(this.MostrarToolStripMenuItem_Click);
            // 
            // FrmPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 472);
            this.Controls.Add(this.trackingIDTxtBox);
            this.Controls.Add(this.entregadoListBox);
            this.Controls.Add(this.enViajeListBox);
            this.Controls.Add(this.ingresadoListBox);
            this.Controls.Add(this.mostrarRTxtBox);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.direccionTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPpal";
            this.Text = "Correo UTN por Nestor.Camela.2D";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPpal_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox direccionTxtBox;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.RichTextBox mostrarRTxtBox;
        private System.Windows.Forms.ListBox ingresadoListBox;
        private System.Windows.Forms.ListBox enViajeListBox;
        private System.Windows.Forms.ListBox entregadoListBox;
        private System.Windows.Forms.MaskedTextBox trackingIDTxtBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mostrarToolStripMenuItem;
    }
}

