using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint.Controllers
{
    public class PaintController : IPaintController
    {
        private readonly IUiModule _uiModule;
        private readonly IApplicationState _applicationState;
        private readonly PaintCanvas _paintCanvas;

        public PaintController(IUiModule uiModule, IApplicationState applicationState, PaintCanvas paintCanvas)
        {
            _uiModule = uiModule;
            _applicationState = applicationState;
            _paintCanvas = paintCanvas;
        }

        public void Setup()
        {
            SetupEvents();
        }
        private void SetupEvents()
        {
            _uiModule.AddEvent(EventName.CHOOSE_SHAPE, () => _applicationState.SetActiveShape());
            _uiModule.AddEvent(EventName.CHOOSE_PRIMARY_COLOR, () => _applicationState.SetActivePrimaryColor());
            _uiModule.AddEvent(EventName.CHOOSE_SECONDARY_COLOR, () => _applicationState.SetActiveSecondaryColor());
            _uiModule.AddEvent(EventName.CHOOSE_SHADING_TYPE, () => _applicationState.SetActiveShadingType());
            _uiModule.AddEvent(EventName.CHOOSE_MOUSE_MODE, () => _applicationState.SetActiveStartAndEndPointMode());
            _uiModule.AddEvent(EventName.UNDO, () => _paintCanvas.Undo());
            _uiModule.AddEvent(EventName.REDO, () => _paintCanvas.Redo());
        }
    }
}
