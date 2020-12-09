namespace DPPaint.Models.ApplicationState
{
    public interface IApplicationState
    {
        void ChooseActiveShape();
        void ChooseActivePrimaryColor();
        void ChooseActiveSecondaryColor();
        void ChooseActiveShadingType();
        void ChooseActiveStartAndEndPointMode();
        void SetActiveShape(ShapeType shapeType);

        void SetActivePrimaryColor(ShapeColor color);

        void SetActiveSecondaryColor(ShapeColor color);

        void SetActiveShadingType(ShapeShadingType shadingType);

        void SetActiveStartAndEndPointMode(MouseMode mouseMode);

        ShapeType GetActiveShapeType();

        ShapeColor GetActivePrimaryColor();

        ShapeColor GetActiveSecondaryColor();

        ShapeShadingType GetActiveShapeShadingType();

        MouseMode GetActiveMouseMode();
    }
}
