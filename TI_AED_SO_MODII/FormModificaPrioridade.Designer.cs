namespace TI_AED_SO_MODII
{
    partial class FormModificaPrioridade
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
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxProcesso = new System.Windows.Forms.TextBox();
            this.labelProcesso = new System.Windows.Forms.Label();
            this.labelPrioridade = new System.Windows.Forms.Label();
            this.textBoxPrioridade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxListaProcesso = new System.Windows.Forms.TextBox();
            this.butaoPesquisar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Informe o ID do processo:";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(12, 32);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(63, 20);
            this.textBoxID.TabIndex = 2;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // textBoxProcesso
            // 
            this.textBoxProcesso.Location = new System.Drawing.Point(12, 87);
            this.textBoxProcesso.Multiline = true;
            this.textBoxProcesso.Name = "textBoxProcesso";
            this.textBoxProcesso.ReadOnly = true;
            this.textBoxProcesso.Size = new System.Drawing.Size(300, 92);
            this.textBoxProcesso.TabIndex = 3;
            this.textBoxProcesso.Visible = false;
            // 
            // labelProcesso
            // 
            this.labelProcesso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelProcesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProcesso.Location = new System.Drawing.Point(12, 64);
            this.labelProcesso.Name = "labelProcesso";
            this.labelProcesso.Size = new System.Drawing.Size(132, 20);
            this.labelProcesso.TabIndex = 4;
            this.labelProcesso.Text = "Processo:";
            this.labelProcesso.Visible = false;
            // 
            // labelPrioridade
            // 
            this.labelPrioridade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPrioridade.Enabled = false;
            this.labelPrioridade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrioridade.Location = new System.Drawing.Point(12, 9);
            this.labelPrioridade.Name = "labelPrioridade";
            this.labelPrioridade.Size = new System.Drawing.Size(152, 20);
            this.labelPrioridade.TabIndex = 5;
            this.labelPrioridade.Text = "Informe a prioridade desejada:";
            this.labelPrioridade.Visible = false;
            // 
            // textBoxPrioridade
            // 
            this.textBoxPrioridade.Enabled = false;
            this.textBoxPrioridade.Location = new System.Drawing.Point(12, 32);
            this.textBoxPrioridade.Name = "textBoxPrioridade";
            this.textBoxPrioridade.Size = new System.Drawing.Size(63, 20);
            this.textBoxPrioridade.TabIndex = 6;
            this.textBoxPrioridade.Visible = false;
            this.textBoxPrioridade.TextChanged += new System.EventHandler(this.textBoxPrioridade_TextChanged);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lista de processos:";
            // 
            // textBoxListaProcesso
            // 
            this.textBoxListaProcesso.Location = new System.Drawing.Point(12, 185);
            this.textBoxListaProcesso.Multiline = true;
            this.textBoxListaProcesso.Name = "textBoxListaProcesso";
            this.textBoxListaProcesso.ReadOnly = true;
            this.textBoxListaProcesso.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxListaProcesso.Size = new System.Drawing.Size(300, 245);
            this.textBoxListaProcesso.TabIndex = 8;
            this.textBoxListaProcesso.Text = " ";
            // 
            // butaoPesquisar
            // 
            this.butaoPesquisar.Location = new System.Drawing.Point(126, 33);
            this.butaoPesquisar.Name = "butaoPesquisar";
            this.butaoPesquisar.Size = new System.Drawing.Size(72, 20);
            this.butaoPesquisar.TabIndex = 9;
            this.butaoPesquisar.Text = "Pesquisar";
            this.butaoPesquisar.UseVisualStyleBackColor = true;
            this.butaoPesquisar.Click += new System.EventHandler(this.butaoPesquisar_Click);
            // 
            // FormModificaPrioridade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 442);
            this.Controls.Add(this.butaoPesquisar);
            this.Controls.Add(this.textBoxListaProcesso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPrioridade);
            this.Controls.Add(this.labelPrioridade);
            this.Controls.Add(this.labelProcesso);
            this.Controls.Add(this.textBoxProcesso);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormModificaPrioridade";
            this.Text = "FormModificaPrioridade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxProcesso;
        private System.Windows.Forms.Label labelProcesso;
        private System.Windows.Forms.Label labelPrioridade;
        private System.Windows.Forms.TextBox textBoxPrioridade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxListaProcesso;
        private System.Windows.Forms.Button butaoPesquisar;
    }
}