﻿namespace TI_AED_SO_MODII
{
    partial class FormCicloExecucao
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
            this.components = new System.ComponentModel.Container();
            this.textBoxExecucaoCPU1 = new System.Windows.Forms.TextBox();
            this.textBoxExecucaoCPU2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxListaPronto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonEncerrar = new System.Windows.Forms.Button();
            this.TimerCiclo = new System.Windows.Forms.Timer(this.components);
            this.textBoxListaFinalizado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxExecucaoCPU1
            // 
            this.textBoxExecucaoCPU1.Location = new System.Drawing.Point(30, 37);
            this.textBoxExecucaoCPU1.Name = "textBoxExecucaoCPU1";
            this.textBoxExecucaoCPU1.ReadOnly = true;
            this.textBoxExecucaoCPU1.Size = new System.Drawing.Size(320, 20);
            this.textBoxExecucaoCPU1.TabIndex = 0;
            // 
            // textBoxExecucaoCPU2
            // 
            this.textBoxExecucaoCPU2.Location = new System.Drawing.Point(30, 89);
            this.textBoxExecucaoCPU2.Name = "textBoxExecucaoCPU2";
            this.textBoxExecucaoCPU2.ReadOnly = true;
            this.textBoxExecucaoCPU2.Size = new System.Drawing.Size(320, 20);
            this.textBoxExecucaoCPU2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "CPU 0 - Processo em execução:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CPU 1 - Processo em execução:";
            // 
            // textBoxListaPronto
            // 
            this.textBoxListaPronto.Location = new System.Drawing.Point(30, 151);
            this.textBoxListaPronto.Multiline = true;
            this.textBoxListaPronto.Name = "textBoxListaPronto";
            this.textBoxListaPronto.ReadOnly = true;
            this.textBoxListaPronto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxListaPronto.Size = new System.Drawing.Size(324, 278);
            this.textBoxListaPronto.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lista pronto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(437, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lista finalizado";
            // 
            // ButtonEncerrar
            // 
            this.ButtonEncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEncerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonEncerrar.Location = new System.Drawing.Point(545, 34);
            this.ButtonEncerrar.Name = "ButtonEncerrar";
            this.ButtonEncerrar.Size = new System.Drawing.Size(130, 23);
            this.ButtonEncerrar.TabIndex = 8;
            this.ButtonEncerrar.Text = "Encerrar";
            this.ButtonEncerrar.UseVisualStyleBackColor = true;
            this.ButtonEncerrar.Click += new System.EventHandler(this.ButtonEncerrar_Click);
            // 
            // TimerCiclo
            // 
            this.TimerCiclo.Enabled = true;
            this.TimerCiclo.Interval = 1000;
            this.TimerCiclo.Tick += new System.EventHandler(this.TimerCiclo_Tick);
            // 
            // textBoxListaFinalizado
            // 
            this.textBoxListaFinalizado.Location = new System.Drawing.Point(429, 151);
            this.textBoxListaFinalizado.Multiline = true;
            this.textBoxListaFinalizado.Name = "textBoxListaFinalizado";
            this.textBoxListaFinalizado.ReadOnly = true;
            this.textBoxListaFinalizado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxListaFinalizado.Size = new System.Drawing.Size(324, 278);
            this.textBoxListaFinalizado.TabIndex = 5;
            // 
            // FormCicloExecucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonEncerrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxListaFinalizado);
            this.Controls.Add(this.textBoxListaPronto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxExecucaoCPU2);
            this.Controls.Add(this.textBoxExecucaoCPU1);
            this.Name = "FormCicloExecucao";
            this.Text = "CicloExecucao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxExecucaoCPU2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxListaPronto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonEncerrar;
        private System.Windows.Forms.Timer TimerCiclo;
        internal System.Windows.Forms.TextBox textBoxExecucaoCPU1;
        private System.Windows.Forms.TextBox textBoxListaFinalizado;
    }
}