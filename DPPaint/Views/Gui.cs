using System;
using System.Drawing;
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

        public void AddEvent(EventName eventName, Action command)
        {
            Button button = _gui.GetButton(eventName);
            button.Click += (s, e) => command.Invoke();
        }

        public T GetDialogResponse<T>(IDialogChoice<T> dialogSettings)
        {
            SettingsDialog dialog = new SettingsDialog();
            dialog.Text = dialogSettings.GetDialogTitle();
            dialog.label1.Text = dialogSettings.GetDialogText();

            var dialogOptions = dialogSettings.GetDialogOptions();
            var point = new Point(0, 0);
            foreach (var option in dialogOptions)
            {
                var dialogChoice = new RadioButton();
                dialogChoice.Text = option.ToString();
                dialogChoice.Location = point;
                dialog.groupBox1.Controls.Add(dialogChoice);
                point.Y += dialogChoice.Height;
            }

            _gui.SetSettingsDialog(dialog);

            //return await _gui.GetDialogResponse();

            // need OK button - set selectedValue on dialogClose

            return dialogSettings.GetCurrentSelection();
        }
    }
}
