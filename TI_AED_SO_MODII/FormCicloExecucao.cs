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
        private delegate void DelegateChamadaSeguraTexto(string texto);
        private delegate void DelegateChamadaSegura();
        Processo executandoCPU1;
        Processo executandoCPU2;
        Thread CPU1;
        Thread CPU2;        
        Mutex mutex;


        public FormCicloExecucao()
        {
            InitializeComponent();
            //Program.threadDelegate = new ThreadStart(TimerCiclo.Start);
            //this.tick = new Thread(Program.threadDelegate);
            //this.tick.Name = "Tick";
            //this.tick.Start();
            //this.TimerCiclo.Enabled = true;
            textBoxExecucaoCPU1.Text = "Iniciando...";
            textBoxExecucaoCPU2.Text = "Iniciando...";
            textBoxListaPronto.Text = "Inicicando...";
            textBoxListaFinalizado.Text = "Inicicando...";                                    
            this.executandoCPU1 = new Processo();
            this.executandoCPU2 = new Processo();
            Program.cicloExecutando = true;            
        }

        private void TimerCiclo_Tick(object sender, EventArgs e)
        {            
            if(mutex == null)
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
        }

        public void Inicio()
        {
            if (Thread.CurrentThread.Name == "CPU1")
                AlocaProcesso(ref executandoCPU1);
            else if (Thread.CurrentThread.Name == "CPU2")
                AlocaProcesso(ref executandoCPU2);
            else
            {
                TimerCiclo_Tick(true, EventArgs.Empty);
            }
        }

        private void Ciclo(ref Processo processo)
        {
            Processo aux = new Processo();
            string linha = null;
            int quantum = processo.QuantidadeCiclo * 100;

            while (quantum == 0)
            {
                Thread.Sleep(100);
                quantum = quantum - 100;
                processo.Descontar(quantum / 100);
                if (Thread.CurrentThread.Name == "CPU1")
                {
                    AdicionarItemTextBoxCPU1(processo.ToString());
                }
                else if (Thread.CurrentThread.Name == "CPU2")
                {
                    AdicionarItemTextBoxCPU2(processo.ToString());
                }
                if(processo.QuantidadeCiclo == 0)
                {
                    ProcessoFinalizado(processo);
                    processo = new Processo(-1,null,-1,-1);
                    AlocaProcesso(ref processo);
                }
                else
                {
                    if (Thread.CurrentThread.Name == "CPU1")
                    {
                        linha = textBoxExecucaoCPU1.ToString();
                    }
                    else if (Thread.CurrentThread.Name == "CPU2")
                    {
                        linha = textBoxExecucaoCPU2.ToString();
                    }

                    string[] split;
                    split = linha.Split(';');

                    aux = new Processo(int.Parse(split[0]), split[1], int.Parse(split[2]), int.Parse(split[3]));                    
                    aux = ComparaPrioridade(aux);
                    if (aux != null)
                    {
                        TrocaContexto(aux, ref processo);
                    }
                }
            }
        }

        private void TrocaContexto(Processo novo, ref Processo processo)
        {
            processo = novo;
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
                Invoke(new DelegateChamadaSeguraTexto(AdicionarItemTextBoxCPU1), new object[] { texto});
            }
            else
            {
                textBoxExecucaoCPU1.Text = texto;
            }
        }
        private void AdicionarItemTextBoxCPU2(string texto)
        {
            if (textBoxExecucaoCPU2.InvokeRequired)
            {
                Invoke(new DelegateChamadaSeguraTexto(AdicionarItemTextBoxCPU2), new object[] { texto });
            }
            else
            {
                textBoxExecucaoCPU2.Text = texto;
            }
        }
        private void AdicionarItemTextBoxPronto(string texto)
        {
            if (textBoxListaPronto.InvokeRequired)
            {
                Invoke(new DelegateChamadaSeguraTexto(AdicionarItemTextBoxPronto), new object[] { texto });
            }
            else
            {
                textBoxListaPronto.Text = texto;
            }
        }
        private void AdicionarItemTextBoxFinalizado(string texto)
        {
            if (textBoxListaFinalizado.InvokeRequired)
            {
                Invoke(new DelegateChamadaSeguraTexto(AdicionarItemTextBoxFinalizado), new object[] { texto });
            }
            else
            {
                textBoxListaFinalizado.Text = texto;
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
            }

        }
    }
}
