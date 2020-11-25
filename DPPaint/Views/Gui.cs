using System.Windows.Forms;

namespace DPPaint.Views
{
    public class Gui : IUiModule
    {
        private readonly IGuiWindow _gui;

        public Gui(IGuiWindow gui)
        {
            _gui = gui;
        }

        public void AddEvent(EventName eventName, IEventCallback callback)
        {
            Button button = _gui.GetButton(eventName);
            //button += ((ActionEvent)->callback.run());
        }

        public T GetDialogResponse<T>(IDialogChoice<T> dialogSettings)
        {
            SettingsDialog dialog = new SettingsDialog();
            dialog.Text = dialogSettings.GetDialogTitle();
            dialog.label1.Text = dialogSettings.GetDialogText();

            var dialogOptions = dialogSettings.GetDialogOptions();
            foreach (var option in dialogOptions)
            {
                // TODO - design pattern?
                var dialogChoice = new DialogChoice();
                dialogChoice.label1.Text = option.ToString();
                dialog.groupBox1.Controls.Add(dialogChoice);
            }
            //dialog.ShowDialog();

            // need OK button - set selectedValue on dialogClose
            //var selectedValue;

            return dialogSettings.GetCurrentSelection();
        }
    }
}
