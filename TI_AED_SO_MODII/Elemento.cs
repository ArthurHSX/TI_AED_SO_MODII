using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_AED_SO_MODII
{
    //PONTIFÍCIA UNIVERSIDADE CATÓLICA DE MINAS GERAIS
    /*  Trabalho Integrado Algoritimo Estrutura de Dados e Sistemas Operacionais
     *  Programadore(s): 
     *  Arthur Wesley Santos
     *  
    */

    public class Elemento
    {
        private Elemento anterior;
        private Processo processo;
        private Elemento proximo;

        public Elemento()
        {
            this.anterior = null;
            this.processo = null;
            this.proximo = null;
        }
        public Elemento(Processo p)
        {
            this.processo = p;
            this.anterior = null;           // os apontadores devem ser definidos na lista na hora de inserir
            this.proximo = null;           // os apontadores devem ser definidos na lista na hora de inserir
        }
        public Elemento(Elemento elemento)
        {
            this.anterior = elemento.Anterior;
            this.processo = elemento.DadoProcesso();
            this.proximo = elemento.Proximo;
        }

        public Elemento Anterior
        {
            get { return this.anterior; }
            set { this.anterior = value; }
        }
        public Elemento Proximo
        {
            get { return this.proximo; }
            set { this.proximo = value; }
        }

        public Processo DadoProcesso()
        {
            return this.processo;
        }
        ///
        /// Resumo:
        ///     Determina se o objeto especificado é igual ao objeto atual.
        ///
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Elemento e = (Elemento)obj;
                return (e.anterior == this.anterior && e.proximo == this.proximo && e.processo.Id == this.processo.Id);
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
