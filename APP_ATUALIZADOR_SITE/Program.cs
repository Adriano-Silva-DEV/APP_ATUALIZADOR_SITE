using APP_ATUALIZADOR_SITE.classes;
using System;
using System.Threading;
using System.Windows.Forms;

namespace APP_ATUALIZADOR_SITE
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread threadAtualizador = new Thread(ProdutoAtualizador.Execute);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(threadAtualizador));
        }
    }
}
