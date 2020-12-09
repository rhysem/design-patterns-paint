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

        public void SetActivePrimaryColor(ShapeColor color)
        {
            _activePrimaryColor = color;
        }

        public void SetActiveSecondaryColor(ShapeColor color)
        {
            _activePrimaryColor = color;
        }

        public void SetActiveShadingType(ShapeShadingType shadingType)
        {
            _activeShapeShadingType = shadingType;
        }

        public void ChooseActiveShape()
        {
            _uiModule.GetDialogResponse(_dialogProvider.GetChooseShapeDialog());
        }

        public void ChooseActivePrimaryColor()
        {
            _uiModule.GetDialogResponse(_dialogProvider.GetChoosePrimaryColorDialog());
        }
        public void ChooseActiveSecondaryColor()
        {
            _uiModule.GetDialogResponse(_dialogProvider.GetChooseSecondaryColorDialog());
        }
        public void ChooseActiveShadingType()
        {
            _uiModule.GetDialogResponse(_dialogProvider.GetChooseShadingTypeDialog());
        }
        public void ChooseActiveStartAndEndPointMode()
        {
            _uiModule.GetDialogResponse(_dialogProvider.GetChooseStartAndEndPointModeDialog());
        }

        public void SetActiveShape(ShapeType shapeType)
        {
            _activeShapeType = shapeType;
        }

        public void SetActiveStartAndEndPointMode(MouseMode mouseMode)
        {
            _activeMouseMode = mouseMode;
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
