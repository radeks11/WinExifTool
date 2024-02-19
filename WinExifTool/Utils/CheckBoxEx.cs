using System.Windows;

namespace System.Windows.Forms
{
    public class CheckBoxEx : CheckBox
    {
        private bool m_InvertCheckStateOrder;

        /// <summary>
        /// Gets or sets a value indicating whether to invert the check state order from [Indeterminate->Unchecked->Checked] to [Indeterminate->Checked->Unchecked].
        /// </summary>
        /// <value>
        ///   <c>true</c> to invert the check state order; otherwise, <c>false</c>.
        /// </value>
        public bool InvertCheckStateOrder
        {
            get { return m_InvertCheckStateOrder; }
            set { m_InvertCheckStateOrder = value; }
        }

        /// <summary>
        /// Löst das <see cref="E:System.Windows.Forms.Control.Click" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Eine Instanz der <see cref="T:System.EventArgs" />-Klasse, die die Ereignisdaten enthält.</param>
        protected override void OnClick(EventArgs e)
        {
            if (this.InvertCheckStateOrder)
            {
                switch (this.CheckState)
                {
                    case CheckState.Indeterminate:
                        this.CheckState = CheckState.Checked;
                        break;
                    case CheckState.Checked:
                        this.CheckState = CheckState.Unchecked;
                        break;
                    case CheckState.Unchecked:
                        this.CheckState = CheckState.Indeterminate;
                        break;
                }
            }
            else
                base.OnClick(e);
        }
    }
}
