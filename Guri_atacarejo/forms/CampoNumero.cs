using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    /// <summary>
    /// Substitui o NumericUpDown (ex.: salário) no estilo underline.
    /// Mantém Value, Minimum, Maximum e DecimalPlaces.
    /// Quando o valor é igual ao Minimum o campo fica vazio e mostra o placeholder (ex.: 0,00).
    /// </summary>
    [DesignerCategory("Code"), DefaultEvent("ValueChanged")]
    public class CampoNumero : CampoBase
    {
        private readonly TextBox tb = new TextBox();

        private decimal minimum = 0m;
        private decimal maximum = 999999999m;
        private decimal ultimo = 0m;
        private int casas = 2;

        public event EventHandler ValueChanged;

        public CampoNumero()
        {
            tb.KeyPress += Filtrar;
            tb.Leave += (s, e) => Definir(ValorAtual());
            AnexarTextBox(tb);
        }

        // =====================================================
        //  PROPRIEDADES
        // =====================================================

        [Category("Guri"), DefaultValue(typeof(decimal), "0")]
        public decimal Value
        {
            get => ValorAtual();
            set => Definir(value);
        }

        [Category("Guri"), DefaultValue(typeof(decimal), "0")]
        public decimal Minimum
        {
            get => minimum;
            set
            {
                minimum = value;
                if (maximum < minimum) maximum = minimum;
                Definir(ValorAtual());
            }
        }

        [Category("Guri"), DefaultValue(typeof(decimal), "999999999")]
        public decimal Maximum
        {
            get => maximum;
            set
            {
                maximum = value;
                if (minimum > maximum) minimum = maximum;
                Definir(ValorAtual());
            }
        }

        [Category("Guri"), DefaultValue(2)]
        public int DecimalPlaces
        {
            get => casas;
            set
            {
                casas = Math.Max(0, Math.Min(6, value));
                Definir(ValorAtual());
                AtualizarPlaceholder();
            }
        }

        protected override string PlaceholderEfetivo =>
            string.IsNullOrEmpty(PlaceholderText)
                ? 0m.ToString("F" + casas, CultureInfo.CurrentCulture)
                : PlaceholderText;

        // =====================================================
        //  LÓGICA
        // =====================================================

        private decimal ValorAtual()
        {
            if (decimal.TryParse(tb.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out var v))
                return Ajustar(v);
            return minimum;
        }

        private decimal Ajustar(decimal v) =>
            Math.Round(Math.Min(Math.Max(v, minimum), maximum), casas);

        private void Definir(decimal v)
        {
            v = Ajustar(v);
            tb.Text = v == minimum ? "" : v.ToString("F" + casas, CultureInfo.CurrentCulture);

            if (v != ultimo)
            {
                ultimo = v;
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        // Só aceita dígitos e UM separador decimal (aceita "." ou "," e converte pro da cultura)
        private void Filtrar(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            string sep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (casas > 0 && (e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar.ToString() == sep))
            {
                if (tb.Text.Contains(sep) && !tb.SelectedText.Contains(sep))
                {
                    e.Handled = true;
                    return;
                }

                e.KeyChar = sep[0];
                return;
            }

            e.Handled = true;
        }
    }
}
