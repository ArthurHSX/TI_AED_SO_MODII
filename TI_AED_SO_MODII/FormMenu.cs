using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace TI_AED_SO_MODII
{
    public partial class FormMenu : Form
    {
        Thread tick;
        FormCicloExecucao cicloExecucaoForm;
        public FormMenu()
        {           
            Program.listaCircular = new ListaCircular();
            Program.listaPronto = new ListaEncadeada();
            Program.listaFinalizado = new ListaEncadeada();
            LeituraArquivo();
            MessageBox.Show("Trabalho Integrado AED - SO \n\n Alunos: Arthur Wesley Santos,\nDavid Richard\nMatheus Rógeres\nNorton de Souza", "TI_AED_SO", MessageBoxButtons.OK);
            InitializeComponent();
        }
        //public FormMenu(ListaCircular listaC)
        //{
        //    Program.listaCircular = listaC;
        //    Program.listaPronto = new ListaEncadeada();
        //    Program.listaFinalizado = new ListaEncadeada();            
        //    InitializeComponent();
        //}
        

        internal void LeituraArquivo()
        {
            try
            {
                using (StreamReader rd = new StreamReader("DadosTI.txt"))
                {
                    string linha;
                    string[] split;
                    Processo aux;
                    while ((linha = rd.ReadLine()) != null)
                    {
                        if (linha == "")
                        {
                            linha = rd.ReadLine();
                        }
                        else
                        {
                            split = linha.Split(';');
                            aux = new Processo(int.Parse(split[0]), split[1], int.Parse(split[2]), int.Parse(split[3]));
                            Program.listaCircular.Inserir(aux);
                        }

                        //Proximo Elemento
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("O arquivo não pôde ser lido.\n" + e.Message, "Erro na leitura do arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);                                
            }
        }

        private void IniciaCiclo_Click(object sender, EventArgs e)
        {
            cicloExecucaoForm = new FormCicloExecucao();
            Program.threadDelegate = new ThreadStart(OpenFormCiclo);
            tick = new Thread(Program.threadDelegate);
            tick.Name = "Thread Ciclo Execucao";
            tick.Start();
            Thread.Sleep(500);
        }

        private void ModificaPrioridade_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função não implementado!!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //FormModificaPrioridade formModificaPrioridade = new FormModificaPrioridade();
            //formModificaPrioridade.ShowDialog();

        }                                     

        private void SuspendeResume_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função não implementado!!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Encerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenFormCiclo()
        {
            if (Application.OpenForms.OfType<FormCicloExecucao>().Count() == 1)
            {
                MessageBox.Show("Janela já está aberta!\nCiclo já iniciado.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cicloExecucaoForm.Show();
                Application.Run(cicloExecucaoForm);
                
            }
        }
    }
}
