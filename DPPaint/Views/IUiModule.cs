using System;

namespace DPPaint.Views
{
    public interface IUiModule
    {
        void AddEvent(EventName eventName, Action command);
        T GetDialogResponse<T>(IDialogChoice<T> dialogChoice);
    }
}
