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
        ListaCircular listaCircular;
        ListaEncadeada listaPronto, listaFinalizado;

        public FormCicloExecucao(ListaCircular listaC, ListaEncadeada listaP, ListaEncadeada listaF)
        {
            this.listaCircular = listaC;
            this.listaPronto = listaP;
            this.listaFinalizado = listaF;
            InitializeComponent();
        }

        private void TimerCiclo_Tick(object sender, EventArgs e)
        {

        }

        private void ButtonEncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
