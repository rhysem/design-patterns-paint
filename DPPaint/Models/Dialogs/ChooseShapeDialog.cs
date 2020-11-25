using System;
using System.Collections.Generic;
using System.Linq;

using DPPaint.Models.ApplicationState;
using DPPaint.Views;

namespace DPPaint.Models.Dialogs
{
    public class ChooseShapeDialog : IDialogChoice<ShapeType>
    {
        private readonly IApplicationState _applicationState;

        public ChooseShapeDialog(IApplicationState applicationState)
        {
            _applicationState = applicationState;
        }

        public string GetDialogTitle()
        {
            return "Shape";
        }

        public string GetDialogText()
        {
            return "Select a shape from the menu below:";
        }

        public IEnumerable<ShapeType> GetDialogOptions()
        {
            return Enum.GetValues(typeof(ShapeType)).Cast<ShapeType>().ToList();
        }

        public ShapeType GetCurrentSelection()
        {
            return _applicationState.GetActiveShapeType();
        }
    }
}
