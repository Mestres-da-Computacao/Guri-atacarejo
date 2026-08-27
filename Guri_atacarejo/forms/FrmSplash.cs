using Guri_atacarejo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            int raio = 10;

            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, raio, raio, 180, 90);
            path.AddArc(Width - raio, 0, raio, raio, 270, 90);
            path.AddArc(Width - raio, Height - raio, raio, raio, 0, 90);
            path.AddArc(0, Height - raio, raio, raio, 90, 90);

            path.CloseFigure();

            this.Region = new Region(path);
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
