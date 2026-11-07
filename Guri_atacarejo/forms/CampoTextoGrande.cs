using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    /// <summary>
    /// Caixa de texto grande (várias linhas) para descrições: sempre uma caixa branca
    /// de cantos arredondados, com a borda mais grossa quando está focada.
    /// Tem Text, PlaceholderText, MaxLength e Clear().
    /// </summary>
    [DesignerCategory("Code"), DefaultEvent("TextChanged")]
    public class CampoTextoGrande : CampoBase
    {
        private readonly TextBox tb = new TextBox();

        public CampoTextoGrande()
        {
            tb.Multiline = true;
            tb.WordWrap = true;
            tb.AcceptsReturn = true;               // Enter quebra a linha
            tb.ScrollBars = ScrollBars.Vertical;   // barra de rolagem só aparece quando precisa

            lineColor = Color.FromArgb(5, 87, 40);                 // borda
            corPlaceholder = Color.FromArgb(140, 160, 140);        // cinza-esverdeado (o fundo é branco)

            AnexarTextBox(tb);
            Size = new Size(400, 120);
        }

        // A caixa grande usa margem e raio fixos (não proporcionais à altura)
        protected override int PadH => 12;
        protected override int Raio => 14;
        protected override bool CaixaSempreBranca => true;

        [Category("Guri"), DefaultValue(32767), Description("Número máximo de caracteres.")]
        public int MaxLength
        {
            get => tb.MaxLength;
            set => tb.MaxLength = value;
        }

        public void Clear() => tb.Clear();

        protected override void DesenharFundo(Graphics g)
        {
            var r = new Rectangle(1, 1, Width - 3, Height - 3);
            using (var path = RetanguloArredondado(r, Raio))
            using (var fill = new SolidBrush(Color.White))
            using (var pen = new Pen(lineColor, focado ? 2.5f : 1.5f))
            {
                g.FillPath(fill, path);
                g.DrawPath(pen, path);
            }
        }
    }
}
