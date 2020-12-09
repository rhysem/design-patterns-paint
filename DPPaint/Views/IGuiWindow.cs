using System.Windows.Forms;

namespace DPPaint.Views
{
    public interface IGuiWindow
    {
        Button GetButton(EventName eventName);
        void SetSettingsDialog(SettingsDialog dialog);
    }
}
