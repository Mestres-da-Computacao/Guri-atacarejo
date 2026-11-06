using System.ComponentModel;
using System.Windows.Forms;

namespace Guri_atacarejo
{
    /// <summary>
    /// Substitui o MaskedTextBox (CPF, telefone...) no estilo underline.
    /// Mantém Mask, MaskCompleted, MaskFull, Text e o evento MaskInputRejected.
    /// </summary>
    [DesignerCategory("Code"), DefaultEvent("TextChanged")]
    public class CampoMascara : CampoBase
    {
        protected readonly MaskedTextBox mtb = new MaskedTextBox();

        public event MaskInputRejectedEventHandler MaskInputRejected;

        public CampoMascara()
        {
            mtb.PromptChar = '_';
            mtb.MaskInputRejected += (s, e) => MaskInputRejected?.Invoke(this, e);
            AnexarTextBox(mtb);
        }

        [Category("Guri"), DefaultValue(""), Description("Máscara de entrada (mesma sintaxe do MaskedTextBox).")]
        public string Mask
        {
            get => mtb.Mask;
            set { mtb.Mask = value ?? ""; AtualizarPlaceholder(); }
        }

        [Browsable(false)]
        public bool MaskCompleted => mtb.MaskCompleted;

        [Browsable(false)]
        public bool MaskFull => mtb.MaskFull;

        // Vazio = nenhum caractere digitado (os literais da máscara não contam)
        protected override bool TextoVazio
        {
            get
            {
                var p = mtb.MaskedTextProvider;
                return p == null ? mtb.TextLength == 0 : p.AssignedEditPositionCount == 0;
            }
        }

        protected override void PosicionarCursor()
        {
            var p = mtb.MaskedTextProvider;
            if (p == null)
            {
                mtb.SelectionStart = mtb.TextLength;
                return;
            }

            int pos = p.FindEditPositionFrom(p.LastAssignedPosition + 1, true);
            mtb.SelectionStart = pos < 0 ? mtb.TextLength : pos;
        }
    }
}
