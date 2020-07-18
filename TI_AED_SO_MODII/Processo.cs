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
     *  Matheus Rógeres
     *  Norton de Souza
     *  David Richard
     *  
    */

    public class Processo
    {
        private int id;
        private string nome;
        private int prioridade;
        private int quantidadeCiclo;
        private bool executando;

        public Processo()
        {
            this.id = -1;
            this.nome = null;
            this.prioridade = -1;
            this.quantidadeCiclo = -1;
            this.executando = false;
        }
        public Processo(int id)
        {
            this.id = id;
            this.nome = null;
            this.prioridade = -1;
            this.quantidadeCiclo = -1;
            this.executando = false;
        }
        public Processo(Processo processo)
        {
            this.id = processo.Id;
            this.nome = processo.Nome;
            this.prioridade = processo.prioridade;
            this.quantidadeCiclo = processo.QuantidadeCiclo;
            this.executando = false;
        }
        public Processo(int id, string nome, int prioridade, int quantidadeCiclo)
        {
            this.id = id;
            this.nome = nome;
            this.prioridade = prioridade;
            this.quantidadeCiclo = quantidadeCiclo;
            this.executando = false;
        }

        public bool Executando
        {
            get { return this.executando; }
        }
        public int QuantidadeCiclo
        {
            get { return this.quantidadeCiclo; }
        }

        public int Prioridade
        {

            get { return this.prioridade; }

            set { this.prioridade = value; }
        }
        public string Nome
        {

            get { return this.nome;  }
            set { this.nome = value; }
        }
        public int Id
        {

            get { return this.id;  }
            set { this.id = value; }
        }

        public void Descontar(int x)
        {
            try
            {
                this.quantidadeCiclo = this.quantidadeCiclo - x;
                if (this.quantidadeCiclo < 0)
                { quantidadeCiclo = 0; }
                        
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void AlteraPrioridade()
        {
            try
            {
                if (this.prioridade > 3 && this.quantidadeCiclo < 3)
                {
                    this.prioridade = this.prioridade - 3;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        ///
        /// Resumo:
        ///     Escreve uma cadeia de caracteres que descreve o objeto
        public override string ToString()
        {
            try
            {
                return String.Format(this.id.ToString() + ";" + this.nome.ToString() + ";" + this.prioridade.ToString() +
                ";" + this.quantidadeCiclo.ToString());
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public string[] DetalhesProcesso()
        {
            string[] texto = new string[4];
            try
            {
                texto[0] = "ID: " + this.id.ToString();
                texto[1] = "Nome: " + this.nome.ToString();
                texto[2] = "Prioridade: " + this.prioridade.ToString();
                texto[3] = "Qntd ciclo: " + this.quantidadeCiclo.ToString();
                return texto;                
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        ///
        /// Resumo:
        ///     Determina se o objeto especificado é igual ao objeto atual.
        ///
        //public override bool Equals(Object obj)
        //{
        //    if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        Processo p = (Processo)obj;
        //        return (id == p.Id);
        //    }
        //}
    }
}
