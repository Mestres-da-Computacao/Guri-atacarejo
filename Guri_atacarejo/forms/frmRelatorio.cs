using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo.forms
{
    public partial class frmRelatorio : Form
    {
        public frmRelatorio()
        {
            InitializeComponent();
            cbtempo.SelectedIndex = 0;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void cbtempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbtempo.SelectedIndex) {
                case 0:
                    maskData.Mask = "00/00/0000";
                    break;
                case 1:
                    maskData.Mask = "00/0000";
                    break;
                case 2:
                    maskData.Mask = "0000";
                    break;
                default:
                    break;
            }
            
        }
    }
}
