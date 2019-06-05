using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TI_AED_SO_MODII
{
    //PONTIFÍCIA UNIVERSIDADE CATÓLICA DE MINAS GERAIS
    /*  Trabalho Integrado Algoritimo Estrutura de Dados e Sistemas Operacionais
     *  Programadore(s): 
     *  Arthur Wesley Santos
     *  
    */
    public class ListaCircular
    {
        private Elemento atual;         // É a sentinela.
        private int count;

        public ListaCircular()
        {
            this.count = 0;
            this.atual = new Elemento();
            this.atual.Proximo = atual;
            this.atual.Anterior = atual;
        }
        public Elemento Atual
        {
            get { return this.atual; }
            set { this.atual = value; }
        }
        public int Count
        {
            get { return this.count; }
        }


        public void Inserir(Processo p)
        {
            try
            {
                Elemento novo = new Elemento(p);
                if (this.Vazia())
                {
                    this.atual.Proximo = novo;
                    this.atual.Anterior = novo;
                    novo.Proximo = this.atual;
                    novo.Anterior = this.atual;
                }
                else
                {                    
                    this.atual.Proximo.Anterior = novo;
                    novo.Proximo = atual.Proximo;
                    this.atual.Proximo = novo;
                    novo.Anterior = this.atual;
                }
                this.count = this.count + 1;
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Circular (Inserir). {0} \n", e.ToString(), MessageBoxButtons.OK);
                throw;
            }
        }
        // Método Retirar() sempre pega o primeiro elemento.
        public Processo Retirar()
        {
            try
            {
                if (this.Vazia()) return null;
                Elemento aux = new Elemento(this.atual.Anterior);

                this.atual.Anterior = this.atual.Anterior.Anterior;

                if (this.Vazia()) this.atual.Proximo = this.atual;

                this.count = this.count - 1;
                return aux.DadoProcesso();
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Circular (Retirar). {0} \n", e.ToString(), MessageBoxButtons.OK);
                throw;
            }
        }

        public bool Vazia()
        {
            if (this.atual.Anterior == this.atual)
                return true;
            else
                return false;
        }

        public string[] String()
        {
            Elemento aux = this.atual.Anterior;
            string[] texto = new string[this.count];
            int cont = 0;
            try
            {                
                if (this.Vazia())
                    throw null;
                else
                {
                    while (aux.DadoProcesso() != null)
                    {
                        texto[cont] = aux.DadoProcesso().ToString();
                        aux = aux.Anterior;
                        cont++;
                    }
                    return texto;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Encadeada (ToString). {0} \n", e.ToString(), MessageBoxButtons.OK);
                return texto;
            }
        }
    }
}
