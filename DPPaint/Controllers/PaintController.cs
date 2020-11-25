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
            //_uiModule.AddEvent(EventName.CHOOSE_SHAPE, ()->applicationState.setActiveShape());
            //_uiModule.AddEvent(EventName.CHOOSE_PRIMARY_COLOR, ()->applicationState.setActivePrimaryColor());
            //_uiModule.AddEvent(EventName.CHOOSE_SECONDARY_COLOR, ()->applicationState.setActiveSecondaryColor());
            //_uiModule.AddEvent(EventName.CHOOSE_SHADING_TYPE, ()->applicationState.setActiveShadingType());
            //_uiModule.AddEvent(EventName.CHOOSE_MOUSE_MODE, ()->applicationState.setActiveStartAndEndPointMode());
        }
    }
}
