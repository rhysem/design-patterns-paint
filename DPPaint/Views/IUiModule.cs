namespace DPPaint.Views
{
    public interface IUiModule
    {
        void AddEvent(EventName eventName, IEventCallback command);
        T GetDialogResponse<T>(IDialogChoice<T> dialogChoice);
    }
}
