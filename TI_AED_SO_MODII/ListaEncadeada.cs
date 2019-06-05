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

    public class ListaEncadeada
    {
        private Elemento primeiro, ultimo;
        private int count;

        public Elemento Primeiro
        {
            get { return this.primeiro; }
            set { this.primeiro = value; }
        }
        public Elemento Ultimo
        {
            get { return this.ultimo; }
            set { this.ultimo = value; }
        }
        public int Count
        {
            get { return this.count; }
        }

        public ListaEncadeada()
        {
            this.count = 0;
            this.primeiro = new Elemento();
            this.ultimo = this.primeiro;
        }

        public void Inserir(Processo processo)
        {
            try
            {
                Elemento novo = new Elemento(processo);

                if (this.Vazia())
                {
                    this.ultimo = novo;
                    this.primeiro.Proximo = this.ultimo;
                }
                else
                {
                    this.ultimo.Proximo = novo;
                    //this.ultimo.Anterior = ultimo;
                    this.ultimo = novo;
                }
                this.count = this.count + 1;
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Encadeada (Inserir). {0} \n", e.ToString(), MessageBoxButtons.OK);
                throw;
            }
        }

        public Processo RetiraPrimeiro()
        {
            try
            {
                Elemento auxretirada = new Elemento();
                if (this.Vazia() == true)
                { return null; }
                else
                {
                    auxretirada = this.primeiro.Proximo;
                    this.primeiro.Proximo = auxretirada.Proximo;
                    if (this.primeiro.Proximo == null) { this.ultimo = this.primeiro; }

                    this.count = this.count - 1;
                    return auxretirada.DadoProcesso();
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Encadeada (RetiraPrimeiro). {0} \n", e.ToString(), MessageBoxButtons.OK);
                throw;
            }

        }

        public Processo BuscaRetira(Processo processo)
        {
            try
            {
                Elemento aux = this.Busca(new Elemento(processo));
                Elemento auxRetirada = new Elemento();
                if (aux == null)
                { throw new Exception(); }
                if (aux.Proximo != null)
                {
                    auxRetirada = aux.Proximo;
                    aux.Proximo = aux.Proximo.Proximo;
                    if (aux.Proximo == null) { this.ultimo = aux; }
                    this.count = this.count - 1;
                    return auxRetirada.DadoProcesso();
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Encadeada (BuscaRetira). {0} \n", e.ToString(), MessageBoxButtons.OK);
                throw;
            }
            return null;
        }

        private Elemento Busca(Elemento elemento)
        {
            try
            {
                if (this.Vazia()) return null;
                Elemento percorre = this.primeiro;
                while (percorre.Proximo != null)
                {// IF está funcionando como um método equals****
                    if (percorre.Proximo.DadoProcesso().Id == elemento.DadoProcesso().Id)
                    {
                        return percorre;
                    }
                    percorre = percorre.Proximo;
                }
                return null;
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Encadeada (Busca). {0} \n", e.ToString(), MessageBoxButtons.OK);
                throw;
            }
        }

        public Processo ComparaPrioridade(Processo processo)
        {
            try
            {
                Elemento percorre = this.primeiro;
                Processo aux = null;

                while (percorre.Proximo != null)
                {
                    if (percorre.Proximo.DadoProcesso().Prioridade > processo.Prioridade)
                        aux = percorre.Proximo.DadoProcesso();

                    percorre = percorre.Proximo;
                }
                return aux;
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Encadeada (Compara Prioridade). {0} \n", e.ToString(), MessageBoxButtons.OK);
                throw;
            }
        }

        public bool Vazia()
        {
            return (this.primeiro.Proximo == null);
        }

        //public Dado Consultimoa_indice(int pos)
        //{
        //    if (this.vazia()) return null;

        //    int i = 0;
        //    Elemento aux = this.primeiro;

        //    while (aux != null && i < pos)
        //    {
        //        aux = aux.Proximo;
        //        i++;
        //    }

        //    if (aux == null) return null;
        //    else return aux.Meudado();
        //}

        public void Concatenar(ListaEncadeada outra)
        {
            try
            {
                if (!outra.Vazia())
                {
                    this.ultimo.Proximo = outra.primeiro.Proximo;
                    this.ultimo = outra.ultimo;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public override string ToString()
        {
            try
            {
                Elemento aux = this.primeiro.Proximo;
                string texto = null;
                if (this.Vazia())
                    return "Lista vazia.";
                else
                {
                    do
                    {
                        texto = texto + aux.DadoProcesso().ToString() + '\n';
                        aux = aux.Proximo;
                    } while (aux != null);
                    return texto;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Erro na Lista Encadeada (ToString). {0} \n", e.ToString(), MessageBoxButtons.OK);
                return "";
            }
        }
    }
}
