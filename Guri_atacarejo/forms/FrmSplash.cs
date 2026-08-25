using Guri_atacarejo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private Timer timer;

        private void FrmSplash(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 4000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
         
            timer.Stop();
            this.Hide();
            // adicionar o frmLogin.show
            // frmlogon login = new frmlogon;
            // login.show;

        }
    }
}
