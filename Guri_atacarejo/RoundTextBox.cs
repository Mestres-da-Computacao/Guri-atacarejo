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
        public override string Text
        {
            get => base.Text;
            set
            {
                // O Designer pode acessar Text antes de InitializeComponent.
                if (textBox1 == null)
                {
                    base.Text = value;
                    return;
                }

                textBox1.Text = value ?? string.Empty;
                base.Text = textBox1.Text;
            }
        }

        // A caixa interna herda cor e fonte do controle. Consultar sua
        // ForeColor aqui criaria uma chamada circular entre pai e filho.
        public override Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        [Description("Define a fonte do texto.")]
        [Browsable(true)]
        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility (DesignerSerializationVisibility.Visible)]
        public override Font Font 
        { 
            get => base.Font; 
            set => base.Font = value;
        }
        public RoundTextBox()
        {
            InitializeComponent();
            textBox1.Text = base.Text;
            // Mantém o texto legível mesmo dentro de um GroupBox com título branco.
            ForeColor = SystemColors.WindowText;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (textBox1 == null)
                return;

            textBox1.Location = new Point(Radius + 7, Radius + 7);
            textBox1.Size = new Size(
                Math.Max(0, Width - ((Radius + 7) * 2)),
                Math.Max(0, Height - ((Radius + 7) * 2)));
            textBox1.BackColor = BackgroundColor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Propaga a digitação para Text, TextChanged e os bindings do controle.
            base.Text = textBox1.Text;
        }

        private void RoundTextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
