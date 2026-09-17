using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoundTextBoxProject;

namespace Guri_atacarejo
{
    public partial class RoundTextBox : RoundControl
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text { get => textBox1.Text; set => textBox1.Text = value; }
        public override Color ForeColor { get => textBox1.ForeColor; set => textBox1.ForeColor = value; }
        [Description("Define a fonte do rótulo do botão.")]
        [Browsable(true)]
        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility (DesignerSerializationVisibility.Visible)]
        public override Font Font 
        { 
            get => base.Font; 
            set => textBox1.Font = base.Font = value; 
        }
        public RoundTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            textBox1.Location = new Point(Radius + 7, Radius + 7);
            textBox1.Size = new Size(Width - ((Radius + 7) * 2), Height - ((Radius + 7) * 2));
            textBox1.BackColor = BackgroundColor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
