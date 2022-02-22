using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciKayit
{
    static class GlobalDeger
    {
        public static string ogrencino;
        
    }
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main( string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GlobalDeger.ogrencino = args[0];
            Application.Run(new OgrenciKayit());
        }
    }
}
