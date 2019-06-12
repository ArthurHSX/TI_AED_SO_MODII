using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TI_AED_SO_MODII
{
    public partial class FormModificaPrioridade : Form
    {                
        public FormModificaPrioridade()
        {           
            InitializeComponent();            
            //ListaProcesso();
            labelProcesso.Visible = false;
            textBoxProcesso.Enabled = false; textBoxProcesso.Visible = false;
            labelPrioridade.Visible = false;
            textBoxPrioridade.Enabled = false; textBoxPrioridade.Visible = false; 
        }

        private void textBoxPrioridade_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
                        
        }

        //public void ListaProcesso()
        //{
        //    if(!Program.threadExecucao.IsAlive == true)
        //    { this.textBoxListaProcesso.Lines = Program.listaCircular.String(); }
        //    else
        //    {
        //        Elemento aux = Program.listaCircular.Atual.Anterior;
        //        ListaEncadeada lista = Program.listaPronto;
        //        lista.Concatenar(Program.listaFinalizado);
        //        while(aux != null)
        //        {
        //            lista.Inserir(aux.DadoProcesso());
        //            aux = aux.Anterior;                    
        //        }
        //        aux = lista.Primeiro.Proximo;
        //        for (int i = 0; i < lista.Count; i++)
        //        {
        //            textBoxListaProcesso.Lines[i] = aux.DadoProcesso().ToString();
        //        }
        //    }
            
        //}
        private void PesquisaID(int id)
        {
            try
            {
                Processo processo = new Processo(id);
                processo = Program.listaCircular.Busca(processo);
                if (processo == null)
                    MessageBox.Show("Processo não encontrado!!\n\nProcesso não foi encontrado na lista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    labelPrioridade.Enabled = true; labelPrioridade.Visible = true;
                    textBoxProcesso.Enabled = true; textBoxProcesso.Visible = true;
                    textBoxID.Enabled = false; textBoxID.Visible = false;
                    textBoxPrioridade.Enabled = true; textBoxPrioridade.Visible = true;
                    label4.Visible = false;
                    textBoxProcesso.Lines = processo.DetalhesProcesso();
                    butaoPesquisar.Enabled = false; butaoPesquisar.Visible = false;
                }
            }
            finally
            {
                Processo processo = new Processo(id);
                processo = Program.listaCircular.Busca(processo);                
            }
        }

        private void butaoPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                PesquisaID(int.Parse(textBoxID.Text));
            }
            catch
            {
                MessageBox.Show("Valor inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
