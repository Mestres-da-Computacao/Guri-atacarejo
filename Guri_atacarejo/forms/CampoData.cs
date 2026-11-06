using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    /// <summary>
    /// Substitui o DateTimePicker no estilo underline: digita dd/mm/aaaa ou abre o calendário no ícone.
    /// Value devolve a data; DataValida diz se o que foi digitado é uma data completa e dentro de MinDate/MaxDate.
    /// </summary>
    [DesignerCategory("Code"), DefaultEvent("ValueChanged")]
    public class CampoData : CampoMascara
    {
        private DateTime minDate = new DateTime(1900, 1, 1);
        private DateTime maxDate = new DateTime(9998, 12, 31);

        private readonly MonthCalendar cal = new MonthCalendar { MaxSelectionCount = 1 };
        private readonly ToolStripDropDown drop;

        public event EventHandler ValueChanged;

        public CampoData()
        {
            mtb.Culture = CultureInfo.InvariantCulture;   // "/" fixo, independente da cultura do Windows
            Mask = "00/00/0000";
            PlaceholderText = "dd/mm/aaaa";

            drop = CriarDropDown(cal);
            cal.DateSelected += (s, e) =>
            {
                Value = e.Start;
                drop.Close();
                FocarCampo();
            };

            mtb.TextChanged += (s, e) =>
            {
                if (DataValida) ValueChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        // =====================================================
        //  PROPRIEDADES
        // =====================================================

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Value
        {
            get => TentarLer(out var d) ? d : DateTime.Today;
            set
            {
                DateTime d = value.Date;
                if (d < minDate) d = minDate;
                if (d > maxDate) d = maxDate;
                mtb.Text = d.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime MinDate
        {
            get => minDate;
            set => minDate = value.Date;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime MaxDate
        {
            get => maxDate;
            set => maxDate = value.Date;
        }

        /// <summary>true se o campo tem uma data completa, real e dentro de MinDate/MaxDate.</summary>
        [Browsable(false)]
        public bool DataValida => TentarLer(out _);

        public void Limpar() => mtb.Text = "";

        private bool TentarLer(out DateTime d) =>
            DateTime.TryParseExact(mtb.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                   DateTimeStyles.None, out d)
            && d >= minDate && d <= maxDate;

        // =====================================================
        //  ÍCONE DE CALENDÁRIO
        // =====================================================

        protected override bool TemIcone => true;

        protected override void ClicouIcone()
        {
            FocarCampo();

            if (DropAberto)
            {
                drop.Close();
                return;
            }
            if (DropRecemFechado) return;

            DateTime d = TentarLer(out var v) ? v : DateTime.Today;
            if (d < minDate) d = minDate;
            if (d > maxDate) d = maxDate;

            cal.MinDate = minDate < new DateTime(1753, 1, 1) ? new DateTime(1753, 1, 1) : minDate;
            cal.MaxDate = maxDate;
            cal.SetDate(d);

            drop.Show(this, new Point(0, Height));
        }

        protected override void DesenharIcone(Graphics g, Rectangle r, Color cor)
        {
            using (var pen = new Pen(cor, 1.6f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                float topo = r.Y + r.Height * 0.15f;
                float altura = r.Height * 0.85f;

                // corpo + faixa do cabeçalho
                g.DrawRectangle(pen, r.X, topo, r.Width, altura);
                g.DrawLine(pen, r.X, topo + altura * 0.32f, r.Right, topo + altura * 0.32f);

                // argolas
                g.DrawLine(pen, r.X + r.Width * 0.3f, r.Y, r.X + r.Width * 0.3f, topo + altura * 0.2f);
                g.DrawLine(pen, r.X + r.Width * 0.7f, r.Y, r.X + r.Width * 0.7f, topo + altura * 0.2f);
            }
        }
    }
}
