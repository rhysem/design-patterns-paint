using System.Collections.Generic;

namespace DPPaint.Models
{
    public class MoveAction : Action
    {
        public List<object> SelectedShapes { get; set; }
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }
    }
}
