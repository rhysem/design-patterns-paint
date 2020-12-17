using System;
using System.Linq;
using System.Windows.Forms;

namespace DPPaint
{
    public partial class SettingsForm : Form
    {
        private object _selected { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.OnFormClosed);
        }

        public T ShowForm<T>()
        {
            if (ShowDialog() == DialogResult.OK && typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), _selected.ToString());
            }

            return default(T); // TODO - MUST RETURN NULL
        }

        private void OnFormClosed(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _selected = groupBox1.Controls.OfType<RadioButton>().First(c => c.Checked).Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
