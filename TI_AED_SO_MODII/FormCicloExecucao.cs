using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TI_AED_SO_MODII
{
    public partial class FormCicloExecucao : Form
    {
        private delegate void DelegateChamadaSeguraTextBox(string texto);
        private delegate void DelegateChamadaSegura();
        Processo executandoCPU1;
        Processo executandoCPU2;
        Thread CPU1;
        Thread CPU2;        
        Mutex mutex;


        public FormCicloExecucao()
        {
            InitializeComponent();                                              
            this.executandoCPU1 = new Processo();
            this.executandoCPU2 = new Processo();
            Program.cicloExecutando = true;            
        }

        private void TimerCiclo_Tick(object sender, EventArgs e)
        {                        
            try
            {                               
                Program.listaPronto.Inserir(Program.listaCircular.Retirar());
                AdicionarItemTextBoxFinalizado(Program.listaFinalizado.ToString());
                AdicionarItemTextBoxPronto(Program.listaPronto.ToString());
                AtualizarForm();             // Reseta o Forms.
            }
            catch (System.Exception)
            {
                MessageBox.Show("Erro no escalonamento. \n"+ e.ToString(), "Erro!",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Thread.CurrentThread.Suspend();
                CPU1.Suspend();
                CPU2.Suspend();
                EncerrarForm();
            }
            if (mutex == null)
            {
                this.mutex = new Mutex();
                Program.threadDelegate = new ThreadStart(Inicio);
                this.CPU1 = new Thread(Program.threadDelegate);
                this.CPU2 = new Thread(Program.threadDelegate);
                this.CPU1.Name = "CPU1";
                this.CPU2.Name = "CPU2";
                this.CPU1.Start();
                //this.CPU2.Start();
            }
            //if (CPU1.IsAlive== false)
            //{ CPU1.Start(); }
            //if (CPU2.IsAlive == false)
            //{ CPU2.Start(); }
        }

        public void Inicio()
        {
            if (Thread.CurrentThread.Name == "CPU1")
                AlocaProcesso(ref executandoCPU1);
            else if (Thread.CurrentThread.Name == "CPU2")
                AlocaProcesso(ref executandoCPU2);
            //else
            //{
            //    TimerCiclo_Tick(true, EventArgs.Empty);
            //}
        }

        private void Ciclo(ref Processo processo)
        {
            Processo aux = new Processo();
            string linha = null;
            int quantum = processo.QuantidadeCiclo;
            do
            {
                Thread.Sleep(100);
                quantum = quantum - 1;
                processo.Descontar(1);
                AtualizarForm();
                if (Thread.CurrentThread.Name == "CPU1")
                {
                    AdicionarItemTextBoxCPU1(processo.ToString());
                }
                else if (Thread.CurrentThread.Name == "CPU2")
                {
                    AdicionarItemTextBoxCPU2(processo.ToString());
                }
                if (processo.QuantidadeCiclo == 0)
                {
                    ProcessoFinalizado(processo);
                    processo = new Processo(-1, null, -1, -1);
                    AlocaProcesso(ref processo);
                }
                else
                {
                    if (Thread.CurrentThread.Name == "CPU1")
                    {
                        aux = executandoCPU1;
                    }
                    else if (Thread.CurrentThread.Name == "CPU2")
                    {
                        aux = executandoCPU2;
                    }  
                    
                    aux = ComparaPrioridade(aux);

                    if (aux != null)
                    {
                        TrocaContexto(aux, ref processo);
                        if (Thread.CurrentThread.Name == "CPU1")
                        {
                            AdicionarItemTextBoxCPU1(processo.ToString());
                        }
                        else if (Thread.CurrentThread.Name == "CPU2")
                        {
                            AdicionarItemTextBoxCPU2(processo.ToString());
                        }                        
                    }

                }
            } while (quantum != 0);            
        }

        private void TrocaContexto(Processo novo, ref Processo processo)
        {
            mutex.WaitOne();
            processo = novo;
            mutex.ReleaseMutex();
        }

        private void ProcessoFinalizado(Processo processo)
        {
            mutex.WaitOne();
            Program.listaFinalizado.Inserir(processo);
            this.textBoxListaFinalizado.Text = Program.listaFinalizado.ToString();
            mutex.ReleaseMutex();
        }        

        private Processo ComparaPrioridade(Processo processo)
        {
            mutex.WaitOne();

            Processo aux = Program.listaPronto.ComparaPrioridade(processo);
            if (aux != null)
            {
                aux = Program.listaPronto.BuscaRetira(aux);
                mutex.ReleaseMutex();
                return aux;
            }
            mutex.ReleaseMutex();
            return null;
        }

        private void AlocaProcesso(ref Processo executando)
        {
            Processo aux;
            mutex.WaitOne();
            if (executando.Nome == null)
            {
                aux = Program.listaPronto.RetiraPrimeiro();
                if (aux != null)
                {
                    executando = aux;
                    if (Thread.CurrentThread.Name == "CPU1")
                    { AdicionarItemTextBoxCPU1(executando.ToString()); }
                    else if(Thread.CurrentThread.Name == "CPU2")
                    { AdicionarItemTextBoxCPU2(executando.ToString()); }
                }
            }
            else if (!Program.listaPronto.Vazia())
            {
                executando = Program.listaPronto.ComparaPrioridade(executando);
                Program.listaPronto.BuscaRetira(executando);
                AtualizarForm();
                if (Thread.CurrentThread.Name == "CPU1")
                { AdicionarItemTextBoxCPU1(executando.ToString()); }
                else if (Thread.CurrentThread.Name == "CPU2")
                { AdicionarItemTextBoxCPU2(executando.ToString()); }
            }
            //this.textBoxListaPronto.Text = Program.listaPronto.ToString();
            mutex.ReleaseMutex();
            Ciclo(ref executando);
        }

        private void ButtonEncerrar_Click(object sender, EventArgs e)
        {
            EncerrarForm();
        }

        private void EncerrarForm()
        {
            CPU1.Abort();
            CPU2.Abort();
            Program.cicloExecutando = false;
            Thread.CurrentThread.Abort();
            this.Close();
        }

        private void AdicionarItemTextBoxCPU1(string texto)
        {
            if(textBoxExecucaoCPU1.InvokeRequired)
            {
                Invoke(new DelegateChamadaSeguraTextBox(AdicionarItemTextBoxCPU1), new object[] { texto});
            }
            else
            {
                if (texto != null)
                {
                    textBoxExecucaoCPU1.Text = texto;
                    this.Refresh();
                }
            }
        }
        private void AdicionarItemTextBoxCPU2(string texto)
        {
            if (textBoxExecucaoCPU2.InvokeRequired)
            {
                Invoke(new DelegateChamadaSeguraTextBox(AdicionarItemTextBoxCPU2), new object[] { texto });
            }
            else
            {
                if (texto != null)
                {
                    textBoxExecucaoCPU2.Text = texto;
                    this.Refresh();
                }
            }
        }
        private void AdicionarItemTextBoxPronto(string texto)
        {
            if (textBoxListaPronto.InvokeRequired)
            {
                Invoke(new DelegateChamadaSeguraTextBox(AdicionarItemTextBoxPronto), new object[] { texto });
            }
            else
            {
                if (texto != null)
                {
                    textBoxListaPronto.Text = texto;
                }
                this.Refresh();
            }
        }
        private void AdicionarItemTextBoxFinalizado(string texto)
        {
            if (textBoxListaFinalizado.InvokeRequired)
            {
                Invoke(new DelegateChamadaSeguraTextBox(AdicionarItemTextBoxFinalizado), new object[] { texto });
            }
            else
            {
                if (texto != null)
                {
                    textBoxListaFinalizado.Text = texto;
                }
                this.Refresh();
            }
        }
        private void AtualizarForm()
        {
            if(this.InvokeRequired)
            {
                Invoke(new DelegateChamadaSegura(AtualizarForm));
            }
            else
            {
                this.Refresh();
                this.textBoxExecucaoCPU1.Refresh();
                this.textBoxExecucaoCPU2.Refresh();
                this.textBoxListaPronto.Refresh();
                this.textBoxListaFinalizado.Refresh();                
            }

        }
    }
}
