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
        ListaCircular listaCircular;
        ListaEncadeada listaPronto, listaFinalizado;
        ThreadStart threadDelegate;
        Thread threadCicloExec;

        public FormMenu()
        {
            this.listaCircular = new ListaCircular();
            this.listaPronto = new ListaEncadeada();
            this.listaFinalizado = new ListaEncadeada();
            this.threadDelegate = new ThreadStart(OpenForm);
            this.threadCicloExec = new Thread(threadDelegate);
            LeituraArquivo();
            //MessageBox.Show("Trabalho Integrado AED - SO \n\n Alunos: Arthur Wesley Santos,\n //Inserir os nomes dos integrantes do grupo *********************************** ", "TI_AED_SO", MessageBoxButtons.OK);            
            InitializeComponent();
        }
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
                            listaCircular.Inserir(aux);
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
            threadCicloExec.Start();
            this.SetDisplayRectLocation(0, 0);
            if(threadCicloExec.IsAlive)
            {
                this.IniciaCiclo.Enabled = false;
            }
        }

        private void ModificaPrioridade_Click(object sender, EventArgs e)
        {
            FormModificaPrioridade formModificaPrioridade = new FormModificaPrioridade(this.listaCircular);
            formModificaPrioridade.ShowDialog();
            //if (threadCicloExec.IsAlive)
            //{

            //}
            //else
            //{

            //}
        }

        private void OpenForm()
        {
            FormCicloExecucao cicloExecucao = new FormCicloExecucao(this.listaCircular, this.listaPronto, this.listaFinalizado);
            cicloExecucao.ShowDialog();
        }
    }
}
