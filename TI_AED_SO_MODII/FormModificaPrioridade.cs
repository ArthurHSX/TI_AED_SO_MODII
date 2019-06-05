using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TI_AED_SO_MODII
{
    public partial class FormModificaPrioridade : Form
    {
        ListaCircular ListaCircular;
        ListaEncadeada listaPronto, listaFinalizado;

        public FormModificaPrioridade(ListaCircular listaC, ListaEncadeada listaP, ListaEncadeada listaF)
        {
            this.ListaCircular = listaC;
            this.listaPronto = listaP;
            this.listaFinalizado = listaF;
            InitializeComponent();
        }
        public FormModificaPrioridade(ListaCircular listaC)
        {
            this.ListaCircular = listaC;            
            InitializeComponent();
            ListaProcesso();
            labelProcesso.Visible = false;
            textBoxProcesso.Enabled = false; textBoxProcesso.Visible = false;
            labelPrioridade.Visible = false;
            textBoxPrioridade.Enabled = false; textBoxPrioridade.Visible = false; 

        }        
        public void ListaProcesso()
        {
            this.textBoxListaProcesso.Lines = ListaCircular.String();
        }
    }
}
