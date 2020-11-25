
using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint.Models.Dialogs
{
    public class DialogProvider : IDialogProvider
    {
        private readonly IDialogChoice<ShapeType> _chooseShapeDialog;
        private readonly IDialogChoice<ShapeColor> _choosePrimaryColorDialog;
        private readonly IDialogChoice<ShapeColor> _chooseSecondaryColorDialog;
        private readonly IDialogChoice<ShapeShadingType> _chooseShadingTypeDialog;
        private readonly IDialogChoice<MouseMode> _chooseStartAndEndPointModeDialog;
        private readonly IApplicationState _applicationState;

        public DialogProvider(IApplicationState applicationState)
        {
            _applicationState = applicationState;
            _chooseShapeDialog = new ChooseShapeDialog(_applicationState);
            _choosePrimaryColorDialog = new ChoosePrimaryColorDialog(_applicationState);
            _chooseSecondaryColorDialog = new ChooseSecondaryColorDialog(_applicationState);
            _chooseShadingTypeDialog = new ChooseShadingTypeDialog(_applicationState);
            _chooseStartAndEndPointModeDialog = new ChooseStartAndEndPointModeDialog(_applicationState);
        }

        public IDialogChoice<ShapeType> GetChooseShapeDialog()
        {
            return _chooseShapeDialog;
        }

        public IDialogChoice<ShapeColor> GetChoosePrimaryColorDialog()
        {
            return _choosePrimaryColorDialog;
        }

        public IDialogChoice<ShapeColor> GetChooseSecondaryColorDialog()
        {
            return _chooseSecondaryColorDialog;
        }

        public IDialogChoice<ShapeShadingType> GetChooseShadingTypeDialog()
        {
            return _chooseShadingTypeDialog;
        }

        public IDialogChoice<MouseMode> GetChooseStartAndEndPointModeDialog()
        {
            return _chooseStartAndEndPointModeDialog;
        }
    }
}
