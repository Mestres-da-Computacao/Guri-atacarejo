using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    public class Icone : Form
    {
        private static readonly Icon IconeApp =
            Icon.FromHandle(Properties.Resources.projeto_icone.GetHicon());

        public Icone()
        {
            this.Icon = IconeApp;
        }
    }
}
