using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TI_AED_SO_MODII
{
    static class Program
    {
        public static ListaCircular listaCircular;
        public static ListaEncadeada listaPronto;
        public static ListaEncadeada listaFinalizado;
        public static ThreadStart threadDelegate;
        public static bool cicloExecutando;
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //threadSecundaria = new Thread(threadDelegate);
            //threadExecucao = new Thread(threadDelegate);
            listaCircular = new ListaCircular();
            listaPronto = new ListaEncadeada();
            listaFinalizado = new ListaEncadeada();
            cicloExecutando = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMenu());
        }
    }
}
