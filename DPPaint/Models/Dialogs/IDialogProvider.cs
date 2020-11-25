using DPPaint.Views;

namespace DPPaint.Models.Dialogs
{
    public interface IDialogProvider
    {
        IDialogChoice<ShapeType> GetChooseShapeDialog();
        IDialogChoice<ShapeColor> GetChoosePrimaryColorDialog();
        IDialogChoice<ShapeColor> GetChooseSecondaryColorDialog();
        IDialogChoice<ShapeShadingType> GetChooseShadingTypeDialog();
        IDialogChoice<MouseMode> GetChooseStartAndEndPointModeDialog();
    }
}
