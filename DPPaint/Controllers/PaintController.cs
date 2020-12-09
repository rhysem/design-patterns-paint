using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint.Controllers
{
    public class PaintController : IPaintController
    {
        private readonly IUiModule _uiModule;
        private readonly IApplicationState _applicationState;

        public PaintController(IUiModule uiModule, IApplicationState applicationState)
        {
            _uiModule = uiModule;
            _applicationState = applicationState;
        }

        public void Setup()
        {
            SetupEvents();
        }
        private void SetupEvents()
        {
            _uiModule.AddEvent(EventName.CHOOSE_SHAPE, () => _applicationState.ChooseActiveShape());
            _uiModule.AddEvent(EventName.CHOOSE_PRIMARY_COLOR, () => _applicationState.ChooseActivePrimaryColor());
            _uiModule.AddEvent(EventName.CHOOSE_SECONDARY_COLOR, () => _applicationState.ChooseActiveSecondaryColor());
            _uiModule.AddEvent(EventName.CHOOSE_SHADING_TYPE, () => _applicationState.ChooseActiveShadingType());
            _uiModule.AddEvent(EventName.CHOOSE_MOUSE_MODE, () => _applicationState.ChooseActiveStartAndEndPointMode());
        }
    }
}
