using System.Linq;
using System.Windows.Forms;

namespace DPPaint
{
    public partial class SettingsDialog : UserControl
    {
        protected object _selected { get; set; }

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _selected = groupBox1.Controls.OfType<RadioButton>().First(c => c.Checked).Text;

            //if (_clickMethod != null && _selected != null)
            //{
            //    _clickMethod(_selected);
            //}
        }
    }
}
