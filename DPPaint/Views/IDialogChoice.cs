using System.Collections.Generic;

namespace DPPaint.Views
{
    public interface IDialogChoice<T>
    {
        string GetDialogTitle();

        string GetDialogText();

        IEnumerable<T> GetDialogOptions();

        T GetCurrentSelection();
    }
}
