using DPPaint.Models.Dialogs;
using DPPaint.Views;

namespace DPPaint.Models.ApplicationState
{
    public class ApplicationState : IApplicationState
    {
        private readonly IUiModule _uiModule;
        private readonly IDialogProvider _dialogProvider;

        private ShapeType _activeShapeType;
        private ShapeColor _activePrimaryColor;
        private ShapeColor _activeSecondaryColor;
        private ShapeShadingType _activeShapeShadingType;
        private MouseMode _activeMouseMode;

        public ApplicationState(IUiModule uiModule)
        {
            _uiModule = uiModule;
            _dialogProvider = new DialogProvider(this);
            SetDefaults();
        }

        public MouseMode GetActiveMouseMode()
        {
            return _activeMouseMode;
        }

        public ShapeColor GetActivePrimaryColor()
        {
            return _activePrimaryColor;
        }

        public ShapeColor GetActiveSecondaryColor()
        {
            return _activeSecondaryColor;
        }

        public ShapeShadingType GetActiveShapeShadingType()
        {
            return _activeShapeShadingType;
        }

        public ShapeType GetActiveShapeType()
        {
            return _activeShapeType;
        }

        public void SetActivePrimaryColor()
        {
            _activePrimaryColor = _uiModule.GetDialogResponse(_dialogProvider.GetChoosePrimaryColorDialog());
        }

        public void SetActiveSecondaryColor()
        {
            _activePrimaryColor = _uiModule.GetDialogResponse(_dialogProvider.GetChoosePrimaryColorDialog());
        }

        public void SetActiveShadingType()
        {
            _activeShapeShadingType = _uiModule.GetDialogResponse(_dialogProvider.GetChooseShadingTypeDialog());
        }

        public void SetActiveShape()
        {
            _activeShapeType = _uiModule.GetDialogResponse(_dialogProvider.GetChooseShapeDialog());
            PaintCanvas.SetPaintStrategy(_activeShapeType);
        }

        public void SetActiveStartAndEndPointMode()
        {
            _activeMouseMode = _uiModule.GetDialogResponse(_dialogProvider.GetChooseStartAndEndPointModeDialog());
        }

        private void SetDefaults()
        {
            _activeShapeType = ShapeType.RECTANGLE;
            _activePrimaryColor = ShapeColor.BLACK;
            _activeSecondaryColor = ShapeColor.WHITE;
            _activeShapeShadingType = ShapeShadingType.FILLED_IN;
            _activeMouseMode = MouseMode.DRAW;
        }
    }
}
