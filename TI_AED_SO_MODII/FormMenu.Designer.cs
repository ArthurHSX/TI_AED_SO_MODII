namespace TI_AED_SO_MODII
{
    partial class FormMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.IniciaCiclo = new System.Windows.Forms.Button();
            this.ModificaPrioridade = new System.Windows.Forms.Button();
            this.Encerrar = new System.Windows.Forms.Button();
            this.SuspendeResume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IniciaCiclo
            // 
            this.IniciaCiclo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IniciaCiclo.Location = new System.Drawing.Point(35, 44);
            this.IniciaCiclo.Name = "IniciaCiclo";
            this.IniciaCiclo.Size = new System.Drawing.Size(250, 50);
            this.IniciaCiclo.TabIndex = 0;
            this.IniciaCiclo.Text = "Iniciar um novo ciclo";
            this.IniciaCiclo.UseVisualStyleBackColor = true;
            this.IniciaCiclo.Click += new System.EventHandler(this.IniciaCiclo_Click);
            // 
            // ModificaPrioridade
            // 
            this.ModificaPrioridade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificaPrioridade.Location = new System.Drawing.Point(35, 113);
            this.ModificaPrioridade.Name = "ModificaPrioridade";
            this.ModificaPrioridade.Size = new System.Drawing.Size(250, 50);
            this.ModificaPrioridade.TabIndex = 1;
            this.ModificaPrioridade.Text = "Modificar uma prioridade";
            this.ModificaPrioridade.UseVisualStyleBackColor = true;
            this.ModificaPrioridade.Click += new System.EventHandler(this.ModificaPrioridade_Click);
            // 
            // Encerrar
            // 
            this.Encerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Encerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Encerrar.Location = new System.Drawing.Point(35, 247);
            this.Encerrar.Name = "Encerrar";
            this.Encerrar.Size = new System.Drawing.Size(250, 50);
            this.Encerrar.TabIndex = 2;
            this.Encerrar.Text = "Encerrar";
            this.Encerrar.UseVisualStyleBackColor = true;
            // 
            // SuspendeResume
            // 
            this.SuspendeResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuspendeResume.Location = new System.Drawing.Point(35, 180);
            this.SuspendeResume.Name = "SuspendeResume";
            this.SuspendeResume.Size = new System.Drawing.Size(250, 50);
            this.SuspendeResume.TabIndex = 3;
            this.SuspendeResume.Text = "Suspender ou resumir";
            this.SuspendeResume.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 442);
            this.Controls.Add(this.SuspendeResume);
            this.Controls.Add(this.Encerrar);
            this.Controls.Add(this.ModificaPrioridade);
            this.Controls.Add(this.IniciaCiclo);
            this.Name = "FormMenu";
            this.Text = "Menu Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button IniciaCiclo;
        private System.Windows.Forms.Button ModificaPrioridade;
        private System.Windows.Forms.Button Encerrar;
        private System.Windows.Forms.Button SuspendeResume;
    }
}

