namespace DPPaint.Models.ApplicationState
{
    public interface IApplicationState
    {
        void SetActiveShape();

        void SetActivePrimaryColor();

        void SetActiveSecondaryColor();

        void SetActiveShadingType();

        void SetActiveStartAndEndPointMode();

        ShapeType GetActiveShapeType();

        ShapeColor GetActivePrimaryColor();

        ShapeColor GetActiveSecondaryColor();

        ShapeShadingType GetActiveShapeShadingType();

        MouseMode GetActiveMouseMode();
    }
}
