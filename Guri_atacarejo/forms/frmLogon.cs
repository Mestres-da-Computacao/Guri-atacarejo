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
    public partial class frmLogon : Form
    {
    bool userjacolocou = false;
        bool pissjacolocou = false;
        public frmLogon()
        {
            InitializeComponent();
        }

        private void Usertxtbox_Click(object sender, EventArgs e)
        {
            if (!userjacolocou)
            {
                Usertxtbox.Text = "";
                userjacolocou = true;
            }
            else
            {
                return;
            }
        }

        private void Usertxtbox_Leave(object sender, EventArgs e)
        {
            if(Usertxtbox.Text == "") 
            {
                Usertxtbox.Text = "Digite o usuário";
                userjacolocou = false;
            }
        }

        private void Pisswordtxtbox_Click(object sender, EventArgs e)
        {
            if (!pissjacolocou)
            {
                Pisswordtxtbox.Text = "";
                pissjacolocou = true;
            }
            else
            {
                return;
            }
        }

        private void Pisswordtxtbox_Leave(object sender, EventArgs e)
        {
            if (Pisswordtxtbox.Text == "")
            {
                Pisswordtxtbox.Text = "Digite sua senha";
                pissjacolocou = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
